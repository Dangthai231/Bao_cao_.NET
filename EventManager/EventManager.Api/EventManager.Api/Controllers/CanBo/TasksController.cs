using EventManager.Api.Data;
using EventManager.Api.DTOs;   // File chứa CreatePlanDto / PlanDto
using EventManager.Api.Models; // File chứa class Plan (Model DB)
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
namespace EventManager.Api.Controllers.CanBo
{
    [Route("api/canbo/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TasksController(AppDbContext context)
        {
            _context = context;
        }
        // ========================================================
        // PHẦN 1: QUẢN LÝ KẾ HOẠCH (Tab Lập kế hoạch sự kiện)
        // ========================================================

        // API: Lấy dữ liệu kế hoạch cũ (GET: api/canbo/tasks/plan/5)
        [HttpGet("plan/{planId}")]
        public async Task<IActionResult> GetPlan(int planId)
        {
            var plan = await _context.Plans.FindAsync(planId);
            if (plan == null)
            {
                return NotFound(new { message = "Không tìm thấy kế hoạch này!" });
            }

            var planDto = new CreatePlanDto
            {
                PlanName = plan.PlanName,
                Objective = plan.Objective,
                Description = plan.Description,
                StartDate = plan.StartDate,
                EndDate = plan.EndDate,
                Location = plan.Location,
                Budget = plan.Budget
            };
            return Ok(planDto);
        }

        // API: Lưu kế hoạch mới (POST: api/canbo/tasks/plan)
        [HttpPost("plan")]
        public async Task<IActionResult> SavePlan([FromBody] CreatePlanDto request)
        {
            var newPlan = new Plan
            {
                PlanName = request.PlanName,
                Objective = request.Objective,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Location = request.Location,
                Budget = request.Budget
            };

            _context.Plans.Add(newPlan);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Lưu kế hoạch thành công!" });
        }
    }
}
