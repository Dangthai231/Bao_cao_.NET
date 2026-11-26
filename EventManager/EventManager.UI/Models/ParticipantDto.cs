using System;
using System.Collections.Generic;

namespace EventManager.UI.Models
{
    // DTO thông tin sự kiện kèm thống kê người tham gia (bên trái)
    public class ParticipantEventDto
    {
        public long Id { get; set; }
        public string MaSuKien { get; set; } = string.Empty;
        public string TenSuKien { get; set; } = string.Empty;
        public string? DiaDiem { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public int TongSoNguoi { get; set; }
        public int DaDiemDanh { get; set; }
        public int Vang { get; set; }
        public int ChuaDiemDanh { get; set; }

        public string DisplayText => Id == 0 
            ? $"📋 {TenSuKien} ({TongSoNguoi})" 
            : $"{TenSuKien} ({TongSoNguoi} SV)";
    }

    // DTO thông tin sinh viên tham gia sự kiện (bảng bên phải)
    public class ParticipantItemDto
    {
        public long DangKyId { get; set; }
        public long SuKienId { get; set; }
        public string TenSuKien { get; set; } = string.Empty;
        public string MaSinhVien { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string Lop { get; set; } = string.Empty;
        public string TenDangNhap { get; set; } = string.Empty;
        public DateTime? NgayDangKy { get; set; }
        public string DiemDanh { get; set; } = "Chưa điểm danh"; // "Đã điểm danh" | "Vắng" | "Chưa điểm danh"
        public string TrangThai { get; set; } = "Đã xác nhận";   // "Đã xác nhận" | "Đã hủy"

        // Bản sao lưu điểm danh ban đầu để kiểm tra xem dòng nào đã bị sửa
        public string OriginalDiemDanh { get; set; } = "Chưa điểm danh";
    }

    // DTO gửi yêu cầu cập nhật điểm danh
    public class UpdateAttendanceItemDto
    {
        public long DangKyId { get; set; }
        public string DiemDanh { get; set; } = string.Empty;
    }

    // DTO cũ để tương thích ngược
    public class ParticipantDto
    {
        public string ParticipantCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string AttendanceStatus { get; set; } = string.Empty;
        public string ConfirmationStatus { get; set; } = string.Empty;
    }
}
