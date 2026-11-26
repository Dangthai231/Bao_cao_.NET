using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EventManager.UI.UserControls.CanBo
{
    partial class ucBaoCaoThongKe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            // ── Khởi tạo controls ─────────────────────────────────────
            pnlTop        = new Panel();
            lblTitle      = new Label();

            pnlFilter     = new Panel();
            chkFilterDate = new CheckBox();
            lblFrom       = new Label();
            dtpFrom       = new DateTimePicker();
            lblTo         = new Label();
            dtpTo         = new DateTimePicker();
            btnXemBaoCao  = new Button();
            lblStatus     = new Label();

            pnlSummary = new Panel();
            pnlStat1 = new Panel(); lblStat1Title = new Label(); lblTotalEvents       = new Label();
            pnlStat2 = new Panel(); lblStat2Title = new Label(); lblOngoing           = new Label();
            pnlStat3 = new Panel(); lblStat3Title = new Label(); lblCompleted         = new Label();
            pnlStat4 = new Panel(); lblStat4Title = new Label(); lblCancelled         = new Label();
            pnlStat5 = new Panel(); lblStat5Title = new Label(); lblTotalParticipants = new Label();
            pnlStat6 = new Panel(); lblStat6Title = new Label(); lblAttended          = new Label();
            pnlStat7 = new Panel(); lblStat7Title = new Label(); lblAttendRate        = new Label();

            chartEvents = new Chart();

            SuspendLayout();

            // ── UserControl root ──────────────────────────────────────
            AutoScaleDimensions = new SizeF(7f, 15f);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(245, 245, 248);
            Size                = new Size(900, 600);

            // Thứ tự Add quan trọng: Dock=Top xếp từ trên xuống
            Controls.Add(pnlTop);
            Controls.Add(pnlFilter);
            Controls.Add(pnlSummary);
            Controls.Add(chartEvents);  // KHÔNG Dock.Fill — dùng Anchor

            // ── pnlTop ────────────────────────────────────────────────
            pnlTop.Dock      = DockStyle.Top;
            pnlTop.Height    = 48;
            pnlTop.BackColor = Color.FromArgb(30, 30, 47);
            pnlTop.Controls.Add(lblTitle);

            lblTitle.AutoSize  = true;
            lblTitle.Text      = "Báo cáo & Thống kê";
            lblTitle.Font      = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(16, 10);

            // ── pnlFilter ─────────────────────────────────────────────
            pnlFilter.Dock      = DockStyle.Top;
            pnlFilter.Height    = 44;
            pnlFilter.BackColor = Color.White;
            pnlFilter.Controls.AddRange(new Control[]
                { chkFilterDate, lblFrom, dtpFrom, lblTo, dtpTo, btnXemBaoCao, lblStatus });

            chkFilterDate.Text     = "Lọc ngày:";
            chkFilterDate.AutoSize = true;
            chkFilterDate.Location = new Point(12, 12);
            chkFilterDate.Font     = new Font("Segoe UI", 9f);

            lblFrom.Text     = "Từ ngày:";
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(105, 14);
            lblFrom.Font     = new Font("Segoe UI", 9f);

            dtpFrom.Location = new Point(165, 10);
            dtpFrom.Size     = new Size(130, 23);
            dtpFrom.Format   = DateTimePickerFormat.Short;

            lblTo.Text     = "Đến:";
            lblTo.AutoSize = true;
            lblTo.Location = new Point(305, 14);
            lblTo.Font     = new Font("Segoe UI", 9f);

            dtpTo.Location = new Point(340, 10);
            dtpTo.Size     = new Size(130, 23);
            dtpTo.Format   = DateTimePickerFormat.Short;

            btnXemBaoCao.Text      = "Xem báo cáo";
            btnXemBaoCao.Location  = new Point(485, 8);
            btnXemBaoCao.Size      = new Size(110, 28);
            btnXemBaoCao.BackColor = Color.FromArgb(70, 130, 180);
            btnXemBaoCao.ForeColor = Color.White;
            btnXemBaoCao.FlatStyle = FlatStyle.Flat;
            btnXemBaoCao.Font      = new Font("Segoe UI", 9f, FontStyle.Bold);

            lblStatus.AutoSize  = true;
            lblStatus.Location  = new Point(610, 14);
            lblStatus.Font      = new Font("Segoe UI", 8f);
            lblStatus.ForeColor = Color.Gray;

            // ── pnlSummary ────────────────────────────────────────────
            pnlSummary.Dock      = DockStyle.Top;
            pnlSummary.Height    = 88;
            pnlSummary.BackColor = Color.FromArgb(245, 245, 248);

            void SetupStatPanel(Panel p, Label title, Label val, int x,
                Color accent, string titleText)
            {
                p.Size      = new Size(112, 70);
                p.Location  = new Point(x, 9);
                p.BackColor = Color.White;

                title.Text      = titleText;
                title.AutoSize  = false;
                title.Size      = new Size(96, 22);
                title.Location  = new Point(8, 6);
                title.TextAlign = ContentAlignment.MiddleLeft;
                title.Font      = new Font("Segoe UI", 7.5f);
                title.ForeColor = Color.Gray;

                val.Text      = "–";
                val.AutoSize  = false;
                val.Size      = new Size(96, 32);
                val.Location  = new Point(8, 28);
                val.TextAlign = ContentAlignment.MiddleCenter;
                val.Font      = new Font("Segoe UI", 16f, FontStyle.Bold);
                val.ForeColor = accent;

                p.Controls.Add(title);
                p.Controls.Add(val);
                pnlSummary.Controls.Add(p);
            }

            SetupStatPanel(pnlStat1, lblStat1Title, lblTotalEvents,        10, Color.FromArgb(70, 130, 180),  "Tổng sự kiện");
            SetupStatPanel(pnlStat2, lblStat2Title, lblOngoing,           130, Color.FromArgb(30, 144, 255),  "Đang diễn ra");
            SetupStatPanel(pnlStat3, lblStat3Title, lblCompleted,         250, Color.FromArgb(60, 179, 113),  "Hoàn thành");
            SetupStatPanel(pnlStat4, lblStat4Title, lblCancelled,         370, Color.FromArgb(220, 80, 80),   "Đã hủy");
            SetupStatPanel(pnlStat5, lblStat5Title, lblTotalParticipants, 490, Color.FromArgb(148, 103, 189), "T.số tham gia");
            SetupStatPanel(pnlStat6, lblStat6Title, lblAttended,          610, Color.FromArgb(23, 162, 184),  "Đã tham dự");
            SetupStatPanel(pnlStat7, lblStat7Title, lblAttendRate,        730, Color.FromArgb(255, 140, 0),   "Tỷ lệ tham dự");

            // ── chartEvents ───────────────────────────────────────────
            // Dùng Anchor thay DockStyle.Fill để tránh lỗi "Height must be > 0"
            // khi chart chưa được add vào parent có kích thước xác định.
            // Vị trí / size thực sẽ được cập nhật bởi ucBaoCaoThongKe_Resize.
            chartEvents.Location  = new Point(0, 180);   // 48+44+88 = 180
            chartEvents.Size      = new Size(900, 420);
            chartEvents.Anchor    = AnchorStyles.Top | AnchorStyles.Bottom
                                  | AnchorStyles.Left | AnchorStyles.Right;
            chartEvents.BackColor = Color.White;

            ResumeLayout(false);
        }

        #endregion

        // ── Fields ────────────────────────────────────────────────────
        private Panel pnlTop, pnlFilter, pnlSummary;
        private Label lblTitle, lblFrom, lblTo, lblStatus;
        private CheckBox chkFilterDate;
        private DateTimePicker dtpFrom, dtpTo;
        private Button btnXemBaoCao;

        private Panel pnlStat1, pnlStat2, pnlStat3, pnlStat4, pnlStat5, pnlStat6, pnlStat7;
        private Label lblStat1Title, lblStat2Title, lblStat3Title, lblStat4Title,
                      lblStat5Title, lblStat6Title, lblStat7Title;
        private Label lblTotalEvents, lblOngoing, lblCompleted, lblCancelled,
                      lblTotalParticipants, lblAttended, lblAttendRate;

        private Chart chartEvents;
    }
}
