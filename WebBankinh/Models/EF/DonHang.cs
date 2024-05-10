using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBankinh.Models.EF
{
    [Table("DonHang")]

    public class DonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdNguoiDung{ get; set; }
        [ForeignKey("IdNguoiDung")]
        public virtual NguoiDung NguoiDung { get; set; }
        public int? TongSoLuong { get; set; }
        public double? TongTien { get; set; }
        public double? TongTienGiam { get; set; }
        public double? KhachPhaiTra { get; set; }
        public int? DaThanhToan { get; set; }
        public int? IdPhuongThucThanhToan { get; set; }
        [ForeignKey("IdPhuongThucThanhToan")]
        public virtual PhuongThucThanhToan PhuongThucThanhToan { get; set; }
        public DateTime  NgayTaoDonhang { get; set; }
            
    }
}