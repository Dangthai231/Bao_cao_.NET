using EventManager.UI.Models;
using System;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Admin
{
    /// <summary>
    /// Form tạo / cập nhật thông báo
    /// </summary>
    public partial class ThongBaoForm : Form
    {
        /// <summary>Dữ liệu người dùng nhập, đọc sau khi form trả về OK</summary>
        public AdminNotificationRequest Result { get; private set; }

        // Tạo thông báo mới
        public ThongBaoForm()
        {
            InitializeComponent();
            Text = "Tạo thông báo";
            cboDoiTuong.SelectedIndex = 0;
            btnLuu.Click += btnLuu_Click;
        }

        // Cập nhật thông báo có sẵn
        public ThongBaoForm(AdminNotificationDto n) : this()
        {
            Text = "Cập nhật thông báo " + n.NotificationCode;
            txtTieuDe.Text = n.Title;
            txtNoiDung.Text = n.Content;
            if (!string.IsNullOrWhiteSpace(n.TargetAudience))
                cboDoiTuong.Text = n.TargetAudience;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text))
            {
                MessageBox.Show(this, "Vui lòng nhập tiêu đề thông báo.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTieuDe.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show(this, "Vui lòng nhập nội dung thông báo.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDung.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(cboDoiTuong.Text))
            {
                MessageBox.Show(this, "Vui lòng chọn đối tượng nhận thông báo.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDoiTuong.Focus();
                return;
            }

            Result = new AdminNotificationRequest
            {
                Title = txtTieuDe.Text.Trim(),
                Content = txtNoiDung.Text.Trim(),
                TargetAudience = cboDoiTuong.Text.Trim()
            };
            DialogResult = DialogResult.OK;
        }
    }
}
