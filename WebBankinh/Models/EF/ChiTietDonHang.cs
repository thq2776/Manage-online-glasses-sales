using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBankinh.Models.EF
{
    [Table("ChiTietDonHang")]

    public class ChiTietDonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdDonHang { get; set; }
        [ForeignKey("IdDonHang")]
        public virtual DonHang DonHang { get; set; }
        public int? IdBienTheSanPham { get; set; }
        [ForeignKey("IdBienTheSanPham")]
        public virtual BienTheSanPham BienTheSanPham { get; set; }
        public double? DonGia { get; set; }
        public double? SoLuong { get; set; }
        public double? PhanTramGiam { get; set; }
        public double? TongTienGiam { get; set; }
        public double? ThanhTien { get; set; }

    }
}