using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EventManager.UI.UserControls.CanBo
{
    public partial class ucBaoCaoThongKe : UserControl
    {
        private readonly ApiService _apiService;
        private const int HeaderHeight = 180; // pnlTop(48) + pnlFilter(44) + pnlSummary(88)

        public ucBaoCaoThongKe()
        {
            InitializeComponent();
            _apiService = new ApiService();

            this.Load   += ucBaoCaoThongKe_Load;
            this.Resize += ucBaoCaoThongKe_Resize;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
        }

        // ─── Resize: giữ chart đúng kích thước ──────────────────────
        private void ucBaoCaoThongKe_Resize(object sender, EventArgs e)
        {
            int h = this.Height - HeaderHeight;
            if (h > 0)
            {
                chartEvents.Location = new Point(0, HeaderHeight);
                chartEvents.Size     = new Size(this.Width, h);
            }
        }

        // ─── Load lần đầu ───────────────────────────────────────────
        private async void ucBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpTo.Value   = new DateTime(DateTime.Now.Year, 12, 31);

            // Kích hoạt resize ngay để chart có kích thước đúng trước khi vẽ
            ucBaoCaoThongKe_Resize(this, EventArgs.Empty);

            await LoadCharts();
        }

        // ─── Nút Xem báo cáo ────────────────────────────────────────
        private async void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            await LoadCharts();
        }

        // ─── Gọi API và vẽ biểu đồ ──────────────────────────────────
        private async System.Threading.Tasks.Task LoadCharts()
        {
            try
            {
                btnXemBaoCao.Enabled = false;
                lblStatus.Text = "Đang tải...";

                DateTime? from = chkFilterDate.Checked ? (DateTime?)dtpFrom.Value.Date : null;
                DateTime? to   = chkFilterDate.Checked
                    ? (DateTime?)dtpTo.Value.Date.AddDays(1).AddSeconds(-1)
                    : null;

                var data = await _apiService.GetReportStatisticsAsync(from, to);

                if (data == null)
                {
                    lblStatus.Text = "Không thể tải dữ liệu.";
                    return;
                }

                // ── Cập nhật thẻ số liệu ─────────────────────────────
                lblTotalEvents.Text       = data.TotalEvents.ToString("N0");
                lblOngoing.Text           = data.OngoingEvents.ToString("N0");
                lblCompleted.Text         = data.CompletedEvents.ToString("N0");
                lblCancelled.Text         = data.CancelledEvents.ToString("N0");
                lblTotalParticipants.Text = data.TotalParticipants.ToString("N0");
                lblAttended.Text          = data.AttendedParticipants.ToString("N0");

                double rate = data.TotalParticipants > 0
                    ? Math.Round(data.AttendedParticipants * 100.0 / data.TotalParticipants, 0)
                    : 0;
                lblAttendRate.Text = rate + "%";

                // ── Vẽ biểu đồ cột ───────────────────────────────────
                DrawBarChart(data);

                lblStatus.Text = $"Cập nhật lúc {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi: " + ex.Message;
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnXemBaoCao.Enabled = true;
            }
        }

        // ─── Vẽ biểu đồ cột ─────────────────────────────────────────
        private void DrawBarChart(ReportDataDto data)
        {
            // Guard: không vẽ nếu chart chưa có kích thước hợp lệ
            if (chartEvents.Width <= 0 || chartEvents.Height <= 0) return;

            chartEvents.Series.Clear();
            chartEvents.ChartAreas.Clear();
            chartEvents.Titles.Clear();

            var area = new ChartArea("main");
            area.BackColor                 = Color.White;
            area.AxisX.MajorGrid.Enabled   = false;
            area.AxisX.LineColor           = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(220, 220, 220);
            area.AxisY.Minimum             = 0;
            area.AxisX.LabelStyle.Font     = new Font("Segoe UI", 9f);
            area.AxisY.LabelStyle.Font     = new Font("Segoe UI", 9f);
            area.InnerPlotPosition         = new ElementPosition(6, 8, 90, 85);
            chartEvents.ChartAreas.Add(area);

            chartEvents.Titles.Add(new Title("Số sự kiện theo tháng")
            {
                Font      = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(40, 40, 40),
                Alignment = ContentAlignment.MiddleLeft,
                Docking   = Docking.Top
            });

            var series = new Series("events")
            {
                ChartType           = SeriesChartType.Column,
                Color               = Color.FromArgb(70, 130, 180),
                IsValueShownAsLabel = true,
                LabelForeColor      = Color.FromArgb(50, 50, 50),
                Font                = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ["PointWidth"]      = "0.6",
            };

            foreach (var kv in data.EventsByMonth)
            {
                var pt       = series.Points.Add(kv.Value);
                pt.AxisLabel = kv.Key;
                if (kv.Value == 0)
                    pt.IsValueShownAsLabel = false;
            }

            chartEvents.Series.Add(series);
            chartEvents.BackColor = Color.White;
        }
    }
}
