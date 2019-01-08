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
    public partial class frmthemkhachhang : Form
    {

        KhachHangBUS bus = new KhachHangBUS();
        KhachHangDTO chon = null;
        public frmthemkhachhang()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "" && txtHoTenKH.Text != "" && rtxtDiaChiKH.Text != "" && txtEmailKH.Text != "" && txtSDTKH.Text != "" && txtCMNDKH.Text != "")
            {
                luuDuLieu();
                if (bus.ThemKH(chon))
                {
                  
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaKH.Text = bus.LayMaKHTiepTheo();
                    txtHoTenKH.Clear();
                    txtEmailKH.Clear();
                    txtCMNDKH.Clear();
                    txtSDTKH.Clear();
                    rtxtDiaChiKH.Clear();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chon = null;
                }
            }
            else
            {
                MessageBox.Show("Làm ơn, nhập đầy đủ thông tin Khách Hàng!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        private void luuDuLieu()
        {

            if (chon == null)
            {
                chon = new KhachHangDTO();
            }
            chon.MaKH = txtMaKH.Text;
            chon.TenKH = txtHoTenKH.Text;
            chon.DiaChi = rtxtDiaChiKH.Text;
            chon.Email = txtEmailKH.Text;
            chon.SDT = int.Parse(txtSDTKH.Text.ToString());
            chon.CMND = txtCMNDKH.Text;
            chon.NgayMuaHang = DateTime.Now;
            
            


        }

        private void frmthemkhachhang_Load(object sender, EventArgs e)
        {

            txtMaKH.Text = bus.LayMaKHTiepTheo();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
