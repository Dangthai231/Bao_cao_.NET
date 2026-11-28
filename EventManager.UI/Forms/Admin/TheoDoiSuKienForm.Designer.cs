using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Admin
{
    partial class TheoDoiSuKienForm
    {
        private void InitializeComponent()
        {
            dgvCongViec = new DataGridView();
            btnDong = new Button();
            lblTenSuKien = new Label();
            lblTienDo = new Label();
            lblChuaCoCongViec = new Label();
            var header = new Panel();
            var footer = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvCongViec).BeginInit();
            SuspendLayout();
            dgvCongViec.Name = "dgvCongViec";
            btnDong.Name = "btnDong";
            dgvCongViec.Dock=DockStyle.Fill;
            dgvCongViec.ReadOnly=true;
            dgvCongViec.AllowUserToAddRows=false;
            dgvCongViec.AllowUserToDeleteRows=false;
            dgvCongViec.RowHeadersVisible=false;
            dgvCongViec.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dgvCongViec.AutoSizeRowsMode=DataGridViewAutoSizeRowsMode.AllCells;
            DataGridViewCellStyle cellStyle1 = new DataGridViewCellStyle();
            cellStyle1.BackColor = Color.White;
            cellStyle1.ForeColor = Color.FromArgb(28, 46, 70);
            cellStyle1.SelectionBackColor = Color.FromArgb(225, 237, 252);
            cellStyle1.SelectionForeColor = Color.FromArgb(20, 40, 72);
            cellStyle1.Padding = new Padding(8, 2, 8, 2);
            cellStyle1.WrapMode = DataGridViewTriState.False;
            dgvCongViec.DefaultCellStyle = cellStyle1;
            dgvCongViec.BackgroundColor = Color.White;
            btnDong.Text="Đóng";
            btnDong.Dock = DockStyle.Right;
            btnDong.Width = 104;
            btnDong.DialogResult=DialogResult.Cancel;

            header.Dock = DockStyle.Top;
            header.Height = 88;
            lblTenSuKien.Dock = DockStyle.Fill;
            lblTenSuKien.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTenSuKien.TextAlign = ContentAlignment.MiddleLeft;
            lblTienDo.Dock = DockStyle.Bottom;
            lblTienDo.Height = 34;
            lblTienDo.ForeColor = Color.FromArgb(71, 85, 105);
            header.Controls.Add(lblTenSuKien);
            header.Controls.Add(lblTienDo);

            lblChuaCoCongViec.Dock = DockStyle.Fill;
            lblChuaCoCongViec.Text = "Sự kiện chưa có công việc nào.";
            lblChuaCoCongViec.TextAlign = ContentAlignment.MiddleCenter;
            lblChuaCoCongViec.Font = new Font("Segoe UI Semibold", 11F);
            lblChuaCoCongViec.ForeColor = Color.FromArgb(71, 85, 105);
            lblChuaCoCongViec.BackColor = Color.FromArgb(248, 250, 252);
            lblChuaCoCongViec.Visible = false;

            footer.Dock = DockStyle.Bottom;
            footer.Height = 52;
            footer.Padding = new Padding(0, 12, 0, 0);
            footer.Controls.Add(btnDong);
            Controls.Add(dgvCongViec);
            Controls.Add(lblChuaCoCongViec);
            Controls.Add(header);
            Controls.Add(footer);
            Text="Theo dõi sự kiện";
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
            dgvCongViec.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle cellStyle2 = new DataGridViewCellStyle();
            cellStyle2.BackColor = Color.FromArgb(241, 245, 249);
            cellStyle2.ForeColor = Color.FromArgb(51, 65, 85);
            cellStyle2.SelectionBackColor = cellStyle2.BackColor;
            cellStyle2.SelectionForeColor = cellStyle2.ForeColor;
            cellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            cellStyle2.Padding = new Padding(8, 7, 8, 7);
            cellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCongViec.ColumnHeadersDefaultCellStyle = cellStyle2;
            DataGridViewCellStyle cellStyle3 = new DataGridViewCellStyle();
            cellStyle3.BackColor = Color.FromArgb(243, 247, 252);
            dgvCongViec.AlternatingRowsDefaultCellStyle = cellStyle3;
            dgvCongViec.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCongViec.RowTemplate.Height = 34;
            dgvCongViec.BorderStyle = BorderStyle.None;
            dgvCongViec.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCongViec.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCongViec.MultiSelect = false;
            dgvCongViec.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCongViec.GridColor = Color.FromArgb(219, 228, 239);
            dgvCongViec.AllowUserToResizeRows = false;
            Padding = new Padding(16);
            MinimumSize = new Size(620, 360);
            Name = "TheoDoiSuKienForm";
            ((System.ComponentModel.ISupportInitialize)dgvCongViec).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvCongViec;
        private Button btnDong;
        private Label lblTenSuKien;
        private Label lblTienDo;
        private Label lblChuaCoCongViec;
    }
}
