using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyCuaHangDoChoiBUS;
using QuanLyCuaHangDoChoiDTO;
using System.IO;
namespace QuanLiCuaHangDoChoi
{
    public partial class FrmNguoiDung : Form
    {

        public static string tendangnhap = string.Empty;
        public FrmNguoiDung()
        {
            InitializeComponent();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            FrmDoiMatkhau fmk = new FrmDoiMatkhau();
            this.Hide();
            fmk.ShowDialog();
            this.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNguoiDung_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void FrmNguoiDung_Load(object sender, EventArgs e)
        {
            //string manv="NV001";
            // string mk = "123456789";
            if (!string.IsNullOrEmpty(tendangnhap))
            {
                FrmDoiMatkhau.tdn = tendangnhap;
                TaiKhoanBUS bus = new TaiKhoanBUS();
                TaiKhoanDTO dto = bus.LayThongTinTK(tendangnhap);
                txtMaNV.Text = dto.MaNV;
                txtTenDN.Text = tendangnhap;
                txtTenHienThi.Text = dto.HoTen;
               
                if (dto.MaLoaiTaiKhoan == @"LTK001")
                {
                    tztQuyen.Text = "Quản Lý";
                }
                else 
                {
                    tztQuyen.Text = "Nhân Viên";
                }

                byte[] byteHA = File.ReadAllBytes(dto.AnhDaiDien);
                MemoryStream ms = new MemoryStream(byteHA);
                picAnhDaiDien.Image = Image.FromStream(ms);
                    
             
            }
        }
    }
}
