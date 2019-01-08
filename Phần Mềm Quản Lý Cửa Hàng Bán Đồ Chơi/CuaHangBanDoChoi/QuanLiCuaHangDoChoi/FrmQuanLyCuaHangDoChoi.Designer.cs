namespace QuanLiCuaHangDoChoi
{
    partial class FrmCuaHangDoChoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCuaHangDoChoi));
            this.openToolStripMenuItem = new System.Windows.Forms.OpenFileDialog();
            this.menuQuanLy = new System.Windows.Forms.MenuStrip();
            this.tổngQuanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàSảnXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nghiệpVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bánHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hjhjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLy.SuspendLayout();
            this.SuspendLayout();
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.FileName = "openFileDialog1";
            // 
            // menuQuanLy
            // 
            this.menuQuanLy.AutoSize = false;
            this.menuQuanLy.BackColor = System.Drawing.Color.PaleTurquoise;
            this.menuQuanLy.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuQuanLy.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuQuanLy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tổngQuanToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.nghiệpVụToolStripMenuItem,
            this.hóaĐơnToolStripMenuItem,
            this.hjhjToolStripMenuItem});
            this.menuQuanLy.Location = new System.Drawing.Point(0, 0);
            this.menuQuanLy.Name = "menuQuanLy";
            this.menuQuanLy.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuQuanLy.Size = new System.Drawing.Size(1387, 46);
            this.menuQuanLy.TabIndex = 0;
            this.menuQuanLy.Text = "menuStrip1";
            this.menuQuanLy.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuQuanLy_ItemClicked);
            // 
            // tổngQuanToolStripMenuItem
            // 
            this.tổngQuanToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.tổngQuanToolStripMenuItem.Image = global::QuanLiCuaHangDoChoi.Properties.Resources.home;
            this.tổngQuanToolStripMenuItem.Name = "tổngQuanToolStripMenuItem";
            this.tổngQuanToolStripMenuItem.Size = new System.Drawing.Size(186, 42);
            this.tổngQuanToolStripMenuItem.Text = "Tổng quan";
            this.tổngQuanToolStripMenuItem.Click += new System.EventHandler(this.tổngQuanToolStripMenuItem_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tàiKhoảnToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.tàiKhoảnToolStripMenuItem.Image = global::QuanLiCuaHangDoChoi.Properties.Resources.user_account_box;
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(203, 42);
            this.tàiKhoảnToolStripMenuItem.Text = "Người dùng";
            this.tàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.tàiKhoảnToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tàiKhoảnToolStripMenuItem1,
            this.sảnPhẩmToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.nhàSảnXuấtToolStripMenuItem,
            this.hóaĐơnToolStripMenuItem1});
            this.quảnLýToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.quảnLýToolStripMenuItem.Image = global::QuanLiCuaHangDoChoi.Properties.Resources.management;
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(146, 42);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // tàiKhoảnToolStripMenuItem1
            // 
            this.tàiKhoảnToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("tàiKhoảnToolStripMenuItem1.Image")));
            this.tàiKhoảnToolStripMenuItem1.Name = "tàiKhoảnToolStripMenuItem1";
            this.tàiKhoảnToolStripMenuItem1.Size = new System.Drawing.Size(266, 42);
            this.tàiKhoảnToolStripMenuItem1.Text = "Tài khoản";
            this.tàiKhoảnToolStripMenuItem1.Click += new System.EventHandler(this.tàiKhoảnToolStripMenuItem1_Click);
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            this.sảnPhẩmToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sảnPhẩmToolStripMenuItem.Image")));
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(266, 42);
            this.sảnPhẩmToolStripMenuItem.Text = "Sản phẩm";
            this.sảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.sảnPhẩmToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kháchHàngToolStripMenuItem.Image")));
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(266, 42);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // nhàSảnXuấtToolStripMenuItem
            // 
            this.nhàSảnXuấtToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nhàSảnXuấtToolStripMenuItem.Image")));
            this.nhàSảnXuấtToolStripMenuItem.Name = "nhàSảnXuấtToolStripMenuItem";
            this.nhàSảnXuấtToolStripMenuItem.Size = new System.Drawing.Size(266, 42);
            this.nhàSảnXuấtToolStripMenuItem.Text = "Nhà sản xuất";
            this.nhàSảnXuấtToolStripMenuItem.Click += new System.EventHandler(this.nhàSảnXuấtToolStripMenuItem_Click);
            // 
            // hóaĐơnToolStripMenuItem1
            // 
            this.hóaĐơnToolStripMenuItem1.Image = global::QuanLiCuaHangDoChoi.Properties.Resources.shopping_list;
            this.hóaĐơnToolStripMenuItem1.Name = "hóaĐơnToolStripMenuItem1";
            this.hóaĐơnToolStripMenuItem1.Size = new System.Drawing.Size(266, 42);
            this.hóaĐơnToolStripMenuItem1.Text = "Hóa đơn";
            this.hóaĐơnToolStripMenuItem1.Click += new System.EventHandler(this.hóaĐơnToolStripMenuItem1_Click);
            // 
            // nghiệpVụToolStripMenuItem
            // 
            this.nghiệpVụToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpHàngToolStripMenuItem,
            this.bánHàngToolStripMenuItem});
            this.nghiệpVụToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.nghiệpVụToolStripMenuItem.Image = global::QuanLiCuaHangDoChoi.Properties.Resources.money;
            this.nghiệpVụToolStripMenuItem.Name = "nghiệpVụToolStripMenuItem";
            this.nghiệpVụToolStripMenuItem.Size = new System.Drawing.Size(181, 42);
            this.nghiệpVụToolStripMenuItem.Text = "Nghiệp vụ";
            // 
            // nhậpHàngToolStripMenuItem
            // 
            this.nhậpHàngToolStripMenuItem.Image = global::QuanLiCuaHangDoChoi.Properties.Resources.NhapHang;
            this.nhậpHàngToolStripMenuItem.Name = "nhậpHàngToolStripMenuItem";
            this.nhậpHàngToolStripMenuItem.Size = new System.Drawing.Size(240, 42);
            this.nhậpHàngToolStripMenuItem.Text = "Nhập hàng";
            this.nhậpHàngToolStripMenuItem.Click += new System.EventHandler(this.nhậpHàngToolStripMenuItem_Click);
            // 
            // bánHàngToolStripMenuItem
            // 
            this.bánHàngToolStripMenuItem.Image = global::QuanLiCuaHangDoChoi.Properties.Resources.BanHang;
            this.bánHàngToolStripMenuItem.Name = "bánHàngToolStripMenuItem";
            this.bánHàngToolStripMenuItem.Size = new System.Drawing.Size(240, 42);
            this.bánHàngToolStripMenuItem.Text = "Bán hàng";
            this.bánHàngToolStripMenuItem.Click += new System.EventHandler(this.bánHàngToolStripMenuItem_Click);
            // 
            // hóaĐơnToolStripMenuItem
            // 
            this.hóaĐơnToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.hóaĐơnToolStripMenuItem.Image = global::QuanLiCuaHangDoChoi.Properties.Resources.whiteboard;
            this.hóaĐơnToolStripMenuItem.Name = "hóaĐơnToolStripMenuItem";
            this.hóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(294, 42);
            this.hóaĐơnToolStripMenuItem.Text = "Báo cáo - Thống kê";
            this.hóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.hóaĐơnToolStripMenuItem_Click);
            // 
            // hjhjToolStripMenuItem
            // 
            this.hjhjToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.hjhjToolStripMenuItem.Image = global::QuanLiCuaHangDoChoi.Properties.Resources.logout;
            this.hjhjToolStripMenuItem.Name = "hjhjToolStripMenuItem";
            this.hjhjToolStripMenuItem.Size = new System.Drawing.Size(181, 42);
            this.hjhjToolStripMenuItem.Text = "Đăng xuất";
            this.hjhjToolStripMenuItem.Click += new System.EventHandler(this.hjhjToolStripMenuItem_Click);
            // 
            // FrmCuaHangDoChoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1387, 788);
            this.Controls.Add(this.menuQuanLy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuQuanLy;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmCuaHangDoChoi";
            this.Text = "Trung Tâm Đồ Chơi Giải Trí ToyPlant";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCuaHangDoChoi_Load);
            this.menuQuanLy.ResumeLayout(false);
            this.menuQuanLy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tổngQuanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhàSảnXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nghiệpVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bánHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hjhjToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuQuanLy;
    }
}

