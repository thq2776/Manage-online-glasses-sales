using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBankinh.Models;
using WebBankinh.Models.EF;

namespace WebBankinh.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var item = db.NguoiDungs.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NguoiDung modle)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Attach(modle);
                db.Entry(modle).Property(x => x.Name).IsModified = true;
                db.Entry(modle).Property(x => x.DiaChi).IsModified = true;
                db.Entry(modle).Property(x => x.SoDienThoai).IsModified = true;
                db.Entry(modle).Property(x => x.Email).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("../user");

            }
            return View(modle);
        }

    }
}