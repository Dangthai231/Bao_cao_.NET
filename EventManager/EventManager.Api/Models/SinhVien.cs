using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Api.Models
{
    [Table("sinh_vien")]
    public class SinhVien
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("ten_dang_nhap")]
        public string TenDangNhap { get; set; } = string.Empty;

        [Column("ma_sinh_vien")]
        public string? MaSinhVien { get; set; }

        [Column("ho_ten")]
        public string? HoTen { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("so_dien_thoai")]
        public string? SoDienThoai { get; set; }

        [Column("lop")]
        public string? Lop { get; set; }

        [Column("ngay_sinh")]
        public DateTime? NgaySinh { get; set; }
    }
}
