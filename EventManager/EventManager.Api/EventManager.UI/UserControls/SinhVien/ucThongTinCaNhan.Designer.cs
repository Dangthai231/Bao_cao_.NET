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
            lblTitle = new Label();
            grpInfo = new GroupBox();
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
            grpPassword = new GroupBox();
            lblCurrentPassword = new Label();
            txtCurrentPassword = new TextBox();
            lblNewPassword = new Label();
            txtNewPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnEdit = new Button();
            btnSave = new Button();
            btnCancelEdit = new Button();
            grpInfo.SuspendLayout();
            grpPassword.SuspendLayout();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 64, 175);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(10, 0, 0, 0);
            lblTitle.Size = new Size(800, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN CÁ NHÂN";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // grpInfo
            //
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
            grpInfo.Location = new Point(15, 55);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(420, 285);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin sinh viên";
            //
            // lblUsername
            //
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(15, 32);
            lblUsername.Name = "lblUsername";
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tài khoản:";
            //
            // txtUsername
            //
            txtUsername.Location = new Point(130, 28);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(270, 23);
            txtUsername.TabIndex = 1;
            //
            // lblStudentCode
            //
            lblStudentCode.AutoSize = true;
            lblStudentCode.Location = new Point(15, 67);
            lblStudentCode.Name = "lblStudentCode";
            lblStudentCode.TabIndex = 2;
            lblStudentCode.Text = "Mã sinh viên:";
            //
            // txtStudentCode
            //
            txtStudentCode.Location = new Point(130, 63);
            txtStudentCode.Name = "txtStudentCode";
            txtStudentCode.ReadOnly = true;
            txtStudentCode.Size = new Size(270, 23);
            txtStudentCode.TabIndex = 3;
            //
            // lblFullName
            //
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(15, 102);
            lblFullName.Name = "lblFullName";
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Họ và tên (*):";
            //
            // txtFullName
            //
            txtFullName.Location = new Point(130, 98);
            txtFullName.MaxLength = 100;
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(270, 23);
            txtFullName.TabIndex = 5;
            //
            // lblClassName
            //
            lblClassName.AutoSize = true;
            lblClassName.Location = new Point(15, 137);
            lblClassName.Name = "lblClassName";
            lblClassName.TabIndex = 6;
            lblClassName.Text = "Lớp:";
            //
            // txtClassName
            //
            txtClassName.Location = new Point(130, 133);
            txtClassName.MaxLength = 50;
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new Size(270, 23);
            txtClassName.TabIndex = 7;
            //
            // lblDateOfBirth
            //
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Location = new Point(15, 172);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.TabIndex = 8;
            lblDateOfBirth.Text = "Ngày sinh:";
            //
            // dtpDateOfBirth
            //
            dtpDateOfBirth.CustomFormat = "dd/MM/yyyy";
            dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDateOfBirth.Location = new Point(130, 168);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.ShowCheckBox = true;
            dtpDateOfBirth.Size = new Size(160, 23);
            dtpDateOfBirth.TabIndex = 9;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(15, 207);
            lblEmail.Name = "lblEmail";
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(130, 203);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(270, 23);
            txtEmail.TabIndex = 11;
            //
            // lblPhone
            //
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(15, 242);
            lblPhone.Name = "lblPhone";
            lblPhone.TabIndex = 12;
            lblPhone.Text = "Số điện thoại:";
            //
            // txtPhone
            //
            txtPhone.Location = new Point(130, 238);
            txtPhone.MaxLength = 11;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(270, 23);
            txtPhone.TabIndex = 13;
            //
            // grpPassword
            //
            grpPassword.Controls.Add(lblCurrentPassword);
            grpPassword.Controls.Add(txtCurrentPassword);
            grpPassword.Controls.Add(lblNewPassword);
            grpPassword.Controls.Add(txtNewPassword);
            grpPassword.Controls.Add(lblConfirmPassword);
            grpPassword.Controls.Add(txtConfirmPassword);
            grpPassword.Location = new Point(450, 55);
            grpPassword.Name = "grpPassword";
            grpPassword.Size = new Size(340, 145);
            grpPassword.TabIndex = 2;
            grpPassword.TabStop = false;
            grpPassword.Text = "Đổi mật khẩu (không bắt buộc)";
            //
            // lblCurrentPassword
            //
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Location = new Point(15, 32);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.TabIndex = 0;
            lblCurrentPassword.Text = "Mật khẩu hiện tại:";
            //
            // txtCurrentPassword
            //
            txtCurrentPassword.Location = new Point(150, 28);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PasswordChar = '●';
            txtCurrentPassword.Size = new Size(170, 23);
            txtCurrentPassword.TabIndex = 1;
            //
            // lblNewPassword
            //
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(15, 67);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.TabIndex = 2;
            lblNewPassword.Text = "Mật khẩu mới:";
            //
            // txtNewPassword
            //
            txtNewPassword.Location = new Point(150, 63);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '●';
            txtNewPassword.Size = new Size(170, 23);
            txtNewPassword.TabIndex = 3;
            //
            // lblConfirmPassword
            //
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(15, 102);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.TabIndex = 4;
            lblConfirmPassword.Text = "Nhập lại mật khẩu:";
            //
            // txtConfirmPassword
            //
            txtConfirmPassword.Location = new Point(150, 98);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(170, 23);
            txtConfirmPassword.TabIndex = 5;
            //
            // btnEdit
            //
            btnEdit.BackColor = Color.FromArgb(37, 99, 235);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(15, 355);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(150, 34);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Cập nhật thông tin";
            btnEdit.UseVisualStyleBackColor = false;
            //
            // btnSave
            //
            btnSave.BackColor = Color.FromArgb(22, 163, 74);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(15, 355);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 34);
            btnSave.TabIndex = 4;
            btnSave.Text = "Lưu thay đổi";
            btnSave.UseVisualStyleBackColor = false;
            //
            // btnCancelEdit
            //
            btnCancelEdit.Location = new Point(175, 355);
            btnCancelEdit.Name = "btnCancelEdit";
            btnCancelEdit.Size = new Size(100, 34);
            btnCancelEdit.TabIndex = 5;
            btnCancelEdit.Text = "Hủy";
            btnCancelEdit.UseVisualStyleBackColor = true;
            //
            // ucThongTinCaNhan
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(btnCancelEdit);
            Controls.Add(btnSave);
            Controls.Add(btnEdit);
            Controls.Add(grpPassword);
            Controls.Add(grpInfo);
            Controls.Add(lblTitle);
            Name = "ucThongTinCaNhan";
            Size = new Size(800, 500);
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpPassword.ResumeLayout(false);
            grpPassword.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private GroupBox grpInfo;
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
        private GroupBox grpPassword;
        private Label lblCurrentPassword;
        private TextBox txtCurrentPassword;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnEdit;
        private Button btnSave;
        private Button btnCancelEdit;
    }
}
