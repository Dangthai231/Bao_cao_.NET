using EventManager.Api.Models;
using System;

namespace EventManager.Api.Controllers.SinhVien
{
    /// <summary>
    /// Các quy tắc nghiệp vụ dùng chung cho phân hệ Sinh viên
    /// </summary>
    public static class SinhVienHelper
    {
        public const string RoleSinhVien       = "HocSinh";

        // Trạng thái đăng ký (cột ConfirmationStatus của Participant)
        public const string StatusRegistered   = "Đã đăng ký";
        public const string StatusCancelled    = "Đã hủy";

        // Trạng thái điểm danh (cột AttendanceStatus của Participant)
        public const string AttendanceNotYet   = "Chưa điểm danh";
        public const string AttendancePresent  = "Đã điểm danh";
        public const string AttendanceAbsent   = "Vắng";

        // Trạng thái sự kiện hiển thị cho sinh viên
        public const string EventUpcoming      = "Sắp diễn ra";
        public const string EventHappening     = "Đang diễn ra";
        public const string EventFinished      = "Đã kết thúc";
        public const string EventCancelled     = "Đã hủy";

        /// <summary>
        /// Thời điểm kết thúc sự kiện. Nếu không có EndDate thì coi như kết thúc cuối ngày bắt đầu.
        /// </summary>
        public static DateTime GetEndTime(Event e)
        {
            return e.EndDate ?? e.StartDate.Date.AddDays(1).AddTicks(-1);
        }

        public static string GetDisplayStatus(Event e, DateTime now)
        {
            if (e.Status == "Cancelled") return EventCancelled;
            if (e.Status == "Completed" || GetEndTime(e) < now) return EventFinished;
            if (e.StartDate > now) return EventUpcoming;
            return EventHappening;
        }

        /// <summary>
        /// Sinh viên chỉ được đăng ký khi sự kiện chưa kết thúc và chưa bị hủy
        /// </summary>
        public static bool IsOpenForRegistration(Event e, DateTime now)
        {
            var status = GetDisplayStatus(e, now);
            return status == EventUpcoming || status == EventHappening;
        }

        /// <summary>
        /// Chỉ được hủy đăng ký trước khi sự kiện bắt đầu
        /// </summary>
        public static bool CanCancel(Participant p, Event e, DateTime now)
        {
            return p.ConfirmationStatus != StatusCancelled
                && e.Status != "Cancelled"
                && e.StartDate > now;
        }

        /// <summary>
        /// Chuẩn hóa trạng thái điểm danh (dữ liệu cũ có thể dùng "Có mặt" / "Vắng mặt" / cờ Attended)
        /// </summary>
        public static string GetAttendanceStatus(Participant p)
        {
            return p.AttendanceStatus switch
            {
                "Có mặt" or AttendancePresent => AttendancePresent,
                "Vắng mặt" or AttendanceAbsent => AttendanceAbsent,
                null or "" => p.Attended ? AttendancePresent : AttendanceNotYet,
                _ => p.AttendanceStatus
            };
        }

        public static string GetConfirmationStatus(Participant p)
        {
            return string.IsNullOrWhiteSpace(p.ConfirmationStatus) ? StatusRegistered : p.ConfirmationStatus;
        }

        public static string GetParticipantCode(Participant p)
        {
            return string.IsNullOrWhiteSpace(p.ParticipantCode) ? $"TG{p.Id:D3}" : p.ParticipantCode;
        }
    }
}
