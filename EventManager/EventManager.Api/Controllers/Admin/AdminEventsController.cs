using EventManager.Api.Data;
using EventManager.Api.DTOs;
using EventManager.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers.Admin
{
    /// <summary>
    /// Use case "Quản lý sự kiện": tạo, cập nhật, tra cứu sự kiện, phân công cán bộ,
    /// theo dõi tiến độ và duyệt kế hoạch tổ chức.
    /// </summary>
    [Route("api/admin/events")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminEventsController : AdminControllerBase
    {
        private static readonly List<string> ValidStatuses = new List<string> { "Ongoing", "Completed", "Cancelled" };

        public AdminEventsController(AppDbContext context) : base(context)
        {
        }

        protected override string? RequiredPermission => AdminHelper.PermEvents;

        // GET: api/admin/events?q=hội thảo&status=Ongoing
        [HttpGet]
        public async Task<IActionResult> GetEvents(string? q = null, string? status = null)
        {
            var query = _context.Events.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(e => e.Title.Contains(q));
            if (!string.IsNullOrWhiteSpace(status))
                query = query.Where(e => e.Status == status);

            var events = await query.OrderByDescending(e => e.StartDate).ToListAsync();
            return Ok(await ToDtoList(events));
        }

        // GET: api/admin/events/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return Missing();
            var list = await ToDtoList(new List<Event> { ev });
            return Ok(list[0]);
        }

        // POST: api/admin/events - Tạo sự kiện
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdminEventRequest request)
        {
            string? error = Validate(request, requiresLocation: true);
            if (error != null) return Invalid(error);

            var ev = new Event { CreatedById = CurrentUserId };
            Apply(ev, request);

            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
            return Success("Tạo sự kiện thành công!");
        }

        // PUT: api/admin/events/5 - Cập nhật sự kiện
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] AdminEventRequest request)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return Missing();

            string? error = Validate(request, requiresLocation: !string.IsNullOrWhiteSpace(ev.Location));
            if (error != null) return Invalid(error);

            // Không cho giảm số chỗ xuống dưới số lượt đăng ký còn hiệu lực
            if (request.MaxParticipants > 0)
            {
                int registered = await _context.Participants
                    .CountAsync(p => p.EventId == id && p.ConfirmationStatus != "Đã hủy");
                if (request.MaxParticipants < registered)
                    return Invalid($"Sự kiện đã có {registered} lượt đăng ký, số chỗ không được nhỏ hơn con số này.");
            }

            Apply(ev, request);
            await _context.SaveChangesAsync();
            return Success("Cập nhật sự kiện thành công!");
        }

        // PUT: api/admin/events/5/assign - Phân công cán bộ phụ trách
        [HttpPut("{id:int}/assign")]
        public async Task<IActionResult> Assign(int id, [FromBody] AdminAssignRequest request)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return Missing();

            bool validStaff = await _context.Users.AnyAsync(u => u.Id == request.ManagerId && u.Role == AdminHelper.RoleCanBo && u.IsActive);
            if (!validStaff) return Invalid("Cán bộ được chọn không hợp lệ hoặc đã bị khóa.");

            ev.ManagerId = request.ManagerId;
            await _context.SaveChangesAsync();
            return Success("Phân công cán bộ thành công!");
        }

        // GET: api/admin/events/5/progress - Theo dõi tiến độ sự kiện
        [HttpGet("{id:int}/progress")]
        public async Task<IActionResult> GetProgress(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return Missing();

            var tasks = new List<AdminTaskDto>();

            // 1. Công việc của phân hệ Cán bộ (bảng cong_viec).
            //    Bảng này gắn với bảng su_kien riêng, nên ghép với sự kiện theo tên sự kiện.
            bool legacyTasksUnavailable = false;
            try
            {
                var congViecs = await _context.CongViecs.AsNoTracking()
                    .Where(c => c.TenSuKien == ev.Title || _context.SuKiens.Any(
                        s => s.Id == c.SuKienId && s.TenSuKien == ev.Title))
                    .Select(c => new { c.TenCongViec, c.TrangThai, c.NhanSu, c.TienDo, c.HanChot })
                    .ToListAsync();
                foreach (var c in congViecs)
                {
                    tasks.Add(new AdminTaskDto
                    {
                        Title = c.TenCongViec,
                        Status = c.TrangThai,
                        Owner = c.NhanSu,
                        Progress = Math.Clamp(c.TienDo, 0, 100),
                        Deadline = c.HanChot
                    });
                }
            }
            catch (MySqlException ex) when (ex.Number == 1146)
            {
                legacyTasksUnavailable = true;
            }

            // 2. Công việc cũ (bảng Tasks) gắn trực tiếp với EventId
            var eventTasks = await _context.Tasks.AsNoTracking().Where(t => t.EventId == id).ToListAsync();
            foreach (var t in eventTasks)
            {
                tasks.Add(new AdminTaskDto
                {
                    Title = t.Title,
                    Status = t.Status,
                    Progress = t.Status == "Completed" ? 100 : 0
                });
            }

            var result = new AdminProgressDto
            {
                EventId = ev.Id,
                EventTitle = ev.Title,
                Tasks = tasks,
                LegacyTasksUnavailable = legacyTasksUnavailable,
                Progress = tasks.Count == 0 ? 0 : (int)Math.Round(tasks.Average(t => t.Progress))
            };
            return Ok(result);
        }

        // GET: api/admin/events/plans - Danh sách kế hoạch tổ chức
        [HttpGet("plans")]
        public async Task<IActionResult> GetPlans()
        {
            var plans = await _context.Plans.AsNoTracking().OrderByDescending(p => p.Id).ToListAsync();
            var result = plans.Select(p => new AdminPlanDto
            {
                Id = p.Id,
                PlanName = p.PlanName,
                Objective = p.Objective,
                Description = p.Description,
                Location = p.Location,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Budget = p.Budget,
                Status = p.Status,
                ReviewNote = p.ReviewNote,
                EventId = p.EventId
            }).ToList();
            return Ok(result);
        }

        // PUT: api/admin/events/plans/5 - Duyệt / từ chối kế hoạch
        // Duyệt kế hoạch => tạo sự kiện mới từ kế hoạch và gắn EventId vào kế hoạch.
        [HttpPut("plans/{id:int}")]
        public async Task<IActionResult> ReviewPlan(int id, [FromBody] AdminReviewRequest request)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null) return Missing();
            if (plan.Status != AdminHelper.StatusPending) return WrongState(plan.Status);
            if (!request.Approved && string.IsNullOrWhiteSpace(request.Reason))
                return Invalid("Vui lòng nhập lý do từ chối.");

            if (request.Approved)
            {
                // Kế hoạch được duyệt sẽ tạo sự kiện => dữ liệu phải đủ để tạo sự kiện hợp lệ
                if (string.IsNullOrWhiteSpace(plan.PlanName))
                    return Invalid("Kế hoạch chưa có tên, không thể tạo sự kiện.");
                if (plan.StartDate == default)
                    return Invalid("Kế hoạch chưa có thời gian bắt đầu, không thể tạo sự kiện.");
                if (plan.EndDate != default && plan.EndDate < plan.StartDate)
                    return Invalid("Thời gian kết thúc của kế hoạch đứng trước thời gian bắt đầu.");
            }

            // Cập nhật kế hoạch và tạo sự kiện trong cùng một transaction:
            // nếu tạo sự kiện lỗi thì kế hoạch vẫn ở trạng thái Chờ duyệt.

            plan.Status = AdminHelper.ReviewStatus(request.Approved);
            plan.ReviewNote = AdminHelper.Clean(request.Reason);

            if (request.Approved && plan.EventId == null)
            {
                var ev = new Event
                {
                    Title = plan.PlanName,
                    Description = string.IsNullOrWhiteSpace(plan.Objective) ? plan.Description : plan.Objective + "\r\n" + plan.Description,
                    Location = plan.Location,
                    StartDate = plan.StartDate,
                    EndDate = plan.EndDate == default ? null : plan.EndDate,
                    Status = "Ongoing",
                    CreatedById = CurrentUserId
                };
                _context.Events.Add(ev);
                await _context.SaveChangesAsync(); // lưu để có ev.Id
                plan.EventId = ev.Id;
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Success(request.Approved ? "Đã duyệt kế hoạch và tạo sự kiện." : "Đã từ chối kế hoạch.");
        }

        private static string? Validate(AdminEventRequest request, bool requiresLocation)
        {
            if (string.IsNullOrWhiteSpace(request.Title)) return "Tên sự kiện không được để trống.";
            if (requiresLocation && string.IsNullOrWhiteSpace(request.Location)) return "Vui lòng nhập địa điểm tổ chức sự kiện.";
            if (request.StartDate == default) return "Vui lòng chọn thời gian bắt đầu.";
            if (request.EndDate.HasValue && request.EndDate < request.StartDate) return "Thời gian kết thúc phải sau thời gian bắt đầu.";
            if (request.MaxParticipants < 0) return "Số chỗ không được âm.";
            if (!ValidStatuses.Contains(request.Status)) return "Trạng thái sự kiện không hợp lệ.";
            return null;
        }

        private static void Apply(Event ev, AdminEventRequest request)
        {
            ev.Title = request.Title.Trim();
            ev.Description = AdminHelper.Clean(request.Description);
            ev.Location = AdminHelper.Clean(request.Location);
            ev.StartDate = request.StartDate;
            ev.EndDate = request.EndDate;
            ev.MaxParticipants = request.MaxParticipants;
            ev.Status = request.Status;
        }

        private async Task<List<AdminEventDto>> ToDtoList(List<Event> events)
        {
            var managerIds = events.Where(e => e.ManagerId != null).Select(e => e.ManagerId!.Value).Distinct().ToList();
            var managers = await _context.Users.AsNoTracking()
                .Where(u => managerIds.Contains(u.Id))
                .ToDictionaryAsync(u => u.Id, u => u.FullName ?? u.Username);

            var eventIds = events.Select(e => e.Id).ToList();
            var counts = await _context.Participants.AsNoTracking()
                .Where(p => eventIds.Contains(p.EventId) && p.ConfirmationStatus != "Đã hủy")
                .GroupBy(p => p.EventId)
                .Select(g => new { EventId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.EventId, x => x.Count);

            return events.Select(e => new AdminEventDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Location = e.Location,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Status = e.Status,
                MaxParticipants = e.MaxParticipants,
                ManagerId = e.ManagerId,
                ManagerName = e.ManagerId != null && managers.ContainsKey(e.ManagerId.Value) ? managers[e.ManagerId.Value] : null,
                RegisteredCount = counts.ContainsKey(e.Id) ? counts[e.Id] : 0
            }).ToList();
        }
    }
}
