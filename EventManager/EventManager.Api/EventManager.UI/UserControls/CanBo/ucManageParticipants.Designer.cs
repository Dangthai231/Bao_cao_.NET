namespace EventManager.UI.UserControls.CanBo
{
    partial class ucQuanLyNguoiThamGia
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
            label1 = new Label();
            label2 = new Label();
            txtSearchParticipants = new TextBox();
            btnSearch = new Button();
            btnClearSearch = new Button();
            dgvParticipants = new GroupBox();
            lblTotalParticipants = new Label();
            lblPresent = new Label();
            lblAbsent = new Label();
            lblNotCheckedIn = new Label();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewComboBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            btnViewDetails = new Button();
            btnCheckIn = new Button();
            btnRefresh = new Button();
            dgvParticipants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 21);
            label1.Name = "label1";
            label1.Size = new Size(201, 15);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ NGƯỜI THAM GIA SỰ KIỆN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 52);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "Tìm kiếm";
            // 
            // txtSearchParticipants
            // 
            txtSearchParticipants.Location = new Point(89, 44);
            txtSearchParticipants.Name = "txtSearchParticipants";
            txtSearchParticipants.Size = new Size(229, 23);
            txtSearchParticipants.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(341, 44);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(125, 23);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnClearSearch
            // 
            btnClearSearch.Location = new Point(482, 44);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(109, 23);
            btnClearSearch.TabIndex = 5;
            btnClearSearch.Text = "Hủy tìm kiếm";
            btnClearSearch.UseVisualStyleBackColor = true;
            // 
            // dgvParticipants
            // 
            dgvParticipants.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvParticipants.Controls.Add(dataGridView1);
            dgvParticipants.Location = new Point(25, 80);
            dgvParticipants.Name = "dgvParticipants";
            dgvParticipants.Size = new Size(1025, 450);
            dgvParticipants.TabIndex = 6;
            dgvParticipants.TabStop = false;
            dgvParticipants.Text = "Danh sách người tham gia";
            // 
            // lblTotalParticipants
            // 
            lblTotalParticipants.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalParticipants.AutoSize = true;
            lblTotalParticipants.Location = new Point(694, 44);
            lblTotalParticipants.Name = "lblTotalParticipants";
            lblTotalParticipants.Size = new Size(38, 15);
            lblTotalParticipants.TabIndex = 7;
            lblTotalParticipants.Text = "Tổng:";
            // 
            // lblPresent
            // 
            lblPresent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPresent.AutoSize = true;
            lblPresent.Location = new Point(761, 44);
            lblPresent.Name = "lblPresent";
            lblPresent.Size = new Size(46, 15);
            lblPresent.TabIndex = 8;
            lblPresent.Text = "Có mặt";
            // 
            // lblAbsent
            // 
            lblAbsent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAbsent.AutoSize = true;
            lblAbsent.Location = new Point(835, 44);
            lblAbsent.Name = "lblAbsent";
            lblAbsent.Size = new Size(61, 15);
            lblAbsent.TabIndex = 9;
            lblAbsent.Text = "Vắng mặt:";
            // 
            // lblNotCheckedIn
            // 
            lblNotCheckedIn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNotCheckedIn.AutoSize = true;
            lblNotCheckedIn.Location = new Point(919, 44);
            lblNotCheckedIn.Name = "lblNotCheckedIn";
            lblNotCheckedIn.Size = new Size(98, 15);
            lblNotCheckedIn.TabIndex = 10;
            lblNotCheckedIn.Text = "Chưa điểm danh:";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7 });
            dataGridView1.Location = new Point(15, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(995, 410);
            dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "Mã";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Họ tên";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Email";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Số điện thoại";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Vai trò";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "Điểm danh";
            Column6.Name = "Column6";
            Column6.Items.AddRange(new object[] { "Đã điểm danh", "Vắng", "Chưa điểm danh" });
            Column6.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            Column6.FlatStyle = FlatStyle.Flat;
            // 
            // Column7
            // 
            Column7.HeaderText = "Trạng thái";
            Column7.Name = "Column7";
            // 
            // btnViewDetails
            // 
            btnViewDetails.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnViewDetails.Location = new Point(25, 545);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(160, 32);
            btnViewDetails.TabIndex = 11;
            btnViewDetails.Text = "Xem chi tiết";
            btnViewDetails.UseVisualStyleBackColor = true;
            // 
            // btnCheckIn
            // 
            btnCheckIn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCheckIn.Location = new Point(205, 545);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(160, 32);
            btnCheckIn.TabIndex = 12;
            btnCheckIn.Text = "Lưu điểm danh";
            btnCheckIn.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.Location = new Point(385, 545);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(160, 32);
            btnRefresh.TabIndex = 13;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // ucQuanLyNguoiThamGia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRefresh);
            Controls.Add(btnCheckIn);
            Controls.Add(btnViewDetails);
            Controls.Add(lblNotCheckedIn);
            Controls.Add(lblAbsent);
            Controls.Add(lblPresent);
            Controls.Add(lblTotalParticipants);
            Controls.Add(dgvParticipants);
            Controls.Add(btnClearSearch);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchParticipants);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ucQuanLyNguoiThamGia";
            Size = new Size(1069, 601);
            dgvParticipants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtSearchParticipants;
        private Button btnSearch;
        private Button btnClearSearch;
        private GroupBox dgvParticipants;
        private Label lblTotalParticipants;
        private Label lblPresent;
        private Label lblAbsent;
        private Label lblNotCheckedIn;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewComboBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private Button btnViewDetails;
        private Button btnCheckIn;
        private Button btnRefresh;
    }
}
