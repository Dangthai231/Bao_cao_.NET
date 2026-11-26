using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2026, 11, 6, 21, 10, 38, 237, DateTimeKind.Local).AddTicks(3668));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SendDate", "SentAt" },
                values: new object[] { new DateTime(2026, 11, 6, 21, 10, 38, 237, DateTimeKind.Local).AddTicks(5308), new DateTime(2026, 11, 6, 21, 10, 38, 237, DateTimeKind.Local).AddTicks(5312) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 10, 38, 237, DateTimeKind.Local).AddTicks(6704));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 10, 38, 237, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 10, 38, 237, DateTimeKind.Local).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 10, 38, 237, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 10, 38, 237, DateTimeKind.Local).AddTicks(3114));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FullName", "Password", "PasswordHash" },
                values: new object[] { "Quản trị viên", "", "$2a$12$eduBLLdVXrxDMfKaRm9h3.tYCVdg4v5TuGXe4JFLVqUTwqjJLFrGi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FullName", "Password", "PasswordHash" },
                values: new object[] { "Cán Bộ Nguyễn Thị Lan", "", "$2a$12$UBMCNRsLXqdHnfG3oZH5oek3h6rJAR2RMIzU0E5VyNNklOWFMUMWa" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "PasswordHash", "Role" },
                values: new object[] { "", "$2a$12$9YmX4vRU5fPAkyqNTLcAuuBR3EqH7UGDopbqyVu.G.KKL7YlAooxK", "SinhVien" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2026, 11, 6, 21, 2, 15, 352, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SendDate", "SentAt" },
                values: new object[] { new DateTime(2026, 11, 6, 21, 2, 15, 353, DateTimeKind.Local).AddTicks(1104), new DateTime(2026, 11, 6, 21, 2, 15, 353, DateTimeKind.Local).AddTicks(1106) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 2, 15, 353, DateTimeKind.Local).AddTicks(2105));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 2, 15, 353, DateTimeKind.Local).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 2, 15, 353, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 2, 15, 352, DateTimeKind.Local).AddTicks(8637));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 2, 15, 352, DateTimeKind.Local).AddTicks(9378));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FullName", "Password", "PasswordHash" },
                values: new object[] { null, "admin123", "" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FullName", "Password", "PasswordHash" },
                values: new object[] { null, "canbo123", "" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "PasswordHash", "Role" },
                values: new object[] { "hs123", "", "HocSinh" });
        }
    }
}
