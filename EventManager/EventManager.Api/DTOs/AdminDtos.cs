using System;
using System.Collections.Generic;

namespace EventManager.Api.DTOs
{
    // ==========================================
    // DỮ LIỆU GỬI LÊN (REQUEST)
    // ==========================================

    public class AdminAccountRequest
    {
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ClassName { get; set; }
        public string? StudentCode { get; set; }
        public string? Password { get; set; }
    }

    public class AdminLockRequest
    {
        public bool IsActive { get; set; }
    }

    public class AdminPasswordRequest
    {
        public string Password { get; set; } = string.Empty;
        public string? CurrentPassword { get; set; }
    }

    public class AdminReviewRequest
    {
        public bool Approved { get; set; }
        public string? Reason { get; set; }
    }

    public class AdminEventRequest
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxParticipants { get; set; }
        public string Status { get; set; } = "Ongoing";
    }

    public class AdminAssignRequest
    {
        public int ManagerId { get; set; }
    }

    public class AdminNotificationRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? TargetAudience { get; set; }
    }

    public class AdminPermissionRequest
    {
        public string Role { get; set; } = string.Empty;
        public List<string> Permissions { get; set; } = new List<string>();
    }

    // ==========================================
    // DỮ LIỆU TRẢ VỀ (RESPONSE)
    // ==========================================

    public class AdminAccountDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string Role { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ClassName { get; set; }
        public string? StudentCode { get; set; }
        public bool IsActive { get; set; }
    }

    public class AdminChangeRequestDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? ReviewNote { get; set; }
        public string? Evidence { get; set; }

        // Thông tin hiện tại
        public string? CurrentFullName { get; set; }
        public string? CurrentEmail { get; set; }
        public string? CurrentPhoneNumber { get; set; }
        public string? CurrentClassName { get; set; }

        // Thông tin đề xuất thay đổi
        public string? NewFullName { get; set; }
        public string? NewEmail { get; set; }
        public string? NewPhoneNumber { get; set; }
        public string? NewClassName { get; set; }
    }

    public class AdminEventDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int MaxParticipants { get; set; }
        public int? ManagerId { get; set; }
        public string? ManagerName { get; set; }
        public int RegisteredCount { get; set; }
    }

    public class AdminTaskDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Status { get; set; }
        public string? Owner { get; set; }
        public int Progress { get; set; }
        public DateTime? Deadline { get; set; }
    }

    public class AdminProgressDto
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public int Progress { get; set; }
        public List<AdminTaskDto> Tasks { get; set; } = new List<AdminTaskDto>();
    }

    public class AdminPlanDto
    {
        public int Id { get; set; }
        public string PlanName { get; set; } = string.Empty;
        public string Objective { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? ReviewNote { get; set; }
        public int? EventId { get; set; }
    }

    public class AdminNotificationDto
    {
        public int Id { get; set; }
        public string? NotificationCode { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? TargetAudience { get; set; }
        public string? Status { get; set; }
        public DateTime SendDate { get; set; }
        public string? CreatorName { get; set; }
        public string? ReviewNote { get; set; }
    }

    public class AdminDashboardDto
    {
        public int TotalAccounts { get; set; }
        public int TotalEvents { get; set; }
        public int UpcomingCount { get; set; }
        public int PublishedNotifications { get; set; }
        public int PendingPlans { get; set; }
        public int PendingNotifications { get; set; }
        public int PendingProfiles { get; set; }
        public List<AdminEventDto> UpcomingEvents { get; set; } = new List<AdminEventDto>();
    }

    public class AdminPermissionDto
    {
        public int UserId { get; set; }
        public string Role { get; set; } = string.Empty;
        public List<string> Permissions { get; set; } = new List<string>();
        public IReadOnlyList<string> Catalog { get; set; } = Array.Empty<string>();
        public bool CanEdit { get; set; }
        public bool HasImplicitAdminAccess { get; set; }
    }

    public class AdminMonthDto
    {
        public string Month { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class AdminTopEventDto
    {
        public string Title { get; set; } = string.Empty;
        public int Count { get; set; }
        public int MaxParticipants { get; set; }
    }

    public class AdminRoleCountDto
    {
        public string Role { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class AdminReportDto
    {
        public int Registered { get; set; }
        public int Attended { get; set; }
        public int Absent { get; set; }
        public double AverageRating { get; set; }
        public List<AdminMonthDto> Months { get; set; } = new List<AdminMonthDto>();
        public List<AdminTopEventDto> TopEvents { get; set; } = new List<AdminTopEventDto>();
        public List<AdminRoleCountDto> Roles { get; set; } = new List<AdminRoleCountDto>();
    }
}
