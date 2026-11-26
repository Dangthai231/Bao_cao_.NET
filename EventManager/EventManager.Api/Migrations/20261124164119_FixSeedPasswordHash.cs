using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManager.Api.Migrations
{
    /// <summary>
    /// Sửa mật khẩu mẫu: các PasswordHash cũ không khớp với admin123 / canbo123 / hs123
    /// nên không đăng nhập được. Chỉ cập nhật bảng Users.
    /// (EF có tự sinh thêm CreateTable cho cong_viec / su_kien / tai_khoan và cập nhật ngày giờ mẫu,
    /// nhưng các bảng đó đã có sẵn trong DB của nhóm nên đã bỏ đi để không bị lỗi.)
    /// </summary>
    public partial class FixSeedPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$06ec83a6FYa/OaSsbkp1auURuujD92STc04xOF/ruCRLjztA8C8DS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$12$frcv5fg3pnUypMRVnSqu0.uHKhgzYejBLDq1AXskLyR7j7StcXgja");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$12$HQk0CibOZnOcu6Ph5q7EYO2a1h6yKd.IO53/jVwYORigoiPMJ.ryO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$eduBLLdVXrxDMfKaRm9h3.tYCVdg4v5TuGXe4JFLVqUTwqjJLFrGi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$12$UBMCNRsLXqdHnfG3oZH5oek3h6rJAR2RMIzU0E5VyNNklOWFMUMWa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$12$9YmX4vRU5fPAkyqNTLcAuuBR3EqH7UGDopbqyVu.G.KKL7YlAooxK");
        }
    }
}
