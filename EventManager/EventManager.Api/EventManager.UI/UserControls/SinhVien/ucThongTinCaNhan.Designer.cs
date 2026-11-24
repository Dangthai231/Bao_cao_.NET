namespace EventManager.UI.UserControls.SinhVien
{
    partial class ucThongTinCaNhan
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
            lblSubtitle = new Label();
            lblTitle = new Label();
            tlpBody = new TableLayoutPanel();
            grpInfo = new Panel();
            pnlAvatar = new Panel();
            lblAvatarLetter = new Label();
            lblProfileName = new Label();
            lblProfileSub = new Label();
            pnlDivider = new Panel();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblStudentCode = new Label();
            txtStudentCode = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblClassName = new Label();
            txtClassName = new TextBox();
            lblDateOfBirth = new Label();
            dtpDateOfBirth = new DateTimePicker();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            grpPassword = new Panel();
            lblPasswordTitle = new Label();
            lblCurrentPassword = new Label();
            txtCurrentPassword = new TextBox();
            lblNewPassword = new Label();
            txtNewPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            lblPasswordHint = new Label();
            pnlRight = new Panel();
            pnlButtons = new Panel();
            spRight = new Panel();
            btnEdit = new Button();
            btnSave = new Button();
            btnCancelEdit = new Button();
            pnlHeader.SuspendLayout();
            tlpBody.SuspendLayout();
            grpInfo.SuspendLayout();
            pnlAvatar.SuspendLayout();
            grpPassword.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(24, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(952, 62);
            pnlHeader.TabIndex = 0;
            //
            // lblSubtitle
            //
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(2, 36);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(330, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Xem và cập nhật thông tin cá nhân, đổi mật khẩu đăng nhập";
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(0, 4);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(190, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thông tin cá nhân";
            //
            // tlpBody
            //
            tlpBody.ColumnCount = 2;
            tlpBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56F));
            tlpBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44F));
            tlpBody.Controls.Add(grpInfo, 0, 0);
            tlpBody.Controls.Add(pnlRight, 1, 0);
            tlpBody.Dock = DockStyle.Fill;
            tlpBody.Location = new Point(24, 82);
            tlpBody.Name = "tlpBody";
            tlpBody.Padding = new Padding(0, 8, 0, 0);
            tlpBody.RowCount = 1;
            tlpBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBody.Size = new Size(952, 568);
            tlpBody.TabIndex = 1;
            //
            // grpInfo
            //
            grpInfo.BackColor = Color.White;
            grpInfo.Controls.Add(pnlAvatar);
            grpInfo.Controls.Add(lblProfileName);
            grpInfo.Controls.Add(lblProfileSub);
            grpInfo.Controls.Add(pnlDivider);
            grpInfo.Controls.Add(lblUsername);
            grpInfo.Controls.Add(txtUsername);
            grpInfo.Controls.Add(lblStudentCode);
            grpInfo.Controls.Add(txtStudentCode);
            grpInfo.Controls.Add(lblFullName);
            grpInfo.Controls.Add(txtFullName);
            grpInfo.Controls.Add(lblClassName);
            grpInfo.Controls.Add(txtClassName);
            grpInfo.Controls.Add(lblDateOfBirth);
            grpInfo.Controls.Add(dtpDateOfBirth);
            grpInfo.Controls.Add(lblEmail);
            grpInfo.Controls.Add(txtEmail);
            grpInfo.Controls.Add(lblPhone);
            grpInfo.Controls.Add(txtPhone);
            grpInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInfo.Location = new Point(0, 8);
            grpInfo.Margin = new Padding(0, 0, 8, 0);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(525, 400);
            grpInfo.TabIndex = 0;
            //
            // pnlAvatar
            //
            pnlAvatar.BackColor = Color.FromArgb(37, 99, 235);
            pnlAvatar.Controls.Add(lblAvatarLetter);
            pnlAvatar.Location = new Point(18, 18);
            pnlAvatar.Name = "pnlAvatar";
            pnlAvatar.Size = new Size(52, 52);
            pnlAvatar.TabIndex = 0;
            //
            // lblAvatarLetter
            //
            lblAvatarLetter.Dock = DockStyle.Fill;
            lblAvatarLetter.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAvatarLetter.ForeColor = Color.White;
            lblAvatarLetter.Location = new Point(0, 0);
            lblAvatarLetter.Name = "lblAvatarLetter";
            lblAvatarLetter.Size = new Size(52, 52);
            lblAvatarLetter.TabIndex = 0;
            lblAvatarLetter.Text = "S";
            lblAvatarLetter.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblProfileName
            //
            lblProfileName.AutoEllipsis = true;
            lblProfileName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProfileName.ForeColor = Color.FromArgb(15, 23, 42);
            lblProfileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblProfileName.Location = new Point(82, 20);
            lblProfileName.Name = "lblProfileName";
            lblProfileName.Size = new Size(420, 24);
            lblProfileName.TabIndex = 1;
            lblProfileName.Text = "Họ và tên sinh viên";
            //
            // lblProfileSub
            //
            lblProfileSub.AutoEllipsis = true;
            lblProfileSub.Font = new Font("Segoe UI", 9F);
            lblProfileSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblProfileSub.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblProfileSub.Location = new Point(83, 46);
            lblProfileSub.Name = "lblProfileSub";
            lblProfileSub.Size = new Size(420, 18);
            lblProfileSub.TabIndex = 2;
            lblProfileSub.Text = "MSV: ---  •  Lớp: ---";
            //
            // pnlDivider
            //
            pnlDivider.BackColor = Color.FromArgb(241, 245, 249);
            pnlDivider.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlDivider.Location = new Point(18, 84);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(484, 1);
            pnlDivider.TabIndex = 3;
            //
            // lblUsername
            //
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(51, 65, 85);
            lblUsername.Location = new Point(18, 104);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(64, 15);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Tài khoản";
            //
            // txtUsername
            //
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 9.5F);
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(150, 100);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(352, 24);
            txtUsername.TabIndex = 5;
            //
            // lblStudentCode
            //
            lblStudentCode.AutoSize = true;
            lblStudentCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStudentCode.ForeColor = Color.FromArgb(51, 65, 85);
            lblStudentCode.Location = new Point(18, 146);
            lblStudentCode.Name = "lblStudentCode";
            lblStudentCode.Size = new Size(80, 15);
            lblStudentCode.TabIndex = 6;
            lblStudentCode.Text = "Mã sinh viên";
            //
            // txtStudentCode
            //
            txtStudentCode.BorderStyle = BorderStyle.FixedSingle;
            txtStudentCode.Font = new Font("Segoe UI", 9.5F);
            txtStudentCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtStudentCode.Location = new Point(150, 142);
            txtStudentCode.Name = "txtStudentCode";
            txtStudentCode.ReadOnly = true;
            txtStudentCode.Size = new Size(352, 24);
            txtStudentCode.TabIndex = 7;
            //
            // lblFullName
            //
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(51, 65, 85);
            lblFullName.Location = new Point(18, 188);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(80, 15);
            lblFullName.TabIndex = 8;
            lblFullName.Text = "Họ và tên (*)";
            //
            // txtFullName
            //
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Font = new Font("Segoe UI", 9.5F);
            txtFullName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFullName.Location = new Point(150, 184);
            txtFullName.MaxLength = 100;
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(352, 24);
            txtFullName.TabIndex = 9;
            //
            // lblClassName
            //
            lblClassName.AutoSize = true;
            lblClassName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblClassName.ForeColor = Color.FromArgb(51, 65, 85);
            lblClassName.Location = new Point(18, 230);
            lblClassName.Name = "lblClassName";
            lblClassName.Size = new Size(28, 15);
            lblClassName.TabIndex = 10;
            lblClassName.Text = "Lớp";
            //
            // txtClassName
            //
            txtClassName.BorderStyle = BorderStyle.FixedSingle;
            txtClassName.Font = new Font("Segoe UI", 9.5F);
            txtClassName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtClassName.Location = new Point(150, 226);
            txtClassName.MaxLength = 50;
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new Size(352, 24);
            txtClassName.TabIndex = 11;
            //
            // lblDateOfBirth
            //
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDateOfBirth.ForeColor = Color.FromArgb(51, 65, 85);
            lblDateOfBirth.Location = new Point(18, 272);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(64, 15);
            lblDateOfBirth.TabIndex = 12;
            lblDateOfBirth.Text = "Ngày sinh";
            //
            // dtpDateOfBirth
            //
            dtpDateOfBirth.CustomFormat = "dd/MM/yyyy";
            dtpDateOfBirth.Font = new Font("Segoe UI", 9.5F);
            dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDateOfBirth.Location = new Point(150, 268);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.ShowCheckBox = true;
            dtpDateOfBirth.Size = new Size(180, 24);
            dtpDateOfBirth.TabIndex = 13;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(51, 65, 85);
            lblEmail.Location = new Point(18, 314);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(38, 15);
            lblEmail.TabIndex = 14;
            lblEmail.Text = "Email";
            //
            // txtEmail
            //
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Location = new Point(150, 310);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(352, 24);
            txtEmail.TabIndex = 15;
            //
            // lblPhone
            //
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(51, 65, 85);
            lblPhone.Location = new Point(18, 356);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(85, 15);
            lblPhone.TabIndex = 16;
            lblPhone.Text = "Số điện thoại";
            //
            // txtPhone
            //
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 9.5F);
            txtPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.Location = new Point(150, 352);
            txtPhone.MaxLength = 11;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(352, 24);
            txtPhone.TabIndex = 17;
            //
            // grpPassword
            //
            grpPassword.BackColor = Color.White;
            grpPassword.Controls.Add(lblPasswordTitle);
            grpPassword.Controls.Add(lblCurrentPassword);
            grpPassword.Controls.Add(txtCurrentPassword);
            grpPassword.Controls.Add(lblNewPassword);
            grpPassword.Controls.Add(txtNewPassword);
            grpPassword.Controls.Add(lblConfirmPassword);
            grpPassword.Controls.Add(txtConfirmPassword);
            grpPassword.Controls.Add(lblPasswordHint);
            grpPassword.Dock = DockStyle.Top;
            grpPassword.Location = new Point(0, 0);
            grpPassword.Name = "grpPassword";
            grpPassword.Size = new Size(411, 214);
            grpPassword.TabIndex = 0;
            //
            // lblPasswordTitle
            //
            lblPasswordTitle.AutoSize = true;
            lblPasswordTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPasswordTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblPasswordTitle.Location = new Point(16, 16);
            lblPasswordTitle.Name = "lblPasswordTitle";
            lblPasswordTitle.Size = new Size(120, 19);
            lblPasswordTitle.TabIndex = 0;
            lblPasswordTitle.Text = "🔒  Đổi mật khẩu";
            //
            // lblCurrentPassword
            //
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCurrentPassword.ForeColor = Color.FromArgb(51, 65, 85);
            lblCurrentPassword.Location = new Point(18, 60);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(110, 15);
            lblCurrentPassword.TabIndex = 1;
            lblCurrentPassword.Text = "Mật khẩu hiện tại";
            //
            // txtCurrentPassword
            //
            txtCurrentPassword.BorderStyle = BorderStyle.FixedSingle;
            txtCurrentPassword.Font = new Font("Segoe UI", 9.5F);
            txtCurrentPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCurrentPassword.Location = new Point(160, 56);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PasswordChar = '●';
            txtCurrentPassword.Size = new Size(233, 24);
            txtCurrentPassword.TabIndex = 2;
            //
            // lblNewPassword
            //
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNewPassword.ForeColor = Color.FromArgb(51, 65, 85);
            lblNewPassword.Location = new Point(18, 102);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(90, 15);
            lblNewPassword.TabIndex = 3;
            lblNewPassword.Text = "Mật khẩu mới";
            //
            // txtNewPassword
            //
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.Font = new Font("Segoe UI", 9.5F);
            txtNewPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNewPassword.Location = new Point(160, 98);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '●';
            txtNewPassword.Size = new Size(233, 24);
            txtNewPassword.TabIndex = 4;
            //
            // lblConfirmPassword
            //
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(51, 65, 85);
            lblConfirmPassword.Location = new Point(18, 144);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(115, 15);
            lblConfirmPassword.TabIndex = 5;
            lblConfirmPassword.Text = "Nhập lại mật khẩu";
            //
            // txtConfirmPassword
            //
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Segoe UI", 9.5F);
            txtConfirmPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtConfirmPassword.Location = new Point(160, 140);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(233, 24);
            txtConfirmPassword.TabIndex = 6;
            //
            // lblPasswordHint
            //
            lblPasswordHint.AutoSize = true;
            lblPasswordHint.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblPasswordHint.ForeColor = Color.FromArgb(100, 116, 139);
            lblPasswordHint.Location = new Point(18, 182);
            lblPasswordHint.Name = "lblPasswordHint";
            lblPasswordHint.Size = new Size(260, 15);
            lblPasswordHint.TabIndex = 7;
            lblPasswordHint.Text = "Không bắt buộc - để trống nếu không muốn đổi.";
            //
            // pnlRight
            //
            pnlRight.Controls.Add(pnlButtons);
            pnlRight.Controls.Add(spRight);
            pnlRight.Controls.Add(grpPassword);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(541, 8);
            pnlRight.Margin = new Padding(8, 0, 0, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(411, 560);
            pnlRight.TabIndex = 1;
            //
            // spRight
            //
            spRight.Dock = DockStyle.Top;
            spRight.Location = new Point(0, 214);
            spRight.Name = "spRight";
            spRight.Size = new Size(411, 16);
            spRight.TabIndex = 1;
            //
            // pnlButtons
            //
            pnlButtons.Controls.Add(btnCancelEdit);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnEdit);
            pnlButtons.Dock = DockStyle.Top;
            pnlButtons.Location = new Point(0, 230);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(411, 44);
            pnlButtons.TabIndex = 2;
            //
            // btnEdit
            //
            btnEdit.BackColor = Color.FromArgb(37, 99, 235);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(0, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(190, 40);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "✏  Cập nhật thông tin";
            btnEdit.UseVisualStyleBackColor = false;
            //
            // btnSave
            //
            btnSave.BackColor = Color.FromArgb(22, 163, 74);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 128, 61);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(190, 40);
            btnSave.TabIndex = 4;
            btnSave.Text = "💾  Lưu thay đổi";
            btnSave.UseVisualStyleBackColor = false;
            //
            // btnCancelEdit
            //
            btnCancelEdit.BackColor = Color.White;
            btnCancelEdit.Cursor = Cursors.Hand;
            btnCancelEdit.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnCancelEdit.FlatStyle = FlatStyle.Flat;
            btnCancelEdit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancelEdit.ForeColor = Color.FromArgb(51, 65, 85);
            btnCancelEdit.Location = new Point(200, 0);
            btnCancelEdit.Name = "btnCancelEdit";
            btnCancelEdit.Size = new Size(110, 40);
            btnCancelEdit.TabIndex = 5;
            btnCancelEdit.Text = "Hủy";
            btnCancelEdit.UseVisualStyleBackColor = false;
            //
            // ucThongTinCaNhan
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(tlpBody);
            Controls.Add(pnlHeader);
            Name = "ucThongTinCaNhan";
            Padding = new Padding(24, 20, 24, 14);
            Size = new Size(1000, 664);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpBody.ResumeLayout(false);
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            pnlAvatar.ResumeLayout(false);
            grpPassword.ResumeLayout(false);
            grpPassword.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private TableLayoutPanel tlpBody;
        private Panel grpInfo;
        private Panel pnlAvatar;
        private Label lblAvatarLetter;
        private Label lblProfileName;
        private Label lblProfileSub;
        private Panel pnlDivider;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblStudentCode;
        private TextBox txtStudentCode;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblClassName;
        private TextBox txtClassName;
        private Label lblDateOfBirth;
        private DateTimePicker dtpDateOfBirth;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Panel grpPassword;
        private Label lblPasswordTitle;
        private Label lblCurrentPassword;
        private TextBox txtCurrentPassword;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Label lblPasswordHint;
        private Panel pnlRight;
        private Panel spRight;
        private Panel pnlButtons;
        private Button btnEdit;
        private Button btnSave;
        private Button btnCancelEdit;
    }
}
