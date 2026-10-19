using EventManager.Api.Data;
using EventManager.Api.DTOs;
using EventManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // 1. GET: api/canbo/participants - Lấy toàn bộ người tham gia
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

        // 2. PUT: api/canbo/participants/{code}/attendance - Cập nhật trạng thái điểm danh
        [HttpPut("{code}/attendance")]
        public async Task<IActionResult> UpdateAttendance(string code, [FromBody] UpdateAttendanceRequest request)
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

        public class UpdateAttendanceRequest
        {
            public string AttendanceStatus { get; set; } = string.Empty;
        }
    }
}
