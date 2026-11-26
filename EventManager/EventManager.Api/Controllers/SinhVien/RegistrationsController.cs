using EventManager.Api.Data;
using EventManager.Api.DTOs.SinhVien;
using EventManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers.SinhVien
{
    /// <summary>
    /// Use case "Đăng ký tham gia sự kiện": đăng ký, hủy đăng ký,
    /// xem thông tin đăng ký, xem trạng thái tham gia
    /// </summary>
    [Route("api/sinhvien/registrations")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegistrationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/sinhvien/registrations?userId=3 - Danh sách sự kiện mình đã đăng ký
        [HttpGet]
        public async Task<IActionResult> GetMyRegistrations(int userId)
        {
            var now = DateTime.Now;

            var rows = await (from p in _context.Participants
                              join e in _context.Events on p.EventId equals e.Id
                              where p.UserId == userId
                              orderby p.RegisteredAt descending
                              select new { p, e }).ToListAsync();

            var result = rows.Select(r => ToDto(r.p, r.e, now)).ToList();
            return Ok(result);
        }

        // GET: api/sinhvien/registrations/5?userId=3 - Xem thông tin đăng ký
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistration(int id, int userId)
        {
            var p = await _context.Participants.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            if (p == null)
            {
                return NotFound(new { message = "Không tìm thấy thông tin đăng ký!" });
            }

            var e = await _context.Events.FindAsync(p.EventId);
            if (e == null)
            {
                return NotFound(new { message = "Sự kiện không còn tồn tại!" });
            }

            return Ok(ToDto(p, e, DateTime.Now));
        }

        // POST: api/sinhvien/registrations - Đăng ký tham gia sự kiện
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterEventRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Dữ liệu không hợp lệ!" });
            }

            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null || user.Role != SinhVienHelper.RoleSinhVien)
            {
                return BadRequest(new { message = "Tài khoản không phải sinh viên!" });
            }

            var ev = await _context.Events.FindAsync(request.EventId);
            if (ev == null)
            {
                return NotFound(new { message = "Không tìm thấy sự kiện!" });
            }

            var now = DateTime.Now;
            if (!SinhVienHelper.IsOpenForRegistration(ev, now))
            {
                return BadRequest(new { message = $"Sự kiện {SinhVienHelper.GetDisplayStatus(ev, now).ToLower()}, không thể đăng ký!" });
            }

            var existing = await _context.Participants
                .FirstOrDefaultAsync(p => p.UserId == user.Id && p.EventId == ev.Id);

            if (existing != null && existing.ConfirmationStatus != SinhVienHelper.StatusCancelled)
            {
                return Conflict(new { message = "Bạn đã đăng ký sự kiện này rồi!" });
            }

            if (ev.MaxParticipants > 0)
            {
                int count = await _context.Participants
                    .CountAsync(p => p.EventId == ev.Id && p.ConfirmationStatus != SinhVienHelper.StatusCancelled);
                if (count >= ev.MaxParticipants)
                {
                    return BadRequest(new { message = "Sự kiện đã đủ số lượng đăng ký!" });
                }
            }

            if (existing != null)
            {
                // Đã từng hủy → đăng ký lại trên bản ghi cũ
                existing.ConfirmationStatus = SinhVienHelper.StatusRegistered;
                existing.AttendanceStatus = SinhVienHelper.AttendanceNotYet;
                existing.Attended = false;
                existing.RegisteredAt = now;
                existing.FullName = user.FullName ?? user.Username;
                existing.Email = user.Email;
                existing.PhoneNumber = user.PhoneNumber;
                await _context.SaveChangesAsync();
                return Ok(ToDto(existing, ev, now));
            }

            var participant = new Participant
            {
                UserId = user.Id,
                EventId = ev.Id,
                FullName = user.FullName ?? user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = "Sinh viên",
                RegisteredAt = now,
                Attended = false,
                AttendanceStatus = SinhVienHelper.AttendanceNotYet,
                ConfirmationStatus = SinhVienHelper.StatusRegistered
            };

            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            // Sinh mã người tham gia theo Id vừa tạo (giống phân hệ Cán bộ)
            participant.ParticipantCode = $"TG{participant.Id:D3}";
            await _context.SaveChangesAsync();

            return Ok(ToDto(participant, ev, now));
        }

        // PUT: api/sinhvien/registrations/5/cancel?userId=3 - Hủy đăng ký
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id, int userId)
        {
            var p = await _context.Participants.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            if (p == null)
            {
                return NotFound(new { message = "Không tìm thấy thông tin đăng ký!" });
            }

            var ev = await _context.Events.FindAsync(p.EventId);
            var now = DateTime.Now;

            if (ev == null || !SinhVienHelper.CanCancel(p, ev, now))
            {
                return BadRequest(new { message = "Chỉ được hủy đăng ký trước khi sự kiện bắt đầu!" });
            }

            p.ConfirmationStatus = SinhVienHelper.StatusCancelled;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Hủy đăng ký thành công!" });
        }

        private static RegistrationDto ToDto(Participant p, Event e, DateTime now)
        {
            return new RegistrationDto
            {
                RegistrationId = p.Id,
                ParticipantCode = SinhVienHelper.GetParticipantCode(p),
                EventId = e.Id,
                EventTitle = e.Title,
                Location = e.Location ?? string.Empty,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                EventStatus = SinhVienHelper.GetDisplayStatus(e, now),
                RegisteredAt = p.RegisteredAt,
                ConfirmationStatus = SinhVienHelper.GetConfirmationStatus(p),
                AttendanceStatus = SinhVienHelper.GetAttendanceStatus(p),
                CanCancel = SinhVienHelper.CanCancel(p, e, now)
            };
        }
    }
}
