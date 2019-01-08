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
    public partial class FrmBanHang : Form
    {
        HDBanBUS bushdb = new HDBanBUS();
        
        HDBanDTO chonhdb = null;
        public static string tdn = string.Empty;
        public static string tendangnhap = string.Empty;
        List<ChiTietHDBanDTO> lscthdb = new List<ChiTietHDBanDTO>();
        List<SanPhamDTO> lsdto = new List<SanPhamDTO>();
        ChiTietHDBanBUS bus = new ChiTietHDBanBUS();
        SanPhamDTO chon = null;
        ChiTietHDBanDTO chonct = null;
        SanPhamBUS bussp = new SanPhamBUS();


        public FrmBanHang()
        {
            InitializeComponent();
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {

            imgnho.ColorDepth = ColorDepth.Depth32Bit;
            imgnho.ImageSize = new System.Drawing.Size(60, 60);
            lsvHienThiDSSP.LargeImageList = imgnho;
            LoadDanhSachSP();

            if (!string.IsNullOrEmpty(tendangnhap))
            {
                FrmBanHang.tdn = tendangnhap;
                TaiKhoanBUS bus1 = new TaiKhoanBUS();
                TaiKhoanDTO dto1 = bus1.LayThongTinTK(tendangnhap);
                txtNVL.Text = dto1.HoTen;
            }
            colXoa.UseColumnTextForButtonValue = true;


        }

        private void LoadDanhSachSP()
        {
            //KhachHangBUS BUS = new KhachHangBUS();
            //List<KhachHangDTO> lsdtokh = BUS.LAYDSKH();
            //cmbkh.DataSource = lsdtokh;
            //cmbkh.DisplayMember = "MaKH";
            //cmbkh.ValueMember = "MaKH";

            SanPhamBUS bus = new SanPhamBUS();
            lsdto = bus.LayDSSanPham();
            lsdto = new List<SanPhamDTO>();
            lsdto = bus.LayDSSanPham().FindAll(o => o.TinhTrang == 1);

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
                lsvHienThiDSSP.Items.Add(lvi);
            }
        }

        private void lsvHienThiDSSP_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lsvHienThiDSSP.SelectedItems.Count > 0)
            {
                dgvDanhSachSP.AutoGenerateColumns = false;
                ListViewItem lviChon = lsvHienThiDSSP.SelectedItems[0];
                chon = lsdto.Find(o => o.TenSP == lviChon.SubItems[1].Text);
                ChiTietHDBanDTO ct = lscthdb.Find(o => o.MaSP == chon.MaSP);
                if (ct != null) //Đã tồn tại
                {
                    ct.SoLuong += 1;


                }
                else
                {
                    ct = new ChiTietHDBanDTO();
                    ct.TenSP = chon.TenSP.ToString();
                    ct.MaSP = chon.MaSP.ToString();
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
                chonct = new ChiTietHDBanDTO();
            }



        }



        private void btnTang_Click(object sender, EventArgs e)
        {


            ChiTietHDBanDTO ct = lscthdb.Find(o => o.MaSP == chonct.MaSP);
            if (lscthdb.Count > 0)
            {
                
                if (ct == null)
                {
                    ct = new ChiTietHDBanDTO();
                }
                if (ct != null)
                {
                    int kq=ct.SoLuong + int.Parse(numsl.Text.ToString());
                    if ( kq > chon.SoLuongTonKho)
                    {
                        MessageBox.Show("Số lượng tồn kho :" + chon.SoLuongTonKho ,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ct.SoLuong += int.Parse(numsl.Text.ToString());
                    }
                    
                   
                    
                }
                txtTongTien.Text = lscthdb.Sum(o => o.ThanhTien).ToString();
                txtTongSL.Text = lscthdb.Sum(o => o.SoLuong).ToString();
                dgvDanhSachSP.DataSource = null;
                dgvDanhSachSP.DataSource = lscthdb;

            }
            else
            {
                MessageBox.Show("Không có sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {

            if (lscthdb.Count > 0)
            {



                ChiTietHDBanDTO ct = lscthdb.Find(o => o.MaSP == chonct.MaSP);
                if (lscthdb.Count > 0)
                {

                    if (ct == null)
                    {
                        ct = new ChiTietHDBanDTO();
                    }
                    if (ct != null)
                    {
                        int kq = ct.SoLuong - int.Parse(numsl.Text.ToString());
                      
                    }
                }
                txtTongTien.Text = lscthdb.Sum(o => o.ThanhTien).ToString();


                dgvDanhSachSP.DataSource = null;
                dgvDanhSachSP.DataSource = lscthdb;
                if (ct.SoLuong <= 0)
                {
                    if (dgvDanhSachSP.SelectedRows.Count > 0)
                    {
                        ChiTietHDBanDTO ctChon = (ChiTietHDBanDTO)dgvDanhSachSP.CurrentRow.DataBoundItem;
                        DialogResult dr = MessageBox.Show("Bạn có muốn xóa sản phẩm này khỏi hóa đơn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                MessageBox.Show("Không có sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dgvDanhSachSP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachSP.SelectedRows.Count > 0)
            {
                chonct = (ChiTietHDBanDTO)dgvDanhSachSP.SelectedRows[0].DataBoundItem;
            }
            else
            {
                chonct = null;
            }

        }




        private void btnThanhToan_Click(object sender, EventArgs e)
        {


            if (lscthdb.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn thanh toán không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {

                    if (cmbkh.SelectedValue == null || txtTienKhachTra.Text == "")
                    {
                        MessageBox.Show("Chưa nhập khách hàng hoặc tiền thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        if (chonhdb == null)
                        {
                            chonhdb = new HDBanDTO();
                        }
                        string a = bushdb.LayMaHDBTiepTheo();
                        chonhdb.MaHDBan = a;
                        chonhdb.NgayLapHD = DateTime.Now;
                        chonhdb.TongTien = decimal.Parse(txtTongTien.Text.ToString());
                        chonhdb.TienKhachTra = decimal.Parse(txtTienKhachTra.Text.ToString());
                        chonhdb.TienDu = decimal.Parse(txtTienDu.Text.ToString());
                        chonhdb.MaKH = cmbkh.SelectedValue.ToString();

                        chonhdb.TinhTrang = 1;
                        if (!string.IsNullOrEmpty(tendangnhap))
                        {
                            FrmBanHang.tdn = tendangnhap;
                            TaiKhoanBUS bus1 = new TaiKhoanBUS();
                            TaiKhoanDTO dto1 = bus1.LayThongTinTK(tendangnhap);
                            chonhdb.NVLapHD = dto1.MaNV;
                        }

                        if (bushdb.ThemHDB(chonhdb))
                        {


                            //Lưu chi hóa đơnV
                            foreach (ChiTietHDBanDTO ct in lscthdb)
                            {

                                chonct = new ChiTietHDBanDTO();
                                ct.MaHDBan = a;
                                // ct.MaSP = chonct.MaSP;
                                if (ct.MaSP == chonct.MaSP)
                                {
                                    ct.SoLuong += 1;
                                }
                                else
                                {
                                    ct.SoLuong += 0;
                                }
                                ct.DonGia = ct.DonGia;
                                bus.ThemCTHDB(ct);
                                bussp.SuaSoLuong(ct.SoLuong.ToString(), ct.MaSP.ToString());

                            }

                            MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lscthdb.Clear();
                            dgvDanhSachSP.DataSource = null;
                            txtTongSL.Text = "";
                            txtTongTien.Text = "";
                            txtTienKhachTra.Text = "";
                            txtTienDu.Text = "";
                            numsl.Text = "1";
                            FrmBaoCao fbc = new FrmBaoCao();
                            fbc.LoadHoaDonBanXuat(a);
                            fbc.Show();
                            dgvDanhSachSP.DataSource = null;

                        }
                    }
                  
                }
                

            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
        //private void luuDuLieuhdb()
        //{

        //    if (chonhdb == null)
        //    {
        //        chonhdb = new HDBanDTO();
        //    }
        //    string a = bushdb.LayMaHDBTiepTheo();
        //    chonhdb.MaHDBan = a;
        //    chonhdb.NgayLapHD = DateTime.Now;
        //    chonhdb.TongTien = decimal.Parse(txtTongTien.Text.ToString());
        //    chonhdb.MaKH = cmbkh.SelectedValue.ToString();
        //    chonhdb.TinhTrang = 1;
        //    chonhdb.TienKhachTra = decimal.Parse(txtTienKhachTra.Text.ToString());
        //    chonhdb.TienDu = decimal.Parse(txtTienDu.Text.ToString());
        //    if (!string.IsNullOrEmpty(tendangnhap))
        //    {
        //        FrmBanHang.tdn = tendangnhap;
        //        TaiKhoanBUS bus1 = new TaiKhoanBUS();
        //        TaiKhoanDTO dto1 = bus1.LayThongTinTK(tendangnhap);
        //        chonhdb.NVLapHD = dto1.MaNV;
        //    }
        //}
        private void txtTienDu_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnkh_Click(object sender, EventArgs e)
        {
            frmthemkhachhang f = new frmthemkhachhang();
            f.Show();
        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //    int t = 0;
            //    //chon = lsdto.Find(o => o.TenSP == txtTKtheoTen.Text);
            //    //LoadDanhSachSP();
            //    for (int i = 0; i < lsvHienThiDSSP.Items.Count; i++)
            //    {
            //        if (lsvHienThiDSSP.Items[i].SubItems[0].Text.Trim() == txtTKtheoTen.Text.Trim())
            //        {
            //            //t = 1;
            //            break;
            //        }
            //    }
            if (txtGiaTu.Text == "" || txtGiaDen.Text == "")
            {
                LoadSPTheoTen();
            }
            else if (txtTKtheoTen.Text == "")
            {
                LoadSPTheoGia();
            }
            else
            {
                LoadSPTheoGiaTen();
            }

        }
        // vây lây viêt cái Load thôilà đc  u722 hồi sáng t viết thiếu
        private void LoadSPTheoTen()
        {
            SanPhamBUS bus = new SanPhamBUS();
            lsdto = bus.TimKiemTheoMa(txtTKtheoTen.Text);
            lsdto = new List<SanPhamDTO>();
            lsdto = bus.TimKiemTheoMa(txtTKtheoTen.Text).FindAll(o => o.TinhTrang == 1);
            lsvHienThiDSSP.Items.Clear();
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
                lsvHienThiDSSP.Items.Add(lvi);
            }
        }
        private void LoadSPTheoGia()
        {
            SanPhamBUS bus = new SanPhamBUS();
            lsdto = bus.TKTHEOGIA(txtGiaTu.Text, txtGiaDen.Text);
            lsdto = new List<SanPhamDTO>();
            lsdto = bus.TKTHEOGIA(txtGiaTu.Text, txtGiaDen.Text).FindAll(o => o.TinhTrang == 1);
            lsvHienThiDSSP.Items.Clear();
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
                lsvHienThiDSSP.Items.Add(lvi);
            }
        }

        private void LoadSPTheoGiaTen()// theo giá  với tên luôn ok
        {
            SanPhamBUS bus = new SanPhamBUS();
            lsdto = bus.TKTHEOGIAten(txtTKtheoTen.Text, txtGiaTu.Text, txtGiaDen.Text);
            lsdto = new List<SanPhamDTO>();
            lsdto = bus.TKTHEOGIAten(txtTKtheoTen.Text, txtGiaTu.Text, txtGiaDen.Text).FindAll(o => o.TinhTrang == 1);
            lsvHienThiDSSP.Items.Clear();
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
                lsvHienThiDSSP.Items.Add(lvi);
            }

        }

        private void cmbkh_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void cmbkh_Click(object sender, EventArgs e)
        {
            KhachHangBUS BUS = new KhachHangBUS();
            List<KhachHangDTO> lsdtokh = BUS.LAYDSKH();
            cmbkh.DataSource = lsdtokh;
            cmbkh.DisplayMember = "MaKH";
            cmbkh.ValueMember = "MaKH";
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTienKhachTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtTongTien.Text != "")
                {
                    string tt = (txtTongTien.Text.ToString());
                    string td = (txtTienDu.Text.ToString());
                    string tkt = (txtTienKhachTra.Text.ToString());

                    decimal a = decimal.Parse(tkt);
                    decimal b = decimal.Parse(tt);

                    decimal c = Math.Abs(a - b);
                    Math.Abs(c);
                    txtTienDu.Text = c.ToString();

                    decimal tdd = decimal.Parse(txtTienDu.Text.ToString());
                    if (b > a)
                    {
                        MessageBox.Show("Khách hàng còn thiếu " + tdd + " VND ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
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

        private void txtGiaTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

