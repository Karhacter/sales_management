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
    public partial class frmDonHangCT : Form
    {
        DonHangCTDAO dhctDAO = new DonHangCTDAO();
        DonHangDAO dhDAO = new DonHangDAO();
        SanPhamDAO spDAO = new SanPhamDAO();

        private string AddOrEdit = "";
        public frmDonHangCT()
        {
            InitializeComponent();
        }

        private void frmDonHangCT_Load(object sender, EventArgs e)
        {
            loadDonHangCT();
            loadMaDH();
            load();
            cbDonVT.Items.Add("Cái");
            cbDonVT.Items.Add("Quyển");
            cbDonVT.SelectedIndex = -1;
            OnOffControl(false);
        }
        private void loadMaDH()
        {
            cbMaDH.DataSource = dhDAO.getList();
            cbMaDH.ValueMember = "MaDH"; 
            cbMaDH.DisplayMember = "MaDH"; 
            cbMaDH.SelectedIndex = -1; 
        }

        private void load()
        {
            var listsanpham = spDAO.getList();
            cbMaSP.DataSource = listsanpham;
            cbMaSP.ValueMember = "MaSP";
            cbMaSP.DisplayMember = "MaSP";
        }

        private void updateDonGia(string maDH)
        {
            if (cbMaDH.Items.Count > 0 && cbMaSP.Items.Count > 0)
            {            
                string firstMaDH = cbMaDH.SelectedValue?.ToString();
                string firstMaSP = cbMaSP.SelectedValue?.ToString();

                if (!string.IsNullOrEmpty(firstMaDH) && !string.IsNullOrEmpty(firstMaSP))
                {      
                    var donHang = dhDAO.getRow(firstMaDH); 
                    if (donHang != null)
                    {
                        string kieuDH = donHang.KieuDH;             
                        var sanPham = spDAO.getRow(firstMaSP); 
                        if (sanPham != null)
                        {
                            decimal donGia = 0;
                            decimal giaBan = Convert.ToDecimal(sanPham.GiaBan);  
                            decimal giaMua = Convert.ToDecimal(sanPham.GiaMua); 
                            if (kieuDH == "Xuất")
                            {
                                donGia = giaBan; 
                            }
                            else if (kieuDH == "Nhập")
                            {
                                donGia = giaMua; 
                            }
                            txtDonGia.Text = donGia.ToString("N0");
                        }
                    }
                }
            }
        }


        private void loadDonHangCT()
        {
            dgvDonHangCT.DataSource = dhctDAO.getList();
        }
        private void OnOffControl(bool status)
        {
            txtSoLuong.Enabled = status;
            txtDonGia.Enabled = false;
            cbDonVT.Enabled = status;
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
            mtxtMaCTDH.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || !int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
                {
                    throw new Exception("Số lượng phải là một số nguyên lớn hơn 0.");
                }

                if (string.IsNullOrWhiteSpace(txtDonGia.Text) || !decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia))
                {
                    throw new Exception("Đơn giá phải là một số hợp lệ.");
                }

                string madh = cbMaDH.SelectedValue.ToString();
                string masp = cbMaSP.SelectedValue.ToString();
                string donvt = cbDonVT.SelectedItem.ToString();
                decimal thanhtien = donGia * soLuong;
                switch (AddOrEdit)
                {
                    case "Add":
                        {
                            //Them 
                            DonHangChiTiet dhct = new DonHangChiTiet();
                            dhct.MaDH = madh;
                            dhct.MaSP = masp;
                            dhct.DonVT = donvt;
                            dhct.DonGia = donGia;
                            dhct.ThanhTien = thanhtien;
                            dhctDAO.insert(dhct);
                            dgvDonHangCT.DataSource = dhctDAO.getList();
                            MessageBox.Show("Thêm thành công", "Thông báo");
                            break;
                        }
                    case "Edit":
                        {
                            //Cap nhat
                            int mactdh = Convert.ToInt16(mtxtMaCTDH.Text.Trim());
                            DonHangChiTiet dhct = dhctDAO.getRow(mactdh);
                            dhct.MaDH = madh;
                            dhct.MaSP = masp;
                            dhct.DonVT = donvt;
                            dhct.DonGia = donGia;
                            dhct.ThanhTien = thanhtien;
                            dhctDAO.insert(dhct);
                            dgvDonHangCT.DataSource = dhctDAO.getList();
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

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string madh = cbMaDH.SelectedValue.ToString();
            dgvDonHangCT.DataSource = dhctDAO.getList(madh);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int mactdh = Convert.ToInt16(mtxtMaCTDH.Text.Trim());
            DonHangChiTiet dhct = dhctDAO.getRow(mactdh);
            dhctDAO.delete(dhct);
            loadDonHangCT();
            MessageBox.Show("Xóa thành công", "Thông báo");
        }

        private void dgvDonHangCT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDonHangCT.Rows.Count)
            {
                int vtchon = e.RowIndex;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                // 
                mtxtMaCTDH.Text = dgvDonHangCT.Rows[vtchon].Cells["MaCTDH"].Value.ToString();
                cbMaDH.Text = dgvDonHangCT.Rows[vtchon].Cells["MaDH"].Value.ToString();
                cbMaSP.Text = dgvDonHangCT.Rows[vtchon].Cells["MaSP"].Value.ToString();
                cbDonVT.Text = dgvDonHangCT.Rows[vtchon].Cells["DonVT"].Value.ToString();
                txtSoLuong.Text = dgvDonHangCT.Rows[vtchon].Cells["SoLuong"].Value.ToString();
                txtDonGia.Text = dgvDonHangCT.Rows[vtchon].Cells["DonGia"].Value.ToString();
            }
        }

        private void cbMaDH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaDH.SelectedValue != null && cbMaDH.SelectedValue.ToString() != "")
            {
                string madh = cbMaDH.SelectedValue.ToString(); 
                Console.WriteLine("Selected MaDH: " + madh); 

                updateDonGia(madh);
            }
            else
            {
                txtDonGia.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbDonHangCT"]);
        }
    }
}
