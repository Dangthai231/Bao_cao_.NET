using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSinhVienFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StudentCode",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AttendanceStatus",
                table: "Participants",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmationStatus",
                table: "Participants",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Participants",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ParticipantCode",
                table: "Participants",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Participants",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Participants",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Participants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Notifications",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NotificationCode",
                table: "Notifications",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "SendDate",
                table: "Notifications",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Notifications",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TargetAudience",
                table: "Notifications",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Notifications",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Events",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "MaxParticipants",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventFeedbacks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2026, 10, 28, 16, 33, 32, 705, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Location", "MaxParticipants" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Location", "MaxParticipants" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Location", "MaxParticipants" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Location", "MaxParticipants" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Location", "MaxParticipants" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Location", "MaxParticipants" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Location", "MaxParticipants" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Location", "MaxParticipants" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Location", "MaxParticipants" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Location", "MaxParticipants" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Location", "MaxParticipants" },
                values: new object[] { null, null, 0 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Location", "MaxParticipants" },
                values: new object[] { null, null, 0 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedById", "Description", "EndDate", "Location", "MaxParticipants", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { 13, 2, "Hội thảo chia sẻ về ứng dụng trí tuệ nhân tạo trong chuyển đổi số dành cho sinh viên khoa CNTT.", new DateTime(2026, 11, 20, 11, 30, 0, 0, DateTimeKind.Unspecified), "Hội trường A - ĐH Điện lực", 200, new DateTime(2026, 11, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), "Ongoing", "Hội thảo AI & Chuyển đổi số" },
                    { 14, 2, "Giải bóng đá giao hữu giữa các chi đoàn thuộc Liên Chi đoàn Công nghệ thông tin.", new DateTime(2026, 12, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), "Sân bóng ĐH Điện lực", 120, new DateTime(2026, 12, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), "Ongoing", "Giải bóng đá Liên Chi đoàn CNTT" },
                    { 15, 2, "Quyên góp áo ấm, sách vở và tổ chức các hoạt động tình nguyện cho trẻ em vùng cao.", new DateTime(2026, 12, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), "Sân trường ĐH Điện lực", 0, new DateTime(2026, 12, 20, 7, 0, 0, 0, DateTimeKind.Unspecified), "Ongoing", "Ngày hội Tình nguyện mùa đông" }
                });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "NotificationCode", "SendDate", "SentAt", "Status", "TargetAudience", "Title" },
                values: new object[] { "", "", new DateTime(2026, 10, 28, 16, 33, 32, 705, DateTimeKind.Local).AddTicks(3645), new DateTime(2026, 10, 28, 16, 33, 32, 705, DateTimeKind.Local).AddTicks(3647), "", "", "" });

            migrationBuilder.UpdateData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AttendanceStatus", "ConfirmationStatus", "Email", "ParticipantCode", "PhoneNumber", "Role", "UserId" },
                values: new object[] { "", "", "", "", "", "", null });

            migrationBuilder.UpdateData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AttendanceStatus", "ConfirmationStatus", "Email", "ParticipantCode", "PhoneNumber", "Role", "UserId" },
                values: new object[] { "", "", "", "", "", "", null });

            migrationBuilder.UpdateData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AttendanceStatus", "ConfirmationStatus", "Email", "ParticipantCode", "PhoneNumber", "Role", "UserId" },
                values: new object[] { "", "", "", "", "", "", null });

            migrationBuilder.UpdateData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AttendanceStatus", "ConfirmationStatus", "Email", "ParticipantCode", "PhoneNumber", "Role", "UserId" },
                values: new object[] { "", "", "", "", "", "", null });

            migrationBuilder.UpdateData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AttendanceStatus", "ConfirmationStatus", "Email", "ParticipantCode", "PhoneNumber", "Role", "UserId" },
                values: new object[] { "", "", "", "", "", "", null });

            migrationBuilder.UpdateData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AttendanceStatus", "ConfirmationStatus", "Email", "ParticipantCode", "PhoneNumber", "Role", "UserId" },
                values: new object[] { "", "", "", "", "", "", null });

            migrationBuilder.UpdateData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AttendanceStatus", "ConfirmationStatus", "Email", "ParticipantCode", "PhoneNumber", "Role", "UserId" },
                values: new object[] { "", "", "", "", "", "", null });

            migrationBuilder.UpdateData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AttendanceStatus", "ConfirmationStatus", "Email", "ParticipantCode", "PhoneNumber", "Role", "UserId" },
                values: new object[] { "", "", "", "", "", "", null });

            migrationBuilder.UpdateData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AttendanceStatus", "ConfirmationStatus", "Email", "ParticipantCode", "PhoneNumber", "Role", "UserId" },
                values: new object[] { "", "", "", "", "", "", null });

            migrationBuilder.UpdateData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AttendanceStatus", "ConfirmationStatus", "Email", "ParticipantCode", "PhoneNumber", "Role", "UserId" },
                values: new object[] { "", "", "", "", "", "", null });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "AttendanceStatus", "Attended", "ConfirmationStatus", "Email", "EventId", "FullName", "ParticipantCode", "PhoneNumber", "RegisteredAt", "Role", "UserId" },
                values: new object[] { 11, "Đã điểm danh", true, "Đã xác nhận", "hocsinh01@epu.edu.vn", 8, "Nguyễn Văn Sinh", "", "0912345678", new DateTime(2026, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sinh viên", 3 });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 28, 16, 33, 32, 705, DateTimeKind.Local).AddTicks(4784));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 28, 16, 33, 32, 705, DateTimeKind.Local).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 28, 16, 33, 32, 705, DateTimeKind.Local).AddTicks(5231));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 28, 16, 33, 32, 705, DateTimeKind.Local).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 28, 16, 33, 32, 705, DateTimeKind.Local).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClassName", "DateOfBirth", "Email", "FullName", "Password", "PhoneNumber", "StudentCode" },
                values: new object[] { null, null, null, null, "admin123", null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClassName", "DateOfBirth", "Email", "FullName", "Password", "PhoneNumber", "StudentCode", "Username" },
                values: new object[] { null, null, null, null, "canbo123", null, null, "canbo01" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClassName", "DateOfBirth", "Email", "FullName", "Password", "PhoneNumber", "StudentCode", "Username" },
                values: new object[] { "D17CNPM1", new DateTime(2004, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "hocsinh01@epu.edu.vn", "Nguyễn Văn Sinh", "hs123", "0912345678", "22810310001", "hocsinh01" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventFeedbacks");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AttendanceStatus",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ConfirmationStatus",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ParticipantCode",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "NotificationCode",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "SendDate",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TargetAudience",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MaxParticipants",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2026, 10, 19, 22, 31, 42, 858, DateTimeKind.Local).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "SentAt",
                value: new DateTime(2026, 10, 19, 22, 31, 42, 858, DateTimeKind.Local).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 19, 22, 31, 42, 858, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 19, 22, 31, 42, 858, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 19, 22, 31, 42, 858, DateTimeKind.Local).AddTicks(9843));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 19, 22, 31, 42, 858, DateTimeKind.Local).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 10, 19, 22, 31, 42, 858, DateTimeKind.Local).AddTicks(6918));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "123");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Username" },
                values: new object[] { "123", "canbo1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Username" },
                values: new object[] { "123", "hocsinh1" });
        }
    }
}
