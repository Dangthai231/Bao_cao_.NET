using EventManager.UI.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Admin
{
    /// <summary>
    /// Chọn cán bộ phụ trách cho một sự kiện
    /// </summary>
    public partial class PhanCongCanBoForm : Form
    {
        public int SelectedManagerId { get; private set; }

        public PhanCongCanBoForm()
        {
            InitializeComponent();
            btnLuu.Click += btnLuu_Click;
        }

        public PhanCongCanBoForm(AdminEventDto ev, List<AdminAccountDto> staff) : this()
        {
            Text = "Phân công cán bộ - " + ev.Title;

            cboCanBo.DisplayMember = "FullName";
            cboCanBo.ValueMember = "Id";
            cboCanBo.DataSource = staff;

            if (ev.ManagerId.HasValue)
                cboCanBo.SelectedValue = ev.ManagerId.Value;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboCanBo.SelectedValue is int id)
            {
                SelectedManagerId = id;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn cán bộ phụ trách.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
