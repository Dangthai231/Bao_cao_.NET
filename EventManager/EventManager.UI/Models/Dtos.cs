using System.Collections.Generic;

namespace EventManager.UI.Models
{
    /// <summary>
    /// Tương ứng với DashboardSummaryDto ở BE
    /// </summary>
    public class DashboardSummaryDto
    {
        public int ActiveEvents { get; set; }
        public int PendingTasks { get; set; }
        public int TotalParticipants { get; set; }
        public int EventDocuments { get; set; }
        public int SentNotifications { get; set; }
        public int CompletedReports { get; set; }
    }

    /// <summary>
    /// Tương ứng với ReportDataDto ở BE — dùng để vẽ biểu đồ
    /// </summary>
    public class ReportDataDto
    {
        public int TotalEvents { get; set; }
        public int OngoingEvents { get; set; }
        public int CompletedEvents { get; set; }
        public int CancelledEvents { get; set; }

        public int TotalParticipants { get; set; }
        public int AttendedParticipants { get; set; }

        public Dictionary<string, int> EventsByMonth { get; set; } = new();
        public Dictionary<string, int> ParticipantsByMonth { get; set; } = new();
    }
}
