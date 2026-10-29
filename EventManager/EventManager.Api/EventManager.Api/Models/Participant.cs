using System;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Api.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        public int EventId { get; set; } = 1;

        /// <summary>
        /// Tài khoản sinh viên đã tự đăng ký (null = do cán bộ thêm thủ công)
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// true = đã tham dự thực tế
        /// </summary>
        public bool Attended { get; set; } = false;

        public DateTime RegisteredAt { get; set; } = DateTime.Now;

        public string? ParticipantCode { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Role { get; set; } = string.Empty;
        public string? AttendanceStatus { get; set; } = string.Empty;
        public string? ConfirmationStatus { get; set; } = string.Empty;
    }
}
