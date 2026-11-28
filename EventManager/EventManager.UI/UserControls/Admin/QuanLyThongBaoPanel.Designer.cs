using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.Admin
{
    partial class QuanLyThongBaoPanel
    {
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblTieuDe = new Label();
            lblMoTa = new Label();
            dgvThongBao = new DataGridView();
            pnlDanhSach = new Panel();
            pnlThaoTac = new TableLayoutPanel();
            pnlTrangThaiLoc = new Panel();
            lblTrangThaiLoc = new Label();
            cboTrangThaiLoc = new ComboBox();
            pnlTuKhoa = new Panel();
            txtTimKiem = new TextBox();
            lblTuKhoa = new Label();
            pnlTuNgay = new Panel();
            dtpTuNgay = new DateTimePicker();
            lblTuNgay = new Label();
            pnlDenNgay = new Panel();
            dtpDenNgay = new DateTimePicker();
            lblDenNgay = new Label();
            pnlDoiTuong = new Panel();
            cboDoiTuongLoc = new ComboBox();
            lblDoiTuong = new Label();
            pnlNutLoc = new FlowLayoutPanel();
            btnTimKiem = new Button();
            btnXoaLoc = new Button();
            pnlTieuDeDanhSach = new Panel();
            lblDanhSach = new Label();
            pnlLamMoiLoc = new Panel();
            btnLamMoi = new Button();
            btnTaoThongBao = new Button();
            pnlThongKe = new TableLayoutPanel();
            lblTong = new AdminMetricLabel();
            lblChoDuyet = new AdminMetricLabel();
            lblDaDuyet = new AdminMetricLabel();
            lblDaDang = new AdminMetricLabel();
            lblTrangThai = new Label();
            pnlSoTrang = AdminGridHelper.CreatePager();
            ((System.ComponentModel.ISupportInitialize)dgvThongBao).BeginInit();
            pnlDanhSach.SuspendLayout();
            pnlThaoTac.SuspendLayout();
            pnlTuKhoa.SuspendLayout();
            pnlTuNgay.SuspendLayout();
            pnlDenNgay.SuspendLayout();
            pnlDoiTuong.SuspendLayout();
            pnlNutLoc.SuspendLayout();
            pnlTieuDeDanhSach.SuspendLayout();
            pnlLamMoiLoc.SuspendLayout();
            pnlThongKe.SuspendLayout();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.Dock = DockStyle.Top;
            lblTieuDe.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 20);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(1002, 44);
            lblTieuDe.TabIndex = 3;
            lblTieuDe.Text = "Quản lý thông báo";
            // 
            // lblMoTa
            // 
            lblMoTa.Dock = DockStyle.Top;
            lblMoTa.ForeColor = Color.FromArgb(75, 94, 119);
            lblMoTa.Location = new Point(24, 64);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(1002, 26);
            lblMoTa.TabIndex = 2;
            lblMoTa.Text = "Soạn, duyệt và phát hành thông báo";
            // 
            // dgvThongBao
            // 
            dgvThongBao.AllowUserToAddRows = false;
            dgvThongBao.AllowUserToDeleteRows = false;
            dgvThongBao.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(242, 246, 250);
            dgvThongBao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvThongBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongBao.BackgroundColor = Color.White;
            dgvThongBao.BorderStyle = BorderStyle.FixedSingle;
            dgvThongBao.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(237, 243, 250);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(20, 40, 72);
            dataGridViewCellStyle2.Padding = new Padding(8, 3, 8, 3);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(225, 237, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(20, 40, 72);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvThongBao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvThongBao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(28, 46, 70);
            dataGridViewCellStyle3.Padding = new Padding(8, 2, 8, 2);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(225, 237, 252);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(20, 40, 72);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvThongBao.DefaultCellStyle = dataGridViewCellStyle3;
            dgvThongBao.Dock = DockStyle.Fill;
            dgvThongBao.EnableHeadersVisualStyles = false;
            dgvThongBao.GridColor = Color.FromArgb(227, 234, 243);
            dgvThongBao.Location = new Point(0, 0);
            dgvThongBao.MultiSelect = false;
            dgvThongBao.Name = "dgvThongBao";
            dgvThongBao.ReadOnly = true;
            dgvThongBao.RowHeadersVisible = false;
            dgvThongBao.RowHeadersWidth = 51;
            dgvThongBao.RowTemplate.Height = 39;
            dgvThongBao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongBao.Size = new Size(966, 226);
            dgvThongBao.TabIndex = 0;
            // 
            // pnlDanhSach
            // 
            pnlDanhSach.BackColor = Color.White;
            pnlDanhSach.Controls.Add(dgvThongBao);
            pnlDanhSach.Controls.Add(pnlThaoTac);
            pnlDanhSach.Controls.Add(pnlTieuDeDanhSach);
            pnlDanhSach.Dock = DockStyle.Fill;
            pnlDanhSach.Location = new Point(24, 186);
            pnlDanhSach.Name = "pnlDanhSach";
            pnlDanhSach.Padding = new Padding(14);
            pnlDanhSach.Size = new Size(1002, 422);
            pnlDanhSach.TabIndex = 0;
            // 
            // pnlThaoTac
            // 
            pnlThaoTac.BackColor = Color.FromArgb(243, 247, 252);
            pnlThaoTac.ColumnCount = 6;
            pnlThaoTac.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlThaoTac.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            pnlThaoTac.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            pnlThaoTac.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17F));
            pnlThaoTac.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            pnlThaoTac.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 84F));
            pnlThaoTac.Controls.Add(pnlTuKhoa, 0, 0);
            pnlThaoTac.Controls.Add(pnlTuNgay, 1, 0);
            pnlThaoTac.Controls.Add(pnlDenNgay, 2, 0);
            pnlThaoTac.Controls.Add(pnlTrangThaiLoc, 3, 0);
            pnlThaoTac.Controls.Add(pnlDoiTuong, 4, 0);
            pnlThaoTac.Controls.Add(pnlNutLoc, 5, 0);
            pnlThaoTac.Dock = DockStyle.Top;
            pnlThaoTac.Location = new Point(14, 62);
            pnlThaoTac.Name = "pnlThaoTac";
            pnlThaoTac.Padding = new Padding(12, 10, 12, 8);
            pnlThaoTac.RowCount = 2;
            pnlThaoTac.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            pnlThaoTac.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlThaoTac.Size = new Size(974, 82);
            pnlThaoTac.TabIndex = 1;
            // 
            // pnlTuKhoa
            // 
            pnlTuKhoa.Controls.Add(txtTimKiem);
            pnlTuKhoa.Controls.Add(lblTuKhoa);
            pnlTuKhoa.Dock = DockStyle.Fill;
            pnlTuKhoa.Location = new Point(12, 10);
            pnlTuKhoa.Margin = new Padding(0, 0, 16, 0);
            pnlTuKhoa.Name = "pnlTuKhoa";
            pnlTuKhoa.Size = new Size(268, 58);
            pnlTuKhoa.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            txtTimKiem.BackColor = Color.White;
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Dock = DockStyle.Top;
            txtTimKiem.ForeColor = Color.FromArgb(28, 46, 70);
            txtTimKiem.Location = new Point(0, 25);
            txtTimKiem.Margin = new Padding(0, 5, 10, 7);
            txtTimKiem.MinimumSize = new Size(145, 0);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tiêu đề, mã hoặc người tạo";
            txtTimKiem.Size = new Size(268, 30);
            txtTimKiem.TabIndex = 0;
            // 
            // lblTuKhoa
            // 
            lblTuKhoa.Dock = DockStyle.Top;
            lblTuKhoa.ForeColor = Color.FromArgb(65, 88, 116);
            lblTuKhoa.Location = new Point(0, 0);
            lblTuKhoa.Name = "lblTuKhoa";
            lblTuKhoa.Size = new Size(268, 25);
            lblTuKhoa.TabIndex = 1;
            lblTuKhoa.Text = "Từ khóa";
            // 
            // pnlTuNgay
            // 
            pnlTuNgay.Controls.Add(dtpTuNgay);
            pnlTuNgay.Controls.Add(lblTuNgay);
            pnlTuNgay.Dock = DockStyle.Fill;
            pnlTuNgay.Location = new Point(290, 10);
            pnlTuNgay.Margin = new Padding(0, 0, 12, 0);
            pnlTuNgay.Name = "pnlTuNgay";
            pnlTuNgay.Size = new Size(176, 58);
            pnlTuNgay.TabIndex = 1;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.AccessibleName = "Từ ngày";
            dtpTuNgay.Checked = false;
            dtpTuNgay.CustomFormat = "'Chưa chọn'";
            dtpTuNgay.Dock = DockStyle.Top;
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(0, 25);
            dtpTuNgay.Margin = new Padding(0, 5, 8, 6);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.ShowCheckBox = true;
            dtpTuNgay.Size = new Size(176, 30);
            dtpTuNgay.TabIndex = 0;
            // 
            // lblTuNgay
            // 
            lblTuNgay.Dock = DockStyle.Top;
            lblTuNgay.ForeColor = Color.FromArgb(65, 88, 116);
            lblTuNgay.Location = new Point(0, 0);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(176, 25);
            lblTuNgay.TabIndex = 1;
            lblTuNgay.Text = "Từ ngày";
            // 
            // pnlDenNgay
            // 
            pnlDenNgay.Controls.Add(dtpDenNgay);
            pnlDenNgay.Controls.Add(lblDenNgay);
            pnlDenNgay.Dock = DockStyle.Fill;
            pnlDenNgay.Location = new Point(472, 10);
            pnlDenNgay.Margin = new Padding(0, 0, 16, 0);
            pnlDenNgay.Name = "pnlDenNgay";
            pnlDenNgay.Size = new Size(172, 58);
            pnlDenNgay.TabIndex = 2;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.AccessibleName = "Đến ngày";
            dtpDenNgay.Checked = false;
            dtpDenNgay.CustomFormat = "'Chưa chọn'";
            dtpDenNgay.Dock = DockStyle.Top;
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(0, 25);
            dtpDenNgay.Margin = new Padding(0, 5, 8, 6);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.ShowCheckBox = true;
            dtpDenNgay.Size = new Size(172, 30);
            dtpDenNgay.TabIndex = 0;
            // 
            // lblDenNgay
            // 
            lblDenNgay.Dock = DockStyle.Top;
            lblDenNgay.ForeColor = Color.FromArgb(65, 88, 116);
            lblDenNgay.Location = new Point(0, 0);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(172, 25);
            lblDenNgay.TabIndex = 1;
            lblDenNgay.Text = "Đến ngày";
            // 
            // pnlTrangThaiLoc
            //
            pnlTrangThaiLoc.Name = "pnlTrangThaiLoc";
            pnlTrangThaiLoc.Dock = DockStyle.Fill;
            pnlTrangThaiLoc.Margin = new Padding(0, 0, 16, 0);
            pnlTrangThaiLoc.Controls.Add(cboTrangThaiLoc);
            pnlTrangThaiLoc.Controls.Add(lblTrangThaiLoc);
            lblTrangThaiLoc.Name = "lblTrangThaiLoc";
            lblTrangThaiLoc.Text = "Trạng thái";
            lblTrangThaiLoc.Dock = DockStyle.Top;
            lblTrangThaiLoc.Height = 25;
            lblTrangThaiLoc.ForeColor = Color.FromArgb(65, 88, 116);
            cboTrangThaiLoc.Name = "cboTrangThaiLoc";
            cboTrangThaiLoc.AccessibleName = "Lọc theo trạng thái";
            cboTrangThaiLoc.Dock = DockStyle.Top;
            cboTrangThaiLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThaiLoc.Items.AddRange(new object[] { "Tất cả", "Chờ duyệt", "Đã duyệt", "Đã đăng", "Từ chối", "Đã gỡ" });
            cboTrangThaiLoc.SelectedIndex = 0;
            //
            // pnlDoiTuong
            // 
            pnlDoiTuong.Controls.Add(cboDoiTuongLoc);
            pnlDoiTuong.Controls.Add(lblDoiTuong);
            pnlDoiTuong.Dock = DockStyle.Fill;
            pnlDoiTuong.Location = new Point(654, 10);
            pnlDoiTuong.Margin = new Padding(0, 0, 12, 0);
            pnlDoiTuong.Name = "pnlDoiTuong";
            pnlDoiTuong.Size = new Size(226, 58);
            pnlDoiTuong.TabIndex = 3;
            // 
            // cboDoiTuongLoc
            // 
            cboDoiTuongLoc.AccessibleName = "Đối tượng nhận";
            cboDoiTuongLoc.Dock = DockStyle.Top;
            cboDoiTuongLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDoiTuongLoc.Location = new Point(0, 25);
            cboDoiTuongLoc.Margin = new Padding(0, 5, 8, 6);
            cboDoiTuongLoc.Name = "cboDoiTuongLoc";
            cboDoiTuongLoc.Size = new Size(226, 31);
            cboDoiTuongLoc.TabIndex = 0;
            // 
            // lblDoiTuong
            // 
            lblDoiTuong.Dock = DockStyle.Top;
            lblDoiTuong.ForeColor = Color.FromArgb(65, 88, 116);
            lblDoiTuong.Location = new Point(0, 0);
            lblDoiTuong.Name = "lblDoiTuong";
            lblDoiTuong.Size = new Size(226, 25);
            lblDoiTuong.TabIndex = 1;
            lblDoiTuong.Text = "Đối tượng nhận";
            // 
            // pnlNutLoc
            // 
            pnlNutLoc.Controls.Add(btnTimKiem);
            pnlNutLoc.Controls.Add(btnXoaLoc);
            pnlNutLoc.Dock = DockStyle.Fill;
            pnlNutLoc.FlowDirection = FlowDirection.RightToLeft;
            pnlNutLoc.Location = new Point(880, 10);
            pnlNutLoc.Margin = new Padding(0);
            pnlNutLoc.Name = "pnlNutLoc";
            pnlNutLoc.Padding = new Padding(10, 28, 0, 0);
            pnlNutLoc.Size = new Size(82, 58);
            pnlNutLoc.TabIndex = 4;
            pnlNutLoc.WrapContents = false;
            // 
            // btnTimKiem
            // 
            btnTimKiem.AccessibleName = "Tìm thông báo";
            btnTimKiem.BackColor = Color.FromArgb(20, 40, 72);
            btnTimKiem.Cursor = Cursors.Hand;
            btnTimKiem.FlatAppearance.BorderColor = Color.FromArgb(219, 228, 239);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatAppearance.MouseOverBackColor = Color.FromArgb(31, 83, 145);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe MDL2 Assets", 10F);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(52, 28);
            btnTimKiem.Margin = new Padding(0);
            btnTimKiem.MinimumSize = new Size(0, 25);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(32, 25);
            btnTimKiem.TabIndex = 0;
            btnTimKiem.Text = "";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnXoaLoc
            // 
            btnXoaLoc.AccessibleName = "Xóa bộ lọc";
            btnXoaLoc.BackColor = Color.White;
            btnXoaLoc.Cursor = Cursors.Hand;
            btnXoaLoc.FlatAppearance.BorderColor = Color.FromArgb(219, 228, 239);
            btnXoaLoc.FlatStyle = FlatStyle.Flat;
            btnXoaLoc.Font = new Font("Segoe MDL2 Assets", 10F);
            btnXoaLoc.Location = new Point(10, 28);
            btnXoaLoc.Margin = new Padding(0, 0, 10, 0);
            btnXoaLoc.MinimumSize = new Size(0, 25);
            btnXoaLoc.Name = "btnXoaLoc";
            btnXoaLoc.Size = new Size(32, 25);
            btnXoaLoc.TabIndex = 1;
            btnXoaLoc.Text = "";
            btnXoaLoc.UseVisualStyleBackColor = false;
            // 
            // pnlTieuDeDanhSach
            // 
            pnlTieuDeDanhSach.Controls.Add(lblDanhSach);
            pnlTieuDeDanhSach.Controls.Add(pnlLamMoiLoc);
            pnlTieuDeDanhSach.Controls.Add(btnTaoThongBao);
            pnlTieuDeDanhSach.Dock = DockStyle.Top;
            pnlTieuDeDanhSach.Location = new Point(14, 14);
            pnlTieuDeDanhSach.Name = "pnlTieuDeDanhSach";
            pnlTieuDeDanhSach.Padding = new Padding(0, 0, 0, 10);
            pnlTieuDeDanhSach.Size = new Size(974, 48);
            pnlTieuDeDanhSach.TabIndex = 2;
            // 
            // lblDanhSach
            // 
            lblDanhSach.Dock = DockStyle.Fill;
            lblDanhSach.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDanhSach.Location = new Point(0, 0);
            lblDanhSach.Name = "lblDanhSach";
            lblDanhSach.Size = new Size(700, 38);
            lblDanhSach.TabIndex = 0;
            lblDanhSach.Text = "Danh sách thông báo";
            lblDanhSach.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlLamMoiLoc
            // 
            pnlLamMoiLoc.Controls.Add(btnLamMoi);
            pnlLamMoiLoc.Dock = DockStyle.Right;
            pnlLamMoiLoc.Location = new Point(700, 0);
            pnlLamMoiLoc.Margin = new Padding(0, 0, 8, 6);
            pnlLamMoiLoc.Name = "pnlLamMoiLoc";
            pnlLamMoiLoc.Padding = new Padding(8, 0, 8, 0);
            pnlLamMoiLoc.Size = new Size(104, 38);
            pnlLamMoiLoc.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.White;
            btnLamMoi.Dock = DockStyle.Fill;
            btnLamMoi.FlatAppearance.BorderColor = Color.FromArgb(219, 228, 239);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Location = new Point(8, 0);
            btnLamMoi.Margin = new Padding(0);
            btnLamMoi.MinimumSize = new Size(0, 25);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(88, 38);
            btnLamMoi.TabIndex = 0;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnTaoThongBao
            // 
            btnTaoThongBao.AutoSize = true;
            btnTaoThongBao.BackColor = Color.FromArgb(24, 98, 184);
            btnTaoThongBao.Cursor = Cursors.Hand;
            btnTaoThongBao.Dock = DockStyle.Right;
            btnTaoThongBao.FlatAppearance.BorderColor = Color.FromArgb(219, 228, 239);
            btnTaoThongBao.FlatAppearance.BorderSize = 0;
            btnTaoThongBao.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 75, 119);
            btnTaoThongBao.FlatStyle = FlatStyle.Flat;
            btnTaoThongBao.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTaoThongBao.ForeColor = Color.White;
            btnTaoThongBao.Location = new Point(804, 0);
            btnTaoThongBao.Margin = new Padding(0, 0, 10, 6);
            btnTaoThongBao.MinimumSize = new Size(144, 36);
            btnTaoThongBao.Name = "btnTaoThongBao";
            btnTaoThongBao.Padding = new Padding(8, 0, 8, 0);
            btnTaoThongBao.Size = new Size(170, 38);
            btnTaoThongBao.TabIndex = 2;
            btnTaoThongBao.Text = "+ Tạo thông báo";
            btnTaoThongBao.UseVisualStyleBackColor = false;
            // 
            // pnlThongKe
            // 
            pnlThongKe.ColumnCount = 4;
            pnlThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlThongKe.Controls.Add(lblTong, 0, 0);
            pnlThongKe.Controls.Add(lblChoDuyet, 1, 0);
            pnlThongKe.Controls.Add(lblDaDuyet, 2, 0);
            pnlThongKe.Controls.Add(lblDaDang, 3, 0);
            pnlThongKe.Dock = DockStyle.Top;
            pnlThongKe.Location = new Point(24, 90);
            pnlThongKe.Name = "pnlThongKe";
            pnlThongKe.RowCount = 1;
            pnlThongKe.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlThongKe.Size = new Size(1002, 96);
            pnlThongKe.TabIndex = 1;
            // 
            // lblTong
            // 
            lblTong.BackColor = Color.White;
            lblTong.Dock = DockStyle.Fill;
            lblTong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTong.ForeColor = Color.FromArgb(22, 99, 192);
            lblTong.Glyph = "";
            lblTong.Location = new Point(0, 4);
            lblTong.Margin = new Padding(0, 4, 10, 10);
            lblTong.Name = "lblTong";
            lblTong.Size = new Size(240, 82);
            lblTong.TabIndex = 0;
            lblTong.Text = "Thống kê 1";
            lblTong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblChoDuyet
            // 
            lblChoDuyet.BackColor = Color.White;
            lblChoDuyet.Dock = DockStyle.Fill;
            lblChoDuyet.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChoDuyet.ForeColor = Color.FromArgb(116, 76, 173);
            lblChoDuyet.Glyph = "";
            lblChoDuyet.Location = new Point(250, 4);
            lblChoDuyet.Margin = new Padding(0, 4, 10, 10);
            lblChoDuyet.Name = "lblChoDuyet";
            lblChoDuyet.Size = new Size(240, 82);
            lblChoDuyet.TabIndex = 1;
            lblChoDuyet.Text = "Thống kê 2";
            lblChoDuyet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDaDuyet
            // 
            lblDaDuyet.BackColor = Color.White;
            lblDaDuyet.Dock = DockStyle.Fill;
            lblDaDuyet.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDaDuyet.ForeColor = Color.FromArgb(10, 130, 89);
            lblDaDuyet.Glyph = "";
            lblDaDuyet.Location = new Point(500, 4);
            lblDaDuyet.Margin = new Padding(0, 4, 10, 10);
            lblDaDuyet.Name = "lblDaDuyet";
            lblDaDuyet.Size = new Size(240, 82);
            lblDaDuyet.TabIndex = 2;
            lblDaDuyet.Text = "Thống kê 3";
            lblDaDuyet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDaDang
            // 
            lblDaDang.BackColor = Color.White;
            lblDaDang.Dock = DockStyle.Fill;
            lblDaDang.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDaDang.ForeColor = Color.FromArgb(156, 93, 0);
            lblDaDang.Glyph = "";
            lblDaDang.Location = new Point(750, 4);
            lblDaDang.Margin = new Padding(0, 4, 0, 10);
            lblDaDang.Name = "lblDaDang";
            lblDaDang.Size = new Size(252, 82);
            lblDaDang.TabIndex = 3;
            lblDaDang.Text = "Thống kê 4";
            lblDaDang.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTrangThai
            // 
            lblTrangThai.Dock = DockStyle.Fill;
            lblTrangThai.ForeColor = Color.FromArgb(75, 94, 119);
            lblTrangThai.Location = new Point(24, 608);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(1002, 30);
            lblTrangThai.TabIndex = 4;
            lblTrangThai.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // QuanLyThongBaoPanel
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 246, 250);
            Controls.Add(pnlDanhSach);
            Controls.Add(pnlThongKe);
            Controls.Add(lblMoTa);
            Controls.Add(lblTieuDe);
            var pnlChanBang = new Panel { Dock = DockStyle.Bottom, Height = 40 };
            pnlChanBang.Controls.Add(lblTrangThai);
            pnlChanBang.Controls.Add(pnlSoTrang);
            Controls.Add(pnlChanBang);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.FromArgb(28, 46, 70);
            Name = "QuanLyThongBaoPanel";
            Padding = new Padding(24, 20, 24, 12);
            Size = new Size(1050, 650);
            ((System.ComponentModel.ISupportInitialize)dgvThongBao).EndInit();
            pnlDanhSach.ResumeLayout(false);
            pnlThaoTac.ResumeLayout(false);
            pnlTuKhoa.ResumeLayout(false);
            pnlTuKhoa.PerformLayout();
            pnlTuNgay.ResumeLayout(false);
            pnlDenNgay.ResumeLayout(false);
            pnlDoiTuong.ResumeLayout(false);
            pnlNutLoc.ResumeLayout(false);
            pnlTieuDeDanhSach.ResumeLayout(false);
            pnlTieuDeDanhSach.PerformLayout();
            pnlLamMoiLoc.ResumeLayout(false);
            pnlThongKe.ResumeLayout(false);
            ResumeLayout(false);
        }

        private DataGridView dgvThongBao;
        private Panel pnlDanhSach;
        private Panel pnlTieuDeDanhSach;
        private Label lblDanhSach;
        private TableLayoutPanel pnlThaoTac;
        private Panel pnlTrangThaiLoc;
        private Label lblTrangThaiLoc;
        private ComboBox cboTrangThaiLoc;
        private Panel pnlTuKhoa;
        private Label lblTuKhoa;
        private Panel pnlTuNgay;
        private Label lblTuNgay;
        private Panel pnlDenNgay;
        private Label lblDenNgay;
        private Panel pnlDoiTuong;
        private Label lblDoiTuong;
        private TableLayoutPanel pnlThongKe;
        private Label lblTrangThai;
        private FlowLayoutPanel pnlSoTrang;
        private TextBox txtTimKiem;
        private FlowLayoutPanel pnlNutLoc;
        private Button btnTimKiem;
        private Panel pnlLamMoiLoc;
        private Button btnLamMoi;
        private Button btnXoaLoc;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private ComboBox cboDoiTuongLoc;
        private Button btnTaoThongBao;
        private Label lblTieuDe;
        private Label lblMoTa;
        private AdminMetricLabel lblTong;
        private AdminMetricLabel lblChoDuyet;
        private AdminMetricLabel lblDaDuyet;
        private AdminMetricLabel lblDaDang;
    }
}
