namespace EventManager.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        
        // Thực tế đi làm MẬT KHẨU PHẢI ĐƯỢC MÃ HÓA (Hash) bằng BCrypt/Argon2. 
        // Ở đây dùng string để bạn dễ hiểu luồng đi.
        public string Password { get; set; } = string.Empty; 
        
        // Quyền của user: "Admin", "CanBo", hoặc "HocSinh"
        public string Role { get; set; } = string.Empty; 
    }
}