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
    /// Dashboard Admin: số liệu tổng quan và các việc đang chờ duyệt
    /// </summary>
    [Route("api/admin/dashboard")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController : AdminControllerBase
    {
        public AdminDashboardController(AppDbContext context) : base(context)
        {
        }

        // GET: api/admin/dashboard
        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            var now = DateTime.Now;
            var pendingStatuses = AdminHelper.PendingNotificationStatuses;

            var upcoming = await _context.Events.AsNoTracking()
                .Where(e => e.StartDate >= now && e.Status == "Ongoing")
                .OrderBy(e => e.StartDate)
                .Take(10)
                .ToListAsync();

            var permissions = await IsFullAdminAsync()
                ? AdminHelper.PermissionCatalog
                : await _context.AdminPermissions.AsNoTracking().Where(p => p.UserId == CurrentUserId)
                    .Select(p => p.Permission).ToListAsync();

            var dto = new AdminDashboardDto
            {
                Permissions = permissions,
                TotalAccounts = await _context.Users.CountAsync(),
                TotalEvents = await _context.Events.CountAsync(),
                UpcomingCount = await _context.Events.CountAsync(e => e.StartDate >= now && e.Status == "Ongoing"),
                PublishedNotifications = await _context.Notifications.CountAsync(n => n.Status == AdminHelper.NotifPublished),
                PendingPlans = await _context.Plans.CountAsync(p => p.Status == AdminHelper.StatusPending),
                PendingNotifications = await _context.Notifications.CountAsync(n => n.Status != null && pendingStatuses.Contains(n.Status)),
                PendingProfiles = await _context.ProfileChangeRequests.CountAsync(r => r.Status == AdminHelper.StatusPending),
                UpcomingEvents = upcoming.Select(e => new AdminEventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Status = e.Status,
                    Location = e.Location
                }).ToList()
            };
            return Ok(dto);
        }
    }
}
