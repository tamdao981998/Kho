using QuanLyCuaHangDoChoiBUS;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCuaHangDoChoi
{
    public partial class frmthemnsx : Form
    {
        NSXDTO chon = null;
        NXSBUS bus = new NXSBUS();
        List<NSXDTO> dto = new List<NSXDTO>();
        public frmthemnsx()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNSX.Text != "" && txtTenNSX.Text != "" && rtxtDiaChiNSX.Text != "" && txtSDTNSX.Text != "")
            {
                luuDuLieu();

                if (bus.ThemNSX(chon))
                {
                  
                    MessageBox.Show("Thêm thành công ");
                    txtMaNSX.Text = bus.LayNSXTiepTheo();
                    txtSDTNSX.Clear();
                    txtTenNSX.Clear();
                    rtxtDiaChiNSX.Clear();

                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                    chon = null;

                }
            }
            else
            {
                MessageBox.Show("Làm ơn, nhập đầy đủ thông tin nhà sản xuất!!! ");
            }
        }
        private void luuDuLieu()
        {

            if (chon == null)
            {
                chon = new NSXDTO();
            }

            chon.MaNSX = txtMaNSX.Text;
            chon.TenNSX = txtTenNSX.Text;
            chon.DiaChi = rtxtDiaChiNSX.Text;
            chon.SDT = int.Parse(txtSDTNSX.Text.ToString());
            //if (chkTinhTrang.Checked == false)

            //    chon.TinhTrang = 0;

            //else
            //    chon.TinhTrang = 1;



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            txtMaNSX.Text = bus.LayNSXTiepTheo();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
