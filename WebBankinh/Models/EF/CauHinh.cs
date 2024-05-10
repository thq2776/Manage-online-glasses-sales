using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBankinh.Models.EF
{
    [Table("CauHinh")]

    public class CauHinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Banner1 { get; set; }
        public string Banner2 { get; set; }
        public string Banner3 { get; set; }
        public string Banner4 { get; set; }
        public string Banner5 { get; set; }
        public string Email { get; set; }
    }
}