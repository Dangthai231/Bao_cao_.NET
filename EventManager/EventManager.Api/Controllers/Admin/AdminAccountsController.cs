using EventManager.Api.Data;
using EventManager.Api.DTOs;
using EventManager.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers.Admin
{
    /// <summary>
    /// Use case "Quản lý tài khoản": tạo, cập nhật, khóa/mở khóa, đặt lại mật khẩu,
    /// tra cứu tài khoản và duyệt yêu cầu thay đổi thông tin.
    /// </summary>
    [Route("api/admin/accounts")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminAccountsController : AdminControllerBase
    {
        public AdminAccountsController(AppDbContext context) : base(context)
        {
        }

        protected override string? RequiredPermission => AdminHelper.PermAccounts;

        protected override bool AllowsPermission(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context,
            IReadOnlyCollection<string> granted)
            => base.AllowsPermission(context, granted)
                || (context.ActionDescriptor.RouteValues.TryGetValue("action", out var action)
                    && action == nameof(GetAccounts)
                    && (granted.Contains(AdminHelper.PermPermissions)
                        || (granted.Contains(AdminHelper.PermEvents)
                            && context.ActionArguments.TryGetValue("role", out var role)
                            && role is AdminHelper.RoleCanBo)));

        // GET: api/admin/accounts?q=an&role=CanBo&active=true
        [HttpGet]
        public async Task<IActionResult> GetAccounts(string? q = null, string? role = null, bool? active = null)
        {
            var query = _context.Users.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                var keyword = q.Trim();
                bool hasId = int.TryParse(keyword, out int id);
                query = query.Where(u => u.Username.Contains(keyword)
                    || (u.FullName != null && u.FullName.Contains(keyword))
                    || (u.Email != null && u.Email.Contains(keyword))
                    || (u.StudentCode != null && u.StudentCode.Contains(keyword))
                    || (hasId && u.Id == id));
            }
            if (!string.IsNullOrWhiteSpace(role))
                query = query.Where(u => u.Role == role);
            if (active.HasValue)
                query = query.Where(u => u.IsActive == active.Value);

            var users = await query.OrderBy(u => u.Id).ToListAsync();
            return Ok(users.Select(ToDto).ToList());
        }

        // GET: api/admin/accounts/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return Missing();
            return Ok(ToDto(user));
        }

        // POST: api/admin/accounts - Tạo tài khoản
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdminAccountRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.FullName))
                return Invalid("Vui lòng nhập tên đăng nhập và họ tên.");
            await using var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
            if (request.Role == AdminHelper.RoleAdmin && !await IsFullAdminAsync())
                return StatusCode(403, new { message = "Chỉ Admin toàn quyền được tạo tài khoản Admin." });

            if (!AdminHelper.IsValidRole(request.Role))
                return Invalid("Vai trò không hợp lệ.");
            if (!AdminHelper.IsValidPassword(request.Password))
                return Invalid($"Mật khẩu phải có ít nhất {AdminHelper.MinPasswordLength} ký tự.");
            if (!AdminHelper.IsValidEmail(request.Email))
                return Invalid("Email không hợp lệ.");

            if (!AdminHelper.IsValidPhone(request.PhoneNumber))
                return Invalid("Số điện thoại phải gồm 10-11 chữ số và bắt đầu bằng 0.");

            string username = request.Username.Trim();
            string? email = AdminHelper.Clean(request.Email);
            string? studentCode = AdminHelper.Clean(request.StudentCode);
            string? className = AdminHelper.Clean(request.ClassName);
            if (request.Role == AdminHelper.RoleSinhVien && studentCode == null)
                return Invalid("Vui lòng nhập mã sinh viên.");
            if (request.Role == AdminHelper.RoleSinhVien && className == null)
                return Invalid("Vui lòng nhập lớp.");

            if (await _context.Users.AnyAsync(u => u.Username == username))
                return Conflict(new { message = "Tên đăng nhập đã tồn tại." });
            if (email != null && await _context.Users.AnyAsync(u => u.Email == email))
                return Conflict(new { message = "Email đã được dùng cho tài khoản khác." });
            if (studentCode != null && await _context.Users.AnyAsync(u => u.StudentCode == studentCode))
                return Conflict(new { message = "Mã sinh viên đã được dùng cho tài khoản khác." });

            var user = new User
            {
                Username = username,
                FullName = request.FullName.Trim(),
                Role = request.Role,
                Email = email,
                PhoneNumber = AdminHelper.Clean(request.PhoneNumber),
                ClassName = className,
                StudentCode = studentCode,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                IsActive = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Success("Tạo tài khoản thành công!");
        }

        // PUT: api/admin/accounts/5 - Cập nhật thông tin tài khoản
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AdminAccountRequest request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return Missing();
            if (user.Role == AdminHelper.RoleAdmin && !await IsFullAdminAsync())
                return StatusCode(403, new { message = "Chỉ Admin toàn quyền được quản lý tài khoản Admin." });

            if (string.IsNullOrWhiteSpace(request.FullName))
                return Invalid("Họ tên không được để trống.");
            if (!AdminHelper.IsValidEmail(request.Email))
                return Invalid("Email không hợp lệ.");
            if (!AdminHelper.IsValidPhone(request.PhoneNumber))
                return Invalid("Số điện thoại phải gồm 10-11 chữ số và bắt đầu bằng 0.");

            string? email = AdminHelper.Clean(request.Email);
            string? studentCode = AdminHelper.Clean(request.StudentCode);
            string? className = AdminHelper.Clean(request.ClassName);
            if (user.Role == AdminHelper.RoleSinhVien && !string.IsNullOrWhiteSpace(user.StudentCode) && studentCode == null)
                return Invalid("Vui lòng nhập mã sinh viên.");
            if (user.Role == AdminHelper.RoleSinhVien && !string.IsNullOrWhiteSpace(user.ClassName) && className == null)
                return Invalid("Vui lòng nhập lớp.");

            if (email != null && await _context.Users.AnyAsync(u => u.Id != id && u.Email == email))
                return Conflict(new { message = "Email đã được dùng cho tài khoản khác." });
            if (studentCode != null && await _context.Users.AnyAsync(u => u.Id != id && u.StudentCode == studentCode))
                return Conflict(new { message = "Mã sinh viên đã được dùng cho tài khoản khác." });

            user.FullName = request.FullName.Trim();
            user.Email = email;
            user.PhoneNumber = AdminHelper.Clean(request.PhoneNumber);
            user.ClassName = className;
            user.StudentCode = studentCode;

            // Đồng bộ thông tin sang các phiếu đăng ký sự kiện (giống khi duyệt yêu cầu đổi thông tin)
            var registrations = await _context.Participants.Where(p => p.UserId == user.Id).ToListAsync();
            foreach (var registration in registrations)
            {
                registration.FullName = user.FullName ?? registration.FullName;
                registration.Email = user.Email;
                registration.PhoneNumber = user.PhoneNumber;
            }

            await _context.SaveChangesAsync();
            return Success("Cập nhật tài khoản thành công!");
        }

        // PUT: api/admin/accounts/5/state - Khóa / mở khóa tài khoản
        [HttpPut("{id:int}/state")]
        public async Task<IActionResult> ChangeState(int id, [FromBody] AdminLockRequest request)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
            var user = await _context.Users.FindAsync(id);
            if (user == null) return Missing();
            if (user.Role == AdminHelper.RoleAdmin && !await IsFullAdminAsync())
                return StatusCode(403, new { message = "Chỉ Admin toàn quyền được quản lý tài khoản Admin." });


            if (!request.IsActive)
            {
                if (id == CurrentUserId)
                    return Invalid("Không thể tự khóa tài khoản của chính mình.");

                bool isLastAdmin = user.Role == AdminHelper.RoleAdmin
                    && !await _context.Users.AnyAsync(u => u.Id != id && u.Role == AdminHelper.RoleAdmin && u.IsActive);
                if (isLastAdmin)
                    return Invalid("Không thể khóa tài khoản Admin cuối cùng.");
            }

            user.IsActive = request.IsActive;
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Success(request.IsActive ? "Đã mở khóa tài khoản." : "Đã khóa tài khoản.");
        }

        // PUT: api/admin/accounts/5/password - Đặt lại mật khẩu
        [HttpPut("{id:int}/password")]
        public async Task<IActionResult> ResetPassword(int id, [FromBody] AdminPasswordRequest request)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
            var user = await _context.Users.FindAsync(id);
            if (user == null) return Missing();
            if (user.Role == AdminHelper.RoleAdmin && !await IsFullAdminAsync())
                return StatusCode(403, new { message = "Chỉ Admin toàn quyền được quản lý tài khoản Admin." });


            if (!AdminHelper.IsValidPassword(request.Password))
                return Invalid($"Mật khẩu phải có ít nhất {AdminHelper.MinPasswordLength} ký tự.");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Success("Đặt lại mật khẩu thành công!");
        }

        // GET: api/admin/accounts/requests - Danh sách yêu cầu thay đổi thông tin
        [HttpGet("requests")]
        public async Task<IActionResult> GetChangeRequests()
        {
            var requests = await _context.ProfileChangeRequests.AsNoTracking().OrderByDescending(r => r.Id).ToListAsync();
            var userIds = requests.Select(r => r.UserId).Distinct().ToList();
            var users = await _context.Users.AsNoTracking().Where(u => userIds.Contains(u.Id)).ToDictionaryAsync(u => u.Id);

            var result = new List<AdminChangeRequestDto>();
            foreach (var r in requests)
            {
                users.TryGetValue(r.UserId, out var user);
                result.Add(new AdminChangeRequestDto
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    Username = user?.Username ?? "(đã xóa)",
                    Status = r.Status,
                    ReviewNote = r.ReviewNote,
                    Evidence = r.Evidence,
                    CurrentFullName = user?.FullName,
                    CurrentEmail = user?.Email,
                    CurrentPhoneNumber = user?.PhoneNumber,
                    CurrentClassName = user?.ClassName,
                    NewFullName = r.FullName ?? user?.FullName,
                    NewEmail = r.Email ?? user?.Email,
                    NewPhoneNumber = r.PhoneNumber ?? user?.PhoneNumber,
                    NewClassName = r.ClassName ?? user?.ClassName
                });
            }
            return Ok(result);
        }

        // PUT: api/admin/accounts/requests/5 - Duyệt / từ chối yêu cầu thay đổi thông tin
        [HttpPut("requests/{id:int}")]
        public async Task<IActionResult> ReviewChangeRequest(int id, [FromBody] AdminReviewRequest request)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
            var changeRequest = await _context.ProfileChangeRequests.FindAsync(id);
            if (changeRequest == null) return Missing();
            if (changeRequest.Status != AdminHelper.StatusPending) return WrongState(changeRequest.Status);
            if (!request.Approved && string.IsNullOrWhiteSpace(request.Reason))
                return Invalid("Vui lòng nhập lý do từ chối.");

            var user = await _context.Users.FindAsync(changeRequest.UserId);
            if (user == null) return Missing();

            if (request.Approved)
            {
                if (!AdminHelper.IsValidEmail(changeRequest.Email))
                    return Invalid("Email đề xuất không hợp lệ.");
                if (!string.IsNullOrWhiteSpace(changeRequest.Email)
                    && await _context.Users.AnyAsync(u => u.Id != user.Id && u.Email == changeRequest.Email))
                    return Invalid("Email đề xuất đã được dùng cho tài khoản khác.");

                user.FullName = changeRequest.FullName ?? user.FullName;
                user.Email = changeRequest.Email ?? user.Email;
                user.PhoneNumber = changeRequest.PhoneNumber ?? user.PhoneNumber;
                user.ClassName = changeRequest.ClassName ?? user.ClassName;

                // Đồng bộ thông tin trên các phiếu đăng ký sự kiện của tài khoản này
                var registrations = await _context.Participants.Where(p => p.UserId == user.Id).ToListAsync();
                foreach (var registration in registrations)
                {
                    registration.FullName = user.FullName ?? registration.FullName;
                    registration.Email = user.Email;
                    registration.PhoneNumber = user.PhoneNumber;
                }
            }

            changeRequest.Status = AdminHelper.ReviewStatus(request.Approved);
            changeRequest.ReviewNote = request.Reason;
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Success(request.Approved ? "Đã duyệt yêu cầu." : "Đã từ chối yêu cầu.");
        }

        private static AdminAccountDto ToDto(User u)
        {
            return new AdminAccountDto
            {
                Id = u.Id,
                Username = u.Username,
                FullName = u.FullName,
                Role = u.Role,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                ClassName = u.ClassName,
                StudentCode = u.StudentCode,
                IsActive = u.IsActive
            };
        }
    }
}
