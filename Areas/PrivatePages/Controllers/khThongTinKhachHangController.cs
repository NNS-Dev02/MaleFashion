using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Areas.PrivatePages.Controllers
{
    public class khThongTinKhachHangController : Controller
    {
        // GET: PrivatePages/khThongTinKhachHang
        public ActionResult Index(string taiKhoan1)
        {
            //--- Dựa vào LinQ để lấy bài viết từ Database ---//
            MaleFashion_Connect db = new MaleFashion_Connect();
            TaiKhoan x = db.TaiKhoans.Where(z => z.taiKhoan1 == taiKhoan1).First<TaiKhoan>();
            //--- Đưa vào View ---//
            ViewData["ThongTinKhachHang"] = x;
            return View();
        }
    }
}