using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBankinh.Models.EF;

namespace WebBankinh.Models.Dtos
{
    public class ProductMapping
    {
        public LoaiSanPham LoaiSanPham { get; set; }
        public List<BienTheSanPham> BienTheSanPhams { get; set; }
    }
}