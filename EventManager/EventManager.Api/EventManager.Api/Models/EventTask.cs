using System;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Api.Models
{
    public class EventTask
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// "Pending" | "InProgress" | "Completed"
        /// </summary>
        public string Status { get; set; } = "Pending";

        public int EventId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
