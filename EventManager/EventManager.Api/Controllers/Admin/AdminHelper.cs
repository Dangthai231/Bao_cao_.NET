using EventManager.Api.Models;
using Microsoft.EntityFrameworkCore;
using EventManager.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace EventManager.Api.Controllers.Admin
{
    /// <summary>
    /// Các quy tắc nghiệp vụ dùng chung cho phân hệ Admin
    /// </summary>
    public static class AdminHelper
    {
        // Vai trò
        public const string RoleAdmin = "Admin";
        public const string RoleCanBo = "CanBo";
        public const string RoleSinhVien = "SinhVien";

        // Trạng thái duyệt (thông báo, kế hoạch, yêu cầu đổi thông tin)
        public const string StatusPending = "Chờ duyệt";
        public const string StatusApproved = "Đã duyệt";
        public const string StatusRejected = "Từ chối";

        // Trạng thái riêng của thông báo
        public const string NotifPublished = "Đã đăng";
        public const string NotifRemoved = "Đã gỡ";
        public const string NotifDraft = "Nháp";
        public const string NotifSentByCanBo = "Đã gửi"; // Cán bộ gửi lên, Admin cần duyệt

        // Tên quyền (dùng cho Phân quyền)
        public const string PermAccounts = "Quản lý tài khoản";
        public const string PermPermissions = "Phân quyền";
        public const string PermEvents = "Quản lý sự kiện";
        public const string PermNotifications = "Quản lý thông báo";
        public const string PermReports = "Báo cáo";

        public const int MinPasswordLength = 6;

        /// <summary>
        /// Danh mục quyền riêng có thể cấp. Quyền riêng chỉ áp dụng cho tài khoản Admin
        /// (được kiểm tra trong AdminControllerBase), nên chỉ gồm các chức năng của phân hệ Admin.
        /// </summary>
        public static readonly List<string> PermissionCatalog = new List<string>
        {
            PermAccounts, PermPermissions, PermEvents, PermNotifications, PermReports
        };

        /// <summary>Các trạng thái thông báo được coi là "đang chờ Admin duyệt"</summary>
        public static readonly List<string> PendingNotificationStatuses = new List<string>
        {
            StatusPending, NotifDraft, NotifSentByCanBo
        };

        public static bool IsValidRole(string? role)
        {
            return role == RoleAdmin || role == RoleCanBo || role == RoleSinhVien;
        }

        public static bool IsValidPassword(string? password)
        {
            // BCrypt chỉ dùng tối đa 72 byte
            return password != null
                && password.Length >= MinPasswordLength
                && System.Text.Encoding.UTF8.GetByteCount(password) <= 72;
        }

        public static bool IsValidEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email)) return true; // email không bắt buộc
            return new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email);
        }

        public static bool IsValidPhone(string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return true; // điện thoại không bắt buộc
            return System.Text.RegularExpressions.Regex.IsMatch(phone.Trim(), @"^0\d{9,10}$");
        }

        /// <summary>Cắt khoảng trắng; chuỗi rỗng => null (để không lưu "" vào CSDL)</summary>
        public static string? Clean(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }

        public static string ReviewStatus(bool approved)
        {
            return approved ? StatusApproved : StatusRejected;
        }
    }

    /// <summary>
    /// Lớp cha của các controller Admin.
    /// Trước mỗi request: kiểm tra tài khoản còn là Admin đang hoạt động trong CSDL
    /// và có quyền dùng chức năng của controller (nếu đã được phân quyền riêng).
    /// </summary>
    public abstract class AdminControllerBase : ControllerBase, IActionFilter
    {
        protected readonly AppDbContext _context;

        protected AdminControllerBase(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>Quyền cần có để dùng controller này. null = Admin nào cũng dùng được.</summary>
        protected virtual string? RequiredPermission => null;

        protected virtual bool AllowsPermission(ActionExecutingContext context, IReadOnlyCollection<string> granted)
            => RequiredPermission != null && granted.Contains(RequiredPermission);

        protected async Task<bool> IsFullAdminAsync()
        {
            int id = CurrentUserId;
            return await _context.Users.AnyAsync(u => u.Id == id && u.IsActive && u.Role == AdminHelper.RoleAdmin)
                && (!await _context.AdminPermissions.AnyAsync(p => p.UserId == id)
                    || !await OtherActiveAdmins(id).AnyAsync());
        }

        /// <summary>Id tài khoản đang đăng nhập (lấy từ JWT)</summary>
        private IQueryable<User> OtherActiveAdmins(int id)
            => _context.Users.Where(u => u.Id != id && u.IsActive && u.Role == AdminHelper.RoleAdmin);

        protected int CurrentUserId
        {
            get
            {
                int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int id);
                return id;
            }
        }

        [NonAction]
        public void OnActionExecuting(ActionExecutingContext context)
        {
            int userId = CurrentUserId;

            bool isActiveAdmin = _context.Users.Any(u => u.Id == userId && u.IsActive && u.Role == AdminHelper.RoleAdmin);
            if (!isActiveAdmin)
            {
                context.Result = new ObjectResult(new { message = "Tài khoản không có quyền Admin hoặc đã bị khóa." }) { StatusCode = 403 };
                return;
            }

            if (RequiredPermission == null) return;

            // Chưa phân quyền riêng => được dùng toàn bộ chức năng Admin.
            // Đã phân quyền riêng => chỉ dùng được chức năng đã được tích.
            var granted = _context.AdminPermissions.Where(p => p.UserId == userId).Select(p => p.Permission).ToList();
            if (granted.Count > 0 && !AllowsPermission(context, granted) && OtherActiveAdmins(userId).Any())
            {
                context.Result = new ObjectResult(new { message = $"Bạn chưa được cấp quyền \"{RequiredPermission}\"." }) { StatusCode = 403 };
            }
        }

        [NonAction]
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        protected IActionResult Success(string message = "Lưu thành công!")
        {
            return Ok(new { message });
        }

        protected IActionResult Invalid(string message)
        {
            return BadRequest(new { message });
        }

        protected IActionResult Missing()
        {
            return NotFound(new { message = "Không tìm thấy dữ liệu." });
        }

        protected IActionResult WrongState(string? current)
        {
            return Conflict(new { message = $"Trạng thái hiện tại ({current}) không cho phép thao tác này." });
        }
    }
}
