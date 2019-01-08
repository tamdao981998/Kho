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
using System.Windows.Forms;

namespace QuanLiCuaHangDoChoi
{
    public partial class FrmSanPham : Form
    {
        List<LoaiSPDTO> DTO = new List<LoaiSPDTO>();
        LoaiSPDTO chon1 = null;
        LoaiSPBUS BUS = new LoaiSPBUS();
        SanPhamDTO chon = null;
        SanPhamBUS bus = new SanPhamBUS();
        List<SanPhamDTO> dto = new List<SanPhamDTO>();
        public FrmSanPham()
        {
            InitializeComponent();
        }

        public void conca()
        {
           
            dto = bus.LayDSSanPham();
            dgvDanhSachSP.DataSource = dto;
           

        }
        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }


        private void LoaDSLOAISP()
        {
            LoaiSPBUS bus = new LoaiSPBUS();
            List<LoaiSPDTO> dto = bus.layDSLoaiSP();
            cmbLoaiSP.DataSource = dto;
            cmbLoaiSP.DisplayMember = "TenLoaiSP";
            cmbLoaiSP.ValueMember = "MaLoaiSP";

        }

        private void LoaDSNSX()
        {
            NXSBUS bus = new NXSBUS();
            List<NSXDTO> dto = bus.LayDSNSX();
            cmbNSX.DataSource = dto;
            cmbNSX.DisplayMember = "TenNSX";
            cmbNSX.ValueMember = "MaNSX";
        }

        public void LoadDSSP()
        {
            List<LoaiSPDTO> DTO = BUS.layDSLoaiSP();
            dgvDSLoaiSP.DataSource = DTO;

            List<SanPhamDTO> dto = bus.LayDSSanPham();
            dgvDanhSachSP.DataSource = dto;


            //colLoaiSP.DataSource = dto;
            //colLoaiSP.DisplayMember = "TenSP";
            //colLoaiSP.DisplayMember = "MaSP";
            //colNSX.DataSource = dto;
            //colNSX.DisplayMember = "TenSP";
            //colNSX.DisplayMember = "MaSP";






        }

        private void dgvDanhSachSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tpSanPham_Click(object sender, EventArgs e)
        {

        }


        private void btnLamMoiSP_Click(object sender, EventArgs e)
        {
            chon = null;
            Bind();
            txtMaSP.Text = bus.LayMaSPTiepTheo();


        }
        private void Bind()
        {
            if (chon != null)
            {
                txtMaSP.Text = chon.MaSP;
                txtTenSP.Text = chon.TenSP;
                txtDoTuoi.Text = chon.DoTuoi;
                rtxtMoTa.Text = chon.MoTa;
                txtGia.Text = chon.Gia.ToString();
                txtSL.Text = chon.SoLuongTonKho.ToString();


            }
            else
            {
                txtMaSP.Clear();
                txtTenSP.Clear();
                txtDoTuoi.Clear();
                rtxtMoTa.Clear();
                txtGia.Clear();
                txtSL.Clear();
                btnSuaSP.Enabled = false;
                btnXoaSP.Enabled = false;
                btnThemSP.Enabled = true;
                picHinh.Image = null;
                cmbLoaiSP.SelectedValue = -1;
                cmbNSX.SelectedValue = -1;
            }
        }

