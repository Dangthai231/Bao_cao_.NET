using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Admin
{
    partial class DuyetKeHoachForm
    {
        private void InitializeComponent()
        {
            DataGridViewCellStyle gridCellStyle = new DataGridViewCellStyle();
            gridCellStyle.WrapMode = DataGridViewTriState.True;
            dgvChiTiet = new DataGridView();
            btnDong = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            dgvChiTiet.Name = "dgvChiTiet";
            btnDong.Name = "btnDong";
            dgvChiTiet.Dock=DockStyle.Fill;
            dgvChiTiet.ReadOnly=true;
            dgvChiTiet.AllowUserToAddRows=false;
            dgvChiTiet.AllowUserToDeleteRows=false;
            dgvChiTiet.RowHeadersVisible=false;
            dgvChiTiet.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.AllCells;
            DataGridViewCellStyle cellStyle1 = new DataGridViewCellStyle();
            cellStyle1.BackColor = Color.White;
            cellStyle1.ForeColor = Color.FromArgb(28, 46, 70);
            cellStyle1.SelectionBackColor = Color.FromArgb(225, 237, 252);
            cellStyle1.SelectionForeColor = Color.FromArgb(20, 40, 72);
            cellStyle1.Padding = new Padding(8, 2, 8, 2);
            cellStyle1.WrapMode = DataGridViewTriState.False;
            dgvChiTiet.DefaultCellStyle = cellStyle1;
            dgvChiTiet.BackgroundColor = Color.White;
            btnDong.Text="Đóng";
            btnDong.Dock=DockStyle.Bottom;
            btnDong.Height=40;
            btnDong.DialogResult=DialogResult.Cancel;
            Controls.Add(dgvChiTiet);
            Controls.Add(btnDong);
            Text="Duyệt kế hoạch";
            ClientSize=new Size(780,480);
            StartPosition=FormStartPosition.CenterParent;
            Font = new Font("Segoe UI", 10F);
            CancelButton=btnDong;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ForeColor = Color.FromArgb(28, 46, 70);
            BackColor = Color.White;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.FlatAppearance.BorderSize = 1;
            btnDong.FlatAppearance.BorderColor = Color.FromArgb(219, 228, 239);
            btnDong.FlatAppearance.MouseOverBackColor = Color.FromArgb(225, 237, 252);
            btnDong.BackColor = Color.FromArgb(243, 247, 252);
            btnDong.ForeColor = Color.FromArgb(28, 46, 70);
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDong.Cursor = Cursors.Hand;
            dgvChiTiet.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle cellStyle2 = new DataGridViewCellStyle();
            cellStyle2.BackColor = Color.FromArgb(20, 40, 72);
            cellStyle2.ForeColor = Color.White;
            cellStyle2.SelectionBackColor = Color.FromArgb(20, 40, 72);
            cellStyle2.SelectionForeColor = Color.White;
            cellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            cellStyle2.Padding = new Padding(8, 3, 8, 3);
            cellStyle2.WrapMode = DataGridViewTriState.True;
            dgvChiTiet.ColumnHeadersDefaultCellStyle = cellStyle2;
            DataGridViewCellStyle cellStyle3 = new DataGridViewCellStyle();
            cellStyle3.BackColor = Color.FromArgb(243, 247, 252);
            dgvChiTiet.AlternatingRowsDefaultCellStyle = cellStyle3;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.RowTemplate.Height = 34;
            dgvChiTiet.BorderStyle = BorderStyle.FixedSingle;
            dgvChiTiet.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvChiTiet.GridColor = Color.FromArgb(219, 228, 239);
            dgvChiTiet.AllowUserToResizeRows = false;
            Padding = new Padding(16);
            MinimumSize = new Size(620, 360);
            Name = "DuyetKeHoachForm";
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvChiTiet;
        private Button btnDong;
    }
}
