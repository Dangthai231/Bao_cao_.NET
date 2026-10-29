using System;

namespace EventManager.Api.DTOs.SinhVien
{
    // ── Tra cứu sự kiện ──────────────────────────────────────────
    public class StudentEventDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// "Sắp diễn ra" | "Đang diễn ra" | "Đã kết thúc" | "Đã hủy"
        /// </summary>
        public string Status { get; set; } = string.Empty;

        public int RegisteredCount { get; set; }
        public int MaxParticipants { get; set; }

        // Trạng thái theo sinh viên đang đăng nhập
        public bool IsRegistered { get; set; }
        public bool CanRegister { get; set; }
    }

    // ── Đăng ký tham gia ─────────────────────────────────────────
    public class RegisterEventRequest
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }

    public class RegistrationDto
    {
        public int RegistrationId { get; set; }
        public string ParticipantCode { get; set; } = string.Empty;
        public int EventId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EventStatus { get; set; } = string.Empty;
        public DateTime RegisteredAt { get; set; }

        /// <summary>
        /// "Đã đăng ký" | "Đã xác nhận" | "Đã hủy"
        /// </summary>
        public string ConfirmationStatus { get; set; } = string.Empty;

        /// <summary>
        /// "Chưa điểm danh" | "Đã điểm danh" | "Vắng"
        /// </summary>
        public string AttendanceStatus { get; set; } = string.Empty;

        public bool CanCancel { get; set; }
    }

    // ── Đánh giá và phản hồi ─────────────────────────────────────
    public class FeedbackRequest
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }

    public class FeedbackDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    // ── Thông tin cá nhân ────────────────────────────────────────
    public class StudentProfileDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
    }

    public class UpdateProfileRequest
    {
        public string FullName { get; set; } = string.Empty;
        public string? ClassName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }

        // Đổi mật khẩu (không bắt buộc)
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
