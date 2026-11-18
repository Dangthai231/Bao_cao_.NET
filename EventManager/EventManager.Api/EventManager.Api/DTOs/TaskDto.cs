using System;

namespace EventManager.Api.DTOs
{
    public class TaskDto
    {
        public long Id { get; set; }
        public string MaCv { get; set; } = string.Empty;
        public string TenCongViec { get; set; } = string.Empty;
        public string? MoTa { get; set; }
        public long? SuKienId { get; set; }
        public string? TenSuKien { get; set; }
        public string? NhanSu { get; set; }
        public string MucDoUuTien { get; set; } = "Trung bình";
        public DateTime? HanChot { get; set; }
        public int TienDo { get; set; } = 0;
        public string TrangThai { get; set; } = "Chưa bắt đầu";
        public DateTime? NgayTao { get; set; }
    }

    public class CreateTaskDto
    {
        public string TenCongViec { get; set; } = string.Empty;
        public string? MoTa { get; set; }
        public long? SuKienId { get; set; }
        public string? TenSuKien { get; set; }
        public string? NhanSu { get; set; }
        public string MucDoUuTien { get; set; } = "Trung bình";
        public DateTime? HanChot { get; set; }
        public int TienDo { get; set; } = 0;
        public string TrangThai { get; set; } = "Chưa bắt đầu";
    }

    public class UpdateTaskDto
    {
        public string TenCongViec { get; set; } = string.Empty;
        public string? MoTa { get; set; }
        public long? SuKienId { get; set; }
        public string? TenSuKien { get; set; }
        public string? NhanSu { get; set; }
        public string MucDoUuTien { get; set; } = "Trung bình";
        public DateTime? HanChot { get; set; }
        public int TienDo { get; set; }
        public string TrangThai { get; set; } = "Chưa bắt đầu";
    }

    public class AssignTaskDto
    {
        public string NhanSu { get; set; } = string.Empty;
    }

    public class TaskSummaryDto
    {
        public int TongCongViec { get; set; }
        public int DangThucHien { get; set; }
        public int HoanThanh { get; set; }
        public int QuaHan { get; set; }
        public int TienDoTrungBinh { get; set; }
    }

    public class TaskEventOptionDto
    {
        public long Id { get; set; }
        public string TenSuKien { get; set; } = string.Empty;
    }

    public class TaskUserOptionDto
    {
        public string DisplayText { get; set; } = string.Empty; // e.g. "Nguyễn Văn Thái (canbo01)"
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
