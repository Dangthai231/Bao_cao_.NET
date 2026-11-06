namespace EventManager.Api.DTOs
{
    // ──────────────────────────────────────────
    // ĐĂNG KÝ
    // ──────────────────────────────────────────

    /// <summary>WinForms gửi lên khi đăng ký tài khoản mới.</summary>
    public class RegisterRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        /// <summary>Vai trò mặc định "SinhVien". Có thể bỏ qua ở client.</summary>
        public string Role { get; set; } = "SinhVien";

        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? StudentCode { get; set; }
        public string? ClassName { get; set; }
        public string? PhoneNumber { get; set; }
    }

    // ──────────────────────────────────────────
    // ĐĂNG NHẬP
    // ──────────────────────────────────────────

    /// <summary>WinForms gửi lên khi đăng nhập.</summary>
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    /// <summary>API trả về cho WinForms sau khi đăng nhập thành công.</summary>
    public class LoginResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? FullName { get; set; }

        /// <summary>JWT Access Token -- WinForms đính vào header Authorization: Bearer {Token}.</summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>Thời điểm token hết hạn (UTC).</summary>
        public DateTime TokenExpiry { get; set; }
    }
}
