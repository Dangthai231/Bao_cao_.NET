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
            dgvDocuments = new DataGridView();
            col1 = new DataGridViewTextBoxColumn();
            col2 = new DataGridViewTextBoxColumn();
            col3 = new DataGridViewTextBoxColumn();
            col4 = new DataGridViewTextBoxColumn();
            col5 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnDelete = new Button();
            btnExport = new Button();
            btnUpload = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDocuments).BeginInit();
            SuspendLayout();
            // 
            // dgvDocuments
            // 
            dgvDocuments.AllowUserToAddRows = false;
            dgvDocuments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDocuments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDocuments.Columns.AddRange(new DataGridViewColumn[] { col1, col2, col3, col4, col5 });
            dgvDocuments.Location = new Point(14, 40);
            dgvDocuments.Name = "dgvDocuments";
            dgvDocuments.Size = new Size(918, 385);
            dgvDocuments.TabIndex = 6;
            // 
            // col1
            // 
            col1.HeaderText = "Tên tài liệu";
            col1.Name = "col1";
            // 
            // col2
            // 
            col2.HeaderText = "Loại";
            col2.Name = "col2";
            // 
            // col3
            // 
            col3.HeaderText = "Kích thước";
            col3.Name = "col3";
            // 
            // col4
            // 
            col4.HeaderText = "Ngày tải lên";
            col4.Name = "col4";
            // 
            // col5
            // 
            col5.HeaderText = "Người tải";
            col5.Name = "col5";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(166, 20);
            label1.TabIndex = 5;
            label1.Text = "Quản lý tài liệu sự kiện";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Location = new Point(308, 437);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 32);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa tài liệu";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExport.Location = new Point(160, 437);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(130, 32);
            btnExport.TabIndex = 8;
            btnExport.Text = "Xuất tài liệu";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnUpload
            // 
            btnUpload.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnUpload.Location = new Point(14, 437);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(130, 32);
            btnUpload.TabIndex = 7;
            btnUpload.Text = "Tải lên tài liệu";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // ucQuanLyTaiLieu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvDocuments);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(btnExport);
            Controls.Add(btnUpload);
            Name = "ucQuanLyTaiLieu";
            Size = new Size(946, 482);
            ((System.ComponentModel.ISupportInitialize)dgvDocuments).EndInit();
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
        private Button btnDelete;
        private Button btnExport;
        private Button btnUpload;
    }
}
