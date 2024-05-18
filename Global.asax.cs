using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using System.Web.Optimization;
using MaleFashion.App_Start;
using MaleFashion.Models;

namespace MaleFashion
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //--- Bundle Link ---//
            BundleCollection bundles = BundleTable.Bundles;
            BundleConfig.RegisterBundle(bundles);
        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            Session["TtDangNhap"] = null;
            //--- Cấp cho người truy cập Giỏ Hàng ---//
            Session["GioHang"] = new CartShop();
        }
    }

}
