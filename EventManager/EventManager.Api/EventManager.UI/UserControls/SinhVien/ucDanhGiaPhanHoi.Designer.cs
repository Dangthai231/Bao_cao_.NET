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
            DataGridViewCellStyle dateStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle starStyle = new DataGridViewCellStyle();
            lblTitle = new Label();
            grpForm = new GroupBox();
            lblEvent = new Label();
            cboEvent = new ComboBox();
            lblNoEvent = new Label();
            lblRating = new Label();
            cboRating = new ComboBox();
            lblComment = new Label();
            txtComment = new TextBox();
            btnSend = new Button();
            btnReset = new Button();
            lblHistory = new Label();
            pnlActions = new Panel();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvFeedbacks = new DataGridView();
            colEvent = new DataGridViewTextBoxColumn();
            colStars = new DataGridViewTextBoxColumn();
            colComment = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            grpForm.SuspendLayout();
            pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFeedbacks).BeginInit();
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
            lblTitle.Text = "ĐÁNH GIÁ VÀ PHẢN HỒI SỰ KIỆN";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // grpForm
            //
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
            grpForm.Location = new Point(0, 45);
            grpForm.Name = "grpForm";
            grpForm.Padding = new Padding(10);
            grpForm.Size = new Size(800, 190);
            grpForm.TabIndex = 1;
            grpForm.TabStop = false;
            grpForm.Text = "Gửi đánh giá";
            //
            // lblEvent
            //
            lblEvent.AutoSize = true;
            lblEvent.Location = new Point(15, 30);
            lblEvent.Name = "lblEvent";
            lblEvent.TabIndex = 0;
            lblEvent.Text = "Sự kiện:";
            //
            // cboEvent
            //
            cboEvent.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEvent.Location = new Point(140, 26);
            cboEvent.Name = "cboEvent";
            cboEvent.Size = new Size(360, 23);
            cboEvent.TabIndex = 1;
            //
            // lblNoEvent
            //
            lblNoEvent.AutoSize = true;
            lblNoEvent.ForeColor = Color.FromArgb(153, 27, 27);
            lblNoEvent.Location = new Point(510, 30);
            lblNoEvent.Name = "lblNoEvent";
            lblNoEvent.TabIndex = 2;
            lblNoEvent.Text = "Bạn chưa tham gia sự kiện nào đã diễn ra.";
            lblNoEvent.Visible = false;
            //
            // lblRating
            //
            lblRating.AutoSize = true;
            lblRating.Location = new Point(15, 63);
            lblRating.Name = "lblRating";
            lblRating.TabIndex = 3;
            lblRating.Text = "Mức độ hài lòng:";
            //
            // cboRating
            //
            cboRating.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRating.Font = new Font("Segoe UI", 10F);
            cboRating.ForeColor = Color.FromArgb(202, 138, 4);
            cboRating.Location = new Point(140, 59);
            cboRating.Name = "cboRating";
            cboRating.Size = new Size(260, 25);
            cboRating.TabIndex = 4;
            //
            // lblComment
            //
            lblComment.AutoSize = true;
            lblComment.Location = new Point(15, 98);
            lblComment.Name = "lblComment";
            lblComment.TabIndex = 5;
            lblComment.Text = "Nhận xét, góp ý:";
            //
            // txtComment
            //
            txtComment.Location = new Point(140, 95);
            txtComment.MaxLength = 1000;
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.PlaceholderText = "Chia sẻ cảm nhận của bạn về sự kiện...";
            txtComment.ScrollBars = ScrollBars.Vertical;
            txtComment.Size = new Size(500, 80);
            txtComment.TabIndex = 6;
            //
            // btnSend
            //
            btnSend.BackColor = Color.FromArgb(37, 99, 235);
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(660, 95);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(140, 32);
            btnSend.TabIndex = 7;
            btnSend.Text = "Gửi đánh giá";
            btnSend.UseVisualStyleBackColor = false;
            //
            // btnReset
            //
            btnReset.Location = new Point(660, 135);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(140, 32);
            btnReset.TabIndex = 8;
            btnReset.Text = "Nhập lại";
            btnReset.UseVisualStyleBackColor = true;
            //
            // lblHistory
            //
            lblHistory.Dock = DockStyle.Top;
            lblHistory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHistory.Location = new Point(0, 235);
            lblHistory.Name = "lblHistory";
            lblHistory.Padding = new Padding(10, 0, 0, 0);
            lblHistory.Size = new Size(800, 32);
            lblHistory.TabIndex = 2;
            lblHistory.Text = "Đánh giá bạn đã gửi";
            lblHistory.TextAlign = ContentAlignment.MiddleLeft;
            //
            // pnlActions
            //
            pnlActions.Controls.Add(btnEdit);
            pnlActions.Controls.Add(btnDelete);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 450);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(800, 50);
            pnlActions.TabIndex = 4;
            //
            // btnEdit
            //
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.Location = new Point(560, 10);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(110, 30);
            btnEdit.TabIndex = 0;
            btnEdit.Text = "Sửa đánh giá";
            btnEdit.UseVisualStyleBackColor = true;
            //
            // btnDelete
            //
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Location = new Point(680, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 30);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Xóa đánh giá";
            btnDelete.UseVisualStyleBackColor = true;
            //
            // dgvFeedbacks
            //
            dgvFeedbacks.AllowUserToAddRows = false;
            dgvFeedbacks.AllowUserToDeleteRows = false;
            dgvFeedbacks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFeedbacks.BackgroundColor = Color.White;
            dgvFeedbacks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFeedbacks.Columns.AddRange(new DataGridViewColumn[] { colEvent, colStars, colComment, colCreatedAt });
            dgvFeedbacks.Dock = DockStyle.Fill;
            dgvFeedbacks.Location = new Point(0, 267);
            dgvFeedbacks.MultiSelect = false;
            dgvFeedbacks.Name = "dgvFeedbacks";
            dgvFeedbacks.ReadOnly = true;
            dgvFeedbacks.RowHeadersVisible = false;
            dgvFeedbacks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFeedbacks.Size = new Size(800, 183);
            dgvFeedbacks.TabIndex = 3;
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
            starStyle.ForeColor = Color.FromArgb(202, 138, 4);
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
            // ucDanhGiaPhanHoi
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvFeedbacks);
            Controls.Add(pnlActions);
            Controls.Add(lblHistory);
            Controls.Add(grpForm);
            Controls.Add(lblTitle);
            Name = "ucDanhGiaPhanHoi";
            Size = new Size(800, 500);
            grpForm.ResumeLayout(false);
            grpForm.PerformLayout();
            pnlActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFeedbacks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private GroupBox grpForm;
        private Label lblEvent;
        private ComboBox cboEvent;
        private Label lblNoEvent;
        private Label lblRating;
        private ComboBox cboRating;
        private Label lblComment;
        private TextBox txtComment;
        private Button btnSend;
        private Button btnReset;
        private Label lblHistory;
        private Panel pnlActions;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvFeedbacks;
        private DataGridViewTextBoxColumn colEvent;
        private DataGridViewTextBoxColumn colStars;
        private DataGridViewTextBoxColumn colComment;
        private DataGridViewTextBoxColumn colCreatedAt;
    }
}
