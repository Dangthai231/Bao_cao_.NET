namespace EventManager.UI.UserControls.SinhVien
{
    partial class ucSuKienCuaToi
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
            pnlTop = new Panel();
            lblFilter = new Label();
            cboFilter = new ComboBox();
            lblTotal = new Label();
            lblUpcoming = new Label();
            lblAttended = new Label();
            lblAbsent = new Label();
            pnlActions = new Panel();
            btnRefresh = new Button();
            btnViewInfo = new Button();
            btnCancel = new Button();
            dgvRegistrations = new DataGridView();
            colCode = new DataGridViewTextBoxColumn();
            colEvent = new DataGridViewTextBoxColumn();
            colStartDate = new DataGridViewTextBoxColumn();
            colLocation = new DataGridViewTextBoxColumn();
            colEventStatus = new DataGridViewTextBoxColumn();
            colConfirmation = new DataGridViewTextBoxColumn();
            colAttendance = new DataGridViewTextBoxColumn();
            pnlTop.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistrations).BeginInit();
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
            lblTitle.Text = "SỰ KIỆN ĐÃ ĐĂNG KÝ";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pnlTop
            //
            pnlTop.Controls.Add(lblFilter);
            pnlTop.Controls.Add(cboFilter);
            pnlTop.Controls.Add(lblTotal);
            pnlTop.Controls.Add(lblUpcoming);
            pnlTop.Controls.Add(lblAttended);
            pnlTop.Controls.Add(lblAbsent);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 45);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(800, 45);
            pnlTop.TabIndex = 1;
            //
            // lblFilter
            //
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(12, 14);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(39, 15);
            lblFilter.TabIndex = 0;
            lblFilter.Text = "Hiển thị:";
            //
            // cboFilter
            //
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilter.Location = new Point(75, 10);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(140, 23);
            cboFilter.TabIndex = 1;
            //
            // lblTotal
            //
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotal.Location = new Point(240, 14);
            lblTotal.Name = "lblTotal";
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Đang đăng ký: 0";
            //
            // lblUpcoming
            //
            lblUpcoming.AutoSize = true;
            lblUpcoming.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUpcoming.ForeColor = Color.FromArgb(30, 64, 175);
            lblUpcoming.Location = new Point(370, 14);
            lblUpcoming.Name = "lblUpcoming";
            lblUpcoming.TabIndex = 3;
            lblUpcoming.Text = "Sắp diễn ra: 0";
            //
            // lblAttended
            //
            lblAttended.AutoSize = true;
            lblAttended.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAttended.ForeColor = Color.FromArgb(22, 101, 52);
            lblAttended.Location = new Point(490, 14);
            lblAttended.Name = "lblAttended";
            lblAttended.TabIndex = 4;
            lblAttended.Text = "Đã tham gia: 0";
            //
            // lblAbsent
            //
            lblAbsent.AutoSize = true;
            lblAbsent.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAbsent.ForeColor = Color.FromArgb(153, 27, 27);
            lblAbsent.Location = new Point(610, 14);
            lblAbsent.Name = "lblAbsent";
            lblAbsent.TabIndex = 5;
            lblAbsent.Text = "Vắng: 0";
            //
            // pnlActions
            //
            pnlActions.Controls.Add(btnRefresh);
            pnlActions.Controls.Add(btnViewInfo);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 450);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(800, 50);
            pnlActions.TabIndex = 3;
            //
            // btnRefresh
            //
            btnRefresh.Location = new Point(12, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            //
            // btnViewInfo
            //
            btnViewInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewInfo.Location = new Point(520, 10);
            btnViewInfo.Name = "btnViewInfo";
            btnViewInfo.Size = new Size(140, 30);
            btnViewInfo.TabIndex = 1;
            btnViewInfo.Text = "Xem thông tin đăng ký";
            btnViewInfo.UseVisualStyleBackColor = true;
            //
            // btnCancel
            //
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(220, 38, 38);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(670, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 30);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Hủy đăng ký";
            btnCancel.UseVisualStyleBackColor = false;
            //
            // dgvRegistrations
            //
            dgvRegistrations.AllowUserToAddRows = false;
            dgvRegistrations.AllowUserToDeleteRows = false;
            dgvRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRegistrations.BackgroundColor = Color.White;
            dgvRegistrations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistrations.Columns.AddRange(new DataGridViewColumn[] { colCode, colEvent, colStartDate, colLocation, colEventStatus, colConfirmation, colAttendance });
            dgvRegistrations.Dock = DockStyle.Fill;
            dgvRegistrations.Location = new Point(0, 90);
            dgvRegistrations.MultiSelect = false;
            dgvRegistrations.Name = "dgvRegistrations";
            dgvRegistrations.ReadOnly = true;
            dgvRegistrations.RowHeadersVisible = false;
            dgvRegistrations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistrations.Size = new Size(800, 360);
            dgvRegistrations.TabIndex = 2;
            //
            // colCode
            //
            colCode.DataPropertyName = "ParticipantCode";
            colCode.FillWeight = 60F;
            colCode.HeaderText = "Mã ĐK";
            colCode.Name = "colCode";
            colCode.ReadOnly = true;
            //
            // colEvent
            //
            colEvent.DataPropertyName = "EventTitle";
            colEvent.FillWeight = 170F;
            colEvent.HeaderText = "Sự kiện";
            colEvent.Name = "colEvent";
            colEvent.ReadOnly = true;
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
            colLocation.FillWeight = 130F;
            colLocation.HeaderText = "Địa điểm";
            colLocation.Name = "colLocation";
            colLocation.ReadOnly = true;
            //
            // colEventStatus
            //
            colEventStatus.DataPropertyName = "EventStatus";
            colEventStatus.HeaderText = "Sự kiện";
            colEventStatus.Name = "colEventStatus";
            colEventStatus.ReadOnly = true;
            //
            // colConfirmation
            //
            colConfirmation.DataPropertyName = "ConfirmationStatus";
            colConfirmation.HeaderText = "Đăng ký";
            colConfirmation.Name = "colConfirmation";
            colConfirmation.ReadOnly = true;
            //
            // colAttendance
            //
            colAttendance.DataPropertyName = "AttendanceStatus";
            colAttendance.HeaderText = "Trạng thái tham gia";
            colAttendance.Name = "colAttendance";
            colAttendance.ReadOnly = true;
            //
            // ucSuKienCuaToi
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvRegistrations);
            Controls.Add(pnlActions);
            Controls.Add(pnlTop);
            Controls.Add(lblTitle);
            Name = "ucSuKienCuaToi";
            Size = new Size(800, 500);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRegistrations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Panel pnlTop;
        private Label lblFilter;
        private ComboBox cboFilter;
        private Label lblTotal;
        private Label lblUpcoming;
        private Label lblAttended;
        private Label lblAbsent;
        private Panel pnlActions;
        private Button btnRefresh;
        private Button btnViewInfo;
        private Button btnCancel;
        private DataGridView dgvRegistrations;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colEvent;
        private DataGridViewTextBoxColumn colStartDate;
        private DataGridViewTextBoxColumn colLocation;
        private DataGridViewTextBoxColumn colEventStatus;
        private DataGridViewTextBoxColumn colConfirmation;
        private DataGridViewTextBoxColumn colAttendance;
    }
}
