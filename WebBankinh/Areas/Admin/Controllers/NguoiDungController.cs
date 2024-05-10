using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBankinh.Models;

namespace WebBankinh.Areas.Admin.Controllers
{
    public class NguoiDungController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/NguoiDung
        public ActionResult Index()
        {
            if (Session["Admin"] != null) //check view
            {
                var items = db.NguoiDungs;
                return View(items);
            }
            else
            {
                return RedirectToAction("Index", "../account/Login");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.NguoiDungs.Find(id);
            if (item != null)
            {
                db.NguoiDungs.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });

            }
            return Json(new { success = false });
        }
    }
}