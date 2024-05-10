using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBankinh.Models.EF
{
    [Table("LoaiSanPham")]

    public class LoaiSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên viết tắt không được để trống!")]
        [StringLength(150)]
        public string TenVietTat { get; set; }
        [Required(ErrorMessage = "Tên loại sản phẩm không được để trống!")]
        [StringLength(150)]
        public string TenLoai { get; set; }
        public string GhiChu { get; set; }
        public bool? Active { get; set; }
    }
}