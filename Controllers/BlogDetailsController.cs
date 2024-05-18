using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Controllers
{
    public class BlogDetailsController : Controller
    {
        public ActionResult Index(string maBV)
        {
            //--- Dựa vào LinQ để lấy bài viết từ Database ---//
            MaleFashion_Connect db = new MaleFashion_Connect();
            BaiViet x = db.BaiViets.Where(z => z.maBV == maBV).First<BaiViet>();
            //--- Đưa vào View ---//
            ViewData["BaiCanXem"] = x;
            return View();
        }
    }
}