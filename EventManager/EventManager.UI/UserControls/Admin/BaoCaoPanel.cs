using EventManager.UI.Services;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.Admin
{
    /// <summary>
    /// Báo cáo tổng hợp: lượt đăng ký, tham gia, đánh giá, sự kiện theo tháng, top sự kiện
    /// </summary>
    public partial class BaoCaoPanel : UserControl
    {
        private readonly ApiService _apiService = ApiService.Instance;
        private int _loadVersion;

        public BaoCaoPanel()
        {
            InitializeComponent();
            if (AdminHelper.IsDesignMode) return;

            txtTimKiem.Visible = false;

            var area = new ChartArea("Months");
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(226, 234, 244);
            area.AxisY.Minimum = 0;
            chartTheoThang.ChartAreas.Add(area);
            var series = new Series("Sự kiện")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(24, 98, 184),
                IsValueShownAsLabel = true
            };
            chartTheoThang.Series.Add(series);

            AdminGridHelper.Setup(dgvTopSuKien);
            AdminGridHelper.AddColumn(dgvTopSuKien, "Title", "Sự kiện");
            AdminGridHelper.AddColumn(dgvTopSuKien, "Count", "Lượt đăng ký");
            AdminGridHelper.AddColumn(dgvTopSuKien, "MaxParticipants", "Số chỗ");

            dgvTopSuKien.CellPainting += DrawRegistrationBar;
            btnTaiLai.Click += async (s, e) => await LoadDataAsync();
            Load += async (s, e) => await LoadDataAsync();
        }

        private void DrawRegistrationBar(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Graphics == null ||
                dgvTopSuKien.Columns[e.ColumnIndex].DataPropertyName != "Count" ||
                dgvTopSuKien.Rows[e.RowIndex].DataBoundItem is not EventManager.UI.Models.AdminTopEventDto item ||
                item.MaxParticipants <= 0) return;

            e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            var bounds = Rectangle.Inflate(e.CellBounds, -8, 0);
            var track = new Rectangle(bounds.Left, bounds.Bottom - 9, Math.Max(1, bounds.Width), 4);
            using var trackBrush = new SolidBrush(Color.FromArgb(220, 231, 243));
            using var fillBrush = new SolidBrush(Color.FromArgb(24, 98, 184));
            e.Graphics.FillRectangle(trackBrush, track);
            int fill = (int)(track.Width * Math.Clamp((double)item.Count / item.MaxParticipants, 0, 1));
            e.Graphics.FillRectangle(fillBrush, new Rectangle(track.X, track.Y, fill, track.Height));
            bounds.Height -= 9;
            TextRenderer.DrawText(e.Graphics, item.Count.ToString(), dgvTopSuKien.Font, bounds,
                Color.FromArgb(20, 40, 72), TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
            e.Handled = true;
        }

        private async Task LoadDataAsync()
        {
            int version = ++_loadVersion;
            try
            {
                var report = await _apiService.GetAdminReportAsync();
                if (IsDisposed || version != _loadVersion) return;

                lblLuotDangKy.Text = "Lượt đăng ký\r\n" + report.Registered;
                lblThamGia.Text = "Đã tham gia\r\n" + report.Attended;
                lblVangMat.Text = "Vắng mặt\r\n" + report.Absent;
                lblDiemTB.Text = "Điểm đánh giá TB\r\n" + report.AverageRating.ToString("0.0");

                var points = chartTheoThang.Series[0].Points;
                points.Clear();
                foreach (var month in report.Months)
                    points.AddXY(month.Month, month.Count);
                dgvTopSuKien.DataSource = report.TopEvents;

                lblTrangThai.Text = "Tài khoản theo vai trò: " +
                    string.Join(" | ", report.Roles.Select(r => $"{r.Role}: {r.Count}"));
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
