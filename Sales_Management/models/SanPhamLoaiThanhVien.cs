using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Management.models
{
    internal class SanPhamLoaiThanhVien
    {
        public string MaSP { get; set; }

        public string TenLoai { get; set; }

        public string TenTV { get; set; }
        public string TenSP { get; set; }
        public string DonVT { get; set; }

        public decimal? GiaMua { get; set; }

        public decimal? GiaBan { get; set; }
    }
}
