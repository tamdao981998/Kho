using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLiCuaHangDoChoi
{
    public partial class FrmCuaHangDoChoi : Form
    {
        public TaiKhoanDTO tkDTO;
        public static string tdn = string.Empty;

        public void abc()
        {
            quảnLýToolStripMenuItem.Visible = false;
            hóaĐơnToolStripMenuItem.Visible = false;
        }
        public FrmCuaHangDoChoi()
        {
            InitializeComponent();
        }
       
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        private void ActiveFormCon(string name)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == name)
                {
                    f.Activate();
                    break;
                }
            }
        }
        private void tàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FrmTaiKhoan"))
            {
                FrmTaiKhoan ftk = new FrmTaiKhoan();
                ftk.MdiParent = this;
                ftk.Dock = DockStyle.Fill;
                ftk.Show();
            }
            else
            {
                ActiveFormCon("FrmTaiKhoan");
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FrmNguoiDung"))
            {
                FrmNguoiDung fng = new FrmNguoiDung();
                fng.MdiParent = this;
                fng.Show();
            }
            else
            {
                ActiveFormCon("FrmNguoiDung");
            }
        }

        private void menuQuanLy_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSanPham fr = new FrmSanPham();
            fr.LoadDSSP();
            if (!CheckExistForm("FrmSanPham"))
            {
                FrmSanPham fsp = new FrmSanPham();
                fsp.MdiParent = this;
                fsp.Dock = DockStyle.Fill;
                fsp.Show();
            }
            else
            {
                 ActiveFormCon("FrmSanPham");
                
            }
            
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FrmKhachHang"))
            {
                FrmKhachHang fkh = new FrmKhachHang();
                fkh.MdiParent = this;
                fkh.Dock = DockStyle.Fill;
                fkh.Show();
            }
            else
            {
                ActiveFormCon("FrmKhachHang");
            }
        }

        private void nhàSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FrmNhasanXuat"))
            {
                FrmNhasanXuat fnsx = new FrmNhasanXuat();
                fnsx.MdiParent = this;
                fnsx.Dock = DockStyle.Fill;
                fnsx.Show();
            }
            else
            {
                ActiveFormCon("FrmNhasanXuat");
            }
        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FrmHoaDon"))
            {
                FrmHoaDon fhd = new FrmHoaDon();
                fhd.MdiParent = this;
                fhd.Dock = DockStyle.Fill;
                fhd.Show();
            }
            else
            {
                ActiveFormCon("FrmHoaDon");
            }
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FrmNhapHang"))
            {
                FrmNhapHang fnh = new FrmNhapHang();
                fnh.MdiParent = this;
                fnh.Dock = DockStyle.Fill;
                fnh.Show();
            }
            else
            {
                ActiveFormCon("FrmNhapHang");
            }
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FrmBanHang"))
            {
                FrmBanHang fbh = new FrmBanHang();
                fbh.MdiParent = this;
                fbh.Dock = DockStyle.Fill;
                fbh.Show();
            }
            else
            {
                ActiveFormCon("FrmBanHang");
            }
        }

      

        private void hjhjToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn đăng xuất ?", "Đăng xuất", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
            }
            else
            {

                this.Close();
            }


        }

        private void FrmCuaHangDoChoi_Load(object sender, EventArgs e)
        {
            FrmTongQuan ftq = new FrmTongQuan();
            ftq.MdiParent = this;
            ftq.Dock = DockStyle.Fill;
            ftq.Show();
        }

        private void tổngQuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTongQuan ftq = new FrmTongQuan();
            ftq.MdiParent = this;
            ftq.Dock = DockStyle.Fill;
            ftq.Show();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("FrmBaoCaoThongKe"))
            {
                FrmBaoCaoThongKe fbh = new FrmBaoCaoThongKe();
                fbh.MdiParent = this;
                fbh.Dock = DockStyle.Fill;
                fbh.Show();
            }
            else
            {
                ActiveFormCon("FrmBaoCaoThongKe");
            }
        }
    }

}
