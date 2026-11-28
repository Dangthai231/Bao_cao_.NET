using EventManager.UI.Models;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Admin
{
    /// <summary>
    /// Theo dõi tiến độ sự kiện: danh sách công việc và % hoàn thành
    /// </summary>
    public partial class TheoDoiSuKienForm : Form
    {
        public TheoDoiSuKienForm()
        {
            InitializeComponent();
        }

        public TheoDoiSuKienForm(AdminProgressDto progress) : this()
        {
            lblTenSuKien.Text = progress.EventTitle;
            lblTienDo.Text = $"Tiến độ chung  {progress.Progress}%   ·   {progress.Tasks.Count} công việc";

            if (progress.Tasks.Count == 0)
            {
                dgvCongViec.Visible = false;
                lblChuaCoCongViec.Visible = true;
                return;
            }

            dgvCongViec.Columns.Add("colCongViec", "Công việc");
            dgvCongViec.Columns.Add("colTrangThai", "Trạng thái");
            dgvCongViec.Columns.Add("colPhuTrach", "Phụ trách");
            dgvCongViec.Columns.Add("colTienDo", "Tiến độ");
            dgvCongViec.Columns.Add("colHanChot", "Hạn chót");
            dgvCongViec.Columns["colCongViec"].FillWeight = 190;
            dgvCongViec.Columns["colCongViec"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvCongViec.Columns["colTienDo"].FillWeight = 65;
            dgvCongViec.Columns["colTienDo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCongViec.Columns["colTienDo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (var task in progress.Tasks)
            {
                dgvCongViec.Rows.Add(
                    task.Title,
                    task.Status,
                    task.Owner,
                    task.Progress + "%",
                    task.Deadline.HasValue ? task.Deadline.Value.ToString("dd/MM/yyyy") : "");
            }

        }
    }
}
