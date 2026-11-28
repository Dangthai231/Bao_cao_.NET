namespace EventManager.Api.Models
{
    /// <summary>
    /// Yêu cầu thay đổi thông tin cá nhân, chờ Admin duyệt
    /// </summary>
    public class ProfileChangeRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ClassName { get; set; }
        public string? Evidence { get; set; }
        public string Status { get; set; } = "Chờ duyệt";
        public string? ReviewNote { get; set; }
    }

    /// <summary>
    /// Quyền riêng được cấp cho một tài khoản
    /// </summary>
    public class AdminPermission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Permission { get; set; } = string.Empty;
    }
}
