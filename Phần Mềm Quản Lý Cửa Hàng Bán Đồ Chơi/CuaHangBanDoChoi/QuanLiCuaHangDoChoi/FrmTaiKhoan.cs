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
    public partial class FrmTaiKhoan : Form
    {
        TaiKhoanDTO chon = null;
        List<TaiKhoanDTO> dto = new List<TaiKhoanDTO>();
        TaiKhoanBUS bus = new TaiKhoanBUS();
        LoaiTKDTO chon1 = null;
        LoaiTKBUS bus1 = new LoaiTKBUS();
        List<LoaiTKDTO> dto1 = new List<LoaiTKDTO>();
        public FrmTaiKhoan()
        {
            InitializeComponent();
        }


        private void FrmTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvDanhSachTK.AutoGenerateColumns = false;
            TaiKhoanBUS bus = new TaiKhoanBUS();
            List<TaiKhoanDTO> dto = bus.LayDSTaiKhoan();
            dgvDanhSachTK.DataSource = dto;
            LoadDSLoaiTK();
        }

        private void LoadDSLoaiTK()
        {
            dgvDanhSachTK.AutoGenerateColumns = false;
            LoaiTKBUS BUS = new LoaiTKBUS();

            List<LoaiTKDTO> Dto = BUS.LoadDSLoaiTK();

            cmbQuyen.DataSource = Dto;
            cmbQuyen.DisplayMember = "TenLoaiTK";
            cmbQuyen.ValueMember = "MaLoaiTK";
            dgvDSLoaiTK.DataSource = Dto;




            //colQuyen.DataSource = Dto;
            //colQuyen.DisplayMember = "TenLoaiTK";
            //colQuyen.ValueMember = "MaLoaiTK";


            //TaiKhoanBUS bus = new TaiKhoanBUS();
            //dto = bus.LayDSTaiKhoan().FindAll(o => o.MaLoaiTaiKhoan == chon.MaLoaiTaiKhoan);

        }


        private void btnTimKiemTK_Click(object sender, EventArgs e)
        {
            dto = bus.TimKiemTheoMa(txtTKTenNV.Text);
            dgvDanhSachTK.DataSource = dto;

        }

        private void dgvDanhSachTK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDanhSachTK_SelectionChanged(object sender, EventArgs e)
        {

            if (dgvDanhSachTK.SelectedRows.Count > 0)
            {
                btnSuaTK.Enabled = true;
                btnXoaTK.Enabled = true;
                btnThemTK.Enabled = false;
                chon = (TaiKhoanDTO)dgvDanhSachTK.SelectedRows[0].DataBoundItem;

                if (chon.MaLoaiTaiKhoan == "LTK001")
                {
                    chkTKTinhTrang.Enabled = false;
                    cmbQuyen.Enabled = false;
                }
                else
                {
                    chkTKTinhTrang.Enabled = true;
                    cmbQuyen.Enabled = true;
                }
            }
            else
            {
                chon = null;
            }
            Bind();

        }

        private void Bind()
        {
            if (chon != null)
            {
                txtMaTK.Text = chon.MaNV;
                txtMK.Text = chon.MatKhau;
                txtHoTen.Text = chon.HoTen;
                rtxtDiaChiTK.Text = chon.DiaChi;
                txtEmail.Text = chon.Email;
                txtSDT.Text = chon.Sdt.ToString();
                txtCMND.Text = chon.CMND;
                //if (chon.TenDangNhap == @"ThanhLuc")
                //{
                cmbQuyen.SelectedValue = chon.MaLoaiTaiKhoan;
                //}
                //else
                //{
                //    cmbQuyen.SelectedValue = chon.MaLoaiTaiKhoan;
                //}


                if (chon.TinhTrang == 0)
                    chkTKTinhTrang.Checked = false;
                else
                    chkTKTinhTrang.Checked = true;

                txtTenDN.Text = chon.TenDangNhap;
                if (File.Exists(chon.AnhDaiDien))
                {
                    byte[] byteHA = File.ReadAllBytes(chon.AnhDaiDien);
                    MemoryStream ms = new MemoryStream(byteHA);
                    picAnhDaiDien.Image = Image.FromStream(ms);

                }
                else
                {
                    picAnhDaiDien.Image = null;
                }


            }
            else
            {
                txtMaTK.Clear();
                txtMK.Clear();
                txtHoTen.Clear();
                rtxtDiaChiTK.Clear();
                txtEmail.Clear();
                txtSDT.Clear();
                txtCMND.Clear();
                cmbQuyen.SelectedValue = -1;
                txtTenDN.Clear();
                picAnhDaiDien.Image = null;

            }


        }
        private void btnLamMoiTK_Click(object sender, EventArgs e)
        {
            chon = null;
            Bind();
            txtMaTK.Text = bus.LayManNVTiepTheo();
            btnSuaTK.Enabled = false;
            btnXoaTK.Enabled = false;
            btnThemTK.Enabled = true;

        }

        private void rtxtDiaChiTK_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {

            if (txtMK.Text != "" && txtTenDN.Text != "" && txtCMND.Text != "" && txtEmail.Text != "" && rtxtDiaChiTK.Text != "" &&
                txtHoTen.Text != "" && txtSDT.Text != "")
            {
                luuDuLieu();

                if (bus.ThemTK(chon))
                {
                    List<TaiKhoanDTO> dto = bus.LayDSTaiKhoan();
                    dgvDanhSachTK.DataSource = dto;
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
                MessageBox.Show("Làm ơn, nhập đầy đủ thông tin Tài Khoản !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }

        private void luuDuLieu()
        {
            if (chon == null)
            {
                chon = new TaiKhoanDTO();
            }
            chon.MaNV = txtMaTK.Text;
            chon.MatKhau = txtMK.Text;
            chon.HoTen = txtHoTen.Text;
            chon.DiaChi = rtxtDiaChiTK.Text;
            chon.Email = txtEmail.Text;
            chon.Sdt = int.Parse(txtSDT.Text.ToString());
            chon.CMND = txtCMND.Text;
            chon.TenDangNhap = txtTenDN.Text;
            chon.MaLoaiTaiKhoan = cmbQuyen.SelectedValue.ToString();
            if (File.Exists(chon.AnhDaiDien))
            {
                byte[] byteHA = File.ReadAllBytes(chon.AnhDaiDien);
                MemoryStream ms = new MemoryStream(byteHA);
                picAnhDaiDien.Image = Image.FromStream(ms);

            }
            else
            {
                picAnhDaiDien.Image = null;
            }


            if (chkTKTinhTrang.Checked == true)
                chon.TinhTrang = 1;

            else
                chon.TinhTrang = 0;



        }




        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            if (txtMaTK.Text != "" && txtMK.Text != "" && rtxtDiaChiTK.Text != "" && txtEmail.Text != "" && txtSDT.Text != "" && txtCMND.Text != "")
            {
                luuDuLieu();
                if (bus.SuaTTTK(chon))
                {
                    List<TaiKhoanDTO> dto = bus.LayDSTaiKhoan();
                    dgvDanhSachTK.DataSource = dto;
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
                MessageBox.Show("Làm ơn, nhập đầy đủ thông tin Nhan Vien!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            if (chon.MaLoaiTaiKhoan == "LTK001")
            {
                MessageBox.Show("Tài khoản là Admin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                DialogResult sp = MessageBox.Show("Bạn có chắc muốn xóa tài khoản ","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(sp==DialogResult.Yes)
                {
                if (chon.TinhTrang == 0)
                {
                    MessageBox.Show("Tài khoản không tồn tại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (bus.XoaTK(chon))
                    {
                        List<TaiKhoanDTO> dto = bus.LayDSTaiKhoan();
                        dgvDanhSachTK.DataSource = dto;
                        MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMaTK.Clear();
                        txtTenDN.Clear();
                        txtMK.Clear();
                        rtxtDiaChiTK.Clear();
                        txtCMND.Clear();
                        txtHoTen.Clear();
                        txtSDT.Clear();
                        txtEmail.Clear();
                        chkTKTinhTrang.Checked = false;
                        picAnhDaiDien.Image = null;

                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        chon = null;
                    }
                }
            }}
        }

        private void dgvDSLoaiTK_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSLoaiTK.SelectedRows.Count > 0)
            {
                btnXoaLTK.Enabled = true;
                btnSuaLTK.Enabled = true;
                btnThemLTK.Enabled = false; ;

                chon1 = (LoaiTKDTO)dgvDSLoaiTK.SelectedRows[0].DataBoundItem;
            }
            else
            {
                chon = null;
            }
            BindLoaiChiTietTK();


        }

        private void BindLoaiChiTietTK()
        {
            if (chon1 != null)
            {
                txtMaLoaiTK.Text = chon1.MaLoaiTK;
                txtTenLoaiTK.Text = chon1.TenLoaiTK;

                if (chon1.TinhTrang == 0)
                    chkTinhTrang.Checked = false;
                else
                    chkTinhTrang.Checked = true;

            }
            else
            {
                txtMaLoaiTK.Clear();
                txtTenLoaiTK.Clear();

            }
        }

        private void btnThemLTK_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiTK.Text != "" && txtTenLoaiTK.Text != "")
            {
                luuDuLieuLoaiTK();


                if (bus1.ThemLoaiTK(chon1))
                {
                    dto1 = bus1.LoadDSLoaiTK();
                    dgvDSLoaiTK.DataSource = dto1;
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
                MessageBox.Show("Làm ơn, nhập đầy đủ thông tin Loại Tài Khoản !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void luuDuLieuLoaiTK()
        {
            if (chon1 == null)
            {
                chon1 = new LoaiTKDTO();
            }
            chon1.MaLoaiTK = txtMaLoaiTK.Text;
            chon1.TenLoaiTK = txtTenLoaiTK.Text;
            if (chkTinhTrang.Checked == false)
                chon1.TinhTrang = 0;
            else
                chon1.TinhTrang = 1;
        }

        private void btnLamMoiLTK_Click(object sender, EventArgs e)
        {
            chon = null;
            BindLoaiTK();
            txtMaLoaiTK.Text = bus1.LayMaLoaiTKTiepTheo();
            btnSuaLTK.Enabled = false;
            btnXoaLTK.Enabled = false;
            btnThemLTK.Enabled = true;

        }

        private void BindLoaiTK()
        {
            txtTenLoaiTK.Clear();
            chkTinhTrang.Checked = false;

        }

        private void btnSuaLTK_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiTK.Text != "" && txtTenLoaiTK.Text != "")
            {

                luuDuLieuLoaiTK();
                if (bus1.SuaTTTK(chon1))
                {
                    dto1 = bus1.LoadDSLoaiTK();
                    dgvDSLoaiTK.DataSource = dto1;
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
                MessageBox.Show("Làm ơn, nhập đầy đủ thông tin Loại Tài Khoản !!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoaLTK_Click(object sender, EventArgs e)
        {
            if (chon1.TinhTrang == 0)
            {
                MessageBox.Show("Loại tài khoản không tồn tại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                luuDuLieuLoaiTK();
                if (bus1.XoaTTTK(chon1))
                {
                    dto1 = bus1.LoadDSLoaiTK();
                    dgvDSLoaiTK.DataSource = dto1;
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaLoaiTK.Clear();
                    txtTenLoaiTK.Clear();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    chon1 = null;
                }
            }

        }

        private void picAnhDaiDien_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Hinh |*.png;*.jpeg;*.jpg";
            DialogResult sp = op.ShowDialog();
            if (sp != DialogResult.Cancel)
            {
                byte[] byt = File.ReadAllBytes(op.FileName);
                MemoryStream ms = new MemoryStream(byt);
                picAnhDaiDien.Image = Image.FromStream(ms);
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk_Click(object sender, EventArgs e)
        {
            dgvDanhSachTK.ClearSelection();
            if (chk.Checked == true)
            {
                List<TaiKhoanDTO> dto = bus.LayDSTaiKhoanxoa();
                dgvDanhSachTK.DataSource = dto;

            }
            else
            {
                List<TaiKhoanDTO> dto = bus.LayDSTaiKhoan();
                dgvDanhSachTK.DataSource = dto;
            }
        }
    }
}
