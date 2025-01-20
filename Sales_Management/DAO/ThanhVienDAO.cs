using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Management.models;

namespace Sales_Management.DAO
{
    internal class ThanhVienDAO
    {
        QLBHDbContext db = null;
        public ThanhVienDAO()
        {
            db = new QLBHDbContext();
        }
        public List<dynamic> getList()
        {
            var list = db.ThanhViens
                         .Select(tv => new
                         {
                             tv.MaTV,
                             tv.TenDangNhap,
                             tv.HoTen,
                             tv.Email,
                             tv.DienThoai,
                             tv.Quyen
                         })
                         .ToList<dynamic>();

            return list;
        }
        public void insert(ThanhVien tv)
        {
            try
            {
                db.ThanhViens.Add(tv);
                db.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                 MessageBox.Show(ex.Message, "Thong bao");
            }
        }
        public bool update(ThanhVien tv)
        {
            try
            {
                var existingEntity = db.ThanhViens.FirstOrDefault(t => t.MaTV == tv.MaTV);

                if (existingEntity != null)
                {
                    db.Entry(existingEntity).CurrentValues.SetValues(tv);
                }
                else
                {
                    db.ThanhViens.Attach(tv);
                    db.Entry(tv).State = EntityState.Modified;
                }

                int affectedRows = db.SaveChanges();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating entity: " + ex.Message);
                return false;
            }
        }
        public void delete(ThanhVien tv)
        {
            try
            {
                db.ThanhViens.Remove(tv);
                db.SaveChanges();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thong bao");
            }
        }
        public ThanhVien getRow(string tendangnhap)
        {
            ThanhVien thanhvien = db.ThanhViens.Where(m => m.Quyen == "Admin" && (m.TenDangNhap == tendangnhap)).FirstOrDefault();
            return thanhvien;
        }
        public ThanhVien getRow(int matv)
        {
            ThanhVien thanhvien = db.ThanhViens.Where(m => m.MaTV == matv).FirstOrDefault();
            return thanhvien;
        }
    }
}
