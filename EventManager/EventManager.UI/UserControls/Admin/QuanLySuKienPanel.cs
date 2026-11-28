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
    /// Quản lý sự kiện: tạo, sửa, tra cứu, phân công cán bộ, theo dõi tiến độ
    /// và duyệt kế hoạch tổ chức (tab thứ 2).
    /// </summary>
    public partial class QuanLySuKienPanel : UserControl
    {
        private readonly ApiService _apiService = ApiService.Instance;
        private const int PageSize = 10;
        private int _page;
        private int _loadVersion;
        private DateTime? _fromDate;
        private DateTime? _throughDate;
        private List<AdminEventDto> _events = new List<AdminEventDto>();
        private List<AdminPlanDto> _plans = new List<AdminPlanDto>();

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowPlansTab { get; set; }

        private bool IsPlansTab => tabSuKien.SelectedIndex == 1;

        public QuanLySuKienPanel()
        {
            InitializeComponent();
            if (AdminHelper.IsDesignMode) return;

            pnlThaoTac.SizeChanged += (_, _) => CapNhatBoCucBoLoc();
            cboCanBoLoc.LocationChanged += (_, _) => CanNutVoiOCanBo();
            cboCanBoLoc.SizeChanged += (_, _) => CanNutVoiOCanBo();
            pnlCanBoLoc.LocationChanged += (_, _) => CanNutVoiOCanBo();
            pnlNutLoc.LocationChanged += (_, _) => CanNutVoiOCanBo();
            CapNhatBoCucBoLoc();
            CanNutVoiOCanBo();

            var goiYBoLoc = new ToolTip();
            goiYBoLoc.SetToolTip(btnTimKiem, "Tìm sự kiện theo bộ lọc");
            goiYBoLoc.SetToolTip(btnXoaLoc, "Xóa bộ lọc");
            Disposed += (_, _) => goiYBoLoc.Dispose();
            txtTimKiem.KeyDown += (_, e) =>
            {
                if (e.KeyCode != Keys.Enter) return;
                e.SuppressKeyPress = true;
                btnTimKiem.PerformClick();
            };

            AdminGridHelper.Setup(dgvSuKien);
            AdminGridHelper.ShowStatusWhenEmpty(dgvSuKien, lblTrangThai);
            dgvSuKien.CellContentClick += dgvSuKien_CellContentClick;
            dgvSuKien.CellPainting += (_, e) =>
            {
                if (AdminGridHelper.GetButtonAction(dgvSuKien, e.RowIndex, e.ColumnIndex) is string action)
                    AdminGridHelper.DrawActionIcon(dgvSuKien, e, action);
            };
            dgvSuKien.CellMouseEnter += AdminGridHelper.InvalidateActionButton;
            dgvSuKien.CellMouseLeave += AdminGridHelper.InvalidateActionButton;
            dgvSuKien.CellFormatting += (_, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0 ||
                    dgvSuKien.Columns[e.ColumnIndex].Name != "colStt")
                    return;

                e.Value = (_page * PageSize + e.RowIndex + 1).ToString();
                e.FormattingApplied = true;
            };

            AdminHelper.ConfigureOptionalDate(dtpTuNgay);
            AdminHelper.ConfigureOptionalDate(dtpDenNgay);
            btnXoaLoc.Click += (s, e) =>
            {
                txtTimKiem.Clear();
                dtpTuNgay.Checked = false;
                dtpDenNgay.Checked = false;
                _fromDate = null;
                _throughDate = null;
                cboCanBoLoc.SelectedIndex = 0;
                cboTrangThai.SelectedIndex = 0;
                ResetPageForFilters();
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
                ResetPageForFilters();
            };
            btnLamMoi.Click += async (s, e) => await LoadDataAsync();
            btnTaoSuKien.Click += async (s, e) => await CreateEventAsync();
            cboTrangThai.SelectedIndexChanged += (s, e) => ResetPageForFilters();
            tabSuKien.SelectedIndexChanged += (s, e) =>
            {
                tabSuKien.SelectedTab?.Controls.Add(dgvSuKien);
                _page = 0;
                ShowCurrentTab();
            };

            Load += async (s, e) =>
            {
                if (ShowPlansTab) tabSuKien.SelectedIndex = 1;
                await LoadDataAsync();
            };
        }

        private void CapNhatBoCucBoLoc()
        {
            bool motHang = pnlThaoTac.ClientSize.Width >= LogicalToDeviceUnits(772);
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
            pnlThaoTac.Height = LogicalToDeviceUnits(motHang ? 76 : 126);
            pnlThaoTac.ResumeLayout();
            CanNutVoiOCanBo();
        }

        private void CanNutVoiOCanBo()
        {
            if (pnlThaoTac.GetRow(pnlNutLoc) != 0)
                return;

            int tamOCanBo = pnlCanBoLoc.Top + cboCanBoLoc.Top + cboCanBoLoc.Height / 2;
            int khoangCachTren = Math.Max(0, tamOCanBo - pnlNutLoc.Top - btnTimKiem.Height / 2);
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
                var events = await _apiService.GetAdminEventsAsync("");
                var plans = await _apiService.GetPlansAsync();
                if (IsDisposed || version != _loadVersion) return;
                _events = events;
                var previousFilter = cboCanBoLoc.SelectedItem as string;
                cboCanBoLoc.Items.Clear();
                cboCanBoLoc.Items.Add("Tất cả cán bộ");
                cboCanBoLoc.Items.AddRange(_events.Select(item => item.ManagerName)
                    .Where(name => !string.IsNullOrWhiteSpace(name)).Distinct().OrderBy(name => name).Cast<object>().ToArray());
                cboCanBoLoc.SelectedIndex = Math.Max(0, cboCanBoLoc.Items.IndexOf(previousFilter ?? ""));
                _plans = plans;

                lblTongSuKien.Text = "Tổng sự kiện\r\n" + _events.Count;
                lblSapDienRa.Text = "Sắp diễn ra\r\n" + _events.Count(ev => ev.Status == "Ongoing" && ev.StartDate >= DateTime.Now);
                lblLuotDangKy.Text = "Lượt đăng ký\r\n" + _events.Sum(ev => ev.RegisteredCount);
                int pending = _plans.Count(plan => plan.Status == "Chờ duyệt");
                lblKeHoachChoDuyet.Text = "KH chờ duyệt\r\n" + pending;
                tabKeHoach.Text = $"Kế hoạch ({pending} chờ duyệt)";

                ShowCurrentTab();
            }
            catch (Exception ex)
            {
                if (IsDisposed || version != _loadVersion) return;
                lblTrangThai.Text = "Không tải được dữ liệu";
                AdminHelper.ShowError(ex);
            }
        }

        private void ShowCurrentTab()
        {
            if (IsPlansTab)
                ShowPlans();
            else
                ShowEvents();
        }

        private void ResetPageForFilters()
        {
            if (!IsPlansTab)
                _page = 0;
            ShowCurrentTab();
        }

        private void ShowEvents()
        {
            string statusFilter = AdminHelper.EventStatusCode(cboTrangThai.Text);
            string keyword = txtTimKiem.Text.Trim();
            var filtered = _events
                .Where(ev => (cboTrangThai.SelectedIndex <= 0 || ev.Status == statusFilter)
                    && (keyword.Length == 0 || ev.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                        || ev.Id.ToString() == keyword)
                    && (_fromDate == null || ev.StartDate.Date >= _fromDate.Value)
                    && (_throughDate == null || ev.StartDate.Date <= _throughDate.Value)
                    && (cboCanBoLoc.SelectedIndex <= 0 || ev.ManagerName == cboCanBoLoc.SelectedItem as string))
                .ToList();

            AdminGridHelper.Setup(dgvSuKien);
            AdminGridHelper.AddColumn(dgvSuKien, "Id", "Mã");
            AdminGridHelper.AddColumn(dgvSuKien, "Title", "Sự kiện");
            AdminGridHelper.AddColumn(dgvSuKien, "StartDate", "Bắt đầu", "dd/MM/yyyy HH:mm");
            AdminGridHelper.AddColumn(dgvSuKien, "RegisteredCount", "Đăng ký");
            AdminGridHelper.AddColumn(dgvSuKien, "ManagerName", "Cán bộ phụ trách");
            AdminGridHelper.AddColumn(dgvSuKien, "Status", "Trạng thái");
            AddEventActionColumns(item => new[] { "Chi tiết", "Sửa", "Phân công", "Theo dõi" },
                "Chi tiết", "Sửa", "Phân công", "Theo dõi");

            BindPage(filtered);
            lblTrangThai.Text = filtered.Count == 0 ? "Không tìm thấy sự kiện phù hợp." : $"Hiển thị {filtered.Count} sự kiện";
        }

        private void ShowPlans()
        {
            AdminGridHelper.Setup(dgvSuKien);
            AdminGridHelper.AddColumn(dgvSuKien, "Id", "Mã");
            AdminGridHelper.AddColumn(dgvSuKien, "PlanName", "Kế hoạch");
            AdminGridHelper.AddColumn(dgvSuKien, "StartDate", "Bắt đầu", "dd/MM/yyyy");
            AdminGridHelper.AddColumn(dgvSuKien, "Budget", "Ngân sách", "N0");
            AdminGridHelper.AddColumn(dgvSuKien, "Status", "Trạng thái");
            AddEventActionColumns(
                item => ((AdminPlanDto)item).Status == "Chờ duyệt" ? new[] { "Chi tiết", "Duyệt", "Từ chối" } : new[] { "Chi tiết" },
                "Chi tiết", "Duyệt", "Từ chối");

            BindPage(_plans);
            lblTrangThai.Text = _plans.Count == 0 ? "Chưa có kế hoạch để duyệt." : $"Hiển thị {_plans.Count} kế hoạch";
        }

        private void BindPage<T>(List<T> rows)
        {
            int totalPages = Math.Max(1, (rows.Count + PageSize - 1) / PageSize);
            _page = Math.Clamp(_page, 0, totalPages - 1);
            dgvSuKien.DataSource = rows.Skip(_page * PageSize).Take(PageSize).ToList();

            AdminGridHelper.ShowPages(pnlSoTrang, _page, totalPages, page =>
            {
                if (page == _page) return;
                _page = page;
                ShowCurrentTab();
            });
        }

        private void AddEventActionColumns(Func<object, string[]> allowedActions, params string[] actions)
        {
            dgvSuKien.Columns.Insert(0, new DataGridViewTextBoxColumn
            {
                Name = "colStt",
                HeaderText = "STT",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = LogicalToDeviceUnits(58),
                SortMode = DataGridViewColumnSortMode.NotSortable,
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            AdminGridHelper.AddActionColumns(dgvSuKien, allowedActions, actions);
            foreach (var column in dgvSuKien.Columns.OfType<DataGridViewButtonColumn>())
            {
                column.HeaderText = column.Text == "Chi tiết" ? "Xem" : column.Text;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                column.MinimumWidth = LogicalToDeviceUnits(48);
                column.CellTemplate!.ToolTipText = column.Text;
            }
        }

        private async void dgvSuKien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string action = AdminGridHelper.GetClickedAction(dgvSuKien, e);
            if (action == null) return;

            object item = dgvSuKien.Rows[e.RowIndex].DataBoundItem;
            if (item is AdminEventDto ev)
            {
                switch (action)
                {
                    case "Chi tiết": ShowEventDetail(ev); break;
                    case "Sửa": await EditEventAsync(ev); break;
                    case "Phân công": await AssignManagerAsync(ev); break;
                    case "Theo dõi": await ShowProgressAsync(ev); break;
                }
            }
            else if (item is AdminPlanDto plan)
            {
                switch (action)
                {
                    case "Chi tiết": ShowPlanDetail(plan); break;
                    case "Duyệt": await ReviewPlanAsync(plan, true); break;
                    case "Từ chối": await ReviewPlanAsync(plan, false); break;
                }
            }
        }

        private void ShowEventDetail(AdminEventDto ev)
        {
            string end = ev.EndDate?.ToString("dd/MM/yyyy HH:mm") ?? "Chưa xác định";
            string detail = $"Mã: {ev.Id}\nSự kiện: {ev.Title}\n"
                + $"Bắt đầu: {ev.StartDate:dd/MM/yyyy HH:mm}\nKết thúc: {end}\n"
                + $"Địa điểm: {ev.Location}\nCán bộ phụ trách: {ev.ManagerName ?? "Chưa phân công"}\n"
                + $"Trạng thái: {AdminHelper.EventStatusText(ev.Status)}\n"
                + $"Đã đăng ký: {ev.RegisteredCount} / {ev.MaxParticipants}\n\n{ev.Description}";
            MessageBox.Show(this, detail, "Chi tiết sự kiện", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task CreateEventAsync()
        {
            using (var form = new SuKienForm())
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                if (AdminHelper.ShowResult(await _apiService.CreateAdminEventAsync(form.Result)))
                    await LoadDataAsync();
            }
        }

        private async Task EditEventAsync(AdminEventDto ev)
        {
            using (var form = new SuKienForm(ev))
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                if (AdminHelper.ShowResult(await _apiService.UpdateAdminEventAsync(ev.Id, form.Result)))
                    await LoadDataAsync();
            }
        }

        private async Task AssignManagerAsync(AdminEventDto ev)
        {
            try
            {
                var staff = (await _apiService.GetAccountsAsync("CanBo")).Where(account => account.IsActive).ToList();
                if (staff.Count == 0)
                {
                    MessageBox.Show("Chưa có tài khoản cán bộ nào đang hoạt động.", "Thông báo");
                    return;
                }

                using (var form = new PhanCongCanBoForm(ev, staff))
                {
                    if (form.ShowDialog(this) != DialogResult.OK) return;
                    if (form.SelectedManagerId == ev.ManagerId)
                    {
                        MessageBox.Show(this, "Sự kiện đã được phân công cho cán bộ này.", "Phân công");
                        return;
                    }
                    var manager = staff.First(account => account.Id == form.SelectedManagerId);
                    if (!AdminHelper.Confirm($"Phân công {manager.FullName} phụ trách sự kiện {ev.Title}?")) return;
                    if (AdminHelper.ShowResult(await _apiService.AssignManagerAsync(ev.Id, form.SelectedManagerId)))
                        await LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                AdminHelper.ShowError(ex);
            }
        }

        private async Task ShowProgressAsync(AdminEventDto ev)
        {
            try
            {
                var progress = await _apiService.GetEventProgressAsync(ev.Id);
                if (progress.LegacyTasksUnavailable)
                    MessageBox.Show(this, "Thiếu bảng công việc hoặc sự kiện của Cán bộ. Tiến độ chỉ tính theo dữ liệu trong bảng Tasks.",
                        "Theo dõi tiến độ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                using (var form = new TheoDoiSuKienForm(progress))
                {
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                AdminHelper.ShowError(ex);
            }
        }

        private void ShowPlanDetail(AdminPlanDto plan)
        {
            using (var form = new DuyetKeHoachForm(plan))
            {
                form.ShowDialog(this);
            }
        }

        private async Task ReviewPlanAsync(AdminPlanDto plan, bool approved)
        {
            string reason = null;
            if (approved)
            {
                if (!AdminHelper.Confirm($"Duyệt kế hoạch \"{plan.PlanName}\"?\nHệ thống sẽ tạo sự kiện mới từ kế hoạch này.")) return;
            }
            else
            {
                reason = NhapLyDoForm.Ask(this, "Từ chối kế hoạch");
                if (reason == null) return;
            }

            if (AdminHelper.ShowResult(await _apiService.ReviewPlanAsync(plan.Id, approved, reason)))
            {
                await LoadDataAsync();
            }
        }
    }
}
