using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBankinh.Models.EF
{
    [Table("NguoiDung")]

    public class NguoiDung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? IdTaiKhoan { get; set; }
        [ForeignKey("IdTaiKhoan")]
        public virtual TaiKhoan TaiKhoan { get; set; }
        [Required(ErrorMessage ="Email không được để trống!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Số điện thoại không được để trống!")]
        public string SoDienThoai { get; set; }
        [Required(ErrorMessage ="Địa chỉ không được để trống!")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage ="Họ tên không được để trống!")]
        public string Name { get; set; }
        public int? IdHinhAnh { get; set; }
        public bool? CanhBao { get; set; }
        public bool? Active { get; set; }

    }
}