using EventManager.UI.Services;
using EventManager.UI.Forms.Canbo;
using EventManager.UI.Forms.SinhVien;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Auth
{
    public partial class LoginForm : Form
    {
        private readonly ApiService _apiService;

        public LoginForm()
        {
            InitializeComponent();
            _apiService = ApiService.Instance;

            // Nhấn phím Enter để tự động kích hoạt nút Đăng nhập
            this.AcceptButton = btnLogin;

            // Hiệu ứng hover nút bấm
            btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = Color.FromArgb(29, 78, 216);
            btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = Color.FromArgb(37, 99, 235);

            // Vẽ viền nhẹ cho khung card đăng nhập
            pnlCard.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
            };
        }

        // Hiện / ẩn mật khẩu
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        // Xử lý đăng nhập
        private async void btnLogin_Click_1(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Đang xử lý...";

            try
            {
                var session = await _apiService.LoginAsync(user, pass);

                if (session != null)
                {
                    Form mainForm = null;

                    if (string.Equals(session.Role, "Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        // mainForm = new AdminDashboard(session);
                    }
                    else if (string.Equals(session.Role, "CanBo", StringComparison.OrdinalIgnoreCase) || 
                             string.Equals(session.Role, "CAN_BO", StringComparison.OrdinalIgnoreCase))
                    {
                        mainForm = new CanBoDashboard(session);
                    }
                    else if (string.Equals(session.Role, "HocSinh", StringComparison.OrdinalIgnoreCase) || 
                             string.Equals(session.Role, "HOC_SINH", StringComparison.OrdinalIgnoreCase) || 
                             string.Equals(session.Role, "SINH_VIEN", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(session.Role, "SinhVien", StringComparison.OrdinalIgnoreCase))
                    {
                        mainForm = new SinhVienDashboard(session);
                    }

                    if (mainForm != null)
                    {
                        this.Hide();
                        mainForm.FormClosed += (s, args) => this.Close();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show($"Vai trò '{session.Role}' hiện chưa được cấu hình giao diện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến Backend: " + ex.Message, "Lỗi Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "ĐĂNG NHẬP";
            }
        }
    }
}
