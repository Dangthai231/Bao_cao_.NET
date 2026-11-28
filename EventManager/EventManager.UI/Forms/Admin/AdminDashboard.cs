using EventManager.UI.Models;
using EventManager.UI.Services;
using EventManager.UI.UserControls.Admin;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Admin
{
    public partial class AdminDashboard : Form
    {
        private readonly ApiService _apiService = ApiService.Instance;
        internal void SetPermissions(IReadOnlyCollection<string> permissions)
        {
            btnSuKien.Enabled = permissions.Contains("Quản lý sự kiện");
            btnThongBao.Enabled = permissions.Contains("Quản lý thông báo");
            btnTaiKhoan.Enabled = permissions.Contains("Quản lý tài khoản");
            btnPhanQuyen.Enabled = permissions.Contains("Phân quyền");
            btnBaoCao.Enabled = permissions.Contains("Báo cáo");
            btnTimKiemChung.Enabled = btnTaiKhoan.Enabled || btnSuKien.Enabled || btnThongBao.Enabled;
        }

        public AdminDashboard()
        {
            InitializeComponent();
            SetMenuIcon(btnTongQuan, "\uE80F");
            SetMenuIcon(btnSuKien, "\uE787");
            SetMenuIcon(btnThongBao, "\uEA8F");
            SetMenuIcon(btnTaiKhoan, "\uE77B");
            SetMenuIcon(btnPhanQuyen, "\uE72E");
            SetMenuIcon(btnBaoCao, "\uE9D9");
            SetMenuIcon(btnCaiDat, "\uE713");
        }

        private void SetMenuIcon(Button button, string glyph)
        {
            int size = LogicalToDeviceUnits(22);
            var icon = new Bitmap(size, size);
            using (var graphics = Graphics.FromImage(icon))
            using (var font = new Font("Segoe MDL2 Assets", 13F))
            {
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                using var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                graphics.DrawString(glyph, font, Brushes.White, new RectangleF(0, 0, size, size), format);
            }
            button.Image = icon;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.Disposed += (_, _) => icon.Dispose();
        }

        public AdminDashboard(UserSession session) : this()
        {
            // Kiểm tra quyền ở giao diện (backend cũng kiểm tra lại ở mọi API)
            if (!string.Equals(session.Role, "Admin", StringComparison.OrdinalIgnoreCase))
                throw new UnauthorizedAccessException("Tài khoản không có quyền Admin.");

            SetPermissions(Array.Empty<string>());
            lblTaiKhoan.Text = session.FullName ?? session.Username;

            btnTongQuan.Click += (s, e) => ShowPage(btnTongQuan, new TongQuanPanel());
            btnSuKien.Click += (s, e) => ShowPage(btnSuKien, new QuanLySuKienPanel());
            btnThongBao.Click += (s, e) => ShowPage(btnThongBao, new QuanLyThongBaoPanel());
            btnTaiKhoan.Click += (s, e) => ShowPage(btnTaiKhoan, new QuanLyTaiKhoanPanel());
            btnPhanQuyen.Click += (s, e) => ShowPage(btnPhanQuyen, new PhanQuyenPanel(session.UserId));
            btnBaoCao.Click += (s, e) => ShowPage(btnBaoCao, new BaoCaoPanel());
            btnCaiDat.Click += (s, e) => ShowPage(btnCaiDat, new CaiDatPanel());

            txtTimKiemChung.KeyDown += txtTimKiemChung_KeyDown;
            btnTimKiemChung.Click += async (_, _) => await TimKiemAsync();

            ShowPage(btnTongQuan, new TongQuanPanel());
        }

        // ─── Điều hướng (được gọi từ màn hình Tổng quan) ─────────────
        public void OpenEvents(bool plansTab)
        {
            if (!btnSuKien.Enabled) return;
            var page = new QuanLySuKienPanel();
            page.ShowPlansTab = plansTab;
            ShowPage(btnSuKien, page);
        }

        public void OpenNotifications(bool pendingOnly)
        {
            if (!btnThongBao.Enabled) return;
            var page = new QuanLyThongBaoPanel();
            page.ShowPendingTab = pendingOnly;
            ShowPage(btnThongBao, page);
        }

        public void OpenAccounts(bool requestsTab, string keyword = "")
        {
            if (!btnTaiKhoan.Enabled) return;
            var page = new QuanLyTaiKhoanPanel();
            page.ShowRequestsTab = requestsTab;
            page.InitialKeyword = keyword;
            ShowPage(btnTaiKhoan, page);
        }

        private void ShowPage(Button menuButton, UserControl page)
        {
            // Tô màu nút đang chọn giống sidebar của Cán bộ
            foreach (Control control in pnlMenu.Controls)
                control.BackColor = pnlSidebar.BackColor;
            menuButton.BackColor = Color.FromArgb(37, 99, 235);
            lblManHinh.Text = menuButton.Text;

            while (pnlContent.Controls.Count > 0)
                pnlContent.Controls[0].Dispose();

            page.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(page);
        }

        private async void txtTimKiemChung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            await TimKiemAsync();
        }

        private async Task TimKiemAsync()
        {
            var keyword = txtTimKiemChung.Text.Trim();
            if (!btnTimKiemChung.Enabled || keyword.Length == 0)
                return;

            btnTimKiemChung.Enabled = false;
            btnTimKiemChung.Text = "…";
            try
            {
                var accounts = btnTaiKhoan.Enabled ? _apiService.GetAccountsAsync() : Task.FromResult(new List<AdminAccountDto>());
                var events = btnSuKien.Enabled ? _apiService.GetAdminEventsAsync(keyword) : Task.FromResult(new List<AdminEventDto>());
                var notifications = btnThongBao.Enabled ? _apiService.GetAdminNotificationsAsync(keyword) : Task.FromResult(new List<AdminNotificationDto>());
                var plans = btnSuKien.Enabled ? _apiService.GetPlansAsync() : Task.FromResult(new List<AdminPlanDto>());
                var requests = btnTaiKhoan.Enabled ? _apiService.GetChangeRequestsAsync() : Task.FromResult(new List<AdminChangeRequestDto>());
                await Task.WhenAll(accounts, events, notifications, plans, requests);
                if (IsDisposed || Disposing)
                    return;

                bool Matches(string text) => text.Contains(keyword, StringComparison.OrdinalIgnoreCase);
                var results = (await accounts)
                    .Where(a => Matches($"{a.Username} {a.FullName} {a.Email} {a.StudentCode} {a.ClassName}"))
                    .Select(a => new SearchResult("Tài khoản", a.FullName ?? a.Username, a.Username))
                    .Concat((await events).Select(e => new SearchResult("Sự kiện", e.Title, e.Location ?? "")))
                    .Concat((await notifications).Select(n => new SearchResult("Thông báo", n.Title ?? "", n.NotificationCode ?? "")))
                    .Concat((await plans)
                        .Where(p => Matches($"{p.PlanName} {p.Objective} {p.Description} {p.Location}"))
                        .Select(p => new SearchResult("Kế hoạch", p.PlanName, p.Location)))
                    .Concat((await requests)
                        .Where(r => Matches($"{r.Username} {r.CurrentFullName} {r.NewFullName} {r.CurrentEmail} {r.NewEmail}"))
                        .Select(r => new SearchResult("Yêu cầu đổi thông tin", r.NewFullName ?? r.Username, r.Username)))
                    .ToList();
                HienKetQuaTimKiem(keyword, results);
            }
            catch (Exception ex)
            {
                if (!IsDisposed && !Disposing)
                    AdminHelper.ShowError(ex);
            }
            finally
            {
                if (!IsDisposed && !Disposing)
                {
                    btnTimKiemChung.Text = "Tìm";
                    btnTimKiemChung.Enabled = btnTaiKhoan.Enabled || btnSuKien.Enabled || btnThongBao.Enabled;
                }
            }
        }

        private sealed record SearchResult(string Category, string Title, string Detail);

        private void HienKetQuaTimKiem(string keyword, System.Collections.Generic.List<SearchResult> results)
        {
            using var dialog = new Form
            {
                Text = "Kết quả tìm kiếm",
                Font = Font,
                StartPosition = FormStartPosition.CenterParent,
                ClientSize = new Size(700, 420),
                MinimumSize = new Size(500, 300),
                Padding = new Padding(16),
                BackColor = Color.White,
                ShowInTaskbar = false
            };
            var summary = new Label
            {
                Text = results.Count == 0 ? $"Không tìm thấy kết quả cho “{keyword}”." : $"{results.Count} kết quả cho “{keyword}”",
                Dock = DockStyle.Top,
                Height = 40,
                AutoEllipsis = true,
                TextAlign = ContentAlignment.MiddleLeft
            };
            var grid = new DataGridView { Dock = DockStyle.Fill };
            AdminGridHelper.Setup(grid);
            AdminGridHelper.AddColumn(grid, nameof(SearchResult.Category), "Loại");
            AdminGridHelper.AddColumn(grid, nameof(SearchResult.Title), "Kết quả");
            AdminGridHelper.AddColumn(grid, nameof(SearchResult.Detail), "Thông tin");
            grid.DataSource = results;
            dialog.Controls.Add(grid);
            dialog.Controls.Add(summary);
            dialog.ShowDialog(this);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (!AdminHelper.Confirm("Bạn có chắc muốn đăng xuất?")) return;

            // LoginForm là form chính của ứng dụng: đóng Dashboard sẽ đóng luôn LoginForm và thoát app.
            // Khởi động lại ứng dụng để quay về màn hình đăng nhập với phiên mới (token cũ bị bỏ).
            Application.Restart();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlSidebar.Visible = !pnlSidebar.Visible;
        }
    }
}
