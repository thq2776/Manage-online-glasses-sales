using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBankinh.Models;

namespace WebBankinh.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.Banner1 = db.CauHinhs.Where(x => x.Id == 1).FirstOrDefault().Banner1;
            ViewBag.Banner3 = db.CauHinhs.Where(x => x.Id == 1).FirstOrDefault().Banner3;
            ViewBag.Banner4 = db.CauHinhs.Where(x => x.Id == 1).FirstOrDefault().Banner4;
            ViewBag.Banner5 = db.CauHinhs.Where(x => x.Id == 1).FirstOrDefault().Banner5;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}