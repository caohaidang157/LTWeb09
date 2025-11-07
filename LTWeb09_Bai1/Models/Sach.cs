namespace LTWeb09_Bai1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        [StringLength(50)]
        public string TenSach { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCapNhat { get; set; }

        public string MoTa { get; set; }

        [StringLength(50)]
        public string AnhBia { get; set; }

        public int? SoLuongTon { get; set; }

        public int? MaChuDe { get; set; }

        public int? MaNXB { get; set; }

        [StringLength(10)]
        public string Moi { get; set; }
        public virtual ChuDe ChuDe { get; set; }
        public virtual NhaXuatBan NhaXuatBan { get; set; }
        public virtual ICollection<ThamGIa> ThamGIas { get; set; }
        public object TacGia { get; internal set; }
    }
}
