using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Api.Models
{
    [Table("su_kien")]
    public class SuKien
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("ten_su_kien")]
        public string? TenSuKien { get; set; }

        [Column("ma_su_kien")]
        public string? MaSuKien { get; set; }

        [Column("dia_diem")]
        public string? DiaDiem { get; set; }

        [Column("thoi_gian_bat_dau")]
        public DateTime? ThoiGianBatDau { get; set; }

        [Column("thoi_gian_ket_thuc")]
        public DateTime? ThoiGianKetThuc { get; set; }

        [Column("trang_thai")]
        public string? TrangThai { get; set; }

        [Column("mo_ta")]
        public string? MoTa { get; set; }

        [Column("so_luong_toi_da")]
        public int? SoLuongToiDa { get; set; }
    }
}
