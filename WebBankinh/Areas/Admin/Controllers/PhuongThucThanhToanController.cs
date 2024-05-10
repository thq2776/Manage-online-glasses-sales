using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBankinh.Models;
using WebBankinh.Models.EF;

namespace WebBankinh.Areas.Admin.Controllers
{
    public class PhuongThucThanhToanController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PhuongThucThanhToan
        public ActionResult Index()
        {
            if (Session["Admin"] != null) //check view
            {
                var items = db.PhuongThucThanhToans;
                return View(items);
            }
            else
            {
                return RedirectToAction("Index", "../account/Login");
            }
        }

        public ActionResult Add()
        {
            if (Session["Admin"] != null) //check view
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "../account/Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PhuongThucThanhToan modle)
        {
            if (ModelState.IsValid)
            {
                db.PhuongThucThanhToans.Add(modle);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(modle);
        }

        public ActionResult Edit(int id)
        {
            var item = db.PhuongThucThanhToans.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhuongThucThanhToan modle)
        {
            if (ModelState.IsValid)
            {
                db.PhuongThucThanhToans.Attach(modle);
                db.Entry(modle).Property(x => x.TenVietTat).IsModified = true;
                db.Entry(modle).Property(x => x.TenPhuongThuc).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(modle);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.PhuongThucThanhToans.Find(id);
            if (item != null)
            {
                db.PhuongThucThanhToans.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });

            }
            return Json(new { success = false });
        }

    }
}