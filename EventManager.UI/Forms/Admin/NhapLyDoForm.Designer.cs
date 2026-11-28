using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Admin
{
    partial class NhapLyDoForm
    {
        private void InitializeComponent()
        {
            lblLyDo = new Label();
            txtLyDo = new TextBox();
            btnXacNhan = new Button();
            btnHuy = new Button();
            SuspendLayout();
            lblLyDo.Name = "lblLyDo";
            txtLyDo.Name = "txtLyDo";
            btnXacNhan.Name = "btnXacNhan";
            btnHuy.Name = "btnHuy";
            lblLyDo.Text = "Lý do từ chối (bắt buộc):";
            lblLyDo.Location = new Point(16, 14);
            lblLyDo.AutoSize = true;
            txtLyDo.Multiline = true;
            txtLyDo.ScrollBars = ScrollBars.Vertical;
            txtLyDo.Location = new Point(16, 42);
            txtLyDo.Size = new Size(428, 110);
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.Location = new Point(244, 166);
            btnXacNhan.Size = new Size(96, 34);
            btnXacNhan.BackColor = Color.FromArgb(159, 43, 55);
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.FlatStyle = FlatStyle.Flat;
            btnHuy.Text = "Hủy";
            btnHuy.Location = new Point(348, 166);
            btnHuy.Size = new Size(96, 34);
            btnHuy.DialogResult = DialogResult.Cancel;
            Controls.Add(lblLyDo);
            Controls.Add(txtLyDo);
            Controls.Add(btnXacNhan);
            Controls.Add(btnHuy);
            Text = "Từ chối";
            ClientSize = new Size(460, 214);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Font = new Font("Segoe UI", 10F);
            CancelButton = btnHuy;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ForeColor = Color.FromArgb(28, 46, 70);
            BackColor = Color.White;
            btnXacNhan.FlatAppearance.BorderSize = 0;
            btnXacNhan.FlatAppearance.BorderColor = Color.FromArgb(219, 228, 239);
            btnXacNhan.FlatAppearance.MouseOverBackColor = Color.FromArgb(136, 35, 47);
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXacNhan.Cursor = Cursors.Hand;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.FlatAppearance.BorderSize = 1;
            btnHuy.FlatAppearance.BorderColor = Color.FromArgb(219, 228, 239);
            btnHuy.FlatAppearance.MouseOverBackColor = Color.FromArgb(225, 237, 252);
            btnHuy.BackColor = Color.FromArgb(243, 247, 252);
            btnHuy.ForeColor = Color.FromArgb(28, 46, 70);
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.Cursor = Cursors.Hand;
            txtLyDo.ForeColor = Color.FromArgb(28, 46, 70);
            txtLyDo.BackColor = Color.White;
            txtLyDo.BorderStyle = BorderStyle.FixedSingle;
            Name = "NhapLyDoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblLyDo;
        private TextBox txtLyDo;
        private Button btnXacNhan;
        private Button btnHuy;
    }
}
