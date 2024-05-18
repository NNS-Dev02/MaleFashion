using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Acc, string Pass)
        {
            //--- So mã hóa ---//
            string mk = MaHoa.encryptSHA256(Pass);
            //--- Đọc tài khoản từ Database ---//
            TaiKhoan ttdn = new MaleFashion_Connect().TaiKhoans.Where(x => x.taiKhoan1.Equals(Acc.ToLower().Trim())
                            && x.matKhau.Equals(mk)).First<TaiKhoan>();
            //--- Hàm lấy thông tin tài khoản login ---//
            Session["HovaTen"] = ttdn.hoDem + " " + ttdn.tenTV;
            Session["NgaySinh"] = ttdn.ngaysinh;
            Session["GioiTinh"] = ttdn.GioiTinh;
            Session["SoDT"] = ttdn.soDT;
            Session["Email"] = ttdn.email;
            Session["DiaChi"] = ttdn.diaChi;
            Session["ChucVu"] = ttdn.GroupID;
            //--- Hàm lấy GroupID tài khoản login ---//
            var listGroups = GetListGroupID(Acc);
            Session.Add("Session_Group", listGroups);
            //--- Hàm kiểm tra tài khoản ---//
            bool isAuthentic = ttdn != null && ttdn.taiKhoan1.Equals(Acc.ToLower().Trim()) && ttdn.matKhau.Equals(mk);
            if (isAuthentic)
            {
                Session["TtDangNhap"] = ttdn;
                return RedirectToAction("Index", "Dashboard", new { Area = "PrivatePages" });
            }
            return View();
        }



        /// ---Hàm nối giữa 2 table UserGroups & TaiKhoans ---///
        public List<string> GetListGroupID(string userName)
        {
            // var user = db.User.Single(x => x.UserName == userName);
            MaleFashion_Connect db = new MaleFashion_Connect();
            var data = (from a in db.UserGroups
                        join b in db.TaiKhoans on a.ID equals b.GroupID
                        where b.taiKhoan1 == userName

                        select new
                        {
                            UserGroupID = b.GroupID,
                            UserGroupName = a.Name
                        });

            return data.Select(x => x.UserGroupName).ToList();
        }
    }
}