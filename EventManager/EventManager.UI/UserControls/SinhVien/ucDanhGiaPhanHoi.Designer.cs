namespace EventManager.UI.UserControls.SinhVien
{
    partial class ucDanhGiaPhanHoi
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
            DataGridViewCellStyle starStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dateStyle = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            grpForm = new Panel();
            lblFormTitle = new Label();
            lblEvent = new Label();
            cboEvent = new ComboBox();
            lblNoEvent = new Label();
            lblRating = new Label();
            cboRating = new ComboBox();
            lblComment = new Label();
            txtComment = new TextBox();
            btnSend = new Button();
            btnReset = new Button();
            spForm = new Panel();
            pnlActions = new Panel();
            btnEdit = new Button();
            btnDelete = new Button();
            pnlGridCard = new Panel();
            dgvFeedbacks = new DataGridView();
            colEvent = new DataGridViewTextBoxColumn();
            colStars = new DataGridViewTextBoxColumn();
            colComment = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            lblHistory = new Label();
            pnlHeader.SuspendLayout();
            grpForm.SuspendLayout();
            pnlActions.SuspendLayout();
            pnlGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFeedbacks).BeginInit();
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
            lblSubtitle.Size = new Size(420, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Chia sẻ cảm nhận về các sự kiện bạn đã tham gia để Liên chi đoàn làm tốt hơn";
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(0, 4);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(230, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Đánh giá và phản hồi";
            //
            // grpForm
            //
            grpForm.BackColor = Color.White;
            grpForm.Controls.Add(lblFormTitle);
            grpForm.Controls.Add(lblEvent);
            grpForm.Controls.Add(cboEvent);
            grpForm.Controls.Add(lblNoEvent);
            grpForm.Controls.Add(lblRating);
            grpForm.Controls.Add(cboRating);
            grpForm.Controls.Add(lblComment);
            grpForm.Controls.Add(txtComment);
            grpForm.Controls.Add(btnSend);
            grpForm.Controls.Add(btnReset);
            grpForm.Dock = DockStyle.Top;
            grpForm.Location = new Point(24, 82);
            grpForm.Name = "grpForm";
            grpForm.Size = new Size(952, 206);
            grpForm.TabIndex = 1;
            //
            // lblFormTitle
            //
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblFormTitle.Location = new Point(16, 14);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(120, 19);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "✍  Gửi đánh giá";
            //
            // lblEvent
            //
            lblEvent.AutoSize = true;
            lblEvent.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEvent.ForeColor = Color.FromArgb(51, 65, 85);
            lblEvent.Location = new Point(18, 54);
            lblEvent.Name = "lblEvent";
            lblEvent.Size = new Size(50, 15);
            lblEvent.TabIndex = 1;
            lblEvent.Text = "Sự kiện";
            //
            // cboEvent
            //
            cboEvent.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEvent.FlatStyle = FlatStyle.Flat;
            cboEvent.Font = new Font("Segoe UI", 9.5F);
            cboEvent.Location = new Point(150, 50);
            cboEvent.Name = "cboEvent";
            cboEvent.Size = new Size(400, 25);
            cboEvent.TabIndex = 2;
            //
            // lblNoEvent
            //
            lblNoEvent.AutoSize = true;
            lblNoEvent.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblNoEvent.ForeColor = Color.FromArgb(220, 38, 38);
            lblNoEvent.Location = new Point(566, 54);
            lblNoEvent.Name = "lblNoEvent";
            lblNoEvent.Size = new Size(250, 15);
            lblNoEvent.TabIndex = 3;
            lblNoEvent.Text = "Bạn chưa tham gia sự kiện nào đã diễn ra.";
            lblNoEvent.Visible = false;
            //
            // lblRating
            //
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRating.ForeColor = Color.FromArgb(51, 65, 85);
            lblRating.Location = new Point(18, 90);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(100, 15);
            lblRating.TabIndex = 4;
            lblRating.Text = "Mức độ hài lòng";
            //
            // cboRating
            //
            cboRating.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRating.FlatStyle = FlatStyle.Flat;
            cboRating.Font = new Font("Segoe UI", 10F);
            cboRating.ForeColor = Color.FromArgb(202, 138, 4);
            cboRating.Location = new Point(150, 86);
            cboRating.Name = "cboRating";
            cboRating.Size = new Size(300, 25);
            cboRating.TabIndex = 5;
            //
            // lblComment
            //
            lblComment.AutoSize = true;
            lblComment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblComment.ForeColor = Color.FromArgb(51, 65, 85);
            lblComment.Location = new Point(18, 126);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(100, 15);
            lblComment.TabIndex = 6;
            lblComment.Text = "Nhận xét, góp ý";
            //
            // txtComment
            //
            txtComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtComment.BorderStyle = BorderStyle.FixedSingle;
            txtComment.Font = new Font("Segoe UI", 9.5F);
            txtComment.Location = new Point(150, 122);
            txtComment.MaxLength = 1000;
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.PlaceholderText = "Chia sẻ cảm nhận của bạn về sự kiện...";
            txtComment.ScrollBars = ScrollBars.Vertical;
            txtComment.Size = new Size(606, 68);
            txtComment.TabIndex = 7;
            //
            // btnSend
            //
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSend.BackColor = Color.FromArgb(37, 99, 235);
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(774, 120);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(160, 36);
            btnSend.TabIndex = 8;
            btnSend.Text = "Gửi đánh giá";
            btnSend.UseVisualStyleBackColor = false;
            //
            // btnReset
            //
            btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReset.BackColor = Color.White;
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReset.ForeColor = Color.FromArgb(51, 65, 85);
            btnReset.Location = new Point(774, 160);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(160, 30);
            btnReset.TabIndex = 9;
            btnReset.Text = "↺  Nhập lại";
            btnReset.UseVisualStyleBackColor = false;
            //
            // spForm
            //
            spForm.Dock = DockStyle.Top;
            spForm.Location = new Point(24, 288);
            spForm.Name = "spForm";
            spForm.Size = new Size(952, 14);
            spForm.TabIndex = 2;
            //
            // pnlActions
            //
            pnlActions.Controls.Add(btnEdit);
            pnlActions.Controls.Add(btnDelete);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(24, 594);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(952, 56);
            pnlActions.TabIndex = 4;
            //
            // btnEdit
            //
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = Color.White;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.ForeColor = Color.FromArgb(51, 65, 85);
            btnEdit.Location = new Point(672, 12);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(135, 36);
            btnEdit.TabIndex = 0;
            btnEdit.Text = "✏  Sửa đánh giá";
            btnEdit.UseVisualStyleBackColor = false;
            //
            // btnDelete
            //
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.FromArgb(220, 38, 38);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(185, 28, 28);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(817, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 36);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "🗑  Xóa đánh giá";
            btnDelete.UseVisualStyleBackColor = false;
            //
            // pnlGridCard
            //
            pnlGridCard.BackColor = Color.White;
            pnlGridCard.Controls.Add(dgvFeedbacks);
            pnlGridCard.Controls.Add(lblHistory);
            pnlGridCard.Dock = DockStyle.Fill;
            pnlGridCard.Location = new Point(24, 302);
            pnlGridCard.Name = "pnlGridCard";
            pnlGridCard.Padding = new Padding(1, 1, 1, 1);
            pnlGridCard.Size = new Size(952, 292);
            pnlGridCard.TabIndex = 3;
            //
            // dgvFeedbacks
            //
            dgvFeedbacks.AllowUserToAddRows = false;
            dgvFeedbacks.AllowUserToDeleteRows = false;
            dgvFeedbacks.AllowUserToResizeRows = false;
            dgvFeedbacks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFeedbacks.BackgroundColor = Color.White;
            dgvFeedbacks.BorderStyle = BorderStyle.None;
            dgvFeedbacks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvFeedbacks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(248, 250, 252);
            headerStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(71, 85, 105);
            headerStyle.Padding = new Padding(8, 0, 0, 0);
            headerStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            headerStyle.SelectionForeColor = Color.FromArgb(71, 85, 105);
            headerStyle.WrapMode = DataGridViewTriState.True;
            dgvFeedbacks.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvFeedbacks.ColumnHeadersHeight = 42;
            dgvFeedbacks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvFeedbacks.Columns.AddRange(new DataGridViewColumn[] { colEvent, colStars, colComment, colCreatedAt });
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 9F);
            cellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            cellStyle.Padding = new Padding(8, 0, 0, 0);
            cellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            cellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            cellStyle.WrapMode = DataGridViewTriState.False;
            dgvFeedbacks.DefaultCellStyle = cellStyle;
            dgvFeedbacks.Dock = DockStyle.Fill;
            dgvFeedbacks.EnableHeadersVisualStyles = false;
            dgvFeedbacks.GridColor = Color.FromArgb(241, 245, 249);
            dgvFeedbacks.Location = new Point(1, 41);
            dgvFeedbacks.MultiSelect = false;
            dgvFeedbacks.Name = "dgvFeedbacks";
            dgvFeedbacks.ReadOnly = true;
            dgvFeedbacks.RowHeadersVisible = false;
            dgvFeedbacks.RowTemplate.Height = 40;
            dgvFeedbacks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFeedbacks.Size = new Size(950, 250);
            dgvFeedbacks.TabIndex = 1;
            //
            // colEvent
            //
            colEvent.DataPropertyName = "EventTitle";
            colEvent.FillWeight = 140F;
            colEvent.HeaderText = "Sự kiện";
            colEvent.Name = "colEvent";
            colEvent.ReadOnly = true;
            //
            // colStars
            //
            colStars.DataPropertyName = "Stars";
            starStyle.Font = new Font("Segoe UI", 10F);
            starStyle.ForeColor = Color.FromArgb(202, 138, 4);
            starStyle.SelectionForeColor = Color.FromArgb(202, 138, 4);
            colStars.DefaultCellStyle = starStyle;
            colStars.FillWeight = 70F;
            colStars.HeaderText = "Đánh giá";
            colStars.Name = "colStars";
            colStars.ReadOnly = true;
            //
            // colComment
            //
            colComment.DataPropertyName = "Comment";
            colComment.FillWeight = 200F;
            colComment.HeaderText = "Nhận xét";
            colComment.Name = "colComment";
            colComment.ReadOnly = true;
            //
            // colCreatedAt
            //
            colCreatedAt.DataPropertyName = "CreatedAt";
            dateStyle.Format = "dd/MM/yyyy HH:mm";
            colCreatedAt.DefaultCellStyle = dateStyle;
            colCreatedAt.FillWeight = 80F;
            colCreatedAt.HeaderText = "Ngày gửi";
            colCreatedAt.Name = "colCreatedAt";
            colCreatedAt.ReadOnly = true;
            //
            // lblHistory
            //
            lblHistory.Dock = DockStyle.Top;
            lblHistory.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblHistory.ForeColor = Color.FromArgb(15, 23, 42);
            lblHistory.Location = new Point(1, 1);
            lblHistory.Name = "lblHistory";
            lblHistory.Padding = new Padding(14, 0, 0, 0);
            lblHistory.Size = new Size(950, 40);
            lblHistory.TabIndex = 0;
            lblHistory.Text = "🗂  Đánh giá bạn đã gửi";
            lblHistory.TextAlign = ContentAlignment.MiddleLeft;
            //
            // ucDanhGiaPhanHoi
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(pnlGridCard);
            Controls.Add(pnlActions);
            Controls.Add(spForm);
            Controls.Add(grpForm);
            Controls.Add(pnlHeader);
            Name = "ucDanhGiaPhanHoi";
            Padding = new Padding(24, 20, 24, 14);
            Size = new Size(1000, 664);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpForm.ResumeLayout(false);
            grpForm.PerformLayout();
            pnlActions.ResumeLayout(false);
            pnlGridCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFeedbacks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel grpForm;
        private Label lblFormTitle;
        private Label lblEvent;
        private ComboBox cboEvent;
        private Label lblNoEvent;
        private Label lblRating;
        private ComboBox cboRating;
        private Label lblComment;
        private TextBox txtComment;
        private Button btnSend;
        private Button btnReset;
        private Panel spForm;
        private Panel pnlActions;
        private Button btnEdit;
        private Button btnDelete;
        private Panel pnlGridCard;
        private Label lblHistory;
        private DataGridView dgvFeedbacks;
        private DataGridViewTextBoxColumn colEvent;
        private DataGridViewTextBoxColumn colStars;
        private DataGridViewTextBoxColumn colComment;
        private DataGridViewTextBoxColumn colCreatedAt;
    }
}
