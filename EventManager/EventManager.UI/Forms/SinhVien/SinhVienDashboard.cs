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

            // Hiển thị tên + chữ cái đầu làm avatar trên thanh trên cùng
            // Hiển thị tên tài khoản (vd: hocsinh01), giống bên Cán bộ
            string displayName = !string.IsNullOrWhiteSpace(_session?.Username) ? _session.Username : "Sinh viên";
            lblWelcome.Text = displayName;
            lblAvatarLetter.Text = displayName.Trim().Substring(0, 1).ToUpper();
            lblPageTitle.Text = $"Xin chào, {displayName} 👋";

            this.Size = new Size(1250, 750);

            // Trang trí (bo góc nút menu, avatar tròn, đường kẻ dưới thanh trên)
            SinhVienTheme.RoundButtons(8, btnEvents, btnMyRegistrations, btnFeedback, btnProfile, btnLogout);
            SinhVienTheme.MakeCircle(pnlAvatar);
            pnlTopNav.Paint += (s, e) =>
            {
                using var pen = new Pen(SinhVienTheme.Border, 1);
                e.Graphics.DrawLine(pen, 0, pnlTopNav.Height - 1, pnlTopNav.Width, pnlTopNav.Height - 1);
            };

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
                bool active = btn == activeButton;
                btn.BackColor = active ? SinhVienTheme.Primary : SinhVienTheme.Navy;
                btn.ForeColor = active ? Color.White : SinhVienTheme.SidebarText;
                btn.Font = new Font("Segoe UI", active ? 9.5F : 9.25F, active ? FontStyle.Bold : FontStyle.Regular);
                btn.FlatAppearance.MouseOverBackColor = active ? SinhVienTheme.Primary : SinhVienTheme.NavyHover;
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

        // Ẩn/hiện sidebar
        private void btnHamburger_Click(object sender, EventArgs e)
        {
            pnlSidebar.Visible = !pnlSidebar.Visible;
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
