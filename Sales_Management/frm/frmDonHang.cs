using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Management.DAO;
using Sales_Management.models;

namespace Sales_Management.frm
{
    public partial class frmDonHang : Form
    {
        DonHangDAO dhDAO = new DonHangDAO();
        private string AddOrEdit = "";
        public frmDonHang()
        {
            InitializeComponent();
        }

        private void frmDonHang_Load(object sender, EventArgs e)
        {
            loadDonHang();
            cbKieuDH.Items.Add("Nhập");
            cbKieuDH.Items.Add("Xuất");
            cbKieuDH.SelectedIndex = 0;
            OnOffControl(false);
        }
        private void loadDonHang()
        {
            dgvDonHang.DataSource = dhDAO.getList();
        }

        private void OnOffControl(bool status)
        {
            mtxtMaDH.Enabled = status;
            dtNgayDat.Enabled = status;
            dtNgayGiao.Enabled = status;
            txtGhiChu.Enabled = status;
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
                if (string.IsNullOrEmpty(mtxtMaDH.Text.Trim()))
                {
                    mtxtMaDH.Focus();
                    throw new Exception("Mã sản phẩm không được để trống");
                }
                if (string.IsNullOrEmpty(txtGhiChu.Text.Trim()))
                {
                    txtGhiChu.Focus();
                    throw new Exception("Tên sản phẩm không được để trống");
                }

                string madh = mtxtMaDH.Text.Trim();
                string kieudh = cbKieuDH.Text.Trim();
                string ngaydat = dtNgayDat.Text.Trim();
                string ngaygiao = dtNgayGiao.Text.Trim();
                string ghichu = txtGhiChu.Text.Trim();

                DateTime ngayDatParsed, ngayGiaoParsed;

                bool isNgayDatValid = DateTime.TryParse(ngaydat, out ngayDatParsed);
                bool isNgayGiaoValid = DateTime.TryParse(ngaygiao, out ngayGiaoParsed);

                if (!isNgayDatValid)
                {
                    MessageBox.Show("Ngày đặt không hợp lệ", "Thông báo");
                    dtNgayDat.Focus();
                    return;
                }

                if (!isNgayGiaoValid)
                {
                    MessageBox.Show("Ngày giao không hợp lệ", "Thông báo");
                    dtNgayGiao.Focus();
                    return;
                }
                switch (AddOrEdit)
                {
                    case "Add":
                        {
                            //Them
                            DonHang dh = new DonHang();
                            dh.MaDH = madh;
                            dh.MaTV = 1;
                            dh.NgayDat = ngayDatParsed;
                            dh.NgayGiao = ngayGiaoParsed;
                            dh.KieuDH = kieudh;
                            dh.GhiChu = ghichu;
                            dhDAO.insert(dh);
                            dgvDonHang.DataSource = dhDAO.getList();
                            MessageBox.Show("Thêm thành công", "Thông báo");
                            break;
                        }
                    case "Edit":
                        {
                            DonHang dh = dhDAO.getRow(madh);
                            //Cap nhat
                            dh.MaDH = madh;
                            dh.MaTV = 1;
                            dh.NgayDat = ngayDatParsed;
                            dh.NgayGiao = ngayGiaoParsed;
                            dh.KieuDH = kieudh;
                            dh.GhiChu = ghichu;
                            dhDAO.update(dh);
                            dgvDonHang.DataSource = dhDAO.getList();
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
            string madh = mtxtMaDH.Text.Trim();
            DonHang dh = dhDAO.getRow(madh);
            dhDAO.delete(dh);
            dgvDonHang.DataSource = dhDAO.getList();
            MessageBox.Show("Xóa thành công", "Thông báo");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            AddOrEdit = "Edit";
            OnOffControl(true);
            mtxtMaDH.Enabled = false;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string kieudh = Convert.ToString(cbKieuDH.SelectedItem);
            dgvDonHang.DataSource = dhDAO.getList(kieudh);
        }

        private void dgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDonHang.Rows.Count)
            {
                int vtchon = e.RowIndex;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                // 
                mtxtMaDH.Text = dgvDonHang.Rows[vtchon].Cells["MaDH"].Value.ToString();
                dtNgayDat.Text = dgvDonHang.Rows[vtchon].Cells["NgayDat"].Value.ToString();
                dtNgayGiao.Text = dgvDonHang.Rows[vtchon].Cells["NgayGiao"].Value.ToString();
                cbKieuDH.Text = dgvDonHang.Rows[vtchon].Cells["KieuDH"].Value.ToString();
                txtGhiChu.Text = dgvDonHang.Rows[vtchon].Cells["GhiChu"].Value.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbDonHang"]);
        }
    }
}
