using EventManager.Api.Data;
using EventManager.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers.CanBo
{
    [Route("api/canbo/participants")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParticipantsController(AppDbContext context)
        {
            _context = context;
        }

        // =========================================================================
        // 1. GET: api/canbo/participants/events - Danh sách sự kiện kèm số lượng SV
        // =========================================================================
        [HttpGet("events")]
        public async Task<IActionResult> GetEventsWithParticipantCounts()
        {
            var suKiens = await _context.SuKiens
                .OrderBy(s => s.Id)
                .ToListAsync();

            var dangKyList = await _context.DangKySuKiens.ToListAsync();

            var result = new List<ParticipantEventDto>();

            // Phần tử đầu tiên: "Tất cả sự kiện"
            result.Add(new ParticipantEventDto
            {
                Id = 0,
                MaSuKien = "ALL",
                TenSuKien = "Tất cả sự kiện",
                TongSoNguoi = dangKyList.Count,
                DaDiemDanh = dangKyList.Count(d => d.TrangThai == "Đã tham gia"),
                Vang = dangKyList.Count(d => d.TrangThai == "Vắng mặt"),
                ChuaDiemDanh = dangKyList.Count(d => d.TrangThai == "Đã đăng ký" || (d.TrangThai != "Đã tham gia" && d.TrangThai != "Vắng mặt" && d.TrangThai != "Đã hủy"))
            });

            foreach (var sk in suKiens)
            {
                var skDk = dangKyList.Where(d => d.SuKienId == sk.Id).ToList();
                result.Add(new ParticipantEventDto
                {
                    Id = sk.Id,
                    MaSuKien = sk.MaSuKien ?? $"SK{sk.Id:D3}",
                    TenSuKien = sk.TenSuKien ?? $"Sự kiện {sk.Id}",
                    DiaDiem = sk.DiaDiem,
                    ThoiGianBatDau = sk.ThoiGianBatDau,
                    TongSoNguoi = skDk.Count,
                    DaDiemDanh = skDk.Count(d => d.TrangThai == "Đã tham gia"),
                    Vang = skDk.Count(d => d.TrangThai == "Vắng mặt"),
                    ChuaDiemDanh = skDk.Count(d => d.TrangThai == "Đã đăng ký" || (d.TrangThai != "Đã tham gia" && d.TrangThai != "Vắng mặt" && d.TrangThai != "Đã hủy"))
                });
            }

            return Ok(result);
        }

        // =========================================================================
        // 2. GET: api/canbo/participants/by-event - Lấy danh sách người tham gia theo sự kiện
        // =========================================================================
        [HttpGet("by-event")]
        public async Task<IActionResult> GetParticipantsByEvent(
            [FromQuery] long? suKienId,
            [FromQuery] string? search,
            [FromQuery] string? diemDanh)
        {
            var dangKyQuery = _context.DangKySuKiens.AsQueryable();

            if (suKienId.HasValue && suKienId.Value > 0)
            {
                dangKyQuery = dangKyQuery.Where(d => d.SuKienId == suKienId.Value);
            }

            var dangKys = await dangKyQuery.ToListAsync();
            var suKienIds = dangKys.Select(d => d.SuKienId).Distinct().ToList();
            var userNames = dangKys.Select(d => d.TenDangNhap).Distinct().ToList();

            var suKiens = await _context.SuKiens
                .Where(s => suKienIds.Contains(s.Id))
                .ToDictionaryAsync(s => s.Id);

            var sinhViens = await _context.SinhViens
                .Where(sv => userNames.Contains(sv.TenDangNhap))
                .ToDictionaryAsync(sv => sv.TenDangNhap);

            var list = new List<ParticipantItemDto>();

            foreach (var dk in dangKys)
            {
                suKiens.TryGetValue(dk.SuKienId, out var sk);
                sinhViens.TryGetValue(dk.TenDangNhap, out var sv);

                string dd = dk.TrangThai switch
                {
                    "Đã tham gia" => "Đã điểm danh",
                    "Vắng mặt" => "Vắng",
                    _ => "Chưa điểm danh"
                };

                string tt = dk.TrangThai == "Đã hủy" ? "Đã hủy" : "Đã xác nhận";

                list.Add(new ParticipantItemDto
                {
                    DangKyId = dk.Id,
                    SuKienId = dk.SuKienId,
                    TenSuKien = sk?.TenSuKien ?? $"Sự kiện #{dk.SuKienId}",
                    MaSinhVien = sv?.MaSinhVien ?? dk.TenDangNhap,
                    HoTen = sv?.HoTen ?? dk.TenDangNhap,
                    Email = sv?.Email ?? string.Empty,
                    SoDienThoai = sv?.SoDienThoai ?? string.Empty,
                    Lop = sv?.Lop ?? string.Empty,
                    TenDangNhap = dk.TenDangNhap,
                    NgayDangKy = dk.NgayDangKy,
                    DiemDanh = dd,
                    TrangThai = tt
                });
            }

            // Lọc theo từ khóa tìm kiếm
            if (!string.IsNullOrWhiteSpace(search))
            {
                string kw = search.Trim().ToLower();
                list = list.Where(p =>
                    (p.MaSinhVien != null && p.MaSinhVien.ToLower().Contains(kw)) ||
                    (p.HoTen != null && p.HoTen.ToLower().Contains(kw)) ||
                    (p.Email != null && p.Email.ToLower().Contains(kw)) ||
                    (p.SoDienThoai != null && p.SoDienThoai.ToLower().Contains(kw)) ||
                    (p.Lop != null && p.Lop.ToLower().Contains(kw)) ||
                    (p.TenSuKien != null && p.TenSuKien.ToLower().Contains(kw))
                ).ToList();
            }

            // Lọc theo trạng thái điểm danh
            if (!string.IsNullOrWhiteSpace(diemDanh) && !diemDanh.Equals("Tất cả", StringComparison.OrdinalIgnoreCase))
            {
                list = list.Where(p => p.DiemDanh.Equals(diemDanh, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Sắp xếp: theo tên sự kiện, sau đó theo họ tên sinh viên
            list = list.OrderBy(p => p.TenSuKien).ThenBy(p => p.HoTen).ToList();

            return Ok(list);
        }

        // =========================================================================
        // 3. PUT: api/canbo/participants/attendance/{dangKyId} - Cập nhật điểm danh 1 SV
        // =========================================================================
        [HttpPut("attendance/{dangKyId}")]
        public async Task<IActionResult> UpdateAttendanceSingle(long dangKyId, [FromBody] UpdateAttendanceItemDto request)
        {
            var dk = await _context.DangKySuKiens.FindAsync(dangKyId);
            if (dk == null)
            {
                return NotFound(new { message = "Không tìm thấy thông tin đăng ký!" });
            }

            if (dk.TrangThai == "Đã hủy")
            {
                return BadRequest(new { message = "Sinh viên đã hủy đăng ký, không thể điểm danh!" });
            }

            string dbStatus = request.DiemDanh switch
            {
                "Đã điểm danh" => "Đã tham gia",
                "Vắng" => "Vắng mặt",
                _ => "Đã đăng ký"
            };

            dk.TrangThai = dbStatus;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Cập nhật điểm danh thành công!", diemDanh = request.DiemDanh });
        }

        // =========================================================================
        // 4. PUT: api/canbo/participants/attendance/batch - Cập nhật điểm danh hàng loạt
        // =========================================================================
        [HttpPut("attendance/batch")]
        public async Task<IActionResult> UpdateAttendanceBatch([FromBody] List<UpdateAttendanceItemDto> requests)
        {
            if (requests == null || requests.Count == 0)
            {
                return BadRequest(new { message = "Danh sách cập nhật trống!" });
            }

            var ids = requests.Select(r => r.DangKyId).ToList();
            var dks = await _context.DangKySuKiens.Where(d => ids.Contains(d.Id)).ToListAsync();

            int updatedCount = 0;
            foreach (var req in requests)
            {
                var dk = dks.FirstOrDefault(d => d.Id == req.DangKyId);
                if (dk != null && dk.TrangThai != "Đã hủy")
                {
                    string dbStatus = req.DiemDanh switch
                    {
                        "Đã điểm danh" => "Đã tham gia",
                        "Vắng" => "Vắng mặt",
                        _ => "Đã đăng ký"
                    };

                    dk.TrangThai = dbStatus;
                    updatedCount++;
                }
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = $"Đã lưu điểm danh cho {updatedCount} sinh viên!", updatedCount });
        }

        // =========================================================================
        // 5. LEGACY ENDPOINTS (Giữ lại để tương thích ngược)
        // =========================================================================
        [HttpGet]
        public async Task<IActionResult> GetParticipants()
        {
            var participants = await _context.Participants
                .OrderBy(p => p.Id)
                .ToListAsync();

            var result = participants.Select(p => new ParticipantDto
            {
                ParticipantCode = string.IsNullOrWhiteSpace(p.ParticipantCode) ? $"TG{p.Id:D3}" : p.ParticipantCode,
                FullName = p.FullName,
                Email = p.Email ?? string.Empty,
                PhoneNumber = p.PhoneNumber ?? string.Empty,
                Role = string.IsNullOrWhiteSpace(p.Role) ? "Sinh viên" : p.Role,
                AttendanceStatus = string.IsNullOrWhiteSpace(p.AttendanceStatus)
                    ? (p.Attended ? "Đã điểm danh" : "Chưa điểm danh")
                    : (p.AttendanceStatus == "Có mặt" ? "Đã điểm danh" : (p.AttendanceStatus == "Vắng mặt" ? "Vắng" : p.AttendanceStatus)),
                ConfirmationStatus = string.IsNullOrWhiteSpace(p.ConfirmationStatus) ? "Đã xác nhận" : p.ConfirmationStatus
            }).ToList();

            return Ok(result);
        }

        [HttpPut("{code}/attendance")]
        public async Task<IActionResult> UpdateAttendance(string code, [FromBody] UpdateAttendanceLegacyRequest request)
        {
            if (string.IsNullOrWhiteSpace(code) || request == null)
            {
                return BadRequest(new { message = "Dữ liệu không hợp lệ!" });
            }

            var p = await _context.Participants
                .FirstOrDefaultAsync(x => x.ParticipantCode == code);

            if (p == null && code.StartsWith("TG") && int.TryParse(code.Substring(2), out int parsedId))
            {
                p = await _context.Participants.FindAsync(parsedId);
            }

            if (p == null)
            {
                return NotFound(new { message = $"Không tìm thấy người tham gia có mã {code}!" });
            }

            p.AttendanceStatus = request.AttendanceStatus;
            p.Attended = (request.AttendanceStatus == "Đã điểm danh" || request.AttendanceStatus == "Có mặt");

            await _context.SaveChangesAsync();

            return Ok(new { message = "Cập nhật điểm danh thành công!", attendanceStatus = p.AttendanceStatus });
        }

        public class UpdateAttendanceLegacyRequest
        {
            public string AttendanceStatus { get; set; } = string.Empty;
        }
    }
}
