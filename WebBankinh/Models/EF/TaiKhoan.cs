using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBankinh.Models.EF
{
    [Table("TaiKhoan")]

    public class TaiKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên Username không được để trống!")]
        [StringLength(150)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password không được để trống!")]
        [StringLength(150)]
        public string Password { get; set; }
        [Required(ErrorMessage = "loại tài khoản không được để trống!")]
        [StringLength(150)]
        public string LoaiTaiKhoan { get; set; }
        


    }
}