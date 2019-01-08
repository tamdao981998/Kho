using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangDoChoiBUS;
using QuanLyCuaHangDoChoiDTO;

namespace QuanLiCuaHangDoChoi
{
    public partial class FrmBaoCaoThongKe : Form
    {
        public FrmBaoCaoThongKe()
        {
            InitializeComponent();
        }
        


        private void FrmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            LoaiSPBUS bus = new LoaiSPBUS();
            cboTheoLoaiSP.DisplayMember = "TenLoaiSP";
            cboTheoLoaiSP.ValueMember = "MaLoaiSP";
            cboTheoLoaiSP.DataSource = bus.layDSLoaiSP();
            //LoadMaNV
            TaiKhoanBUS tk = new TaiKhoanBUS();
            cboDSMaNV.DisplayMember = "MaNV";
            cboDSMaNV.ValueMember = "MaNV";
            cboDSMaNV.DataSource = tk.LayDSTaiKhoan();

        }

        private void btnXemBaoCao_Click_1(object sender, EventArgs e)
        {
            FrmBaoCao fbc = new FrmBaoCao();

            if (rdbDSSanPham.Checked)
            {
                fbc.LoadTatCaDSSanPham();
            }
            else if (rdbLoaiSP.Checked)
            {
                fbc.LoadSanPhamTheoLoai((string)cboTheoLoaiSP.SelectedValue);
            }
            else if (rdbGomNhomSP.Checked)
            {
                fbc.LoadGomNhomSanPhamTheoLoai();
            }
            else if (rdbDSKhachHang.Checked)
            {
                fbc.LoadDanhSachKhacHang();
            }
            else if (rdbDSNSX.Checked)
            {
                fbc.LoadDanhSachNSX();
            }

            else if (rdbTaiKhoan.Checked)
            {
                fbc.LoadDanhSachTK();
            }
            else if(rdbTSHDB.Checked)
            {
                fbc.LoadDanhSachHoaDonBanTheoTime(dtpThoiGianTu.Value.Date, dtpThoiGianDen.Value.Date);
            }
            else if (rdbTongSoHDNhuy.Checked)
            {
                fbc.LoadDanhSachHoaDonNhapHuy(dtpThoiGianTu.Value.Date, dtpThoiGianDen.Value.Date);
            }
            else if(rdbTSHDN.Checked)
            {
                fbc.LoadDanhSachHoaDonNhap(dtpThoiGianTu.Value.Date, dtpThoiGianDen.Value.Date);
            }
            else if (rdbTongSoHDBhuy.Checked)
            {
                fbc.LoadDanhSachHoaDonBanHuy(dtpThoiGianTu.Value.Date, dtpThoiGianDen.Value.Date);
            }
            else if (rdbSPBanChayNhat.Checked)
            {

                fbc.LoadSanPhamBanChayNhat(dtpThoiGianTu.Value.Date, dtpThoiGianDen.Value.Date);
            }
            else if(rdbTongDoanhThuNV.Checked)
            {
                fbc.LoadDSTongDoanhThuTheoNV(cboDSMaNV.SelectedValue.ToString(),dtpThoiGianTu.Value.Date, dtpThoiGianDen.Value.Date);
            }
            else if (rdbTongDoanhThu.Checked)
            {
                fbc.LoadTongDoanhThuTheoThang(dtpThoiGianTu.Value.Date, dtpThoiGianDen.Value.Date);
            }
            fbc.Show();
            
        }
    }
}
