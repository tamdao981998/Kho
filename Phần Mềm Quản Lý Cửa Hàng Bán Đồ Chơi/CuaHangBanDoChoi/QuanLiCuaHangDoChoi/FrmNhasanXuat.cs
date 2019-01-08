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
    public partial class FrmNhasanXuat : Form
    {
        NSXDTO chon = null;
        NXSBUS bus = new NXSBUS();
        List<NSXDTO> dto = new List<NSXDTO>();
        public FrmNhasanXuat()
        {
            InitializeComponent();
        }

        private void FrmNhasanXuat_Load(object sender, EventArgs e)
        {

            List<NSXDTO> lsnsx = bus.LoadDSNSX();
            dgvDanhSachNSX.DataSource = lsnsx;


        }
        private void Bind()
        {

            if (chon != null)
            {
                txtMaNSX.Text = chon.MaNSX;
                txtTenNSX.Text = chon.TenNSX;
                rtxtDiaChiNSX.Text = chon.DiaChi;
                txtSDTNSX.Text = chon.SDT.ToString();
                if (chon.TinhTrang == 0)
                    chkTinhTrang.Checked = false;
                else
                    chkTinhTrang.Checked = true;


            }
            else
            {
                txtMaNSX.Clear();
                txtTenNSX.Clear();
                rtxtDiaChiNSX.Clear();
                txtSDTNSX.Clear();

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNSX.Text != "" && txtTenNSX.Text != "" && rtxtDiaChiNSX.Text != "" && txtSDTNSX.Text != "")
            {
                luuDuLieu();

                if (bus.ThemNSX(chon))
                {
                    List<NSXDTO> lsnsx = bus.LoadDSNSX();
                    dgvDanhSachNSX.DataSource = lsnsx;
                    MessageBox.Show("Thêm thành công ");


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
            if (chkTinhTrang.Checked == false)

                chon.TinhTrang = 0;

            else
                chon.TinhTrang = 1;



        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            chon = null;
            Bind();
            txtMaNSX.Text = bus.LayNSXTiepTheo();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgvDanhSachNSX_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachNSX.SelectedRows.Count > 0)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                chon = (NSXDTO)dgvDanhSachNSX.SelectedRows[0].DataBoundItem;
            }
            else
            {
                chon = null;
            }
            Bind();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult sp = MessageBox.Show("Bạn có chắc muốn xóa tài khoản ","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (sp == DialogResult.Yes)
            {
                luuDuLieu();
                if (bus.XoaNSX(chon))
                {
                    dto = bus.LoadDSNSX();
                    dgvDanhSachNSX.DataSource = dto;
                    MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaNSX.Clear();
                    txtTenNSX.Clear();
                    txtSDTNSX.Clear();
                    rtxtDiaChiNSX.Clear();
                    chkTinhTrang.Checked = false;
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chon = null;
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNSX.Text != "" && txtTenNSX.Text != "" && txtSDTNSX.Text != "" && rtxtDiaChiNSX.Text != "")
            {

                luuDuLieu();
                if (bus.SuaNSX(chon))
                {
                    dto = bus.LoadDSNSX();
                    dgvDanhSachNSX.DataSource = dto;
                    MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chon = null;
                }
            }
            else
            {
                MessageBox.Show("Làm ơn, nhập đầy đủ thông tin Nhà Sản Xuất !!! ");
            }
        }

        private void btnTimKiemNSX_Click(object sender, EventArgs e)
        {
            dgvDanhSachNSX.DataSource = bus.TimKiem(txtTKTenNSX.Text);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDanhSachNSX_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {

            dgvDanhSachNSX.ClearSelection();
            if (chk.Checked == true)
            {
                List<NSXDTO> dto = bus.LoadDSNXSxoa();
                dgvDanhSachNSX.DataSource = dto;

            }
            else
            {
                List<NSXDTO> dto = bus.LayDSNSX();
                dgvDanhSachNSX.DataSource = dto;
            }
        }


    }
}
