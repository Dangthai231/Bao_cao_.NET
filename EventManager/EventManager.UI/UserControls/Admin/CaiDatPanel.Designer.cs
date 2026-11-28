using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.UserControls.Admin
{
    partial class CaiDatPanel
    {
        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMatKhauCu = new Label();
            lblMatKhauMoi = new Label();
            lblNhapLai = new Label();
            lblGhiChu = new Label();
            txtMatKhauCu = new TextBox();
            txtMatKhauMoi = new TextBox();
            txtNhapLai = new TextBox();
            btnDoiMatKhau = new Button();
            SuspendLayout();
            lblTieuDe.Name = "lblTieuDe";
            lblMatKhauCu.Name = "lblMatKhauCu";
            lblMatKhauMoi.Name = "lblMatKhauMoi";
            lblNhapLai.Name = "lblNhapLai";
            lblGhiChu.Name = "lblGhiChu";
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtNhapLai.Name = "txtNhapLai";
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            BackColor = Color.FromArgb(242, 246, 250);
            Font = new Font("Segoe UI", 10F);
            Size=new Size(900,600);
            lblTieuDe.Text="Cài đặt - Đổi mật khẩu";
            lblTieuDe.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblTieuDe.Location=new Point(24,24);
            lblTieuDe.AutoSize=true;
            lblMatKhauCu.Text="Mật khẩu hiện tại";
            lblMatKhauCu.Location = new Point(24, 80);
            lblMatKhauCu.AutoSize=true;
            txtMatKhauCu.Location = new Point(24, 104);
            txtMatKhauCu.Width = 340;
            txtMatKhauCu.UseSystemPasswordChar=true;
            lblMatKhauMoi.Text="Mật khẩu mới";
            lblMatKhauMoi.Location = new Point(24, 144);
            lblMatKhauMoi.AutoSize=true;
            txtMatKhauMoi.Location = new Point(24, 168);
            txtMatKhauMoi.Width = 340;
            txtMatKhauMoi.UseSystemPasswordChar=true;
            lblNhapLai.Text="Nhập lại mật khẩu";
            lblNhapLai.Location = new Point(24, 208);
            lblNhapLai.AutoSize=true;
            txtNhapLai.Location = new Point(24, 232);
            txtNhapLai.Width = 340;
            txtNhapLai.UseSystemPasswordChar=true;
            btnDoiMatKhau.Text="Lưu mật khẩu";
            btnDoiMatKhau.Location = new Point(24, 270);
            btnDoiMatKhau.Size=new Size(150,36);
            lblGhiChu.Text="Thông tin hệ thống\r\nHệ thống quản lý sự kiện - BCH LCĐ CNS\r\nTrường Đại học Điện lực\r\n.NET 10 / MySQL";
            lblGhiChu.Location = new Point(24, 334);
            lblGhiChu.AutoSize=true;
            Controls.Add(lblTieuDe);
            Controls.Add(lblMatKhauCu);
            Controls.Add(lblMatKhauMoi);
            Controls.Add(lblNhapLai);
            Controls.Add(txtMatKhauCu);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(txtNhapLai);
            Controls.Add(btnDoiMatKhau);
            Controls.Add(lblGhiChu);
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ForeColor = Color.FromArgb(28, 46, 70);
            btnDoiMatKhau.FlatStyle = FlatStyle.Flat;
            btnDoiMatKhau.FlatAppearance.BorderSize = 0;
            btnDoiMatKhau.FlatAppearance.BorderColor = Color.FromArgb(219, 228, 239);
            btnDoiMatKhau.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 75, 119);
            btnDoiMatKhau.BackColor = Color.FromArgb(20, 40, 72);
            btnDoiMatKhau.ForeColor = Color.White;
            btnDoiMatKhau.UseVisualStyleBackColor = false;
            btnDoiMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDoiMatKhau.Cursor = Cursors.Hand;
            txtMatKhauCu.ForeColor = Color.FromArgb(28, 46, 70);
            txtMatKhauCu.BackColor = Color.White;
            txtMatKhauCu.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhauMoi.ForeColor = Color.FromArgb(28, 46, 70);
            txtMatKhauMoi.BackColor = Color.White;
            txtMatKhauMoi.BorderStyle = BorderStyle.FixedSingle;
            txtNhapLai.ForeColor = Color.FromArgb(28, 46, 70);
            txtNhapLai.BackColor = Color.White;
            txtNhapLai.BorderStyle = BorderStyle.FixedSingle;
            lblMatKhauCu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMatKhauMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNhapLai.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGhiChu.ForeColor = Color.FromArgb(75, 94, 119);
            Name = "CaiDatPanel";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTieuDe;
        private Label lblMatKhauCu;
        private Label lblMatKhauMoi;
        private Label lblNhapLai;
        private Label lblGhiChu;
        private TextBox txtMatKhauCu;
        private TextBox txtMatKhauMoi;
        private TextBox txtNhapLai;
        private Button btnDoiMatKhau;
    }
}
