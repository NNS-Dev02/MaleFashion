using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;
using System.IO;

namespace MaleFashion.Areas.PrivatePages.Controllers
{
    [ValidateInput(false)]
    public class spChinhSuaSanPhamController : Controller
    {
        private static MaleFashion_Connect db = new MaleFashion_Connect();
        //--- Hàm xóa chỉnh sửa sản phẩm ---//
        public ActionResult Update(string maSanPham)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.maSP == maSanPham);
            return View(sp);
        }
        [HttpPost]
        public ActionResult Update(SanPham sp)
        {
            SanPham usp = db.SanPhams.FirstOrDefault(x => x.maSP == sp.maSP);
            usp.tenSP = sp.tenSP;
            usp.ndTomTat = sp.ndTomTat;
            usp.giaGoc = sp.giaGoc;
            usp.giaBan = sp.giaBan;
            usp.dvt = sp.dvt;
            usp.nhaSanXuat = sp.nhaSanXuat;
            usp.maLoai = sp.maLoai;
            usp.NoiDung = sp.NoiDung;
            usp.ngayDang = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index", "spDanhSachSanPham", new { IsActive = 1 });
        }
    }
}