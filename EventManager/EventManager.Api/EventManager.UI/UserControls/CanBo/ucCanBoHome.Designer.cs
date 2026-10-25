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
            pnlTop = new Panel();
            lblHeader = new Label();
            pnlBottom = new Panel();
            pnlBanner = new Panel();
            lblBannerText = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel6 = new Panel();
            label11 = new Label();
            lblCompletedReports = new Label();
            panel5 = new Panel();
            label9 = new Label();
            lblSentNotifications = new Label();
            panel4 = new Panel();
            label7 = new Label();
            lblEventDocuments = new Label();
            panel3 = new Panel();
            label5 = new Label();
            lblTotalParticipants = new Label();
            panel2 = new Panel();
            label3 = new Label();
            lblPendingTasks = new Label();
            panel1 = new Panel();
            label2 = new Label();
            lblActiveEvents = new Label();
            pnlTop.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlBanner.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(lblHeader);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(950, 75);
            pnlTop.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(17, 24, 39);
            lblHeader.Location = new Point(25, 20);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(292, 38);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Tổng quan sự kiện";
            // 
            // pnlBottom
            // 
            pnlBottom.Controls.Add(pnlBanner);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 525);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(25, 8, 25, 18);
            pnlBottom.Size = new Size(950, 75);
            pnlBottom.TabIndex = 2;
            // 
            // pnlBanner
            // 
            pnlBanner.BackColor = Color.White;
            pnlBanner.Controls.Add(lblBannerText);
            pnlBanner.Dock = DockStyle.Fill;
            pnlBanner.Location = new Point(25, 8);
            pnlBanner.Name = "pnlBanner";
            pnlBanner.Size = new Size(900, 49);
            pnlBanner.TabIndex = 0;
            // 
            // lblBannerText
            // 
            lblBannerText.AutoSize = true;
            lblBannerText.Font = new Font("Segoe UI", 10F);
            lblBannerText.ForeColor = Color.FromArgb(55, 65, 81);
            lblBannerText.Location = new Point(18, 14);
            lblBannerText.Name = "lblBannerText";
            lblBannerText.Size = new Size(543, 19);
            lblBannerText.TabIndex = 0;
            lblBannerText.Text = "Chào mừng đến với hệ thống quản lý sự kiện!";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.Controls.Add(panel6, 2, 1);
            tableLayoutPanel1.Controls.Add(panel5, 1, 1);
            tableLayoutPanel1.Controls.Add(panel4, 0, 1);
            tableLayoutPanel1.Controls.Add(panel3, 2, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 75);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(15, 0, 15, 5);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(950, 450);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(label11);
            panel6.Controls.Add(lblCompletedReports);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(638, 235);
            panel6.Margin = new Padding(10);
            panel6.Name = "panel6";
            panel6.Size = new Size(287, 205);
            panel6.TabIndex = 5;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F);
            label11.ForeColor = Color.FromArgb(100, 116, 139);
            label11.Location = new Point(22, 158);
            label11.Name = "label11";
            label11.Size = new Size(130, 19);
            label11.TabIndex = 1;
            label11.Text = "Báo cáo hoàn thành";
            // 
            // lblCompletedReports
            // 
            lblCompletedReports.AutoSize = true;
            lblCompletedReports.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblCompletedReports.ForeColor = Color.FromArgb(2, 132, 199);
            lblCompletedReports.Location = new Point(20, 35);
            lblCompletedReports.Name = "lblCompletedReports";
            lblCompletedReports.Size = new Size(49, 59);
            lblCompletedReports.TabIndex = 0;
            lblCompletedReports.Text = "7";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label9);
            panel5.Controls.Add(lblSentNotifications);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(331, 235);
            panel5.Margin = new Padding(10);
            panel5.Name = "panel5";
            panel5.Size = new Size(287, 205);
            panel5.TabIndex = 4;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.ForeColor = Color.FromArgb(100, 116, 139);
            label9.Location = new Point(22, 158);
            label9.Name = "label9";
            label9.Size = new Size(116, 19);
            label9.TabIndex = 1;
            label9.Text = "Thông báo đã gửi";
            // 
            // lblSentNotifications
            // 
            lblSentNotifications.AutoSize = true;
            lblSentNotifications.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblSentNotifications.ForeColor = Color.FromArgb(225, 29, 72);
            lblSentNotifications.Location = new Point(20, 35);
            lblSentNotifications.Name = "lblSentNotifications";
            lblSentNotifications.Size = new Size(73, 59);
            lblSentNotifications.TabIndex = 0;
            lblSentNotifications.Text = "18";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(label7);
            panel4.Controls.Add(lblEventDocuments);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(25, 235);
            panel4.Margin = new Padding(10);
            panel4.Name = "panel4";
            panel4.Size = new Size(286, 205);
            panel4.TabIndex = 3;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.ForeColor = Color.FromArgb(100, 116, 139);
            label7.Location = new Point(22, 158);
            label7.Name = "label7";
            label7.Size = new Size(99, 19);
            label7.TabIndex = 1;
            label7.Text = "Tài liệu sự kiện";
            // 
            // lblEventDocuments
            // 
            lblEventDocuments.AutoSize = true;
            lblEventDocuments.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblEventDocuments.ForeColor = Color.FromArgb(124, 58, 237);
            lblEventDocuments.Location = new Point(20, 35);
            lblEventDocuments.Name = "lblEventDocuments";
            lblEventDocuments.Size = new Size(73, 59);
            lblEventDocuments.TabIndex = 0;
            lblEventDocuments.Text = "36";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label5);
            panel3.Controls.Add(lblTotalParticipants);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(638, 10);
            panel3.Margin = new Padding(10);
            panel3.Name = "panel3";
            panel3.Size = new Size(287, 205);
            panel3.TabIndex = 2;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.FromArgb(100, 116, 139);
            label5.Location = new Point(22, 158);
            label5.Name = "label5";
            label5.Size = new Size(104, 19);
            label5.TabIndex = 1;
            label5.Text = "Người tham gia";
            // 
            // lblTotalParticipants
            // 
            lblTotalParticipants.AutoSize = true;
            lblTotalParticipants.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTotalParticipants.ForeColor = Color.FromArgb(234, 88, 12);
            lblTotalParticipants.Location = new Point(20, 35);
            lblTotalParticipants.Name = "lblTotalParticipants";
            lblTotalParticipants.Size = new Size(97, 59);
            lblTotalParticipants.TabIndex = 0;
            lblTotalParticipants.Text = "248";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblPendingTasks);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(331, 10);
            panel2.Margin = new Padding(10);
            panel2.Name = "panel2";
            panel2.Size = new Size(287, 205);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(100, 116, 139);
            label3.Location = new Point(22, 158);
            label3.Name = "label3";
            label3.Size = new Size(135, 19);
            label3.TabIndex = 1;
            label3.Text = "Sự kiện đã hoàn thành";
            // 
            // lblPendingTasks
            // 
            lblPendingTasks.AutoSize = true;
            lblPendingTasks.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblPendingTasks.ForeColor = Color.FromArgb(5, 150, 105);
            lblPendingTasks.Location = new Point(20, 35);
            lblPendingTasks.Name = "lblPendingTasks";
            lblPendingTasks.Size = new Size(73, 59);
            lblPendingTasks.TabIndex = 0;
            lblPendingTasks.Text = "12";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblActiveEvents);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(25, 10);
            panel1.Margin = new Padding(10);
            panel1.Name = "panel1";
            panel1.Size = new Size(286, 205);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.FromArgb(100, 116, 139);
            label2.Location = new Point(22, 158);
            label2.Name = "label2";
            label2.Size = new Size(136, 19);
            label2.TabIndex = 1;
            label2.Text = "Sự kiện đang tổ chức";
            // 
            // lblActiveEvents
            // 
            lblActiveEvents.AutoSize = true;
            lblActiveEvents.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblActiveEvents.ForeColor = Color.FromArgb(37, 99, 235);
            lblActiveEvents.Location = new Point(20, 35);
            lblActiveEvents.Name = "lblActiveEvents";
            lblActiveEvents.Size = new Size(49, 59);
            lblActiveEvents.TabIndex = 0;
            lblActiveEvents.Text = "3";
            // 
            // ucCanBoHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
            Name = "ucCanBoHome";
            Size = new Size(950, 600);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlBanner.ResumeLayout(false);
            pnlBanner.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblHeader;
        private Panel pnlBottom;
        private Panel pnlBanner;
        private Label lblBannerText;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label lblActiveEvents;
        private Label label2;
        private Panel panel2;
        private Label lblPendingTasks;
        private Label label3;
        private Panel panel3;
        private Label lblTotalParticipants;
        private Label label5;
        private Panel panel4;
        private Label lblEventDocuments;
        private Label label7;
        private Panel panel5;
        private Label lblSentNotifications;
        private Label label9;
        private Panel panel6;
        private Label lblCompletedReports;
        private Label label11;
    }
}