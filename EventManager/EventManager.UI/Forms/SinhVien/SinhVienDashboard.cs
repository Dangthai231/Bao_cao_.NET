using EventManager.UI.Models;
using EventManager.UI.UserControls.SinhVien;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.Forms.SinhVien
{
    public partial class SinhVienDashboard : Form
    {
        private readonly UserSession _session;

        // Constructor nhận thông tin đăng nhập truyền sang từ LoginForm
        public SinhVienDashboard(UserSession session)
        {
            InitializeComponent();
            _session = session;

            lblWelcome.Text = $"Xin chào,\n{(string.IsNullOrWhiteSpace(_session.FullName) ? _session.Username : _session.FullName)}";

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1150, 700);
            this.MinimumSize = new Size(950, 550);

            // Cố định nút Đăng xuất ở dưới cùng sidebar
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLogout.Location = new Point(10, pnlSidebar.ClientSize.Height - btnLogout.Height - 15);
            btnLogout.Width = pnlSidebar.ClientSize.Width - 20;

            // Mở màn hình Tra cứu sự kiện mặc định
            LoadUserControl(new ucTraCuuSuKien(_session), btnEvents);
        }

        // --- Nhúng màn hình con vào pnlContent và tô sáng nút đang chọn ---
        private void LoadUserControl(UserControl uc, Button activeButton)
        {
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);

            foreach (var btn in new[] { btnEvents, btnMyRegistrations, btnFeedback, btnProfile })
            {
                btn.BackColor = btn == activeButton ? Color.FromArgb(37, 99, 235) : SystemColors.Control;
                btn.ForeColor = btn == activeButton ? Color.White : SystemColors.ControlText;
            }
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucTraCuuSuKien(_session), btnEvents);
        }

        private void btnMyRegistrations_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucSuKienCuaToi(_session), btnMyRegistrations);
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucDanhGiaPhanHoi(_session), btnFeedback);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucThongTinCaNhan(_session), btnProfile);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng Dashboard → LoginForm sẽ đóng theo (do FormClosed event)
            }
        }
    }
}
