using EventManager.Api.Data;
using EventManager.Api.DTOs;
using EventManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventManager.Api.Controllers.Auth
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        // ──────────────────────────────────────────────────────────────
        // POST /api/auth/login
        // ──────────────────────────────────────────────────────────────
        /// <summary>
        /// Xác thực user. So sánh mật khẩu bằng BCrypt.Verify, trả về JWT nếu đúng.
        /// </summary>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // 1. Kiểm tra input
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Username và Password không được để trống." });
            }

            // 2. Tìm user theo username
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);

            if (user == null)
            {
                // Không tiết lộ username không tồn tại (bảo mật)
                return Unauthorized(new { message = "Sai tài khoản hoặc mật khẩu." });
            }

            // 3. Xác minh mật khẩu bằng BCrypt.Verify
            //    Hỗ trợ cả user cũ (Password plain-text) lẫn user mới (PasswordHash)
            bool passwordValid;
            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                // User mới: dùng BCrypt
                passwordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            }
            else
            {
                // User cũ chưa migrate: so sánh plain-text (tạm thời)
#pragma warning disable CS0618
                passwordValid = user.Password == request.Password;
#pragma warning restore CS0618
            }

            if (!passwordValid)
            {
                return Unauthorized(new { message = "Sai tài khoản hoặc mật khẩu." });
            }

            // 4. Sinh JWT Access Token
            string token = GenerateJwtToken(user);
            var expiry   = DateTime.UtcNow.AddHours(GetTokenExpiryHours());

            var response = new LoginResponse
            {
                UserId      = user.Id,
                Username    = user.Username,
                Role        = user.Role,
                FullName    = user.FullName,
                Token       = token,
                TokenExpiry = expiry,
            };

            return Ok(response);
        }

        // ──────────────────────────────────────────────────────────────
        // Helper: sinh JWT Token
        // ──────────────────────────────────────────────────────────────
        private string GenerateJwtToken(User user)
        {
            var jwtSection = _config.GetSection("Jwt");
            var key        = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(jwtSection["Key"]!));
            var creds      = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,  user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(ClaimTypes.Role,              user.Role),
                new Claim(JwtRegisteredClaimNames.Jti,  Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer:   jwtSection["Issuer"],
                audience: jwtSection["Audience"],
                claims:   claims,
                expires:  DateTime.UtcNow.AddHours(GetTokenExpiryHours()),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private double GetTokenExpiryHours()
        {
            var raw = _config["Jwt:ExpiryHours"];
            return double.TryParse(raw, out double h) ? h : 8;
        }
    }
}
