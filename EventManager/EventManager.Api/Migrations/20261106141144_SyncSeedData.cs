using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class SyncSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
