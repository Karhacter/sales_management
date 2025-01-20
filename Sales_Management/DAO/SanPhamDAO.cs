using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales_Management.models;

namespace Sales_Management.DAO
{
    internal class SanPhamDAO
    {
        QLBHDbContext db = null;
        public SanPhamDAO()
        {
            db = new QLBHDbContext();
        }
        public List<SanPhamLoaiThanhVien> getList()
        {
            List<SanPhamLoaiThanhVien> list = db.SanPhams
            .Join(
                db.LoaiSPs,
                sp => sp.MaLoai,
                loai => loai.MaLoai,
                (sp, loai) => new { sp, loai })
            .Join(db.ThanhViens,
                combined => combined.sp.MaTV,
                tv => tv.MaTV,
                (combined, tv) => new SanPhamLoaiThanhVien
                {
                    MaSP = combined.sp.MaSP,
                    TenTV = tv.HoTen,
                    TenSP = combined.sp.TenSP,
                    DonVT = combined.sp.DonVT,
                    GiaMua = combined.sp.GiaMua,
                    GiaBan = combined.sp.GiaBan,
                    TenLoai = combined.loai.TenLoai,
                }).ToList();
            return list;
        }
        public List<SanPhamLoaiThanhVien> getList(int maloai)
        {
            List<SanPhamLoaiThanhVien> list = db.SanPhams.Where(sp=>sp.MaLoai == maloai)
               .Join(
               db.LoaiSPs,
               sp => sp.MaLoai,
               loai => loai.MaLoai,
               (sp, loai) => new { sp, loai }).Join(db.ThanhViens,
               combined => combined.sp.MaTV,
               tv => tv.MaTV,
               (combined, tv) => new SanPhamLoaiThanhVien
               {
                   MaSP = combined.sp.MaSP,
                   TenSP = combined.sp.TenSP,
                   DonVT = combined.sp.DonVT,
                   GiaMua = combined.sp.GiaMua,
                   GiaBan = combined.sp.GiaBan,
                   TenLoai = combined.loai.TenLoai,
                   TenTV = tv.HoTen,
               }).ToList();
            return list;
        }
        public bool insert(SanPham sp)
        {
            try
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool update(SanPham sp)
        {
            try
            {
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool delete(SanPham sp)
        {
            try
            {
                db.SanPhams.Remove(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public SanPham getRow(string masp)
        {
            SanPham sp = db.SanPhams.Where(m => m.MaSP == masp).FirstOrDefault();
            return sp;
        }
    }
}
