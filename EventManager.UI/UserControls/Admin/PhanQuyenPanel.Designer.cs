namespace EventManager.UI.UserControls.Admin
{
    partial class PhanQuyenPanel
    {
        private TableLayoutPanel layNoiDung;
        private Panel pnlDanhSach;
        private Panel pnlQuyen;
        private Label lblDanhSach;
        private Label lblLocVaiTro;
        private ListBox lstTaiKhoan;
        private TableLayoutPanel pnlTimKiem;
        private Label lblBieuTuongTimKiem;
        private TextBox txtTimKiem;
        private ComboBox cboVaiTro;
        private Label lblTaiKhoan;
        private Label lblTrangThai;
        private TabControl tabQuyen;
        private TabPage tabCapQuyen;
        private TabPage tabTraCuu;
        private FlowLayoutPanel pnlDanhSachQuyen;
        private ListView lstTraCuu;
        private Label lblTomTatQuyen;
        private Panel pnlThaoTac;
        private Button btnLuuQuyen;
        private Button btnChonTatCa;
        private Button btnTaiLai;

        private void InitializeComponent()
        {
            layNoiDung = new TableLayoutPanel();
            pnlDanhSach = new Panel();
            pnlQuyen = new Panel();
            lblDanhSach = new Label();
            lblLocVaiTro = new Label();
            lstTaiKhoan = new ListBox();
            pnlTimKiem = new TableLayoutPanel();
            lblBieuTuongTimKiem = new Label();
            txtTimKiem = new TextBox();
            cboVaiTro = new ComboBox();
            lblTaiKhoan = new Label();
            lblTrangThai = new Label();
            tabQuyen = new TabControl();
            tabCapQuyen = new TabPage();
            tabTraCuu = new TabPage();
            pnlDanhSachQuyen = new FlowLayoutPanel();
            lstTraCuu = new ListView();
            lblTomTatQuyen = new Label();
            pnlThaoTac = new Panel();
            btnLuuQuyen = new Button();
            btnChonTatCa = new Button();
            btnTaiLai = new Button();

            SuspendLayout();
            layNoiDung.SuspendLayout();
            pnlDanhSach.SuspendLayout();
            pnlQuyen.SuspendLayout();
            tabQuyen.SuspendLayout();
            tabCapQuyen.SuspendLayout();
            tabTraCuu.SuspendLayout();

            layNoiDung.Name = "layNoiDung";
            layNoiDung.Dock = DockStyle.Fill;
            layNoiDung.ColumnCount = 2;
            layNoiDung.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            layNoiDung.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            layNoiDung.RowCount = 1;
            layNoiDung.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            pnlDanhSach.Name = "pnlDanhSach";
            pnlDanhSach.Dock = DockStyle.Fill;
            pnlDanhSach.Margin = new Padding(0, 0, 12, 0);
            pnlDanhSach.Padding = new Padding(14);
            pnlDanhSach.BackColor = Color.White;

            lblDanhSach.Name = "lblDanhSach";
            lblDanhSach.Text = "Tài khoản";
            lblDanhSach.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDanhSach.Dock = DockStyle.Top;
            lblDanhSach.Height = 34;

            pnlTimKiem.Name = "pnlTimKiem";
            pnlTimKiem.Dock = DockStyle.Top;
            pnlTimKiem.Height = 36;
            pnlTimKiem.Padding = new Padding(1);
            pnlTimKiem.BackColor = Color.White;
            pnlTimKiem.ColumnCount = 2;
            pnlTimKiem.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 34));
            pnlTimKiem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pnlTimKiem.RowCount = 1;
            pnlTimKiem.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlTimKiem.Paint += pnlTimKiem_Paint;

            lblBieuTuongTimKiem.Name = "lblBieuTuongTimKiem";
            lblBieuTuongTimKiem.Dock = DockStyle.Fill;
            lblBieuTuongTimKiem.Margin = new Padding(0);
            lblBieuTuongTimKiem.Font = new Font("Segoe MDL2 Assets", 11F);
            lblBieuTuongTimKiem.Text = "\uE721";
            lblBieuTuongTimKiem.TextAlign = ContentAlignment.MiddleCenter;
            lblBieuTuongTimKiem.ForeColor = Color.FromArgb(71, 85, 105);
            lblBieuTuongTimKiem.Cursor = Cursors.IBeam;
            lblBieuTuongTimKiem.Click += (_, _) => txtTimKiem.Focus();

            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.Margin = new Padding(0, 0, 8, 0);
            txtTimKiem.PlaceholderText = "Mã, họ tên hoặc tên đăng nhập";
            txtTimKiem.AccessibleName = "Tìm tài khoản";
            txtTimKiem.BorderStyle = BorderStyle.None;
            txtTimKiem.GotFocus += (_, _) => pnlTimKiem.Invalidate();
            txtTimKiem.LostFocus += (_, _) => pnlTimKiem.Invalidate();
            pnlTimKiem.Controls.Add(lblBieuTuongTimKiem, 0, 0);
            pnlTimKiem.Controls.Add(txtTimKiem, 1, 0);

            lblLocVaiTro.Name = "lblLocVaiTro";
            lblLocVaiTro.Text = "Vai trò";
            lblLocVaiTro.Dock = DockStyle.Top;
            lblLocVaiTro.Height = 30;
            lblLocVaiTro.TextAlign = ContentAlignment.BottomLeft;
            lblLocVaiTro.Padding = new Padding(0, 0, 0, 4);

            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Dock = DockStyle.Top;
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVaiTro.AccessibleName = "Lọc theo vai trò";

            lstTaiKhoan.Name = "lstTaiKhoan";
            lstTaiKhoan.Dock = DockStyle.Fill;
            lstTaiKhoan.DrawMode = DrawMode.OwnerDrawFixed;
            lstTaiKhoan.ItemHeight = 48;
            lstTaiKhoan.IntegralHeight = false;
            lstTaiKhoan.AccessibleName = "Danh sách tài khoản";
            lstTaiKhoan.BorderStyle = BorderStyle.FixedSingle;
            lstTaiKhoan.BackColor = Color.FromArgb(248, 250, 253);
            lstTaiKhoan.DrawItem += lstTaiKhoan_DrawItem;

            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Text = "Tải lại danh sách";
            btnTaiLai.Dock = DockStyle.Bottom;
            btnTaiLai.Height = 34;
            btnTaiLai.FlatStyle = FlatStyle.Flat;
            btnTaiLai.FlatAppearance.BorderColor = Color.FromArgb(219, 228, 239);
            btnTaiLai.BackColor = Color.FromArgb(242, 246, 250);
            btnTaiLai.UseVisualStyleBackColor = false;
            btnTaiLai.Cursor = Cursors.Hand;

            pnlDanhSach.Controls.Add(lstTaiKhoan);
            pnlDanhSach.Controls.Add(btnTaiLai);
            pnlDanhSach.Controls.Add(cboVaiTro);
            pnlDanhSach.Controls.Add(lblLocVaiTro);
            pnlDanhSach.Controls.Add(pnlTimKiem);
            pnlDanhSach.Controls.Add(lblDanhSach);

            pnlQuyen.Name = "pnlQuyen";
            pnlQuyen.Dock = DockStyle.Fill;
            pnlQuyen.Margin = new Padding(0);
            pnlQuyen.Padding = new Padding(14);
            pnlQuyen.BackColor = Color.White;

            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Dock = DockStyle.Top;
            lblTaiKhoan.Height = 44;
            lblTaiKhoan.AutoEllipsis = true;
            lblTaiKhoan.Text = "Chọn tài khoản để xem quyền";
            lblTaiKhoan.TextAlign = ContentAlignment.MiddleLeft;
            lblTaiKhoan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            tabQuyen.Name = "tabQuyen";
            tabQuyen.Dock = DockStyle.Fill;
            tabQuyen.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabQuyen.Padding = new Point(12, 7);
            tabQuyen.DrawItem += AdminGridHelper.DrawTab;

            tabCapQuyen.Name = "tabCapQuyen";
            tabCapQuyen.Text = "Cấp và thay đổi quyền";
            tabCapQuyen.Padding = new Padding(12);
            tabCapQuyen.BackColor = Color.White;

            tabTraCuu.Name = "tabTraCuu";
            tabTraCuu.Text = "Quyền hiện tại";
            tabTraCuu.Padding = new Padding(12);
            tabTraCuu.BackColor = Color.White;

            pnlDanhSachQuyen.Name = "pnlDanhSachQuyen";
            pnlDanhSachQuyen.Dock = DockStyle.Fill;
            pnlDanhSachQuyen.FlowDirection = FlowDirection.LeftToRight;
            pnlDanhSachQuyen.WrapContents = true;
            pnlDanhSachQuyen.AutoScroll = true;
            pnlDanhSachQuyen.AccessibleName = "Quyền chức năng";

            lstTraCuu.Name = "lstTraCuu";
            lstTraCuu.Dock = DockStyle.Fill;
            lstTraCuu.View = View.Details;
            lstTraCuu.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstTraCuu.FullRowSelect = true;
            lstTraCuu.MultiSelect = false;
            lstTraCuu.ShowItemToolTips = true;
            lstTraCuu.AccessibleName = "Trạng thái quyền chức năng";
            lstTraCuu.BorderStyle = BorderStyle.FixedSingle;
            lstTraCuu.BackColor = Color.White;
            lstTraCuu.Columns.Add("Chức năng", 280);
            lstTraCuu.Columns.Add("Quyền truy cập", 144);
            lstTraCuu.Resize += (_, _) => CanCotQuyen();

            lblTomTatQuyen.Dock = DockStyle.Top;
            lblTomTatQuyen.Height = 42;
            lblTomTatQuyen.ForeColor = Color.FromArgb(71, 85, 105);
            lblTomTatQuyen.TextAlign = ContentAlignment.MiddleLeft;

            pnlThaoTac.Name = "pnlThaoTac";
            pnlThaoTac.Dock = DockStyle.Bottom;
            pnlThaoTac.Height = 48;
            pnlThaoTac.Padding = new Padding(0, 12, 0, 0);

            btnChonTatCa.Name = "btnChonTatCa";
            btnChonTatCa.Text = "Chọn / bỏ chọn tất cả";
            btnChonTatCa.Dock = DockStyle.Left;
            btnChonTatCa.Width = 156;
            btnChonTatCa.FlatStyle = FlatStyle.Flat;
            btnChonTatCa.FlatAppearance.BorderColor = Color.FromArgb(219, 228, 239);
            btnChonTatCa.BackColor = Color.White;
            btnChonTatCa.UseVisualStyleBackColor = false;
            btnChonTatCa.Cursor = Cursors.Hand;

            btnLuuQuyen.Name = "btnLuuQuyen";
            btnLuuQuyen.Text = "Cấp quyền";
            btnLuuQuyen.Dock = DockStyle.Right;
            btnLuuQuyen.Width = 136;
            btnLuuQuyen.FlatStyle = FlatStyle.Flat;
            btnLuuQuyen.FlatAppearance.BorderSize = 0;
            btnLuuQuyen.BackColor = Color.FromArgb(24, 98, 184);
            btnLuuQuyen.ForeColor = Color.White;
            btnLuuQuyen.UseVisualStyleBackColor = false;
            btnLuuQuyen.Cursor = Cursors.Hand;

            pnlThaoTac.Controls.Add(btnChonTatCa);
            pnlThaoTac.Controls.Add(btnLuuQuyen);
            tabCapQuyen.Controls.Add(pnlDanhSachQuyen);
            tabCapQuyen.Controls.Add(pnlThaoTac);
            tabTraCuu.Controls.Add(lstTraCuu);
            tabTraCuu.Controls.Add(lblTomTatQuyen);
            tabQuyen.Controls.Add(tabCapQuyen);
            tabQuyen.Controls.Add(tabTraCuu);
            pnlQuyen.Controls.Add(tabQuyen);
            pnlQuyen.Controls.Add(lblTaiKhoan);
            layNoiDung.Controls.Add(pnlDanhSach, 0, 0);
            layNoiDung.Controls.Add(pnlQuyen, 1, 0);

            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Dock = DockStyle.Bottom;
            lblTrangThai.Height = 32;
            lblTrangThai.TextAlign = ContentAlignment.MiddleLeft;
            lblTrangThai.ForeColor = Color.FromArgb(75, 94, 119);

            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Segoe UI", 10F);
            BackColor = Color.FromArgb(242, 246, 250);
            ForeColor = Color.FromArgb(28, 46, 70);
            Padding = new Padding(8, 8, 8, 4);
            Size = new Size(1050, 650);
            Name = "PhanQuyenPanel";
            Controls.Add(layNoiDung);
            Controls.Add(lblTrangThai);

            tabTraCuu.ResumeLayout(false);
            tabCapQuyen.ResumeLayout(false);
            tabQuyen.ResumeLayout(false);
            pnlQuyen.ResumeLayout(false);
            pnlDanhSach.ResumeLayout(false);
            pnlDanhSach.PerformLayout();
            layNoiDung.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
