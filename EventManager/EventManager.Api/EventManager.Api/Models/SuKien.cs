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
    }
}
