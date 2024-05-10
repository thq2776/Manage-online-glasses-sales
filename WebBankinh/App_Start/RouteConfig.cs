using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBankinh
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "LoaiSanPham",
               url: "San-Pham",
               defaults: new { controller = "SanPham", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "WebbanKinh.Controllers" }
           );
            routes.MapRoute(
               name: "ChiTietSP",
               url: "chi-tiet-{id}",
               defaults: new { controller = "Menu", action = "ChiTietSP", id = UrlParameter.Optional },
               namespaces: new[] { "WebbanKinh.Controllers" }
           );
            routes.MapRoute(
               name: "TinTuc",
               url: "tin-tuc",
               defaults: new { controller = "tintuc", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "WebbanKinh.Controllers" }
           );
             routes.MapRoute(
               name: "User",
               url: "user",
               defaults: new { controller = "user", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "WebbanKinh.Controllers" }
           );
            routes.MapRoute(
                name: "LienHe",
                url: "lien-he",
                defaults: new { controller = "LienHe", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"WebbanKinh.Controllers"}
            );
            routes.MapRoute(
                name: "CheckOut",
                url: "thanh-toan",
                defaults: new { controller = "Shoppingcart", action = "CheckOut", id = UrlParameter.Optional },
                namespaces: new[] { "WebbanKinh.Controllers" }
            );
            routes.MapRoute(
                name: "Shoppingcart",
                url: "gio-hang",
                defaults: new { controller = "Shoppingcart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"WebbanKinh.Controllers"}
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"WebbanKinh.Controllers"}
            );
        }
    }
}
