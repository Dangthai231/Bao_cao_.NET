using EventManager.Api.Data;
using EventManager.Api.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers.Admin
{
    /// <summary>
    /// Cài đặt: Admin tự đổi mật khẩu của mình
    /// </summary>
    [Route("api/admin/settings")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminSettingsController : AdminControllerBase
    {
        public AdminSettingsController(AppDbContext context) : base(context)
        {
        }

        // PUT: api/admin/settings/password
        [HttpPut("password")]
        public async Task<IActionResult> ChangePassword([FromBody] AdminPasswordRequest request)
        {
            var user = await _context.Users.FindAsync(CurrentUserId);
            if (user == null) return Missing();

            if (string.IsNullOrEmpty(request.CurrentPassword) || string.IsNullOrEmpty(user.PasswordHash)
                || !BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.PasswordHash))
                return Invalid("Mật khẩu hiện tại không đúng.");
            if (!AdminHelper.IsValidPassword(request.Password))
                return Invalid($"Mật khẩu mới phải có ít nhất {AdminHelper.MinPasswordLength} ký tự.");
            if (request.Password == request.CurrentPassword)
                return Invalid("Mật khẩu mới phải khác mật khẩu hiện tại.");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            await _context.SaveChangesAsync();
            return Success("Đổi mật khẩu thành công!");
        }
    }
}
