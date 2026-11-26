using System;

namespace EventManager.UI.Models
{
    /// <summary>
    /// Tương ứng với StudentEventDto ở BE — sự kiện hiển thị cho sinh viên
    /// </summary>
    public class StudentEventDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public int RegisteredCount { get; set; }
        public int MaxParticipants { get; set; }
        public bool IsRegistered { get; set; }
        public bool CanRegister { get; set; }

        // Cột hiển thị trên DataGridView
        public string SlotText => MaxParticipants > 0 ? $"{RegisteredCount}/{MaxParticipants}" : $"{RegisteredCount}";
        public string MyStatusText => IsRegistered ? "Đã đăng ký" : (CanRegister ? "Có thể đăng ký" : "—");
    }

    /// <summary>
    /// Tương ứng với RegistrationDto ở BE — một lượt đăng ký của sinh viên
    /// </summary>
    public class RegistrationDto
    {
        public int RegistrationId { get; set; }
        public string ParticipantCode { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EventStatus { get; set; }
        public DateTime RegisteredAt { get; set; }
        public string ConfirmationStatus { get; set; }
        public string AttendanceStatus { get; set; }
        public bool CanCancel { get; set; }
    }

    public class FeedbackDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public string Stars => new string('★', Rating) + new string('☆', 5 - Rating);
    }

    public class StudentProfileDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string StudentCode { get; set; }
        public string ClassName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }

    public class UpdateProfileRequest
    {
        public string FullName { get; set; }
        public string ClassName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
