using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaleFashion.Models
{
    public class CartShop
    {
        public string MaKH {get; set; }
        public string Taikhoan { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set; }
        public string DiaChi { get; set; }
        public SortedList<string, CtDonHang> SanPhamDC { get; set; }

        //--- Giá trị mặc định của CartShop ---//
        public CartShop()
        {
            this.MaKH = ""; this.Taikhoan = ""; 
            this.NgayDat = DateTime.Now; 
            this.NgayGiao = DateTime.Now.AddDays(2);
            this.DiaChi = "";
            this.SanPhamDC = new SortedList<string, CtDonHang>();
        }

        //--- Phương thức trả về true nếu không có sản phẩm nào đã chọn mua trong hệ thống ---//
        public bool IsEmpty()
        {
            return (SanPhamDC.Keys.Count == 0);
        }

        //--- Hàm "THÊM" 1 sản phẩm đã chọn mua vào giỏ hàng ---//
        public void addItem(string maSP)
        {
            if (SanPhamDC.Keys.Contains(maSP))
            {
                //--- Trỏ đến sản phẩm cần thay đổi số lượng mua có trong giỏ hàng ---//
                CtDonHang x = SanPhamDC.Values[SanPhamDC.IndexOfKey(maSP)];
                //--- Tăng số lượng lên 1 ---//
                x.soLuong++;
            }
            else
            {
                //--- Tạo 1 Object chi tiết đơn hàng mới ---//
                CtDonHang i = new CtDonHang();
                //--- Cập nhật thông tin hiện hành từ hệ thống cho đối tượng đó ---//
                i.maSP = maSP;
                i.soLuong = 1;
                //--- Lấy giá bán, và giảm giá từ Table SanPham ---//
                SanPham z = Common.getProductByID(maSP);
                i.giaBan = z.giaBan;
                //--- Bỏ danh sách các sản phẩm đã chọn mua vào giỏ hàng ---//
                SanPhamDC.Add(maSP, i);
            }
        }

        //--- Hàm "XÓA" 1 sản phẩm đã chọn mua vào giỏ hàng ---//
        public void deleteItem(string maSP)
        {
            if (SanPhamDC.Keys.Contains(maSP))
                SanPhamDC.Remove(maSP);
        }

        //--- Hàm "GIẢM SỐ LƯỢNG" 1 sản phẩm đã chọn mua vào giỏ hàng ---//
        public void decreaseItem(string maSP)
        {
            if (SanPhamDC.Keys.Contains(maSP))
            {
                //--- Trỏ đến sản phẩm cần thay đổi số lượng mua trong giỏ hàng ---//
                CtDonHang x = SanPhamDC.Values[SanPhamDC.IndexOfKey(maSP)];
                if (x.soLuong > 1)
                    x.soLuong--;
                else
                    deleteItem(maSP);
            }
        }

        //--- Hàm tính tiền của 1 sản phẩm ---//
        public long moneyOfOneItem(CtDonHang x)
        {
            return (long)(x.giaBan * x.soLuong);
        }

        //--- Hàm tính tiền của 1 sản phẩm được giao hàng (5000VNĐ = 1 Sản Phẩm) ---//
        public long moneyOfOneItemShip(CtDonHang x)
        {
            return (long)(x.soLuong * 5000);
        }

        //--- Hàm tính tổng tiền giao hàng tất cả sản phẩm ---//
        public long totalOfShip()
        {
            long kq = 0;
            foreach (CtDonHang i in SanPhamDC.Values)
                kq += moneyOfOneItemShip(i);
            return kq;
        }

        //--- Hàm tính tổng tiền cho giỏ hàng ---//
        public long totalOfCartShop()
        {
            long kq = 0;
            foreach (CtDonHang i in SanPhamDC.Values)
                kq += moneyOfOneItem(i);
            return kq;
        }
    }
}