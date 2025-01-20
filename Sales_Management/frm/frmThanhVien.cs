using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Management.DAO;
using Sales_Management.models;

namespace Sales_Management.frm
{
    public partial class frmThanhVien : Form
    {
        ThanhVienDAO thanhvienDAO = new ThanhVienDAO();
        private string AddOrEdit = "";
        public frmThanhVien()
        {
            InitializeComponent();
            cbQuyen.Items.Add("admin");
            cbQuyen.Items.Add("customer");
            cbQuyen.SelectedItem = 0;
        }

        private void frmThanhVien_Load(object sender, EventArgs e)
        {
            dgvThanhVien.DataSource = thanhvienDAO.getList();
            OnOffControl(false);
        }
        private void OnOffControl(bool status)
        {
            mtxtMaTV.Enabled = false;
            txtTenDangNhap.Enabled = status;
            txtMatKhau.Enabled = status;
            txtHoTen.Enabled = status;
            txtEmail.Enabled = status;
            txtDienThoai.Enabled = status;
            cbQuyen.Enabled = status;
            btnLuu.Enabled = status;
            btnXoa.Enabled = status;
            btnSua.Enabled = status;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddOrEdit = "Add";
            OnOffControl(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            AddOrEdit = "Edit";
            OnOffControl(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenDangNhap.Text.Trim()))
                {
                    txtTenDangNhap.Focus();
                    throw new Exception("Tên đăng nhập không được để trống");
                }
                string tenDangNhap = txtTenDangNhap.Text.Trim();

                if (string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
                {
                    txtMatKhau.Focus();
                    throw new Exception("Mật khẩu không được để trống");
                }
                if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {
                    txtEmail.Focus();
                    throw new Exception("Email không được để trống");
                }
                string email = txtEmail.Text.Trim();
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(email, emailPattern))
                {
                    txtEmail.Focus();
                    throw new Exception("Địa chỉ email không hợp lệ");
                }
                if (string.IsNullOrEmpty(txtHoTen.Text.Trim()))
                {
                    txtHoTen.Focus();
                    throw new Exception("Họ tên không được để trống");
                }
                if (string.IsNullOrEmpty(txtDienThoai.Text.Trim()) || txtDienThoai.Text.Trim().Length != 10)
                {
                    txtDienThoai.Focus();
                    throw new Exception("Điện thoại không hợp lệ");
                }
                string tendangnhap = txtTenDangNhap.Text.Trim();
                string matkhau = txtMatKhau.Text.Trim();
                string hoten = txtHoTen.Text.Trim();
                string dienthoai = txtDienThoai.Text.Trim();
                string quyen = cbQuyen.SelectedItem.ToString();
                switch (AddOrEdit)
                {
                    case "Add":
                        {
                            ThanhVien tv = new ThanhVien();
                            tv.TenDangNhap = tendangnhap;
                            tv.MatKhau = matkhau;
                            tv.HoTen = hoten;
                            tv.Email = email;
                            tv.DienThoai = dienthoai;
                            tv.Quyen = quyen;
                            //Them
                            thanhvienDAO.insert(tv);
                            dgvThanhVien.DataSource = thanhvienDAO.getList();
                            MessageBox.Show("Thêm thành công", "Thông báo");
                            break;
                        }
                    case "Edit":
                        {
                            int matv = int.Parse(mtxtMaTV.Text.Trim());
                            ThanhVien tv = thanhvienDAO.getRow(matv);
                            tv.TenDangNhap = tendangnhap;
                            tv.MatKhau = matkhau;
                            tv.HoTen = hoten;
                            tv.Email = email;
                            tv.DienThoai = dienthoai;
                            tv.Quyen = quyen;
                            //Them
                            thanhvienDAO.update(tv);
                            dgvThanhVien.DataSource = thanhvienDAO.getList();
                            MessageBox.Show("Cập nhật thành công", "Thông báo");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int matv = int.Parse(mtxtMaTV.Text.Trim());
            ThanhVien tv = thanhvienDAO.getRow(matv);
            thanhvienDAO.delete(tv);
            dgvThanhVien.DataSource = thanhvienDAO.getList();
            MessageBox.Show("Xóa thành công", "Thông báo");
        }

        private void dgvThanhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvThanhVien.Rows.Count)
            {
                int vtchon = e.RowIndex;

                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                int matv = int.Parse(dgvThanhVien.Rows[vtchon].Cells["MaTV"].Value.ToString());
                mtxtMaTV.Text = dgvThanhVien.Rows[vtchon].Cells["MaTV"].Value.ToString();
                txtTenDangNhap.Text = dgvThanhVien.Rows[vtchon].Cells["TenDangNhap"].Value.ToString();
     
                txtEmail.Text = dgvThanhVien.Rows[vtchon].Cells["Email"].Value.ToString();
                txtHoTen.Text = dgvThanhVien.Rows[vtchon].Cells["HoTen"].Value.ToString();
                txtDienThoai.Text = dgvThanhVien.Rows[vtchon].Cells["DienThoai"].Value.ToString();
                cbQuyen.Text = dgvThanhVien.Rows[vtchon].Cells["Quyen"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbThanhVien"]);
        }
    }
}
