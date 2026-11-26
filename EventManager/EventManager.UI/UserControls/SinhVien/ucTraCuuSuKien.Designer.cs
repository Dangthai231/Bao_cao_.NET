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
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dateStyle = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlFilter = new Panel();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            btnSearch = new Button();
            btnClear = new Button();
            chkFilterDate = new CheckBox();
            dtpFrom = new DateTimePicker();
            lblTo = new Label();
            dtpTo = new DateTimePicker();
            spFilter = new Panel();
            pnlActions = new Panel();
            lblCount = new Label();
            btnViewDetail = new Button();
            btnRegister = new Button();
            pnlGridCard = new Panel();
            dgvEvents = new DataGridView();
            colTitle = new DataGridViewTextBoxColumn();
            colStartDate = new DataGridViewTextBoxColumn();
            colLocation = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colSlot = new DataGridViewTextBoxColumn();
            colMyStatus = new DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            pnlActions.SuspendLayout();
            pnlGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
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
            lblSubtitle.Size = new Size(380, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Tìm kiếm, lọc theo ngày, xem chi tiết và đăng ký tham gia sự kiện";
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(0, 4);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tra cứu sự kiện";
            //
            // pnlFilter
            //
            pnlFilter.BackColor = Color.White;
            pnlFilter.Controls.Add(lblKeyword);
            pnlFilter.Controls.Add(txtKeyword);
            pnlFilter.Controls.Add(btnSearch);
            pnlFilter.Controls.Add(btnClear);
            pnlFilter.Controls.Add(chkFilterDate);
            pnlFilter.Controls.Add(dtpFrom);
            pnlFilter.Controls.Add(lblTo);
            pnlFilter.Controls.Add(dtpTo);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(24, 82);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(952, 96);
            pnlFilter.TabIndex = 1;
            //
            // lblKeyword
            //
            lblKeyword.AutoSize = true;
            lblKeyword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblKeyword.ForeColor = Color.FromArgb(51, 65, 85);
            lblKeyword.Location = new Point(18, 20);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(58, 15);
            lblKeyword.TabIndex = 0;
            lblKeyword.Text = "🔍 Từ khóa";
            //
            // txtKeyword
            //
            txtKeyword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKeyword.BorderStyle = BorderStyle.FixedSingle;
            txtKeyword.Font = new Font("Segoe UI", 10F);
            txtKeyword.Location = new Point(130, 15);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Nhập tên sự kiện, địa điểm...";
            txtKeyword.Size = new Size(552, 25);
            txtKeyword.TabIndex = 1;
            //
            // btnSearch
            //
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(37, 99, 235);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(700, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 34);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "🔍  Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            //
            // btnClear
            //
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = Color.White;
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(51, 65, 85);
            btnClear.Location = new Point(820, 12);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(114, 34);
            btnClear.TabIndex = 3;
            btnClear.Text = "✖  Xóa bộ lọc";
            btnClear.UseVisualStyleBackColor = false;
            //
            // chkFilterDate
            //
            chkFilterDate.AutoSize = true;
            chkFilterDate.Cursor = Cursors.Hand;
            chkFilterDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkFilterDate.ForeColor = Color.FromArgb(51, 65, 85);
            chkFilterDate.Location = new Point(18, 60);
            chkFilterDate.Name = "chkFilterDate";
            chkFilterDate.Size = new Size(105, 19);
            chkFilterDate.TabIndex = 4;
            chkFilterDate.Text = "📅 Từ ngày";
            chkFilterDate.UseVisualStyleBackColor = true;
            //
            // dtpFrom
            //
            dtpFrom.CustomFormat = "dd/MM/yyyy";
            dtpFrom.Font = new Font("Segoe UI", 9.5F);
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.Location = new Point(130, 56);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(140, 24);
            dtpFrom.TabIndex = 5;
            //
            // lblTo
            //
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTo.ForeColor = Color.FromArgb(51, 65, 85);
            lblTo.Location = new Point(285, 60);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(59, 15);
            lblTo.TabIndex = 6;
            lblTo.Text = "Đến ngày";
            //
            // dtpTo
            //
            dtpTo.CustomFormat = "dd/MM/yyyy";
            dtpTo.Font = new Font("Segoe UI", 9.5F);
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.Location = new Point(355, 56);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(140, 24);
            dtpTo.TabIndex = 7;
            //
            // spFilter
            //
            spFilter.Dock = DockStyle.Top;
            spFilter.Location = new Point(24, 178);
            spFilter.Name = "spFilter";
            spFilter.Size = new Size(952, 14);
            spFilter.TabIndex = 2;
            //
            // pnlActions
            //
            pnlActions.Controls.Add(lblCount);
            pnlActions.Controls.Add(btnViewDetail);
            pnlActions.Controls.Add(btnRegister);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(24, 594);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(952, 56);
            pnlActions.TabIndex = 4;
            //
            // lblCount
            //
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Segoe UI", 9F);
            lblCount.ForeColor = Color.FromArgb(100, 116, 139);
            lblCount.Location = new Point(2, 22);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(110, 15);
            lblCount.TabIndex = 0;
            lblCount.Text = "Tìm thấy 0 sự kiện";
            //
            // btnViewDetail
            //
            btnViewDetail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewDetail.BackColor = Color.White;
            btnViewDetail.Cursor = Cursors.Hand;
            btnViewDetail.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnViewDetail.FlatStyle = FlatStyle.Flat;
            btnViewDetail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnViewDetail.ForeColor = Color.FromArgb(51, 65, 85);
            btnViewDetail.Location = new Point(632, 12);
            btnViewDetail.Name = "btnViewDetail";
            btnViewDetail.Size = new Size(140, 36);
            btnViewDetail.TabIndex = 1;
            btnViewDetail.Text = "👁  Xem chi tiết";
            btnViewDetail.UseVisualStyleBackColor = false;
            //
            // btnRegister
            //
            btnRegister.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegister.BackColor = Color.FromArgb(22, 163, 74);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 128, 61);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(782, 12);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(170, 36);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "✔  Đăng ký tham gia";
            btnRegister.UseVisualStyleBackColor = false;
            //
            // pnlGridCard
            //
            pnlGridCard.BackColor = Color.White;
            pnlGridCard.Controls.Add(dgvEvents);
            pnlGridCard.Dock = DockStyle.Fill;
            pnlGridCard.Location = new Point(24, 192);
            pnlGridCard.Name = "pnlGridCard";
            pnlGridCard.Padding = new Padding(1, 1, 1, 1);
            pnlGridCard.Size = new Size(952, 402);
            pnlGridCard.TabIndex = 3;
            //
            // dgvEvents
            //
            dgvEvents.AllowUserToAddRows = false;
            dgvEvents.AllowUserToDeleteRows = false;
            dgvEvents.AllowUserToResizeRows = false;
            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvents.BackgroundColor = Color.White;
            dgvEvents.BorderStyle = BorderStyle.None;
            dgvEvents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEvents.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(248, 250, 252);
            headerStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(71, 85, 105);
            headerStyle.Padding = new Padding(8, 0, 0, 0);
            headerStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            headerStyle.SelectionForeColor = Color.FromArgb(71, 85, 105);
            headerStyle.WrapMode = DataGridViewTriState.True;
            dgvEvents.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvEvents.ColumnHeadersHeight = 42;
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEvents.Columns.AddRange(new DataGridViewColumn[] { colTitle, colStartDate, colLocation, colStatus, colSlot, colMyStatus });
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 9F);
            cellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            cellStyle.Padding = new Padding(8, 0, 0, 0);
            cellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            cellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            cellStyle.WrapMode = DataGridViewTriState.False;
            dgvEvents.DefaultCellStyle = cellStyle;
            dgvEvents.Dock = DockStyle.Fill;
            dgvEvents.EnableHeadersVisualStyles = false;
            dgvEvents.GridColor = Color.FromArgb(241, 245, 249);
            dgvEvents.Location = new Point(1, 1);
            dgvEvents.MultiSelect = false;
            dgvEvents.Name = "dgvEvents";
            dgvEvents.ReadOnly = true;
            dgvEvents.RowHeadersVisible = false;
            dgvEvents.RowTemplate.Height = 40;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvents.Size = new Size(950, 400);
            dgvEvents.TabIndex = 0;
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
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(pnlGridCard);
            Controls.Add(pnlActions);
            Controls.Add(spFilter);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
            Name = "ucTraCuuSuKien";
            Padding = new Padding(24, 20, 24, 14);
            Size = new Size(1000, 664);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlActions.ResumeLayout(false);
            pnlActions.PerformLayout();
            pnlGridCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlFilter;
        private Label lblKeyword;
        private TextBox txtKeyword;
        private Button btnSearch;
        private Button btnClear;
        private CheckBox chkFilterDate;
        private DateTimePicker dtpFrom;
        private Label lblTo;
        private DateTimePicker dtpTo;
        private Panel spFilter;
        private Panel pnlActions;
        private Label lblCount;
        private Button btnViewDetail;
        private Button btnRegister;
        private Panel pnlGridCard;
        private DataGridView dgvEvents;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colStartDate;
        private DataGridViewTextBoxColumn colLocation;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colSlot;
        private DataGridViewTextBoxColumn colMyStatus;
    }
}
