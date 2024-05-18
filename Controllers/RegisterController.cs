using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TaiKhoan t)
        {
            MaleFashion_Connect db = new MaleFashion_Connect();
            db.TaiKhoans.Add(t);
            //--- Mật khẩu sẽ = với mã hóa SH256 ---//
            t.matKhau = MaHoa.encryptSHA256(t.matKhau);
            //--- Thông tin ẩn không thể chỉnh sửa ---//
            t.ngayTao = DateTime.Now;
            //--- Lưu Database ---//
            db.SaveChanges();
            return View("Index",t);
        }
    }
}