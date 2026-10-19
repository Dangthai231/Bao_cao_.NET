using ClosedXML.Excel;
using EventManager.UI.Models;
using EventManager.UI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EventManager.UI.UserControls
{
    public partial class ucQuanLyTaiLieu : UserControl
    {
        private UserSession _session;
        private readonly ApiService _apiService = new ApiService();
        public ucQuanLyTaiLieu()
        {
            InitializeComponent();
            // Tắt chế độ tự tạo cột thừa để nó dùng đúng 5 cột bạn đã vẽ
            dgvDocuments.AutoGenerateColumns = false;

            // Map tên thuộc tính trong DocumentDto vào từng cột của DataGridView (theo đúng thứ tự bạn đã tạo)
            dgvDocuments.Columns[0].DataPropertyName = "FileName";
            dgvDocuments.Columns[1].DataPropertyName = "FileType";
            dgvDocuments.Columns[2].DataPropertyName = "FileSize";
            dgvDocuments.Columns[3].DataPropertyName = "UploadDate";
            dgvDocuments.Columns[4].DataPropertyName = "UploadedBy";

            this.Load += ucManageDocuments_Load;
        }
        // Tạo sự kiện Load cho UserControl (Nhấp đúp chuột vào nền giao diện để tự sinh ra hàm này)
        private async void ucManageDocuments_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ BE và đổ thẳng vào DataSource của bảng
                var documents = await _apiService.GetDocumentsAsync();
                dgvDocuments.DataSource = documents;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tài liệu: " + ex.Message);
            }
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Tất cả các file|*.*|Word|*.docx|Excel|*.xlsx|PDF|*.pdf";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Phân tích file người dùng vừa chọn
                FileInfo fileInfo = new FileInfo(ofd.FileName);

                // Tính dung lượng file cho đẹp (KB hoặc MB)
                long sizeBytes = fileInfo.Length;
                string sizeStr = sizeBytes > 1024 * 1024
                    ? $"{(sizeBytes / 1024f / 1024f):0.##} MB"
                    : $"{(sizeBytes / 1024f):0} KB";

                // Gói thành DTO gửi lên DB
                var newDoc = new DocumentDto
                {
                    FileName = fileInfo.Name,
                    FileType = fileInfo.Extension.Replace(".", "").ToUpper(),
                    FileSize = sizeStr
                };

                // Gọi API lưu DB
                bool isUploaded = await _apiService.UploadDocumentAsync(newDoc);

                if (isUploaded)
                {
                    MessageBox.Show("Tải lên và lưu vào cơ sở dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Gọi lại sự kiện Load để bảng tự động hiện dòng mới thêm
                    ucManageDocuments_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu vào máy chủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra bảng có dữ liệu hay không
            if (dgvDocuments.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 2. Mở hộp thoại chọn vị trí lưu file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = "DanhSachTaiLieu_Export.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Khởi tạo Workbook và Worksheet của ClosedXML
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("TaiLieuSuKien");
                        // 4. Ghi tiêu đề các cột (Dòng 1)
                        for (int i = 0; i < dgvDocuments.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dgvDocuments.Columns[i].HeaderText;
                            worksheet.Cell(1, i + 1).Style.Font.Bold = true; // In đậm
                        }
                        // 5. Duyệt qua từng dòng trên DataGridView để ghi dữ liệu (Từ dòng 2 trở đi)
                        for (int i = 0; i < dgvDocuments.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvDocuments.Columns.Count; j++)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = dgvDocuments.Rows[i].Cells[j].Value?.ToString();
                            }
                        }
                        // Tự động căn chỉnh độ rộng cột vừa vặn với nội dung (tùy chọn)
                        worksheet.Columns().AdjustToContents();
                        // 6. Lưu file ra đường dẫn đã chọn
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Xuất file Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn dòng nào trên bảng DataGridView chưa
            if (dgvDocuments.CurrentRow != null)
            {
                // 2. Ép kiểu dữ liệu của dòng đang chọn về DocumentDto để lấy ID và Tên file
                var selectedDoc = (DocumentDto)dgvDocuments.CurrentRow.DataBoundItem;
                int docId = selectedDoc.Id;
                string docName = selectedDoc.FileName;

                // 3. Hiển thị hộp thoại cảnh báo xác nhận trước khi xóa
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài liệu '{docName}' không?\nDữ liệu sẽ bị xóa vĩnh viễn khỏi hệ thống!",
                                                      "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // 4. Nếu người dùng chọn Yes
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Gọi API gửi lệnh xóa bằng ID xuống Backend (để xóa trong DB)
                        bool isDeleted = await _apiService.DeleteDocumentAsync(docId);

                        if (isDeleted)
                        {
                            MessageBox.Show("Xóa tài liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // 5. Gọi lại hàm Load của UserControl để làm mới lại bảng dữ liệu (Grid)
                            ucManageDocuments_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại. Vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Bắt lỗi nếu mất mạng hoặc Backend chưa chạy
                        MessageBox.Show("Lỗi kết nối đến máy chủ: " + ex.Message, "Lỗi Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài liệu trong bảng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
