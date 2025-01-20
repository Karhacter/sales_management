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
    public partial class frmSanPham : Form
    {
        SanPhamDAO spDAO = new SanPhamDAO();
        LoaiSPDAO loDAO = new LoaiSPDAO();
        private string AddOrEdit = "";
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                int vtchon = e.RowIndex;
                if (vtchon >= 0 && vtchon < dgvSanPham.Rows.Count)
                {
                    btnXoa.Enabled = true;
                    btnSua.Enabled = true;
                    // 
                    mtxtMaSP.Text = dgvSanPham.Rows[vtchon].Cells["MaSP"].Value.ToString();
                    cbTenLoai.Text = dgvSanPham.Rows[vtchon].Cells["TenLoai"].Value.ToString();
                    txtTenSP.Text = dgvSanPham.Rows[vtchon].Cells["TenSP"].Value.ToString() ?? "";
                    cbDonVT.Text = dgvSanPham.Rows[vtchon].Cells["DonVT"].Value.ToString();
                    txtGiaMua.Text = dgvSanPham.Rows[vtchon].Cells["GiaMua"].Value.ToString();
                    txtGiaBan.Text = dgvSanPham.Rows[vtchon].Cells["GiaBan"].Value.ToString();
                }
        }
        private void loadSanPham()
        {
            dgvSanPham.DataSource = spDAO.getList();
        }

        private void loadLoaiSP()
        {
            cbTenLoai.DataSource = loDAO.getList();
            cbTenLoai.ValueMember = "MaLoai";
            cbTenLoai.DisplayMember = "TenLoai";
        }

        private void OnOffControl(bool status)
        {
            mtxtMaSP.Enabled = status;
            txtTenSP.Enabled = status;
            cbDonVT.Enabled = status;
            txtGiaMua.Enabled = status;
            txtGiaBan.Enabled = status;
            btnLuu.Enabled = status;
            btnXoa.Enabled = status;
            btnSua.Enabled = status;
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            loadSanPham();
            loadLoaiSP();
            OnOffControl(false);
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
            mtxtMaSP.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                decimal giamua = 0;
                decimal giaban = 0;
                if (string.IsNullOrEmpty(mtxtMaSP.Text.Trim()))
                {
                    mtxtMaSP.Focus();
                    throw new Exception("Mã sản phẩm không được để trống");
                }
                if (string.IsNullOrEmpty(txtTenSP.Text.Trim()))
                {
                    txtTenSP.Focus();
                    throw new Exception("Tên sản phẩm không được để trống");
                }
                if (!decimal.TryParse(txtGiaBan.Text.Trim(), out giaban) || !decimal.TryParse(txtGiaMua.Text.Trim(), out giamua))
                {
                    throw new Exception("Giá bán và giá mua phải là số hợp lệ.");
                }

                string masp = mtxtMaSP.Text.Trim();
                int maloai = Convert.ToInt16(cbTenLoai.SelectedValue);
                string tensp = txtTenSP.Text.Trim();
                string donvt = cbDonVT.SelectedValue.ToString();
                switch (AddOrEdit)
                {
                    case "Add":
                        {
                            //Them
                            SanPham sp = new SanPham();
                            sp.MaSP = masp;
                            sp.MaLoai = maloai;
                            sp.MaTV = 1;
                            sp.TenSP = tensp;
                            sp.DonVT = donvt;
                            sp.GiaMua = giamua;
                            sp.GiaBan = giaban;
                            spDAO.insert(sp);
                            dgvSanPham.DataSource = spDAO.getList();
                            MessageBox.Show("Thêm thành công", "Thông báo");
                            break;
                        }
                    case "Edit":
                        {
                            //Cap nhat
                            SanPham sp = spDAO.getRow(masp);
                            sp.MaSP = masp;
                            sp.MaLoai = maloai;
                            sp.MaTV = 1;
                            sp.TenSP = tensp;
                            sp.DonVT = donvt;
                            sp.GiaMua = giamua;
                            sp.GiaBan = giaban;
                            spDAO.update(sp);
                            dgvSanPham.DataSource = spDAO.getList();
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
            string masp = mtxtMaSP.Text.Trim();
            SanPham sp = spDAO.getRow(masp);
            spDAO.delete(sp);
            dgvSanPham.DataSource = spDAO.getList();
            MessageBox.Show("Xóa thành công", "Thông báo");
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            int loaisp = Convert.ToInt16(cbTenLoai.SelectedValue);
            dgvSanPham.DataSource = spDAO.getList(loaisp);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbSanPham"]);
        }
    }
}
