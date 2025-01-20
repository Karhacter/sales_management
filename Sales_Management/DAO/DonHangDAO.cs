using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Management.models;

namespace Sales_Management.DAO
{
    internal class DonHangDAO
    {
        QLBHDbContext db = null;
        public DonHangDAO()
        {
            db = new QLBHDbContext();
        }
        public List<DonHangTV> getList()
        {
            List<DonHangTV> list = db.DonHangs
               .Join(
               db.ThanhViens,
               dh => dh.MaTV,
               tv => tv.MaTV,
               (dh,tv) => new DonHangTV
               {
                   MaDH = dh.MaDH,
                   HoTen = tv.HoTen,
                   NgayDat = dh.NgayDat,
                   NgayGiao = dh.NgayGiao,
                   KieuDH = dh.KieuDH,
                   GhiChu = dh.GhiChu
               }).ToList();
            return list;
        }

        public List<DonHangTV> getList(string kieudh)
        {
            List<DonHangTV> list = db.DonHangs.Where(dh=>dh.KieuDH == kieudh)
               .Join(
               db.ThanhViens,
               dh => dh.MaTV,
               tv => tv.MaTV,
               (dh, tv) => new DonHangTV
               {
                   MaDH = dh.MaDH,
                   HoTen = tv.HoTen,
                   NgayDat = dh.NgayDat,
                   NgayGiao = dh.NgayGiao,
                   KieuDH = dh.KieuDH,
                   GhiChu = dh.GhiChu
               }).ToList();
            return list;
        }
        public void insert(DonHang dh)
        {
            try
            {
                db.DonHangs.Add(dh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        public void update(DonHang dh)
        {
            try
            {
                db.Entry(db).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        public void delete(DonHang dh)
        {
            try
            {
                db.DonHangs.Remove(dh);
                db.SaveChanges();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        public DonHang getRow(string madh)
        {
            DonHang dh = db.DonHangs.Where(m => m.MaDH == madh).FirstOrDefault();
            return dh;
        }
        public List<DonHangSanPhamCT> getDonHang(string maDH)
        {
            var list = db.DonHangChiTiets
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
                        TenSP = combined.sp.TenSP,
                        NgayDat = dh.NgayDat,
                        NgayGiao = dh.NgayGiao,
                        DonVT = combined.dhct.DonVT,
                        DonGia = combined.dhct.DonGia,
                        SoLuong = combined.dhct.SoLuong,
                        ThanhTien = combined.dhct.ThanhTien
                    })
                .Where(dh => dh.MaDH == maDH)
                .ToList();

            return list;
        }
    }
}
