using EventManager.Api.Data;
using EventManager.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Api.Controllers.CanBo
{
    [Route("api/canbo/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var summary = new DashboardSummaryDto
            {
                ActiveEvents = await _context.Events.CountAsync(e => e.Status == "Ongoing"),
                PendingTasks = await _context.Events.CountAsync(e => e.Status == "Completed"),
                TotalParticipants = await _context.Participants.CountAsync(),
                EventDocuments = await _context.Documents.CountAsync(),
                SentNotifications = await _context.Notifications.CountAsync(),
                CompletedReports = await _context.Reports.CountAsync(r => r.IsCompleted)
            };

            return Ok(summary);
        }
    }
}
