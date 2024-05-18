using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Areas.PrivatePages.Controllers
{
    public class dhDangXuLyController : Controller
    {
        private static MaleFashion_Connect db = new MaleFashion_Connect();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //---------------------------------------- Giành cho Admin + Người dùng ----------------------------------------//

        //--- Hàm duyệt Đơn Hàng ---//
        [HttpPost]
        public ActionResult Active(String IDDonHang)
        {
            DonHang x = db.DonHangs.Find(IDDonHang);
            x.daKichHoat = true;
            x.vanChuyen = false;
            db.SaveChanges();
            return View("Index");
        }

        //--- Hàm hủy Đơn hàng ---//
        [HttpPost]
        public ActionResult Delete(String IDDonHang)
        {
            DonHang x = db.DonHangs.Find(IDDonHang);
            db.DonHangs.Remove(x);
            db.SaveChanges();
            return View("Index");
        }

        //---------------------------------------- Giành cho Shipper ----------------------------------------//

        //--- Hàm nhận giao Đơn hàng ---//
        [HttpPost]
        public ActionResult NhanGiao(String IDDonHang)
        {
            DonHang x = db.DonHangs.Find(IDDonHang);
            x.vanChuyen = true;
            db.SaveChanges();
            return View("Index");
        }

        //--- Hàm không nhận giao Đơn Hàng ---//
        [HttpPost]
        public ActionResult KhongNhanGiao(String IDDonHang)
        {
            DonHang x = db.DonHangs.Find(IDDonHang);
            x.vanChuyen = false;
            db.SaveChanges();
            return View("Index");
        }
    }
}