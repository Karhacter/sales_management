namespace Sales_Management.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            DonHangChiTiets = new HashSet<DonHangChiTiet>();
        }

        [Key]
        [StringLength(20)]
        public string MaDH { get; set; }

        public int MaTV { get; set; }

        public DateTime NgayDat { get; set; }

        public DateTime NgayGiao { get; set; }

        [Required]
        [StringLength(255)]
        public string KieuDH { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
    }
}
