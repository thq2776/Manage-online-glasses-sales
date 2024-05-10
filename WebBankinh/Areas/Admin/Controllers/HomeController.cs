using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBankinh.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["Admin"] != null) 
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "../account/Login");
            }
        }

    }
}