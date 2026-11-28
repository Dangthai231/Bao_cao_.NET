using EventManager.UI.Forms.Admin;
using EventManager.UI.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.Admin
{
    /// <summary>
    /// Dashboard Admin: số liệu tổng quan + lối tắt tới các việc đang chờ duyệt
    /// </summary>
    public partial class TongQuanPanel : UserControl
    {
        private readonly ApiService _apiService = ApiService.Instance;
        private int _loadVersion;

        public TongQuanPanel()
        {
            InitializeComponent();
            if (AdminHelper.IsDesignMode) return;

            AdminGridHelper.Setup(dgvSapDienRa);
            AdminGridHelper.AddColumn(dgvSapDienRa, "Title", "Sự kiện");
            AdminGridHelper.AddColumn(dgvSapDienRa, "StartDate", "Bắt đầu", "dd/MM/yyyy HH:mm");
            AdminGridHelper.AddColumn(dgvSapDienRa, "Location", "Địa điểm");
            AdminGridHelper.AddColumn(dgvSapDienRa, "Status", "Trạng thái");

            btnTaiLai.Click += async (s, e) => await LoadDataAsync();
            btnXemSuKien.Click += (s, e) => Dashboard?.OpenEvents(plansTab: false);
            btnKeHoachChoDuyet.Click += (s, e) => Dashboard?.OpenEvents(plansTab: true);
            btnThongBaoChoDuyet.Click += (s, e) => Dashboard?.OpenNotifications(pendingOnly: true);
            btnYeuCauDoiThongTin.Click += (s, e) => Dashboard?.OpenAccounts(requestsTab: true);

            Load += async (s, e) => await LoadDataAsync();
        }

        private AdminDashboard Dashboard => FindForm() as AdminDashboard;

        private async Task LoadDataAsync()
        {
            int version = ++_loadVersion;
            try
            {
                lblTrangThai.Text = "Đang tải...";
                var data = await _apiService.GetAdminDashboardAsync();
                if (IsDisposed || version != _loadVersion) return;

                Dashboard?.SetPermissions(data.Permissions);
                btnXemSuKien.Enabled = btnKeHoachChoDuyet.Enabled = data.Permissions.Contains("Quản lý sự kiện");
                btnThongBaoChoDuyet.Enabled = data.Permissions.Contains("Quản lý thông báo");
                btnYeuCauDoiThongTin.Enabled = data.Permissions.Contains("Quản lý tài khoản");

                lblTongTaiKhoan.Text = "Tổng tài khoản\r\n" + data.TotalAccounts;
                lblTongSuKien.Text = "Tổng sự kiện\r\n" + data.TotalEvents;
                lblSapDienRa.Text = "Sắp diễn ra\r\n" + data.UpcomingCount;
                lblDaDang.Text = "Thông báo đã đăng\r\n" + data.PublishedNotifications;

                lblSoViec.Text = $"{data.PendingPlans + data.PendingNotifications + data.PendingProfiles} việc đang chờ";
                btnKeHoachChoDuyet.Text = $"Kế hoạch chờ duyệt ({data.PendingPlans})";
                btnThongBaoChoDuyet.Text = $"Thông báo chờ duyệt ({data.PendingNotifications})";
                btnYeuCauDoiThongTin.Text = $"Yêu cầu đổi thông tin ({data.PendingProfiles})";
                dgvSapDienRa.DataSource = data.UpcomingEvents;
                lblTrangThai.Text = "Đã tải dữ liệu";
            }
            catch (Exception ex)
            {
                if (IsDisposed || version != _loadVersion) return;
                lblTrangThai.Text = "Không tải được dữ liệu";
                AdminHelper.ShowError(ex);
            }
        }
    }
}
