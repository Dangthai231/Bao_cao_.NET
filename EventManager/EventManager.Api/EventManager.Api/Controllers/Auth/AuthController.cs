using EventManager.Api.Data;
using EventManager.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // 1. Tìm user trong DB có khớp Username và Password không
            var user = _context.Users.FirstOrDefault(u => 
                u.Username == request.Username && 
                u.Password == request.Password);

            // 2. Nếu không tìm thấy -> Trả về lỗi 401 Unauthorized
            if (user == null)
            {
                return Unauthorized(new { message = "Sai tài khoản hoặc mật khẩu!" });
            }

            // 3. Nếu đúng -> Tạo thông tin trả về
            var response = new LoginResponse
            {
                Username = user.Username,
                Role = user.Role,
            };

            return Ok(response); // Trả về HTTP 200 kèm dữ liệu JSON
        }
    }
}