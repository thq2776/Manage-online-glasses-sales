using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebBankinh.Models;
using WebBankinh.Models.EF;

namespace WebBankinh.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            if (Session["Admin"] != null) //check view
            {
                var items = db.BienTheSanPhams.OrderByDescending(x => x.Id).Where(x => x.Active == true || x.Active == null);
                return View(items);
            }
            else
            {
                return RedirectToAction("Index", "../account/Login");
            }
            
        }

        public ActionResult Add() 
        {
            if(Session["Admin"] != null)
            {
                ViewBag.LoaiSanPham = new SelectList(db.LoaiSanPhams.Where(x => x.Active == false || x.Active == null).ToList(), "Id", "TenLoai");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "../account/Login");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BienTheSanPham modle )
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(modle.SanPham);
                db.BienTheSanPhams.Add(modle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modle);
        }   
        public ActionResult Edit(int id)
        {
            ViewBag.LoaiSanPham = new SelectList(db.LoaiSanPhams.Where(x => x.Active == false || x.Active == null).ToList(), "Id", "TenLoai");
            var item = db.BienTheSanPhams.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BienTheSanPham modle)
        {

            if(modle != null)
            {
                var getProduct = await db.SanPhams.Where(x => x.Id == modle.IdSanPham).FirstOrDefaultAsync();

                if (getProduct != null)
                {
                    getProduct.TenSanPham = modle.SanPham.TenSanPham;
                    getProduct.GhiChu = modle.SanPham.GhiChu;
                    getProduct.IdLoaiSanPham = modle.SanPham.IdLoaiSanPham;
                }

                var getBienThe = await db.BienTheSanPhams.Where(x => x.Id == modle.Id).FirstOrDefaultAsync();

                if (getBienThe != null)
                {
                    if (modle.KhuyenMai <= 100)
                    {
                        getBienThe.GiaBan = modle.GiaBan;
                        getBienThe.KhuyenMai = modle.KhuyenMai;

                        // Thực hiện cập nhật dữ liệu
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        // Hiển thị thông báo lỗi
                        Console.WriteLine("Khuyến mãi không được vượt quá 100");
                    }
                }

                var getImages = await db.HinhAnhs.Where(x => x.Id == modle.IdHinhAnh).FirstOrDefaultAsync();
                if (getImages != null)
                {
                    getImages.DuongDan = modle.HinhAnh.DuongDan;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modle);
        }

        /*[HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var delete = await db.BienTheSanPhams.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (delete != null)
                {
                    delete.Active = false;
                }
                db.SaveChangesAsync();
            }
            return Json(new { success = false });
        }*/
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.BienTheSanPhams.Find(id);
            if (item != null)
            {
                db.BienTheSanPhams.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });

            }
            return Json(new { success = false });
        }
    }
}