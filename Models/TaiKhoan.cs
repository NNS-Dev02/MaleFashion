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
    
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            this.BaiViets = new HashSet<BaiViet>();
            this.DonHangs = new HashSet<DonHang>();
            this.SanPhams = new HashSet<SanPham>();
        }
    
        public string taiKhoan1 { get; set; }
        public string matKhau { get; set; }
        public string hoDem { get; set; }
        public string tenTV { get; set; }
        public Nullable<System.DateTime> ngaysinh { get; set; }
        public string soDT { get; set; }
        public string email { get; set; }
        public string diaChi { get; set; }
        public string GroupID { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> ngayTao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
