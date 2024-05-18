using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Controllers
{
    public class CheckOutSuccessController : Controller
    {
        public ActionResult Index()
        {
            //--- Lấy giỏ hàng từ session ra để hiển thị lần cuối ---//
            CartShop gh = Session["GioHang"] as CartShop;
            ViewData["Cart"] = gh;
            //--- Xóa giỏ hàng trong Session ---//
            Session["GioHang"] = new CartShop();
            return View();
        }
    }
}