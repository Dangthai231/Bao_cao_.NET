namespace EventManager.UI.UserControls
{
    partial class ucQuanLyTaiLieu
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
            DataGridViewCellStyle dgvHeaderStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dgvRowStyle = new DataGridViewCellStyle();
            dgvDocuments = new DataGridView();
            col1 = new DataGridViewTextBoxColumn();
            col2 = new DataGridViewTextBoxColumn();
            col3 = new DataGridViewTextBoxColumn();
            col4 = new DataGridViewTextBoxColumn();
            col5 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            lblSubtitle = new Label();
            pnlTableCard = new Panel();
            btnDelete = new Button();
            btnExport = new Button();
            btnUpload = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDocuments).BeginInit();
            pnlTableCard.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(15, 23, 42);
            label1.Location = new Point(20, 16);
            label1.Name = "label1";
            label1.Size = new Size(210, 25);
            label1.TabIndex = 5;
            label1.Text = "Quản lý tài liệu sự kiện";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(22, 44);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(300, 15);
            lblSubtitle.TabIndex = 10;
            lblSubtitle.Text = "Danh sách và quản lý các tài liệu, hồ sơ liên quan sự kiện";
            // 
            // pnlTableCard
            // 
            pnlTableCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlTableCard.BackColor = Color.White;
            pnlTableCard.Controls.Add(dgvDocuments);
            pnlTableCard.Location = new Point(20, 72);
            pnlTableCard.Name = "pnlTableCard";
            pnlTableCard.Padding = new Padding(1);
            pnlTableCard.Size = new Size(906, 350);
            pnlTableCard.TabIndex = 11;
            // 
            // dgvDocuments
            // 
            dgvDocuments.AllowUserToAddRows = false;
            dgvDocuments.AllowUserToDeleteRows = false;
            dgvDocuments.AllowUserToResizeRows = false;
            dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDocuments.BackgroundColor = Color.White;
            dgvDocuments.BorderStyle = BorderStyle.None;
            dgvDocuments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDocuments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvHeaderStyle.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            dgvHeaderStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvHeaderStyle.Padding = new Padding(10, 0, 0, 0);
            dgvHeaderStyle.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dgvHeaderStyle.SelectionForeColor = Color.FromArgb(71, 85, 105);
            dgvHeaderStyle.WrapMode = DataGridViewTriState.True;
            dgvDocuments.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            dgvDocuments.ColumnHeadersHeight = 42;
            dgvDocuments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDocuments.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col3, col4, col5 });
            dgvRowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyle.BackColor = Color.White;
            dgvRowStyle.Font = new Font("Segoe UI", 9.25F);
            dgvRowStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvRowStyle.Padding = new Padding(10, 0, 0, 0);
            dgvRowStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvRowStyle.SelectionForeColor = Color.FromArgb(29, 78, 216);
            dgvRowStyle.WrapMode = DataGridViewTriState.False;
            dgvDocuments.DefaultCellStyle = dgvRowStyle;
            dgvDocuments.Dock = DockStyle.Fill;
            dgvDocuments.EnableHeadersVisualStyles = false;
            dgvDocuments.GridColor = Color.FromArgb(241, 245, 249);
            dgvDocuments.Location = new Point(1, 1);
            dgvDocuments.MultiSelect = false;
            dgvDocuments.Name = "dgvDocuments";
            dgvDocuments.ReadOnly = true;
            dgvDocuments.RowHeadersVisible = false;
            dgvDocuments.RowTemplate.Height = 38;
            dgvDocuments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDocuments.Size = new Size(904, 348);
            dgvDocuments.TabIndex = 6;
            // 
            // col1
            // 
            col1.HeaderText = "Tên tài liệu";
            col1.Name = "col1";
            col1.ReadOnly = true;
            // 
            // col2
            // 
            col2.HeaderText = "Loại";
            col2.Name = "col2";
            col2.ReadOnly = true;
            // 
            // col3
            // 
            col3.HeaderText = "Kích thước";
            col3.Name = "col3";
            col3.ReadOnly = true;
            // 
            // col4
            // 
            col4.HeaderText = "Ngày tải lên";
            col4.Name = "col4";
            col4.ReadOnly = true;
            // 
            // col5
            // 
            col5.HeaderText = "Người tải";
            col5.Name = "col5";
            col5.ReadOnly = true;
            // 
            // btnUpload
            // 
            btnUpload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpload.BackColor = Color.FromArgb(37, 99, 235);
            btnUpload.Cursor = Cursors.Hand;
            btnUpload.FlatAppearance.BorderSize = 0;
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            btnUpload.ForeColor = Color.White;
            btnUpload.Location = new Point(20, 434);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(136, 36);
            btnUpload.TabIndex = 7;
            btnUpload.Text = "📤  Tải lên tài liệu";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExport.BackColor = Color.White;
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            btnExport.ForeColor = Color.FromArgb(51, 65, 85);
            btnExport.Location = new Point(166, 434);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(136, 36);
            btnExport.TabIndex = 8;
            btnExport.Text = "📊  Xuất tài liệu";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.BackColor = Color.FromArgb(254, 242, 242);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            btnDelete.ForeColor = Color.FromArgb(220, 38, 38);
            btnDelete.Location = new Point(312, 434);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 36);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "🗑️  Xóa tài liệu";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // ucQuanLyTaiLieu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(pnlTableCard);
            Controls.Add(lblSubtitle);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnExport);
            Controls.Add(btnUpload);
            Name = "ucQuanLyTaiLieu";
            Size = new Size(946, 482);
            ((System.ComponentModel.ISupportInitialize)dgvDocuments).EndInit();
            pnlTableCard.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDocuments;
        private DataGridViewTextBoxColumn col1;
        private DataGridViewTextBoxColumn col2;
        private DataGridViewTextBoxColumn col3;
        private DataGridViewTextBoxColumn col4;
        private DataGridViewTextBoxColumn col5;
        private Label label1;
        private Label lblSubtitle;
        private Panel pnlTableCard;
        private Button btnDelete;
        private Button btnExport;
        private Button btnUpload;
    }
}
