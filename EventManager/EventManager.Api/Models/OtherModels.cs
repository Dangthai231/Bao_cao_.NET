using System;

namespace EventManager.Api.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public string FileSize { get; set; } = string.Empty;
        public DateTime UploadDate { get; set; } = DateTime.Now;
        public string UploadedBy { get; set; } = string.Empty;
        public int EventId { get; set; }
    }

    public class Plan
    {
        public int Id { get; set; }
        public string PlanName { get; set; } = string.Empty;
        public string Objective { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public decimal Budget { get; set; }
    }

    public class Notification
    {
        public int Id { get; set; }
        public string? NotificationCode { get; set; } = string.Empty;
        public string? Title { get; set; } = string.Empty;
        public string? Content { get; set; } = string.Empty;
        public string? TargetAudience { get; set; } = string.Empty;
        public DateTime SendDate { get; set; } = DateTime.Now;
        public string? Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int CreatedById { get; set; } = 2;
        public DateTime SentAt { get; set; } = DateTime.Now;
    }

    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
