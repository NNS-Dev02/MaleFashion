using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Areas.PrivatePages.Controllers
{
    public class khKhachHangMoiController : Controller
    {
        private static MaleFashion_Connect db = new MaleFashion_Connect();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(String tenTaiKhoan)
        {
            TaiKhoan x = db.TaiKhoans.Find(tenTaiKhoan);
            db.TaiKhoans.Remove(x);
            db.SaveChanges();
            return View("Index");
        }
    }
}