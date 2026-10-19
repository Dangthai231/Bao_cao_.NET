using EventManager.Api.Data;
using EventManager.Api.DTOs.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers.CanBo
{
    [Route("api/canbo/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET /api/canbo/reports/statistics?fromDate=2026-01-01&amp;toDate=2026-12-31
        /// Trả về dữ liệu thống kê để vẽ biểu đồ ở FE.
        /// </summary>
        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics(
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate)
        {
            // Mặc định: năm hiện tại nếu không truyền filter
            var from = fromDate ?? new DateTime(DateTime.Now.Year, 1, 1);
            var to   = toDate   ?? new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59);

            // ── Sự kiện ──────────────────────────────────────────────
            var eventsQuery = _context.Events
                .Where(e => e.StartDate >= from && e.StartDate <= to);

            var allEvents = await eventsQuery.ToListAsync();

            var total      = allEvents.Count;
            var ongoing    = allEvents.Count(e => e.Status == "Ongoing");
            var completed  = allEvents.Count(e => e.Status == "Completed");
            var cancelled  = allEvents.Count(e => e.Status == "Cancelled");

            // Số sự kiện theo tháng
            var eventsByMonth = Enumerable.Range(1, 12).ToDictionary(
                m => $"T{m}",
                m => allEvents.Count(e => e.StartDate.Month == m)
            );

            // ── Người tham gia ────────────────────────────────────────
            var eventIds = allEvents.Select(e => e.Id).ToList();

            var participants = await _context.Participants
                .Where(p => eventIds.Contains(p.EventId))
                .ToListAsync();

            var totalParticipants   = participants.Count;
            var attendedParticipants = participants.Count(p => p.Attended);

            // Người tham gia đăng ký theo tháng
            var participantsByMonth = Enumerable.Range(1, 12).ToDictionary(
                m => $"T{m}",
                m => participants.Count(p => p.RegisteredAt.Month == m)
            );

            var dto = new ReportDataDto
            {
                TotalEvents          = total,
                OngoingEvents        = ongoing,
                CompletedEvents      = completed,
                CancelledEvents      = cancelled,
                TotalParticipants    = totalParticipants,
                AttendedParticipants = attendedParticipants,
                EventsByMonth        = eventsByMonth,
                ParticipantsByMonth  = participantsByMonth,
            };

            return Ok(dto);
        }
    }
}
