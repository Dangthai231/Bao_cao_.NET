using EventManager.Api.Data;
using EventManager.Api.DTOs;
using EventManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers.CanBo
{
    [Route("api/canbo/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        // --- 1. LẤY DANH SÁCH CÔNG VIỆC ---
        [HttpGet]
        public async Task<IActionResult> GetTasks([FromQuery] string? search, [FromQuery] string? trangThai, [FromQuery] long? suKienId)
        {
            var query = _context.CongViecs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(trangThai) && !trangThai.Equals("Tất cả", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(t => t.TrangThai == trangThai);
            }

            if (suKienId.HasValue && suKienId.Value > 0)
            {
                query = query.Where(t => t.SuKienId == suKienId.Value);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                string kw = search.Trim().ToLower();
                query = query.Where(t =>
                    (t.MaCv != null && t.MaCv.ToLower().Contains(kw)) ||
                    t.TenCongViec.ToLower().Contains(kw) ||
                    (t.NhanSu != null && t.NhanSu.ToLower().Contains(kw)) ||
                    (t.TenSuKien != null && t.TenSuKien.ToLower().Contains(kw)) ||
                    (t.MoTa != null && t.MoTa.ToLower().Contains(kw)));
            }

            // Sắp xếp theo ID giảm dần (CV008 -> CV001)
            var tasks = await query.OrderByDescending(t => t.Id).ToListAsync();

            var result = tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                MaCv = t.MaCv ?? $"CV{t.Id:D3}",
                TenCongViec = t.TenCongViec,
                MoTa = t.MoTa,
                SuKienId = t.SuKienId,
                TenSuKien = t.TenSuKien,
                NhanSu = t.NhanSu,
                MucDoUuTien = t.MucDoUuTien ?? "Trung bình",
                HanChot = t.HanChot,
                TienDo = t.TienDo,
                TrangThai = t.TrangThai ?? "Chưa bắt đầu",
                NgayTao = t.NgayTao
            }).ToList();

            return Ok(result);
        }

        // --- 2. LẤY THỐNG KÊ SUMMARY ---
        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var allTasks = await _context.CongViecs.ToListAsync();
            var today = DateTime.Today;

            int tong = allTasks.Count;
            int dangThucHien = allTasks.Count(t => t.TrangThai == "Đang thực hiện");
            int hoanThanh = allTasks.Count(t => t.TrangThai == "Hoàn thành");
            int quaHan = allTasks.Count(t => t.TrangThai != "Hoàn thành" && t.HanChot.HasValue && t.HanChot.Value.Date < today);
            int tienDoTb = tong > 0 ? (int)Math.Round(allTasks.Average(t => t.TienDo)) : 0;

            return Ok(new TaskSummaryDto
            {
                TongCongViec = tong,
                DangThucHien = dangThucHien,
                HoanThanh = hoanThanh,
                QuaHan = quaHan,
                TienDoTrungBinh = tienDoTb
            });
        }

        // --- 3. LẤY DANH SÁCH SỰ KIỆN CHO DROPDOWN ---
        [HttpGet("events")]
        public async Task<IActionResult> GetEvents()
        {
            // Lấy từ bảng su_kien nếu có, nếu rỗng thì lấy từ events
            var suKiens = await _context.SuKiens
                .Select(s => new TaskEventOptionDto
                {
                    Id = s.Id,
                    TenSuKien = s.TenSuKien ?? $"Sự kiện #{s.Id}"
                })
                .ToListAsync();

            if (suKiens.Count == 0)
            {
                suKiens = await _context.Events
                    .Select(e => new TaskEventOptionDto
                    {
                        Id = e.Id,
                        TenSuKien = e.Title
                    })
                    .ToListAsync();
            }

            return Ok(suKiens);
        }

        // --- 4. LẤY DANH SÁCH CÁN BỘ / NHÂN SỰ CHO DROPDOWN PHÂN CÔNG ---
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var taiKhoans = await _context.TaiKhoans
                .Where(t => t.VaiTro == "CAN_BO" || t.VaiTro == "ADMIN" || t.VaiTro == "CanBo")
                .Select(t => new TaskUserOptionDto
                {
                    DisplayText = $"{t.HoTen} ({t.TenDangNhap})",
                    Username = t.TenDangNhap ?? "",
                    FullName = t.HoTen ?? ""
                })
                .ToListAsync();

            if (taiKhoans.Count == 0)
            {
                taiKhoans = await _context.Users
                    .Select(u => new TaskUserOptionDto
                    {
                        DisplayText = $"{u.FullName} ({u.Username})",
                        Username = u.Username,
                        FullName = u.FullName
                    })
                    .ToListAsync();
            }

            return Ok(taiKhoans);
        }

        // --- 5. LẤY CHI TIẾT 1 CÔNG VIỆC ---
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(long id)
        {
            var t = await _context.CongViecs.FindAsync(id);
            if (t == null)
                return NotFound(new { message = "Không tìm thấy công việc này!" });

            return Ok(new TaskDto
            {
                Id = t.Id,
                MaCv = t.MaCv ?? $"CV{t.Id:D3}",
                TenCongViec = t.TenCongViec,
                MoTa = t.MoTa,
                SuKienId = t.SuKienId,
                TenSuKien = t.TenSuKien,
                NhanSu = t.NhanSu,
                MucDoUuTien = t.MucDoUuTien ?? "Trung bình",
                HanChot = t.HanChot,
                TienDo = t.TienDo,
                TrangThai = t.TrangThai ?? "Chưa bắt đầu",
                NgayTao = t.NgayTao
            });
        }

        // --- 6. TẠO CÔNG VIỆC MỚI ---
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto request)
        {
            if (string.IsNullOrWhiteSpace(request.TenCongViec))
                return BadRequest(new { message = "Tên công việc không được để trống!" });

            // Tự sinh mã CV tiếp theo
            string nextMaCv = "CV001";
            var existingMaCvs = await _context.CongViecs
                .Where(t => t.MaCv != null && t.MaCv.StartsWith("CV"))
                .Select(t => t.MaCv)
                .ToListAsync();

            int maxNum = 0;
            foreach (var code in existingMaCvs)
            {
                if (code != null && code.Length > 2 && int.TryParse(code.Substring(2), out int num))
                {
                    if (num > maxNum) maxNum = num;
                }
            }
            nextMaCv = $"CV{maxNum + 1:D3}";

            // Lấy tên sự kiện nếu chưa có
            string? tenSuKien = request.TenSuKien;
            if (string.IsNullOrWhiteSpace(tenSuKien) && request.SuKienId.HasValue)
            {
                var sk = await _context.SuKiens.FindAsync(request.SuKienId.Value);
                if (sk != null) tenSuKien = sk.TenSuKien;
            }

            var congViec = new CongViec
            {
                MaCv = nextMaCv,
                TenCongViec = request.TenCongViec.Trim(),
                MoTa = request.MoTa?.Trim(),
                SuKienId = request.SuKienId,
                TenSuKien = tenSuKien,
                NhanSu = request.NhanSu?.Trim(),
                MucDoUuTien = string.IsNullOrWhiteSpace(request.MucDoUuTien) ? "Trung bình" : request.MucDoUuTien,
                HanChot = request.HanChot,
                TienDo = Math.Clamp(request.TienDo, 0, 100),
                TrangThai = string.IsNullOrWhiteSpace(request.TrangThai) ? "Chưa bắt đầu" : request.TrangThai,
                NgayTao = DateTime.Now
            };

            // Nếu tiến độ 100% thì tự đổi trạng thái thành Hoàn thành
            if (congViec.TienDo == 100)
                congViec.TrangThai = "Hoàn thành";

            _context.CongViecs.Add(congViec);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Tạo công việc thành công!", id = congViec.Id, maCv = congViec.MaCv });
        }

        // --- 7. CẬP NHẬT CÔNG VIỆC ---
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(long id, [FromBody] UpdateTaskDto request)
        {
            var task = await _context.CongViecs.FindAsync(id);
            if (task == null)
                return NotFound(new { message = "Không tìm thấy công việc để cập nhật!" });

            task.TenCongViec = request.TenCongViec.Trim();
            task.MoTa = request.MoTa?.Trim();
            task.SuKienId = request.SuKienId;

            string? tenSuKien = request.TenSuKien;
            if (string.IsNullOrWhiteSpace(tenSuKien) && request.SuKienId.HasValue)
            {
                var sk = await _context.SuKiens.FindAsync(request.SuKienId.Value);
                if (sk != null) tenSuKien = sk.TenSuKien;
            }
            if (!string.IsNullOrWhiteSpace(tenSuKien))
                task.TenSuKien = tenSuKien;

            task.NhanSu = request.NhanSu?.Trim();
            task.MucDoUuTien = string.IsNullOrWhiteSpace(request.MucDoUuTien) ? "Trung bình" : request.MucDoUuTien;
            task.HanChot = request.HanChot;
            task.TienDo = Math.Clamp(request.TienDo, 0, 100);
            task.TrangThai = request.TrangThai;

            if (task.TienDo == 100 && task.TrangThai != "Hoàn thành")
                task.TrangThai = "Hoàn thành";

            await _context.SaveChangesAsync();

            return Ok(new { message = "Cập nhật công việc thành công!" });
        }

        // --- 8. PHÂN CÔNG NHÂN SỰ ---
        [HttpPut("{id}/assign")]
        public async Task<IActionResult> AssignTask(long id, [FromBody] AssignTaskDto request)
        {
            var task = await _context.CongViecs.FindAsync(id);
            if (task == null)
                return NotFound(new { message = "Không tìm thấy công việc!" });

            task.NhanSu = request.NhanSu?.Trim();
            await _context.SaveChangesAsync();

            return Ok(new { message = "Phân công nhân sự thành công!" });
        }

        // --- 9. ĐÁNH DẤU HOÀN THÀNH ---
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTask(long id)
        {
            var task = await _context.CongViecs.FindAsync(id);
            if (task == null)
                return NotFound(new { message = "Không tìm thấy công việc!" });

            task.TienDo = 100;
            task.TrangThai = "Hoàn thành";
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đã đánh dấu hoàn thành công việc!" });
        }

        // --- 10. XÓA CÔNG VIỆC ---
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(long id)
        {
            var task = await _context.CongViecs.FindAsync(id);
            if (task == null)
                return NotFound(new { message = "Không tìm thấy công việc để xóa!" });

            _context.CongViecs.Remove(task);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Xóa công việc thành công!" });
        }
    }
}
