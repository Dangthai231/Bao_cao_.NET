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
    /// Quản lý tài khoản: tạo, sửa, khóa/mở, đặt lại mật khẩu, tra cứu
    /// và duyệt yêu cầu thay đổi thông tin (tab thứ 2).
    /// </summary>
    public partial class QuanLyTaiKhoanPanel : UserControl
    {
        private const int PageSize = 10;

        private readonly ApiService _apiService = ApiService.Instance;
        private int _loadVersion;
        private List<AdminAccountDto> _accounts = new List<AdminAccountDto>();
        private List<AdminChangeRequestDto> _requests = new List<AdminChangeRequestDto>();
        private int _page;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowRequestsTab { get; set; }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string InitialKeyword { get; set; } = "";

        private bool IsRequestsTab => tabTaiKhoan.SelectedIndex == 1;

        public QuanLyTaiKhoanPanel()
        {
            InitializeComponent();
            if (AdminHelper.IsDesignMode) return;

            var goiYBoLoc = new ToolTip();
            goiYBoLoc.SetToolTip(btnTimKiem, "Tìm tài khoản theo bộ lọc");
            goiYBoLoc.SetToolTip(btnXoaLoc, "Xóa bộ lọc");
            Disposed += (_, _) => goiYBoLoc.Dispose();

            AdminGridHelper.Setup(dgvTaiKhoan);
            AdminGridHelper.ShowStatusWhenEmpty(dgvTaiKhoan, lblTrangThai);
            dgvTaiKhoan.CellContentClick += dgvTaiKhoan_CellContentClick;
            dgvTaiKhoan.CellFormatting += (_, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0 ||
                    dgvTaiKhoan.Columns[e.ColumnIndex].Name != "colStt")
                    return;

                e.Value = (_page * PageSize + e.RowIndex + 1).ToString();
                e.FormattingApplied = true;
            };
            dgvTaiKhoan.CellPainting += (_, e) =>
            {
                if (GetAccountIconAction(e.RowIndex, e.ColumnIndex) is string action)
                    AdminGridHelper.DrawActionIcon(dgvTaiKhoan, e, action);
            };
            dgvTaiKhoan.CellMouseEnter += AdminGridHelper.InvalidateActionButton;
            dgvTaiKhoan.CellMouseLeave += AdminGridHelper.InvalidateActionButton;
            dgvTaiKhoan.CellToolTipTextNeeded += (_, e) =>
            {
                if (GetAccountIconAction(e.RowIndex, e.ColumnIndex) is string action)
                    e.ToolTipText = action == "Đặt lại MK" ? "Đặt lại mật khẩu" : action;
            };

            btnXoaLoc.Click += (s, e) =>
            {
                txtTimKiem.Clear();
                cboVaiTro.SelectedIndex = 0;
                cboTinhTrang.SelectedIndex = 0;
                _page = 0;
                ShowCurrentTab();
            };
            btnTimKiem.Click += (s, e) => { _page = 0; ShowCurrentTab(); };
            btnLamMoi.Click += async (s, e) => { _page = 0; await LoadDataAsync(); };
            btnTaoTaiKhoan.Click += async (s, e) => await CreateAccountAsync();
            cboVaiTro.SelectedIndexChanged += (s, e) => { _page = 0; ShowCurrentTab(); };
            cboTinhTrang.SelectedIndexChanged += (s, e) => { _page = 0; ShowCurrentTab(); };
            tabTaiKhoan.SelectedIndexChanged += (s, e) =>
            {
                // Dùng chung một lưới cho cả 2 tab
                tabTaiKhoan.SelectedTab?.Controls.Add(dgvTaiKhoan);
                _page = 0;
                ShowCurrentTab();
            };

            Load += async (s, e) =>
            {
                txtTimKiem.Text = InitialKeyword;
                if (ShowRequestsTab) tabTaiKhoan.SelectedIndex = 1;
                await LoadDataAsync();
            };
        }

        private async Task LoadDataAsync()
        {
            int version = ++_loadVersion;
            lblTrangThai.Text = "Đang tải dữ liệu…";
            try
            {
                var accounts = await _apiService.GetAccountsAsync();
                var requests = await _apiService.GetChangeRequestsAsync();
                if (IsDisposed || version != _loadVersion) return;
                _accounts = accounts;
                _requests = requests;

                int pending = _requests.Count(r => r.Status == "Chờ duyệt");
                lblTong.Text = "Tổng\r\n" + _accounts.Count;
                lblHoatDong.Text = "Hoạt động\r\n" + _accounts.Count(a => a.IsActive);
                lblBiKhoa.Text = "Bị khóa\r\n" + _accounts.Count(a => !a.IsActive);
                lblChoDuyet.Text = "Chờ duyệt\r\n" + pending;
                tabYeuCau.Text = $"Yêu cầu hồ sơ ({pending} chờ duyệt)";

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
            if (IsRequestsTab)
                ShowRequests();
            else
                ShowAccounts();
        }

        // ─── Tab 1: danh sách tài khoản (lọc + phân trang) ───────────
        private void ShowAccounts()
        {
            string keyword = txtTimKiem.Text.Trim();
            var filtered = _accounts.Where(a =>
                (cboVaiTro.SelectedIndex <= 0 || a.Role == cboVaiTro.Text) &&
                (cboTinhTrang.SelectedIndex <= 0 || a.IsActive == (cboTinhTrang.SelectedIndex == 1)) &&
                (keyword == "" || ($"{a.Username} {a.FullName} {a.Email} {a.StudentCode}").Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    || a.Id.ToString() == keyword))
                .ToList();

            AdminGridHelper.Setup(dgvTaiKhoan);
            dgvTaiKhoan.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStt",
                HeaderText = "STT",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = LogicalToDeviceUnits(58),
                SortMode = DataGridViewColumnSortMode.NotSortable,
                HeaderCell = { Style = { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            AdminGridHelper.AddColumn(dgvTaiKhoan, "Id", "Mã");
            var idColumn = dgvTaiKhoan.Columns["colId"];
            idColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            idColumn.MinimumWidth = LogicalToDeviceUnits(48);
            idColumn.Width = LogicalToDeviceUnits(64);
            idColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            AdminGridHelper.AddColumn(dgvTaiKhoan, "Username", "Tên đăng nhập");
            AdminGridHelper.AddColumn(dgvTaiKhoan, "FullName", "Họ tên");
            AdminGridHelper.AddColumn(dgvTaiKhoan, "Role", "Vai trò");
            dgvTaiKhoan.Columns["colRole"].MinimumWidth = LogicalToDeviceUnits(116);
            AdminGridHelper.AddColumn(dgvTaiKhoan, "IsActive", "Trạng thái");
            AdminGridHelper.AddActionColumns(dgvTaiKhoan, item => new[] { "Chi tiết", "Sửa", "Khóa/Mở", "Đặt lại MK" },
                "Chi tiết", "Sửa", "Khóa/Mở", "Đặt lại MK");
            foreach (var column in dgvTaiKhoan.Columns.OfType<DataGridViewButtonColumn>())
            {
                column.HeaderText = column.Text switch
                {
                    "Chi tiết" => "Xem",
                    "Khóa/Mở" => "Khóa",
                    "Đặt lại MK" => "Mật khẩu",
                    _ => column.Text
                };
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Padding = new Padding(LogicalToDeviceUnits(4), 0, LogicalToDeviceUnits(4), 0);
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                column.MinimumWidth = LogicalToDeviceUnits(48);
                column.Resizable = DataGridViewTriState.False;
            }

            BindPage(filtered);
            lblTrangThai.Text = filtered.Count == 0 ? "Không tìm thấy tài khoản phù hợp." : $"Hiển thị {filtered.Count} tài khoản";
        }

        // ─── Tab 2: yêu cầu thay đổi thông tin ───────────────────────
        private void ShowRequests()
        {
            AdminGridHelper.Setup(dgvTaiKhoan);
            AdminGridHelper.AddColumn(dgvTaiKhoan, "Id", "Mã");
            AdminGridHelper.AddColumn(dgvTaiKhoan, "Username", "Tài khoản");
            AdminGridHelper.AddColumn(dgvTaiKhoan, "NewFullName", "Họ tên đề xuất");
            AdminGridHelper.AddColumn(dgvTaiKhoan, "NewEmail", "Email đề xuất");
            AdminGridHelper.AddColumn(dgvTaiKhoan, "Status", "Trạng thái");
            AdminGridHelper.AddActionColumns(dgvTaiKhoan,
                item => ((AdminChangeRequestDto)item).Status == "Chờ duyệt" ? new[] { "Chi tiết", "Duyệt", "Từ chối" } : new[] { "Chi tiết" },
                "Chi tiết", "Duyệt", "Từ chối");

            BindPage(_requests);
            lblTrangThai.Text = _requests.Count == 0 ? "Chưa có yêu cầu đổi thông tin để duyệt." : $"Hiển thị {_requests.Count} yêu cầu";
        }

        private void BindPage<T>(List<T> rows)
        {
            int totalPages = Math.Max(1, (rows.Count + PageSize - 1) / PageSize);
            _page = Math.Clamp(_page, 0, totalPages - 1);
            dgvTaiKhoan.DataSource = rows.Skip(_page * PageSize).Take(PageSize).ToList();
            AdminGridHelper.ShowPages(pnlSoTrang, _page, totalPages, page =>
            {
                if (page == _page) return;
                _page = page;
                ShowCurrentTab();
            });
        }

        private string? GetAccountIconAction(int rowIndex, int columnIndex)
        {
            string? action = AdminGridHelper.GetButtonAction(dgvTaiKhoan, rowIndex, columnIndex);
            if (action == null || dgvTaiKhoan.Rows[rowIndex].DataBoundItem is not AdminAccountDto account)
                return null;

            return action == "Khóa/Mở"
                ? (account.IsActive ? "Khóa tài khoản" : "Mở khóa tài khoản")
                : action;
        }

        private async void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string action = AdminGridHelper.GetClickedAction(dgvTaiKhoan, e);
            if (action == null) return;

            object item = dgvTaiKhoan.Rows[e.RowIndex].DataBoundItem;
            if (item is AdminAccountDto account)
            {
                switch (action)
                {
                    case "Chi tiết": ShowAccountDetail(account); break;
                    case "Sửa": await EditAccountAsync(account); break;
                    case "Khóa/Mở": await ToggleLockAsync(account); break;
                    case "Đặt lại MK": await ResetPasswordAsync(account); break;
                }
            }
            else if (item is AdminChangeRequestDto request)
            {
                switch (action)
                {
                    case "Chi tiết": ShowRequestDetail(request); break;
                    case "Duyệt": await ReviewRequestAsync(request, true); break;
                    case "Từ chối": await ReviewRequestAsync(request, false); break;
                }
            }
        }

        private async Task CreateAccountAsync()
        {
            using (var form = new TaoTaiKhoanForm())
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                if (AdminHelper.ShowResult(await _apiService.CreateAccountAsync(form.Result)))
                    await LoadDataAsync();
            }
        }

        private async Task EditAccountAsync(AdminAccountDto account)
        {
            using (var form = new TaoTaiKhoanForm(account))
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                if (AdminHelper.ShowResult(await _apiService.UpdateAccountAsync(account.Id, form.Result)))
                    await LoadDataAsync();
            }
        }

        private async Task ToggleLockAsync(AdminAccountDto account)
        {
            string action = account.IsActive ? "khóa" : "mở khóa";
            if (!AdminHelper.Confirm($"Bạn có chắc muốn {action} tài khoản \"{account.Username}\"?")) return;

            if (AdminHelper.ShowResult(await _apiService.SetAccountActiveAsync(account.Id, !account.IsActive)))
                await LoadDataAsync();
        }

        private async Task ResetPasswordAsync(AdminAccountDto account)
        {
            using (var form = TaoTaiKhoanForm.ForResetPassword(account))
            {
                if (form.ShowDialog(this) != DialogResult.OK) return;
                AdminHelper.ShowResult(await _apiService.ResetPasswordAsync(account.Id, form.Result.Password));
            }
        }

        private async Task ReviewRequestAsync(AdminChangeRequestDto request, bool approved)
        {
            string reason = null;
            if (approved)
            {
                if (!AdminHelper.Confirm($"Duyệt yêu cầu thay đổi thông tin của \"{request.Username}\"?")) return;
            }
            else
            {
                reason = NhapLyDoForm.Ask(this, "Từ chối yêu cầu thay đổi thông tin");
                if (reason == null) return;
            }

            if (AdminHelper.ShowResult(await _apiService.ReviewChangeRequestAsync(request.Id, approved, reason)))
            {
                await LoadDataAsync();
            }
        }

        private void ShowAccountDetail(AdminAccountDto a)
        {
            string text =
                $"Tên đăng nhập: {a.Username}\n" +
                $"Họ tên: {a.FullName}\n" +
                $"Vai trò: {a.Role}\n" +
                $"Email: {a.Email}\n" +
                $"Điện thoại: {a.PhoneNumber}\n" +
                $"Mã sinh viên: {a.StudentCode}\n" +
                $"Lớp: {a.ClassName}\n" +
                $"Trạng thái: {(a.IsActive ? "Hoạt động" : "Bị khóa")}";
            MessageBox.Show(text, "Chi tiết tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowRequestDetail(AdminChangeRequestDto r)
        {
            using (var form = new DuyetThongTinForm(r))
            {
                form.ShowDialog(this);
            }
        }
    }
}
