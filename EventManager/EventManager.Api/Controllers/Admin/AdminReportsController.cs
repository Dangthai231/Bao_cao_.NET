using EventManager.Api.Data;
using EventManager.Api.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers.Admin
{
    /// <summary>
    /// Báo cáo tổng hợp cho Admin
    /// </summary>
    [Route("api/admin/reports")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminReportsController : AdminControllerBase
    {
        public AdminReportsController(AppDbContext context) : base(context)
        {
        }

        protected override string? RequiredPermission => AdminHelper.PermReports;

        // GET: api/admin/reports
        [HttpGet]
        public async Task<IActionResult> GetReport()
        {
            var participants = await _context.Participants.AsNoTracking()
                .Where(p => p.ConfirmationStatus != "Đã hủy")
                .ToListAsync();
            var events = await _context.Events.AsNoTracking().ToListAsync();
            var ratings = await _context.EventFeedbacks.AsNoTracking().Select(f => f.Rating).ToListAsync();

            var report = new AdminReportDto
            {
                Registered = participants.Count,
                Attended = participants.Count(p => p.Attended || p.AttendanceStatus == "Có mặt" || p.AttendanceStatus == "Đã điểm danh"),
                Absent = participants.Count(p => p.AttendanceStatus == "Vắng mặt" || p.AttendanceStatus == "Vắng"),
                AverageRating = ratings.Count == 0 ? 0 : Math.Round(ratings.Average(), 1)
            };

            // Số sự kiện trong 6 tháng gần nhất
            var firstMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-5);
            for (int i = 0; i < 6; i++)
            {
                var from = firstMonth.AddMonths(i);
                var to = from.AddMonths(1);
                report.Months.Add(new AdminMonthDto
                {
                    Month = from.ToString("MM/yyyy"),
                    Count = events.Count(e => e.StartDate >= from && e.StartDate < to)
                });
            }

            // Top 5 sự kiện có nhiều lượt đăng ký nhất
            report.TopEvents = events
                .Select(e => new AdminTopEventDto
                {
                    Title = e.Title,
                    MaxParticipants = e.MaxParticipants,
                    Count = participants.Count(p => p.EventId == e.Id)
                })
                .OrderByDescending(x => x.Count)
                .Take(5)
                .ToList();

            // Số tài khoản theo vai trò
            report.Roles = await _context.Users
                .GroupBy(u => u.Role)
                .Select(g => new AdminRoleCountDto { Role = g.Key, Count = g.Count() })
                .ToListAsync();

            return Ok(report);
        }
    }
}
