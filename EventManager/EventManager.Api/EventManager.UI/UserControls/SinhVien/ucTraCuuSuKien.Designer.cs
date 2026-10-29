namespace EventManager.UI.UserControls.SinhVien
{
    partial class ucTraCuuSuKien
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
            DataGridViewCellStyle dateStyle = new DataGridViewCellStyle();
            lblTitle = new Label();
            pnlFilter = new Panel();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            chkFilterDate = new CheckBox();
            dtpFrom = new DateTimePicker();
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            btnSearch = new Button();
            btnClear = new Button();
            pnlActions = new Panel();
            lblCount = new Label();
            btnViewDetail = new Button();
            btnRegister = new Button();
            dgvEvents = new DataGridView();
            colTitle = new DataGridViewTextBoxColumn();
            colStartDate = new DataGridViewTextBoxColumn();
            colLocation = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colSlot = new DataGridViewTextBoxColumn();
            colMyStatus = new DataGridViewTextBoxColumn();
            pnlFilter.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
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
            lblTitle.Text = "TRA CỨU SỰ KIỆN";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pnlFilter
            //
            pnlFilter.Controls.Add(lblKeyword);
            pnlFilter.Controls.Add(txtKeyword);
            pnlFilter.Controls.Add(chkFilterDate);
            pnlFilter.Controls.Add(dtpFrom);
            pnlFilter.Controls.Add(lblTo);
            pnlFilter.Controls.Add(dtpTo);
            pnlFilter.Controls.Add(btnSearch);
            pnlFilter.Controls.Add(btnClear);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 45);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(800, 80);
            pnlFilter.TabIndex = 1;
            //
            // lblKeyword
            //
            lblKeyword.AutoSize = true;
            lblKeyword.Location = new Point(12, 12);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(58, 15);
            lblKeyword.TabIndex = 0;
            lblKeyword.Text = "Từ khóa:";
            //
            // txtKeyword
            //
            txtKeyword.Location = new Point(110, 9);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Nhập tên sự kiện, địa điểm...";
            txtKeyword.Size = new Size(340, 23);
            txtKeyword.TabIndex = 1;
            //
            // chkFilterDate
            //
            chkFilterDate.AutoSize = true;
            chkFilterDate.Location = new Point(12, 46);
            chkFilterDate.Name = "chkFilterDate";
            chkFilterDate.Size = new Size(93, 19);
            chkFilterDate.TabIndex = 2;
            chkFilterDate.Text = "Lọc từ ngày:";
            chkFilterDate.UseVisualStyleBackColor = true;
            //
            // dtpFrom
            //
            dtpFrom.CustomFormat = "dd/MM/yyyy";
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.Location = new Point(110, 44);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(130, 23);
            dtpFrom.TabIndex = 3;
            //
            // lblTo
            //
            lblTo.AutoSize = true;
            lblTo.Location = new Point(252, 48);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(59, 15);
            lblTo.TabIndex = 4;
            lblTo.Text = "Đến ngày:";
            //
            // dtpTo
            //
            dtpTo.CustomFormat = "dd/MM/yyyy";
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.Location = new Point(320, 44);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(130, 23);
            dtpTo.TabIndex = 5;
            //
            // btnSearch
            //
            btnSearch.BackColor = Color.FromArgb(37, 99, 235);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(470, 8);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 27);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            //
            // btnClear
            //
            btnClear.Location = new Point(470, 42);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 27);
            btnClear.TabIndex = 7;
            btnClear.Text = "Xóa bộ lọc";
            btnClear.UseVisualStyleBackColor = true;
            //
            // pnlActions
            //
            pnlActions.Controls.Add(lblCount);
            pnlActions.Controls.Add(btnViewDetail);
            pnlActions.Controls.Add(btnRegister);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 450);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(800, 50);
            pnlActions.TabIndex = 3;
            //
            // lblCount
            //
            lblCount.AutoSize = true;
            lblCount.Location = new Point(12, 18);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(0, 15);
            lblCount.TabIndex = 0;
            //
            // btnViewDetail
            //
            btnViewDetail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewDetail.Location = new Point(530, 10);
            btnViewDetail.Name = "btnViewDetail";
            btnViewDetail.Size = new Size(125, 30);
            btnViewDetail.TabIndex = 1;
            btnViewDetail.Text = "Xem chi tiết";
            btnViewDetail.UseVisualStyleBackColor = true;
            //
            // btnRegister
            //
            btnRegister.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegister.BackColor = Color.FromArgb(22, 163, 74);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(665, 10);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(125, 30);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Đăng ký tham gia";
            btnRegister.UseVisualStyleBackColor = false;
            //
            // dgvEvents
            //
            dgvEvents.AllowUserToAddRows = false;
            dgvEvents.AllowUserToDeleteRows = false;
            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvents.BackgroundColor = Color.White;
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvents.Columns.AddRange(new DataGridViewColumn[] { colTitle, colStartDate, colLocation, colStatus, colSlot, colMyStatus });
            dgvEvents.Dock = DockStyle.Fill;
            dgvEvents.Location = new Point(0, 125);
            dgvEvents.MultiSelect = false;
            dgvEvents.Name = "dgvEvents";
            dgvEvents.ReadOnly = true;
            dgvEvents.RowHeadersVisible = false;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvents.Size = new Size(800, 325);
            dgvEvents.TabIndex = 2;
            //
            // colTitle
            //
            colTitle.DataPropertyName = "Title";
            colTitle.FillWeight = 180F;
            colTitle.HeaderText = "Tên sự kiện";
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            //
            // colStartDate
            //
            colStartDate.DataPropertyName = "StartDate";
            dateStyle.Format = "dd/MM/yyyy HH:mm";
            colStartDate.DefaultCellStyle = dateStyle;
            colStartDate.HeaderText = "Thời gian";
            colStartDate.Name = "colStartDate";
            colStartDate.ReadOnly = true;
            //
            // colLocation
            //
            colLocation.DataPropertyName = "Location";
            colLocation.FillWeight = 140F;
            colLocation.HeaderText = "Địa điểm";
            colLocation.Name = "colLocation";
            colLocation.ReadOnly = true;
            //
            // colStatus
            //
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Trạng thái";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            //
            // colSlot
            //
            colSlot.DataPropertyName = "SlotText";
            colSlot.FillWeight = 70F;
            colSlot.HeaderText = "Đã đăng ký";
            colSlot.Name = "colSlot";
            colSlot.ReadOnly = true;
            //
            // colMyStatus
            //
            colMyStatus.DataPropertyName = "MyStatusText";
            colMyStatus.HeaderText = "Của tôi";
            colMyStatus.Name = "colMyStatus";
            colMyStatus.ReadOnly = true;
            //
            // ucTraCuuSuKien
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvEvents);
            Controls.Add(pnlActions);
            Controls.Add(pnlFilter);
            Controls.Add(lblTitle);
            Name = "ucTraCuuSuKien";
            Size = new Size(800, 500);
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Panel pnlFilter;
        private Label lblKeyword;
        private TextBox txtKeyword;
        private CheckBox chkFilterDate;
        private DateTimePicker dtpFrom;
        private Label lblTo;
        private DateTimePicker dtpTo;
        private Button btnSearch;
        private Button btnClear;
        private Panel pnlActions;
        private Label lblCount;
        private Button btnViewDetail;
        private Button btnRegister;
        private DataGridView dgvEvents;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colStartDate;
        private DataGridViewTextBoxColumn colLocation;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colSlot;
        private DataGridViewTextBoxColumn colMyStatus;
    }
}
