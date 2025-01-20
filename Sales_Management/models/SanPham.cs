namespace Sales_Management.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            DonHangChiTiets = new HashSet<DonHangChiTiet>();
        }

        [Key]
        [StringLength(20)]
        public string MaSP { get; set; }

        public int MaLoai { get; set; }

        public int MaTV { get; set; }

        [Required]
        [StringLength(220)]
        public string TenSP { get; set; }

        [Required]
        [StringLength(20)]
        public string DonVT { get; set; }

        public decimal? GiaMua { get; set; }

        public decimal? GiaBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }

        public virtual LoaiSP LoaiSP { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
