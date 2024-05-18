using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaleFashion.Models;

namespace MaleFashion.Areas.PrivatePages.Model
{
    public class ThuongDung
    {
        public static TaiKhoan getTTTaiKhoan()
        {
            TaiKhoan kq = new TaiKhoan();
            kq = HttpContext.Current.Session["TtDangNhap"] as TaiKhoan;
            return kq;
        }

        //--- Hàm đọc tên tài khoản đã đăng nhập ---//
        public static string getTenTaiKhoan()
        {
            return getTTTaiKhoan().taiKhoan1;
        }
    }
}