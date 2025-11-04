using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LTWeb09_Bai1.Models
{
    [Table("ThamGIa")]
    public partial class ThamGIa
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Sach")]
        public int MaSach { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("TacGia")]
        public int MaTacGia { get; set; }

        [StringLength(50)]
        public string VaiTro { get; set; }

        [StringLength(50)]
        public string ViTri { get; set; }

        public virtual Sach Sach { get; set; }
        public virtual TacGia TacGia { get; set; }
    }
}
