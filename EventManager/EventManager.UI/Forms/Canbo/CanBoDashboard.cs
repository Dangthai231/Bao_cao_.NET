using EventManager.UI.Models;
using EventManager.UI.UserControls;
using EventManager.UI.UserControls.CanBo;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Canbo
{
    public partial class CanBoDashboard : Form
    {
        private UserSession _session;
        private Button _currentActiveButton;

        public CanBoDashboard(UserSession session)
        {
            InitializeComponent();
            _session = session;

            // Hiển thị tên người dùng và avatar
            string displayName = !string.IsNullOrWhiteSpace(_session?.FullName) ? _session.FullName : (_session?.Username ?? "canbo01");
            lblUsername.Text = _session?.Username ?? "canbo01";
            lblAvatarLetter.Text = (!string.IsNullOrWhiteSpace(displayName) ? displayName.Trim().Substring(0, 1).ToUpper() : "C");

            // Cấu hình form
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1250, 750);
            this.MinimumSize = new Size(1000, 600);

            // Gán sự kiện vẽ giao diện bo tròn / viền
            pnlSearchBox.Paint += PnlSearchBox_Paint;
            pnlAvatar.Paint += PnlAvatar_Paint;
            lblBadgeCount.Paint += LblBadgeCount_Paint;
            pnlTopNav.Paint += PnlTopNav_Paint;

            // Cấu hình bo tròn và hover cho các nút sidebar
            SetupNavButton(btnHome);
            SetupNavButton(btnReports);
            SetupNavButton(btnDocuments);
            SetupNavButton(btnTasks);
            SetupNavButton(btnParticipants);
            SetupNavButton(btnNotifications);
            SetupNavButton(btnLogout);

            btnHamburger.Click += (s, e) =>
            {
                pnlSidebar.Visible = !pnlSidebar.Visible;
            };

            // Nút active mặc định: Trang chủ
            SetActiveButton(btnHome);

            // Tải trang chủ
            LoadUserControl(new ucCanBoHome());
        }

        private void SetupNavButton(Button btn)
        {
            ApplyRoundedRegion(btn, 8);
            btn.SizeChanged += (s, e) => ApplyRoundedRegion(btn, 8);
        }

        private void ApplyRoundedRegion(Control ctrl, int radius)
        {
            if (ctrl.Width <= 0 || ctrl.Height <= 0) return;
            using var path = CreateRoundedRectangle(new Rectangle(0, 0, ctrl.Width, ctrl.Height), radius);
            ctrl.Region?.Dispose();
            ctrl.Region = new Region(path);
        }

        private void SetActiveButton(Button btn)
        {
            _currentActiveButton = btn;

            Button[] navButtons = { btnHome, btnReports, btnDocuments, btnTasks, btnParticipants, btnNotifications };
            foreach (var b in navButtons)
            {
                if (b == btn)
                {
                    b.BackColor = Color.FromArgb(37, 99, 235);
                    b.ForeColor = Color.White;
                    b.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(37, 99, 235);
                    b.FlatAppearance.MouseDownBackColor = Color.FromArgb(29, 78, 216);
                }
                else
                {
                    b.BackColor = Color.FromArgb(11, 27, 61);
                    b.ForeColor = Color.FromArgb(203, 213, 225);
                    b.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular);
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 42, 85);
                    b.FlatAppearance.MouseDownBackColor = Color.FromArgb(29, 78, 216);
                }
                ApplyRoundedRegion(b, 8);
            }
        }

        private void PnlSearchBox_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var path = CreateRoundedRectangle(new Rectangle(0, 0, pnlSearchBox.Width - 1, pnlSearchBox.Height - 1), 8);
            using var pen = new Pen(Color.FromArgb(203, 213, 225), 1);
            e.Graphics.DrawPath(pen, path);
        }

        private void PnlAvatar_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(Color.FromArgb(11, 27, 61));
            e.Graphics.FillEllipse(brush, 0, 0, pnlAvatar.Width - 1, pnlAvatar.Height - 1);
        }

        private void LblBadgeCount_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(Color.FromArgb(220, 38, 38));
            e.Graphics.FillEllipse(brush, 0, 0, lblBadgeCount.Width - 1, lblBadgeCount.Height - 1);
            TextRenderer.DrawText(e.Graphics, lblBadgeCount.Text, lblBadgeCount.Font,
                new Rectangle(0, 0, lblBadgeCount.Width, lblBadgeCount.Height),
                Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void PnlTopNav_Paint(object? sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
            e.Graphics.DrawLine(pen, 0, pnlTopNav.Height - 1, pnlTopNav.Width, pnlTopNav.Height - 1);
        }

        private GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        // --- HÀM HỖ TRỢ NHÚNG MÀN HÌNH CON VÀO PNLCONTENT ---
        private void LoadUserControl(UserControl uc)
        {
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnHome);
            LoadUserControl(new ucCanBoHome());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnReports);
            LoadUserControl(new ucBaoCaoThongKe());
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnDocuments);
            LoadUserControl(new ucQuanLyTaiLieu());
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnTasks);
            LoadUserControl(new ucQuanLyCongViec());
        }

        private void btnParticipants_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnParticipants);
            LoadUserControl(new ucQuanLyNguoiThamGia());
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnNotifications);
            LoadUserControl(new ucManageNotifications());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
