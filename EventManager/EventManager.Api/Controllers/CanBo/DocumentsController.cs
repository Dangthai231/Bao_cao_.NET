using EventManager.Api.Data;
using EventManager.Api.DTOs;
using EventManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EventManager.Api.Controllers.CanBo
{
    [Route("api/canbo/documents")]
    [ApiController]

    public class DocumentsController :ControllerBase
    {
        private readonly AppDbContext _context;

        // Tiêm (Inject) AppDbContext vào Controller để thao tác với DB
        public DocumentsController(AppDbContext context)
        {
            _context = context;
        }

        // --- 1. API LẤY DANH SÁCH TÀI LIỆU TỪ DB ---
        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            // Dùng Entity Framework để lấy tất cả dữ liệu từ bảng Documents trong Database
            var documents = await _context.Documents.ToListAsync();

            // Chuyển đổi dữ liệu từ Model (chứa cấu trúc DB) sang DTO (để gửi về WinForms hiển thị)
            var listDocs = documents.Select(doc => new DocumentDto
            {
                Id = doc.Id,
                FileName = doc.FileName,
                FileType = doc.FileType,
                FileSize = doc.FileSize,
                UploadDate = doc.UploadDate.ToString("dd/MM/yyyy"), // Format ngày cho đẹp
                UploadedBy = doc.UploadedBy
            }).ToList();

            return Ok(listDocs);
        }

        // --- 2. API XÓA TÀI LIỆU THỰC TẾ TRONG DB ---
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            // Tìm tài liệu trong Database theo ID
            var doc = await _context.Documents.FindAsync(id);

            // Nếu không tìm thấy
            if (doc == null)
            {
                return NotFound(new { message = "Không tìm thấy tài liệu để xóa!" });
            }

            // Xóa dòng dữ liệu đó khỏi Database
            _context.Documents.Remove(doc);

            // Lưu lại thay đổi
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Đã xóa thành công tài liệu: {doc.FileName}" });
        }
        [HttpPost]
        public async Task<IActionResult> UploadDocument([FromBody] DocumentDto request)
        {
            // Tạo đối tượng Model để lưu vào Database
            var newDoc = new Document
            {
                FileName = request.FileName,
                FileType = request.FileType,
                FileSize = request.FileSize,
                UploadDate = DateTime.Now,
                UploadedBy = "Cán bộ" // Thực tế đi làm sẽ lấy Username từ token người đang đăng nhập
            };

            _context.Documents.Add(newDoc);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Lưu tài liệu vào Database thành công!" });
        }
    }
}
