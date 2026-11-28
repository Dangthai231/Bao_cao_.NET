using EventManager.UI.Models;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Admin
{
    /// <summary>
    /// Xem chi tiết kế hoạch tổ chức trước khi duyệt
    /// </summary>
    public partial class DuyetKeHoachForm : Form
    {
        public DuyetKeHoachForm()
        {
            InitializeComponent();
        }

        public DuyetKeHoachForm(AdminPlanDto plan) : this()
        {
            Text = "Kế hoạch: " + plan.PlanName;

            dgvChiTiet.Columns.Add("colThongTin", "Thông tin");
            dgvChiTiet.Columns.Add("colGiaTri", "Giá trị");

            dgvChiTiet.Rows.Add("Tên kế hoạch", plan.PlanName);
            dgvChiTiet.Rows.Add("Mục tiêu", plan.Objective);
            dgvChiTiet.Rows.Add("Mô tả", plan.Description);
            dgvChiTiet.Rows.Add("Địa điểm", plan.Location);
            dgvChiTiet.Rows.Add("Thời gian", $"{plan.StartDate:dd/MM/yyyy} - {plan.EndDate:dd/MM/yyyy}");
            dgvChiTiet.Rows.Add("Ngân sách", plan.Budget.ToString("N0") + " đ");
            dgvChiTiet.Rows.Add("Trạng thái", plan.Status);
            if (!string.IsNullOrWhiteSpace(plan.ReviewNote))
                dgvChiTiet.Rows.Add("Ghi chú duyệt", plan.ReviewNote);
            if (plan.EventId.HasValue)
                dgvChiTiet.Rows.Add("Sự kiện đã tạo", "Mã sự kiện " + plan.EventId.Value);
        }
    }
}
