namespace EventManager.UI.Forms.Canbo
{
    partial class CanBoDashboard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            lblWelcome = new Label();
            btnLogout = new Button();
            btnNotifications = new Button();
            btnParticipants = new Button();
            btnDocuments = new Button();
            btnReports = new Button();
            btnHome = new Button();
            pnlContent = new Panel();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = SystemColors.ActiveCaption;
            pnlSidebar.Controls.Add(lblWelcome);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnNotifications);
            pnlSidebar.Controls.Add(btnParticipants);
            pnlSidebar.Controls.Add(btnDocuments);
            pnlSidebar.Controls.Add(btnReports);
            pnlSidebar.Controls.Add(btnHome);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(164, 450);
            pnlSidebar.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWelcome.Location = new Point(3, 8);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(158, 35);
            lblWelcome.TabIndex = 7;
            lblWelcome.Text = "Xin chào";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(13, 420);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(148, 23);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnNotifications
            // 
            btnNotifications.Location = new Point(3, 164);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(158, 23);
            btnNotifications.TabIndex = 5;
            btnNotifications.Text = "Quản lý thông báo";
            btnNotifications.UseVisualStyleBackColor = true;
            btnNotifications.Click += btnNotifications_Click;
            // 
            // btnParticipants
            // 
            btnParticipants.Location = new Point(3, 135);
            btnParticipants.Name = "btnParticipants";
            btnParticipants.Size = new Size(158, 23);
            btnParticipants.TabIndex = 4;
            btnParticipants.Text = "Quản lý người tham gia";
            btnParticipants.UseVisualStyleBackColor = true;
            btnParticipants.Click += btnParticipants_Click;
            // 
            // btnDocuments
            // 
            btnDocuments.Location = new Point(3, 106);
            btnDocuments.Name = "btnDocuments";
            btnDocuments.Size = new Size(158, 23);
            btnDocuments.TabIndex = 2;
            btnDocuments.Text = "Quản lý tài liệu sự kiện";
            btnDocuments.UseVisualStyleBackColor = true;
            btnDocuments.Click += btnDocuments_Click;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(3, 77);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(158, 23);
            btnReports.TabIndex = 1;
            btnReports.Text = "Lập báo cáo và thống kê";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += button2_Click;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(3, 48);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(158, 23);
            btnHome.TabIndex = 0;
            btnHome.Text = "Trang chủ";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(164, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(636, 450);
            pnlContent.TabIndex = 1;
            // 
            // CanBoDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Name = "CanBoDashboard";
            Text = "Cán Bộ - Quản lý sự kiện";
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnNotifications;
        private System.Windows.Forms.Button btnParticipants;
        private System.Windows.Forms.Button btnDocuments;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel pnlContent;
    }
}
