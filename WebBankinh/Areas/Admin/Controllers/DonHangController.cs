using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBankinh.Models;
using WebBankinh.Models.EF;

namespace WebBankinh.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/DonHang
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                var items = db.DonHangs.OrderByDescending(x => x.Id);
                return View(items);
            }
            else
            {
                return RedirectToAction("Index", "../account/Login");
            }
        }

        public ActionResult Chitiet(DonHang modle)
        {
            if (Session["Admin"] != null)
            {
                var items = db.ChiTietDonHangs.Where(x => x.IdDonHang == modle.Id).ToList();
                return View(items);
            }
            else
            {
                return RedirectToAction("Index", "../account/Login");
            }

        }

        public ActionResult Duyet(int id)
        { 
                var duyet = db.DonHangs.Where(x => x.Id == id).FirstOrDefault();
                duyet.DaThanhToan = 1;
                db.SaveChanges();
            return RedirectToAction("Index", "../admin/DonHang");
        }

        public ActionResult Huy(int id)
        {
            var huy = db.DonHangs.Where(x => x.Id == id).FirstOrDefault();
            huy.DaThanhToan = 2;
            db.SaveChanges();
            return RedirectToAction("Index", "../admin/DonHang");
        }

    }
}