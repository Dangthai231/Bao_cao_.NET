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
            pnlSidebarMenu = new Panel();
            btnNotifications = new Button();
            sp5 = new Panel();
            btnParticipants = new Button();
            spTask = new Panel();
            btnTasks = new Button();
            sp4 = new Panel();
            btnDocuments = new Button();
            sp3 = new Panel();
            btnReports = new Button();
            sp2 = new Panel();
            btnHome = new Button();
            pnlSidebarFooter = new Panel();
            lblFooterSlogan = new Label();
            lblFooterBrand = new Label();
            lblFooterIcon = new Label();
            btnLogout = new Button();
            pnlSidebarBrand = new Panel();
            lblBrandSubtitle = new Label();
            lblBrandTitle = new Label();
            lblBrandIcon = new Label();
            pnlMain = new Panel();
            pnlContent = new Panel();
            pnlTopNav = new Panel();
            pnlTopNavRight = new Panel();
            lblDropdownArrow = new Label();
            lblUsername = new Label();
            pnlAvatar = new Panel();
            lblAvatarLetter = new Label();
            pnlNotificationBadge = new Panel();
            lblBadgeCount = new Label();
            lblBellIcon = new Label();
            pnlSearchBox = new Panel();
            txtSearch = new TextBox();
            lblSearchIcon = new Label();
            btnHamburger = new Button();
            pnlSidebar.SuspendLayout();
            pnlSidebarMenu.SuspendLayout();
            pnlSidebarFooter.SuspendLayout();
            pnlSidebarBrand.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlTopNav.SuspendLayout();
            pnlTopNavRight.SuspendLayout();
            pnlAvatar.SuspendLayout();
            pnlNotificationBadge.SuspendLayout();
            pnlSearchBox.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(11, 27, 61);
            pnlSidebar.Controls.Add(pnlSidebarMenu);
            pnlSidebar.Controls.Add(pnlSidebarFooter);
            pnlSidebar.Controls.Add(pnlSidebarBrand);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(230, 720);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlSidebarMenu
            // 
            pnlSidebarMenu.AutoScroll = true;
            pnlSidebarMenu.Controls.Add(btnNotifications);
            pnlSidebarMenu.Controls.Add(sp5);
            pnlSidebarMenu.Controls.Add(btnParticipants);
            pnlSidebarMenu.Controls.Add(spTask);
            pnlSidebarMenu.Controls.Add(btnTasks);
            pnlSidebarMenu.Controls.Add(sp4);
            pnlSidebarMenu.Controls.Add(btnDocuments);
            pnlSidebarMenu.Controls.Add(sp3);
            pnlSidebarMenu.Controls.Add(btnReports);
            pnlSidebarMenu.Controls.Add(sp2);
            pnlSidebarMenu.Controls.Add(btnHome);
            pnlSidebarMenu.Dock = DockStyle.Fill;
            pnlSidebarMenu.Location = new Point(0, 80);
            pnlSidebarMenu.Name = "pnlSidebarMenu";
            pnlSidebarMenu.Padding = new Padding(12, 8, 12, 8);
            pnlSidebarMenu.Size = new Size(230, 520);
            pnlSidebarMenu.TabIndex = 1;
            // 
            // btnNotifications
            // 
            btnNotifications.BackColor = Color.FromArgb(11, 27, 61);
            btnNotifications.Cursor = Cursors.Hand;
            btnNotifications.Dock = DockStyle.Top;
            btnNotifications.FlatAppearance.BorderSize = 0;
            btnNotifications.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 42, 85);
            btnNotifications.FlatStyle = FlatStyle.Flat;
            btnNotifications.Font = new Font("Segoe UI", 9.25F);
            btnNotifications.ForeColor = Color.FromArgb(203, 213, 225);
            btnNotifications.Location = new Point(12, 196);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Padding = new Padding(10, 0, 0, 0);
            btnNotifications.Size = new Size(206, 42);
            btnNotifications.TabIndex = 8;
            btnNotifications.Text = "   🔔  Quản lý thông báo";
            btnNotifications.TextAlign = ContentAlignment.MiddleLeft;
            btnNotifications.UseVisualStyleBackColor = false;
            btnNotifications.Click += btnNotifications_Click;
            // 
            // sp5
            // 
            sp5.Dock = DockStyle.Top;
            sp5.Location = new Point(12, 190);
            sp5.Name = "sp5";
            sp5.Size = new Size(206, 6);
            sp5.TabIndex = 7;
            // 
            // btnParticipants
            // 
            btnParticipants.BackColor = Color.FromArgb(11, 27, 61);
            btnParticipants.Cursor = Cursors.Hand;
            btnParticipants.Dock = DockStyle.Top;
            btnParticipants.FlatAppearance.BorderSize = 0;
            btnParticipants.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 42, 85);
            btnParticipants.FlatStyle = FlatStyle.Flat;
            btnParticipants.Font = new Font("Segoe UI", 9.25F);
            btnParticipants.ForeColor = Color.FromArgb(203, 213, 225);
            btnParticipants.Location = new Point(12, 148);
            btnParticipants.Name = "btnParticipants";
            btnParticipants.Padding = new Padding(10, 0, 0, 0);
            btnParticipants.Size = new Size(206, 42);
            btnParticipants.TabIndex = 6;
            btnParticipants.Text = "   👥  Quản lý người tham gia";
            btnParticipants.TextAlign = ContentAlignment.MiddleLeft;
            btnParticipants.UseVisualStyleBackColor = false;
            btnParticipants.Click += btnParticipants_Click;
            // 
            // spTask
            // 
            spTask.Dock = DockStyle.Top;
            spTask.Location = new Point(12, 142);
            spTask.Name = "spTask";
            spTask.Size = new Size(206, 6);
            spTask.TabIndex = 5;
            // 
            // btnTasks
            // 
            btnTasks.BackColor = Color.FromArgb(11, 27, 61);
            btnTasks.Cursor = Cursors.Hand;
            btnTasks.Dock = DockStyle.Top;
            btnTasks.FlatAppearance.BorderSize = 0;
            btnTasks.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 42, 85);
            btnTasks.FlatStyle = FlatStyle.Flat;
            btnTasks.Font = new Font("Segoe UI", 9.25F);
            btnTasks.ForeColor = Color.FromArgb(203, 213, 225);
            btnTasks.Location = new Point(12, 100);
            btnTasks.Name = "btnTasks";
            btnTasks.Padding = new Padding(10, 0, 0, 0);
            btnTasks.Size = new Size(206, 42);
            btnTasks.TabIndex = 4;
            btnTasks.Text = "   📋  Quản lý công việc";
            btnTasks.TextAlign = ContentAlignment.MiddleLeft;
            btnTasks.UseVisualStyleBackColor = false;
            btnTasks.Click += btnTasks_Click;
            // 
            // sp4
            // 
            sp4.Dock = DockStyle.Top;
            sp4.Location = new Point(12, 94);
            sp4.Name = "sp4";
            sp4.Size = new Size(206, 6);
            sp4.TabIndex = 3;
            // 
            // btnDocuments
            // 
            btnDocuments.BackColor = Color.FromArgb(11, 27, 61);
            btnDocuments.Cursor = Cursors.Hand;
            btnDocuments.Dock = DockStyle.Top;
            btnDocuments.FlatAppearance.BorderSize = 0;
            btnDocuments.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 42, 85);
            btnDocuments.FlatStyle = FlatStyle.Flat;
            btnDocuments.Font = new Font("Segoe UI", 9.25F);
            btnDocuments.ForeColor = Color.FromArgb(203, 213, 225);
            btnDocuments.Location = new Point(12, 100);
            btnDocuments.Name = "btnDocuments";
            btnDocuments.Padding = new Padding(10, 0, 0, 0);
            btnDocuments.Size = new Size(206, 42);
            btnDocuments.TabIndex = 4;
            btnDocuments.Text = "   📄  Quản lý tài liệu sự kiện";
            btnDocuments.TextAlign = ContentAlignment.MiddleLeft;
            btnDocuments.UseVisualStyleBackColor = false;
            btnDocuments.Click += btnDocuments_Click;
            // 
            // sp3
            // 
            sp3.Dock = DockStyle.Top;
            sp3.Location = new Point(12, 94);
            sp3.Name = "sp3";
            sp3.Size = new Size(206, 6);
            sp3.TabIndex = 3;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.FromArgb(11, 27, 61);
            btnReports.Cursor = Cursors.Hand;
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 42, 85);
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 9.25F);
            btnReports.ForeColor = Color.FromArgb(203, 213, 225);
            btnReports.Location = new Point(12, 52);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(10, 0, 0, 0);
            btnReports.Size = new Size(206, 42);
            btnReports.TabIndex = 2;
            btnReports.Text = "   📊  Lập báo cáo và thống kê";
            btnReports.TextAlign = ContentAlignment.MiddleLeft;
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += button2_Click;
            // 
            // sp2
            // 
            sp2.Dock = DockStyle.Top;
            sp2.Location = new Point(12, 46);
            sp2.Name = "sp2";
            sp2.Size = new Size(206, 6);
            sp2.TabIndex = 1;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(37, 99, 235);
            btnHome.Cursor = Cursors.Hand;
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(12, 8);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(10, 0, 0, 0);
            btnHome.Size = new Size(206, 42);
            btnHome.TabIndex = 0;
            btnHome.Text = "   🏠  Trang chủ";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // pnlSidebarFooter
            // 
            pnlSidebarFooter.Controls.Add(lblFooterSlogan);
            pnlSidebarFooter.Controls.Add(lblFooterBrand);
            pnlSidebarFooter.Controls.Add(lblFooterIcon);
            pnlSidebarFooter.Controls.Add(btnLogout);
            pnlSidebarFooter.Dock = DockStyle.Bottom;
            pnlSidebarFooter.Location = new Point(0, 600);
            pnlSidebarFooter.Name = "pnlSidebarFooter";
            pnlSidebarFooter.Padding = new Padding(12, 5, 12, 12);
            pnlSidebarFooter.Size = new Size(230, 120);
            pnlSidebarFooter.TabIndex = 2;
            // 
            // lblFooterSlogan
            // 
            lblFooterSlogan.AutoSize = true;
            lblFooterSlogan.Font = new Font("Segoe UI", 7.25F);
            lblFooterSlogan.ForeColor = Color.FromArgb(148, 163, 184);
            lblFooterSlogan.Location = new Point(40, 93);
            lblFooterSlogan.Name = "lblFooterSlogan";
            lblFooterSlogan.Size = new Size(160, 12);
            lblFooterSlogan.TabIndex = 3;
            lblFooterSlogan.Text = "Kết nối tri thức - Kiến tạo tương lai";
            // 
            // lblFooterBrand
            // 
            lblFooterBrand.AutoSize = true;
            lblFooterBrand.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblFooterBrand.ForeColor = Color.White;
            lblFooterBrand.Location = new Point(40, 77);
            lblFooterBrand.Name = "lblFooterBrand";
            lblFooterBrand.Size = new Size(88, 13);
            lblFooterBrand.TabIndex = 2;
            lblFooterBrand.Text = "Đại học Điện lực";
            // 
            // lblFooterIcon
            // 
            lblFooterIcon.Font = new Font("Segoe UI", 16F);
            lblFooterIcon.ForeColor = Color.FromArgb(59, 130, 246);
            lblFooterIcon.Location = new Point(8, 73);
            lblFooterIcon.Name = "lblFooterIcon";
            lblFooterIcon.Size = new Size(30, 32);
            lblFooterIcon.TabIndex = 1;
            lblFooterIcon.Text = "🎓";
            lblFooterIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(11, 27, 61);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Top;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 42, 85);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9.25F);
            btnLogout.ForeColor = Color.FromArgb(203, 213, 225);
            btnLogout.Location = new Point(12, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(10, 0, 0, 0);
            btnLogout.Size = new Size(206, 42);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "   🚪  Đăng xuất";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlSidebarBrand
            // 
            pnlSidebarBrand.Controls.Add(lblBrandSubtitle);
            pnlSidebarBrand.Controls.Add(lblBrandTitle);
            pnlSidebarBrand.Controls.Add(lblBrandIcon);
            pnlSidebarBrand.Dock = DockStyle.Top;
            pnlSidebarBrand.Location = new Point(0, 0);
            pnlSidebarBrand.Name = "pnlSidebarBrand";
            pnlSidebarBrand.Size = new Size(230, 80);
            pnlSidebarBrand.TabIndex = 0;
            // 
            // lblBrandSubtitle
            // 
            lblBrandSubtitle.AutoSize = true;
            lblBrandSubtitle.Font = new Font("Segoe UI", 7.75F);
            lblBrandSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
            lblBrandSubtitle.Location = new Point(48, 43);
            lblBrandSubtitle.Name = "lblBrandSubtitle";
            lblBrandSubtitle.Size = new Size(137, 13);
            lblBrandSubtitle.TabIndex = 2;
            lblBrandSubtitle.Text = "BCH LCĐ CNS - ĐH Điện lực";
            // 
            // lblBrandTitle
            // 
            lblBrandTitle.AutoSize = true;
            lblBrandTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblBrandTitle.ForeColor = Color.White;
            lblBrandTitle.Location = new Point(48, 24);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new Size(157, 15);
            lblBrandTitle.TabIndex = 1;
            lblBrandTitle.Text = "HỆ THỐNG QUẢN LÝ SỰ KIỆN";
            // 
            // lblBrandIcon
            // 
            lblBrandIcon.Font = new Font("Segoe UI", 18F);
            lblBrandIcon.ForeColor = Color.White;
            lblBrandIcon.Location = new Point(8, 18);
            lblBrandIcon.Name = "lblBrandIcon";
            lblBrandIcon.Size = new Size(38, 40);
            lblBrandIcon.TabIndex = 0;
            lblBrandIcon.Text = "🎓";
            lblBrandIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(pnlContent);
            pnlMain.Controls.Add(pnlTopNav);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(230, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(994, 720);
            pnlMain.TabIndex = 1;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(248, 250, 252);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 56);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(994, 664);
            pnlContent.TabIndex = 1;
            // 
            // pnlTopNav
            // 
            pnlTopNav.BackColor = Color.White;
            pnlTopNav.Controls.Add(pnlTopNavRight);
            pnlTopNav.Controls.Add(btnHamburger);
            pnlTopNav.Dock = DockStyle.Top;
            pnlTopNav.Location = new Point(0, 0);
            pnlTopNav.Name = "pnlTopNav";
            pnlTopNav.Size = new Size(994, 56);
            pnlTopNav.TabIndex = 0;
            // 
            // pnlTopNavRight
            // 
            pnlTopNavRight.Controls.Add(lblDropdownArrow);
            pnlTopNavRight.Controls.Add(lblUsername);
            pnlTopNavRight.Controls.Add(pnlAvatar);
            pnlTopNavRight.Controls.Add(pnlNotificationBadge);
            pnlTopNavRight.Controls.Add(pnlSearchBox);
            pnlTopNavRight.Dock = DockStyle.Right;
            pnlTopNavRight.Location = new Point(484, 0);
            pnlTopNavRight.Name = "pnlTopNavRight";
            pnlTopNavRight.Size = new Size(510, 56);
            pnlTopNavRight.TabIndex = 1;
            // 
            // lblDropdownArrow
            // 
            lblDropdownArrow.AutoSize = true;
            lblDropdownArrow.Cursor = Cursors.Hand;
            lblDropdownArrow.Font = new Font("Segoe UI", 9F);
            lblDropdownArrow.ForeColor = Color.FromArgb(100, 116, 139);
            lblDropdownArrow.Location = new Point(486, 21);
            lblDropdownArrow.Name = "lblDropdownArrow";
            lblDropdownArrow.Size = new Size(13, 15);
            lblDropdownArrow.TabIndex = 4;
            lblDropdownArrow.Text = "˅";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Cursor = Cursors.Hand;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(15, 23, 42);
            lblUsername.Location = new Point(430, 21);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(52, 15);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "canbo01";
            // 
            // pnlAvatar
            // 
            pnlAvatar.BackColor = Color.FromArgb(11, 27, 61);
            pnlAvatar.Controls.Add(lblAvatarLetter);
            pnlAvatar.Cursor = Cursors.Hand;
            pnlAvatar.Location = new Point(390, 12);
            pnlAvatar.Name = "pnlAvatar";
            pnlAvatar.Size = new Size(32, 32);
            pnlAvatar.TabIndex = 2;
            // 
            // lblAvatarLetter
            // 
            lblAvatarLetter.Dock = DockStyle.Fill;
            lblAvatarLetter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAvatarLetter.ForeColor = Color.White;
            lblAvatarLetter.Location = new Point(0, 0);
            lblAvatarLetter.Name = "lblAvatarLetter";
            lblAvatarLetter.Size = new Size(32, 32);
            lblAvatarLetter.TabIndex = 0;
            lblAvatarLetter.Text = "C";
            lblAvatarLetter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlNotificationBadge
            // 
            pnlNotificationBadge.Controls.Add(lblBadgeCount);
            pnlNotificationBadge.Controls.Add(lblBellIcon);
            pnlNotificationBadge.Cursor = Cursors.Hand;
            pnlNotificationBadge.Location = new Point(335, 10);
            pnlNotificationBadge.Name = "pnlNotificationBadge";
            pnlNotificationBadge.Size = new Size(38, 36);
            pnlNotificationBadge.TabIndex = 1;
            // 
            // lblBadgeCount
            // 
            lblBadgeCount.BackColor = Color.FromArgb(220, 38, 38);
            lblBadgeCount.Font = new Font("Segoe UI", 6.5F, FontStyle.Bold);
            lblBadgeCount.ForeColor = Color.White;
            lblBadgeCount.Location = new Point(20, 2);
            lblBadgeCount.Name = "lblBadgeCount";
            lblBadgeCount.Size = new Size(15, 15);
            lblBadgeCount.TabIndex = 1;
            lblBadgeCount.Text = "3";
            lblBadgeCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBellIcon
            // 
            lblBellIcon.Dock = DockStyle.Fill;
            lblBellIcon.Font = new Font("Segoe UI", 13F);
            lblBellIcon.ForeColor = Color.FromArgb(71, 85, 105);
            lblBellIcon.Location = new Point(0, 0);
            lblBellIcon.Name = "lblBellIcon";
            lblBellIcon.Size = new Size(38, 36);
            lblBellIcon.TabIndex = 0;
            lblBellIcon.Text = "🔔";
            lblBellIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSearchBox
            // 
            pnlSearchBox.BackColor = Color.White;
            pnlSearchBox.Controls.Add(txtSearch);
            pnlSearchBox.Controls.Add(lblSearchIcon);
            pnlSearchBox.Location = new Point(40, 11);
            pnlSearchBox.Name = "pnlSearchBox";
            pnlSearchBox.Padding = new Padding(6, 4, 8, 4);
            pnlSearchBox.Size = new Size(275, 34);
            pnlSearchBox.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.ForeColor = Color.FromArgb(100, 116, 139);
            txtSearch.Location = new Point(30, 9);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm sự kiện, người tham gia...";
            txtSearch.Size = new Size(235, 16);
            txtSearch.TabIndex = 1;
            // 
            // lblSearchIcon
            // 
            lblSearchIcon.Font = new Font("Segoe UI", 9.5F);
            lblSearchIcon.ForeColor = Color.FromArgb(148, 163, 184);
            lblSearchIcon.Location = new Point(6, 6);
            lblSearchIcon.Name = "lblSearchIcon";
            lblSearchIcon.Size = new Size(20, 22);
            lblSearchIcon.TabIndex = 0;
            lblSearchIcon.Text = "🔍";
            lblSearchIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnHamburger
            // 
            btnHamburger.Cursor = Cursors.Hand;
            btnHamburger.FlatAppearance.BorderSize = 0;
            btnHamburger.FlatStyle = FlatStyle.Flat;
            btnHamburger.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHamburger.ForeColor = Color.FromArgb(51, 65, 85);
            btnHamburger.Location = new Point(14, 11);
            btnHamburger.Name = "btnHamburger";
            btnHamburger.Size = new Size(36, 34);
            btnHamburger.TabIndex = 0;
            btnHamburger.Text = "☰";
            btnHamburger.UseVisualStyleBackColor = true;
            // 
            // CanBoDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 720);
            Controls.Add(pnlMain);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1000, 600);
            Name = "CanBoDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cán Bộ - Quản lý sự kiện";
            pnlSidebar.ResumeLayout(false);
            pnlSidebarMenu.ResumeLayout(false);
            pnlSidebarFooter.ResumeLayout(false);
            pnlSidebarFooter.PerformLayout();
            pnlSidebarBrand.ResumeLayout(false);
            pnlSidebarBrand.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlTopNav.ResumeLayout(false);
            pnlTopNavRight.ResumeLayout(false);
            pnlTopNavRight.PerformLayout();
            pnlAvatar.ResumeLayout(false);
            pnlNotificationBadge.ResumeLayout(false);
            pnlSearchBox.ResumeLayout(false);
            pnlSearchBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlSidebarBrand;
        private Label lblBrandIcon;
        private Label lblBrandTitle;
        private Label lblBrandSubtitle;
        private Panel pnlSidebarMenu;
        private Button btnHome;
        private Panel sp2;
        private Button btnReports;
        private Panel sp3;
        private Button btnDocuments;
        private Panel sp4;
        private Button btnTasks;
        private Panel spTask;
        private Button btnParticipants;
        private Panel sp5;
        private Button btnNotifications;
        private Panel pnlSidebarFooter;
        private Button btnLogout;
        private Label lblFooterIcon;
        private Label lblFooterBrand;
        private Label lblFooterSlogan;
        private Panel pnlMain;
        private Panel pnlTopNav;
        private Button btnHamburger;
        private Panel pnlTopNavRight;
        private Panel pnlSearchBox;
        private Label lblSearchIcon;
        private TextBox txtSearch;
        private Panel pnlNotificationBadge;
        private Label lblBellIcon;
        private Label lblBadgeCount;
        private Panel pnlAvatar;
        private Label lblAvatarLetter;
        private Label lblUsername;
        private Label lblDropdownArrow;
        private Panel pnlContent;
    }
}
