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
    public partial class FrmHoaDon : Form
    {
        DonDatHangDTO chonddh = null;
        List<DonDatHangDTO> dtoddh = new List<DonDatHangDTO>();
        DonDatHangBUS busddh = new DonDatHangBUS();
        HDNhapBUS NHAP = new HDNhapBUS();
        List<HDNhapDTO> dtonhap = new List<HDNhapDTO>();
        HDNhapDTO chonnhap = null;
        HDBanBUS bus = new HDBanBUS();
        HDBanDTO chon = null;
        List<HDBanDTO> dto = new List<HDBanDTO>();
        ChiTietHDBanBUS CTHDB = new ChiTietHDBanBUS();
        List<ChiTietHDBanDTO> DTO = new List<ChiTietHDBanDTO>();
        public FrmHoaDon()
        {
            InitializeComponent();
        }

        private void tpHoaDonBan_Click(object sender, EventArgs e)
        {

        }

        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
             
            dgvDanhSachHDB.AutoGenerateColumns = false;
            dto = bus.LAYHDBan();
            dgvDanhSachHDB.DataSource = dto;

            LoadDSNVLAP();
            LoadDSKH();
            LoadDSHDNHAP();
            LoadDSNSX();
            SanPhamBUS sp = new SanPhamBUS();
            List<SanPhamDTO> DTOSP = sp.LayDSSanPham();
            colMaSPCHTHD.DataSource = DTOSP;
            colMaSPCHTHD.DisplayMember = "TenSP";
            colMaSPCHTHD.ValueMember = "MaSP";
           

        }


        private void LoadDSNSX()
        {
            dgvDSHDN.AutoGenerateColumns = false;
            NXSBUS bus1 = new NXSBUS();
            List<NSXDTO> dto1 = bus1.LayDSNSX();
            cmbHDNNSX.DataSource = dto1;
            cmbHDNNSX.DisplayMember = "TenNSX";
            cmbHDNNSX.ValueMember = "MaNSX";

            colNSXHDN.DataSource = dto1;
            colNSXHDN.DisplayMember = "TenNSX";
            colNSXHDN.ValueMember = "MaNSX";
         
         
        }

        private void LoadDSHDNHAP()
        {
            dgvDSHDN.AutoGenerateColumns = false;
            HDNhapBUS bus = new HDNhapBUS();
            dtonhap = bus.LAYDSHDNhap();
            dgvDSHDN.DataSource = dtonhap;

        }


        public void LoadDSKH()
        {
            KhachHangBUS bus = new KhachHangBUS();
            List<KhachHangDTO> dto = bus.LAYDSKH();
            cmbMaKH.DataSource = dto;
            cmbMaKH.DisplayMember = "TenKH";
            cmbMaKH.ValueMember = "MaKH";

            colKHHDB.DataSource = dto;
            colKHHDB.DisplayMember = "TenKH";
            colKHHDB.ValueMember = "MaKH";






        }

        public void LoadDSNVLAP()
        {
            
            TaiKhoanBUS bus = new TaiKhoanBUS();
            List<TaiKhoanDTO> DTO = bus.LayDSTaiKhoan();
            cmbNVLapHDB.DataSource = DTO;
            cmbNVLapHDB.DisplayMember = "HoTen";
            cmbNVLapHDB.ValueMember = "MaNV";

            colNVLapHDB.DataSource = DTO;
            colNVLapHDB.DisplayMember = "HoTen";
            colNVLapHDB.ValueMember = "MaNV";

            colNVLapHDN.DataSource = DTO;
            colNVLapHDN.DisplayMember = "HoTen";
            colNVLapHDN.ValueMember = "MaNV";

            
            cmbHDNNVLap.DataSource = DTO;
            cmbHDNNVLap.DisplayMember = "HoTen";
            cmbHDNNVLap.ValueMember = "MaNV";

            DataGridViewComboBoxColumn dgv = (DataGridViewComboBoxColumn)dgvDSHDN.Columns["colNVLapHDN"];
            dgv.DataSource = DTO;
            dgv.DisplayMember = "HoTen";
            dgv.ValueMember = "MaNV";


            //colNVLapHDN.DataSource = DTO;
            //colNVLapHDN.DisplayMember = "HoTen";
            //colNVLapHDN.ValueMember = "MaNV";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDanhSachTK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTongTienHDN_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDSHDN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvDanhSachHDB_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvDanhSachHDB.SelectedRows.Count > 0)
            {
                chon = (HDBanDTO)dgvDanhSachHDB.SelectedRows[0].DataBoundItem;
            }
            else
            {
                chon = null;
            }
            BindHDB();
        }

        private void BindHDB()
        {
            if (chon != null)
            {
                txtMaHDBan.Text = chon.MaHDBan;
                txtTongTien.Text = chon.TongTien.ToString();
                dtpNgayLapHDB.Text = chon.NgayLapHD.ToString();
                cmbNVLapHDB.SelectedValue = chon.NVLapHD;
                cmbMaKH.SelectedValue = chon.MaKH;
            }
        }

 

       
            
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHDBan.Text != "" && txtTongTien.Text != "")
            {
                luudulieu();
                if (bus.SUAHDB(chon))
                {
                    List<HDBanDTO> dto = bus.LAYHDBan();
                    dgvDanhSachHDB.DataSource = dto;
                    MessageBox.Show("Cập nhật thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chon = null;
                }

            }
            else
            {
                MessageBox.Show("Làm ơn, nhập đầy đủ thông tin Hóa Đơn Bán!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
     
        }

        private void luudulieu()
        {
            if (chon != null)
            {
                chon = new HDBanDTO();
            }
            chon.MaHDBan = txtMaHDBan.Text;
            chon.TongTien = decimal.Parse(txtTongTien.Text.ToString());
            chon.MaKH = cmbMaKH.SelectedValue.ToString();
            chon.NVLapHD = cmbNVLapHDB.SelectedValue.ToString();
            chon.NgayLapHD =dtpNgayLapHDB.Value;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult sp = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn ? ","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (sp == DialogResult.Yes)
            {
                if (bus.XoaHDB(chon))
                {
                    List<HDBanDTO> dto = bus.LAYHDBan();
                    dgvDanhSachHDB.DataSource = dto;
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHDBan.Clear();
                    txtTongTien.Clear();
                    cmbNVLapHDB.SelectedValue = -1;
                    cmbMaKH.SelectedValue = -1;
                    dgvDSCTHDB.DataSource = null;

                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvDSHDN_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSHDN.SelectedRows.Count > 0)
            {
                chonnhap = (HDNhapDTO)dgvDSHDN.SelectedRows[0].DataBoundItem;
            }
            else
            {
                chonnhap = null;
            }
            BindHDN();
        }

        private void BindHDN()
        {
           if(chonnhap != null)
           {
               txtMaHDNhap.Text = chonnhap.MaHDNhap;
               txtTongTienHDN.Text = chonnhap.TongTien.ToString();
               cmbHDNNVLap.SelectedValue = chonnhap.NVLap;// mai dem len nho` :v ok
               cmbHDNNSX.SelectedValue = chonnhap.NSX;
               dtpNgayLapHDN.Text = chonnhap.NgayNhapHang.ToString();
               
           }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {


            dgvDSCTHDN.AutoGenerateColumns = false;
            ChiTietHDNhapBUS bus = new ChiTietHDNhapBUS();
            List<ChiTietHDNhapDTO> DTO = bus.LOADCTHDN(txtMaHDNhap.Text);
                

            dgvDSCTHDN.DataSource = DTO;
            SanPhamBUS sp = new SanPhamBUS();
            List<SanPhamDTO> DTOSP = sp.LayDSSanPham();
            colMaSPCTHDN.DataSource = DTOSP;
            colMaSPCTHDN.DisplayMember = "TenSP";
            colMaSPCTHDN.ValueMember = "MaSP";
            
            
        }

   
       

        private void btnHDNXoa_Click(object sender, EventArgs e)
        {
            DialogResult sp = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn ? ","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (sp == DialogResult.Yes)
            {
                if (NHAP.XoaHDN(chonnhap))
                {

                    List<HDNhapDTO> DTO = NHAP.LAYDSHDNhap();
                    dgvDSHDN.DataSource = DTO;
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHDNhap.Clear();
                    txtTongTienHDN.Clear();
                    cmbHDNNVLap.SelectedValue = -1;
                    cmbHDNNSX.SelectedValue = -1;
                    dgvDSCTHDN.DataSource = null;

                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnHDNSua_Click(object sender, EventArgs e)
        {

            if (txtMaHDNhap.Text != "" && txtTongTienHDN.Text != "")
            {
                luudulieuHDN();
                if (NHAP.SUAHDN(chonnhap))
                {
                    List<HDNhapDTO> dto = NHAP.LAYDSHDNhap();
                    dgvDSHDN.DataSource = dto;
                    MessageBox.Show("Cập nhật thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chon = null;
                }

            }
            else
            {
                MessageBox.Show("Làm ơn, nhập đầy đủ thông tin Hóa Đơn Nhập!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void luudulieuHDN()
        {

            if (chonnhap != null)
            {
                chonnhap = new HDNhapDTO();
            }
            chonnhap.MaHDNhap = txtMaHDNhap.Text;
            chonnhap.NgayNhapHang = DateTime.Parse(dtpNgayLapHDN.Value.ToString());
            chonnhap.TongTien = decimal.Parse(txtTongTienHDN.Text.ToString());
            chonnhap.NSX = cmbHDNNSX.SelectedValue.ToString();
            chonnhap.NVLap = cmbHDNNVLap.SelectedValue.ToString();
            
            
        }

       

        

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            ChiTietHDBanBUS BUS = new ChiTietHDBanBUS();
            List<ChiTietHDBanDTO> DTO = BUS.LOADCTHDB(txtMaHDBan.Text);
            dgvDSCTHDB.DataSource = DTO;

        }

        private void dtpNgayLapHDB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnTKHDB_Click(object sender, EventArgs e)
        {
            dgvDanhSachHDB.DataSource = bus.TimKiem(txtTKMaHDB.Text);
        }

        private void btnTKHDN_Click(object sender, EventArgs e)
        {
            dgvDSHDN.DataSource = NHAP.TimKiem(txtTKMaHDN.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            dgvDanhSachHDB.ClearSelection();
            if (checkBox1.Checked == true)
            {
                List<HDBanDTO> dto= bus.LAYDSHDBanxoa();
                dgvDanhSachHDB.DataSource = dto;

            }
            else
            {
                List<HDBanDTO> dto = bus.LAYHDBan();
                dgvDanhSachHDB.DataSource = dto;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {

            dgvDSHDN.ClearSelection();
            if (checkBox2.Checked == true)
            {
                List<HDNhapDTO> dto = NHAP.LAYDSHDNhapxoa();
                dgvDSHDN.DataSource = dto;

            }
            else
            {
                List<HDNhapDTO> dto = NHAP.LAYDSHDNhap();
                dgvDSHDN.DataSource = dto;
            }

        }

 
    }
}
