namespace EventManager.UI.UserControls.CanBo
{
    partial class ucQuanLyCongViec
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblSubtitle = new System.Windows.Forms.Label();
            btnRefresh = new System.Windows.Forms.Button();
            btnCreateTask = new System.Windows.Forms.Button();

            pnlCards = new System.Windows.Forms.TableLayoutPanel();
            cardTotal = new System.Windows.Forms.Panel();
            cardInProgress = new System.Windows.Forms.Panel();
            cardCompleted = new System.Windows.Forms.Panel();
            cardOverdue = new System.Windows.Forms.Panel();

            pnlAverageProgress = new System.Windows.Forms.Panel();
            lblAvgTitle = new System.Windows.Forms.Label();
            lblAvgPercent = new System.Windows.Forms.Label();

            pnlTabs = new System.Windows.Forms.Panel();
            btnTabAll = new System.Windows.Forms.Button();
            btnTabNotStarted = new System.Windows.Forms.Button();
            btnTabInProgress = new System.Windows.Forms.Button();
            btnTabCompleted = new System.Windows.Forms.Button();
            btnTabOnHold = new System.Windows.Forms.Button();

            pnlFilters = new System.Windows.Forms.Panel();
            cboEventFilter = new System.Windows.Forms.ComboBox();
            txtSearch = new System.Windows.Forms.TextBox();
            lblActionGuide = new System.Windows.Forms.Label();

            pnlGridCard = new System.Windows.Forms.Panel();
            dgvTasks = new System.Windows.Forms.DataGridView();
            colMaCv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCongViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSuKien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colNhanSu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colUuTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHanChot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTienDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colThaoTac = new System.Windows.Forms.DataGridViewTextBoxColumn();

            lblFooterCount = new System.Windows.Forms.Label();

            pnlHeader.SuspendLayout();
            pnlCards.SuspendLayout();
            pnlAverageProgress.SuspendLayout();
            pnlTabs.SuspendLayout();
            pnlFilters.SuspendLayout();
            pnlGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();

            // ── pnlHeader ──
            pnlHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlHeader.Location = new System.Drawing.Point(20, 12);
            pnlHeader.Size = new System.Drawing.Size(960, 48);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(btnCreateTask);

            lblTitle.Text = "Quản lý công việc";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.AutoSize = true;

            lblSubtitle.Text = "Lập kế hoạch sự kiện, phân công nhiệm vụ, theo dõi tiến độ và cập nhật trạng thái";
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new System.Drawing.Point(2, 28);
            lblSubtitle.AutoSize = true;

            btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRefresh.Text = "🔄  Làm mới";
            btnRefresh.Location = new System.Drawing.Point(670, 6);
            btnRefresh.Size = new System.Drawing.Size(100, 36);
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.BackColor = System.Drawing.Color.White;
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);

            btnCreateTask.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCreateTask.Text = "➕  Lập kế hoạch công việc";
            btnCreateTask.Location = new System.Drawing.Point(780, 6);
            btnCreateTask.Size = new System.Drawing.Size(180, 36);
            btnCreateTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCreateTask.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnCreateTask.ForeColor = System.Drawing.Color.White;
            btnCreateTask.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnCreateTask.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCreateTask.FlatAppearance.BorderSize = 0;

            // ── pnlCards (4 KPI Cards) ──
            pnlCards.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlCards.Location = new System.Drawing.Point(20, 68);
            pnlCards.Size = new System.Drawing.Size(960, 68);
            pnlCards.ColumnCount = 4;
            pnlCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            pnlCards.Controls.Add(cardTotal, 0, 0);
            pnlCards.Controls.Add(cardInProgress, 1, 0);
            pnlCards.Controls.Add(cardCompleted, 2, 0);
            pnlCards.Controls.Add(cardOverdue, 3, 0);

            cardTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            cardTotal.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            cardInProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            cardInProgress.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            cardCompleted.Dock = System.Windows.Forms.DockStyle.Fill;
            cardCompleted.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            cardOverdue.Dock = System.Windows.Forms.DockStyle.Fill;
            cardOverdue.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);

            // ── pnlAverageProgress ──
            pnlAverageProgress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlAverageProgress.Location = new System.Drawing.Point(20, 144);
            pnlAverageProgress.Size = new System.Drawing.Size(960, 48);
            pnlAverageProgress.BackColor = System.Drawing.Color.White;
            pnlAverageProgress.Controls.Add(lblAvgTitle);
            pnlAverageProgress.Controls.Add(lblAvgPercent);

            lblAvgTitle.Text = "📊  Tiến độ trung bình toàn bộ kế hoạch";
            lblAvgTitle.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            lblAvgTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblAvgTitle.Location = new System.Drawing.Point(14, 14);
            lblAvgTitle.AutoSize = true;

            lblAvgPercent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblAvgPercent.Text = "0%";
            lblAvgPercent.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblAvgPercent.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblAvgPercent.Location = new System.Drawing.Point(905, 12);
            lblAvgPercent.Size = new System.Drawing.Size(45, 24);
            lblAvgPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ── pnlTabs ──
            pnlTabs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlTabs.Location = new System.Drawing.Point(20, 202);
            pnlTabs.Size = new System.Drawing.Size(960, 36);
            pnlTabs.Controls.Add(btnTabAll);
            pnlTabs.Controls.Add(btnTabNotStarted);
            pnlTabs.Controls.Add(btnTabInProgress);
            pnlTabs.Controls.Add(btnTabCompleted);
            pnlTabs.Controls.Add(btnTabOnHold);

            int tabX = 0;
            void SetupTab(System.Windows.Forms.Button tab, string text, int w)
            {
                tab.Text = text;
                tab.Location = new System.Drawing.Point(tabX, 0);
                tab.Size = new System.Drawing.Size(w, 34);
                tab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                tab.FlatAppearance.BorderSize = 0;
                tab.Font = new System.Drawing.Font("Segoe UI", 9.25F);
                tab.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
                tab.BackColor = System.Drawing.Color.Transparent;
                tab.Cursor = System.Windows.Forms.Cursors.Hand;
                tabX += w + 8;
            }
            SetupTab(btnTabAll, "Tất cả (0)", 85);
            SetupTab(btnTabNotStarted, "Chưa bắt đầu (0)", 125);
            SetupTab(btnTabInProgress, "Đang thực hiện (0)", 135);
            SetupTab(btnTabCompleted, "Hoàn thành (0)", 115);
            SetupTab(btnTabOnHold, "Tạm hoãn (0)", 110);

            // ── pnlFilters ──
            pnlFilters.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlFilters.Location = new System.Drawing.Point(20, 244);
            pnlFilters.Size = new System.Drawing.Size(960, 36);
            pnlFilters.Controls.Add(cboEventFilter);
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Controls.Add(lblActionGuide);

            cboEventFilter.Location = new System.Drawing.Point(0, 3);
            cboEventFilter.Size = new System.Drawing.Size(180, 26);
            cboEventFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboEventFilter.Font = new System.Drawing.Font("Segoe UI", 9F);

            txtSearch.Location = new System.Drawing.Point(190, 3);
            txtSearch.Size = new System.Drawing.Size(260, 26);
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);

            lblActionGuide.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblActionGuide.Text = "Bấm các nút bên phải từng dòng để sửa, phân công hoặc cập nhật trạng thái";
            lblActionGuide.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            lblActionGuide.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblActionGuide.Location = new System.Drawing.Point(520, 8);
            lblActionGuide.Size = new System.Drawing.Size(440, 20);
            lblActionGuide.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ── pnlGridCard ──
            pnlGridCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlGridCard.Location = new System.Drawing.Point(20, 286);
            pnlGridCard.Size = new System.Drawing.Size(960, 345);
            pnlGridCard.BackColor = System.Drawing.Color.White;
            pnlGridCard.Controls.Add(dgvTasks);

            // ── dgvTasks ──
            dgvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvTasks.AllowUserToAddRows = false;
            dgvTasks.AllowUserToDeleteRows = false;
            dgvTasks.AllowUserToResizeRows = false;
            dgvTasks.BackgroundColor = System.Drawing.Color.White;
            dgvTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvTasks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTasks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvTasks.EnableHeadersVisualStyles = false;
            dgvTasks.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgvTasks.RowHeadersVisible = false;
            dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTasks.MultiSelect = false;
            dgvTasks.RowTemplate.Height = 52;
            dgvTasks.ColumnHeadersHeight = 40;

            var dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                BackColor = System.Drawing.Color.FromArgb(248, 250, 252),
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(71, 85, 105),
                Padding = new System.Windows.Forms.Padding(8, 0, 0, 0),
                WrapMode = System.Windows.Forms.DataGridViewTriState.True
            };
            dgvTasks.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;

            var dgvRowStyle = new System.Windows.Forms.DataGridViewCellStyle
            {
                Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft,
                BackColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 9F),
                ForeColor = System.Drawing.Color.FromArgb(30, 41, 59),
                Padding = new System.Windows.Forms.Padding(8, 0, 0, 0),
                SelectionBackColor = System.Drawing.Color.FromArgb(248, 250, 252),
                SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
            };
            dgvTasks.DefaultCellStyle = dgvRowStyle;

            colMaCv.HeaderText = "Mã CV";
            colMaCv.Name = "colMaCv";
            colMaCv.Width = 75;
            colMaCv.ReadOnly = true;

            colCongViec.HeaderText = "Công việc";
            colCongViec.Name = "colCongViec";
            colCongViec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colCongViec.FillWeight = 160F;
            colCongViec.ReadOnly = true;

            colSuKien.HeaderText = "Sự kiện";
            colSuKien.Name = "colSuKien";
            colSuKien.Width = 180;
            colSuKien.ReadOnly = true;

            colNhanSu.HeaderText = "Nhân sự phụ trách";
            colNhanSu.Name = "colNhanSu";
            colNhanSu.Width = 170;
            colNhanSu.ReadOnly = true;

            colUuTien.HeaderText = "Ưu tiên";
            colUuTien.Name = "colUuTien";
            colUuTien.Width = 90;
            colUuTien.ReadOnly = true;

            colHanChot.HeaderText = "Hạn chót";
            colHanChot.Name = "colHanChot";
            colHanChot.Width = 95;
            colHanChot.ReadOnly = true;

            colTienDo.HeaderText = "Tiến độ";
            colTienDo.Name = "colTienDo";
            colTienDo.Width = 110;
            colTienDo.ReadOnly = true;

            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.Name = "colTrangThai";
            colTrangThai.Width = 115;
            colTrangThai.ReadOnly = true;

            colThaoTac.HeaderText = "Thao tác";
            colThaoTac.Name = "colThaoTac";
            colThaoTac.Width = 115;
            colThaoTac.ReadOnly = true;

            dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                colMaCv, colCongViec, colSuKien, colNhanSu, colUuTien, colHanChot, colTienDo, colTrangThai, colThaoTac
            });

            // ── lblFooterCount ──
            lblFooterCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblFooterCount.Text = "Hiển thị 0 công việc";
            lblFooterCount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblFooterCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblFooterCount.Location = new System.Drawing.Point(22, 638);
            lblFooterCount.Size = new System.Drawing.Size(350, 20);

            // ── ucQuanLyCongViec ──
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            Controls.Add(pnlHeader);
            Controls.Add(pnlCards);
            Controls.Add(pnlAverageProgress);
            Controls.Add(pnlTabs);
            Controls.Add(pnlFilters);
            Controls.Add(pnlGridCard);
            Controls.Add(lblFooterCount);
            Size = new System.Drawing.Size(1000, 665);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCards.ResumeLayout(false);
            pnlAverageProgress.ResumeLayout(false);
            pnlAverageProgress.PerformLayout();
            pnlTabs.ResumeLayout(false);
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            pnlGridCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCreateTask;

        private System.Windows.Forms.TableLayoutPanel pnlCards;
        private System.Windows.Forms.Panel cardTotal;
        private System.Windows.Forms.Panel cardInProgress;
        private System.Windows.Forms.Panel cardCompleted;
        private System.Windows.Forms.Panel cardOverdue;

        private System.Windows.Forms.Panel pnlAverageProgress;
        private System.Windows.Forms.Label lblAvgTitle;
        private System.Windows.Forms.Label lblAvgPercent;

        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnTabAll;
        private System.Windows.Forms.Button btnTabNotStarted;
        private System.Windows.Forms.Button btnTabInProgress;
        private System.Windows.Forms.Button btnTabCompleted;
        private System.Windows.Forms.Button btnTabOnHold;

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.ComboBox cboEventFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblActionGuide;

        private System.Windows.Forms.Panel pnlGridCard;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaCv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCongViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSuKien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNhanSu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUuTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHanChot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTienDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThaoTac;

        private System.Windows.Forms.Label lblFooterCount;
    }
}
