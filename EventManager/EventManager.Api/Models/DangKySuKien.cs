using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Api.Models
{
    [Table("dang_ky_su_kien")]
    public class DangKySuKien
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("su_kien_id")]
        public long SuKienId { get; set; }

        [Column("ten_dang_nhap")]
        public string TenDangNhap { get; set; } = string.Empty;

        [Column("ngay_dang_ky")]
        public DateTime? NgayDangKy { get; set; }

        [Column("trang_thai")]
        public string? TrangThai { get; set; } // "Đã tham gia", "Vắng mặt", "Đã đăng ký", "Đã hủy"
    }
}
