namespace EventManager.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Mật khẩu đã được băm bằng BCrypt. KHÔNG bao giờ lưu plain-text.
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Giữ lại trường cũ cho dữ liệu seed / migration cũ.
        /// Khi tất cả user đã migrate sang PasswordHash, có thể xóa trường này.
        /// </summary>
        [Obsolete("Dùng PasswordHash thay thế. Trường này chỉ giữ lại để tương thích migration cũ.")]
        public string Password { get; set; } = string.Empty;

        // Quyền của user: "Admin", "CanBo", hoặc "SinhVien"
        public string Role { get; set; } = string.Empty;

        // ── Thông tin cá nhân ──
        public string? FullName { get; set; }
        public string? StudentCode { get; set; }
        public string? ClassName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
