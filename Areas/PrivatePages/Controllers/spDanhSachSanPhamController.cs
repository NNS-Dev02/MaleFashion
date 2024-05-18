using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Areas.PrivatePages.Controllers
{
    public class spDanhSachSanPhamController : Controller
    {
        private static MaleFashion_Connect db = new MaleFashion_Connect();
        private static bool daDuyet;
        [HttpGet]
        public ActionResult Index(string IsActive)
        {
            daDuyet = IsActive != null && IsActive.Equals("1");
            CapNhatDuLieu();
            return View();
        }



        //--- Hàm xóa sản phẩm ---//
        [HttpPost]
        public ActionResult Delete(String maSanPham)
        {
            SanPham x = db.SanPhams.Find(maSanPham);
            db.SanPhams.Remove(x);
            db.SaveChanges();
            CapNhatDuLieu();
            return View("Index");
        }



        //--- Hàm cấm sản phẩm hiển thị ---//
        [HttpPost]
        public ActionResult Active(String maSanPham)
        {
            SanPham x = db.SanPhams.Find(maSanPham);
            x.duyetSanPham = !daDuyet;
            db.SaveChanges();
            CapNhatDuLieu();
            return View("Index");
        }


        //--- Hàm cập nhật dữ liệu cho View ---//
        private void CapNhatDuLieu()
        {
            List<SanPham> l = db.SanPhams.Where(x => x.duyetSanPham == daDuyet).ToList<SanPham>();
            ViewData["DanhSachSP"] = l;
            ViewBag.dangXuLi = daDuyet ? "Đã duyệt" : "Chưa duyệt";
            ViewBag.tdCuaNut = daDuyet ? "Cấm hiển thị" : "Duyệt sản phẩm";
            ViewBag.ttCuaNut = daDuyet ? "Cấm sản phẩm này hiển thị" : "Cho phép sản phẩm này được hiển thị";
        }
    }
}