using EventManager.UI.Forms.Canbo;
using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.CanBo
{
    public partial class ucQuanLyCongViec : UserControl
    {
        private readonly ApiService _apiService = ApiService.Instance;
        private List<TaskItemDto> _allTasks = new List<TaskItemDto>();
        private List<TaskItemDto> _filteredTasks = new List<TaskItemDto>();
        private TaskSummaryDto _summary = new TaskSummaryDto();

        private string _activeStatusTab = "Tất cả";
        private int _avgProgressPercent = 0;

        public ucQuanLyCongViec()
        {
            InitializeComponent();
            SetupCustomStyles();
            HookEvents();
        }

        private void SetupCustomStyles()
        {
            // Cấu hình bo góc cho các nút
            ApplyRoundedRegion(btnRefresh, 6);
            ApplyRoundedRegion(btnCreateTask, 6);

            // Cấu hình vẽ viền cho các card
            SetupCardPainting(cardTotal, "📋", "Tổng công việc", () => _summary.TongCongViec.ToString(), Color.FromArgb(239, 246, 255), Color.FromArgb(37, 99, 235));
            SetupCardPainting(cardInProgress, "🕒", "Đang thực hiện", () => _summary.DangThucHien.ToString(), Color.FromArgb(255, 247, 237), Color.FromArgb(234, 88, 12));
            SetupCardPainting(cardCompleted, "✔️", "Hoàn thành", () => _summary.HoanThanh.ToString(), Color.FromArgb(240, 253, 244), Color.FromArgb(22, 163, 74));
            SetupCardPainting(cardOverdue, "🔔", "Quá hạn", () => _summary.QuaHan.ToString(), Color.FromArgb(254, 242, 242), Color.FromArgb(220, 38, 38));

            // Vẽ thanh tiến độ trung bình trên pnlAverageProgress
            pnlAverageProgress.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Viền card
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlAverageProgress.Width - 1, pnlAverageProgress.Height - 1);

                // Thanh tiến độ nằm giữa tiêu đề và nhãn %
                int barX = lblAvgTitle.Right + 20;
                int barW = Math.Max(50, lblAvgPercent.Left - barX - 20);
                int barY = (pnlAverageProgress.Height - 10) / 2;
                int barH = 10;

                // Track
                using var trackBrush = new SolidBrush(Color.FromArgb(241, 245, 249));
                using var trackPath = CreateRoundedRectangle(new Rectangle(barX, barY, barW, barH), 5);
                e.Graphics.FillPath(trackBrush, trackPath);

                // Fill
                if (_avgProgressPercent > 0)
                {
                    int fillW = Math.Max(8, (int)(barW * (_avgProgressPercent / 100.0)));
                    using var fillBrush = new SolidBrush(Color.FromArgb(37, 99, 235));
                    using var fillPath = CreateRoundedRectangle(new Rectangle(barX, barY, fillW, barH), 5);
                    e.Graphics.FillPath(fillBrush, fillPath);
                }
            };

            // Vẽ viền khung chứa bảng
            pnlGridCard.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, pnlGridCard.Width - 1, pnlGridCard.Height - 1);
            };

            // Vẽ gạch chân cho tab đang chọn trên pnlTabs
            pnlTabs.Paint += (s, e) =>
            {
                using var penBorder = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawLine(penBorder, 0, pnlTabs.Height - 1, pnlTabs.Width, pnlTabs.Height - 1);

                Button? activeBtn = GetActiveTabButton();
                if (activeBtn != null)
                {
                    using var activePen = new Pen(Color.FromArgb(37, 99, 235), 3);
                    e.Graphics.DrawLine(activePen, activeBtn.Left, pnlTabs.Height - 2, activeBtn.Right, pnlTabs.Height - 2);
                }
            };

            // Custom painting cho DataGridView
            dgvTasks.CellPainting += DgvTasks_CellPainting;
            dgvTasks.CellMouseClick += DgvTasks_CellMouseClick;
        }

        private void HookEvents()
        {
            this.Load += async (s, e) => await LoadDataAsync();
            btnRefresh.Click += async (s, e) => await LoadDataAsync();
            btnCreateTask.Click += BtnCreateTask_Click;

            btnTabAll.Click += (s, e) => SwitchTab("Tất cả");
            btnTabNotStarted.Click += (s, e) => SwitchTab("Chưa bắt đầu");
            btnTabInProgress.Click += (s, e) => SwitchTab("Đang thực hiện");
            btnTabCompleted.Click += (s, e) => SwitchTab("Hoàn thành");
            btnTabOnHold.Click += (s, e) => SwitchTab("Tạm hoãn");

            txtSearch.TextChanged += (s, e) => ApplyLocalFilter();
            cboEventFilter.SelectedIndexChanged += (s, e) => ApplyLocalFilter();
        }

        private void SetupCardPainting(Panel card, string icon, string title, Func<string> getValue, Color circleBg, Color iconColor)
        {
            card.BackColor = Color.White;
            card.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Viền card
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);

                // Hình tròn icon
                int circleSize = 38;
                int circleX = 14;
                int circleY = (card.Height - circleSize) / 2;
                using var circleBrush = new SolidBrush(circleBg);
                e.Graphics.FillEllipse(circleBrush, circleX, circleY, circleSize, circleSize);

                // Icon text
                using var iconFont = new Font("Segoe UI", 13F);
                using var iconBrush = new SolidBrush(iconColor);
                var iconRect = new Rectangle(circleX, circleY, circleSize, circleSize);
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(icon, iconFont, iconBrush, iconRect, sf);

                // Tiêu đề nhỏ
                int textX = circleX + circleSize + 12;
                using var titleFont = new Font("Segoe UI", 8.5F);
                using var titleBrush = new SolidBrush(Color.FromArgb(100, 116, 139));
                e.Graphics.DrawString(title, titleFont, titleBrush, new PointF(textX, 13));

                // Số lượng lớn in đậm
                using var valFont = new Font("Segoe UI", 15F, FontStyle.Bold);
                using var valBrush = new SolidBrush(Color.FromArgb(15, 23, 42));
                e.Graphics.DrawString(getValue(), valFont, valBrush, new PointF(textX, 29));
            };
        }

        public async Task LoadDataAsync()
        {
            try
            {
                // 1. Tải danh sách sự kiện cho ComboBox nếu chưa có
                if (cboEventFilter.Items.Count <= 1)
                {
                    var events = await _apiService.GetTaskEventsAsync();
                    cboEventFilter.Items.Clear();
                    cboEventFilter.Items.Add(new DropdownItem { Text = "Tất cả sự kiện", Value = 0 });
                    foreach (var ev in events)
                    {
                        cboEventFilter.Items.Add(new DropdownItem { Text = ev.TenSuKien, Value = ev.Id });
                    }
                    cboEventFilter.SelectedIndex = 0;
                }

                // 2. Tải danh sách công việc từ DB
                _allTasks = await _apiService.GetTasksAsync();

                // 3. Tải thống kê
                _summary = await _apiService.GetTaskSummaryAsync();
                _avgProgressPercent = _summary.TienDoTrungBinh;
                lblAvgPercent.Text = $"{_avgProgressPercent}%";

                // Cập nhật số liệu trên các tab
                UpdateTabBadges();

                // 4. Áp dụng bộ lọc và hiển thị lên bảng
                ApplyLocalFilter();

                // Vẽ lại giao diện card và progress
                pnlCards.Invalidate(true);
                pnlAverageProgress.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu công việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTabBadges()
        {
            int allCount = _allTasks.Count;
            int notStarted = _allTasks.Count(t => t.TrangThai == "Chưa bắt đầu");
            int inProgress = _allTasks.Count(t => t.TrangThai == "Đang thực hiện");
            int completed = _allTasks.Count(t => t.TrangThai == "Hoàn thành");
            int onHold = _allTasks.Count(t => t.TrangThai == "Tạm hoãn");

            btnTabAll.Text = $"Tất cả ({allCount})";
            btnTabNotStarted.Text = $"Chưa bắt đầu ({notStarted})";
            btnTabInProgress.Text = $"Đang thực hiện ({inProgress})";
            btnTabCompleted.Text = $"Hoàn thành ({completed})";
            btnTabOnHold.Text = $"Tạm hoãn ({onHold})";
        }

        private void SwitchTab(string status)
        {
            _activeStatusTab = status;

            Button[] tabs = { btnTabAll, btnTabNotStarted, btnTabInProgress, btnTabCompleted, btnTabOnHold };
            foreach (var b in tabs)
            {
                bool isActive = (b.Text.StartsWith(status));
                b.Font = new Font("Segoe UI", 9.25F, isActive ? FontStyle.Bold : FontStyle.Regular);
                b.ForeColor = isActive ? Color.FromArgb(37, 99, 235) : Color.FromArgb(100, 116, 139);
            }

            pnlTabs.Invalidate();
            ApplyLocalFilter();
        }

        private Button? GetActiveTabButton()
        {
            if (_activeStatusTab == "Chưa bắt đầu") return btnTabNotStarted;
            if (_activeStatusTab == "Đang thực hiện") return btnTabInProgress;
            if (_activeStatusTab == "Hoàn thành") return btnTabCompleted;
            if (_activeStatusTab == "Tạm hoãn") return btnTabOnHold;
            return btnTabAll;
        }

        private void ApplyLocalFilter()
        {
            var query = _allTasks.AsEnumerable();

            // Lọc theo tab trạng thái
            if (_activeStatusTab != "Tất cả")
            {
                query = query.Where(t => t.TrangThai == _activeStatusTab);
            }

            // Lọc theo sự kiện
            if (cboEventFilter.SelectedItem is DropdownItem selectedItem && selectedItem.Value > 0)
            {
                query = query.Where(t => t.SuKienId == selectedItem.Value || t.TenSuKien == selectedItem.Text);
            }

            // Lọc theo từ khóa tìm kiếm
            string kw = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(kw))
            {
                query = query.Where(t =>
                    t.MaCv.ToLower().Contains(kw) ||
                    t.TenCongViec.ToLower().Contains(kw) ||
                    (t.NhanSu != null && t.NhanSu.ToLower().Contains(kw)) ||
                    (t.TenSuKien != null && t.TenSuKien.ToLower().Contains(kw)) ||
                    (t.MoTa != null && t.MoTa.ToLower().Contains(kw)));
            }

            _filteredTasks = query.ToList();
            PopulateGrid(_filteredTasks);

            lblFooterCount.Text = $"Hiển thị {_filteredTasks.Count} trong tổng số {_allTasks.Count} công việc";
        }

        private void PopulateGrid(List<TaskItemDto> list)
        {
            dgvTasks.Rows.Clear();
            foreach (var t in list)
            {
                int rowIndex = dgvTasks.Rows.Add(
                    t.MaCv,
                    t.TenCongViec,
                    t.TenSuKien ?? "---",
                    t.NhanSu ?? "---",
                    t.MucDoUuTien,
                    t.HanChotFormatted,
                    $"{t.TienDo}%",
                    t.TrangThai,
                    ""
                );
                dgvTasks.Rows[rowIndex].Tag = t;
            }
        }

        // --- TÙY CHỈNH VẼ TỪNG Ô DATAGRIDVIEW ---
        private void DgvTasks_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var task = dgvTasks.Rows[e.RowIndex].Tag as TaskItemDto;
            if (task == null) return;

            e.PaintBackground(e.CellBounds, true);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // 1. CỘT CÔNG VIỆC: Tên in đậm + Mô tả xám bên dưới
            if (e.ColumnIndex == colCongViec.Index)
            {
                using var titleFont = new Font("Segoe UI", 9.25F, FontStyle.Bold);
                using var titleBrush = new SolidBrush(Color.FromArgb(15, 23, 42));
                e.Graphics.DrawString(task.TenCongViec, titleFont, titleBrush, new PointF(e.CellBounds.X + 8, e.CellBounds.Y + 8));

                if (!string.IsNullOrWhiteSpace(task.MoTa))
                {
                    using var descFont = new Font("Segoe UI", 8F);
                    using var descBrush = new SolidBrush(Color.FromArgb(100, 116, 139));
                    string shortDesc = task.MoTa.Length > 55 ? task.MoTa.Substring(0, 52) + "..." : task.MoTa;
                    e.Graphics.DrawString(shortDesc, descFont, descBrush, new PointF(e.CellBounds.X + 8, e.CellBounds.Y + 28));
                }

                e.Handled = true;
            }
            // 2. CỘT ƯU TIÊN: Badge bo tròn
            else if (e.ColumnIndex == colUuTien.Index)
            {
                Color bg = Color.FromArgb(241, 245, 249);
                Color fg = Color.FromArgb(71, 85, 105);

                if (task.MucDoUuTien == "Cao")
                {
                    bg = Color.FromArgb(254, 226, 226);
                    fg = Color.FromArgb(220, 38, 38);
                }
                else if (task.MucDoUuTien == "Trung bình")
                {
                    bg = Color.FromArgb(254, 243, 199);
                    fg = Color.FromArgb(217, 119, 6);
                }
                else if (task.MucDoUuTien == "Thấp")
                {
                    bg = Color.FromArgb(220, 252, 231);
                    fg = Color.FromArgb(22, 163, 74);
                }

                int badgeW = 75;
                int badgeH = 22;
                int badgeX = e.CellBounds.X + (e.CellBounds.Width - badgeW) / 2;
                int badgeY = e.CellBounds.Y + (e.CellBounds.Height - badgeH) / 2;

                using var path = CreateRoundedRectangle(new Rectangle(badgeX, badgeY, badgeW, badgeH), 11);
                using var brush = new SolidBrush(bg);
                e.Graphics.FillPath(brush, path);

                using var textBrush = new SolidBrush(fg);
                using var badgeFont = new Font("Segoe UI", 8.25F, FontStyle.Bold);
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(task.MucDoUuTien, badgeFont, textBrush, new Rectangle(badgeX, badgeY, badgeW, badgeH), sf);

                e.Handled = true;
            }
            // 3. CỘT HẠN CHÓT: Nếu quá hạn thì in đỏ đậm
            else if (e.ColumnIndex == colHanChot.Index)
            {
                bool isOverdue = task.IsOverdue;
                using var font = new Font("Segoe UI", 9F, isOverdue ? FontStyle.Bold : FontStyle.Regular);
                using var brush = new SolidBrush(isOverdue ? Color.FromArgb(220, 38, 38) : Color.FromArgb(51, 65, 85));

                var sf = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(task.HanChotFormatted, font, brush, new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y, e.CellBounds.Width - 10, e.CellBounds.Height), sf);
                e.Handled = true;
            }
            // 4. CỘT TIẾN ĐỘ: Mini progress bar + %
            else if (e.ColumnIndex == colTienDo.Index)
            {
                int barW = 55;
                int barH = 6;
                int barX = e.CellBounds.X + 8;
                int barY = e.CellBounds.Y + (e.CellBounds.Height - barH) / 2;

                // Track
                using var trackBrush = new SolidBrush(Color.FromArgb(241, 245, 249));
                using var trackPath = CreateRoundedRectangle(new Rectangle(barX, barY, barW, barH), 3);
                e.Graphics.FillPath(trackBrush, trackPath);

                // Fill
                if (task.TienDo > 0)
                {
                    int fillW = Math.Max(4, (int)(barW * (task.TienDo / 100.0)));
                    Color barColor = task.TienDo == 100 ? Color.FromArgb(22, 163, 74) :
                                    (task.TienDo < 30 ? Color.FromArgb(234, 88, 12) : Color.FromArgb(37, 99, 235));
                    using var fillBrush = new SolidBrush(barColor);
                    using var fillPath = CreateRoundedRectangle(new Rectangle(barX, barY, fillW, barH), 3);
                    e.Graphics.FillPath(fillBrush, fillPath);
                }

                // Text %
                using var pctFont = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                using var pctBrush = new SolidBrush(Color.FromArgb(51, 65, 85));
                e.Graphics.DrawString($"{task.TienDo}%", pctFont, pctBrush, new PointF(barX + barW + 8, e.CellBounds.Y + 17));

                e.Handled = true;
            }
            // 5. CỘT TRẠNG THÁI: Dấu chấm tròn màu + Tên trạng thái
            else if (e.ColumnIndex == colTrangThai.Index)
            {
                Color dotColor = Color.FromArgb(100, 116, 139);
                if (task.TrangThai == "Chưa bắt đầu") dotColor = Color.FromArgb(245, 158, 11);
                else if (task.TrangThai == "Đang thực hiện") dotColor = Color.FromArgb(37, 99, 235);
                else if (task.TrangThai == "Hoàn thành") dotColor = Color.FromArgb(22, 163, 74);
                else if (task.TrangThai == "Tạm hoãn") dotColor = Color.FromArgb(239, 68, 68);

                int dotSize = 7;
                int dotX = e.CellBounds.X + 8;
                int dotY = e.CellBounds.Y + (e.CellBounds.Height - dotSize) / 2;

                using var dotBrush = new SolidBrush(dotColor);
                e.Graphics.FillEllipse(dotBrush, dotX, dotY, dotSize, dotSize);

                using var textBrush = new SolidBrush(dotColor);
                using var stFont = new Font("Segoe UI", 8.75F, FontStyle.Regular);
                e.Graphics.DrawString(task.TrangThai, stFont, textBrush, new PointF(dotX + dotSize + 6, e.CellBounds.Y + 17));

                e.Handled = true;
            }
            // 6. CỘT THAO TÁC: 4 icons (✏️, 👤, ✔️, 🗑️)
            else if (e.ColumnIndex == colThaoTac.Index)
            {
                int startX = e.CellBounds.X + 6;
                int iconY = e.CellBounds.Y + (e.CellBounds.Height - 24) / 2;
                using var iconFont = new Font("Segoe UI", 9.5F);

                // ✏️ Sửa
                DrawActionIcon(e.Graphics, "✏️", startX, iconY, Color.FromArgb(71, 85, 105), iconFont);
                // 👤 Phân công
                DrawActionIcon(e.Graphics, "👤", startX + 26, iconY, Color.FromArgb(37, 99, 235), iconFont);
                // ✔️ Hoàn thành
                DrawActionIcon(e.Graphics, "✔️", startX + 52, iconY, Color.FromArgb(22, 163, 74), iconFont);
                // 🗑️ Xóa
                DrawActionIcon(e.Graphics, "🗑️", startX + 78, iconY, Color.FromArgb(220, 38, 38), iconFont);

                e.Handled = true;
            }
        }

        private void DrawActionIcon(Graphics g, string icon, int x, int y, Color color, Font font)
        {
            var rect = new Rectangle(x, y, 22, 22);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            using var brush = new SolidBrush(color);
            g.DrawString(icon, font, brush, rect, sf);
        }

        // --- XỬ LÝ CLICK CÁC NÚT THAO TÁC TRÊN BẢNG ---
        private async void DgvTasks_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colThaoTac.Index) return;

            var task = dgvTasks.Rows[e.RowIndex].Tag as TaskItemDto;
            if (task == null) return;

            int cellX = e.X;
            int startX = 6;

            // 1. ✏️ Click Sửa (X: 6 -> 28)
            if (cellX >= startX && cellX < startX + 26)
            {
                var dlg = new TaskEditDialog(task);
                dlg.ShowDialog(this.FindForm());
                if (dlg.IsSaved)
                {
                    await LoadDataAsync();
                }
            }
            // 2. 👤 Click Phân công (X: 32 -> 54)
            else if (cellX >= startX + 26 && cellX < startX + 52)
            {
                var dlg = new TaskAssignDialog(task);
                dlg.ShowDialog(this.FindForm());
                if (dlg.IsAssigned)
                {
                    await LoadDataAsync();
                }
            }
            // 3. ✔️ Click Đánh dấu hoàn thành (X: 58 -> 80)
            else if (cellX >= startX + 52 && cellX < startX + 78)
            {
                if (task.TrangThai == "Hoàn thành")
                {
                    MessageBox.Show("Công việc này đã hoàn thành rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var res = MessageBox.Show($"Đánh dấu hoàn thành 100% cho công việc '{task.TenCongViec}'?", "Xác nhận hoàn thành",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    var (success, msg) = await _apiService.CompleteTaskAsync(task.Id);
                    if (success)
                    {
                        MessageBox.Show("Đã cập nhật hoàn thành công việc!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // 4. 🗑️ Click Xóa công việc (X: 84 -> 106)
            else if (cellX >= startX + 78 && cellX < startX + 104)
            {
                var res = MessageBox.Show($"Bạn có chắc chắn muốn xóa công việc '{task.MaCv} - {task.TenCongViec}' khỏi hệ thống?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res == DialogResult.Yes)
                {
                    var (success, msg) = await _apiService.DeleteTaskAsync(task.Id);
                    if (success)
                    {
                        MessageBox.Show("Đã xóa công việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa: " + msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void BtnCreateTask_Click(object? sender, EventArgs e)
        {
            var dlg = new TaskEditDialog();
            dlg.ShowDialog(this.FindForm());
            if (dlg.IsSaved)
            {
                await LoadDataAsync();
            }
        }

        private void ApplyRoundedRegion(Control ctrl, int radius)
        {
            if (ctrl.Width <= 0 || ctrl.Height <= 0) return;
            using var path = CreateRoundedRectangle(new Rectangle(0, 0, ctrl.Width, ctrl.Height), radius);
            ctrl.Region?.Dispose();
            ctrl.Region = new Region(path);
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

        private class DropdownItem
        {
            public string Text { get; set; } = string.Empty;
            public long Value { get; set; }
            public override string ToString() => Text;
        }
    }
}
