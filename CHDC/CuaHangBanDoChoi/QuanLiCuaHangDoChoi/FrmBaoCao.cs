using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyCuaHangDoChoiBUS;
using QuanLyCuaHangDoChoiDTO;
namespace QuanLiCuaHangDoChoi
{
    public partial class FrmBaoCao : Form
    {
        public FrmBaoCao()
        {
            InitializeComponent();
        }

        private void FrmBaoCao_Load(object sender, EventArgs e)
        {

            this.rpvBaoCao.RefreshReport();
        }

        private void rpvBaoCao_Load(object sender, EventArgs e)
        {

        }
        public void LoadTatCaDSSanPham()
        {
            SanPhamBUS bus = new SanPhamBUS();
            List<SanPhamDTO> lstsp = bus.LayDSSanPham();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptLoadDSSanPham.rdlc";
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsSanPham", lstsp));
            rpvBaoCao.RefreshReport();
        }

        private void rpvDanhSachSP_Load(object sender, EventArgs e)
        {

        }
        public void LoadSanPhamTheoLoai(string maLoai)
        {
            SanPhamBUS bus = new SanPhamBUS();
            List<SanPhamDTO> lsp = bus.LayDSSanPhamTheoLoai(maLoai);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptTheoLoaiSanPham.rdlc";
            LoaiSPBUS lspbus = new LoaiSPBUS();
            LoaiSPDTO l = lspbus.LayLoaiSanPham(maLoai);
            rpvBaoCao.LocalReport.SetParameters(new ReportParameter("pMaLoai", l.TenLoaiSP));
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsLoaiSP", lsp));
        }
        public void LoadGomNhomSanPhamTheoLoai()
        {
            LoaiSPBUS lspbus = new LoaiSPBUS();
            List<LoaiSPDTO> lst = lspbus.layDSLoaiSP();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptTheoGomNhomLSP.rdlc";
            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsLoaiSP", lst));
            rpvBaoCao.RefreshReport();
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            string maloai = e.Parameters["pLoaiSP"].Values[0];
            SanPhamBUS bus = new SanPhamBUS();
            List<SanPhamDTO> lstsp = bus.LayDSSanPhamTheoLoai(maloai);
            e.DataSources.Add(new ReportDataSource("dsDSSanPham", lstsp));
        }
        public void LoadDanhSachKhacHang()
        {
            KhachHangBUS bus = new KhachHangBUS();
            List<KhachHangDTO> lstkh = bus.LAYDSKH();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptTheoDSKhachHang.rdlc";
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsDSKhachHang", lstkh));
            rpvBaoCao.RefreshReport();
        }
        public void LoadDanhSachNSX()
        {
            NXSBUS bus = new NXSBUS();
            List<NSXDTO> nsx = bus.LayDSNSX();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptTheoDanhSachNSX.rdlc";
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsDSNSX", nsx));
            rpvBaoCao.RefreshReport();
        }
        public void LoadDanhSachTK()
        {
            TaiKhoanBUS bus = new TaiKhoanBUS();
            List<TaiKhoanDTO> tk = bus.LayDSTaiKhoan();
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptTheoDanhSachTK.rdlc";
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsTaiKhoan", tk));
            rpvBaoCao.RefreshReport();
        }
        public void LoadDanhSachHoaDonNhap(DateTime TimeTu, DateTime TimeDen)
        {
            HDNhapBUS bus = new HDNhapBUS();
            List<TK_HDNhap_NSXDTO> hdn = bus.LAYDSHDNhapTheoNgay(TimeTu, TimeDen);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptTheoTongSoHDNhap.rdlc";

            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessingHDN);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsDSHDN", hdn));
            rpvBaoCao.RefreshReport();
        }

        void LocalReport_SubreportProcessingHDN(object sender, SubreportProcessingEventArgs e)
        {
            string mahdn = e.Parameters["pMaHDN"].Values[0];
            ChiTietHDNhapBUS bus = new ChiTietHDNhapBUS();
            List<ChiTietHDNhapDTO> cthdn = bus.LOADCTHDN(mahdn);
            e.DataSources.Add(new ReportDataSource("dsCTHDN", cthdn));
        }
        public void LoadDanhSachHoaDonBanTheoTime(DateTime TimeTu, DateTime TimeDen)
        {
            HDBanBUS bus = new HDBanBUS();
            List<TK_KH_HDBDTOcs> hdb = bus.LAYHDBanTheoNgay(TimeTu, TimeDen);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptTheoTongSoHDBan.rdlc";

            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessingHDB); ;
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsDSHDB", hdb));

