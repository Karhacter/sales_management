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
    public partial class frmLoaiSP : Form
    {
        LoaiSPDAO loDAO = new LoaiSPDAO();
        private string AddOrEdit = "";
        public frmLoaiSP()
        {
            InitializeComponent();
        }

        private void frmLoaiSP_Load(object sender, EventArgs e)
        {
            loadLoai();
            OnOffControl(false);
        }
        private void loadLoai()
        {
            dgvLoaiSP.DataSource = loDAO.getList();
        }
        private void OnOffControl(bool status)
        {
            mtxtMaLoai.Enabled = false;
            txtTenLoai.Enabled = status;
            txtChiTiet.Enabled = status;
            btnLuu.Enabled = status;
            btnXoa.Enabled = status;
            btnSua.Enabled = status;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            AddOrEdit = "Add";
            OnOffControl(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenLoai.Text.Trim()))
                {
                    txtTenLoai.Focus();
                    throw new Exception("Tên loại không được để trống");
                }
                if (string.IsNullOrEmpty(txtChiTiet.Text.Trim()))
                {
                    txtChiTiet.Focus();
                    throw new Exception("Chi tiết không được để trống");
                }
                string tenloai = txtTenLoai.Text.Trim();
                string chitiet = txtChiTiet.Text.Trim();
                switch (AddOrEdit)
                {
                    case "Add":
                        {
                            LoaiSP lsp = new LoaiSP();
                            lsp.MaTV = 1;
                            lsp.TenLoai = tenloai;
                            lsp.ChiTiet = chitiet;
                            loDAO.insert(lsp);
                            dgvLoaiSP.DataSource = loDAO.getList();
                            MessageBox.Show("Thêm thành công", "Thông báo");
                            break;
                        }
                    case "Edit":
                        {
                            //Them
                            int maloai = Convert.ToInt16(mtxtMaLoai.Text.Trim());
                            LoaiSP lsp = loDAO.getRow(maloai);
                            lsp.MaTV = 1;
                            lsp.TenLoai = tenloai;
                            lsp.ChiTiet = chitiet;
                            loDAO.update(lsp);
                            dgvLoaiSP.DataSource = loDAO.getList();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            AddOrEdit = "Edit";
            OnOffControl(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maloai = Convert.ToInt16(mtxtMaLoai.Text.Trim());
            LoaiSP lsp = loDAO.getRow(maloai);
            loDAO.delete(lsp);
            loadLoai();
            MessageBox.Show("Xóa thành công", "Thông báo");
        }

        private void dgvLoaiSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvLoaiSP.Rows.Count)
            {
                int vtchon = e.RowIndex;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                // 
                mtxtMaLoai.Text = dgvLoaiSP.Rows[vtchon].Cells["MaLoai"].Value.ToString();
                txtTenLoai.Text = dgvLoaiSP.Rows[vtchon].Cells["TenLoai"].Value.ToString();
                txtChiTiet.Text = dgvLoaiSP.Rows[vtchon].Cells["ChiTiet"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbLoaiSP"]);
        }
    }
}