        private void dgvDanhSachSP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachSP.SelectedRows.Count > 0)
            {
                btnThemSP.Enabled = false;
                btnXoaSP.Enabled = true;
                btnSuaSP.Enabled = true;

                chon = (SanPhamDTO)dgvDanhSachSP.SelectedRows[0].DataBoundItem;
            }
            else
            {
                chon = null;
            }

            BindingChiTietSP();

        }

        private void BindingChiTietSP()
        {
            if (chon != null)
            {
                txtMaSP.Text = chon.MaSP;
                txtTenSP.Text = chon.TenSP;
                txtDoTuoi.Text = chon.DoTuoi;
                rtxtMoTa.Text = chon.MoTa;
                txtGia.Text = chon.Gia.ToString("#,##0");
                txtSL.Text = chon.SoLuongTonKho.ToString();

                cmbLoaiSP.SelectedValue = chon.MaLoaiSP;
                cmbNSX.SelectedValue = chon.MaNSX;

                if (chon.TinhTrang == 1)
                    chkTinhTrang.Checked = true;
                else
                    chkTinhTrang.Checked = false;
                if (File.Exists(chon.HinhAnh))
                {
                    byte[] byteHA = File.ReadAllBytes(chon.HinhAnh);
                    MemoryStream ms = new MemoryStream(byteHA);
                    picHinh.Image = Image.FromStream(ms);

                }
                else
                {
                    picHinh.Image = null;
                }

            }
            else
            {
                txtMaSP.Clear();
                txtTenSP.Clear();
                txtDoTuoi.Clear();
                rtxtMoTa.Clear();
                txtGia.Clear();
                txtSL.Clear();
                chkTinhTrang.Checked = false;
                cmbLoaiSP.SelectedIndex = -1;
                cmbNSX.SelectedIndex = -1;
                picHinh.Image = null;
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text != "" && txtDoTuoi.Text != "" && rtxtMoTa.Text != "" && txtGia.Text != "" && txtSL.Text != "" && picHinh.Image != null)
            {
                luuDuLieu();

                if (bus.ThemSP(chon))
                {

                    if (chon.HinhAnh != null)
                    {
                        picHinh.Image.Save(chon.HinhAnh);
                    }
                    LoadDSSP();
                    MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chon = null;

                }
            }
            else
            {
                MessageBox.Show("Làm ơn, Nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            chon.SoLuongTonKho = 0;
            chon.MaLoaiSP = cmbLoaiSP.SelectedValue.ToString();
            chon.MaNSX = cmbNSX.SelectedValue.ToString();


            if (chkTinhTrang.Checked == false)
                chon.TinhTrang = 0;
            else
                chon.TinhTrang = 1;


        }

        private void FrmSanPham_Load_1(object sender, EventArgs e)
        {
            dgvDanhSachSP.AutoGenerateColumns = false;

            LoadDSSP();
            LoaDSLOAISP();
            LoaDSNSX();


        }

        private void btnLamMoiLSP_Click(object sender, EventArgs e)
        {
            chon = null;
            BindLoai();
            txtMaLoaiSP.Text = BUS.LayMaLoaiSPTiepTheo();
            btnXoaLSP.Enabled = false;
            btnSuaLSP.Enabled = false;
            btnThemLSP.Enabled = true;

        }

        private void BindLoai()
        {
            if (chon1 == null)
            {
                txtMaLoaiSP.Text = chon1.MaLoaiSP;
                txtTenLoaiSP.Text = chon1.TenLoaiSP;

            }
            else
            {
                txtTenLoaiSP.Clear();
                txtMaLoaiSP.Clear();
                chkTinhTrangLSP.Checked = false;
            }

        }

        private void dgvDSLoaiSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {

            if (txtTenSP.Text != "" && txtDoTuoi.Text != "" && rtxtMoTa.Text != "" && txtGia.Text != "" && txtSL.Text != "")
            {

                luuDuLieu();
                if (bus.SuaTTSP(chon))
                {
                    dto = bus.LayDSSanPham();
                    dgvDanhSachSP.DataSource = dto;
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkBox1.Checked = false;
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chon = null;
                }


            }
            else
            {
                MessageBox.Show("Làm ơn, nhập đầy đủ thông tin Sản Phẩm !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (txtDoTuoi.Text != "" && txtMaSP.Text != "")
            {
                luuDuLieu();
                if (chon.TinhTrang == 0)
                {
                    MessageBox.Show("Sản phẩm không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult dg = MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg == DialogResult.Yes)
                    {
                        if (bus.XoaSP(chon))
                        {
                            dto = bus.LayDSSanPham();
                            dgvDanhSachSP.DataSource = dto;
                            MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaSP.Clear();
                            txtTenSP.Clear();
                            txtDoTuoi.Clear();
                            rtxtMoTa.Clear();
                            txtGia.Clear();
                            txtSL.Clear();
                            chkTinhTrang.Checked = false;
                            cmbLoaiSP.SelectedIndex = -1;
                            cmbNSX.SelectedIndex = -1;
                            picHinh.Image = null;
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            chon = null;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Sản Phẩm muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dgvDSLoaiSP_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvDSLoaiSP.SelectedRows.Count > 0)
            {
                btnThemLSP.Enabled = false;
                btnXoaLSP.Enabled = true;
                btnSuaLSP.Enabled = true;
                //if(chon.TinhTrang==0)
                //{

                //}
                chon1 = (LoaiSPDTO)dgvDSLoaiSP.SelectedRows[0].DataBoundItem;
            }
            else
            {
                chon1 = null;
            }
            BindLoaiChiTietTK();

        }

        private void BindLoaiChiTietTK()
        {
            if (chon1 == null)
            {
                chon1 = new LoaiSPDTO();
            }
            txtMaLoaiSP.Text = chon1.MaLoaiSP;
            txtTenLoaiSP.Text = chon1.TenLoaiSP;
            if (chon1.TinhTrang == 0)
                chkTinhTrangLSP.Checked = false;
            else
                chkTinhTrangLSP.Checked = true;
        }

        private void btnThemLSP_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiSP.Text != "" && txtMaLoaiSP.Text != "")
            {
                luuDuLieuLoaiSP();

                if (BUS.ThemLoaiSP(chon1))
                {
                    LoaDSLOAISP();
                    MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chon1 = null;

                }
            }
            else
            {
                MessageBox.Show("Làm ơn, Nhập đầy đủ thông tin Loại Sản Phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void luuDuLieuLoaiSP()
        {
            if (chon1 != null)
            {
                chon1 = new LoaiSPDTO();
            }
            chon1.MaLoaiSP = txtMaLoaiSP.Text;
            chon1.TenLoaiSP = txtTenLoaiSP.Text;
            if (chkTinhTrangLSP.Checked == false)
                chon1.TinhTrang = 0;
            else
                chon1.TinhTrang = 1;
        }

        private void btnXoaLSP_Click(object sender, EventArgs e)
        {
            if (chon1.TinhTrang == 0)
            {
                MessageBox.Show("Loại sản phẩm không tồn tại  không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dg = MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg == DialogResult.Yes)
                {
                    luuDuLieuLoaiSP();
                    if (BUS.XoaLoaiSP(chon1))
                    {
                        DTO = BUS.layDSLoaiSP();
                        dgvDSLoaiSP.DataSource = DTO;
                        MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaLoaiSP.Clear();
                        txtTenLoaiSP.Clear();
                        chkTinhTrangLSP.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        chon1 = null;
                    }
                }

            }

        }

        //private void luuDuLieuLSP()
        //{
        //    if (chon1 == null)
        //    {
        //        chon1 = new LoaiSPDTO();

        //    }
        //    chon1.MaLoaiSP = txtTenLoaiSP.Text;
        //    chon1.TenLoaiSP = txtTenLoaiSP.Text;
        //    if(chkTinhTrang.Checked==false)
        //    {
        //        chon1.TinhTrang = 0;
        //    }
        //    else
        //        chon1.TinhTrang = 1;

        //}

        private void btnSuaLSP_Click(object sender, EventArgs e)
        {

            if (txtTenLoaiSP.Text != "" && txtMaLoaiSP.Text != "")
            {

                luuDuLieuLoaiSP();
                if (BUS.SuaLoaiSP(chon1))
                {
                    DTO = BUS.layDSLoaiSP();
                    dgvDSLoaiSP.DataSource = DTO;
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chon1 = null;
                }


            }
            else
            {
                MessageBox.Show("Làm ơn, nhập đầy đủ thông tin Sản Phẩm !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            if (txtGiaTu.Text == "" && txtGiaDen.Text == "" && txtTKTenSP.Text == "")
            {
                dto = bus.LayDSSanPham();
                dgvDanhSachSP.DataSource = dto;
            }
            else
                if (txtTKTenSP.Text == "")
                {
                    dto = bus.TKTHEOGIA(txtGiaTu.Text, txtGiaDen.Text);
                    dgvDanhSachSP.DataSource = dto;
                }
                else if (txtGiaTu.Text == "" && txtGiaDen.Text == "")
                {
                    dto = bus.TimKiemTheoMa(txtTKTenSP.Text);
                    dgvDanhSachSP.DataSource = dto;
                }
                else
                {

                    dto = bus.TKTHEOGIAten(txtTKTenSP.Text, txtGiaTu.Text, txtGiaDen.Text);
                    dgvDanhSachSP.DataSource = dto;
                }


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

        private void checkBox1_Click(object sender, EventArgs e)
        {
            dgvDanhSachSP.ClearSelection();
            if (checkBox1.Checked == true)
            {
                List<SanPhamDTO> dto = bus.LayDSSanPhamxoa();
                dgvDanhSachSP.DataSource = dto;
                
            }
            else
            {
                List<SanPhamDTO> dto = bus.LayDSSanPham();
                dgvDanhSachSP.DataSource = dto;
            }

        }

        private void tclSanPham_TabIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void tclSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tclSanPham_Move(object sender, EventArgs e)
        {
           
        }

        private void tclSanPham_ImeModeChanged(object sender, EventArgs e)
        {
        }

        private void dgvDanhSachSP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void dgvDanhSachSP_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvDanhSachSP_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
         
        }




    }
}
