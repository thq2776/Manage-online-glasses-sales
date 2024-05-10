using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBankinh.Models;

namespace WebBankinh.Controllers
{
    public class LienHeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: LienHe
        public ActionResult Index()
        {
            ViewBag.SoDienThoai = db.CauHinhs.Where(x => x.Id == 1).FirstOrDefault().SoDienThoai;
            ViewBag.DiaChi = db.CauHinhs.Where(x => x.Id == 1).FirstOrDefault().DiaChi;
            ViewBag.Email = db.CauHinhs.Where(x => x.Id == 1).FirstOrDefault().Email;
            return View();
        }
    }
}