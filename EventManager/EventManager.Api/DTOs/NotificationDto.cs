using System;

namespace EventManager.Api.DTOs
{
    public class NotificationDto
    {
        public string? NotificationCode { get; set; } = string.Empty; // Mã (VD: TB001)
        public string Title { get; set; } = string.Empty;             // Tiêu đề
        public string? Content { get; set; } = string.Empty;          // Nội dung
        public string? TargetAudience { get; set; } = string.Empty;   // Đối tượng
        public DateTime SendDate { get; set; } = DateTime.Now;        // Ngày gửi
        public string? Status { get; set; } = string.Empty;           // Trạng thái (Đã gửi/Nháp/Đã hủy)
    }
}