            rpvBaoCao.RefreshReport();
        }

        void LocalReport_SubreportProcessingHDB(object sender, SubreportProcessingEventArgs e)
        {
            string mahdb = e.Parameters["pMaHD"].Values[0];
            ChiTietHDBanBUS bus = new ChiTietHDBanBUS();
            List<ChiTietHDBanDTO> cthdb = bus.LOADCTHDB(mahdb);
            e.DataSources.Add(new ReportDataSource("dsDSCTHDB", cthdb));
        }
        public void LoadDanhSachHoaDonNhapHuy(DateTime TimeTu, DateTime TimeDen)
        {
            HDNhapBUS bus = new HDNhapBUS();
            List<TK_HDNhap_NSXDTO> hdn = bus.LayDanHSachHDNHuy(TimeTu, TimeDen);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptTheoTongSoHDNHuy.rdlc";

            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessingHDNHuy);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsDSHDNHuy", hdn));
            rpvBaoCao.RefreshReport();
        }



        private void LocalReport_SubreportProcessingHDNHuy(object sender, SubreportProcessingEventArgs e)
        {
            string mahdn = e.Parameters["pMaHDN"].Values[0];
            ChiTietHDNhapBUS bus = new ChiTietHDNhapBUS();
            List<ChiTietHDNhapDTO> cthdn = bus.LOADCTHDN(mahdn);
            e.DataSources.Add(new ReportDataSource("dsCTHDN", cthdn));
        }
        public void LoadDSTongDoanhThuTheoNV(string manv, DateTime TimeTu, DateTime TimeDen)
        {
            HDBanBUS bus = new HDBanBUS();
            List<TK_HDB_CTHDBDTO> tdt = bus.LayTongDoanhThuTheoNhanVien(manv, TimeTu, TimeDen);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptTongDoanhThuTheoNhanVien.rdlc";
            TaiKhoanBUS manvbus = new TaiKhoanBUS();
            TaiKhoanDTO dto = manvbus.LayDSTKTheoMaNV(manv);
            rpvBaoCao.LocalReport.SetParameters(new ReportParameter("pMaNV", dto.HoTen));
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsTongDoanhThu", tdt));
            rpvBaoCao.RefreshReport();
        }
        public void LoadDanhSachHoaDonBanHuy(DateTime TimeTu, DateTime TimeDen)
        {
            HDBanBUS bus = new HDBanBUS();
            List<TK_KH_HDBDTOcs> hdb = bus.LayDSHoaDonBanHuy(TimeTu, TimeDen);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptTheoTongSoHDBHuy.rdlc";
            rpvBaoCao.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessingHDBHuy);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsDSHDBHuy", hdb));
            rpvBaoCao.RefreshReport();
        }

        private void LocalReport_SubreportProcessingHDBHuy(object sender, SubreportProcessingEventArgs e)
        {
            string mahdb = e.Parameters["pMaHD"].Values[0];
            ChiTietHDBanBUS bus = new ChiTietHDBanBUS();
            List<ChiTietHDBanDTO> cthdb = bus.LOADCTHDB(mahdb);
            e.DataSources.Add(new ReportDataSource("dsDSCTHDB", cthdb));

        }

        public void LoadDanhSachSPBan(DateTime TimeTu, DateTime TimeDen)
        {
            SanPhamBUS bus = new SanPhamBUS();
            List<SP_CTHDBDTO> spb = bus.LayDSSPBan(TimeTu, TimeDen);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptTheoTongSoSanPhamDaBan.rdlc";

            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsDSSPBan", spb));

            rpvBaoCao.RefreshReport();
        }
        public void LoadDanhSachSPNhap(DateTime TimeTu, DateTime TimeDen)
        {
            SanPhamBUS bus = new SanPhamBUS();
            List<SP_CTHDBDTO> spn = bus.LayDSSPDaNhap(TimeTu, TimeDen);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptTheoTongSoSPNhap.rdlc";

            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsDSSPN", spn));
            rpvBaoCao.RefreshReport();
        }
        public void LoadHoaDonBanXuat(string mahd)
        {
            HDBanBUS bus = new HDBanBUS();
            List<TK_KH_HDBDTOcs> hdb = bus.LAYDSHDBanTheoMaHD(mahd);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.RptHoaDonBan.rdlc";
            rpvBaoCao.LocalReport.SubreportProcessing+=new SubreportProcessingEventHandler(LocalReport_SubreportProcessingHDBX);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsHDBXuat", hdb));
            rpvBaoCao.RefreshReport();
        }

        private void LocalReport_SubreportProcessingHDBX(object sender, SubreportProcessingEventArgs e)
        {
            string mahdb = e.Parameters["pMaHDB"].Values[0];
            ChiTietHDBanBUS bus = new ChiTietHDBanBUS();
            List<SP_CTHDBDTO> hdb = bus.LOADCTHDXUAT(mahdb);
            e.DataSources.Add(new ReportDataSource("dsCTHDBX", hdb));

        }
        public void LoadTongDoanhThuTheoThang(DateTime TimeTu, DateTime TimeDen)
        {
            HDBanBUS bus = new HDBanBUS();
            List<HDBanDTO> tdt = bus.LayTongDoanhThuTheoThang(TimeTu, TimeDen);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptTongDoanhThuTheoThang.rdlc";

            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsDoanhThu", tdt));

            rpvBaoCao.RefreshReport();
        }
        public void LoadSanPhamBanChayNhat(DateTime TimeTu, DateTime TimeDen)
        {
            SanPhamBUS bus = new SanPhamBUS();
            List<SP_CTHDBDTO> spb = bus.SPBanChayNhat(TimeTu, TimeDen);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptSPBanChayNhat.rdlc";

            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsSPBanChayNhat", spb));

            rpvBaoCao.RefreshReport();
        }
        public void LoadHoaDonNhapXuat(string mahd)
        {
            HDNhapBUS bus = new HDNhapBUS();
            List<TK_HDNhap_NSXDTO> hdn = bus.LAYDSHDNhapTheoMaHD(mahd);
            rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptHoaDonNhap.rdlc";
            rpvBaoCao.LocalReport.SubreportProcessing +=new SubreportProcessingEventHandler(LocalReport_SubreportProcessingXuatHDN);
            rpvBaoCao.LocalReport.DataSources.Add(new ReportDataSource("dsHDN", hdn));
            rpvBaoCao.RefreshReport();
        }

        private void LocalReport_SubreportProcessingXuatHDN(object sender, SubreportProcessingEventArgs e)
        {
            string mahdn = e.Parameters["pMaHDN"].Values[0];
            ChiTietHDNhapBUS bus = new ChiTietHDNhapBUS();
            List<SP_CTHDN_LSP_HDN> hdn = bus.LOADCTHDXUAT(mahdn);
            e.DataSources.Add(new ReportDataSource("dsXuatCTHDN", hdn));  
        }
    }
}
