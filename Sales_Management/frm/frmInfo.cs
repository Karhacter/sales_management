using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Management.models;

namespace Sales_Management.frm
{
    public partial class frmInfo : Form
    {
        public frmInfo()
        {
            InitializeComponent();
        }

        private void frmInfo_Load(object sender, EventArgs e)
        {
            ThanhVien thanhvien = frmMain.thanhvien;
            txtTenDangNhap.Text = thanhvien.TenDangNhap;
            txtMatKhau.Text = thanhvien.MatKhau;
            txtHoTen.Text = thanhvien.HoTen;
            txtEmail.Text = thanhvien.Email;
            txtDienThoai.Text = thanhvien.DienThoai;
            cbQuyen.Text = thanhvien.Quyen;
            OffControl();
        }
        private void OffControl()
        {
            txtTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = false;
            txtHoTen.Enabled = false;
            txtEmail.Enabled = false;
            txtDienThoai.Enabled = false;
            cbQuyen.Enabled = false;
        }
        private bool ExistTabPage(TabControl control, string tabPageName)
        {
            bool check = false;
            for (int i = 0; i < control.TabPages.Count; i++)
            {
                if (control.TabPages[i].Name == tabPageName)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbThongTin"]);
            TabPage tab = new TabPage();
            tab.Text = "Đổi mật khẩu";
            tab.Name = "tbDoiMatKhau";
            tab.ImageIndex = 3;

            Form frm = new frmChangePass();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            if (!ExistTabPage(frmMain.tabControl, "tbDoiMatKhau"))
            {
                frmMain.tabControl.TabPages.Add(tab);
            }
            frmMain.tabControl.SelectedTab = frmMain.tabControl.TabPages["tbDoiMatKhau"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMain.tabControl.TabPages.Remove(frmMain.tabControl.TabPages["tbThongTin_"]);
        }
    }
}
