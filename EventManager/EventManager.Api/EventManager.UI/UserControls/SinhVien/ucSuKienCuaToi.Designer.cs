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
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dateStyle = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblFilter = new Label();
            cboFilter = new ComboBox();
            lblSubtitle = new Label();
            lblTitle = new Label();
            tlpCards = new TableLayoutPanel();
            cardTotal = new Panel();
            lblTotal = new Label();
            lblTotalCaption = new Label();
            lblTotalIcon = new Label();
            cardUpcoming = new Panel();
            lblUpcoming = new Label();
            lblUpcomingCaption = new Label();
            lblUpcomingIcon = new Label();
            cardAttended = new Panel();
            lblAttended = new Label();
            lblAttendedCaption = new Label();
            lblAttendedIcon = new Label();
            cardAbsent = new Panel();
            lblAbsent = new Label();
            lblAbsentCaption = new Label();
            lblAbsentIcon = new Label();
            spCards = new Panel();
            pnlActions = new Panel();
            btnRefresh = new Button();
            btnViewInfo = new Button();
            btnCancel = new Button();
            pnlGridCard = new Panel();
            dgvRegistrations = new DataGridView();
            colCode = new DataGridViewTextBoxColumn();
            colEvent = new DataGridViewTextBoxColumn();
            colStartDate = new DataGridViewTextBoxColumn();
            colLocation = new DataGridViewTextBoxColumn();
            colEventStatus = new DataGridViewTextBoxColumn();
            colConfirmation = new DataGridViewTextBoxColumn();
            colAttendance = new DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            tlpCards.SuspendLayout();
            cardTotal.SuspendLayout();
            cardUpcoming.SuspendLayout();
            cardAttended.SuspendLayout();
            cardAbsent.SuspendLayout();
            pnlActions.SuspendLayout();
            pnlGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegistrations).BeginInit();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.Controls.Add(lblFilter);
            pnlHeader.Controls.Add(cboFilter);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(24, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(952, 62);
            pnlHeader.TabIndex = 0;
            //
            // lblFilter
            //
            lblFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFilter.ForeColor = Color.FromArgb(51, 65, 85);
            lblFilter.Location = new Point(740, 16);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(54, 15);
            lblFilter.TabIndex = 2;
            lblFilter.Text = "Hiển thị:";
            //
            // cboFilter
            //
            cboFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilter.FlatStyle = FlatStyle.Flat;
            cboFilter.Font = new Font("Segoe UI", 9.5F);
            cboFilter.Location = new Point(802, 12);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(150, 25);
            cboFilter.TabIndex = 3;
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
            lblSubtitle.Text = "Xem thông tin đăng ký, hủy đăng ký và theo dõi trạng thái tham gia";
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(0, 4);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Sự kiện đã đăng ký";
            //
            // tlpCards
            //
            tlpCards.ColumnCount = 4;
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpCards.Controls.Add(cardTotal, 0, 0);
            tlpCards.Controls.Add(cardUpcoming, 1, 0);
            tlpCards.Controls.Add(cardAttended, 2, 0);
            tlpCards.Controls.Add(cardAbsent, 3, 0);
            tlpCards.Dock = DockStyle.Top;
            tlpCards.Location = new Point(24, 82);
            tlpCards.Name = "tlpCards";
            tlpCards.RowCount = 1;
            tlpCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpCards.Size = new Size(952, 80);
            tlpCards.TabIndex = 1;
            //
            // cardTotal
            //
            cardTotal.BackColor = Color.White;
            cardTotal.Controls.Add(lblTotal);
            cardTotal.Controls.Add(lblTotalCaption);
            cardTotal.Controls.Add(lblTotalIcon);
            cardTotal.Dock = DockStyle.Fill;
            cardTotal.Location = new Point(0, 0);
            cardTotal.Margin = new Padding(0, 0, 8, 0);
            cardTotal.Name = "cardTotal";
            cardTotal.Size = new Size(230, 80);
            cardTotal.TabIndex = 0;
            //
            // lblTotal
            //
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(15, 23, 42);
            lblTotal.Location = new Point(66, 32);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(28, 32);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "0";
            //
            // lblTotalCaption
            //
            lblTotalCaption.AutoSize = true;
            lblTotalCaption.Font = new Font("Segoe UI", 9F);
            lblTotalCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblTotalCaption.Location = new Point(68, 14);
            lblTotalCaption.Name = "lblTotalCaption";
            lblTotalCaption.Size = new Size(83, 15);
            lblTotalCaption.TabIndex = 1;
            lblTotalCaption.Text = "Đang đăng ký";
            //
            // lblTotalIcon
            //
            lblTotalIcon.BackColor = Color.FromArgb(239, 246, 255);
            lblTotalIcon.Font = new Font("Segoe UI", 14F);
            lblTotalIcon.ForeColor = Color.FromArgb(37, 99, 235);
            lblTotalIcon.Location = new Point(14, 18);
            lblTotalIcon.Name = "lblTotalIcon";
            lblTotalIcon.Size = new Size(44, 44);
            lblTotalIcon.TabIndex = 0;
            lblTotalIcon.Text = "📋";
            lblTotalIcon.TextAlign = ContentAlignment.MiddleCenter;
            //
            // cardUpcoming
            //
            cardUpcoming.BackColor = Color.White;
            cardUpcoming.Controls.Add(lblUpcoming);
            cardUpcoming.Controls.Add(lblUpcomingCaption);
            cardUpcoming.Controls.Add(lblUpcomingIcon);
            cardUpcoming.Dock = DockStyle.Fill;
            cardUpcoming.Location = new Point(246, 0);
            cardUpcoming.Margin = new Padding(8, 0, 8, 0);
            cardUpcoming.Name = "cardUpcoming";
            cardUpcoming.Size = new Size(222, 80);
            cardUpcoming.TabIndex = 1;
            //
            // lblUpcoming
            //
            lblUpcoming.AutoSize = true;
            lblUpcoming.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblUpcoming.ForeColor = Color.FromArgb(15, 23, 42);
            lblUpcoming.Location = new Point(66, 32);
            lblUpcoming.Name = "lblUpcoming";
            lblUpcoming.Size = new Size(28, 32);
            lblUpcoming.TabIndex = 2;
            lblUpcoming.Text = "0";
            //
            // lblUpcomingCaption
            //
            lblUpcomingCaption.AutoSize = true;
            lblUpcomingCaption.Font = new Font("Segoe UI", 9F);
            lblUpcomingCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblUpcomingCaption.Location = new Point(68, 14);
            lblUpcomingCaption.Name = "lblUpcomingCaption";
            lblUpcomingCaption.Size = new Size(72, 15);
            lblUpcomingCaption.TabIndex = 1;
            lblUpcomingCaption.Text = "Sắp diễn ra";
            //
            // lblUpcomingIcon
            //
            lblUpcomingIcon.BackColor = Color.FromArgb(255, 247, 237);
            lblUpcomingIcon.Font = new Font("Segoe UI", 14F);
            lblUpcomingIcon.ForeColor = Color.FromArgb(234, 88, 12);
            lblUpcomingIcon.Location = new Point(14, 18);
            lblUpcomingIcon.Name = "lblUpcomingIcon";
            lblUpcomingIcon.Size = new Size(44, 44);
            lblUpcomingIcon.TabIndex = 0;
            lblUpcomingIcon.Text = "🕒";
            lblUpcomingIcon.TextAlign = ContentAlignment.MiddleCenter;
            //
            // cardAttended
            //
            cardAttended.BackColor = Color.White;
            cardAttended.Controls.Add(lblAttended);
            cardAttended.Controls.Add(lblAttendedCaption);
            cardAttended.Controls.Add(lblAttendedIcon);
            cardAttended.Dock = DockStyle.Fill;
            cardAttended.Location = new Point(484, 0);
            cardAttended.Margin = new Padding(8, 0, 8, 0);
            cardAttended.Name = "cardAttended";
            cardAttended.Size = new Size(222, 80);
            cardAttended.TabIndex = 2;
            //
            // lblAttended
            //
            lblAttended.AutoSize = true;
            lblAttended.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAttended.ForeColor = Color.FromArgb(15, 23, 42);
            lblAttended.Location = new Point(66, 32);
            lblAttended.Name = "lblAttended";
            lblAttended.Size = new Size(28, 32);
            lblAttended.TabIndex = 2;
            lblAttended.Text = "0";
            //
            // lblAttendedCaption
            //
            lblAttendedCaption.AutoSize = true;
            lblAttendedCaption.Font = new Font("Segoe UI", 9F);
            lblAttendedCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblAttendedCaption.Location = new Point(68, 14);
            lblAttendedCaption.Name = "lblAttendedCaption";
            lblAttendedCaption.Size = new Size(72, 15);
            lblAttendedCaption.TabIndex = 1;
            lblAttendedCaption.Text = "Đã tham gia";
            //
            // lblAttendedIcon
            //
            lblAttendedIcon.BackColor = Color.FromArgb(240, 253, 244);
            lblAttendedIcon.Font = new Font("Segoe UI", 14F);
            lblAttendedIcon.ForeColor = Color.FromArgb(22, 163, 74);
            lblAttendedIcon.Location = new Point(14, 18);
            lblAttendedIcon.Name = "lblAttendedIcon";
            lblAttendedIcon.Size = new Size(44, 44);
            lblAttendedIcon.TabIndex = 0;
            lblAttendedIcon.Text = "✔️";
            lblAttendedIcon.TextAlign = ContentAlignment.MiddleCenter;
            //
            // cardAbsent
            //
            cardAbsent.BackColor = Color.White;
            cardAbsent.Controls.Add(lblAbsent);
            cardAbsent.Controls.Add(lblAbsentCaption);
            cardAbsent.Controls.Add(lblAbsentIcon);
            cardAbsent.Dock = DockStyle.Fill;
            cardAbsent.Location = new Point(722, 0);
            cardAbsent.Margin = new Padding(8, 0, 0, 0);
            cardAbsent.Name = "cardAbsent";
            cardAbsent.Size = new Size(230, 80);
            cardAbsent.TabIndex = 3;
            //
            // lblAbsent
            //
            lblAbsent.AutoSize = true;
            lblAbsent.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAbsent.ForeColor = Color.FromArgb(15, 23, 42);
            lblAbsent.Location = new Point(66, 32);
            lblAbsent.Name = "lblAbsent";
            lblAbsent.Size = new Size(28, 32);
            lblAbsent.TabIndex = 2;
            lblAbsent.Text = "0";
            //
            // lblAbsentCaption
            //
            lblAbsentCaption.AutoSize = true;
            lblAbsentCaption.Font = new Font("Segoe UI", 9F);
            lblAbsentCaption.ForeColor = Color.FromArgb(100, 116, 139);
            lblAbsentCaption.Location = new Point(68, 14);
            lblAbsentCaption.Name = "lblAbsentCaption";
            lblAbsentCaption.Size = new Size(34, 15);
            lblAbsentCaption.TabIndex = 1;
            lblAbsentCaption.Text = "Vắng";
            //
            // lblAbsentIcon
            //
            lblAbsentIcon.BackColor = Color.FromArgb(254, 242, 242);
            lblAbsentIcon.Font = new Font("Segoe UI", 14F);
            lblAbsentIcon.ForeColor = Color.FromArgb(220, 38, 38);
            lblAbsentIcon.Location = new Point(14, 18);
            lblAbsentIcon.Name = "lblAbsentIcon";
            lblAbsentIcon.Size = new Size(44, 44);
            lblAbsentIcon.TabIndex = 0;
            lblAbsentIcon.Text = "✖";
            lblAbsentIcon.TextAlign = ContentAlignment.MiddleCenter;
            //
            // spCards
            //
            spCards.Dock = DockStyle.Top;
            spCards.Location = new Point(24, 162);
            spCards.Name = "spCards";
            spCards.Size = new Size(952, 14);
            spCards.TabIndex = 2;
            //
            // pnlActions
            //
            pnlActions.Controls.Add(btnRefresh);
            pnlActions.Controls.Add(btnViewInfo);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(24, 594);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(952, 56);
            pnlActions.TabIndex = 4;
            //
            // btnRefresh
            //
            btnRefresh.BackColor = Color.White;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.FromArgb(51, 65, 85);
            btnRefresh.Location = new Point(0, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 36);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "🔄  Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            //
            // btnViewInfo
            //
            btnViewInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewInfo.BackColor = Color.White;
            btnViewInfo.Cursor = Cursors.Hand;
            btnViewInfo.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnViewInfo.FlatStyle = FlatStyle.Flat;
            btnViewInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnViewInfo.ForeColor = Color.FromArgb(51, 65, 85);
            btnViewInfo.Location = new Point(632, 12);
            btnViewInfo.Name = "btnViewInfo";
            btnViewInfo.Size = new Size(180, 36);
            btnViewInfo.TabIndex = 1;
            btnViewInfo.Text = "👁  Xem thông tin đăng ký";
            btnViewInfo.UseVisualStyleBackColor = false;
            //
            // btnCancel
            //
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(220, 38, 38);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(185, 28, 28);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(822, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 36);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "✖  Hủy đăng ký";
            btnCancel.UseVisualStyleBackColor = false;
            //
            // pnlGridCard
            //
            pnlGridCard.BackColor = Color.White;
            pnlGridCard.Controls.Add(dgvRegistrations);
            pnlGridCard.Dock = DockStyle.Fill;
            pnlGridCard.Location = new Point(24, 176);
            pnlGridCard.Name = "pnlGridCard";
            pnlGridCard.Padding = new Padding(1, 1, 1, 1);
            pnlGridCard.Size = new Size(952, 418);
            pnlGridCard.TabIndex = 3;
            //
            // dgvRegistrations
            //
            dgvRegistrations.AllowUserToAddRows = false;
            dgvRegistrations.AllowUserToDeleteRows = false;
            dgvRegistrations.AllowUserToResizeRows = false;
            dgvRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRegistrations.BackgroundColor = Color.White;
            dgvRegistrations.BorderStyle = BorderStyle.None;
            dgvRegistrations.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRegistrations.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(248, 250, 252);
            headerStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(71, 85, 105);
            headerStyle.Padding = new Padding(8, 0, 0, 0);
            headerStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            headerStyle.SelectionForeColor = Color.FromArgb(71, 85, 105);
            headerStyle.WrapMode = DataGridViewTriState.True;
            dgvRegistrations.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvRegistrations.ColumnHeadersHeight = 42;
            dgvRegistrations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRegistrations.Columns.AddRange(new DataGridViewColumn[] { colCode, colEvent, colStartDate, colLocation, colEventStatus, colConfirmation, colAttendance });
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 9F);
            cellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            cellStyle.Padding = new Padding(8, 0, 0, 0);
            cellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            cellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            cellStyle.WrapMode = DataGridViewTriState.False;
            dgvRegistrations.DefaultCellStyle = cellStyle;
            dgvRegistrations.Dock = DockStyle.Fill;
            dgvRegistrations.EnableHeadersVisualStyles = false;
            dgvRegistrations.GridColor = Color.FromArgb(241, 245, 249);
            dgvRegistrations.Location = new Point(1, 1);
            dgvRegistrations.MultiSelect = false;
            dgvRegistrations.Name = "dgvRegistrations";
            dgvRegistrations.ReadOnly = true;
            dgvRegistrations.RowHeadersVisible = false;
            dgvRegistrations.RowTemplate.Height = 40;
            dgvRegistrations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRegistrations.Size = new Size(950, 416);
            dgvRegistrations.TabIndex = 0;
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
            colEventStatus.HeaderText = "Tình trạng sự kiện";
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
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(pnlGridCard);
            Controls.Add(pnlActions);
            Controls.Add(spCards);
            Controls.Add(tlpCards);
            Controls.Add(pnlHeader);
            Name = "ucSuKienCuaToi";
            Padding = new Padding(24, 20, 24, 14);
            Size = new Size(1000, 664);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpCards.ResumeLayout(false);
            cardTotal.ResumeLayout(false);
            cardTotal.PerformLayout();
            cardUpcoming.ResumeLayout(false);
            cardUpcoming.PerformLayout();
            cardAttended.ResumeLayout(false);
            cardAttended.PerformLayout();
            cardAbsent.ResumeLayout(false);
            cardAbsent.PerformLayout();
            pnlActions.ResumeLayout(false);
            pnlGridCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRegistrations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblFilter;
        private ComboBox cboFilter;
        private TableLayoutPanel tlpCards;
        private Panel cardTotal;
        private Label lblTotalIcon;
        private Label lblTotalCaption;
        private Label lblTotal;
        private Panel cardUpcoming;
        private Label lblUpcomingIcon;
        private Label lblUpcomingCaption;
        private Label lblUpcoming;
        private Panel cardAttended;
        private Label lblAttendedIcon;
        private Label lblAttendedCaption;
        private Label lblAttended;
        private Panel cardAbsent;
        private Label lblAbsentIcon;
        private Label lblAbsentCaption;
        private Label lblAbsent;
        private Panel spCards;
        private Panel pnlActions;
        private Button btnRefresh;
        private Button btnViewInfo;
        private Button btnCancel;
        private Panel pnlGridCard;
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
