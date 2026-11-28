using EventManager.UI.Models;
using System.Drawing;
using System.Windows.Forms;

namespace EventManager.UI.Forms.Admin
{
    /// <summary>
    /// So sánh thông tin hiện tại và thông tin đề xuất của một yêu cầu thay đổi thông tin
    /// </summary>
    public partial class DuyetThongTinForm : Form
    {
        public DuyetThongTinForm()
        {
            InitializeComponent();
        }

        public DuyetThongTinForm(AdminChangeRequestDto request) : this()
        {
            Text = $"Yêu cầu thay đổi thông tin - {request.Username}";

            dgvChiTiet.Columns.Add("colThongTin", "Thông tin");
            dgvChiTiet.Columns.Add("colHienTai", "Hiện tại");
            dgvChiTiet.Columns.Add("colDeXuat", "Đề xuất");

            AddRow("Họ tên", request.CurrentFullName, request.NewFullName);
            AddRow("Email", request.CurrentEmail, request.NewEmail);
            AddRow("Điện thoại", request.CurrentPhoneNumber, request.NewPhoneNumber);
            AddRow("Lớp", request.CurrentClassName, request.NewClassName);
            AddRow("Minh chứng", "", request.Evidence);
            AddRow("Trạng thái", "", request.Status);
            if (!string.IsNullOrWhiteSpace(request.ReviewNote))
                AddRow("Lý do từ chối", "", request.ReviewNote);
        }

        private void AddRow(string label, string current, string proposed)
        {
            int index = dgvChiTiet.Rows.Add(label, current ?? "", proposed ?? "");

            // In đậm dòng có thay đổi để Admin dễ thấy
            if ((current ?? "") != (proposed ?? "") && current != "")
                dgvChiTiet.Rows[index].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }
    }
}
