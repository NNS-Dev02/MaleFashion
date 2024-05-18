using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Controllers
{
    public class ShoppingCartController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //--- Lấy giỏ hàng tù Session ---//
            CartShop gh = Session["GioHang"] as CartShop;
            //--- Truyền ra ngoài VIEW ---//
            ViewData["Cart"] = gh;
            return View();
        }

        //--- Hàm thêm sản phẩm "Icon dấu + " ---//
        public ActionResult Increase(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            gh.addItem(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }

        //--- Hàm giảm bớt sản phẩm "Icon dấu - " ---//
        public ActionResult Decrease(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            gh.decreaseItem(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }

        //--- Hàm xóa bỏ sản phẩm khõi giỏ hàng "Icon dấu X " ---//
        public ActionResult RemoveItem(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            gh.deleteItem(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
    }
}