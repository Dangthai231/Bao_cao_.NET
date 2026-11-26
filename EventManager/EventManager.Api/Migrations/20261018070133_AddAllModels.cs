using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Attended = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsCompleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "EventId", "FileName", "UploadedAt" },
                values: new object[] { 1, 1, "chuong_trinh.pdf", new DateTime(2026, 10, 18, 14, 1, 30, 184, DateTimeKind.Local).AddTicks(2718) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedById", "EndDate", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "Hội thảo T1" },
                    { 2, 2, null, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "Sự kiện T2" },
                    { 3, 2, null, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "Hội nghị T3" },
                    { 4, 2, null, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", "Workshop T4" },
                    { 5, 2, null, new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "Triển lãm T5" },
                    { 6, 2, null, new DateTime(2026, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "Tập huấn T6" },
                    { 7, 2, null, new DateTime(2026, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "Hội thi T7" },
                    { 8, 2, null, new DateTime(2026, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", "Giao lưu T8" },
                    { 9, 2, null, new DateTime(2026, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", "Hội thảo T9" },
                    { 10, 2, null, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ongoing", "Sự kiện T10" },
                    { 11, 2, null, new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ongoing", "Sự kiện T10b" },
                    { 12, 2, null, new DateTime(2026, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ongoing", "Sự kiện T10c" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedById", "Message", "SentAt" },
                values: new object[] { 1, 2, "Nhắc nhở sự kiện T10", new DateTime(2026, 10, 18, 14, 1, 30, 184, DateTimeKind.Local).AddTicks(3744) });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "Attended", "EventId", "FullName", "RegisteredAt" },
                values: new object[,]
                {
                    { 1, true, 1, "Nguyễn A", new DateTime(2026, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, 1, "Trần B", new DateTime(2026, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, false, 2, "Lê C", new DateTime(2026, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, true, 3, "Phạm D", new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, true, 3, "Hoàng E", new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, true, 5, "Ngô F", new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, false, 6, "Đặng G", new DateTime(2026, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, true, 7, "Vũ H", new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, true, 8, "Bùi I", new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, false, 10, "Dương J", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CreatedAt", "IsCompleted", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 18, 14, 1, 30, 184, DateTimeKind.Local).AddTicks(4763), true, "Báo cáo Q1" },
                    { 2, new DateTime(2026, 10, 18, 14, 1, 30, 184, DateTimeKind.Local).AddTicks(5321), true, "Báo cáo Q2" },
                    { 3, new DateTime(2026, 10, 18, 14, 1, 30, 184, DateTimeKind.Local).AddTicks(5323), false, "Báo cáo Q3" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "EventId", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 18, 14, 1, 30, 184, DateTimeKind.Local).AddTicks(1346), 10, "Pending", "Chuẩn bị tài liệu" },
                    { 2, new DateTime(2026, 10, 18, 14, 1, 30, 184, DateTimeKind.Local).AddTicks(2192), 10, "Completed", "Gửi thư mời" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
