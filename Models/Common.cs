using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MaleFashion.Controllers;
using MaleFashion.Areas.PrivatePages.Model;

namespace MaleFashion.Models
{
    public class Common
    {
        ///-------------------------------------------------- SẢN PHẨM --------------------------------------------------/// 


        //--- Khai báo 1 đối tượng đại diện cho Database ---//
        static DbContext cn = new DbContext("name=MaleFashion_Connect");

        ///--- Hàm lấy ra danh sách "Chi Tiết Sản Phẩm" ---///
        public static List<SanPham> getProductByLoaiSP(int maLoai)
        {
            List<SanPham> l = new List<SanPham>();
            //--- Khai báo 1 đối tượng đại diện cho Database ---//
            DbContext cn = new DbContext("name=MaleFashion_Connect");
            //--- Lấy dữ liệu ---//
            l = cn.Set<SanPham>().Where(m => m.duyetSanPham == true).Where(m => m.maLoai == maLoai).ToList<SanPham>();
            return l;
        }

        ///--- Hàm cho phép lấy ra danh sách các "Mã Loại Sản Phẩm" ---///
        public static List<LoaiSP> getCategories()
        {
            return new DbContext("name=MaleFashion_Connect").Set<LoaiSP>().ToList<LoaiSP>();
        }

        /// ---Hàm cho phép lấy ra "tất cả sản phẩm cũ nhất" ---///
        public static List<SanPham> getProductOld(int cu)
        {
            List<SanPham> l = new List<SanPham>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            l = db.SanPhams.Where(o => o.duyetSanPham == true).OrderBy(o => o.ngayDang).Take(cu).ToList<SanPham>();
            return l;
        }

        /// ---Hàm cho phép lấy ra "tất cả sản phẩm mới nhất" ---///
        public static List<SanPham> getProductNew(int moi)
        {
            List<SanPham> l = new List<SanPham>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            l = db.SanPhams.Where(n => n.duyetSanPham == true).OrderByDescending(n => n.ngayDang).Take(moi).ToList<SanPham>();
            return l;
        }

        /// ---Hàm cho phép lấy ra "tất cả sản phẩm sale nhất" ---///
        public static List<SanPham> getProductSale(int re)
        {
            List<SanPham> l = new List<SanPham>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            l = db.SanPhams.Where(s => s.duyetSanPham == true).OrderBy(s => (s.giaGoc - s.giaBan)).Take(re).ToList<SanPham>();
            return l;
        }

        ///--- Hàm cho phép lấy ra danh sách sản phẩm cho USER đăng ở trang Area---///
        public static List<SanPham> getProductUser(int n)
        {
            List<SanPham> l = new List<SanPham>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            l = db.SanPhams.OrderByDescending(bv => bv.ngayDang).Take(n).ToList<SanPham>();
            return l;
        }

        ///--- Hàm cho phép lấy ra danh sách sản phẩm theo ID cho CartShop---///
        public static SanPham getProductByID(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP);
        }

