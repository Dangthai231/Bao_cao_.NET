using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Api.Models
{
    [Table("cong_viec")]
    public class CongViec
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("ma_cv")]
        public string? MaCv { get; set; }

        [Column("ten_cong_viec")]
        public string TenCongViec { get; set; } = string.Empty;

        [Column("mo_ta")]
        public string? MoTa { get; set; }

        [Column("su_kien_id")]
        public long? SuKienId { get; set; }

        [Column("ten_su_kien")]
        public string? TenSuKien { get; set; }

        [Column("nhan_su")]
        public string? NhanSu { get; set; }

        [Column("muc_do_uu_tien")]
        public string? MucDoUuTien { get; set; } // "Cao", "Trung bình", "Thấp"

        [Column("han_chot")]
        public DateTime? HanChot { get; set; }

        [Column("tien_do")]
        public int TienDo { get; set; } = 0;

        [Column("trang_thai")]
        public string? TrangThai { get; set; } // "Chưa bắt đầu", "Đang thực hiện", "Hoàn thành", "Tạm hoãn"

        [Column("ngay_tao")]
        public DateTime? NgayTao { get; set; } = DateTime.Now;
    }
}
