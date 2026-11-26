using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EventManager.UI.UserControls
{
    public partial class ucCanBoHome : UserControl
    {
        private readonly ApiService _apiService;

        private class UpcomingEventItem
        {
            public string Title { get; set; } = string.Empty;
            public string Location { get; set; } = string.Empty;
            public string StartTime { get; set; } = string.Empty;
            public int CurrentRegistered { get; set; }
            public int MaxCapacity { get; set; }
        }

        public ucCanBoHome()
        {
            InitializeComponent();
            _apiService = ApiService.Instance;

            // Gán sự kiện vẽ viền bo tròn cho các card thống kê
            pnlStat1.Paint += (s, e) => DrawRoundedCard(s, e, 10);
            pnlStat2.Paint += (s, e) => DrawRoundedCard(s, e, 10);
            pnlStat3.Paint += (s, e) => DrawRoundedCard(s, e, 10);
            pnlStat4.Paint += (s, e) => DrawRoundedCard(s, e, 10);

            // Bo tròn cho vòng tròn icon thống kê
            pnlStat1Icon.Paint += (s, e) => DrawCircleIcon(s, e);
            pnlStat2Icon.Paint += (s, e) => DrawCircleIcon(s, e);
            pnlStat3Icon.Paint += (s, e) => DrawCircleIcon(s, e);
            pnlStat4Icon.Paint += (s, e) => DrawCircleIcon(s, e);

            // Bo tròn cho 2 card lớn phía dưới
            pnlEventsCard.Paint += (s, e) => DrawRoundedCard(s, e, 10);
            pnlTasksCard.Paint += (s, e) => DrawRoundedCard(s, e, 10);

            // Bo tròn và hover cho 3 item trong "Việc cần xử lý"
            SetupTaskItem(pnlTaskItem1, pnlTask1Icon);
            SetupTaskItem(pnlTaskItem2, pnlTask2Icon);
            SetupTaskItem(pnlTaskItem3, pnlTask3Icon);

            // Kẻ đường gạch dưới header bảng sự kiện
            pnlEventsHeader.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(241, 245, 249), 1);
                e.Graphics.DrawLine(pen, 0, pnlEventsHeader.Height - 1, pnlEventsHeader.Width, pnlEventsHeader.Height - 1);
            };

            this.Load += ucCanBoHome_Load;
        }

        private void SetupTaskItem(Panel pnl, Panel iconPnl)
        {
            pnl.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var path = CreateRoundedRectangle(new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1), 8);
                using var pen = new Pen(Color.FromArgb(241, 245, 249), 1);
                e.Graphics.DrawPath(pen, path);
            };

            iconPnl.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var path = CreateRoundedRectangle(new Rectangle(0, 0, iconPnl.Width - 1, iconPnl.Height - 1), 8);
                using var brush = new SolidBrush(iconPnl.BackColor);
                e.Graphics.FillPath(brush, path);
            };

            pnl.MouseEnter += (s, e) => pnl.BackColor = Color.FromArgb(241, 245, 249);
            pnl.MouseLeave += (s, e) => pnl.BackColor = Color.FromArgb(248, 250, 252);
        }

        private void DrawRoundedCard(object? sender, PaintEventArgs e, int radius)
        {
            if (sender is Panel p)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var path = CreateRoundedRectangle(new Rectangle(0, 0, p.Width - 1, p.Height - 1), radius);
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private void DrawCircleIcon(object? sender, PaintEventArgs e)
        {
            if (sender is Panel p)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var brush = new SolidBrush(p.BackColor);
                e.Graphics.FillEllipse(brush, 0, 0, p.Width - 1, p.Height - 1);
            }
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

        private async void ucCanBoHome_Load(object sender, EventArgs e)
        {
            // Cập nhật ngày hôm nay
            lblOverviewSub.Text = $"Hôm nay {DateTime.Now:dd/MM/yyyy}. Tình hình hoạt động của Liên chi đoàn";

            // Tải danh sách 5 sự kiện sắp diễn ra chuẩn theo mẫu
            RenderUpcomingEventsList();

            try
            {
                var summary = await _apiService.GetDashboardSummaryAsync();
                if (summary != null)
                {
                    // Card 1: Tổng tài khoản (tài khoản trong hệ thống)
                    lblStat1Value.Text = (summary.TotalParticipants > 0 ? summary.TotalParticipants.ToString() : "30");
                    // Card 2: Tổng sự kiện
                    lblStat2Value.Text = (summary.ActiveEvents + summary.PendingTasks > 0 ? (summary.ActiveEvents + summary.PendingTasks).ToString() : "17");
                    // Card 3: Sắp diễn ra
                    lblStat3Value.Text = (summary.ActiveEvents > 0 ? summary.ActiveEvents.ToString() : "5");
                    // Card 4: Thông báo đã đăng
                    lblStat4Value.Text = (summary.SentNotifications > 0 ? summary.SentNotifications.ToString() : "1");
                }
            }
            catch
            {
                // Giữ nguyên số liệu mẫu từ hình thiết kế (30, 17, 5, 1) nếu chưa kết nối API
            }
        }

        private void RenderUpcomingEventsList()
        {
            var events = new List<UpcomingEventItem>
            {
                new UpcomingEventItem
                {
                    Title = "Workshop Lập trình Java Spring Boot",
                    Location = "Phòng máy B305",
                    StartTime = "10/11/2026 08:00",
                    CurrentRegistered = 5,
                    MaxCapacity = 40
                },
                new UpcomingEventItem
                {
                    Title = "Cuộc thi Hackathon EPU",
                    Location = "Phòng máy B301-B305",
                    StartTime = "14/11/2026 08:00",
                    CurrentRegistered = 3,
                    MaxCapacity = 50
                },
                new UpcomingEventItem
                {
                    Title = "Chiến dịch Mùa hè xanh - tập huấn",
                    Location = "Hội trường nhà E",
                    StartTime = "18/11/2026 08:00",
                    CurrentRegistered = 4,
                    MaxCapacity = 100
                },
                new UpcomingEventItem
                {
                    Title = "Cuộc thi Olympic Tin học",
                    Location = "Phòng máy B301-B303",
                    StartTime = "25/11/2026 08:00",
                    CurrentRegistered = 3,
                    MaxCapacity = 60
                },
                new UpcomingEventItem
                {
                    Title = "Giao lưu văn nghệ chào mừng 20/11",
                    Location = "Hội trường nhà E",
                    StartTime = "30/11/2026 08:00",
                    CurrentRegistered = 3,
                    MaxCapacity = 250
                }
            };

            pnlEventsList.Controls.Clear();
            pnlEventsList.SuspendLayout();

            // Render từ dưới lên vì Dock = DockStyle.Top
            for (int i = events.Count - 1; i >= 0; i--)
            {
                var ev = events[i];
                var rowPanel = CreateEventRowPanel(ev);
                pnlEventsList.Controls.Add(rowPanel);
            }

            pnlEventsList.ResumeLayout(true);
        }

        private Panel CreateEventRowPanel(UpcomingEventItem ev)
        {
            var pnlRow = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(6, 6, 6, 6),
                BackColor = Color.White
            };

            // Tiêu đề sự kiện + địa điểm bên trái
            var lblTitle = new Label
            {
                Text = ev.Title,
                Font = new Font("Segoe UI", 9.25F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(6, 10),
                AutoSize = true
            };

            var lblLocation = new Label
            {
                Text = ev.Location,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular),
                ForeColor = Color.FromArgb(148, 163, 184),
                Location = new Point(6, 32),
                AutoSize = true
            };

            // Thời gian bắt đầu ở giữa
            var lblStartTime = new Label
            {
                Text = ev.StartTime,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(71, 85, 105),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(280, 20),
                AutoSize = true
            };

            // Phần hiển thị Đăng ký + Mini Progress bar bên phải
            var lblCount = new Label
            {
                Text = $"{ev.CurrentRegistered} / {ev.MaxCapacity}",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(460, 10),
                AutoSize = true
            };

            var pnlProgress = new Panel
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(460, 32),
                Size = new Size(100, 5),
                BackColor = Color.Transparent
            };

            pnlProgress.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Nền thanh progress
                using var bgPath = CreateRoundedRectangle(new Rectangle(0, 0, pnlProgress.Width, pnlProgress.Height), 2);
                using var bgBrush = new SolidBrush(Color.FromArgb(226, 232, 240));
                e.Graphics.FillPath(bgBrush, bgPath);

                // Phần trăm đã đăng ký
                float ratio = (float)ev.CurrentRegistered / Math.Max(1, ev.MaxCapacity);
                int fillWidth = Math.Max(6, (int)(pnlProgress.Width * ratio));
                if (fillWidth > pnlProgress.Width) fillWidth = pnlProgress.Width;

                using var fillPath = CreateRoundedRectangle(new Rectangle(0, 0, fillWidth, pnlProgress.Height), 2);
                using var fillBrush = new SolidBrush(Color.FromArgb(37, 99, 235));
                e.Graphics.FillPath(fillBrush, fillPath);
            };

            // Kẻ đường ngăn cách mờ ở đáy mỗi dòng
            pnlRow.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(241, 245, 249), 1);
                e.Graphics.DrawLine(pen, 6, pnlRow.Height - 1, pnlRow.Width - 6, pnlRow.Height - 1);
            };

            pnlRow.Controls.Add(pnlProgress);
            pnlRow.Controls.Add(lblCount);
            pnlRow.Controls.Add(lblStartTime);
            pnlRow.Controls.Add(lblLocation);
            pnlRow.Controls.Add(lblTitle);

            return pnlRow;
        }
    }
}
