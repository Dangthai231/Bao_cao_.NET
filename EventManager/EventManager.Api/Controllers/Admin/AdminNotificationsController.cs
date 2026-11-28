using EventManager.Api.Data;
using EventManager.Api.DTOs;
using EventManager.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers.Admin
{
    /// <summary>
    /// Use case "Quản lý thông báo": tạo, cập nhật, duyệt, đăng, gỡ và tra cứu thông báo.
    /// Luồng trạng thái: Chờ duyệt (hoặc "Đã gửi" từ Cán bộ) → Đã duyệt / Từ chối → Đã đăng → Đã gỡ
    /// </summary>
    [Route("api/admin/notifications")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminNotificationsController : AdminControllerBase
    {
        public AdminNotificationsController(AppDbContext context) : base(context)
        {
        }

        protected override string? RequiredPermission => AdminHelper.PermNotifications;

        // GET: api/admin/notifications?q=hội thảo&status=Chờ duyệt
        [HttpGet]
        public async Task<IActionResult> GetNotifications(string? q = null, string? status = null)
        {
            var query = _context.Notifications.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(n => (n.Title != null && n.Title.Contains(q)) || (n.NotificationCode != null && n.NotificationCode.Contains(q)));
            if (!string.IsNullOrWhiteSpace(status))
                query = query.Where(n => n.Status == status);

            var list = await query.OrderByDescending(n => n.SendDate).ToListAsync();
            var names = await _context.Users.AsNoTracking().ToDictionaryAsync(u => u.Id, u => u.FullName ?? u.Username);

            var result = list.Select(n => new AdminNotificationDto
            {
                Id = n.Id,
                NotificationCode = string.IsNullOrWhiteSpace(n.NotificationCode) ? $"TB{n.Id:D3}" : n.NotificationCode,
                Title = n.Title,
                Content = n.Content,
                TargetAudience = n.TargetAudience,
                Status = n.Status,
                SendDate = n.SendDate,
                CreatorName = names.ContainsKey(n.CreatedById) ? names[n.CreatedById] : null,
                ReviewNote = n.ReviewNote
            }).ToList();
            return Ok(result);
        }

        // POST: api/admin/notifications - Tạo thông báo (trạng thái Chờ duyệt)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdminNotificationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.Content))
                return Invalid("Vui lòng nhập tiêu đề và nội dung thông báo.");

            var notification = new Notification
            {
                NotificationCode = await NextCodeAsync(),
                Status = AdminHelper.StatusPending,
                CreatedById = CurrentUserId,
                SendDate = DateTime.Now,
                SentAt = DateTime.Now
            };
            Apply(notification, request);

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            return Success($"Tạo thông báo {notification.NotificationCode} thành công!");
        }

        // PUT: api/admin/notifications/5 - Cập nhật thông báo (sau khi sửa phải duyệt lại)
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AdminNotificationRequest request)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return Missing();
            if (notification.Status == AdminHelper.NotifPublished || notification.Status == AdminHelper.NotifRemoved)
                return WrongState(notification.Status);
            if (string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.Content))
                return Invalid("Vui lòng nhập tiêu đề và nội dung thông báo.");

            Apply(notification, request);
            notification.Status = AdminHelper.StatusPending;
            notification.ReviewNote = null;

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Success("Cập nhật thông báo thành công, thông báo chuyển về Chờ duyệt.");
        }

        // PUT: api/admin/notifications/5/review - Duyệt / từ chối
        [HttpPut("{id:int}/review")]
        public async Task<IActionResult> Review(int id, [FromBody] AdminReviewRequest request)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return Missing();
            if (!AdminHelper.PendingNotificationStatuses.Contains(notification.Status ?? ""))
                return WrongState(notification.Status);
            if (!request.Approved && string.IsNullOrWhiteSpace(request.Reason))
                return Invalid("Vui lòng nhập lý do từ chối.");

            notification.Status = AdminHelper.ReviewStatus(request.Approved);
            notification.ReviewNote = request.Reason;

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Success(request.Approved ? "Đã duyệt thông báo." : "Đã từ chối thông báo.");
        }

        // PUT: api/admin/notifications/5/publish - Đăng thông báo đã duyệt
        [HttpPut("{id:int}/publish")]
        public async Task<IActionResult> Publish(int id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return Missing();
            if (notification.Status != AdminHelper.StatusApproved) return WrongState(notification.Status);

            notification.Status = AdminHelper.NotifPublished;
            notification.SendDate = DateTime.Now;
            notification.SentAt = DateTime.Now;

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Success("Đăng thông báo thành công!");
        }

        // PUT: api/admin/notifications/5/withdraw - Gỡ thông báo đã đăng
        [HttpPut("{id:int}/withdraw")]
        public async Task<IActionResult> Withdraw(int id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return Missing();
            if (notification.Status != AdminHelper.NotifPublished) return WrongState(notification.Status);

            notification.Status = AdminHelper.NotifRemoved;
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Success("Đã gỡ thông báo.");
        }

        private static void Apply(Notification notification, AdminNotificationRequest request)
        {
            notification.Title = request.Title.Trim();
            notification.Content = request.Content.Trim();
            notification.Message = notification.Content;
            notification.TargetAudience = string.IsNullOrWhiteSpace(request.TargetAudience) ? "Tất cả người tham gia" : request.TargetAudience;
        }

        /// <summary>Sinh mã TBxxx tiếp theo, cùng cách đánh mã với phân hệ Cán bộ</summary>
        private async Task<string> NextCodeAsync()
        {
            int maxNumber = 0;
            var codes = await _context.Notifications
                .Where(n => n.NotificationCode != null && n.NotificationCode.StartsWith("TB"))
                .Select(n => n.NotificationCode)
                .ToListAsync();

            foreach (var code in codes)
            {
                if (code != null && int.TryParse(code.Substring(2), out int number) && number > maxNumber)
                    maxNumber = number;
            }

            int maxId = await _context.Notifications.AnyAsync() ? await _context.Notifications.MaxAsync(n => n.Id) : 0;
            if (maxId > maxNumber) maxNumber = maxId;

            return $"TB{maxNumber + 1:D3}";
        }
    }
}
