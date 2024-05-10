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
    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            ViewBag.Banner2 = db.CauHinhs.Where(x => x.Id == 1).FirstOrDefault().Banner2;
            return View();
        }
        public ActionResult MenuLoaiSanPham()
        {
            var listProduct = new List<ProductMapping>();
            var items = db.LoaiSanPhams.OrderByDescending(x => x.Id).Where(x => x.Active == false || x.Active == null).ToList();

            foreach (var item in items)
            {
                var product = db.BienTheSanPhams.Where(f => f.SanPham.IdLoaiSanPham == item.Id).OrderByDescending(x => x.Id).ToList();
                listProduct.Add(new ProductMapping() { LoaiSanPham = item, BienTheSanPhams = product});
            }
            return PartialView("MenuLoaiSanPham", listProduct);
        }

        public ActionResult ChiTietSP(int id)
        {
            var item = db.BienTheSanPhams.Include("HinhAnh").Include("SanPham").FirstOrDefault(f => f.SanPham.Id == id);
            ViewBag.CategoryName = db.LoaiSanPhams.FirstOrDefault(f => f.Id == item.SanPham.IdLoaiSanPham).TenLoai;
            return View(item);
        }
    }
}

