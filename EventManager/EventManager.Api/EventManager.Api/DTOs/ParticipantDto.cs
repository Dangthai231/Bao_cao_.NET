namespace EventManager.Api.DTOs
{
    public class ParticipantDto
    {
        public string ParticipantCode { get; set; } // Tương ứng cột: Mã
        public string FullName { get; set; }        // Họ tên
        public string Email { get; set; }           // Email
        public string PhoneNumber { get; set; }     // Số điện thoại
        public string Role { get; set; }            // Vai trò (Đại biểu, Khách mời...)
        public string AttendanceStatus { get; set; } // Điểm danh (Có mặt, Vắng mặt...)
        public string ConfirmationStatus { get; set; }// Trạng thái (Đã xác nhận, Đã hủy...)
    }
}
