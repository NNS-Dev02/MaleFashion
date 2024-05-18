using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Areas.PrivatePages.Controllers
{
    public class dhDangGiaoChoKhachController : Controller
    {
        private static MaleFashion_Connect db = new MaleFashion_Connect();
        public ActionResult Index()
        {
            return View();
        }

        //--- Hàm Đơn Hàng đã giao thành công ---//
        [HttpPost]
        public ActionResult GiaoThanhCong(String IDDonHang)
        {
            DonHang x = db.DonHangs.Find(IDDonHang);
            x.trangThai = true;
            db.SaveChanges();
            return View("Index");
        }

        //--- Hàm Đơn hàng đã bị hủy ---//
        [HttpPost]
        public ActionResult BiHuy(String IDDonHang)
        {
            DonHang x = db.DonHangs.Find(IDDonHang);
            x.trangThai = false;
            db.SaveChanges();
            return View("Index");
        }
    }
}