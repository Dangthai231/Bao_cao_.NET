using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.Admin
{
    /// <summary>
    /// Cấu hình DataGridView cho các màn hình Admin:
    /// tạo cột theo thuộc tính DTO, cột nút thao tác trên từng dòng, tô màu cột trạng thái.
    /// </summary>
    public static class AdminGridHelper
    {
        public static void DrawTab(object? sender, DrawItemEventArgs e)
        {
            if (sender is not TabControl tab || e.Index < 0 || e.Index >= tab.TabCount) return;
            bool selected = tab.SelectedIndex == e.Index;
            var bounds = tab.GetTabRect(e.Index);
            bounds.Inflate(-1, -1);
            using var background = new SolidBrush(selected ? Color.FromArgb(25, 99, 184) : Color.FromArgb(238, 244, 251));
            e.Graphics.FillRectangle(background, bounds);
            TextRenderer.DrawText(e.Graphics, tab.TabPages[e.Index].Text, tab.Font, bounds,
                selected ? Color.White : Color.FromArgb(27, 52, 81),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        public static void Setup(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.RowHeadersVisible = false;
            grid.DataSource = null;
            grid.Tag = null;

            // Gỡ rồi gắn lại để mỗi lưới chỉ có đúng 1 handler, dù Setup được gọi nhiều lần (khi đổi tab)
            grid.CellFormatting -= FormatStatusCell;
            grid.CellFormatting += FormatStatusCell;
            grid.CellPainting -= DrawStatusBadge;
            grid.CellPainting += DrawStatusBadge;
            grid.DataBindingComplete -= HideUnavailableActions;
            grid.DataBindingComplete += HideUnavailableActions;
        }

        public static FlowLayoutPanel CreatePager() => new FlowLayoutPanel
        {
            Dock = DockStyle.Right,
            AutoSize = true,
            WrapContents = false,
            Padding = new Padding(4, 2, 0, 0),
            Visible = false
        };

        public static void ShowPages(FlowLayoutPanel pager, int currentPage, int totalPages, Action<int> selectPage)
        {
            pager.SuspendLayout();
            bool restoreFocus = pager.ContainsFocus;
            while (pager.Controls.Count > 0)
                pager.Controls[0].Dispose();

            pager.Visible = totalPages > 1;
            if (totalPages > 1)
            {
                AddPageButton(pager, selectPage, "‹", currentPage - 1, "Trang trước", enabled: currentPage > 0);
                int first = Math.Clamp(currentPage - 2, 0, Math.Max(0, totalPages - 5));
                for (int page = first; page < Math.Min(first + 5, totalPages); page++)
                {
                    bool selected = page == currentPage;
                    var button = AddPageButton(pager, selectPage, (page + 1).ToString(), page, $"Trang {page + 1}", selected: selected);
                    if (selected && restoreFocus)
                        button.Focus();
                }
                AddPageButton(pager, selectPage, "›", currentPage + 1, "Trang sau", enabled: currentPage < totalPages - 1);
            }
            pager.ResumeLayout();
        }

        private static Button AddPageButton(FlowLayoutPanel pager, Action<int> selectPage, string text, int page, string accessibleName, bool enabled = true, bool selected = false)
        {
            var button = new Button
            {
                Text = text,
                AccessibleName = selected ? accessibleName + " (đang xem)" : accessibleName,
                AutoSize = true,
                MinimumSize = new Size(pager.LogicalToDeviceUnits(32), pager.LogicalToDeviceUnits(30)),
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(2, 0, 2, 0),
                BackColor = selected ? Color.FromArgb(25, 99, 184) : Color.White,
                ForeColor = selected ? Color.White : pager.ForeColor,
                Enabled = enabled,
                Cursor = Cursors.Hand
            };
            button.FlatAppearance.BorderColor = Color.FromArgb(210, 222, 236);
            button.Click += (_, _) => selectPage(page);
            pager.Controls.Add(button);
            return button;
        }

        public static void ShowStatusWhenEmpty(DataGridView grid, Label status)
        {
            status.TextChanged += (_, _) => grid.Invalidate();
            grid.Paint += (_, e) =>
            {
                if (grid.Rows.Count != 0 || string.IsNullOrWhiteSpace(status.Text))
                    return;

                int header = grid.ColumnHeadersVisible ? grid.ColumnHeadersHeight : 0;
                var bounds = Rectangle.FromLTRB(12, header, grid.ClientSize.Width - 12, grid.ClientSize.Height);
                if (bounds.Width <= 0 || bounds.Height <= 0)
                    return;

                TextRenderer.DrawText(e.Graphics, status.Text, grid.Font, bounds, Color.FromArgb(71, 85, 105),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
            };
        }

        /// <summary>Thêm cột hiển thị một thuộc tính của DTO</summary>
        public static void AddColumn(DataGridView grid, string property, string header, string format = null)
        {
            var column = new DataGridViewTextBoxColumn
            {
                Name = "col" + property,
                DataPropertyName = property,
                HeaderText = header
            };
            column.MinimumWidth = 82;
            column.FillWeight = property switch
            {
                "Title" or "FullName" or "Description" or "Content" => 170,
                "Role" or "IsActive" or "Status" => 85,
                _ => 100
            };
            if (format != null) column.DefaultCellStyle.Format = format;
            grid.Columns.Add(column);
        }

        /// <summary>
        /// Thêm các cột nút (Sửa, Duyệt, ...). allowedActions cho biết dòng nào được hiện nút nào.
        /// </summary>
        public static void AddActionColumns(DataGridView grid, Func<object, string[]> allowedActions, params string[] actions)
        {
            foreach (string action in actions)
            {
                grid.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "btn" + action.Replace(" ", ""),
                    HeaderText = "",
                    Text = action,
                    Tag = action,
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                });
            }

            // Lưu lại hàm kiểm tra để HideUnavailableActions dùng sau khi gán DataSource
            grid.Tag = allowedActions;
        }

        /// <summary>Sau khi gán DataSource: ẩn nút không dùng được ở trạng thái hiện tại của dòng</summary>
        private static void HideUnavailableActions(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (!(grid.Tag is Func<object, string[]> allowedActions)) return;

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.DataBoundItem == null) continue;
                string[] allowed = allowedActions(row.DataBoundItem);
                foreach (DataGridViewColumn column in grid.Columns)
                {
                    if (column is DataGridViewButtonColumn && !allowed.Contains((string)column.Tag))
                        row.Cells[column.Index] = new DataGridViewTextBoxCell { Value = "" };
                }
            }
        }

        /// <summary>Trả về tên thao tác nếu người dùng bấm vào một nút trong lưới, ngược lại null</summary>
        public static string? GetClickedAction(DataGridView grid, DataGridViewCellEventArgs e)
            => GetButtonAction(grid, e.RowIndex, e.ColumnIndex);

        public static string? GetButtonAction(DataGridView grid, int rowIndex, int columnIndex)
        {
            if (rowIndex < 0 || rowIndex >= grid.Rows.Count || columnIndex < 0 || columnIndex >= grid.Columns.Count) return null;
            var cell = grid.Rows[rowIndex].Cells[columnIndex];
            if (cell is DataGridViewButtonCell)
                return grid.Columns[columnIndex].Tag as string;
            return null;
        }

        public static void DrawActionIcon(DataGridView grid, DataGridViewCellPaintingEventArgs e, string action)
        {
            if (e.Graphics == null) return;

            string icon = action switch
            {
                "Chi tiết" => "\uE7B3", // View
                "Sửa" => "\uE70F", // Edit
                "Phân công" => "\uE8FA", // AddFriend
                "Theo dõi" => "\uE9D2", // Diagnostic
                "Duyệt" => "\uE73E", // CheckMark
                "Từ chối" => "\uE711", // Cancel
                "Đăng" => "\uE74A", // Upload
                "Gỡ" => "\uE738", // Remove
                "Khóa tài khoản" => "\uE72E", // Lock
                "Mở khóa tài khoản" => "\uE785", // Unlock
                "Đặt lại MK" => "\uE8D7", // Permissions
                _ => ""
            };
            Color iconColor = action switch
            {
                "Duyệt" => Color.FromArgb(21, 107, 69),
                "Từ chối" or "Gỡ" => Color.FromArgb(157, 48, 48),
                _ => Color.FromArgb(42, 60, 82)
            };
            var bounds = e.CellBounds;
            bounds.Width = Math.Min(bounds.Width, grid.LogicalToDeviceUnits(44));
            bounds.X = e.CellBounds.X + (e.CellBounds.Width - bounds.Width) / 2;
            int horizontal = grid.LogicalToDeviceUnits(4);
            int vertical = Math.Max(grid.LogicalToDeviceUnits(4), (bounds.Height - grid.LogicalToDeviceUnits(28)) / 2);
            bounds.Inflate(-horizontal, -vertical);
            if (bounds.Width < 2 || bounds.Height < 2)
                return;

            e.Paint(e.ClipBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.SelectionBackground |
                DataGridViewPaintParts.Border);
            if (e.CellBounds.Contains(grid.PointToClient(Cursor.Position)))
            {
                using var hoverBrush = new SolidBrush(Color.FromArgb(22, iconColor));
                e.Graphics.FillRectangle(hoverBrush, bounds);
            }
            using var iconFont = new Font("Segoe MDL2 Assets", 11F);
            TextRenderer.DrawText(e.Graphics, icon, iconFont, bounds, iconColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine |
                TextFormatFlags.EndEllipsis);
            e.Paint(e.ClipBounds, DataGridViewPaintParts.Focus);
            e.Handled = true;
        }

        public static void InvalidateActionButton(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView grid && GetClickedAction(grid, e) != null)
                grid.InvalidateCell(e.ColumnIndex, e.RowIndex);
        }

        private static void DrawStatusBadge(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (sender is not DataGridView grid || e.RowIndex < 0 || e.ColumnIndex < 0 ||
                e.Graphics == null || grid.Columns[e.ColumnIndex].DataPropertyName is not ("Status" or "IsActive" or "Role") ||
                e.FormattedValue is not string text || string.IsNullOrWhiteSpace(text)) return;


            var font = e.CellStyle?.Font ?? grid.Font;
            var color = e.CellStyle?.ForeColor ?? grid.ForeColor;
            int inset = grid.LogicalToDeviceUnits(6);
            int height = Math.Min(grid.LogicalToDeviceUnits(24), e.CellBounds.Height - inset);
            int width = Math.Min(e.CellBounds.Width - inset * 2,
                TextRenderer.MeasureText(text, font).Width + inset * 2);
            if (height < 8 || width < 8) return;
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            var badge = new Rectangle(e.CellBounds.Left + inset, e.CellBounds.Top + (e.CellBounds.Height - height) / 2, width, height);
            var tint = Color.FromArgb((color.R + 255 * 8) / 9, (color.G + 255 * 8) / 9, (color.B + 255 * 8) / 9);
            int diameter = Math.Min(badge.Width, badge.Height);
            using var outline = new GraphicsPath();
            outline.AddArc(badge.Left, badge.Top, diameter, diameter, 90, 180);
            outline.AddArc(badge.Right - diameter, badge.Top, diameter, diameter, 270, 180);
            outline.CloseFigure();
            var graphicsState = e.Graphics.Save();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(tint);
            e.Graphics.FillPath(brush, outline);
            e.Graphics.Restore(graphicsState);
            TextRenderer.DrawText(e.Graphics, text, font, badge, color,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);
            e.Handled = true;
        }

        private static void FormatStatusCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string property = grid.Columns[e.ColumnIndex].DataPropertyName;
            if (property == "Role" && e.Value is string role)
            {
                e.Value = AdminHelper.RoleName(role);
                e.FormattingApplied = true;
                e.CellStyle.ForeColor = role switch
                {
                    "Admin" => Color.FromArgb(91, 33, 182),
                    "CanBo" => Color.FromArgb(30, 64, 175),
                    _ => Color.FromArgb(51, 65, 85)
                };
                e.CellStyle.Font = StatusFont;
                return;
            }
            if (property == "IsActive" && e.Value is bool active)
            {
                e.Value = active ? "Hoạt động" : "Bị khóa";
                e.FormattingApplied = true;
            }
            else if (property == "Status" && e.Value is string status)
            {
                e.Value = AdminHelper.EventStatusText(status);
                e.FormattingApplied = true;
            }
            else
            {
                return;
            }

            string text = e.Value?.ToString() ?? "";
            if (text.Contains("khóa") || text.Contains("Từ chối") || text.Contains("hủy") || text.Contains("gỡ"))
                e.CellStyle.ForeColor = Color.Firebrick;
            else if (text.Contains("Chờ") || text.Contains("Nháp") || text == "Đã gửi")
                e.CellStyle.ForeColor = Color.FromArgb(133, 80, 18);
            else
                e.CellStyle.ForeColor = Color.SeaGreen;
            e.CellStyle.Font = StatusFont;
        }

        // Dùng chung 1 font: CellFormatting chạy liên tục, tạo Font mới mỗi lần sẽ rò rỉ tài nguyên GDI
        private static readonly Font StatusFont = new Font("Segoe UI Semibold", 9F);
    }
}
