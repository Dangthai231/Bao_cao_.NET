using EventManager.UI.Forms.Admin;
using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.Admin
{
    /// <summary>
    /// Quản lý thông báo: tạo, cập nhật, duyệt / từ chối, đăng, gỡ, tra cứu.
    /// Mỗi tab lọc theo một trạng thái.
    /// </summary>
    public partial class QuanLyThongBaoPanel : UserControl
    {
        // Thứ tự trùng với thứ tự tab trong Designer

        private readonly ApiService _apiService = ApiService.Instance;
        private const int PageSize = 10;
        private int _page;
        private int _loadVersion;
        private DateTime? _fromDate;
        private DateTime? _throughDate;
        private List<AdminNotificationDto> _notifications = new List<AdminNotificationDto>();

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowPendingTab { get; set; }

        public QuanLyThongBaoPanel()
        {
            InitializeComponent();
            if (AdminHelper.IsDesignMode) return;

            pnlThaoTac.SizeChanged += (_, _) => CapNhatBoCucBoLoc();
            cboDoiTuongLoc.LocationChanged += (_, _) => CanNutVoiODoiTuong();
            cboDoiTuongLoc.SizeChanged += (_, _) => CanNutVoiODoiTuong();
            pnlDoiTuong.LocationChanged += (_, _) => CanNutVoiODoiTuong();
            pnlNutLoc.LocationChanged += (_, _) => CanNutVoiODoiTuong();
            btnTimKiem.SizeChanged += (_, _) => CanNutVoiODoiTuong();
            CapNhatBoCucBoLoc();
            CanNutVoiODoiTuong();

            var goiYBoLoc = new ToolTip();
            goiYBoLoc.SetToolTip(btnTimKiem, "Tìm thông báo theo bộ lọc");
            goiYBoLoc.SetToolTip(btnXoaLoc, "Xóa bộ lọc");
            Disposed += (_, _) => goiYBoLoc.Dispose();
            txtTimKiem.KeyDown += (_, e) =>
            {
                if (e.KeyCode != Keys.Enter) return;
                e.SuppressKeyPress = true;
                btnTimKiem.PerformClick();
            };

            AdminGridHelper.Setup(dgvThongBao);
            AdminGridHelper.ShowStatusWhenEmpty(dgvThongBao, lblTrangThai);
            dgvThongBao.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStt",
                HeaderText = "STT",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = LogicalToDeviceUnits(58),
                SortMode = DataGridViewColumnSortMode.NotSortable,
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvThongBao.CellFormatting += (_, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0 ||
                    dgvThongBao.Columns[e.ColumnIndex].Name != "colStt")
                    return;

                e.Value = (_page * PageSize + e.RowIndex + 1).ToString();
                e.FormattingApplied = true;
            };
            AdminGridHelper.AddColumn(dgvThongBao, "NotificationCode", "Mã");
            AdminGridHelper.AddColumn(dgvThongBao, "Title", "Thông báo");
            AdminGridHelper.AddColumn(dgvThongBao, "CreatorName", "Người tạo");
            AdminGridHelper.AddColumn(dgvThongBao, "SendDate", "Ngày gửi", "dd/MM/yyyy HH:mm");
            AdminGridHelper.AddColumn(dgvThongBao, "Status", "Trạng thái");
            AdminGridHelper.AddActionColumns(dgvThongBao, item => GetActions((AdminNotificationDto)item),
                "Chi tiết", "Sửa", "Duyệt", "Từ chối", "Đăng", "Gỡ");
            foreach (var column in dgvThongBao.Columns.OfType<DataGridViewButtonColumn>())
            {
                column.HeaderText = column.Text == "Chi tiết" ? "Xem" : column.Text;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                column.MinimumWidth = LogicalToDeviceUnits(44);
                column.CellTemplate!.ToolTipText = column.Text;
            }
            dgvThongBao.CellPainting += VeNutThongBao;
            dgvThongBao.CellMouseEnter += AdminGridHelper.InvalidateActionButton;
            dgvThongBao.CellMouseLeave += AdminGridHelper.InvalidateActionButton;
            dgvThongBao.CellContentClick += dgvThongBao_CellContentClick;

            cboDoiTuongLoc.Items.Add("Mọi đối tượng");
            cboDoiTuongLoc.SelectedIndex = 0;
            AdminHelper.ConfigureOptionalDate(dtpTuNgay);
            AdminHelper.ConfigureOptionalDate(dtpDenNgay);
            btnXoaLoc.Click += (s, e) =>
            {
                txtTimKiem.Clear();
                dtpTuNgay.Checked = false;
                dtpDenNgay.Checked = false;
                _fromDate = null;
                _throughDate = null;
                cboDoiTuongLoc.SelectedIndex = 0;
                cboTrangThaiLoc.SelectedIndex = 0;
                _page = 0;
                ApDungBoLoc();
            };
            btnTimKiem.Click += (s, e) =>
            {
                if (!AdminHelper.TryReadDateRange(dtpTuNgay, dtpDenNgay, out var from, out var through))
                {
                    lblTrangThai.Text = "Từ ngày phải trước hoặc bằng đến ngày.";
                    dtpDenNgay.Focus();
                    return;
                }

                _fromDate = from;
                _throughDate = through;
                _page = 0;
                ApDungBoLoc();
            };
            btnLamMoi.Click += async (s, e) => await LoadDataAsync();
            btnTaoThongBao.Click += async (s, e) => await CreateAsync();
            cboTrangThaiLoc.SelectedIndexChanged += (_, _) =>
            {
                _page = 0;
                ApDungBoLoc();
            };

            Load += async (s, e) =>
            {
                if (ShowPendingTab) cboTrangThaiLoc.SelectedItem = "Chờ duyệt";
                await LoadDataAsync();
            };
        }

        /// <summary>Các nút được phép theo trạng thái thông báo</summary>
        private static string[] GetActions(AdminNotificationDto n)
        {
            if (AdminHelper.IsPendingNotification(n.Status)) return new[] { "Chi tiết", "Sửa", "Duyệt", "Từ chối" };
            if (n.Status == "Đã duyệt") return new[] { "Chi tiết", "Sửa", "Đăng" };
            if (n.Status == "Từ chối") return new[] { "Chi tiết", "Sửa" };
            if (n.Status == "Đã đăng") return new[] { "Chi tiết", "Gỡ" };
            return new[] { "Chi tiết" };
        }

        private void CapNhatBoCucBoLoc()
        {
            bool motHang = pnlThaoTac.ClientSize.Width >= LogicalToDeviceUnits(790);
            if ((pnlThaoTac.GetRow(pnlNutLoc) == 0) == motHang)
                return;

            pnlThaoTac.SuspendLayout();
            pnlThaoTac.SetColumnSpan(pnlNutLoc, 1);
            pnlThaoTac.SetCellPosition(pnlNutLoc, new TableLayoutPanelCellPosition(motHang ? 5 : 0, motHang ? 0 : 1));
            pnlThaoTac.SetColumnSpan(pnlNutLoc, motHang ? 1 : 6);
            pnlThaoTac.ColumnStyles[5].Width = motHang
                ? btnTimKiem.Width + btnXoaLoc.Width + btnXoaLoc.Margin.Horizontal + LogicalToDeviceUnits(10)
                : 0;
            if (!motHang)
                pnlNutLoc.Padding = new Padding(0, LogicalToDeviceUnits(8), 0, 0);
            pnlThaoTac.Height = LogicalToDeviceUnits(motHang ? 82 : 132);
            pnlThaoTac.ResumeLayout();
            CanNutVoiODoiTuong();
        }

        private void CanNutVoiODoiTuong()
        {
            if (pnlThaoTac.GetRow(pnlNutLoc) != 0)
                return;

            int tamODoiTuong = pnlDoiTuong.Top + cboDoiTuongLoc.Top + cboDoiTuongLoc.Height / 2;
            int khoangCachTren = Math.Max(0, tamODoiTuong - pnlNutLoc.Top - btnTimKiem.Height / 2);
            var padding = new Padding(LogicalToDeviceUnits(10), khoangCachTren, 0, 0);
            if (pnlNutLoc.Padding != padding)
                pnlNutLoc.Padding = padding;
        }

        private async Task LoadDataAsync()
        {
            int version = ++_loadVersion;
            lblTrangThai.Text = "Đang tải dữ liệu…";
            try
            {
                var notifications = await _apiService.GetAdminNotificationsAsync("");
                if (IsDisposed || version != _loadVersion) return;
                _notifications = notifications;
                var previousFilter = cboDoiTuongLoc.SelectedItem as string;
                cboDoiTuongLoc.Items.Clear();
                cboDoiTuongLoc.Items.Add("Mọi đối tượng");
                cboDoiTuongLoc.Items.AddRange(_notifications.Select(item => item.TargetAudience)
                    .Where(name => !string.IsNullOrWhiteSpace(name)).Distinct().OrderBy(name => name).Cast<object>().ToArray());
                cboDoiTuongLoc.SelectedIndex = Math.Max(0, cboDoiTuongLoc.Items.IndexOf(previousFilter ?? ""));

                int pending = _notifications.Count(n => AdminHelper.IsPendingNotification(n.Status));
                lblTong.Text = "Tổng\r\n" + _notifications.Count;
                lblChoDuyet.Text = "Chờ duyệt\r\n" + pending;
                lblDaDuyet.Text = "Đã duyệt\r\n" + _notifications.Count(n => n.Status == "Đã duyệt");
                lblDaDang.Text = "Đã đăng\r\n" + _notifications.Count(n => n.Status == "Đã đăng");

                ApDungBoLoc();
            }
            catch (Exception ex)
            {
                if (IsDisposed || version != _loadVersion) return;
                lblTrangThai.Text = "Không tải được dữ liệu";
                AdminHelper.ShowError(ex);
            }
        }

        private void ApDungBoLoc()
        {
            string status = cboTrangThaiLoc.SelectedItem as string ?? "Tất cả";
            List<AdminNotificationDto> rows;

            if (status == "Tất cả")
                rows = _notifications;
            else if (status == "Chờ duyệt")
                rows = _notifications.Where(n => AdminHelper.IsPendingNotification(n.Status)).ToList();
            else
                rows = _notifications.Where(n => n.Status == status).ToList();

            string keyword = txtTimKiem.Text.Trim();
            if (keyword.Length > 0)
                rows = rows.Where(n => (n.Title ?? "").Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    || (n.NotificationCode ?? "").Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    || (n.Content ?? "").Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    || (n.CreatorName ?? "").Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            rows = rows.Where(n => (_fromDate == null || n.SendDate.Date >= _fromDate.Value)
                && (_throughDate == null || n.SendDate.Date <= _throughDate.Value)
                && (cboDoiTuongLoc.SelectedIndex <= 0 || n.TargetAudience == cboDoiTuongLoc.SelectedItem as string)).ToList();
            int totalPages = Math.Max(1, (rows.Count + PageSize - 1) / PageSize);
            _page = Math.Clamp(_page, 0, totalPages - 1);
            dgvThongBao.DataSource = rows.Skip(_page * PageSize).Take(PageSize).ToList();
            AdminGridHelper.ShowPages(pnlSoTrang, _page, totalPages, page =>
            {
                if (page == _page) return;
                _page = page;
                ApDungBoLoc();
            });
            lblTrangThai.Text = rows.Count == 0
                ? (status == "Chờ duyệt" && !_notifications.Any(n => AdminHelper.IsPendingNotification(n.Status))
                    ? "Không có thông báo chờ duyệt."
                    : "Không tìm thấy thông báo phù hợp.")
                : $"Hiển thị {rows.Count} thông báo";
        }

        private void VeNutThongBao(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (AdminGridHelper.GetButtonAction(dgvThongBao, e.RowIndex, e.ColumnIndex) is string action)
                AdminGridHelper.DrawActionIcon(dgvThongBao, e, action);
        }

        private async void dgvThongBao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string action = AdminGridHelper.GetClickedAction(dgvThongBao, e);
            if (action == null) return;

            var n = (AdminNotificationDto)dgvThongBao.Rows[e.RowIndex].DataBoundItem;
            (bool Success, string Message) result;

            switch (action)
            {
                case "Chi tiết":
                    ShowDetail(n);
                    return;
                case "Sửa":
                    await EditAsync(n);
                    return;
                case "Duyệt":
                    if (!AdminHelper.Confirm($"Duyệt thông báo {n.NotificationCode}?")) return;
                    result = await _apiService.ReviewNotificationAsync(n.Id, true, null);
                    break;
                case "Từ chối":
                    string reason = NhapLyDoForm.Ask(this, "Từ chối thông báo " + n.NotificationCode);
                    if (reason == null) return;
                    result = await _apiService.ReviewNotificationAsync(n.Id, false, reason);
                    break;
                case "Đăng":
                    if (!AdminHelper.Confirm($"Đăng thông báo {n.NotificationCode}?")) return;
                    result = await _apiService.PublishNotificationAsync(n.Id);
                    break;
                case "Gỡ":
                    if (!AdminHelper.Confirm($"Gỡ thông báo {n.NotificationCode} khỏi danh sách đã đăng?")) return;
                    result = await _apiService.WithdrawNotificationAsync(n.Id);
                    break;
                default:
                    return;
            }

            if (AdminHelper.ShowResult(result))
            {
                await LoadDataAsync();
            }
        }

        private async Task CreateAsync()
        {
            using (var form = new ThongBaoForm())
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                if (AdminHelper.ShowResult(await _apiService.CreateAdminNotificationAsync(form.Result)))
                {
                    await LoadDataAsync();
                }
            }
        }

        private async Task EditAsync(AdminNotificationDto n)
        {
            using (var form = new ThongBaoForm(n))
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                if (AdminHelper.ShowResult(await _apiService.UpdateAdminNotificationAsync(n.Id, form.Result)))
                {
                    await LoadDataAsync();
                }
            }
        }

        private void ShowDetail(AdminNotificationDto n)
        {
            string text =
                $"Mã: {n.NotificationCode}\n" +
                $"Tiêu đề: {n.Title}\n" +
                $"Đối tượng: {n.TargetAudience}\n" +
                $"Người tạo: {n.CreatorName}\n" +
                $"Trạng thái: {n.Status}\n" +
                $"Ghi chú duyệt: {n.ReviewNote}\n\n" +
                $"{n.Content}";
            MessageBox.Show(text, "Chi tiết thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
