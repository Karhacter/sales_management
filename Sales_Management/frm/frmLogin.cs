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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Length == 0)
                {
                    throw new Exception("Vui lòng nhập tên đăng nhập");
                }
                if (txtPassword.Text.Length < 5)
                {
                    throw new Exception("Mật khẩu ít nhất phải 5 ký tự");
                }
                string username = txtUsername.Text.Trim();
                string password = MaHoa.ToMD5(txtPassword.Text.Trim());
                ThanhVienDAO thanhVienDAO = new ThanhVienDAO();
                ThanhVien tv = thanhVienDAO.getRow(username);

                if (tv == null)
                {
                    lblThongBao.Text = "Tài khỏa không tồn tại";
                }
                else
                {
                    if (tv.MatKhau == password)
                    {
                        frmMain.thanhvien = tv;
                        this.Hide();
                        frmMain frm = new frmMain();
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        lblThongBao.Text = "Mật khẩu không chính xác";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                txtPassword.PasswordChar = '*';
            }
            else
            {
                txtPassword.PasswordChar = '\0';
            }
        }

        private void btnDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
        
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
