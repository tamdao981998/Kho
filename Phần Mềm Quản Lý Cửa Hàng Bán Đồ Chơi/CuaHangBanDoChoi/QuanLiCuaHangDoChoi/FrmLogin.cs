using QuanLyCuaHangDoChoiBUS;
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
    public partial class FrmLogin : Form
    {


        
        public FrmLogin()
        {
            InitializeComponent();
        }

        public void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            //FrmCuaHangDoChoi fmain = new FrmCuaHangDoChoi();
            //fmain.Hide();
            //this.Show();
            //fmain.ShowDialog();

            if (txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập mật khẩu");
            }
            else
            {
                TaiKhoanBUS tkbus = new TaiKhoanBUS();
                bool tkdn = tkbus.KiemTraDangNhap(cboTenDN.SelectedValue.ToString(), txtMatKhau.Text);
                
                if (tkdn == true)
                {
                    
                    FrmNguoiDung.tendangnhap = cboTenDN.SelectedValue.ToString();

                    FrmDoiMatkhau.matkhau = txtMatKhau.Text;
                    FrmNhapHang.tendangnhap = cboTenDN.SelectedValue.ToString();
                    FrmBanHang.tendangnhap = cboTenDN.SelectedValue.ToString();
                    FrmCuaHangDoChoi fmain = new FrmCuaHangDoChoi();
                    TaiKhoanBUS bus = new TaiKhoanBUS();
                    TaiKhoanDTO dto = bus.LayThongTinTK(cboTenDN.SelectedValue.ToString());
                    
                    if (dto.MaLoaiTaiKhoan=="LTK001")
                    {

                    }
                    else
                    {
                        fmain.abc();
                    };
                    this.Hide();
                    fmain.ShowDialog();
                    this.Show();
                   
                    
            }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {  
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
            
            
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            LoadDSNhanVien();
            
        }

        private void LoadDSNhanVien()
        {
            TaiKhoanBUS tk = new TaiKhoanBUS();
            List<TaiKhoanDTO> lstk = tk.LayDSTaiKhoan();
            cboTenDN.DataSource = lstk;
            cboTenDN.DisplayMember = "TenDangNhap";
            cboTenDN.ValueMember = "TenDangNhap";

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
