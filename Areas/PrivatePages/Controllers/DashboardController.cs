using MaleFashion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaleFashion.Models.ViewModels;

namespace MaleFashion.Areas.PrivatePages.Controllers
{
    public class DashboardController : Controller
    {
        // GET: PrivatePages/Dashboard
        public ActionResult Index()
        {
            // lấy tổng doanh thu từ trước đến nay
            float doanhthu = LayTongDoanhThu();
            // Tạo biến view model ở đây rồi đẩy nó ra ngoài như các màn hình khác
            DashboardViewModel model = new DashboardViewModel
            {
                TongDoanhThu = doanhthu
            };
            return View(model);
        }

        private float LayTongDoanhThu()
        {
            var db = new MaleFashion_Connect();
            // Lấy tất cả các chi tiết đơn hàng và thông tin sản phẩm
            var ctDonHangs = (from ctdh in db.CtDonHangs
                             join sp in db.SanPhams
                             on ctdh.maSP equals sp.maSP
                             select new
                             {
                                 ctdh.maSP,
                                 ctdh.soLuong,
                                 sp.giaBan
                             }).ToList();
            long? tongDoanhThu = ctDonHangs.Sum(s => s.giaBan * s.soLuong);
            db.Dispose();
            return tongDoanhThu.Value;
        }
    }
}