using EventManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User>        Users        { get; set; }
        public DbSet<Event>       Events       { get; set; }
        public DbSet<EventTask>   Tasks        { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Document>    Documents    { get; set; }
        public DbSet<Plan>        Plans        { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Report>      Reports      { get; set; }
        public DbSet<EventFeedback> EventFeedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ── Users ────────────────────────────────────────────────
            modelBuilder.Entity<User>().HasData(
                
                new User { Id = 1, Username = "admin",     Password = "admin123", Role = "Admin" },
                new User { Id = 2, Username = "canbo01",   Password = "canbo123", Role = "CanBo" },
                new User
                {
                    Id = 3, Username = "hocsinh01", Password = "hs123", Role = "HocSinh",
                    FullName = "Nguyễn Văn Sinh", StudentCode = "22810310001", ClassName = "D17CNPM1",
                    Email = "hocsinh01@epu.edu.vn", PhoneNumber = "0912345678",
                    DateOfBirth = new System.DateTime(2004, 5, 20)
                }
            );

            // ── Seed Events (mỗi tháng 1 sự kiện, năm 2026) ─────────
            modelBuilder.Entity<Event>().HasData(
                new Event { Id =  1, Title = "Hội thảo T1",  Status = "Completed", StartDate = new System.DateTime(2026, 1, 15), CreatedById = 2 },
                new Event { Id =  2, Title = "Sự kiện T2",   Status = "Completed", StartDate = new System.DateTime(2026, 2, 10), CreatedById = 2 },
                new Event { Id =  3, Title = "Hội nghị T3",  Status = "Completed", StartDate = new System.DateTime(2026, 3, 20), CreatedById = 2 },
                new Event { Id =  4, Title = "Workshop T4",  Status = "Cancelled", StartDate = new System.DateTime(2026, 4,  5), CreatedById = 2 },
                new Event { Id =  5, Title = "Triển lãm T5", Status = "Completed", StartDate = new System.DateTime(2026, 5, 18), CreatedById = 2 },
                new Event { Id =  6, Title = "Tập huấn T6",  Status = "Completed", StartDate = new System.DateTime(2026, 6, 22), CreatedById = 2 },
                new Event { Id =  7, Title = "Hội thi T7",   Status = "Completed", StartDate = new System.DateTime(2026, 7, 12), CreatedById = 2 },
                new Event { Id =  8, Title = "Giao lưu T8",  Status = "Completed", StartDate = new System.DateTime(2026, 8,  8), CreatedById = 2 },
                new Event { Id =  9, Title = "Hội thảo T9",  Status = "Cancelled", StartDate = new System.DateTime(2026, 9, 25), CreatedById = 2 },
                new Event { Id = 10, Title = "Sự kiện T10",  Status = "Ongoing",   StartDate = new System.DateTime(2026,10,  1), CreatedById = 2 },
                new Event { Id = 11, Title = "Sự kiện T10b", Status = "Ongoing",   StartDate = new System.DateTime(2026,10, 15), CreatedById = 2 },
                new Event { Id = 12, Title = "Sự kiện T10c", Status = "Ongoing",   StartDate = new System.DateTime(2026,10, 16), CreatedById = 2 },

                // Các sự kiện sắp diễn ra để sinh viên đăng ký
                new Event
                {
                    Id = 13, Title = "Hội thảo AI & Chuyển đổi số", Status = "Ongoing", CreatedById = 2,
                    StartDate = new System.DateTime(2026, 11, 20, 8, 0, 0), EndDate = new System.DateTime(2026, 11, 20, 11, 30, 0),
                    Location = "Hội trường A - ĐH Điện lực", MaxParticipants = 200,
                    Description = "Hội thảo chia sẻ về ứng dụng trí tuệ nhân tạo trong chuyển đổi số dành cho sinh viên khoa CNTT."
                },
                new Event
                {
                    Id = 14, Title = "Giải bóng đá Liên Chi đoàn CNTT", Status = "Ongoing", CreatedById = 2,
                    StartDate = new System.DateTime(2026, 12, 5, 14, 0, 0), EndDate = new System.DateTime(2026, 12, 12, 17, 0, 0),
                    Location = "Sân bóng ĐH Điện lực", MaxParticipants = 120,
                    Description = "Giải bóng đá giao hữu giữa các chi đoàn thuộc Liên Chi đoàn Công nghệ thông tin."
                },
                new Event
                {
                    Id = 15, Title = "Ngày hội Tình nguyện mùa đông", Status = "Ongoing", CreatedById = 2,
                    StartDate = new System.DateTime(2026, 12, 20, 7, 0, 0), EndDate = new System.DateTime(2026, 12, 20, 17, 0, 0),
                    Location = "Sân trường ĐH Điện lực", MaxParticipants = 0,
                    Description = "Quyên góp áo ấm, sách vở và tổ chức các hoạt động tình nguyện cho trẻ em vùng cao."
                }
            );

            // ── Seed Participants ────────────────────────────────────
            modelBuilder.Entity<Participant>().HasData(
                new Participant { Id =  1, FullName = "Nguyễn A",  EventId = 1, Attended = true,  RegisteredAt = new System.DateTime(2026, 1, 14) },
                new Participant { Id =  2, FullName = "Trần B",    EventId = 1, Attended = true,  RegisteredAt = new System.DateTime(2026, 1, 14) },
                new Participant { Id =  3, FullName = "Lê C",      EventId = 2, Attended = false, RegisteredAt = new System.DateTime(2026, 2,  9) },
                new Participant { Id =  4, FullName = "Phạm D",    EventId = 3, Attended = true,  RegisteredAt = new System.DateTime(2026, 3, 19) },
                new Participant { Id =  5, FullName = "Hoàng E",   EventId = 3, Attended = true,  RegisteredAt = new System.DateTime(2026, 3, 19) },
                new Participant { Id =  6, FullName = "Ngô F",     EventId = 5, Attended = true,  RegisteredAt = new System.DateTime(2026, 5, 17) },
                new Participant { Id =  7, FullName = "Đặng G",    EventId = 6, Attended = false, RegisteredAt = new System.DateTime(2026, 6, 21) },
                new Participant { Id =  8, FullName = "Vũ H",      EventId = 7, Attended = true,  RegisteredAt = new System.DateTime(2026, 7, 11) },
                new Participant { Id =  9, FullName = "Bùi I",     EventId = 8, Attended = true,  RegisteredAt = new System.DateTime(2026, 8,  7) },
                new Participant { Id = 10, FullName = "Dương J",   EventId = 10, Attended = false, RegisteredAt = new System.DateTime(2026,10,  1) },
                // Sinh viên hocsinh01 đã tham gia "Giao lưu T8" → có thể đánh giá sự kiện
                new Participant
                {
                    Id = 11, FullName = "Nguyễn Văn Sinh", EventId = 8, UserId = 3, Attended = true,
                    RegisteredAt = new System.DateTime(2026, 8, 1), Email = "hocsinh01@epu.edu.vn", PhoneNumber = "0912345678",
                    Role = "Sinh viên", AttendanceStatus = "Đã điểm danh", ConfirmationStatus = "Đã xác nhận"
                }
            );

            // ── Tasks, Documents, Notifications, Reports (tối giản) ──
            modelBuilder.Entity<EventTask>().HasData(
                new EventTask { Id = 1, Title = "Chuẩn bị tài liệu", Status = "Pending",   EventId = 10 },
                new EventTask { Id = 2, Title = "Gửi thư mời",       Status = "Completed", EventId = 10 }
            );
            modelBuilder.Entity<Document>().HasData(
                new Document { Id = 1, FileName = "chuong_trinh.pdf", EventId = 1 }
            );
            modelBuilder.Entity<Notification>().HasData(
                new Notification { Id = 1, Message = "Nhắc nhở sự kiện T10", CreatedById = 2 }
            );
            modelBuilder.Entity<Report>().HasData(
                new Report { Id = 1, Title = "Báo cáo Q1", IsCompleted = true },
                new Report { Id = 2, Title = "Báo cáo Q2", IsCompleted = true },
                new Report { Id = 3, Title = "Báo cáo Q3", IsCompleted = false }
            );
        }
    }
}
