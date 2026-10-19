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
    }
}
