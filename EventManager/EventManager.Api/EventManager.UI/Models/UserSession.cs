namespace EventManager.UI.Models
{
    public class UserSession
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }

        /// <summary>JWT Access Token nhận từ API sau khi đăng nhập thành công.</summary>
        public string Token { get; set; }
    }
}
