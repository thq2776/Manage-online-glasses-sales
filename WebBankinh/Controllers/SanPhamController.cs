using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBankinh.Models;

namespace WebBankinh.Controllers
{
    public class SanPhamController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: SanPham
        public ActionResult Index(/*int? page*/)
        {
           /* int pageSize = 10;
            int pageNumber = (page ?? 1);
            var products = db.SanPhams.OrderBy(p => p.TenSanPham);
            return View(products.ToPagedList(pageNumber, pageSize));*/
            return View();
        }
    }
}