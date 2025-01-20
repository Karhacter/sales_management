using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Management.DAO;
using Sales_Management.models;

namespace Sales_Management.frm
{
    public partial class frmChangePass : Form
    {
        public frmChangePass()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                ThanhVien thanhvien = frmMain.thanhvien;
                string matkhaucu = MaHoa.ToMD5(txtMatKhauCu.Text.Trim());
                if (!thanhvien.MatKhau.Equals(matkhaucu))
                {
                    throw new Exception("Mật khẩu cũ không chính xác");
                }
                if (!txtMatKhau.Text.Trim().Equals(txtXacNhanMK.Text.Trim()))
                {
                    throw new Exception("Mật khẩu mới không khớp");
                }
                string matkhau = MaHoa.ToMD5(txtMatKhau.Text.Trim());
                thanhvien.MatKhau = matkhau;
                ThanhVienDAO tvDAO = new ThanhVienDAO();
                tvDAO.update(thanhvien);
                MessageBox.Show("Đổi mật khẩu thành công");
                frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbDoiMatKhau"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
    }
}
