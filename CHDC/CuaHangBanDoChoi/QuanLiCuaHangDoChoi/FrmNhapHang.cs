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
    public partial class FrmNhapHang : Form
    {
        public static string tdn = string.Empty;
        public static string tendangnhap = string.Empty;
        HDNhapBUS bus = new HDNhapBUS();
        HDNhapDTO chonhdn = null;
        LoaiSPDTO dtoloai = null;
        SanPhamDTO chon = null;
        SanPhamBUS bussp = new SanPhamBUS();
        List<SanPhamDTO> lsdto = new List<SanPhamDTO>();
        List<ChiTietHDNhapDTO> lscthdb = new List<ChiTietHDNhapDTO>();
        ChiTietHDNhapDTO chonct = null;
        ChiTietHDNhapBUS busct = new ChiTietHDNhapBUS();
        NSXDTO chonnsx = null;
        NXSBUS busnsx = new NXSBUS();
        List<NXSBUS> ls = new List<NXSBUS>();
        public FrmNhapHang()
        {
            InitializeComponent();
        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {

            imgnho.ColorDepth = ColorDepth.Depth32Bit;
            imgnho.ImageSize = new System.Drawing.Size(60, 60);
            lsvNhapSP.LargeImageList = imgnho;
            NXSBUS bus2 = new NXSBUS();
            List<NSXDTO> lsdto2 = bus2.LayDSNSX();
            cmbnsx.DataSource = lsdto2;
            cmbnsx.DisplayMember = "TenNSX";
            cmbnsx.ValueMember = "MaNSX";
       
            LoaiSPBUS buss = new LoaiSPBUS();
            List<LoaiSPDTO> lss = buss.layDSLoaiSP();
            cboLoaiSP.DataSource = lss;
            cboLoaiSP.DisplayMember = "TenLoaiSP";
            cboLoaiSP.ValueMember = "MaLoaiSP";
            
            if (!string.IsNullOrEmpty(tendangnhap))
            {
                FrmBanHang.tdn = tendangnhap;
                TaiKhoanBUS bus1 = new TaiKhoanBUS();
                TaiKhoanDTO dto1 = bus1.LayThongTinTK(tendangnhap);
                txtNVLap.Text = dto1.HoTen;
            }
            colXoa.UseColumnTextForButtonValue = true;
        }

        private void LoadDanhSachSPSP()
        {


            SanPhamBUS bus = new SanPhamBUS();
            lsdto = new List<SanPhamDTO>();
            lsdto = bus.LayDSSanPhamTheoLoai(cboLoaiSP.SelectedValue.ToString()).FindAll(o => o.MaLoaiSP == cboLoaiSP.SelectedValue.ToString());

            //colBHTenSP.DataSource = lsdto;
            //colBHTenSP.DisplayMember = "TenSP";
            //colBHTenSP.ValueMember = "MaSP";


            for (int i = 0; i < lsdto.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(lsdto[i].TenSP);
                lvi.SubItems.Add(lsdto[i].TenSP);
                if (File.Exists(lsdto[i].HinhAnh))
                {
                    byte[] byteHA = File.ReadAllBytes(lsdto[i].HinhAnh);
                    MemoryStream ms = new MemoryStream(byteHA);
                    Image img = Image.FromStream(ms);
                    imgnho.Images.Add(img);

                    lvi.ImageIndex = imgnho.Images.Count - 1;
                }
                lsvNhapSP.Items.Add(lvi);
            }
        }

        private void txtTimSP_Enter(object sender, EventArgs e)
        {
            if (txtTimSP.Text == "Nhập tên sản phẩm cần tìm")
            {
                txtTimSP.Text = "";
                txtTimSP.ForeColor = Color.Black;
            }
        }

        private void txtTimSP_Leave(object sender, EventArgs e)
        {
            if (txtTimSP.Text == "")
            {
                txtTimSP.Text = "Nhập tên sản phẩm cần tìm";
                txtTimSP.ForeColor = Color.Gainsboro;
            }
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTimSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            frmthemsanpham fsp = new frmthemsanpham();
            fsp.ShowDialog();

        }

        private void dgvDanhSachSP_SelectionChanged(object sender, EventArgs e)
        {


            if (dgvDanhSachSP.SelectedRows.Count > 0)
            {
                chonct = (ChiTietHDNhapDTO)dgvDanhSachSP.SelectedRows[0].DataBoundItem;
            }
            else
            {
                chon = null;
            }
            Bindnhaphang();

        }

        private void Bindnhaphang()
        {
            if (chonct != null)
            {


            }
        }



        private void lsvNhapSP_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lsvNhapSP.SelectedItems.Count > 0)
            {
                dgvDanhSachSP.AutoGenerateColumns = false;
                ListViewItem lviChon = lsvNhapSP.SelectedItems[0];
                chon = lsdto.Find(o => o.TenSP == lviChon.SubItems[1].Text);
                ChiTietHDNhapDTO ct = lscthdb.Find(o => o.MaSP == chon.MaSP);
                if (ct != null) //Đã tồn tại
                {
                    ct.SoLuong += 1;

                }
                else
                {
                    ct = new ChiTietHDNhapDTO();
                    ct.MaSP = chon.MaSP.ToString();
                    ct.TenSP = chon.TenSP.ToString();
                    ct.SoLuong = 1;
                    ct.DonGia = chon.Gia * ct.SoLuong;
                    lscthdb.Add(ct);

                }
                txtTongTien.Text = lscthdb.Sum(o => o.ThanhTien).ToString();
                txtTongSL.Text = lscthdb.Sum(o => o.SoLuong).ToString();


                dgvDanhSachSP.DataSource = null;
                dgvDanhSachSP.DataSource = lscthdb;
            }
            else
            {
                chon = null;
            }
            BindingChiTiet();
        }
        private void BindingChiTiet()
        {
            if (chonct != null)
            {
                chonct = new ChiTietHDNhapDTO();
            }



        }

        private void btnTKHDB_Click(object sender, EventArgs e)
        {

            loadtheoten();
        }

        private void loadtheoten()
        {

            SanPhamBUS bus = new SanPhamBUS();
            lsdto = bus.TimKiemTheoMa(txtTimSP.Text);
            lsdto = new List<SanPhamDTO>();
            lsdto = bus.TimKiemTheoMa(txtTimSP.Text).FindAll(o => o.TinhTrang == 1);
            lsvNhapSP.Items.Clear();
            //colBHTenSP.DataSource = lsdto;
            //colBHTenSP.DisplayMember = "TenSP";
            //colBHTenSP.ValueMember = "MaSP";

            for (int i = 0; i < lsdto.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(lsdto[i].TenSP);
                lvi.SubItems.Add(lsdto[i].TenSP);
                if (File.Exists(lsdto[i].HinhAnh))
                {
                    byte[] byteHA = File.ReadAllBytes(lsdto[i].HinhAnh);
                    MemoryStream ms = new MemoryStream(byteHA);
                    Image img = Image.FromStream(ms);
                    imgnho.Images.Add(img);

                    lvi.ImageIndex = imgnho.Images.Count - 1;
                }
                else
                {
                    lsdto[i].HinhAnh = null;
                }
                lsvNhapSP.Items.Add(lvi);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            
                if (lscthdb.Count > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Bạn có muốn nhập hàng không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))


                    if (chonhdn == null)
                    {
                        chonhdn = new HDNhapDTO();
                    }
                    string a = bus.LayMaHDNTiepTheo();
                    chonhdn.MaHDNhap = a;
                    chonhdn.NgayNhapHang = DateTime.Now;
                    chonhdn.TongTien = decimal.Parse(txtTongTien.Text.ToString());
                    chonhdn.NSX = cmbnsx.SelectedValue.ToString();

                    chonhdn.TinhTrang = 1;
                    if (!string.IsNullOrEmpty(tendangnhap))
                    {
                        FrmNhapHang.tdn = tendangnhap;
                        TaiKhoanBUS bus1 = new TaiKhoanBUS();
                        TaiKhoanDTO dto1 = bus1.LayThongTinTK(tendangnhap);
                        chonhdn.NVLap = dto1.MaNV;
                    }

                    if (bus.ThemHDN(chonhdn))
                    {


                        //Lưu chi hóa đơn
                        foreach (ChiTietHDNhapDTO ct in lscthdb)
                        {

                            chonct = new ChiTietHDNhapDTO();
                            ct.MaHDNhap = a;
                            //ct.MaSP = chonct.MaSP;
                            if (ct.MaSP == chonct.MaSP)
                            {
                                ct.SoLuong += 1;
                            }
                            else
                            {
                                ct.SoLuong += 0;
                            }
                            ct.TenSP = ct.TenSP.ToString();
                            ct.DonGia = ct.DonGia;
                            busct.ThemCTHDN(ct);
                            bussp.SuaNhapSoLuong(ct.SoLuong.ToString(), ct.MaSP.ToString());

                        }

                        MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmSanPham f = new FrmSanPham();
                        f.conca();
                        FrmBaoCao fbc = new FrmBaoCao();
                        fbc.LoadHoaDonNhapXuat(a);
                        fbc.Show();
                        dgvDanhSachSP.DataSource = null;

                    }
                    lscthdb.Clear();
                    txtTongSL.Text = "";
                    txtTongTien.Text = "";


                }
                
            
        else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        }

        private void cmbnsx_Click(object sender, EventArgs e)
        {
            NXSBUS bus2 = new NXSBUS();
            List<NSXDTO> lsdto2 = bus2.LayDSNSX();
            cmbnsx.DataSource = lsdto2;
            cmbnsx.DisplayMember = "MaNSX";
            cmbnsx.ValueMember = "MaNSX";
        }

        private void btnTang_Click(object sender, EventArgs e)
        {


            
            ChiTietHDNhapDTO ct = lscthdb.Find(o => o.MaSP.ToString() == chonct.MaSP);
            if (lscthdb.Count > 0)
            {
                if (ct == null)
                {
                    ct = new ChiTietHDNhapDTO();
                }
                if (ct != null)
                {
                    ct.SoLuong += int.Parse(numsl.Text.ToString());

                }
                txtTongTien.Text = lscthdb.Sum(o => o.ThanhTien).ToString();
                txtTongSL.Text = lscthdb.Sum(o => o.SoLuong).ToString();
                dgvDanhSachSP.DataSource = null;
                dgvDanhSachSP.DataSource = lscthdb;
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
           
        



        }

        private void btnGiam_Click(object sender, EventArgs e)
        {

            ChiTietHDNhapDTO ct = lscthdb.Find(o => o.MaSP == chonct.MaSP);
            if (lscthdb.Count > 0)
            {
                if (ct == null)
                {
                    ct = new ChiTietHDNhapDTO();
                }
                
                if (ct != null)
                {
                    
                    
                    int kq =ct.SoLuong - int.Parse(numsl.Text.ToString());
                    if(kq<0)
                    {
                        lscthdb.Remove(ct);
                    }
                }
                txtTongTien.Text = lscthdb.Sum(o => o.ThanhTien).ToString();
                txtTongSL.Text = lscthdb.Sum(o => o.SoLuong).ToString();

                dgvDanhSachSP.DataSource = null;
                dgvDanhSachSP.DataSource = lscthdb;

                if (ct.SoLuong == 0)
                {
                    if (dgvDanhSachSP.SelectedRows.Count > 0)
                    {
                        ChiTietHDNhapDTO ctChon = (ChiTietHDNhapDTO)dgvDanhSachSP.CurrentRow.DataBoundItem;
                        DialogResult dr = MessageBox.Show("Bạn có muốn xóa sản phẩm này khỏi hóa đơn?", "Hóa đơn", MessageBoxButtons.YesNo);

                        if (dr == DialogResult.Yes)
                        {

                            lscthdb.Remove(ctChon);
                            txtTongTien.Text = lscthdb.Sum(o => o.ThanhTien).ToString();
                            txtTongSL.Text = lscthdb.Sum(o => o.SoLuong).ToString();
                            dgvDanhSachSP.DataSource = null;
                            dgvDanhSachSP.DataSource = lscthdb;
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa có sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnThemS_Click(object sender, EventArgs e)
        {
            frmthemnsx fsp = new frmthemnsx();
            fsp.ShowDialog();
        }
        private void dgvDanhSachSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            if (dgvDanhSachSP.Columns[e.ColumnIndex].Name == "colXoa")
            {
                string masp = dgvDanhSachSP.SelectedRows[0].Cells["colMaSP"].Value.ToString();
                lscthdb.RemoveAt((int)(lscthdb.FindIndex(o => o.MaSP == masp)));
                txtTongTien.Text = lscthdb.Sum(o => o.ThanhTien).ToString();
                txtTongSL.Text = lscthdb.Sum(o => o.SoLuong).ToString();
                dgvDanhSachSP.DataSource = null;
                dgvDanhSachSP.DataSource = lscthdb;


                //tongtien -= thanhtien;
            }
        }

        private void cboLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsvNhapSP.Items.Clear();
            LoadDanhSachSPSP();
        }




    }
}
