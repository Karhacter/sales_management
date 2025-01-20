using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Management.models;

namespace Sales_Management.DAO
{
    internal class LoaiSPDAO
    {
        QLBHDbContext db = null;
        public LoaiSPDAO()
        {
            db = new QLBHDbContext();
        }
        public List<LoaiSPThanhVien> getList()
        {
            List<LoaiSPThanhVien> list = db.LoaiSPs
                .Join(
                     db.ThanhViens,
                     loai => loai.MaTV,
                     tv => tv.MaTV,
                     (loai, tv) => new LoaiSPThanhVien
                     {
                         MaLoai = loai.MaLoai,
                         HoTen = tv.HoTen,
                         TenLoai = loai.TenLoai,
                         ChiTiet = loai.ChiTiet,
                     }
                ).ToList();
            return list;
        }
        public void insert(LoaiSP lsp)
        {
            try
            {
                db.LoaiSPs.Add(lsp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông báo");
            }
        }
        public void update(LoaiSP lsp)
        {
            try
            {
                db.Entry(lsp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        public void delete(LoaiSP lsp)
        {
            try
            {
                db.LoaiSPs.Remove(lsp);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");

            }
        }
        public LoaiSP getRow(int maloai)
        {
            LoaiSP lsp = db.LoaiSPs.Where(m => m.MaLoai == maloai).FirstOrDefault();
            return lsp;
        }
    }
}
