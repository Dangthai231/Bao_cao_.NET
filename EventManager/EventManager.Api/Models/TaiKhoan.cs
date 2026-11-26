using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Api.Models
{
    [Table("tai_khoan")]
    public class TaiKhoan
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("ten_dang_nhap")]
        public string? TenDangNhap { get; set; }

        [Column("ho_ten")]
        public string? HoTen { get; set; }

        [Column("vai_tro")]
        public string? VaiTro { get; set; }

        [Column("ma_so")]
        public string? MaSo { get; set; }
    }
}
