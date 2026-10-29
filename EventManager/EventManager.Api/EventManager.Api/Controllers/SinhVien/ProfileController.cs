using EventManager.Api.Data;
using EventManager.Api.DTOs.SinhVien;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers.SinhVien
{
    /// <summary>
    /// Use case "Quản lý thông tin cá nhân": xem và cập nhật thông tin
    /// </summary>
    [Route("api/sinhvien/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/sinhvien/profile/3
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfile(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy tài khoản!" });
            }

            return Ok(new StudentProfileDto
            {
                UserId = user.Id,
                Username = user.Username,
                FullName = user.FullName ?? string.Empty,
                StudentCode = user.StudentCode ?? string.Empty,
                ClassName = user.ClassName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber ?? string.Empty,
                DateOfBirth = user.DateOfBirth
            });
        }

        // PUT: api/sinhvien/profile/3
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateProfile(int userId, [FromBody] UpdateProfileRequest request)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound(new { message = "Không tìm thấy tài khoản!" });
            }

            if (request == null || string.IsNullOrWhiteSpace(request.FullName))
            {
                return BadRequest(new { message = "Họ tên không được để trống!" });
            }

            if (!string.IsNullOrWhiteSpace(request.Email) &&
                !Regex.IsMatch(request.Email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return BadRequest(new { message = "Email không đúng định dạng!" });
            }

            if (!string.IsNullOrWhiteSpace(request.PhoneNumber) &&
                !Regex.IsMatch(request.PhoneNumber.Trim(), @"^0\d{9,10}$"))
            {
                return BadRequest(new { message = "Số điện thoại phải gồm 10-11 chữ số và bắt đầu bằng 0!" });
            }

            // Đổi mật khẩu nếu có nhập mật khẩu mới
            if (!string.IsNullOrEmpty(request.NewPassword))
            {
                if (request.CurrentPassword != user.Password)
                {
                    return BadRequest(new { message = "Mật khẩu hiện tại không đúng!" });
                }
                if (request.NewPassword.Length < 6)
                {
                    return BadRequest(new { message = "Mật khẩu mới phải có ít nhất 6 ký tự!" });
                }
                user.Password = request.NewPassword;
            }

            user.FullName = request.FullName.Trim();
            user.ClassName = request.ClassName?.Trim();
            user.Email = request.Email?.Trim();
            user.PhoneNumber = request.PhoneNumber?.Trim();
            user.DateOfBirth = request.DateOfBirth;

            // Đồng bộ thông tin sang các bản đăng ký để cán bộ thấy thông tin mới nhất
            var registrations = await _context.Participants.Where(p => p.UserId == userId).ToListAsync();
            foreach (var p in registrations)
            {
                p.FullName = user.FullName;
                p.Email = user.Email;
                p.PhoneNumber = user.PhoneNumber;
            }

            await _context.SaveChangesAsync();

            return Ok(new { message = "Cập nhật thông tin thành công!" });
        }
    }
}
