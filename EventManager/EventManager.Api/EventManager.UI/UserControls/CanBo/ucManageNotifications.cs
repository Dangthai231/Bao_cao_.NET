using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.CanBo
{
    public partial class ucManageNotifications : UserControl
    {
        private readonly ApiService _apiService;
        private List<NotificationDto> _allNotifications; // Lưu tạm danh sách để tìm kiếm
        public ucManageNotifications()
        {
            InitializeComponent();
            _apiService = new ApiService();
            dgvNotifications.AutoGenerateColumns = false;
            this.Load += ucQuanLyThongBao_Load;
            this.Resize += ucManageNotifications_Resize;
        }

        private void ucManageNotifications_Resize(object? sender, EventArgs e)
        {
            if (this.ClientSize.Width <= 100 || this.ClientSize.Height <= 100) return;

            int padding = 15;
            int top = 40;
            int bottomMargin = 40;
            int h = Math.Max(250, this.ClientSize.Height - top - bottomMargin);

            int totalW = this.ClientSize.Width - padding * 3;
            int w1 = (int)(totalW * 0.46);
            int w2 = totalW - w1;

            groupBox1.Location = new Point(padding, top);
            groupBox1.Size = new Size(w1, h);

            groupBox2.Location = new Point(padding * 2 + w1, top);
            groupBox2.Size = new Size(w2, h);

            lblSystemMessage.Location = new Point(padding, this.ClientSize.Height - 25);
        }
        // --- 1. SỰ KIỆN LOAD: Tải dữ liệu khi mở form ---
        private async void ucQuanLyThongBao_Load(object sender, EventArgs e)
        {
            // Map cột DataGridView với thuộc tính của DTO
            dgvNotifications.Columns[0].DataPropertyName = "NotificationCode";
            dgvNotifications.Columns[1].DataPropertyName = "Title";
            dgvNotifications.Columns[2].DataPropertyName = "TargetAudience";
            dgvNotifications.Columns[3].DataPropertyName = "SendDate";
            dgvNotifications.Columns[4].DataPropertyName = "Status";

            await LoadDataAsync();
            lblSystemMessage.Text = ""; // Xóa dòng chữ thông báo mặc định
        }
        private async Task LoadDataAsync()
        {
            _allNotifications = await _apiService.GetNotificationsAsync();
            dgvNotifications.DataSource = _allNotifications;
        }

        private void dgvNotifications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvNotifications.CurrentRow != null)
            {
                var selectedNotif = (NotificationDto)dgvNotifications.CurrentRow.DataBoundItem;

                txtNotificationTitle.Text = selectedNotif.Title;
                richTextBox1.Text = selectedNotif.Content;
                cboTargetAudience.SelectedItem = selectedNotif.TargetAudience;
                dtpSendDate.Value = selectedNotif.SendDate;
                cboStatus.SelectedItem = selectedNotif.Status;

                // Lưu tạm Mã vào Tag của nút Cập nhật để dùng sau
                btnUpdateNotification.Tag = selectedNotif.NotificationCode;
            }
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            txtNotificationTitle.Clear();
            richTextBox1.Clear();
            cboTargetAudience.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;
            dtpSendDate.Value = DateTime.Now;
            btnUpdateNotification.Tag = null; // Xóa Mã tạm

            lblSystemMessage.Text = "Đã làm mới biểu mẫu.";
            lblSystemMessage.ForeColor = System.Drawing.Color.Blue;
        }

        private async void btnCreateNotification_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNotificationTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newNotif = new NotificationDto
            {
                // Để BE tự sinh Mã (NotificationCode)
                Title = txtNotificationTitle.Text.Trim(),
                Content = richTextBox1.Text.Trim(),
                TargetAudience = cboTargetAudience.Text,
                SendDate = dtpSendDate.Value,
                Status = cboStatus.Text
            };

            bool isSuccess = await _apiService.CreateNotificationAsync(newNotif);
            if (isSuccess)
            {
                ShowSystemMessage("Tạo thông báo thành công!");
                btnResetForm_Click(sender, e);
                await LoadDataAsync();
            }
            else
            {
                ShowSystemMessage("Tạo thông báo thất bại!", true);
            }
        }

        private async void btnUpdateNotification_Click(object sender, EventArgs e)
        {
            if (btnUpdateNotification.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn một thông báo từ danh sách để cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updatedNotif = new NotificationDto
            {
                NotificationCode = btnUpdateNotification.Tag.ToString(),
                Title = txtNotificationTitle.Text.Trim(),
                Content = richTextBox1.Text.Trim(),
                TargetAudience = cboTargetAudience.Text,
                SendDate = dtpSendDate.Value,
                Status = cboStatus.Text
            };

            bool isSuccess = await _apiService.UpdateNotificationAsync(updatedNotif);
            if (isSuccess)
            {
                ShowSystemMessage("Cập nhật thông báo thành công!");
                await LoadDataAsync();
            }
            else
            {
                ShowSystemMessage("Cập nhật thất bại!");
            }
        }

        private async void btnDeleteNotification_Click(object sender, EventArgs e)
        {
            if (btnUpdateNotification.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn một thông báo để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string code = btnUpdateNotification.Tag.ToString();
            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa thông báo {code}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool isDeleted = await _apiService.DeleteNotificationAsync(code);
                if (isDeleted)
                {
                    ShowSystemMessage("Xóa thông báo thành công!");
                    btnResetForm_Click(sender, e);
                    await LoadDataAsync();
                }
                else
                {
                    ShowSystemMessage("Xóa thất bại!", true);
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchNotification.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                dgvNotifications.DataSource = _allNotifications;
            }
            else
            {
                // Lọc theo Tiêu đề hoặc Mã
                var filtered = _allNotifications.Where(n =>
                    (n.Title != null && n.Title.ToLower().Contains(keyword)) ||
                    (n.NotificationCode != null && n.NotificationCode.ToLower().Contains(keyword))
                ).ToList();

                dgvNotifications.DataSource = filtered;
            }
        }

        private void ShowSystemMessage(string msg, bool isError = false)
        {
            lblSystemMessage.Text = msg;
            lblSystemMessage.ForeColor = isError ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }
    }
}
