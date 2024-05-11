using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBankinh.Models;
using WebBankinh.Models.Dtos;
using WebBankinh.Models.EF;

namespace WebBankinh.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string search)
        {
            var listProduct = new List<ProductMapping>();
            var items = db.LoaiSanPhams.Where(x => x.Active == false || x.Active == null).ToList();

            foreach (var item in items)
            {
                var product = db.BienTheSanPhams.Where(f => f.SanPham.IdLoaiSanPham == item.Id || f.SanPham.TenSanPham.Contains(search)).ToList();
                listProduct.Add(new ProductMapping() { LoaiSanPham = item, BienTheSanPhams = product });
            }
            return RedirectToAction("Index", "Home", listProduct);
        }
    }
}