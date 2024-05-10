using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBankinh.Models.EF
{
    [Table("SanPham")]

    public class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên sản phẩm không được để trống!")]
        [StringLength(150)]
        public string TenSanPham { get; set; }
        public int?  IdLoaiSanPham { get; set; }
        [ForeignKey("IdLoaiSanPham")]
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public string GhiChu { get; set; }
        public bool? Active { get; set; }

    }
}