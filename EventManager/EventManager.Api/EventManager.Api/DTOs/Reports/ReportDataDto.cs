using System.Collections.Generic;

namespace EventManager.Api.DTOs.Reports
{
    /// <summary>
    /// Dữ liệu trả về cho chức năng Lập báo cáo & thống kê (biểu đồ)
    /// </summary>
    public class ReportDataDto
    {
        // ── Tổng quan ────────────────────────────────────────────────
        public int TotalEvents { get; set; }
        public int OngoingEvents { get; set; }
        public int CompletedEvents { get; set; }
        public int CancelledEvents { get; set; }

        public int TotalParticipants { get; set; }
        public int AttendedParticipants { get; set; }

        // ── Dữ liệu biểu đồ cột: số sự kiện theo tháng ──────────────
        // Key = "Tháng 1" … "Tháng 12", Value = số sự kiện
        public Dictionary<string, int> EventsByMonth { get; set; } = new();

        // ── Dữ liệu biểu đồ cột: người tham gia theo tháng ──────────
        public Dictionary<string, int> ParticipantsByMonth { get; set; } = new();
    }
}
