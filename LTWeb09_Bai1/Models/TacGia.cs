namespace LTWeb09_Bai1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TacGia")]
    public partial class TacGia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTacGia { get; set; }

        [StringLength(50)]
        public string TenTacGia { get; set; }

        public string DiaChi { get; set; }

        public string TieuSu { get; set; }

        [StringLength(10)]
        public string DienThoai { get; set; }
        public virtual ICollection<ThamGIa> ThamGIas { get; set; }


    }
}
