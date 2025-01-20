namespace Sales_Management
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuControlMain = new System.Windows.Forms.MenuStrip();
            this.quảnLýChiTiếtĐơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelTenDangNhap = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.thohastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýSảnPhẩmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLoạiSảnPhẩmToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýLoạiSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýThànhViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.menuControlMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 32);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(830, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuControlMain
            // 
            this.menuControlMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuControlMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.quảnLýSảnPhẩmToolStripMenuItem,
            this.quảnLýLoạiSảnPhẩmToolStripMenuItem,
            this.quảnLýChiTiếtĐơnHàngToolStripMenuItem,
            this.quảnLýThànhViênToolStripMenuItem,
            this.trợGiúpToolStripMenuItem});
            this.menuControlMain.Location = new System.Drawing.Point(0, 0);
            this.menuControlMain.Name = "menuControlMain";
            this.menuControlMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuControlMain.Size = new System.Drawing.Size(830, 32);
            this.menuControlMain.TabIndex = 1;
            this.menuControlMain.Text = "menuStrip1";
            // 
            // quảnLýChiTiếtĐơnHàngToolStripMenuItem
            // 
            this.quảnLýChiTiếtĐơnHàngToolStripMenuItem.Image = global::Sales_Management.Properties.Resources._1877745_200;
            this.quảnLýChiTiếtĐơnHàngToolStripMenuItem.Name = "quảnLýChiTiếtĐơnHàngToolStripMenuItem";
            this.quảnLýChiTiếtĐơnHàngToolStripMenuItem.Size = new System.Drawing.Size(229, 28);
            this.quảnLýChiTiếtĐơnHàngToolStripMenuItem.Text = "Quản Lý Chi  Tiết Đơn Hàng";
            this.quảnLýChiTiếtĐơnHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýChiTiếtĐơnHàngToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTenDangNhap});
            this.statusStrip1.Location = new System.Drawing.Point(0, 502);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(830, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelTenDangNhap
            // 
            this.toolStripStatusLabelTenDangNhap.Name = "toolStripStatusLabelTenDangNhap";
            this.toolStripStatusLabelTenDangNhap.Size = new System.Drawing.Size(68, 20);
            this.toolStripStatusLabelTenDangNhap.Text = "Xin Chào";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 63);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(830, 439);
            this.tabControlMain.TabIndex = 3;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinTàiKhoảnToolStripMenuItem,
            this.đổiMậtKhẩuToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem,
            this.toolStripSeparator1,
            this.thohastToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Image = global::Sales_Management.Properties.Resources.hethong;
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(109, 28);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông Tin Tài Khoản";
            this.thôngTinTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.thôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi Mật Khẩu";
            this.đổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // thohastToolStripMenuItem
            // 
            this.thohastToolStripMenuItem.Name = "thohastToolStripMenuItem";
            this.thohastToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.thohastToolStripMenuItem.Text = "Thoát";
            this.thohastToolStripMenuItem.Click += new System.EventHandler(this.thohastToolStripMenuItem_Click);
            // 
            // quảnLýSảnPhẩmToolStripMenuItem
            // 
            this.quảnLýSảnPhẩmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýSảnPhẩmToolStripMenuItem1,
            this.quảnLýLoạiSảnPhẩmToolStripMenuItem1});
            this.quảnLýSảnPhẩmToolStripMenuItem.Image = global::Sales_Management.Properties.Resources.product1;
            this.quảnLýSảnPhẩmToolStripMenuItem.Name = "quảnLýSảnPhẩmToolStripMenuItem";
            this.quảnLýSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(112, 28);
            this.quảnLýSảnPhẩmToolStripMenuItem.Text = "Sản Phẩm";
            // 
            // quảnLýSảnPhẩmToolStripMenuItem1
            // 
            this.quảnLýSảnPhẩmToolStripMenuItem1.Name = "quảnLýSảnPhẩmToolStripMenuItem1";
            this.quảnLýSảnPhẩmToolStripMenuItem1.Size = new System.Drawing.Size(245, 26);
            this.quảnLýSảnPhẩmToolStripMenuItem1.Text = "Quản Lý Sản Phẩm";
            this.quảnLýSảnPhẩmToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýSảnPhẩmToolStripMenuItem1_Click);
            // 
            // quảnLýLoạiSảnPhẩmToolStripMenuItem1
            // 
            this.quảnLýLoạiSảnPhẩmToolStripMenuItem1.Name = "quảnLýLoạiSảnPhẩmToolStripMenuItem1";
            this.quảnLýLoạiSảnPhẩmToolStripMenuItem1.Size = new System.Drawing.Size(245, 26);
            this.quảnLýLoạiSảnPhẩmToolStripMenuItem1.Text = "Quản Lý Loại Sản Phẩm";
            this.quảnLýLoạiSảnPhẩmToolStripMenuItem1.Click += new System.EventHandler(this.quảnLýLoạiSảnPhẩmToolStripMenuItem1_Click);
            // 
            // quảnLýLoạiSảnPhẩmToolStripMenuItem
            // 
            this.quảnLýLoạiSảnPhẩmToolStripMenuItem.Image = global::Sales_Management.Properties.Resources._101952_200;
            this.quảnLýLoạiSảnPhẩmToolStripMenuItem.Name = "quảnLýLoạiSảnPhẩmToolStripMenuItem";
            this.quảnLýLoạiSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(171, 28);
            this.quảnLýLoạiSảnPhẩmToolStripMenuItem.Text = "Quản Lý Đơn Hàng";
            this.quảnLýLoạiSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.quảnLýLoạiSảnPhẩmToolStripMenuItem_Click);
            // 
            // quảnLýThànhViênToolStripMenuItem
            // 
            this.quảnLýThànhViênToolStripMenuItem.Image = global::Sales_Management.Properties.Resources.thanhvien;
            this.quảnLýThànhViênToolStripMenuItem.Name = "quảnLýThànhViênToolStripMenuItem";
            this.quảnLýThànhViênToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.quảnLýThànhViênToolStripMenuItem.Text = "Quản Lý Thành Viên";
            this.quảnLýThànhViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýThànhViênToolStripMenuItem_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.Image = global::Sales_Management.Properties.Resources.trogiup;
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(103, 28);
            this.trợGiúpToolStripMenuItem.Text = "Trợ Giúp";
            this.trợGiúpToolStripMenuItem.Click += new System.EventHandler(this.trợGiúpToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(830, 528);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuControlMain);
            this.MainMenuStrip = this.menuControlMain;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Quản Lý Bán Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuControlMain.ResumeLayout(false);
            this.menuControlMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip menuControlMain;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem thohastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýSảnPhẩmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýLoạiSảnPhẩmToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýLoạiSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýThànhViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTenDangNhap;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýChiTiếtĐơnHàngToolStripMenuItem;
    }
}

