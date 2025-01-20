using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Management.models
{
    internal class DonHangSanPhamCT
    {
        public int MaCTDH { get; set; }
        public string MaDH { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set; }
        public string DonVT { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
