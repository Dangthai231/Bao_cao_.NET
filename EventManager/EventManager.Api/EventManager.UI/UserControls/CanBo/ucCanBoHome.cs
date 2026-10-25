using EventManager.UI.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.UserControls
{
    public partial class ucCanBoHome : UserControl
    {
        private readonly ApiService _apiService;

        public ucCanBoHome()
        {
            InitializeComponent();
            _apiService = new ApiService();

            // Gán sự kiện vẽ viền tinh tế cho các thẻ số liệu và banner
            panel1.Paint += Card_Paint;
            panel2.Paint += Card_Paint;
            panel3.Paint += Card_Paint;
            panel4.Paint += Card_Paint;
            panel5.Paint += Card_Paint;
            panel6.Paint += Card_Paint;
            pnlBanner.Paint += Card_Paint;

            this.Load += ucCanBoHome_Load;
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel p)
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
            }
        }

        private async void ucCanBoHome_Load(object sender, EventArgs e)
        {
            // Cập nhật ngày hiện tại vào dòng thông báo chân trang
            lblBannerText.Text = $"Ngày {DateTime.Now:dd/MM/yyyy} - Chúc bạn một ngày làm việc hiệu quả và quản lý sự kiện thành công!";

            try
            {
                // Gọi API lấy dữ liệu thống kê thực tế
                var summary = await _apiService.GetDashboardSummaryAsync();

                if (summary != null)
                {
                    lblActiveEvents.Text = summary.ActiveEvents.ToString();
                    lblPendingTasks.Text = summary.PendingTasks.ToString();
                    lblTotalParticipants.Text = summary.TotalParticipants.ToString();
                    lblEventDocuments.Text = summary.EventDocuments.ToString();
                    lblSentNotifications.Text = summary.SentNotifications.ToString();
                    lblCompletedReports.Text = summary.CompletedReports.ToString();
                }
            }
            catch
            {
                // Giữ lại số liệu mặc định nếu Backend chưa sẵn sàng
            }
        }
    }
}
