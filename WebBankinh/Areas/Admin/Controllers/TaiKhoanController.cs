using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebBankinh.Models;
using WebBankinh.Models.EF;

namespace WebBankinh.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/TaiKhoan
        public ActionResult Index()
        {
            if (Session["Admin"] != null) //check view
            {
                var items = db.TaiKhoans;
                return View(items);
            }
            else
            {
                return RedirectToAction("Index", "../account/Login");
            }
        }
        public ActionResult Add()
        {
            /*            ViewBag.TaiKhoan = new SelectList(db.TaiKhoans.ToList(), "Id", "LoaiTaiKhoan");*/
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(TaiKhoan modle)
        {
           /* var check = db.TaiKhoans.Where(x => x.Username == modle.Username).FirstOrDefaultAsync(); //trùng tên tài khoản k thêm được
            if (check != null)
            {
                return RedirectToAction("Add");
            }*/

            string hashpass = HashPassword(modle.Password); //Mã hoá password
            modle.Password = hashpass;

            if (modle.Username != null && modle.Password != null && modle.LoaiTaiKhoan !=null)
            {
                db.TaiKhoans.Add(modle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(modle);           
        }
        public ActionResult Edit(int id)
        {
            var item = db.TaiKhoans.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaiKhoan modle)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Attach(modle);
                db.Entry(modle).Property(x => x.Username).IsModified = true;
                db.Entry(modle).Property(x => x.Password).IsModified = true;
                db.Entry(modle).Property(x => x.LoaiTaiKhoan).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(modle);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.TaiKhoans.Find(id);
            if (item != null)
            {
                db.TaiKhoans.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });

            }
            return Json(new { success = false });
        }
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}