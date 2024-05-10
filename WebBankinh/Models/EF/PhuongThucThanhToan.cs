using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBankinh.Models.EF
{
    [Table("PhuongThucThanhToan")]

    public class PhuongThucThanhToan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TenVietTat { get; set; }
        public string TenPhuongThuc { get; set; }

    }
}