using EventManager.UI.Models;
using EventManager.UI.Services;

namespace EventManager.UI.UserControls.Admin
{
    public partial class PhanQuyenPanel : UserControl
    {
        private readonly ApiService _apiService = ApiService.Instance;
        private List<AdminAccountDto> _accounts = new();
        private AdminPermissionDto? _permissions;
        private bool _busy;
        private bool _binding;
        private int _selectionVersion;

        public PhanQuyenPanel()
        {
            InitializeComponent();
        }

        public PhanQuyenPanel(int currentUserId) : this()
        {
            cboVaiTro.Items.AddRange(new object[]
            {
                new RoleOption(null, "Tất cả vai trò"),
                new RoleOption("Admin", "Quản trị viên"),
                new RoleOption("CanBo", "Cán bộ"),
                new RoleOption("SinhVien", "Sinh viên")
            });
            cboVaiTro.SelectedIndex = 0;

            lstTaiKhoan.SelectedIndexChanged += async (_, _) =>
            {
                if (!_binding) await SelectAccountAsync();
            };
            txtTimKiem.TextChanged += async (_, _) => await ShowAccountsAsync();
            cboVaiTro.SelectedIndexChanged += async (_, _) => await ShowAccountsAsync();
            btnTaiLai.Click += async (_, _) => await LoadDataAsync();
            btnLuuQuyen.Click += async (_, _) => await SaveAsync();
            btnChonTatCa.Click += (_, _) =>
            {
                var cacOQuyen = pnlDanhSachQuyen.Controls.OfType<CheckBox>();
                bool check = cacOQuyen.Any(o => !o.Checked);
                foreach (var oQuyen in cacOQuyen)
                    oQuyen.Checked = check;
            };
            Load += async (_, _) => await LoadDataAsync();
            UpdateControls();
        }

        private void UpdateControls()
        {
            bool canEdit = !_busy && _permissions?.CanEdit == true;
            pnlDanhSachQuyen.Enabled = btnChonTatCa.Enabled = btnLuuQuyen.Enabled = canEdit;
            btnTaiLai.Enabled = txtTimKiem.Enabled = cboVaiTro.Enabled = lstTaiKhoan.Enabled = !_busy;
            btnLuuQuyen.Text = _permissions?.Permissions.Count > 0 ? "Thay đổi quyền" : "Cấp quyền";
        }

        private async Task LoadDataAsync()
        {
            if (_busy) return;
            _busy = true;
            UpdateControls();
            try
            {
                var accounts = await _apiService.GetAccountsAsync();
                if (IsDisposed) return;
                _accounts = accounts;
                await ShowAccountsAsync();
            }
            catch (Exception ex)
            {
                if (!IsDisposed) AdminHelper.ShowError(ex);
            }
            finally
            {
                _busy = false;
                if (!IsDisposed) UpdateControls();
            }
        }

        private async Task ShowAccountsAsync()
        {
            int? selectedId = (lstTaiKhoan.SelectedItem as AdminAccountDto)?.Id;
            string keyword = txtTimKiem.Text.Trim();
            string? role = (cboVaiTro.SelectedItem as RoleOption)?.Code;
            var matches = _accounts.Where(account =>
                (role == null || account.Role == role)
                && (account.Id.ToString().Contains(keyword, StringComparison.Ordinal)
                    || account.Username.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    || account.FullName?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true
                    || account.StudentCode?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true)).ToList();

            _binding = true;
            lstTaiKhoan.DataSource = matches;
            lstTaiKhoan.SelectedItem = matches.FirstOrDefault(account => account.Id == selectedId)
                ?? matches.FirstOrDefault();
            _binding = false;
            lblTrangThai.Text = matches.Count == 0 ? "Không tìm thấy tài khoản." : $"Tìm thấy {matches.Count} tài khoản";
            await SelectAccountAsync();
        }

