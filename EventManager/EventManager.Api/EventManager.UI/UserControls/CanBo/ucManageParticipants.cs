using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.CanBo
{
    public partial class ucQuanLyNguoiThamGia : UserControl
    {
        private readonly ApiService _apiService;
        private List<ParticipantDto> _allParticipants = new List<ParticipantDto>();

        public ucQuanLyNguoiThamGia()
        {
            InitializeComponent();
            _apiService = new ApiService();

            // Gắn sự kiện cho các nút
            this.Load += ucQuanLyNguoiThamGia_Load;
            btnSearch.Click += btnSearch_Click;
            btnClearSearch.Click += btnClearSearch_Click;
            btnViewDetails.Click += btnViewDetails_Click;
            btnCheckIn.Click += btnCheckIn_Click;
            btnRefresh.Click += btnRefresh_Click;
            txtSearchParticipants.KeyDown += TxtSearchParticipants_KeyDown;

            // Định dạng màu sắc cột điểm danh
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.CellDoubleClick += (s, e) => btnViewDetails_Click(s, e);

            // Xử lý ComboBox chọn trạng thái điểm danh trực tiếp trên DataGridView
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.DataError += (s, e) => { e.Cancel = true; };
        }

        // Tự động commit ngay khi chọn trong ComboBox để kích hoạt CellValueChanged
        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty && dataGridView1.CurrentCell is DataGridViewComboBoxCell)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Tự động lưu và cập nhật thống kê khi chọn trạng thái mới trong ComboBox
        private async void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (dataGridView1.Rows[e.RowIndex].DataBoundItem is ParticipantDto participant && !string.IsNullOrEmpty(cellValue))
                {
                    participant.AttendanceStatus = cellValue;
                    UpdateStatistics(_allParticipants);
                    await SaveAttendanceAsync(participant.ParticipantCode, cellValue);
                }
            }
        }

        private async Task SaveAttendanceAsync(string code, string status)
        {
            try
            {
                await _apiService.UpdateAttendanceStatusAsync(code, status);
            }
            catch
            {
                // Bỏ qua lỗi ngầm định hoặc hiển thị nếu cần
            }
        }

        // 1. Sự kiện khi mở màn hình: Cấu hình DataGridView và tải dữ liệu từ DB
        private async void ucQuanLyNguoiThamGia_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns[0].DataPropertyName = "ParticipantCode";
            dataGridView1.Columns[1].DataPropertyName = "FullName";
            dataGridView1.Columns[2].DataPropertyName = "Email";
            dataGridView1.Columns[3].DataPropertyName = "PhoneNumber";
            dataGridView1.Columns[4].DataPropertyName = "Role";
            dataGridView1.Columns[5].DataPropertyName = "AttendanceStatus";
            dataGridView1.Columns[6].DataPropertyName = "ConfirmationStatus";

            await LoadDataAsync();
        }

        // Tải danh sách người tham gia từ API Backend
        private async Task LoadDataAsync()
        {
            try
            {
                _allParticipants = await _apiService.GetParticipantsAsync();

                // Chuẩn hóa dữ liệu về đúng 3 lựa chọn của ComboBox: "Đã điểm danh", "Vắng", "Chưa điểm danh"
                foreach (var p in _allParticipants)
                {
                    if (p.AttendanceStatus == "Có mặt") p.AttendanceStatus = "Đã điểm danh";
                    else if (p.AttendanceStatus == "Vắng mặt") p.AttendanceStatus = "Vắng";
                    else if (string.IsNullOrWhiteSpace(p.AttendanceStatus)) p.AttendanceStatus = "Chưa điểm danh";
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _allParticipants;
                UpdateStatistics(_allParticipants);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách người tham gia: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật các nhãn thống kê góc trên bên phải
        private void UpdateStatistics(List<ParticipantDto> list)
        {
            lblTotalParticipants.Text = $"Tổng: {list.Count}";
            lblPresent.Text = $"Đã điểm danh: {list.Count(p => p.AttendanceStatus == "Đã điểm danh" || p.AttendanceStatus == "Có mặt")}";
            lblAbsent.Text = $"Vắng: {list.Count(p => p.AttendanceStatus == "Vắng" || p.AttendanceStatus == "Vắng mặt")}";
            lblNotCheckedIn.Text = $"Chưa điểm danh: {list.Count(p => p.AttendanceStatus == "Chưa điểm danh" || string.IsNullOrWhiteSpace(p.AttendanceStatus))}";
        }

        // 2. Nút "Tìm kiếm"
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchParticipants.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _allParticipants;
                UpdateStatistics(_allParticipants);
                return;
            }

            var filtered = _allParticipants.Where(p =>
                (p.FullName != null && p.FullName.ToLower().Contains(keyword)) ||
                (p.ParticipantCode != null && p.ParticipantCode.ToLower().Contains(keyword)) ||
                (p.Email != null && p.Email.ToLower().Contains(keyword)) ||
                (p.PhoneNumber != null && p.PhoneNumber.ToLower().Contains(keyword)) ||
                (p.Role != null && p.Role.ToLower().Contains(keyword)) ||
                (p.AttendanceStatus != null && p.AttendanceStatus.ToLower().Contains(keyword))
            ).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtered;
            UpdateStatistics(filtered);
        }

        private void TxtSearchParticipants_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // 3. Nút "Hủy tìm kiếm"
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchParticipants.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _allParticipants;
            UpdateStatistics(_allParticipants);
        }

        // 4. Nút "Xem chi tiết"
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is ParticipantDto selected)
            {
                string info = $"Mã người tham gia: {selected.ParticipantCode}\n" +
                              $"Họ và tên: {selected.FullName}\n" +
                              $"Email: {selected.Email}\n" +
                              $"Số điện thoại: {selected.PhoneNumber}\n" +
                              $"Vai trò: {selected.Role}\n" +
                              $"Điểm danh: {selected.AttendanceStatus}\n" +
                              $"Trạng thái: {selected.ConfirmationStatus}";

                MessageBox.Show(info, "Chi tiết người tham gia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một người tham gia trong danh sách để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 5. Nút "Lưu điểm danh" / Chuyển đổi trạng thái điểm danh
        private async void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is ParticipantDto selected)
            {
                // Chuyển đổi trạng thái: "Chưa điểm danh" -> "Đã điểm danh" -> "Vắng" -> "Chưa điểm danh"
                string newStatus = selected.AttendanceStatus switch
                {
                    "Đã điểm danh" => "Vắng",
                    "Vắng" => "Chưa điểm danh",
                    _ => "Đã điểm danh"
                };

                try
                {
                    bool isSuccess = await _apiService.UpdateAttendanceStatusAsync(selected.ParticipantCode, newStatus);
                    if (isSuccess)
                    {
                        selected.AttendanceStatus = newStatus;
                        dataGridView1.Refresh();
                        UpdateStatistics(_allParticipants);
                        MessageBox.Show($"Đã cập nhật điểm danh của '{selected.FullName}' thành '{newStatus}'!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật điểm danh thất bại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối máy chủ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một người tham gia để điểm danh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 6. Nút "Làm mới"
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchParticipants.Clear();
            await LoadDataAsync();
            MessageBox.Show("Đã làm mới danh sách người tham gia!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Tô màu nổi bật cột "Điểm danh"
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                string status = e.Value.ToString();

                if (status == "Đã điểm danh" || status == "Có mặt")
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231); // Xanh lá nhạt
                    e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);   // Xanh lá đậm
                    e.CellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                }
                else if (status == "Vắng" || status == "Vắng mặt")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226); // Đỏ nhạt
                    e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);   // Đỏ sẫm
                    e.CellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                }
                else if (status == "Chưa điểm danh")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 249, 195); // Vàng nhạt
                    e.CellStyle.ForeColor = Color.FromArgb(133, 77, 14);   // Nâu vàng
                }
            }
        }
    }
}
