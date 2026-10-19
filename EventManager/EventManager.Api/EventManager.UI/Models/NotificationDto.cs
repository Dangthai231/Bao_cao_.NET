using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.UI.Models
{
    public class NotificationDto
    {
        public string NotificationCode { get; set; } // Mã (VD: TB001)
        public string Title { get; set; }            // Tiêu đề
        public string Content { get; set; }          // Nội dung
        public string TargetAudience { get; set; }   // Đối tượng
        public DateTime SendDate { get; set; }       // Ngày gửi
        public string Status { get; set; }           // Trạng thái (Đã gửi/Nháp/Đã hủy)
    }
}
