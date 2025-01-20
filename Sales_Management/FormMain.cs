using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Management.frm;
using Sales_Management.models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sales_Management
{
    public partial class frmMain : Form
    {

        public static ThanhVien thanhvien = null;
        public static TabControl tabControl = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            while (thanhvien == null)
            {
                Form frm = new frmLogin();
                frm.ShowDialog();
                if (thanhvien == null)
                {
                    MessageBox.Show("Bạn cần đăng nhập để tiếp tục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            toolStripStatusLabelTenDangNhap.Text = "Xin chào: " + thanhvien.HoTen;
            formWelcome();

            tabControlMain.ImageList = LoadImageList();
            tabControl = tabControlMain;
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
        private void formWelcome()
        {
            TabPage tb = new TabPage();
            tb.Text = "Welcome";
            tb.Name = "tbWelcome";
            tb.ImageIndex = 0;

            Form frm = new frmWelcome();
            frm.TopLevel = false;
            frm.Parent = tb;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tb.Controls.Add(frm);

            if (!ExistTabPage(tabControlMain, "tbWelcome"))
            {
                tabControlMain.TabPages.Add(tb);
            }

            // Select the "Welcome" tab after login
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbWelcome"];
        }
        private ImageList LoadImageList()
        {
            ImageList iconlist = new ImageList();
            iconlist.TransparentColor = Color.Blue;
            iconlist.ColorDepth = ColorDepth.Depth32Bit;
            iconlist.ImageSize = new Size(25, 25);
            iconlist.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resource\\hethong.png"));
            iconlist.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resource\\thanhvien.png"));
            iconlist.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resource\\trogiup.png"));
            iconlist.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resource\\product.png"));
            iconlist.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resource\\order.png"));
            iconlist.Images.Add(Image.FromFile(Directory.GetCurrentDirectory() + "\\Resource\\orderdetail.png"));
            return iconlist;
        }

        private void quảnLýSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Sản phẩm";
            tab.Name = "tbSanPham";
            tab.ImageIndex = 3;
            //
            Form frm = new frmSanPham();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);

            //
            if (!ExistTabPage(tabControlMain, "tbSanPham"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbSanPham"];
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Trợ Giúp";
            tab.Name = "tbTroGiup";
            tab.ImageIndex = 2;
            //
            Form frm = new frmHelp();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);

            //
            if (!ExistTabPage(tabControlMain, "tbTroGiup"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbTroGiup"];
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Thông tin";
            tab.Name = "tbThongTin";
            tab.ImageIndex = 0;
            //
            Form frm = new frmInfo();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tab.Controls.Add(frm);

            //
            if (!ExistTabPage(tabControlMain, "tbThongTin"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbThongTin"];
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Đổi mật khẩu";
            tab.Name = "tbDoiMatKhau";
            tab.ImageIndex = 0;

            Form frm = new frmChangePass();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            if (!ExistTabPage(tabControlMain, "tbDoiMatKhau"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbDoiMatKhau"];
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain.thanhvien = null;
            this.Hide();
            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();
            if (frmMain.thanhvien != null)
            {
            }
            else
            {
                this.Close();
            }
        }

        private void thohastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void quảnLýLoạiSảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Loại Sản Phẩm";
            tab.Name = "tbLoaiSp";
            tab.ImageIndex = 3;

            Form frm = new frmLoaiSP();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            if (!ExistTabPage(tabControlMain, "tbLoaiSp"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbLoaiSp"];
        }

        private void quảnLýLoạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Đơn Hàng";
            tab.Name = "tbDonHang";
            tab.ImageIndex = 4;

            Form frm = new frmDonHang();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            if (!ExistTabPage(tabControlMain, "tbDonHang"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbDonHang"];
        }

        private void quảnLýChiTiếtĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Chi Tiết Đơn Hàng";
            tab.Name = "tbDonHangCT";
            tab.ImageIndex = 5;

            Form frm = new frmDonHangCT();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            if (!ExistTabPage(tabControlMain, "tbDonHangCT"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbDonHangCT"];
        }

        private void quảnLýThànhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tab = new TabPage();
            tab.Text = "Thành Viên";
            tab.Name = "tbThanhVien";
            tab.ImageIndex = 1;

            Form frm = new frmThanhVien();
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            if (!ExistTabPage(tabControlMain, "tbThanhVien"))
            {
                tabControlMain.TabPages.Add(tab);
            }
            tabControlMain.SelectedTab = tabControlMain.TabPages["tbThanhVien"];
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
