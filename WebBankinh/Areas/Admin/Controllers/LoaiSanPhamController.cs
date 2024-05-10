using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBankinh.Models;
using WebBankinh.Models.EF;

namespace WebBankinh.Areas.Admin.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/LoaiSanPham
        public ActionResult Index()
        {
            if (Session["Admin"] != null) //check view
            {
                var items = db.LoaiSanPhams.OrderByDescending(x => x.Id).Where(x => x.Active == false || x.Active == null);
                return View(items);
            }
            else
            {
                return RedirectToAction("Index", "../account/Login");
            }
        }
        public ActionResult AddLSP()
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
        public ActionResult AddLSP(LoaiSanPham modle)
        {
            if (ModelState.IsValid)
            {
                db.LoaiSanPhams.Add(modle);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(modle);
        }
        public ActionResult Edit(int id)
        {
            var item = db.LoaiSanPhams.Find(id); 
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoaiSanPham modle)
        {
            if (ModelState.IsValid)
            {
                db.LoaiSanPhams.Attach(modle);
                db.Entry(modle).Property(x=>x.TenVietTat).IsModified = true;
                db.Entry(modle).Property(x=>x.TenLoai).IsModified = true;
                db.Entry(modle).Property(x=>x.GhiChu).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(modle);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.LoaiSanPhams.Find(id);
            if (item != null)
            {
                /*db.LoaiSanPhams.Remove(item);*/
                item.Active = true;
                db.SaveChanges();
                return Json(new { success = true });

            }
            return Json(new { success = false });
        }
    }
}