namespace EventManager.UI.UserControls.CanBo
{
    partial class ucManageNotifications
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
            groupBox1 = new GroupBox();
            dgvNotifications = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            btnSearch = new Button();
            txtSearchNotification = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            btnResetForm = new Button();
            btnDeleteNotification = new Button();
            btnUpdateNotification = new Button();
            btnCreateNotification = new Button();
            cboStatus = new ComboBox();
            dtpSendDate = new DateTimePicker();
            cboTargetAudience = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            richTextBox1 = new RichTextBox();
            label4 = new Label();
            txtNotificationTitle = new TextBox();
            label3 = new Label();
            label1 = new Label();
            lblSystemMessage = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvNotifications);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtSearchNotification);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(27, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(485, 528);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách thông báo";
            // 
            // dgvNotifications
            // 
            dgvNotifications.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNotifications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotifications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotifications.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dgvNotifications.Location = new Point(12, 58);
            dgvNotifications.Name = "dgvNotifications";
            dgvNotifications.Size = new Size(467, 464);
            dgvNotifications.TabIndex = 3;
            dgvNotifications.CellClick += dgvNotifications_CellClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Mã";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Tiêu đề";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Đối tượng";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Ngày gửi";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Trạng thái";
            Column5.Name = "Column5";
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.Location = new Point(385, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(88, 25);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchNotification
            // 
            txtSearchNotification.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchNotification.Location = new Point(74, 22);
            txtSearchNotification.Name = "txtSearchNotification";
            txtSearchNotification.Size = new Size(300, 23);
            txtSearchNotification.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 25);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 0;
            label2.Text = "Tìm kiếm:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnResetForm);
            groupBox2.Controls.Add(btnDeleteNotification);
            groupBox2.Controls.Add(btnUpdateNotification);
            groupBox2.Controls.Add(btnCreateNotification);
            groupBox2.Controls.Add(cboStatus);
            groupBox2.Controls.Add(dtpSendDate);
            groupBox2.Controls.Add(cboTargetAudience);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(richTextBox1);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtNotificationTitle);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(518, 47);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(561, 528);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin thông báo";
            // 
            // btnResetForm
            // 
            btnResetForm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnResetForm.Location = new Point(385, 495);
            btnResetForm.Name = "btnResetForm";
            btnResetForm.Size = new Size(110, 28);
            btnResetForm.TabIndex = 13;
            btnResetForm.Text = "Làm mới";
            btnResetForm.UseVisualStyleBackColor = true;
            btnResetForm.Click += btnResetForm_Click;
            // 
            // btnDeleteNotification
            // 
            btnDeleteNotification.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteNotification.Location = new Point(269, 495);
            btnDeleteNotification.Name = "btnDeleteNotification";
            btnDeleteNotification.Size = new Size(110, 28);
            btnDeleteNotification.TabIndex = 12;
            btnDeleteNotification.Text = "Xóa";
            btnDeleteNotification.UseVisualStyleBackColor = true;
            btnDeleteNotification.Click += btnDeleteNotification_Click;
            // 
            // btnUpdateNotification
            // 
            btnUpdateNotification.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpdateNotification.Location = new Point(153, 495);
            btnUpdateNotification.Name = "btnUpdateNotification";
            btnUpdateNotification.Size = new Size(110, 28);
            btnUpdateNotification.TabIndex = 11;
            btnUpdateNotification.Text = "Cập nhật";
            btnUpdateNotification.UseVisualStyleBackColor = true;
            btnUpdateNotification.Click += btnUpdateNotification_Click;
            // 
            // btnCreateNotification
            // 
            btnCreateNotification.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCreateNotification.Location = new Point(37, 495);
            btnCreateNotification.Name = "btnCreateNotification";
            btnCreateNotification.Size = new Size(110, 28);
            btnCreateNotification.TabIndex = 10;
            btnCreateNotification.Text = "Tạo thông báo";
            btnCreateNotification.UseVisualStyleBackColor = true;
            btnCreateNotification.Click += btnCreateNotification_Click;
            // 
            // cboStatus
            // 
            cboStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Đã gửi", "Nháp", "Đã hủy" });
            cboStatus.Location = new Point(70, 460);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(475, 23);
            cboStatus.TabIndex = 9;
            // 
            // dtpSendDate
            // 
            dtpSendDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtpSendDate.CustomFormat = "dd/MM/yyyy";
            dtpSendDate.Format = DateTimePickerFormat.Custom;
            dtpSendDate.Location = new Point(70, 422);
            dtpSendDate.Name = "dtpSendDate";
            dtpSendDate.Size = new Size(475, 23);
            dtpSendDate.TabIndex = 8;
            // 
            // cboTargetAudience
            // 
            cboTargetAudience.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cboTargetAudience.FormattingEnabled = true;
            cboTargetAudience.Items.AddRange(new object[] { "Tất cả người tham gia", "Ban tổ chức", "Đại biểu", "Khách mời" });
            cboTargetAudience.Location = new Point(70, 386);
            cboTargetAudience.Name = "cboTargetAudience";
            cboTargetAudience.Size = new Size(475, 23);
            cboTargetAudience.TabIndex = 7;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(6, 425);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 6;
            label7.Text = "Ngày gửi:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(6, 463);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 5;
            label6.Text = "Trạng thái:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(6, 389);
            label5.Name = "label5";
            label5.Size = new Size(63, 15);
            label5.TabIndex = 4;
            label5.Text = "Đối tượng:";
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(70, 58);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(475, 312);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 58);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 2;
            label4.Text = "Nội dung:";
            // 
            // txtNotificationTitle
            // 
            txtNotificationTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNotificationTitle.Location = new Point(70, 20);
            txtNotificationTitle.Name = "txtNotificationTitle";
            txtNotificationTitle.Size = new Size(475, 23);
            txtNotificationTitle.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 0;
            label3.Text = "Tiêu đề:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 14);
            label1.Name = "label1";
            label1.Size = new Size(173, 15);
            label1.TabIndex = 2;
            label1.Text = "QUẢN LÝ THÔNG BÁO SỰ KIỆN";
            // 
            // lblSystemMessage
            // 
            lblSystemMessage.AutoSize = true;
            lblSystemMessage.ForeColor = Color.Lime;
            lblSystemMessage.Location = new Point(41, 588);
            lblSystemMessage.Name = "lblSystemMessage";
            lblSystemMessage.Size = new Size(180, 15);
            lblSystemMessage.TabIndex = 3;
            lblSystemMessage.Text = "Cập nhật thông báo thành công!";
            // 
            // ucManageNotifications
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblSystemMessage);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ucManageNotifications";
            Size = new Size(1082, 612);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnSearch;
        private TextBox txtSearchNotification;
        private Label label2;
        private GroupBox groupBox2;
        private Label label1;
        private DataGridView dgvNotifications;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Label label3;
        private ComboBox cboStatus;
        private DateTimePicker dtpSendDate;
        private ComboBox cboTargetAudience;
        private Label label7;
        private Label label6;
        private Label label5;
        private RichTextBox richTextBox1;
        private Label label4;
        private TextBox txtNotificationTitle;
        private Button btnResetForm;
        private Button btnDeleteNotification;
        private Button btnUpdateNotification;
        private Button btnCreateNotification;
        private Label lblSystemMessage;
    }
}
