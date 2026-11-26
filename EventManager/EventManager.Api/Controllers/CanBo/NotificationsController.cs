using EventManager.Api.Data;
using EventManager.Api.DTOs;
using EventManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers.CanBo
{
    [Route("api/canbo/notifications")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotificationsController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET: api/canbo/notifications - Lấy danh sách tất cả thông báo
        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var notifications = await _context.Notifications
                .OrderByDescending(n => n.SendDate)
                .ThenByDescending(n => n.Id)
                .ToListAsync();

            var result = notifications.Select(n => new NotificationDto
            {
                NotificationCode = string.IsNullOrWhiteSpace(n.NotificationCode) ? $"TB{n.Id:D3}" : n.NotificationCode,
                Title = n.Title ?? n.Message ?? string.Empty,
                Content = n.Content ?? n.Message ?? string.Empty,
                TargetAudience = string.IsNullOrWhiteSpace(n.TargetAudience) ? "Tất cả người tham gia" : n.TargetAudience,
                SendDate = n.SendDate != default ? n.SendDate : n.SentAt,
                Status = string.IsNullOrWhiteSpace(n.Status) ? "Đã gửi" : n.Status
            }).ToList();

            return Ok(result);
        }

        // 2. POST: api/canbo/notifications - Tạo mới thông báo
        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationDto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Title))
            {
                return BadRequest(new { message = "Tiêu đề thông báo không được để trống!" });
            }

            try
            {
                // Tự động sinh mã NotificationCode nếu chưa có (TB001, TB002, ...)
                string code = request.NotificationCode ?? string.Empty;
                if (string.IsNullOrWhiteSpace(code))
                {
                    int maxNum = 0;
                    var existingCodes = await _context.Notifications
                        .Select(n => n.NotificationCode)
                        .Where(c => c != null && c.StartsWith("TB"))
                        .ToListAsync();

                    foreach (var c in existingCodes)
                    {
                        if (c != null && c.Length > 2 && int.TryParse(c.Substring(2), out int num))
                        {
                            if (num > maxNum) maxNum = num;
                        }
                    }

                    var maxId = await _context.Notifications.AnyAsync()
                        ? await _context.Notifications.MaxAsync(n => n.Id)
                        : 0;
                    if (maxId > maxNum) maxNum = maxId;

                    code = $"TB{(maxNum + 1):D3}";
                }

                var contentText = request.Content ?? string.Empty;
                var messageText = string.IsNullOrWhiteSpace(contentText) ? request.Title : contentText;

                var newNotification = new Notification
                {
                    NotificationCode = code,
                    Title = request.Title.Trim(),
                    Content = contentText,
                    Message = messageText,
                    TargetAudience = string.IsNullOrWhiteSpace(request.TargetAudience) ? "Tất cả người tham gia" : request.TargetAudience,
                    SendDate = request.SendDate != default ? request.SendDate : DateTime.Now,
                    Status = string.IsNullOrWhiteSpace(request.Status) ? "Đã gửi" : request.Status,
                    SentAt = request.SendDate != default ? request.SendDate : DateTime.Now,
                    CreatedById = 2
                };

                _context.Notifications.Add(newNotification);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Tạo thông báo thành công!", notificationCode = code });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lưu thông báo: " + ex.Message });
            }
        }

        // 3. PUT: api/canbo/notifications/{code} - Cập nhật thông báo
        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateNotification(string code, [FromBody] NotificationDto request)
        {
            if (string.IsNullOrWhiteSpace(code) || request == null)
            {
                return BadRequest(new { message = "Dữ liệu không hợp lệ!" });
            }

            try
            {
                var notif = await _context.Notifications
                    .FirstOrDefaultAsync(n => n.NotificationCode == code);

                // Thử tìm theo ID nếu code có dạng TB001
                if (notif == null && code.StartsWith("TB") && int.TryParse(code.Substring(2), out int parsedId))
                {
                    notif = await _context.Notifications.FindAsync(parsedId);
                }

                if (notif == null)
                {
                    return NotFound(new { message = $"Không tìm thấy thông báo có mã {code}!" });
                }

                var contentText = request.Content ?? string.Empty;
                var messageText = string.IsNullOrWhiteSpace(contentText) ? request.Title : contentText;

                notif.Title = request.Title;
                notif.Content = contentText;
                notif.Message = messageText;
                notif.TargetAudience = string.IsNullOrWhiteSpace(request.TargetAudience) ? "Tất cả người tham gia" : request.TargetAudience;
                notif.SendDate = request.SendDate != default ? request.SendDate : DateTime.Now;
                notif.Status = string.IsNullOrWhiteSpace(request.Status) ? "Đã gửi" : request.Status;
                notif.SentAt = notif.SendDate;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Cập nhật thông báo thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi cập nhật thông báo: " + ex.Message });
            }
        }

        // 4. DELETE: api/canbo/notifications/{code} - Xóa thông báo
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteNotification(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return BadRequest(new { message = "Mã thông báo không hợp lệ!" });
            }

            try
            {
                var notif = await _context.Notifications
                    .FirstOrDefaultAsync(n => n.NotificationCode == code);

                // Thử tìm theo ID nếu code có dạng TB001
                if (notif == null && code.StartsWith("TB") && int.TryParse(code.Substring(2), out int parsedId))
                {
                    notif = await _context.Notifications.FindAsync(parsedId);
                }

                if (notif == null)
                {
                    return NotFound(new { message = $"Không tìm thấy thông báo có mã {code}!" });
                }

                _context.Notifications.Remove(notif);
                await _context.SaveChangesAsync();

                return Ok(new { message = $"Đã xóa thành công thông báo: {code}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi xóa thông báo: " + ex.Message });
            }
        }
    }
}
