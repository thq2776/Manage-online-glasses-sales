using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBankinh.Models.EF
{
    [Table("BienTheSanPham")]
    public class BienTheSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdSanPham { get; set; }
        [ForeignKey("IdSanPham")]
        public virtual SanPham SanPham { get; set; }
        public string GhiChu { get; set; }
        public double? GiaNhap { get; set; }
        public double? GiaBan { get; set; }
        public double? KhuyenMai { get; set; }
        public int? IdHinhAnh { get; set; }
        [ForeignKey("IdHinhAnh")]
        public virtual HinhAnh HinhAnh { get; set; }
        public bool? Active { get; set; }

    }
}