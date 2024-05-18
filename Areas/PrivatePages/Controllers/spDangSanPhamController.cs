using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;
using MaleFashion.Areas.PrivatePages.Model;
using System.IO;

namespace MaleFashion.Areas.PrivatePages.Controllers
{
    [ValidateInput(false)]
    public class spDangSanPhamController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            SanPham x = new SanPham();
            //--- Thiết lập các thông tin mặc định không được phép chỉnh sửa ---//
            x.maSP = string.Format("SP{0:mmssffff}", DateTime.Now);
            x.ngayDang = DateTime.Now;
            x.taiKhoan = ThuongDung.getTenTaiKhoan();
            x.soLanXem = 0;
            ViewBag.DDHinh = "";
            return View(x);
        }

        [HttpPost]
        public ActionResult Index(SanPham x, HttpPostedFileBase HinhDaiDien)
        {
            try
            {
                x.maSP = string.Format("SP{0:mmssffff}", DateTime.Now);
                x.duyetSanPham = false;
                x.ngayDang = DateTime.Now;
                x.taiKhoan = ThuongDung.getTenTaiKhoan();
                x.soLanXem = 0;
                if (HinhDaiDien != null)
                {
                    //--- Lưu hình vào file chứa hình ảnh bài viết ---//
                    string virPath = "/Asset/Images/sanPham/";
                    string phyPath = Server.MapPath("~/" + virPath);
                    string ext = Path.GetExtension(HinhDaiDien.FileName);
                    string tenFile = "SanPham" + x.maSP + ext;
                    HinhDaiDien.SaveAs(phyPath + tenFile);
                    x.hinhDD = virPath + tenFile;
                    ViewBag.DDHinh = x.hinhDD;
                }
                else
                    x.hinhDD = "";
                //--- Lưu database ---//
                MaleFashion_Connect db = new MaleFashion_Connect();
                db.SanPhams.Add(x);
                db.SaveChanges();
                //--- Đăng thành công truyền về Danh sách bài viết chưa duyệt ---//
                return RedirectToAction("Index", "spDanhSachSanPham", new { IsActive = 0 });
            }
            catch
            {

            }
            return View(x);
        }
    }
}