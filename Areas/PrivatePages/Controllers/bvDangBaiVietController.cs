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
    public class bvDangBaiVietController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            BaiViet x = new BaiViet();
            //--- Thiết lập các thông tin mặc định không được phép chỉnh sửa ---//
            x.maBV = string.Format("BV{0:mmssffff}", DateTime.Now);
            x.ngayDang = DateTime.Now;
            x.taiKhoan = ThuongDung.getTenTaiKhoan();
            x.soLanDoc = 0;
            ViewBag.DDHinh = "";
            return View(x);
        }

        [HttpPost]
        public ActionResult Index(BaiViet x, HttpPostedFileBase HinhDaiDien)
        {
            try
            {
                x.maBV = string.Format("BV{0:mmssffff}", DateTime.Now);
                x.duyetBai = false;
                x.ngayDang = DateTime.Now;
                x.taiKhoan = ThuongDung.getTenTaiKhoan();
                x.soLanDoc = 0;
                x.loaiTin = "Tin Tức";
                if (HinhDaiDien != null)
                {
                    //--- Lưu hình vào file chứa hình ảnh bài viết ---//
                    string virPath = "/Asset/Images/baiViet/";
                    string phyPath = Server.MapPath("~/" + virPath);
                    string ext = Path.GetExtension(HinhDaiDien.FileName);
                    string tenFile = "BaiViet" + x.maBV + ext;
                    HinhDaiDien.SaveAs(phyPath + tenFile);
                    x.hinhDD = virPath + tenFile;
                    ViewBag.DDHinh = x.hinhDD;
                }
                else
                    x.hinhDD = "";
                //--- Lưu database ---//
                MaleFashion_Connect db = new MaleFashion_Connect();
                db.BaiViets.Add(x);
                db.SaveChanges();
                //--- Đăng thành công truyền về Danh sách bài viết chưa duyệt ---//
                return RedirectToAction("Index", "bvDanhSachBaiViet", new { IsActive = 0 });
            }
            catch
            {

            }
            return View(x);
        }

    }
}