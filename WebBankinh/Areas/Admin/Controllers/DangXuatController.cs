using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBankinh.Areas.Admin.Controllers
{
    public class DangXuatController : Controller
    {
        // GET: Admin/DangXuat
        public ActionResult Index()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "../");
        }
    }
}