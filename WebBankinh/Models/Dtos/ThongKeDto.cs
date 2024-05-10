using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBankinh.Models.Dtos
{
    public class ThongKeDto
    {
        public double? DoanhThuNgay { get; set; }
        public double? DoanhThuThang { get; set; }
        public double? DoanhThuNam { get; set; }
        public List<ChartThongKe> ChartThongKe { get; set;}
    }
}