        private async Task SelectAccountAsync()
        {
            int version = ++_selectionVersion;
            _permissions = null;
            UpdateControls();
            lblTaiKhoan.Text = "Chọn tài khoản để xem quyền";
            while (pnlDanhSachQuyen.Controls.Count > 0)
                pnlDanhSachQuyen.Controls[0].Dispose();
            lstTraCuu.Items.Clear();
            lblTomTatQuyen.Text = "";
            if (lstTaiKhoan.SelectedItem is not AdminAccountDto account) return;

            lblTaiKhoan.Text = $"#{account.Id}  •  {account.FullName}  •  {account.Username}  •  {AdminHelper.RoleName(account.Role)}";
            lblTomTatQuyen.Text = "Đang tải quyền…";
            try
            {
                var rights = await _apiService.GetPermissionsAsync(account.Id);
                if (IsDisposed || version != _selectionVersion) return;

                _permissions = rights;
                lblTaiKhoan.Text = $"#{account.Id}  •  {account.FullName}  •  {account.Username}  •  {AdminHelper.RoleName(rights.Role)}";
                var granted = rights.Permissions.ToHashSet();
                pnlDanhSachQuyen.SuspendLayout();
                foreach (string permission in rights.Catalog)
                {
                    bool isGranted = granted.Contains(permission);
                    pnlDanhSachQuyen.Controls.Add(TaoOQuyen(permission, isGranted));
                }
                pnlDanhSachQuyen.ResumeLayout();
                HienThiQuyenHienTai(rights, granted);
                lblTrangThai.Text = $"Tìm thấy {lstTaiKhoan.Items.Count} tài khoản"
                    + (rights.CanEdit ? "" : "  •  Chỉ tra cứu");
                UpdateControls();
            }
            catch (Exception ex)
            {
                if (!IsDisposed && version == _selectionVersion)
                {
                    lblTrangThai.Text = "Không tải được quyền tài khoản.";
                    lblTomTatQuyen.Text = lblTrangThai.Text;
                    AdminHelper.ShowError(ex);
                }
            }
        }

        private void HienThiQuyenHienTai(AdminPermissionDto rights, HashSet<string> granted)
        {
            bool usesRoleAccess = rights.Role is "CanBo" or "SinhVien";
            bool hasDefaultAccess = usesRoleAccess || rights.HasImplicitAdminAccess;
            int availableCount = hasDefaultAccess ? rights.Catalog.Count : granted.Count;
            lblTomTatQuyen.Text = usesRoleAccess
                ? $"Quyền truy cập theo vai trò {AdminHelper.RoleName(rights.Role)}."
                : $"{availableCount}/{rights.Catalog.Count} chức năng có quyền truy cập.";

            lstTraCuu.BeginUpdate();
            foreach (string permission in rights.Catalog.OrderByDescending(permission => hasDefaultAccess || granted.Contains(permission)))
            {
                bool isGranted = granted.Contains(permission);
                string status = usesRoleAccess ? "Theo vai trò"
                    : isGranted ? "Đã cấp riêng"
                    : hasDefaultAccess ? "Mặc định"
                    : "Chưa cấp";
                var item = new ListViewItem(permission) { UseItemStyleForSubItems = false, ToolTipText = permission };
                item.SubItems.Add(status).ForeColor = isGranted || hasDefaultAccess
                    ? Color.FromArgb(21, 107, 69) : Color.FromArgb(100, 116, 139);
                lstTraCuu.Items.Add(item);
            }
            lstTraCuu.EndUpdate();
            CanCotQuyen();
        }

        private void CanCotQuyen()
        {
            int statusWidth = LogicalToDeviceUnits(144);
            lstTraCuu.Columns[0].Width = Math.Max(LogicalToDeviceUnits(180),
                lstTraCuu.ClientSize.Width - statusWidth - SystemInformation.VerticalScrollBarWidth);
            lstTraCuu.Columns[1].Width = statusWidth;
        }

