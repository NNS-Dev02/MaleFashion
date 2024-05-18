using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models;

namespace MaleFashion.Areas.PrivatePages.Controllers
{
    public class spLoaiSanPhamController : Controller
    {
        private static bool isUpdate = false;
        public ActionResult Index()
        {
            List<LoaiSP> l = new MaleFashion_Connect().LoaiSPs.OrderBy(x => x.tenLoai).ToList<LoaiSP>();
            ViewData["DsLoai"] = l;
            return View();
        }

        //--- Thêm Sản Phẩm ---//
        [HttpPost]
        public ActionResult Index(LoaiSP x)
        {
            MaleFashion_Connect db = new MaleFashion_Connect();
            //--- Bước 1 : Thêm Loại SP từ data ---//
            if (!isUpdate)
                db.LoaiSPs.Add(x);
            else
            {
                LoaiSP y = db.LoaiSPs.Find(x.maLoai);
                y.tenLoai = x.tenLoai;
                y.ghiChu = x.ghiChu;
                isUpdate = false;
            }
            db.SaveChanges(); //--- Save database ---//

            //--- Updata database ---//
            if (ModelState.IsValid)
                ModelState.Clear();
            ViewData["DsLoai"] = db.LoaiSPs.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            return View();
        }

        //--- Xóa Sản Phẩm ---//
        [HttpPost]
        public ActionResult Delete(String ml)
        {
            MaleFashion_Connect db = new MaleFashion_Connect();
            int ma = int.Parse(ml);
            //--- Bước 1 : Tìm Loại SP ---//
            LoaiSP x = db.LoaiSPs.Find(ma);
            //--- Bước 2 : Xóa từ danh sách ---//
            db.LoaiSPs.Remove(x);
            //--- Bước 3 : Update database ---//
            db.SaveChanges();
            //--- Bước 4 : Update data on view ---//
            ViewData["DsLoai"] = db.LoaiSPs.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            return View("Index");
        }

        //--- Chỉnh sửa Sản Phẩm ---//
        [HttpPost]
        public ActionResult Update(String mlcs)
        {
            MaleFashion_Connect db = new MaleFashion_Connect();
            int ma = int.Parse(mlcs);
            //--- Bước 1 : Tìm Loại SP ---//
            LoaiSP x = db.LoaiSPs.Find(ma);
            isUpdate = true;
            //--- Bước 2 : ... ---//
            ViewData["DsLoai"] = db.LoaiSPs.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            return View("Index", x);
        }
    }
}