using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManager.Api.Migrations
{
    /// <summary>
    /// Dữ liệu mẫu cho phân hệ Sinh viên (tài khoản hocsinh01, UserId = 3):
    /// thêm 4 sự kiện sắp diễn ra, 13 lượt đăng ký và 5 đánh giá.
    /// Mỗi câu lệnh đều kiểm tra "chưa có thì mới thêm" nên chạy lại nhiều lần không bị trùng.
    /// </summary>
    public partial class AddSinhVienSampleData : Migration
    {
        // Sự kiện mới: Tiêu đề, Bắt đầu, Kết thúc, Mô tả, Địa điểm, Số lượng tối đa
        private static readonly (string Title, string Start, string End, string Desc, string Location, int Max)[] NewEvents =
        {
            ("Cuộc thi Lập trình Sinh viên EPU 2026", "2026-12-02 08:00:00", "2026-12-02 17:00:00",
                "Cuộc thi lập trình theo đội 3 người, giải thuật và xây dựng ứng dụng.", "Phòng máy A3 - Cơ sở 1", 90),
            ("Hội thảo Kỹ năng phỏng vấn IT", "2026-12-10 14:00:00", "2026-12-10 16:30:00",
                "Chia sẻ kinh nghiệm phỏng vấn từ các anh chị cựu sinh viên đang làm tại doanh nghiệp.", "Hội trường B - Tầng 2", 150),
            ("Đêm nhạc Chào năm mới 2027", "2026-12-28 19:00:00", "2026-12-28 22:00:00",
                "Chương trình văn nghệ chào đón năm mới của Liên chi đoàn CNTT.", "Sân trung tâm", 0),
            ("Chiến dịch Xuân tình nguyện 2027", "2027-01-15 07:00:00", "2027-01-18 17:00:00",
                "Hoạt động tình nguyện tại địa phương dịp Tết Nguyên đán.", "Huyện Ba Vì, Hà Nội", 60),
        };

        // Đăng ký của hocsinh01: Id sự kiện (hoặc câu SELECT lấy Id), Ngày đăng ký, Đã có mặt, Điểm danh, Trạng thái đăng ký
        private static readonly (string EventId, string RegisteredAt, int Attended, string Attendance, string Confirmation)[] Registrations =
        {
            ("1",  "2026-01-10 09:00:00", 1, "Đã điểm danh",   "Đã đăng ký"),
            ("2",  "2026-02-05 14:00:00", 1, "Đã điểm danh",   "Đã đăng ký"),
            ("3",  "2026-03-15 10:30:00", 1, "Đã điểm danh",   "Đã đăng ký"),
            ("5",  "2026-05-12 08:15:00", 1, "Đã điểm danh",   "Đã đăng ký"),
            ("6",  "2026-06-18 16:00:00", 0, "Vắng",           "Đã đăng ký"),
            ("7",  "2026-07-05 20:00:00", 1, "Đã điểm danh",   "Đã đăng ký"),
            ("10", "2026-09-28 11:00:00", 0, "Chưa điểm danh", "Đã hủy"),
            ("13", "2026-11-15 21:00:00", 1, "Đã điểm danh",   "Đã đăng ký"),
            ("14", "2026-11-22 19:45:00", 0, "Chưa điểm danh", "Đã đăng ký"),
            ("15", "2026-11-23 08:20:00", 0, "Chưa điểm danh", "Đã đăng ký"),
            (EventIdOf("Cuộc thi Lập trình Sinh viên EPU 2026"), "2026-11-24 09:00:00", 0, "Chưa điểm danh", "Đã đăng ký"),
            (EventIdOf("Hội thảo Kỹ năng phỏng vấn IT"),         "2026-11-24 09:05:00", 0, "Chưa điểm danh", "Đã đăng ký"),
            (EventIdOf("Đêm nhạc Chào năm mới 2027"),            "2026-11-24 09:10:00", 0, "Chưa điểm danh", "Đã đăng ký"),
        };

        // Đánh giá của hocsinh01 (chừa sự kiện 2 và 13 để thử gửi đánh giá mới)
        private static readonly (int EventId, int Rating, string Comment, string CreatedAt)[] Feedbacks =
        {
            (1, 5, "Hội thảo rất bổ ích, diễn giả nhiệt tình, nội dung sát thực tế.", "2026-01-16 20:10:00"),
            (3, 4, "Tổ chức chu đáo, tuy nhiên thời gian hơi ngắn.",                "2026-03-21 21:30:00"),
            (5, 5, "Triển lãm đẹp, nhiều sản phẩm sáng tạo của sinh viên.",          "2026-05-19 18:45:00"),
            (7, 3, "Cuộc thi hay nhưng khâu chấm điểm còn chậm.",                    "2026-07-13 22:00:00"),
            (8, 4, "Buổi giao lưu vui, kết nối được nhiều bạn mới.",                 "2026-08-09 19:20:00"),
        };

        private static string EventIdOf(string title) =>
            $"(SELECT Id FROM (SELECT Id FROM events WHERE Title = '{title}' ORDER BY Id LIMIT 1) AS t)";

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (var e in NewEvents)
            {
                migrationBuilder.Sql($@"
                    INSERT INTO events (Title, Status, StartDate, EndDate, CreatedById, Description, Location, MaxParticipants)
                    SELECT '{e.Title}', 'Ongoing', '{e.Start}', '{e.End}', 2, '{e.Desc}', '{e.Location}', {e.Max}
                    FROM DUAL
                    WHERE NOT EXISTS (SELECT 1 FROM events WHERE Title = '{e.Title}');");
            }

            foreach (var r in Registrations)
            {
                migrationBuilder.Sql($@"
                    INSERT INTO participants (FullName, EventId, Attended, RegisteredAt, AttendanceStatus, ConfirmationStatus, Email, PhoneNumber, Role, UserId)
                    SELECT 'Nguyễn Văn Sinh', ev.Id, {r.Attended}, '{r.RegisteredAt}', '{r.Attendance}', '{r.Confirmation}',
                           'hocsinh01@epu.edu.vn', '0912345678', 'Sinh viên', 3
                    FROM (SELECT {r.EventId} AS Id) AS ev
                    WHERE ev.Id IS NOT NULL
                      AND NOT EXISTS (SELECT 1 FROM participants p WHERE p.UserId = 3 AND p.EventId = ev.Id);");
            }

            // Mã đăng ký dạng TG001, TG002... cho các dòng chưa có mã
            migrationBuilder.Sql(@"
                UPDATE participants SET ParticipantCode = CONCAT('TG', LPAD(Id, 3, '0'))
                WHERE UserId = 3 AND (ParticipantCode IS NULL OR ParticipantCode = '');");

            foreach (var f in Feedbacks)
            {
                migrationBuilder.Sql($@"
                    INSERT INTO eventfeedbacks (EventId, UserId, Rating, Comment, CreatedAt)
                    SELECT {f.EventId}, 3, {f.Rating}, '{f.Comment}', '{f.CreatedAt}'
                    FROM DUAL
                    WHERE NOT EXISTS (SELECT 1 FROM eventfeedbacks WHERE UserId = 3 AND EventId = {f.EventId});");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (var f in Feedbacks)
                migrationBuilder.Sql($"DELETE FROM eventfeedbacks WHERE UserId = 3 AND EventId = {f.EventId} AND Comment = '{f.Comment}';");

            foreach (var r in Registrations)
                migrationBuilder.Sql($"DELETE FROM participants WHERE UserId = 3 AND RegisteredAt = '{r.RegisteredAt}';");

            foreach (var e in NewEvents)
                migrationBuilder.Sql($"DELETE FROM events WHERE Title = '{e.Title}' AND NOT EXISTS (SELECT 1 FROM (SELECT EventId FROM participants) p WHERE p.EventId = events.Id);");
        }
    }
}
