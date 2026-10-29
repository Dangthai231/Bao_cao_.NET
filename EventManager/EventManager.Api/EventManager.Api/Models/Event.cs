using System;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Api.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// "Ongoing" | "Completed" | "Cancelled"
        /// </summary>
        public string Status { get; set; } = "Ongoing";

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }

        public int CreatedById { get; set; }

        // Thông tin hiển thị cho sinh viên khi tra cứu / xem chi tiết sự kiện
        public string? Description { get; set; }
        public string? Location { get; set; }

        /// <summary>
        /// Số lượng tối đa được đăng ký. 0 = không giới hạn
        /// </summary>
        public int MaxParticipants { get; set; } = 0;
    }
}
