using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Controllers
{
    public class ShopDetailsController : Controller
    {
        public ActionResult Index(string MaSanPham)
        {
            //--- Dựa vào LinQ để lấy đối tượng sản phẩm từ Database  ---
            MaleFashion_Connect db = new MaleFashion_Connect();
            SanPham x = db.SanPhams.Where(sp => sp.maSP.Equals(MaSanPham)).First<SanPham>();
            //--- Đưa vào View
            ViewData["SpCanXem"] = x;
            return View();
        }
        
    }
}