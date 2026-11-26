using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddEventMissingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2026, 11, 6, 22, 14, 24, 367, DateTimeKind.Local).AddTicks(1486));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SendDate", "SentAt" },
                values: new object[] { new DateTime(2026, 11, 6, 22, 14, 24, 367, DateTimeKind.Local).AddTicks(2812), new DateTime(2026, 11, 6, 22, 14, 24, 367, DateTimeKind.Local).AddTicks(2815) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 22, 14, 24, 367, DateTimeKind.Local).AddTicks(3923));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 22, 14, 24, 367, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 22, 14, 24, 367, DateTimeKind.Local).AddTicks(4456));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 22, 14, 24, 367, DateTimeKind.Local).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 22, 14, 24, 367, DateTimeKind.Local).AddTicks(967));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2026, 11, 6, 21, 11, 43, 969, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SendDate", "SentAt" },
                values: new object[] { new DateTime(2026, 11, 6, 21, 11, 43, 969, DateTimeKind.Local).AddTicks(6689), new DateTime(2026, 11, 6, 21, 11, 43, 969, DateTimeKind.Local).AddTicks(6691) });

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 11, 43, 969, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 11, 43, 969, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 11, 43, 969, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 11, 43, 969, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 11, 6, 21, 11, 43, 969, DateTimeKind.Local).AddTicks(4856));
        }
    }
}
