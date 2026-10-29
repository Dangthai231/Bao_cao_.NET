using EventManager.Api.Data;
using EventManager.Api.DTOs.SinhVien;
using EventManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers.SinhVien
{
    /// <summary>
    /// Use case "Đánh giá và phản hồi sự kiện"
    /// </summary>
    [Route("api/sinhvien/feedbacks")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeedbacksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/sinhvien/feedbacks?userId=3 - Các đánh giá mình đã gửi
        [HttpGet]
        public async Task<IActionResult> GetMyFeedbacks(int userId)
        {
            var result = await (from f in _context.EventFeedbacks
                                join e in _context.Events on f.EventId equals e.Id
                                where f.UserId == userId
                                orderby f.CreatedAt descending
                                select new FeedbackDto
                                {
                                    Id = f.Id,
                                    EventId = e.Id,
                                    EventTitle = e.Title,
                                    Rating = f.Rating,
                                    Comment = f.Comment ?? string.Empty,
                                    CreatedAt = f.CreatedAt
                                }).ToListAsync();

            return Ok(result);
        }

        // GET: api/sinhvien/feedbacks/eligible-events?userId=3
        // Sự kiện được phép đánh giá: đã đăng ký (không hủy) và sự kiện đã bắt đầu / kết thúc
        [HttpGet("eligible-events")]
        public async Task<IActionResult> GetEligibleEvents(int userId)
        {
            var now = DateTime.Now;

            var events = await (from p in _context.Participants
                                join e in _context.Events on p.EventId equals e.Id
                                where p.UserId == userId
                                   && p.ConfirmationStatus != SinhVienHelper.StatusCancelled
                                   && e.Status != "Cancelled"
                                   && e.StartDate <= now
                                orderby e.StartDate descending
                                select e).ToListAsync();

            var result = events.Select(e => new StudentEventDto
            {
                Id = e.Id,
                Title = e.Title,
                Location = e.Location ?? string.Empty,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Status = SinhVienHelper.GetDisplayStatus(e, now)
            }).ToList();

            return Ok(result);
        }

        // POST: api/sinhvien/feedbacks - Gửi đánh giá (gửi lại sẽ cập nhật đánh giá cũ)
        [HttpPost]
        public async Task<IActionResult> SubmitFeedback([FromBody] FeedbackRequest request)
        {
            if (request == null || request.Rating < 1 || request.Rating > 5)
            {
                return BadRequest(new { message = "Số sao đánh giá phải từ 1 đến 5!" });
            }

            var ev = await _context.Events.FindAsync(request.EventId);
            if (ev == null)
            {
                return NotFound(new { message = "Không tìm thấy sự kiện!" });
            }

            bool joined = await _context.Participants.AnyAsync(p =>
                p.UserId == request.UserId &&
                p.EventId == request.EventId &&
                p.ConfirmationStatus != SinhVienHelper.StatusCancelled);

            if (!joined || ev.Status == "Cancelled" || ev.StartDate > DateTime.Now)
            {
                return BadRequest(new { message = "Bạn chỉ có thể đánh giá sự kiện đã tham gia và đã diễn ra!" });
            }

            var feedback = await _context.EventFeedbacks
                .FirstOrDefaultAsync(f => f.UserId == request.UserId && f.EventId == request.EventId);

            bool isNew = feedback == null;
            if (feedback == null)
            {
                feedback = new EventFeedback { UserId = request.UserId, EventId = request.EventId };
                _context.EventFeedbacks.Add(feedback);
            }

            feedback.Rating = request.Rating;
            feedback.Comment = request.Comment?.Trim();
            feedback.CreatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(new { message = isNew ? "Gửi đánh giá thành công!" : "Đã cập nhật đánh giá của bạn!" });
        }

        // DELETE: api/sinhvien/feedbacks/2?userId=3 - Xóa đánh giá của mình
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id, int userId)
        {
            var feedback = await _context.EventFeedbacks.FirstOrDefaultAsync(f => f.Id == id && f.UserId == userId);
            if (feedback == null)
            {
                return NotFound(new { message = "Không tìm thấy đánh giá!" });
            }

            _context.EventFeedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đã xóa đánh giá!" });
        }
    }
}
