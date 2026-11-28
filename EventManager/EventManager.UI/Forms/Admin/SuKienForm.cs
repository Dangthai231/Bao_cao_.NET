using EventManager.UI.Models;
using EventManager.UI.UserControls.Admin;
using System;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Admin
{
    /// <summary>
    /// Form tạo / cập nhật sự kiện
    /// </summary>
    public partial class SuKienForm : Form
    {
        private readonly bool _requiresLocation = true;

        /// <summary>Dữ liệu người dùng nhập, đọc sau khi form trả về OK</summary>
        public AdminEventRequest Result { get; private set; }

        // Tạo sự kiện mới
        public SuKienForm()
        {
            InitializeComponent();
            Text = "Tạo sự kiện";
            dtpBatDau.Value = DateTime.Today.AddDays(1).AddHours(8);
            dtpKetThuc.Value = dtpBatDau.Value.AddHours(2);
            chkCoKetThuc.CheckedChanged += (_, _) =>
            {
                dtpKetThuc.Enabled = chkCoKetThuc.Checked;
                dtpKetThuc.CustomFormat = chkCoKetThuc.Checked ? "dd/MM/yyyy HH:mm" : "'Chưa đặt'";
            };
            btnLuu.Click += btnLuu_Click;
        }

        // Cập nhật sự kiện có sẵn
        public SuKienForm(AdminEventDto ev) : this()
        {
            Text = "Cập nhật sự kiện";
            _requiresLocation = !string.IsNullOrWhiteSpace(ev.Location);
            lblDiaDiem.Text = _requiresLocation ? "Địa điểm *" : "Địa điểm";
            txtTenSuKien.Text = ev.Title;
            txtMoTa.Text = ev.Description;
            txtDiaDiem.Text = ev.Location;
            dtpBatDau.Value = ev.StartDate;
            dtpKetThuc.Value = ev.EndDate ?? ev.StartDate;
            chkCoKetThuc.Checked = ev.EndDate.HasValue;
            nudSoCho.Value = Math.Min(nudSoCho.Maximum, ev.MaxParticipants);
            cboTrangThai.SelectedItem = AdminHelper.EventStatusText(ev.Status);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSuKien.Text))
            {
                MessageBox.Show(this, "Vui lòng nhập tên sự kiện.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSuKien.Focus();
                return;
            }
            if (_requiresLocation && string.IsNullOrWhiteSpace(txtDiaDiem.Text))
            {
                MessageBox.Show(this, "Vui lòng nhập địa điểm tổ chức sự kiện.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaDiem.Focus();
                return;
            }
            if (cboTrangThai.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Vui lòng chọn trạng thái sự kiện.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangThai.Focus();
                return;
            }
            if (chkCoKetThuc.Checked && dtpKetThuc.Value < dtpBatDau.Value)
            {
                MessageBox.Show("Thời gian kết thúc phải bằng hoặc sau thời gian bắt đầu.", "Thông tin không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Result = new AdminEventRequest
            {
                Title = txtTenSuKien.Text.Trim(),
                Description = txtMoTa.Text.Trim(),
                Location = txtDiaDiem.Text.Trim(),
                StartDate = dtpBatDau.Value,
                EndDate = chkCoKetThuc.Checked ? dtpKetThuc.Value : null,
                MaxParticipants = (int)nudSoCho.Value,
                Status = AdminHelper.EventStatusCode(cboTrangThai.Text)
            };
            DialogResult = DialogResult.OK;
        }
    }
}
