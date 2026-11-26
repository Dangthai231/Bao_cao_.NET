using System;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Api.Models
{
    /// <summary>
    /// Đánh giá và phản hồi của sinh viên sau khi tham gia sự kiện
    /// </summary>
    public class EventFeedback
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public int UserId { get; set; }

        /// <summary>
        /// Số sao đánh giá: 1 - 5
        /// </summary>
        [Range(1, 5)]
        public int Rating { get; set; } = 5;

        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
