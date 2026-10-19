namespace EventManager.Api.DTOs
{
    public class DashboardSummaryDto
    {
        public int ActiveEvents { get; set; }
        public int PendingTasks { get; set; }
        public int TotalParticipants { get; set; }
        public int EventDocuments { get; set; }
        public int SentNotifications { get; set; }
        public int CompletedReports { get; set; }
    }
}
