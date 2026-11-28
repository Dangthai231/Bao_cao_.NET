using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Admin
{
    partial class PhanCongCanBoForm
    {
        private void InitializeComponent()
        {
            cboCanBo = new ComboBox();
            btnLuu = new Button();
            btnHuy = new Button();
            lblCanBo = new Label();
            SuspendLayout();
            cboCanBo.Name = "cboCanBo";
            btnLuu.Name = "btnLuu";
            btnHuy.Name = "btnHuy";
            lblCanBo.Name = "lblCanBo";
            lblCanBo.Text="Chọn cán bộ phụ trách";
            lblCanBo.Location = new Point(20, 20);
            lblCanBo.Size = new Size(440, 30);
            cboCanBo.Location = new Point(20, 65);
            cboCanBo.Size = new Size(440, 32);
            cboCanBo.DropDownStyle=ComboBoxStyle.DropDownList;
            btnLuu.Text="Phân công";
            btnLuu.Location = new Point(350, 125);
            btnLuu.Size = new Size(110, 35);
            btnHuy.Text="Hủy";
            btnHuy.Location = new Point(230, 125);
            btnHuy.Size = new Size(110, 35);
            btnHuy.DialogResult=DialogResult.Cancel;
            Controls.AddRange(new Control[]{lblCanBo,cboCanBo,btnLuu,btnHuy});
            AcceptButton=btnLuu;
            CancelButton=btnHuy;
            ClientSize=new Size(480,185);
            Text="Phân công cán bộ";
            Font = new Font("Segoe UI", 10F);
            StartPosition=FormStartPosition.CenterParent;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ForeColor = Color.FromArgb(28, 46, 70);
            BackColor = Color.White;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatAppearance.BorderColor = Color.FromArgb(219, 228, 239);
            btnLuu.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 75, 119);
            btnLuu.BackColor = Color.FromArgb(20, 40, 72);
            btnLuu.ForeColor = Color.White;
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.Cursor = Cursors.Hand;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.FlatAppearance.BorderSize = 1;
            btnHuy.FlatAppearance.BorderColor = Color.FromArgb(219, 228, 239);
            btnHuy.FlatAppearance.MouseOverBackColor = Color.FromArgb(225, 237, 252);
            btnHuy.BackColor = Color.FromArgb(243, 247, 252);
            btnHuy.ForeColor = Color.FromArgb(28, 46, 70);
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.Cursor = Cursors.Hand;
            cboCanBo.ForeColor = Color.FromArgb(28, 46, 70);
            cboCanBo.BackColor = Color.White;
            cboCanBo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLuu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnHuy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            MinimumSize = new Size(460, 220);
            Name = "PhanCongCanBoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cboCanBo;
        private Button btnLuu;
        private Button btnHuy;
        private Label lblCanBo;
    }
}
