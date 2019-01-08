using QuanLyCuaHangDoChoiBUS;
using QuanLyCuaHangDoChoiDTO;
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

namespace QuanLiCuaHangDoChoi
{
    public partial class frmthemsanpham : Form
    {
        SanPhamDTO chon = null;
        SanPhamBUS bus = new SanPhamBUS();
        List<SanPhamDTO> dto = new List<SanPhamDTO>();
        public frmthemsanpham()
        {
            InitializeComponent();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {

            if (txtTenSP.Text != "" && txtDoTuoi.Text != "" && rtxtMoTa.Text != "" && txtGia.Text != "")
            {
                luuDuLieu();

                if (bus.ThemSP(chon))
                {
                    if(chon.HinhAnh!=null)
                    {
                        picHinh.Image.Save(chon.HinhAnh);
                    }
                    MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaSP.Text = bus.LayMaSPTiepTheo();
                    txtDoTuoi.Clear();
                    txtGia.Clear();
                    
                    txtTenSP.Clear();
                    rtxtMoTa.Clear();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chon = null;

                }
            }
            else
            {
                MessageBox.Show("Làm ơn, Nhập đầy đủ thông tin Sản Phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void luuDuLieu()
        {

            if (chon == null)
            {
                chon = new SanPhamDTO();
            }

            chon.MaSP = txtMaSP.Text;
            chon.TenSP = txtTenSP.Text;
            chon.DoTuoi = txtDoTuoi.Text;
            chon.MoTa = rtxtMoTa.Text;
            chon.Gia = decimal.Parse(txtGia.Text.ToString());
            chon.HinhAnh = chon.MaSP + ".JPG";
            
            chon.MaLoaiSP = cmbLoaiSP.SelectedValue.ToString();
            chon.MaNSX = cmbNSX.SelectedValue.ToString();
            chon.TinhTrang = 1;

            //if (chkTinhTrang.Checked == false)
            //    chon.TinhTrang = 0;
            //else
            //    chon.TinhTrang = 1;


        }

        private void frmthemsanpham_Load(object sender, EventArgs e)
        {
            txtMaSP.Text = bus.LayMaSPTiepTheo();
            LoaiSPBUS bus3 = new LoaiSPBUS();
            List<LoaiSPDTO> dto3 = bus3.layDSLoaiSP();
            cmbLoaiSP.DataSource = dto3;
            cmbLoaiSP.DisplayMember = "TenLoaiSP";
            cmbLoaiSP.ValueMember = "MaLoaiSP";

            NXSBUS bus2 = new NXSBUS();
            List<NSXDTO> dto1= bus2.LayDSNSX();
            cmbNSX.DataSource = dto1;
            cmbNSX.DisplayMember = "TenNSX";
            cmbNSX.ValueMember = "MaNSX";
        }

        private void btnLamMoiSP_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDoTuoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void picHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Hinh |*.png;*.jpeg;*.jpg";
            DialogResult sp = op.ShowDialog();
            if (sp != DialogResult.Cancel)
            {
                byte[] byt = File.ReadAllBytes(op.FileName);
                MemoryStream ms = new MemoryStream(byt);
                picHinh.Image = Image.FromStream(ms);
            }
        }

    }
}
