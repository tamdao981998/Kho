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
    public partial class FrmKhachHang : Form
    {
        KhachHangBUS bus = new KhachHangBUS();
        KhachHangDTO chon = null;
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            KhachHangBUS bus = new KhachHangBUS();
            List<KhachHangDTO> dto = bus.LAYDSKH();
            dgvDanhSachKH.DataSource = dto;
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDanhSachKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Bind()
        {
            if (chon != null)
            {
                txtMaKH.Text = chon.MaKH;
                txtHoTenKH.Text = chon.TenKH;
                rtxtDiaChiKH.Text = chon.DiaChi;
                txtEmailKH.Text = chon.Email;
                txtSDTKH.Text = chon.SDT.ToString();
                txtCMNDKH.Text = chon.CMND;
                if (chon.TinhTrang == 0)
                    chktinhTrang.Checked = false;
                else
                    chktinhTrang.Checked = true;



            }
            else
            {
                txtMaKH.Clear();
                txtHoTenKH.Clear();
                rtxtDiaChiKH.Clear();
                txtEmailKH.Clear();
                txtSDTKH.Clear();
                txtCMNDKH.Clear();
                chktinhTrang.Checked = false;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {

            chon = null;
            Bind();
            txtMaKH.Text = bus.LayMaKHTiepTheo();
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
        }

        private void dgvDanhSachKH_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachKH.SelectedRows.Count > 0)
            {
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnThem.Enabled = false;
                chon = (KhachHangDTO)dgvDanhSachKH.SelectedRows[0].DataBoundItem;

            }
            else
            {
                chon = null;
            }
            Bind();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
                if (txtMaKH.Text != "" && txtHoTenKH.Text != "" && rtxtDiaChiKH.Text != "" && txtEmailKH.Text != "" && txtSDTKH.Text != "" && txtCMNDKH.Text != "")
                {
                    //if (txtMaKH.Text == chon.MaKH)
                    //{
                    //    MessageBox.Show("Mã khách hàng đã tồn tài , vui lòng làm mới để có mã khách hàng chính xác !!!cám ơn");
                    //}
                    //else
                    {
                        luuDuLieu();
                        if (bus.ThemKH(chon))
                        {
                            List<KhachHangDTO> dto = bus.LAYDSKH();
                            dgvDanhSachKH.DataSource = dto;
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            chon = null;
                        }
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
            chon.NgayMuaHang = DateTime.Parse(dtpNgayMuaHang.Value.ToString());
            chon.TinhTrang = chktinhTrang.Checked ? 1 : 0;
            


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
         
            if (txtMaKH.Text != "" && txtHoTenKH.Text != "" && rtxtDiaChiKH.Text != "" && txtEmailKH.Text != "" && txtSDTKH.Text != "" && txtCMNDKH.Text != "")
            {
                    luuDuLieu();
                    if (bus.SuaTTKH(chon))
                    {
                        List<KhachHangDTO> dto = bus.LAYDSKH();
                        dgvDanhSachKH.DataSource = dto;
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
                MessageBox.Show("Làm ơn, nhập đầy đủ thông tin Khách Hàng!!! ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult sp = MessageBox.Show("Bạn có chắc muốn xóa tài khoản ","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (sp == DialogResult.Yes)
            {
                if (chon.TinhTrang == 0)
                {
                    MessageBox.Show("Khách hàng không tồn tại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (bus.XoaTTKH(chon))
                    {
                        List<KhachHangDTO> dto = bus.LAYDSKH();
                        dgvDanhSachKH.DataSource = dto;
                        MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaKH.Clear();
                        txtHoTenKH.Clear();
                        rtxtDiaChiKH.Clear();
                        txtEmailKH.Clear();
                        txtSDTKH.Clear();
                        txtCMNDKH.Clear();
                        chktinhTrang.Checked = false;

                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnTimKiemTK_Click(object sender, EventArgs e)
        {
            dgvDanhSachKH.DataSource = bus.TimKiemTheoTen(txtTKTenNV.Text);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk_Click(object sender, EventArgs e)
        {

            dgvDanhSachKH.ClearSelection();
            if (chk.Checked == true)
            {
                List<KhachHangDTO> dto = bus.LAYDSKHxoa();
                dgvDanhSachKH.DataSource = dto;

            }
            else
            {
                List<KhachHangDTO> dto = bus.LAYDSKH();
                dgvDanhSachKH.DataSource = dto;
            }
        }
    }
}
