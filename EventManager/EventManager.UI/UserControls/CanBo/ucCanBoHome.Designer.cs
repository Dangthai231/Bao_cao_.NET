namespace EventManager.UI.UserControls
{
    partial class ucCanBoHome
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblOverviewSub = new Label();
            lblOverviewTitle = new Label();
            tblStats = new TableLayoutPanel();
            pnlStat4 = new Panel();
            lblStat4Value = new Label();
            lblStat4Title = new Label();
            pnlStat4Icon = new Panel();
            lblStat4Icon = new Label();
            pnlStat3 = new Panel();
            lblStat3Value = new Label();
            lblStat3Title = new Label();
            pnlStat3Icon = new Panel();
            lblStat3Icon = new Label();
            pnlStat2 = new Panel();
            lblStat2Value = new Label();
            lblStat2Title = new Label();
            pnlStat2Icon = new Panel();
            lblStat2Icon = new Label();
            pnlStat1 = new Panel();
            lblStat1Value = new Label();
            lblStat1Title = new Label();
            pnlStat1Icon = new Panel();
            lblStat1Icon = new Label();
            tblBottom = new TableLayoutPanel();
            pnlTasksCard = new Panel();
            pnlTaskItem3 = new Panel();
            lblTask3Badge = new Label();
            lblTask3Sub = new Label();
            lblTask3Title = new Label();
            pnlTask3Icon = new Panel();
            lblTask3Icon = new Label();
            pnlTaskItem2 = new Panel();
            lblTask2Badge = new Label();
            lblTask2Sub = new Label();
            lblTask2Title = new Label();
            pnlTask2Icon = new Panel();
            lblTask2Icon = new Label();
            pnlTaskItem1 = new Panel();
            lblTask1Badge = new Label();
            lblTask1Sub = new Label();
            lblTask1Title = new Label();
            pnlTask1Icon = new Panel();
            lblTask1Icon = new Label();
            lblTasksSub = new Label();
            lblTasksTitle = new Label();
            pnlEventsCard = new Panel();
            pnlEventsList = new Panel();
            pnlEventsHeader = new Panel();
            lblColReg = new Label();
            lblColStart = new Label();
            lblColEvent = new Label();
            lblViewAll = new Label();
            lblEventsTitle = new Label();
            pnlHeader.SuspendLayout();
            tblStats.SuspendLayout();
            pnlStat4.SuspendLayout();
            pnlStat4Icon.SuspendLayout();
            pnlStat3.SuspendLayout();
            pnlStat3Icon.SuspendLayout();
            pnlStat2.SuspendLayout();
            pnlStat2Icon.SuspendLayout();
            pnlStat1.SuspendLayout();
            pnlStat1Icon.SuspendLayout();
            tblBottom.SuspendLayout();
            pnlTasksCard.SuspendLayout();
            pnlTaskItem3.SuspendLayout();
            pnlTask3Icon.SuspendLayout();
            pnlTaskItem2.SuspendLayout();
            pnlTask2Icon.SuspendLayout();
            pnlTaskItem1.SuspendLayout();
            pnlTask1Icon.SuspendLayout();
            pnlEventsCard.SuspendLayout();
            pnlEventsHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblOverviewSub);
            pnlHeader.Controls.Add(lblOverviewTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(25, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(950, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblOverviewSub
            // 
            lblOverviewSub.AutoSize = true;
            lblOverviewSub.Font = new Font("Segoe UI", 9.5F);
            lblOverviewSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblOverviewSub.Location = new Point(0, 36);
            lblOverviewSub.Name = "lblOverviewSub";
            lblOverviewSub.Size = new Size(335, 17);
            lblOverviewSub.TabIndex = 1;
            lblOverviewSub.Text = "Hôm nay 07/11/2026. Tình hình hoạt động của Liên chi đoàn";
            // 
            // lblOverviewTitle
            // 
            lblOverviewTitle.AutoSize = true;
            lblOverviewTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblOverviewTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblOverviewTitle.Location = new Point(0, 0);
            lblOverviewTitle.Name = "lblOverviewTitle";
            lblOverviewTitle.Size = new Size(155, 37);
            lblOverviewTitle.TabIndex = 0;
            lblOverviewTitle.Text = "Tổng quan";
            // 
            // tblStats
            // 
            tblStats.ColumnCount = 4;
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStats.Controls.Add(pnlStat4, 3, 0);
            tblStats.Controls.Add(pnlStat3, 2, 0);
            tblStats.Controls.Add(pnlStat2, 1, 0);
            tblStats.Controls.Add(pnlStat1, 0, 0);
            tblStats.Dock = DockStyle.Top;
            tblStats.Location = new Point(25, 80);
            tblStats.Name = "tblStats";
            tblStats.RowCount = 1;
            tblStats.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblStats.Size = new Size(950, 96);
            tblStats.TabIndex = 1;
            // 
            // pnlStat4
            // 
            pnlStat4.BackColor = Color.White;
            pnlStat4.Controls.Add(lblStat4Value);
            pnlStat4.Controls.Add(lblStat4Title);
            pnlStat4.Controls.Add(pnlStat4Icon);
            pnlStat4.Dock = DockStyle.Fill;
            pnlStat4.Location = new Point(718, 5);
            pnlStat4.Margin = new Padding(7, 5, 0, 5);
            pnlStat4.Name = "pnlStat4";
            pnlStat4.Padding = new Padding(14);
            pnlStat4.Size = new Size(232, 86);
            pnlStat4.TabIndex = 3;
            // 
            // lblStat4Value
            // 
            lblStat4Value.AutoSize = true;
            lblStat4Value.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblStat4Value.ForeColor = Color.FromArgb(15, 23, 42);
            lblStat4Value.Location = new Point(70, 36);
            lblStat4Value.Name = "lblStat4Value";
            lblStat4Value.Size = new Size(33, 38);
            lblStat4Value.TabIndex = 2;
            lblStat4Value.Text = "1";
            // 
            // lblStat4Title
            // 
            lblStat4Title.AutoSize = true;
            lblStat4Title.Font = new Font("Segoe UI", 9F);
            lblStat4Title.ForeColor = Color.FromArgb(100, 116, 139);
            lblStat4Title.Location = new Point(72, 16);
            lblStat4Title.Name = "lblStat4Title";
            lblStat4Title.Size = new Size(106, 15);
            lblStat4Title.TabIndex = 1;
            lblStat4Title.Text = "Thông báo đã đăng";
            // 
            // pnlStat4Icon
            // 
            pnlStat4Icon.BackColor = Color.FromArgb(254, 243, 199);
            pnlStat4Icon.Controls.Add(lblStat4Icon);
            pnlStat4Icon.Location = new Point(14, 20);
            pnlStat4Icon.Name = "pnlStat4Icon";
            pnlStat4Icon.Size = new Size(46, 46);
            pnlStat4Icon.TabIndex = 0;
            // 
            // lblStat4Icon
            // 
            lblStat4Icon.Dock = DockStyle.Fill;
            lblStat4Icon.Font = new Font("Segoe UI", 15F);
            lblStat4Icon.ForeColor = Color.FromArgb(217, 119, 6);
            lblStat4Icon.Location = new Point(0, 0);
            lblStat4Icon.Name = "lblStat4Icon";
            lblStat4Icon.Size = new Size(46, 46);
            lblStat4Icon.TabIndex = 0;
            lblStat4Icon.Text = "🔔";
            lblStat4Icon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlStat3
            // 
            pnlStat3.BackColor = Color.White;
            pnlStat3.Controls.Add(lblStat3Value);
            pnlStat3.Controls.Add(lblStat3Title);
            pnlStat3.Controls.Add(pnlStat3Icon);
            pnlStat3.Dock = DockStyle.Fill;
            pnlStat3.Location = new Point(481, 5);
            pnlStat3.Margin = new Padding(7, 5, 7, 5);
            pnlStat3.Name = "pnlStat3";
            pnlStat3.Padding = new Padding(14);
            pnlStat3.Size = new Size(223, 86);
            pnlStat3.TabIndex = 2;
            // 
            // lblStat3Value
            // 
            lblStat3Value.AutoSize = true;
            lblStat3Value.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblStat3Value.ForeColor = Color.FromArgb(15, 23, 42);
            lblStat3Value.Location = new Point(70, 36);
            lblStat3Value.Name = "lblStat3Value";
            lblStat3Value.Size = new Size(33, 38);
            lblStat3Value.TabIndex = 2;
            lblStat3Value.Text = "5";
            // 
            // lblStat3Title
            // 
            lblStat3Title.AutoSize = true;
            lblStat3Title.Font = new Font("Segoe UI", 9F);
            lblStat3Title.ForeColor = Color.FromArgb(100, 116, 139);
            lblStat3Title.Location = new Point(72, 16);
            lblStat3Title.Name = "lblStat3Title";
            lblStat3Title.Size = new Size(67, 15);
            lblStat3Title.TabIndex = 1;
            lblStat3Title.Text = "Sắp diễn ra";
            // 
            // pnlStat3Icon
            // 
            pnlStat3Icon.BackColor = Color.FromArgb(220, 252, 231);
            pnlStat3Icon.Controls.Add(lblStat3Icon);
            pnlStat3Icon.Location = new Point(14, 20);
            pnlStat3Icon.Name = "pnlStat3Icon";
            pnlStat3Icon.Size = new Size(46, 46);
            pnlStat3Icon.TabIndex = 0;
            // 
            // lblStat3Icon
            // 
            lblStat3Icon.Dock = DockStyle.Fill;
            lblStat3Icon.Font = new Font("Segoe UI", 15F);
            lblStat3Icon.ForeColor = Color.FromArgb(22, 163, 74);
            lblStat3Icon.Location = new Point(0, 0);
            lblStat3Icon.Name = "lblStat3Icon";
            lblStat3Icon.Size = new Size(46, 46);
            lblStat3Icon.TabIndex = 0;
            lblStat3Icon.Text = "🕒";
            lblStat3Icon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlStat2
            // 
            pnlStat2.BackColor = Color.White;
            pnlStat2.Controls.Add(lblStat2Value);
            pnlStat2.Controls.Add(lblStat2Title);
            pnlStat2.Controls.Add(pnlStat2Icon);
            pnlStat2.Dock = DockStyle.Fill;
            pnlStat2.Location = new Point(244, 5);
            pnlStat2.Margin = new Padding(7, 5, 7, 5);
            pnlStat2.Name = "pnlStat2";
            pnlStat2.Padding = new Padding(14);
            pnlStat2.Size = new Size(223, 86);
            pnlStat2.TabIndex = 1;
            // 
            // lblStat2Value
            // 
            lblStat2Value.AutoSize = true;
            lblStat2Value.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblStat2Value.ForeColor = Color.FromArgb(15, 23, 42);
            lblStat2Value.Location = new Point(70, 36);
            lblStat2Value.Name = "lblStat2Value";
            lblStat2Value.Size = new Size(49, 38);
            lblStat2Value.TabIndex = 2;
            lblStat2Value.Text = "17";
            // 
            // lblStat2Title
            // 
            lblStat2Title.AutoSize = true;
            lblStat2Title.Font = new Font("Segoe UI", 9F);
            lblStat2Title.ForeColor = Color.FromArgb(100, 116, 139);
            lblStat2Title.Location = new Point(72, 16);
            lblStat2Title.Name = "lblStat2Title";
            lblStat2Title.Size = new Size(72, 15);
            lblStat2Title.TabIndex = 1;
            lblStat2Title.Text = "Tổng sự kiện";
            // 
            // pnlStat2Icon
            // 
            pnlStat2Icon.BackColor = Color.FromArgb(243, 232, 255);
            pnlStat2Icon.Controls.Add(lblStat2Icon);
            pnlStat2Icon.Location = new Point(14, 20);
            pnlStat2Icon.Name = "pnlStat2Icon";
            pnlStat2Icon.Size = new Size(46, 46);
            pnlStat2Icon.TabIndex = 0;
            // 
            // lblStat2Icon
            // 
            lblStat2Icon.Dock = DockStyle.Fill;
            lblStat2Icon.Font = new Font("Segoe UI", 15F);
            lblStat2Icon.ForeColor = Color.FromArgb(147, 51, 234);
            lblStat2Icon.Location = new Point(0, 0);
            lblStat2Icon.Name = "lblStat2Icon";
            lblStat2Icon.Size = new Size(46, 46);
            lblStat2Icon.TabIndex = 0;
            lblStat2Icon.Text = "📅";
            lblStat2Icon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlStat1
            // 
            pnlStat1.BackColor = Color.White;
            pnlStat1.Controls.Add(lblStat1Value);
            pnlStat1.Controls.Add(lblStat1Title);
            pnlStat1.Controls.Add(pnlStat1Icon);
            pnlStat1.Dock = DockStyle.Fill;
            pnlStat1.Location = new Point(0, 5);
            pnlStat1.Margin = new Padding(0, 5, 7, 5);
            pnlStat1.Name = "pnlStat1";
            pnlStat1.Padding = new Padding(14);
            pnlStat1.Size = new Size(230, 86);
            pnlStat1.TabIndex = 0;
            // 
            // lblStat1Value
            // 
            lblStat1Value.AutoSize = true;
            lblStat1Value.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblStat1Value.ForeColor = Color.FromArgb(15, 23, 42);
            lblStat1Value.Location = new Point(70, 36);
            lblStat1Value.Name = "lblStat1Value";
            lblStat1Value.Size = new Size(49, 38);
            lblStat1Value.TabIndex = 2;
            lblStat1Value.Text = "30";
            // 
            // lblStat1Title
            // 
            lblStat1Title.AutoSize = true;
            lblStat1Title.Font = new Font("Segoe UI", 9F);
            lblStat1Title.ForeColor = Color.FromArgb(100, 116, 139);
            lblStat1Title.Location = new Point(72, 16);
            lblStat1Title.Name = "lblStat1Title";
            lblStat1Title.Size = new Size(84, 15);
            lblStat1Title.TabIndex = 1;
            lblStat1Title.Text = "Tổng tài khoản";
            // 
            // pnlStat1Icon
            // 
            pnlStat1Icon.BackColor = Color.FromArgb(239, 246, 255);
            pnlStat1Icon.Controls.Add(lblStat1Icon);
            pnlStat1Icon.Location = new Point(14, 20);
            pnlStat1Icon.Name = "pnlStat1Icon";
            pnlStat1Icon.Size = new Size(46, 46);
            pnlStat1Icon.TabIndex = 0;
            // 
            // lblStat1Icon
            // 
            lblStat1Icon.Dock = DockStyle.Fill;
            lblStat1Icon.Font = new Font("Segoe UI", 15F);
            lblStat1Icon.ForeColor = Color.FromArgb(37, 99, 235);
            lblStat1Icon.Location = new Point(0, 0);
            lblStat1Icon.Name = "lblStat1Icon";
            lblStat1Icon.Size = new Size(46, 46);
            lblStat1Icon.TabIndex = 0;
            lblStat1Icon.Text = "👥";
            lblStat1Icon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblBottom
            // 
            tblBottom.ColumnCount = 2;
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66F));
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tblBottom.Controls.Add(pnlTasksCard, 1, 0);
            tblBottom.Controls.Add(pnlEventsCard, 0, 0);
            tblBottom.Dock = DockStyle.Fill;
            tblBottom.Location = new Point(25, 176);
            tblBottom.Name = "tblBottom";
            tblBottom.RowCount = 1;
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblBottom.Size = new Size(950, 484);
            tblBottom.TabIndex = 2;
            // 
            // pnlTasksCard
            // 
            pnlTasksCard.BackColor = Color.White;
            pnlTasksCard.Controls.Add(pnlTaskItem3);
            pnlTasksCard.Controls.Add(pnlTaskItem2);
            pnlTasksCard.Controls.Add(pnlTaskItem1);
            pnlTasksCard.Controls.Add(lblTasksSub);
            pnlTasksCard.Controls.Add(lblTasksTitle);
            pnlTasksCard.Dock = DockStyle.Fill;
            pnlTasksCard.Location = new Point(634, 15);
            pnlTasksCard.Margin = new Padding(7, 15, 0, 10);
            pnlTasksCard.Name = "pnlTasksCard";
            pnlTasksCard.Padding = new Padding(20);
            pnlTasksCard.Size = new Size(316, 459);
            pnlTasksCard.TabIndex = 1;
            // 
            // pnlTaskItem3
            // 
            pnlTaskItem3.BackColor = Color.FromArgb(248, 250, 252);
            pnlTaskItem3.Controls.Add(lblTask3Badge);
            pnlTaskItem3.Controls.Add(lblTask3Sub);
            pnlTaskItem3.Controls.Add(lblTask3Title);
            pnlTaskItem3.Controls.Add(pnlTask3Icon);
            pnlTaskItem3.Cursor = Cursors.Hand;
            pnlTaskItem3.Dock = DockStyle.Top;
            pnlTaskItem3.Location = new Point(20, 218);
            pnlTaskItem3.Margin = new Padding(0, 0, 0, 10);
            pnlTaskItem3.Name = "pnlTaskItem3";
            pnlTaskItem3.Padding = new Padding(12);
            pnlTaskItem3.Size = new Size(276, 68);
            pnlTaskItem3.TabIndex = 4;
            // 
            // lblTask3Badge
            // 
            lblTask3Badge.Dock = DockStyle.Right;
            lblTask3Badge.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTask3Badge.ForeColor = Color.FromArgb(220, 38, 38);
            lblTask3Badge.Location = new Point(224, 12);
            lblTask3Badge.Name = "lblTask3Badge";
            lblTask3Badge.Size = new Size(40, 44);
            lblTask3Badge.TabIndex = 3;
            lblTask3Badge.Text = "3";
            lblTask3Badge.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTask3Sub
            // 
            lblTask3Sub.AutoSize = true;
            lblTask3Sub.Font = new Font("Segoe UI", 8.25F);
            lblTask3Sub.ForeColor = Color.FromArgb(148, 163, 184);
            lblTask3Sub.Location = new Point(62, 36);
            lblTask3Sub.Name = "lblTask3Sub";
            lblTask3Sub.Size = new Size(72, 13);
            lblTask3Sub.TabIndex = 2;
            lblTask3Sub.Text = "Bấm để xử lý";
            // 
            // lblTask3Title
            // 
            lblTask3Title.AutoSize = true;
            lblTask3Title.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            lblTask3Title.ForeColor = Color.FromArgb(15, 23, 42);
            lblTask3Title.Location = new Point(60, 16);
            lblTask3Title.Name = "lblTask3Title";
            lblTask3Title.Size = new Size(130, 17);
            lblTask3Title.TabIndex = 1;
            lblTask3Title.Text = "Yêu cầu đổi thông tin";
            // 
            // pnlTask3Icon
            // 
            pnlTask3Icon.BackColor = Color.FromArgb(243, 232, 255);
            pnlTask3Icon.Controls.Add(lblTask3Icon);
            pnlTask3Icon.Location = new Point(12, 14);
            pnlTask3Icon.Name = "pnlTask3Icon";
            pnlTask3Icon.Size = new Size(40, 40);
            pnlTask3Icon.TabIndex = 0;
            // 
            // lblTask3Icon
            // 
            lblTask3Icon.Dock = DockStyle.Fill;
            lblTask3Icon.Font = new Font("Segoe UI", 13F);
            lblTask3Icon.ForeColor = Color.FromArgb(147, 51, 234);
            lblTask3Icon.Location = new Point(0, 0);
            lblTask3Icon.Name = "lblTask3Icon";
            lblTask3Icon.Size = new Size(40, 40);
            lblTask3Icon.TabIndex = 0;
            lblTask3Icon.Text = "👤";
            lblTask3Icon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTaskItem2
            // 
            pnlTaskItem2.BackColor = Color.FromArgb(248, 250, 252);
            pnlTaskItem2.Controls.Add(lblTask2Badge);
            pnlTaskItem2.Controls.Add(lblTask2Sub);
            pnlTaskItem2.Controls.Add(lblTask2Title);
            pnlTaskItem2.Controls.Add(pnlTask2Icon);
            pnlTaskItem2.Cursor = Cursors.Hand;
            pnlTaskItem2.Dock = DockStyle.Top;
            pnlTaskItem2.Location = new Point(20, 140);
            pnlTaskItem2.Margin = new Padding(0, 0, 0, 10);
            pnlTaskItem2.Name = "pnlTaskItem2";
            pnlTaskItem2.Padding = new Padding(12);
            pnlTaskItem2.Size = new Size(276, 78);
            pnlTaskItem2.TabIndex = 3;
            // 
            // lblTask2Badge
            // 
            lblTask2Badge.Dock = DockStyle.Right;
            lblTask2Badge.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTask2Badge.ForeColor = Color.FromArgb(220, 38, 38);
            lblTask2Badge.Location = new Point(224, 12);
            lblTask2Badge.Name = "lblTask2Badge";
            lblTask2Badge.Size = new Size(40, 54);
            lblTask2Badge.TabIndex = 3;
            lblTask2Badge.Text = "26";
            lblTask2Badge.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTask2Sub
            // 
            lblTask2Sub.AutoSize = true;
            lblTask2Sub.Font = new Font("Segoe UI", 8.25F);
            lblTask2Sub.ForeColor = Color.FromArgb(148, 163, 184);
            lblTask2Sub.Location = new Point(62, 36);
            lblTask2Sub.Name = "lblTask2Sub";
            lblTask2Sub.Size = new Size(72, 13);
            lblTask2Sub.TabIndex = 2;
            lblTask2Sub.Text = "Bấm để xử lý";
            // 
            // lblTask2Title
            // 
            lblTask2Title.AutoSize = true;
            lblTask2Title.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            lblTask2Title.ForeColor = Color.FromArgb(15, 23, 42);
            lblTask2Title.Location = new Point(60, 16);
            lblTask2Title.Name = "lblTask2Title";
            lblTask2Title.Size = new Size(133, 17);
            lblTask2Title.TabIndex = 1;
            lblTask2Title.Text = "Thông báo chờ duyệt";
            // 
            // pnlTask2Icon
            // 
            pnlTask2Icon.BackColor = Color.FromArgb(239, 246, 255);
            pnlTask2Icon.Controls.Add(lblTask2Icon);
            pnlTask2Icon.Location = new Point(12, 14);
            pnlTask2Icon.Name = "pnlTask2Icon";
            pnlTask2Icon.Size = new Size(40, 40);
            pnlTask2Icon.TabIndex = 0;
            // 
            // lblTask2Icon
            // 
            lblTask2Icon.Dock = DockStyle.Fill;
            lblTask2Icon.Font = new Font("Segoe UI", 13F);
            lblTask2Icon.ForeColor = Color.FromArgb(37, 99, 235);
            lblTask2Icon.Location = new Point(0, 0);
            lblTask2Icon.Name = "lblTask2Icon";
            lblTask2Icon.Size = new Size(40, 40);
            lblTask2Icon.TabIndex = 0;
            lblTask2Icon.Text = "🔔";
            lblTask2Icon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTaskItem1
            // 
            pnlTaskItem1.BackColor = Color.FromArgb(248, 250, 252);
            pnlTaskItem1.Controls.Add(lblTask1Badge);
            pnlTaskItem1.Controls.Add(lblTask1Sub);
            pnlTaskItem1.Controls.Add(lblTask1Title);
            pnlTaskItem1.Controls.Add(pnlTask1Icon);
            pnlTaskItem1.Cursor = Cursors.Hand;
            pnlTaskItem1.Dock = DockStyle.Top;
            pnlTaskItem1.Location = new Point(20, 62);
            pnlTaskItem1.Margin = new Padding(0, 0, 0, 10);
            pnlTaskItem1.Name = "pnlTaskItem1";
            pnlTaskItem1.Padding = new Padding(12);
            pnlTaskItem1.Size = new Size(276, 78);
            pnlTaskItem1.TabIndex = 2;
            // 
            // lblTask1Badge
            // 
            lblTask1Badge.Dock = DockStyle.Right;
            lblTask1Badge.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTask1Badge.ForeColor = Color.FromArgb(220, 38, 38);
            lblTask1Badge.Location = new Point(224, 12);
            lblTask1Badge.Name = "lblTask1Badge";
            lblTask1Badge.Size = new Size(40, 54);
            lblTask1Badge.TabIndex = 3;
            lblTask1Badge.Text = "2";
            lblTask1Badge.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTask1Sub
            // 
            lblTask1Sub.AutoSize = true;
            lblTask1Sub.Font = new Font("Segoe UI", 8.25F);
            lblTask1Sub.ForeColor = Color.FromArgb(148, 163, 184);
            lblTask1Sub.Location = new Point(62, 36);
            lblTask1Sub.Name = "lblTask1Sub";
            lblTask1Sub.Size = new Size(72, 13);
            lblTask1Sub.TabIndex = 2;
            lblTask1Sub.Text = "Bấm để xử lý";
            // 
            // lblTask1Title
            // 
            lblTask1Title.AutoSize = true;
            lblTask1Title.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            lblTask1Title.ForeColor = Color.FromArgb(15, 23, 42);
            lblTask1Title.Location = new Point(60, 16);
            lblTask1Title.Name = "lblTask1Title";
            lblTask1Title.Size = new Size(160, 17);
            lblTask1Title.TabIndex = 1;
            lblTask1Title.Text = "Kế hoạch sự kiện chờ duyệt";
            // 
            // pnlTask1Icon
            // 
            pnlTask1Icon.BackColor = Color.FromArgb(254, 243, 199);
            pnlTask1Icon.Controls.Add(lblTask1Icon);
            pnlTask1Icon.Location = new Point(12, 14);
            pnlTask1Icon.Name = "pnlTask1Icon";
            pnlTask1Icon.Size = new Size(40, 40);
            pnlTask1Icon.TabIndex = 0;
            // 
            // lblTask1Icon
            // 
            lblTask1Icon.Dock = DockStyle.Fill;
            lblTask1Icon.Font = new Font("Segoe UI", 13F);
            lblTask1Icon.ForeColor = Color.FromArgb(217, 119, 6);
            lblTask1Icon.Location = new Point(0, 0);
            lblTask1Icon.Name = "lblTask1Icon";
            lblTask1Icon.Size = new Size(40, 40);
            lblTask1Icon.TabIndex = 0;
            lblTask1Icon.Text = "📄";
            lblTask1Icon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTasksSub
            // 
            lblTasksSub.AutoSize = true;
            lblTasksSub.Dock = DockStyle.Top;
            lblTasksSub.Font = new Font("Segoe UI", 8.5F);
            lblTasksSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblTasksSub.Location = new Point(20, 41);
            lblTasksSub.Name = "lblTasksSub";
            lblTasksSub.Padding = new Padding(0, 0, 0, 6);
            lblTasksSub.Size = new Size(149, 21);
            lblTasksSub.TabIndex = 1;
            lblTasksSub.Text = "31 việc đang chờ bạn xử lý";
            // 
            // lblTasksTitle
            // 
            lblTasksTitle.AutoSize = true;
            lblTasksTitle.Dock = DockStyle.Top;
            lblTasksTitle.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblTasksTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTasksTitle.Location = new Point(20, 20);
            lblTasksTitle.Name = "lblTasksTitle";
            lblTasksTitle.Padding = new Padding(0, 0, 0, 2);
            lblTasksTitle.Size = new Size(111, 21);
            lblTasksTitle.TabIndex = 0;
            lblTasksTitle.Text = "Việc cần xử lý";
            // 
            // pnlEventsCard
            // 
            pnlEventsCard.BackColor = Color.White;
            pnlEventsCard.Controls.Add(pnlEventsList);
            pnlEventsCard.Controls.Add(pnlEventsHeader);
            pnlEventsCard.Controls.Add(lblViewAll);
            pnlEventsCard.Controls.Add(lblEventsTitle);
            pnlEventsCard.Dock = DockStyle.Fill;
            pnlEventsCard.Location = new Point(0, 15);
            pnlEventsCard.Margin = new Padding(0, 15, 7, 10);
            pnlEventsCard.Name = "pnlEventsCard";
            pnlEventsCard.Padding = new Padding(20);
            pnlEventsCard.Size = new Size(620, 459);
            pnlEventsCard.TabIndex = 0;
            // 
            // pnlEventsList
            // 
            pnlEventsList.AutoScroll = true;
            pnlEventsList.Dock = DockStyle.Fill;
            pnlEventsList.Location = new Point(20, 75);
            pnlEventsList.Name = "pnlEventsList";
            pnlEventsList.Size = new Size(580, 364);
            pnlEventsList.TabIndex = 3;
            // 
            // pnlEventsHeader
            // 
            pnlEventsHeader.Controls.Add(lblColReg);
            pnlEventsHeader.Controls.Add(lblColStart);
            pnlEventsHeader.Controls.Add(lblColEvent);
            pnlEventsHeader.Dock = DockStyle.Top;
            pnlEventsHeader.Location = new Point(20, 45);
            pnlEventsHeader.Name = "pnlEventsHeader";
            pnlEventsHeader.Size = new Size(580, 30);
            pnlEventsHeader.TabIndex = 2;
            // 
            // lblColReg
            // 
            lblColReg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblColReg.AutoSize = true;
            lblColReg.Font = new Font("Segoe UI", 8.5F);
            lblColReg.ForeColor = Color.FromArgb(100, 116, 139);
            lblColReg.Location = new Point(460, 8);
            lblColReg.Name = "lblColReg";
            lblColReg.Size = new Size(50, 15);
            lblColReg.TabIndex = 2;
            lblColReg.Text = "Đăng ký";
            // 
            // lblColStart
            // 
            lblColStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblColStart.AutoSize = true;
            lblColStart.Font = new Font("Segoe UI", 8.5F);
            lblColStart.ForeColor = Color.FromArgb(100, 116, 139);
            lblColStart.Location = new Point(280, 8);
            lblColStart.Name = "lblColStart";
            lblColStart.Size = new Size(47, 15);
            lblColStart.TabIndex = 1;
            lblColStart.Text = "Bắt đầu";
            // 
            // lblColEvent
            // 
            lblColEvent.AutoSize = true;
            lblColEvent.Font = new Font("Segoe UI", 8.5F);
            lblColEvent.ForeColor = Color.FromArgb(100, 116, 139);
            lblColEvent.Location = new Point(6, 8);
            lblColEvent.Name = "lblColEvent";
            lblColEvent.Size = new Size(49, 15);
            lblColEvent.TabIndex = 0;
            lblColEvent.Text = "Sự kiện";
            // 
            // lblViewAll
            // 
            lblViewAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblViewAll.AutoSize = true;
            lblViewAll.Cursor = Cursors.Hand;
            lblViewAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblViewAll.ForeColor = Color.FromArgb(37, 99, 235);
            lblViewAll.Location = new Point(526, 22);
            lblViewAll.Name = "lblViewAll";
            lblViewAll.Size = new Size(74, 15);
            lblViewAll.TabIndex = 1;
            lblViewAll.Text = "Xem tất cả >";
            // 
            // lblEventsTitle
            // 
            lblEventsTitle.AutoSize = true;
            lblEventsTitle.Dock = DockStyle.Top;
            lblEventsTitle.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblEventsTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblEventsTitle.Location = new Point(20, 20);
            lblEventsTitle.Name = "lblEventsTitle";
            lblEventsTitle.Padding = new Padding(0, 0, 0, 6);
            lblEventsTitle.Size = new Size(157, 25);
            lblEventsTitle.TabIndex = 0;
            lblEventsTitle.Text = "Sự kiện sắp diễn ra";
            // 
            // ucCanBoHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(tblBottom);
            Controls.Add(tblStats);
            Controls.Add(pnlHeader);
            Name = "ucCanBoHome";
            Padding = new Padding(25, 20, 25, 15);
            Size = new Size(1000, 675);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tblStats.ResumeLayout(false);
            pnlStat4.ResumeLayout(false);
            pnlStat4.PerformLayout();
            pnlStat4Icon.ResumeLayout(false);
            pnlStat3.ResumeLayout(false);
            pnlStat3.PerformLayout();
            pnlStat3Icon.ResumeLayout(false);
            pnlStat2.ResumeLayout(false);
            pnlStat2.PerformLayout();
            pnlStat2Icon.ResumeLayout(false);
            pnlStat1.ResumeLayout(false);
            pnlStat1.PerformLayout();
            pnlStat1Icon.ResumeLayout(false);
            tblBottom.ResumeLayout(false);
            pnlTasksCard.ResumeLayout(false);
            pnlTasksCard.PerformLayout();
            pnlTaskItem3.ResumeLayout(false);
            pnlTaskItem3.PerformLayout();
            pnlTask3Icon.ResumeLayout(false);
            pnlTaskItem2.ResumeLayout(false);
            pnlTaskItem2.PerformLayout();
            pnlTask2Icon.ResumeLayout(false);
            pnlTaskItem1.ResumeLayout(false);
            pnlTaskItem1.PerformLayout();
            pnlTask1Icon.ResumeLayout(false);
            pnlEventsCard.ResumeLayout(false);
            pnlEventsCard.PerformLayout();
            pnlEventsHeader.ResumeLayout(false);
            pnlEventsHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblOverviewTitle;
        private Label lblOverviewSub;
        private TableLayoutPanel tblStats;
        private Panel pnlStat1;
        private Panel pnlStat1Icon;
        private Label lblStat1Icon;
        private Label lblStat1Title;
        private Label lblStat1Value;
        private Panel pnlStat2;
        private Label lblStat2Value;
        private Label lblStat2Title;
        private Panel pnlStat2Icon;
        private Label lblStat2Icon;
        private Panel pnlStat3;
        private Label lblStat3Value;
        private Label lblStat3Title;
        private Panel pnlStat3Icon;
        private Label lblStat3Icon;
        private Panel pnlStat4;
        private Label lblStat4Value;
        private Label lblStat4Title;
        private Panel pnlStat4Icon;
        private Label lblStat4Icon;
        private TableLayoutPanel tblBottom;
        private Panel pnlEventsCard;
        private Label lblEventsTitle;
        private Label lblViewAll;
        private Panel pnlEventsHeader;
        private Label lblColEvent;
        private Label lblColStart;
        private Label lblColReg;
        private Panel pnlEventsList;
        private Panel pnlTasksCard;
        private Label lblTasksTitle;
        private Label lblTasksSub;
        private Panel pnlTaskItem1;
        private Panel pnlTask1Icon;
        private Label lblTask1Icon;
        private Label lblTask1Title;
        private Label lblTask1Sub;
        private Label lblTask1Badge;
        private Panel pnlTaskItem2;
        private Panel pnlTask2Icon;
        private Label lblTask2Icon;
        private Label lblTask2Title;
        private Label lblTask2Sub;
        private Label lblTask2Badge;
        private Panel pnlTaskItem3;
        private Panel pnlTask3Icon;
        private Label lblTask3Icon;
        private Label lblTask3Title;
        private Label lblTask3Sub;
        private Label lblTask3Badge;
    }
}
