using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.SinhVien
{
    /// <summary>
    /// Use case "Tra cứu sự kiện": Xem danh sách sự kiện, Tìm kiếm sự kiện,
    /// Lọc sự kiện theo ngày, Xem chi tiết sự kiện (+ Đăng ký tham gia)
    /// </summary>
    public partial class ucTraCuuSuKien : UserControl
    {
        private readonly ApiService _apiService;
        private readonly UserSession _session;
        private List<StudentEventDto> _events = new List<StudentEventDto>();

        public ucTraCuuSuKien(UserSession session)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _session = session;

            // Mặc định lọc từ hôm nay đến 3 tháng sau
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddMonths(3);
            dtpFrom.Enabled = dtpTo.Enabled = chkFilterDate.Checked;

            this.Load += async (s, e) => await LoadEventsAsync();
            btnSearch.Click += async (s, e) => await LoadEventsAsync();
            btnClear.Click += btnClear_Click;
            btnViewDetail.Click += async (s, e) => await ShowDetailAsync();
            btnRegister.Click += async (s, e) => await RegisterSelectedAsync();
            chkFilterDate.CheckedChanged += (s, e) => dtpFrom.Enabled = dtpTo.Enabled = chkFilterDate.Checked;
            txtKeyword.KeyDown += TxtKeyword_KeyDown;

            dgvEvents.AutoGenerateColumns = false;
            dgvEvents.CellDoubleClick += async (s, e) => { if (e.RowIndex >= 0) await ShowDetailAsync(); };
            dgvEvents.CellFormatting += dgvEvents_CellFormatting;
            dgvEvents.SelectionChanged += (s, e) => UpdateButtons();

            // DataGridView mặc định tự chọn dòng đầu tiên sau khi nạp dữ liệu → bỏ chọn,
            // để sinh viên phải tự bấm vào sự kiện mới đăng ký được (tránh đăng ký nhầm)
            dgvEvents.DataBindingComplete += (s, e) =>
            {
                dgvEvents.ClearSelection();
                dgvEvents.CurrentCell = null;
                UpdateButtons();
            };
        }

        // 1. Xem danh sách + Tìm kiếm + Lọc theo ngày: gọi API với các tham số lọc
        private async Task LoadEventsAsync()
        {
            DateTime? from = null, to = null;
            if (chkFilterDate.Checked)
            {
                if (dtpFrom.Value.Date > dtpTo.Value.Date)
                {
                    MessageBox.Show("\"Từ ngày\" phải nhỏ hơn hoặc bằng \"Đến ngày\"!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                from = dtpFrom.Value.Date;
                to = dtpTo.Value.Date;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                _events = await _apiService.GetStudentEventsAsync(_session.UserId, txtKeyword.Text, from, to);

                dgvEvents.DataSource = null;
                dgvEvents.DataSource = _events;
                lblCount.Text = $"Tìm thấy {_events.Count} sự kiện";
                UpdateButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sự kiện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void TxtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnSearch.PerformClick();
            }
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            chkFilterDate.Checked = false;
            await LoadEventsAsync();
        }

        private StudentEventDto SelectedEvent => dgvEvents.CurrentRow?.DataBoundItem as StudentEventDto;

        private void UpdateButtons()
        {
            var ev = SelectedEvent;
            btnViewDetail.Enabled = ev != null;
            btnRegister.Enabled = ev != null && ev.CanRegister;
        }

        // 2. Xem chi tiết sự kiện (lấy dữ liệu mới nhất từ server)
        private async Task ShowDetailAsync()
        {
            if (SelectedEvent == null)
            {
                MessageBox.Show("Vui lòng chọn một sự kiện để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var ev = await _apiService.GetStudentEventDetailAsync(SelectedEvent.Id, _session.UserId);
                if (ev == null)
                {
                    MessageBox.Show("Không tìm thấy sự kiện!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string info = $"Tên sự kiện: {ev.Title}\n" +
                              $"Thời gian: {ev.StartDate:dd/MM/yyyy HH:mm}" + (ev.EndDate.HasValue ? $" - {ev.EndDate:dd/MM/yyyy HH:mm}" : "") + "\n" +
                              $"Địa điểm: {(string.IsNullOrWhiteSpace(ev.Location) ? "Đang cập nhật" : ev.Location)}\n" +
                              $"Trạng thái: {ev.Status}\n" +
                              $"Số lượng đăng ký: {ev.SlotText}" + (ev.MaxParticipants == 0 ? " (không giới hạn)" : "") + "\n" +
                              $"Mô tả: {(string.IsNullOrWhiteSpace(ev.Description) ? "Chưa có mô tả" : ev.Description)}\n\n" +
                              (ev.IsRegistered ? "✔ Bạn đã đăng ký sự kiện này." : "");

                if (ev.CanRegister)
                {
                    var answer = MessageBox.Show(info + "Bạn có muốn đăng ký tham gia sự kiện này không?", "Chi tiết sự kiện",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (answer == DialogResult.Yes)
                        await RegisterAsync(ev);
                }
                else
                {
                    MessageBox.Show(info, "Chi tiết sự kiện", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. Đăng ký tham gia sự kiện đang chọn
        private async Task RegisterSelectedAsync()
        {
            var ev = SelectedEvent;
            if (ev == null) return;

            var answer = MessageBox.Show($"Xác nhận đăng ký tham gia sự kiện \"{ev.Title}\"?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
                await RegisterAsync(ev);
        }

        private async Task RegisterAsync(StudentEventDto ev)
        {
            try
            {
                var (success, message) = await _apiService.RegisterEventAsync(_session.UserId, ev.Id);
                MessageBox.Show(message, success ? "Thành công" : "Không thể đăng ký",
                    MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (success)
                    await LoadEventsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tô màu cột Trạng thái
        private void dgvEvents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEvents.Columns[e.ColumnIndex] != colStatus || e.Value == null) return;

            switch (e.Value.ToString())
            {
                case "Sắp diễn ra":
                    e.CellStyle.BackColor = Color.FromArgb(219, 234, 254);
                    e.CellStyle.ForeColor = Color.FromArgb(30, 64, 175);
                    break;
                case "Đang diễn ra":
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);
                    break;
                case "Đã hủy":
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                    e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);
                    break;
                default:
                    e.CellStyle.ForeColor = Color.Gray;
                    break;
            }
        }
    }
}
