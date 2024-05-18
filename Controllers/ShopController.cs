using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Controllers
{
    public class ShopController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddtoCart(string maSP)
        {
            //--- Lấy giỏ hàng từ Session ra ---//
            CartShop gh = Session["GioHang"] as CartShop;
            //--- Thêm sản phẩm vừa chọn mua vào giỏ hàng ---//
            gh.addItem(maSP);
            //--- Cập nhật lại giỏ hàng vào trong Session---//
            Session["GioHang"] = gh;
            return View("Index");
        }
    }
}