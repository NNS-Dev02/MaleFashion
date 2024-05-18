using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Areas.PrivatePages.Controllers
{
    public class bvDanhSachBaiVietController : Controller
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

        //--- Hàm xóa bài viết ---//
        [HttpPost]
        public ActionResult Delete(String maBaiViet)
        {
            BaiViet x = db.BaiViets.Find(maBaiViet);
            db.BaiViets.Remove(x);
            db.SaveChanges();
            CapNhatDuLieu();
            return View("Index");
        }

        //--- Hàm cấm bài viết hiển thị ---//
        public ActionResult Active(String maBaiViet)
        {
            BaiViet x = db.BaiViets.Find(maBaiViet);
            x.duyetBai = !daDuyet;
            db.SaveChanges();
            CapNhatDuLieu();
            return View("Index");
        }

        //--- Hàm cập nhật dữ liệu cho View ---//
        private void CapNhatDuLieu()
        {
            List<BaiViet> l = db.BaiViets.Where(x => x.duyetBai == daDuyet).ToList<BaiViet>();
            ViewData["DanhSachBV"] = l;
            ViewBag.tdCuaNut = daDuyet ? "Cấm hiển thị" : "Duyệt bài viết";
            ViewBag.ttCuaNut = daDuyet ? "Cấm bài viết này hiển thị" : "Cho phép bài viết này được hiển thị";
        }
    }
}