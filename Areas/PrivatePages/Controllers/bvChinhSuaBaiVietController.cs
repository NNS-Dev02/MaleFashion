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
    public class bvChinhSuaBaiVietController : Controller
    {
        private static MaleFashion_Connect db = new MaleFashion_Connect();
        //--- Hàm xóa chỉnh sửa bài viết ---//
        public ActionResult Update(string maBaiViet)
        {
            BaiViet bv = db.BaiViets.FirstOrDefault(x => x.maBV == maBaiViet);
            return View(bv);
        }
        [HttpPost]
        public ActionResult Update(BaiViet bv)
        {
            BaiViet ubv = db.BaiViets.FirstOrDefault(x => x.maBV == bv.maBV);
            ubv.tenBV = bv.tenBV;
            ubv.ndTomTat = bv.ndTomTat;
            ubv.noiDung = bv.noiDung;
            ubv.ngayDang = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index", "bvDanhSachBaiViet", new { IsActive = 1 });
        }
    }
}