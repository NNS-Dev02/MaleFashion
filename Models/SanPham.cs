//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaleFashion.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.CtDonHangs = new HashSet<CtDonHang>();
        }
    
        public string maSP { get; set; }
        public string tenSP { get; set; }
        public string hinhDD { get; set; }
        public string ndTomTat { get; set; }
        public Nullable<System.DateTime> ngayDang { get; set; }
        public int maLoai { get; set; }
        public string taiKhoan { get; set; }
        public string dvt { get; set; }
        public Nullable<int> giaBan { get; set; }
        public string nhaSanXuat { get; set; }
        public Nullable<int> soLanXem { get; set; }
        public Nullable<bool> duyetSanPham { get; set; }
        public string NoiDung { get; set; }
        public Nullable<int> giaGoc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CtDonHang> CtDonHangs { get; set; }
        public virtual LoaiSP LoaiSP { get; set; }
        public virtual TaiKhoan TaiKhoan1 { get; set; }
    }
}