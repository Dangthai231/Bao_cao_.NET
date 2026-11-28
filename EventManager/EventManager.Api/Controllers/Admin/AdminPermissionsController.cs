using EventManager.Api.Data;
using EventManager.Api.DTOs;
using EventManager.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Api.Controllers.Admin;

[Route("api/admin/permissions")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminPermissionsController(AppDbContext context) : AdminControllerBase(context)
{
    private static readonly string[] StaffCatalog =
    [
        "Tra cứu sự kiện", "Xem thông tin chi tiết sự kiện", "Lập kế hoạch sự kiện",
        "Chỉnh sửa kế hoạch", "Gửi kế hoạch xét duyệt", "Quản lý người tham gia",
        "Quản lý điểm danh", "Tạo mã QR điểm danh", "Tra cứu kết quả điểm danh",
        "Phân công nhiệm vụ", "Quản lý tài liệu sự kiện", "Theo dõi tiến độ",
        "Cập nhật tiến độ công việc", "Lập báo cáo", "Sử dụng Trợ lý ảo AI"
    ];

    private static readonly string[] StudentCatalog =
    [
        "Tra cứu sự kiện", "Xem thông tin chi tiết sự kiện", "Đăng ký tham gia sự kiện",
        "Hủy đăng ký sự kiện", "Xem thông tin đăng ký", "Xem trạng thái tham gia",
        "Đánh giá và phản hồi sự kiện", "Xem thông tin cá nhân", "Cập nhật thông tin cá nhân"
    ];

    protected override string? RequiredPermission => AdminHelper.PermPermissions;

    private static IReadOnlyList<string> CatalogFor(string role) => role switch
    {
        AdminHelper.RoleAdmin => AdminHelper.PermissionCatalog,
        AdminHelper.RoleCanBo => StaffCatalog,
        AdminHelper.RoleSinhVien => StudentCatalog,
        _ => Array.Empty<string>()
    };

    [HttpGet("catalog")]
    public IActionResult GetCatalog([FromQuery] string? role = null)
        => Ok(CatalogFor(role ?? AdminHelper.RoleAdmin));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPermissions(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return Missing();

        var catalog = CatalogFor(user.Role);
        var stored = await _context.AdminPermissions.Where(p => p.UserId == id)
            .Select(p => p.Permission).ToListAsync();

        bool implicitAdminAccess = user.Role == AdminHelper.RoleAdmin
            && (stored.Count == 0 || (user.IsActive && !await _context.Users.AnyAsync(
                u => u.Id != id && u.IsActive && u.Role == AdminHelper.RoleAdmin)));

        return Ok(new AdminPermissionDto
        {
            UserId = id,
            Role = user.Role,
            Catalog = catalog,
            Permissions = catalog.Intersect(stored).ToList(),
            CanEdit = id != CurrentUserId && catalog.Count > 0 && await IsFullAdminAsync(),
            HasImplicitAdminAccess = implicitAdminAccess
        });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> SetPermissions(int id, [FromBody] AdminPermissionRequest request)
    {
        if (id == CurrentUserId)
            return StatusCode(403, new { message = "Không thể thay đổi quyền của chính mình." });

        await using var transaction = await _context.Database.BeginTransactionAsync(
            System.Data.IsolationLevel.Serializable);
        if (!await IsFullAdminAsync())
            return StatusCode(403, new { message = "Chỉ Admin toàn quyền được cập nhật quyền." });

        var user = await _context.Users.FindAsync(id);
        if (user == null) return Missing();
        if (request.Role != user.Role)
            return Conflict(new { message = "Vai trò tài khoản đã khác dữ liệu đang hiển thị. Hãy tải lại." });

        var catalog = CatalogFor(user.Role);
        if (catalog.Count == 0 || request.Permissions == null || request.Permissions.Except(catalog).Any())
            return Invalid("Danh sách chứa quyền không hợp lệ với vai trò tài khoản.");
        if (user.Role == AdminHelper.RoleAdmin && request.Permissions.Count == 0)
            return Invalid("Hãy chọn ít nhất một quyền cho tài khoản Admin.");

        var permissions = request.Permissions.ToHashSet();
        var existing = await _context.AdminPermissions.Where(p => p.UserId == id).ToListAsync();
        bool isGrant = !existing.Any(p => catalog.Contains(p.Permission));
        if (isGrant && permissions.Count == 0)
            return Invalid("Hãy chọn ít nhất một quyền để cấp.");

        _context.AdminPermissions.RemoveRange(existing.Where(p => !permissions.Contains(p.Permission)));
        foreach (string permission in permissions.Except(existing.Select(p => p.Permission)))
            _context.AdminPermissions.Add(new AdminPermission { UserId = id, Permission = permission });

        await _context.SaveChangesAsync();
        await transaction.CommitAsync();
        return Success(isGrant ? "Cấp quyền thành công!" : "Thay đổi quyền thành công!");
    }
}