        private CheckBox TaoOQuyen(string permission, bool isGranted)
        {
            var oQuyen = new CheckBox
            {
                Text = permission,
                AccessibleName = permission,
                Checked = isGranted,
                AutoEllipsis = true,
                Size = LogicalToDeviceUnits(new Size(222, 40)),
                Margin = new Padding(0, 0, LogicalToDeviceUnits(8), LogicalToDeviceUnits(8)),
                Padding = new Padding(LogicalToDeviceUnits(10), 0, LogicalToDeviceUnits(6), 0),
                FlatStyle = FlatStyle.Flat,
                UseVisualStyleBackColor = false,
                Cursor = Cursors.Hand
            };

            void CapNhatMau()
            {
                oQuyen.BackColor = oQuyen.Checked ? Color.FromArgb(219, 234, 254) : Color.FromArgb(240, 245, 251);
                oQuyen.ForeColor = oQuyen.Checked ? Color.FromArgb(30, 64, 175) : Color.FromArgb(28, 46, 70);
            }

            oQuyen.CheckedChanged += (_, _) => CapNhatMau();
            oQuyen.Paint += (_, e) =>
            {
                using var pen = new Pen(oQuyen.Checked ? Color.FromArgb(147, 197, 253) : Color.FromArgb(219, 228, 239));
                e.Graphics.DrawRectangle(pen, 0, 0, oQuyen.ClientSize.Width - 1, oQuyen.ClientSize.Height - 1);
            };
            CapNhatMau();
            return oQuyen;
        }

        private void pnlTimKiem_Paint(object? sender, PaintEventArgs e)
        {
            var color = txtTimKiem.Focused ? Color.FromArgb(37, 99, 165) : Color.FromArgb(193, 205, 220);
            ControlPaint.DrawBorder(e.Graphics, pnlTimKiem.ClientRectangle, color, ButtonBorderStyle.Solid);
        }

        private void lstTaiKhoan_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || lstTaiKhoan.Items[e.Index] is not AdminAccountDto account) return;
            e.DrawBackground();
            using var bold = new Font(lstTaiKhoan.Font, FontStyle.Bold);
            var title = new Rectangle(e.Bounds.X + 8, e.Bounds.Y, e.Bounds.Width - 16, e.Bounds.Height / 2);
            var subtitle = new Rectangle(title.X, title.Bottom, title.Width, title.Height);
            var flags = TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
            TextRenderer.DrawText(e.Graphics, account.FullName ?? account.Username, bold, title, e.ForeColor, flags);
            TextRenderer.DrawText(e.Graphics, $"#{account.Id}  |  {account.Username}  |  {AdminHelper.RoleName(account.Role)}",
                lstTaiKhoan.Font, subtitle, e.ForeColor, flags);
            e.DrawFocusRectangle();
        }

        private async Task SaveAsync()
        {
            if (_busy || _permissions is not { CanEdit: true } current ||
                lstTaiKhoan.SelectedItem is not AdminAccountDto account || account.Id != current.UserId)
                return;

            var permissions = pnlDanhSachQuyen.Controls.OfType<CheckBox>()
                .Where(o => o.Checked)
                .Select(o => o.Text)
                .ToList();
            bool isGrant = current.Permissions.Count == 0;
            if (permissions.Count == 0 && (isGrant || current.Role == "Admin"))
            {
                MessageBox.Show(this, "Hãy chọn ít nhất một quyền.", "Phân quyền");
                return;
            }
            if (current.Permissions.ToHashSet().SetEquals(permissions))
            {
                lblTrangThai.Text = "Danh sách quyền chưa thay đổi.";
                return;
            }

            string summary = permissions.Count == 0 ? "Không còn quyền được chọn."
                : string.Join(Environment.NewLine, permissions);
            if (!AdminHelper.Confirm($"{btnLuuQuyen.Text} cho {account.Username}?\n\n{summary}")) return;

            _busy = true;
            UpdateControls();
            try
            {
                var result = await _apiService.SetPermissionsAsync(account.Id, new AdminPermissionRequest
                {
                    Role = current.Role,
                    Permissions = permissions
                });
                if (!IsDisposed && AdminHelper.ShowResult(result))
                    await SelectAccountAsync();
            }
            catch (Exception ex)
            {
                if (!IsDisposed) AdminHelper.ShowError(ex);
            }
            finally
            {
                _busy = false;
                if (!IsDisposed) UpdateControls();
            }
        }

        private sealed record RoleOption(string? Code, string Label)
        {
            public override string ToString() => Label;
        }
    }
}
