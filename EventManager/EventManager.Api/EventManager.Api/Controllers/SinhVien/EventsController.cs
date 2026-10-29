using EventManager.Api.Data;
using EventManager.Api.DTOs.SinhVien;
using EventManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers.SinhVien
{
    /// <summary>
    /// Use case "Tra cứu sự kiện": xem danh sách, tìm kiếm, lọc theo ngày, xem chi tiết
    /// </summary>
    [Route("api/sinhvien/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/sinhvien/events?userId=3&keyword=hội thảo&fromDate=2026-11-01&toDate=2026-12-31
        [HttpGet]
        public async Task<IActionResult> GetEvents(int userId, string? keyword, DateTime? fromDate, DateTime? toDate)
        {
            var query = _context.Events.AsQueryable();

            // Tìm kiếm theo tên / địa điểm / mô tả
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var kw = keyword.Trim();
                query = query.Where(e => e.Title.Contains(kw)
                                      || (e.Location != null && e.Location.Contains(kw))
                                      || (e.Description != null && e.Description.Contains(kw)));
            }

            // Lọc theo ngày diễn ra
            if (fromDate.HasValue)
            {
                var from = fromDate.Value.Date;
                query = query.Where(e => e.StartDate >= from);
            }
            if (toDate.HasValue)
            {
                var to = toDate.Value.Date.AddDays(1);
                query = query.Where(e => e.StartDate < to);
            }

            var events = await query.OrderByDescending(e => e.StartDate).ToListAsync();
            var result = await BuildDtosAsync(events, userId);

            return Ok(result);
        }

        // GET: api/sinhvien/events/13?userId=3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventDetail(int id, int userId)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null)
            {
                return NotFound(new { message = "Không tìm thấy sự kiện!" });
            }

            var result = await BuildDtosAsync(new List<Event> { ev }, userId);
            return Ok(result[0]);
        }

        private async Task<List<StudentEventDto>> BuildDtosAsync(List<Event> events, int userId)
        {
            var eventIds = events.Select(e => e.Id).ToList();

            // Đếm số đăng ký còn hiệu lực của từng sự kiện
            var activeRegs = await _context.Participants
                .Where(p => eventIds.Contains(p.EventId) && p.ConfirmationStatus != SinhVienHelper.StatusCancelled)
                .Select(p => new { p.EventId, p.UserId })
                .ToListAsync();

            var countByEvent = activeRegs.GroupBy(r => r.EventId).ToDictionary(g => g.Key, g => g.Count());
            var myEventIds = activeRegs.Where(r => r.UserId == userId).Select(r => r.EventId).ToHashSet();

            var now = DateTime.Now;

            return events.Select(e =>
            {
                int count = countByEvent.TryGetValue(e.Id, out var c) ? c : 0;
                bool isRegistered = myEventIds.Contains(e.Id);
                bool isFull = e.MaxParticipants > 0 && count >= e.MaxParticipants;

                return new StudentEventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Description = e.Description ?? string.Empty,
                    Location = e.Location ?? string.Empty,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Status = SinhVienHelper.GetDisplayStatus(e, now),
                    RegisteredCount = count,
                    MaxParticipants = e.MaxParticipants,
                    IsRegistered = isRegistered,
                    CanRegister = !isRegistered && !isFull && SinhVienHelper.IsOpenForRegistration(e, now)
                };
            }).ToList();
        }
    }
}
