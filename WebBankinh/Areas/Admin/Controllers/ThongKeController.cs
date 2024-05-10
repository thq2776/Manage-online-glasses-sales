using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebBankinh.Models;
using WebBankinh.Models.Dtos;

namespace WebBankinh.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ThongKe
        public async Task<ActionResult> Index()
        {
            //Thống kê ngày
            ThongKeDto tk = new ThongKeDto();
            DateTime now = DateTime.Now;
            double? ThongKeNgay = db.DonHangs.Where(x => x.NgayTaoDonhang.Day == now.Day).Sum(x => x.TongTien);
            double? ThongKeThang = db.DonHangs.Where(x => x.NgayTaoDonhang.Month == now.Month).Sum(x => x.TongTien);
            double? ThongKeNam = db.DonHangs.Where(x => x.NgayTaoDonhang.Year == now.Year).Sum(x => x.TongTien);
            var ChartThongKeNam = db.DonHangs.GroupBy(x => x.NgayTaoDonhang.Month).Select(g => new ChartThongKe { month = g.Key, total = g.Sum(x => x.TongTien)}).ToList();
            tk.DoanhThuNgay = ThongKeNgay;
            tk.DoanhThuThang = ThongKeThang;
            tk.DoanhThuNam = ThongKeNam;
            tk.ChartThongKe = ChartThongKeNam;
            return View(tk);
        }
    }
}