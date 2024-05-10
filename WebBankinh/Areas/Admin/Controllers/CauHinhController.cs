using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBankinh.Models;
using WebBankinh.Models.EF;

namespace WebBankinh.Areas.Admin.Controllers
{
    public class CauHinhController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/CauHinh
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                var items = db.CauHinhs;
                return View(items);
            }
            else
            {
                return RedirectToAction("Index", "../account/Login");
            }
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CauHinh modle)
        {
            if (ModelState.IsValid)
            {
                db.CauHinhs.Add(modle);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(modle);
        }
        public ActionResult Edit(int id)
        {
            var item = db.CauHinhs.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CauHinh modle)
        {
            if (ModelState.IsValid)
            {
                db.CauHinhs.Attach(modle);
                db.Entry(modle).Property(x => x.Banner1).IsModified = true;
                db.Entry(modle).Property(x => x.Banner2).IsModified = true;
                db.Entry(modle).Property(x => x.Banner3).IsModified = true;
                db.Entry(modle).Property(x => x.Banner4).IsModified = true;
                db.Entry(modle).Property(x => x.Banner5).IsModified = true;
                db.Entry(modle).Property(x => x.SoDienThoai).IsModified = true;
                db.Entry(modle).Property(x => x.DiaChi).IsModified = true;
                db.Entry(modle).Property(x => x.Email).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(modle);
        }
    }
}