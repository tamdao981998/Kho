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
    public partial class FrmDoiMatkhau : Form
    {
        TaiKhoanDTO chon = null;
        TaiKhoanBUS bus = new TaiKhoanBUS();
        public static string tdn = string.Empty;
        public static string matkhau = string.Empty;
        public FrmDoiMatkhau()
        {
            InitializeComponent();
        }

        private void FrmDoiMatkhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn chắc chắn muốn thoát","Thoát",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!= System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDoiMatkhau_Load(object sender, EventArgs e)
        {
            
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtMKcu.Text != "" && txtMKmoi.Text != "" && txtXacNhan.Text != "")
            {
                if (txtMKcu.Text == matkhau)
                {
                    if(txtMKmoi.Text == txtMKcu.Text)
                    {
                        MessageBox.Show("Trùng với mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                
                    else if (txtMKmoi.Text == txtXacNhan.Text)
                    {

                        luudulieu();
                        if (bus.UpdateMatKhau(chon))
                        {

                            MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMKcu.Text = "";
                            txtMKmoi.Text = "";
                            txtXacNhan.Text = "";
                        }
                    }
                    else if (txtMKmoi.Text == txtMKcu.Text)
                    {
                        MessageBox.Show("Trùng với mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không trùng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void luudulieu()
        {
            if (chon == null)
            {
                chon = new TaiKhoanDTO();

            }
            chon.MatKhau = txtMKmoi.Text;
           
        }
        
    }
}
