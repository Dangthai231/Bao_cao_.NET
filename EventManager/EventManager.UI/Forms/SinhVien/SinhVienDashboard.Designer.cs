namespace EventManager.UI.Forms.SinhVien
{
    partial class SinhVienDashboard
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
            btnProfile = new Button();
            btnFeedback = new Button();
            btnMyRegistrations = new Button();
            btnEvents = new Button();
            pnlContent = new Panel();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            //
            // pnlSidebar
            //
            pnlSidebar.BackColor = SystemColors.ActiveCaption;
            pnlSidebar.Controls.Add(lblWelcome);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnProfile);
            pnlSidebar.Controls.Add(btnFeedback);
            pnlSidebar.Controls.Add(btnMyRegistrations);
            pnlSidebar.Controls.Add(btnEvents);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(180, 450);
            pnlSidebar.TabIndex = 0;
            //
            // lblWelcome
            //
            lblWelcome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWelcome.Location = new Point(3, 8);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(174, 45);
            lblWelcome.TabIndex = 5;
            lblWelcome.Text = "Xin chào";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnLogout
            //
            btnLogout.Location = new Point(10, 415);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(160, 28);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            //
            // btnProfile
            //
            btnProfile.Location = new Point(3, 167);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(174, 32);
            btnProfile.TabIndex = 3;
            btnProfile.Text = "Thông tin cá nhân";
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Click += btnProfile_Click;
            //
            // btnFeedback
            //
            btnFeedback.Location = new Point(3, 130);
            btnFeedback.Name = "btnFeedback";
            btnFeedback.Size = new Size(174, 32);
            btnFeedback.TabIndex = 2;
            btnFeedback.Text = "Đánh giá và phản hồi";
            btnFeedback.UseVisualStyleBackColor = false;
            btnFeedback.Click += btnFeedback_Click;
            //
            // btnMyRegistrations
            //
            btnMyRegistrations.Location = new Point(3, 93);
            btnMyRegistrations.Name = "btnMyRegistrations";
            btnMyRegistrations.Size = new Size(174, 32);
            btnMyRegistrations.TabIndex = 1;
            btnMyRegistrations.Text = "Sự kiện đã đăng ký";
            btnMyRegistrations.UseVisualStyleBackColor = false;
            btnMyRegistrations.Click += btnMyRegistrations_Click;
            //
            // btnEvents
            //
            btnEvents.Location = new Point(3, 56);
            btnEvents.Name = "btnEvents";
            btnEvents.Size = new Size(174, 32);
            btnEvents.TabIndex = 0;
            btnEvents.Text = "Tra cứu sự kiện";
            btnEvents.UseVisualStyleBackColor = false;
            btnEvents.Click += btnEvents_Click;
            //
            // pnlContent
            //
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(180, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(620, 450);
            pnlContent.TabIndex = 1;
            //
            // SinhVienDashboard
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Name = "SinhVienDashboard";
            Text = "Sinh viên - Hệ thống quản lý sự kiện LCĐ CNTT";
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnFeedback;
        private System.Windows.Forms.Button btnMyRegistrations;
        private System.Windows.Forms.Button btnEvents;
        private System.Windows.Forms.Panel pnlContent;
    }
}