        ///--- Hàm cho phép lấy ra "TÊN" của sản phẩm theo ID cho CartShop---///
        public static string getNameProductByID(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP).tenSP;
        }

        ///--- Hàm cho phép lấy ra "ẢNH" của sản phẩm theo ID cho CartShop---///
        public static string getImageProductByID(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP).hinhDD;
        }

        ///--- Hàm cho phép lấy ra "Nội dung tóm tắt" của sản phẩm theo ID cho CartShop---///
        public static string getNdTomTatProductByID(string maSP)
        {
            return cn.Set<SanPham>().Find(maSP).ndTomTat;
        }


        ///-------------------------------------------------- BÀI VIẾT --------------------------------------------------/// 

        /// ---Hàm cho phép lấy ra " 3 bài viết mới nhất ở trang HOME " ---///
        public static List<BaiViet> getArticlesNew(int s)
        {
            List<BaiViet> l = new List<BaiViet>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            l = db.BaiViets.Where(m => m.duyetBai == true).OrderByDescending(sp => sp.ngayDang).Take(s).ToList<BaiViet>();
            return l;
        }

        ///--- Hàm cho phép lấy ra danh sách bài viết cho USER đăng ở trang Area ---///
        public static List<BaiViet> getArticlesUser(int n)
        {
            List<BaiViet> l = new List<BaiViet>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            l = db.BaiViets.OrderByDescending(bv => bv.ngayDang).Take(n).ToList<BaiViet>();
            return l;
        }



        ///-------------------------------------------------- NGƯỜI DÙNG --------------------------------------------------/// 

        ///--- Hàm cho phép lấy ra "tất cả thông tin của người dùng" ---///
        public static List<TaiKhoan> getUser(int n)
        {
            List<TaiKhoan> u = new List<TaiKhoan>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            u = db.TaiKhoans.Where(m => m.ngayTao != null).OrderByDescending(bv => bv.ngayTao).Take(n).ToList<TaiKhoan>();
            return u;
        }



        ///-------------------------------------------------- THANH TOÁN THÀNH CÔNG --------------------------------------------------/// 

        ///--- Hàm cho phép lấy ra thông tin khách hàng vừa mới đặt hàng ---///
        public static List<KhachHang> getKhachHangMoi(int s)
        {
            List<KhachHang> l = new List<KhachHang>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            l = db.KhachHangs.OrderByDescending(sp => sp.ngayDat).Take(s).ToList<KhachHang>();
            return l;
        }

        ///--- Hàm cho phép lấy ra thông tin đơn hàng vừa mới đặt hàng ---///
        public static List<DonHang> getDonHangMoi(int s)
        {
            List<DonHang> l = new List<DonHang>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            l = db.DonHangs.OrderByDescending(sp => sp.ngayDat).Take(s).ToList<DonHang>();
            return l;
        }



        ///-------------------------------------------------- ĐƠN HÀNG --------------------------------------------------///

        ///--- Hàm cho phép lấy ra thông tin đơn hàng đang xử lý ---///
        public static List<DonHang> getDonHangDangXuLy(int dh)
        {
            List<DonHang> l = new List<DonHang>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            l = db.DonHangs.Where(o => o.daKichHoat == false).Where(o => o.vanChuyen == false).OrderBy(o => o.ngayDat).Take(dh).ToList<DonHang>();
            return l;
        }

        ///--- Hàm cho phép lấy ra thông tin đơn hàng đã duyệt ---///
        public static List<DonHang> getDonHangDaDuyet(int dh)
        {
            List<DonHang> l = new List<DonHang>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            l = db.DonHangs.Where(o => o.daKichHoat == true).Where(o => o.vanChuyen == false).OrderBy(o => o.ngayDat).Take(dh).ToList<DonHang>();
            return l;
        }

        ///--- Hàm cho phép lấy ra thông tin đơn hàng đã được Shipper nhận giao ---///
        public static List<DonHang> getDonHangDaNhanGiao(int dh)
        {
            List<DonHang> l = new List<DonHang>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            l = db.DonHangs.Where(o => o.vanChuyen == true).Where(o => o.trangThai == null).OrderBy(o => o.ngayDat).Take(dh).ToList<DonHang>();
            return l;
        }

        ///--- Hàm cho phép lấy ra thông tin đơn hàng đã giao thành công ---///
        public static List<DonHang> getDonHangGiaoThanhCong(int dh)
        {
            List<DonHang> l = new List<DonHang>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            l = db.DonHangs.Where(o => o.trangThai == true).OrderBy(o => o.ngayDat).Take(dh).ToList<DonHang>();
            return l;
        }

        ///--- Hàm cho phép lấy ra thông tin đơn hàng đã bị hủy ---///
        public static List<DonHang> getDonHangBiHuy(int dh)
        {
            List<DonHang> l = new List<DonHang>();
            MaleFashion_Connect db = new MaleFashion_Connect();
            l = db.DonHangs.Where(o => o.trangThai == false).OrderBy(o => o.ngayDat).Take(dh).ToList<DonHang>();
            return l;
        }
    }
}