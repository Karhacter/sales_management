using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales_Management.models;

namespace Sales_Management.DAO
{
    internal class DonHangCTDAO
    {
        QLBHDbContext db = null;
        public DonHangCTDAO()
        {
            db = new QLBHDbContext();
        }
        public List<DonHangSanPhamCT> getList()
        {
            List<DonHangSanPhamCT> list = db.DonHangChiTiets
                .Join(db.SanPhams,
                   dhct => dhct.MaSP,
                   sp => sp.MaSP,
                   (dhct, sp) => new { dhct, sp })
                .Join(db.DonHangs,
                    combined => combined.dhct.MaDH,
                    dh => dh.MaDH,
                 (combined, dh) => new DonHangSanPhamCT
                 { 
                     MaCTDH = combined.dhct.MaCTDH,
                     MaDH = combined.dhct.MaDH,
                     MaSP = combined.dhct.MaSP,
                     TenSP = combined.sp.TenSP,
                     NgayDat = dh.NgayDat,
                     NgayGiao = dh.NgayGiao,
                     DonVT = combined.dhct.DonVT,
                     DonGia = combined.dhct.DonGia,
                     SoLuong = combined.dhct.SoLuong,
                     ThanhTien = combined.dhct.ThanhTien
                 }).ToList();
            return list;
        }
        public List<DonHangSanPhamCT> getList(string madh)
        {
            List<DonHangSanPhamCT> list = db.DonHangChiTiets
                .Join(db.SanPhams,
                   dhct => dhct.MaSP,
                   sp => sp.MaSP,
                   (dhct, sp) => new { dhct, sp })
                .Join(db.DonHangs,
                    combined => combined.dhct.MaDH,
                    dh => dh.MaDH,
                 (combined, dh) => new DonHangSanPhamCT
                 {
                     MaCTDH = combined.dhct.MaCTDH,
                     MaDH = combined.dhct.MaDH,
                     MaSP = combined.dhct.MaSP,
                     TenSP = combined.sp.TenSP,
                     NgayDat = dh.NgayDat,
                     NgayGiao = dh.NgayGiao,
                     DonVT = combined.dhct.DonVT,
                     DonGia = combined.dhct.DonGia,
                     SoLuong = combined.dhct.SoLuong,
                     ThanhTien = combined.dhct.ThanhTien
                 }).Where(dh=>dh.MaDH == madh).ToList();
            return list;
        }
        public void insert(DonHangChiTiet dhct)
        {
            db.DonHangChiTiets.Add(dhct);
            db.SaveChanges();
        }
        public void update(DonHangChiTiet dhct)
        {
            db.Entry(dhct).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void delete(DonHangChiTiet dhct)
        {
            db.DonHangChiTiets.Remove(dhct);
            db.SaveChanges();
        }
        public DonHangChiTiet getRow(int mactdh) {
            DonHangChiTiet dhct = db.DonHangChiTiets.Where(m=>m.MaCTDH == mactdh).FirstOrDefault();
            return dhct;
        }
    }
}
