using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.SinhVien
{
    /// <summary>
    /// Use case "Đăng ký tham gia sự kiện": Xem thông tin đăng ký, Hủy đăng ký, Xem trạng thái tham gia
    /// </summary>
    public partial class ucSuKienCuaToi : UserControl
    {
        private readonly ApiService _apiService;
        private readonly UserSession _session;
        private List<RegistrationDto> _registrations = new List<RegistrationDto>();

        public ucSuKienCuaToi(UserSession session)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _session = session;

            cboFilter.Items.AddRange(new object[] { "Tất cả", "Đang đăng ký", "Đã hủy" });
            cboFilter.SelectedIndex = 1;

            this.Load += async (s, e) => await LoadDataAsync();
            btnRefresh.Click += async (s, e) => await LoadDataAsync();
            btnViewInfo.Click += btnViewInfo_Click;
            btnCancel.Click += async (s, e) => await CancelSelectedAsync();
            cboFilter.SelectedIndexChanged += (s, e) => BindGrid();

            dgvRegistrations.AutoGenerateColumns = false;
            dgvRegistrations.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) btnViewInfo_Click(s, e); };
            dgvRegistrations.CellFormatting += dgvRegistrations_CellFormatting;
            dgvRegistrations.SelectionChanged += (s, e) =>
                btnCancel.Enabled = SelectedRegistration?.CanCancel == true;

            // Bỏ chọn dòng đầu tiên mà DataGridView tự chọn sau khi nạp dữ liệu (tránh hủy nhầm)
            dgvRegistrations.DataBindingComplete += (s, e) =>
            {
                dgvRegistrations.ClearSelection();
                dgvRegistrations.CurrentCell = null;
                btnCancel.Enabled = false;
            };
        }

        private RegistrationDto SelectedRegistration => dgvRegistrations.CurrentRow?.DataBoundItem as RegistrationDto;

        private async Task LoadDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _registrations = await _apiService.GetMyRegistrationsAsync(_session.UserId);
                BindGrid();
                UpdateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BindGrid()
        {
            IEnumerable<RegistrationDto> list = _registrations;
            if (cboFilter.SelectedIndex == 1) list = list.Where(r => r.ConfirmationStatus != "Đã hủy");
            else if (cboFilter.SelectedIndex == 2) list = list.Where(r => r.ConfirmationStatus == "Đã hủy");

            dgvRegistrations.DataSource = null;
            dgvRegistrations.DataSource = list.ToList();
            btnCancel.Enabled = SelectedRegistration?.CanCancel == true;
        }

        // Thống kê nhanh trạng thái tham gia
        private void UpdateStatistics()
        {
            var active = _registrations.Where(r => r.ConfirmationStatus != "Đã hủy").ToList();
            lblTotal.Text = $"Đang đăng ký: {active.Count}";
            lblUpcoming.Text = $"Sắp diễn ra: {active.Count(r => r.EventStatus == "Sắp diễn ra")}";
            lblAttended.Text = $"Đã tham gia: {active.Count(r => r.AttendanceStatus == "Đã điểm danh")}";
            lblAbsent.Text = $"Vắng: {active.Count(r => r.AttendanceStatus == "Vắng")}";
        }

        // 1. Xem thông tin đăng ký
        private void btnViewInfo_Click(object sender, EventArgs e)
        {
            var r = SelectedRegistration;
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn một đăng ký để xem thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string info = $"Mã đăng ký: {r.ParticipantCode}\n" +
                          $"Sự kiện: {r.EventTitle}\n" +
                          $"Thời gian: {r.StartDate:dd/MM/yyyy HH:mm}" + (r.EndDate.HasValue ? $" - {r.EndDate:dd/MM/yyyy HH:mm}" : "") + "\n" +
                          $"Địa điểm: {(string.IsNullOrWhiteSpace(r.Location) ? "Đang cập nhật" : r.Location)}\n" +
                          $"Trạng thái sự kiện: {r.EventStatus}\n" +
                          $"Ngày đăng ký: {r.RegisteredAt:dd/MM/yyyy HH:mm}\n" +
                          $"Trạng thái đăng ký: {r.ConfirmationStatus}\n" +
                          $"Trạng thái tham gia: {r.AttendanceStatus}";

            MessageBox.Show(info, "Thông tin đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 2. Hủy đăng ký
        private async Task CancelSelectedAsync()
        {
            var r = SelectedRegistration;
            if (r == null || !r.CanCancel)
            {
                MessageBox.Show("Chỉ được hủy đăng ký trước khi sự kiện bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var answer = MessageBox.Show($"Bạn chắc chắn muốn hủy đăng ký sự kiện \"{r.EventTitle}\"?", "Xác nhận hủy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;

            try
            {
                var (success, message) = await _apiService.CancelRegistrationAsync(r.RegistrationId, _session.UserId);
                MessageBox.Show(message, success ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (success)
                    await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. Tô màu cột Trạng thái tham gia (điểm danh) và Trạng thái đăng ký
        private void dgvRegistrations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            var column = dgvRegistrations.Columns[e.ColumnIndex];
            string value = e.Value.ToString();

            if (column == colAttendance)
            {
                if (value == "Đã điểm danh")
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);
                    e.CellStyle.Font = new Font(dgvRegistrations.Font, FontStyle.Bold);
                }
                else if (value == "Vắng")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                    e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);
                    e.CellStyle.Font = new Font(dgvRegistrations.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 249, 195);
                    e.CellStyle.ForeColor = Color.FromArgb(133, 77, 14);
                }
            }
            else if (column == colConfirmation && value == "Đã hủy")
            {
                e.CellStyle.ForeColor = Color.Gray;
                e.CellStyle.Font = new Font(dgvRegistrations.Font, FontStyle.Strikeout);
            }
        }
    }
}
