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
                
                ActiveEvents = await _context.Events.CountAsync(),
                PendingTasks = await _context.Tasks.CountAsync(t => t.Status == "Pending"),
                TotalParticipants = await _context.Participants.CountAsync(),
                EventDocuments = await _context.Documents.CountAsync(),
                SentNotifications = await _context.Notifications.CountAsync(),
                CompletedReports = await _context.Reports.CountAsync(r => r.IsCompleted)
            };

            return Ok(summary);
        }
    }

}
