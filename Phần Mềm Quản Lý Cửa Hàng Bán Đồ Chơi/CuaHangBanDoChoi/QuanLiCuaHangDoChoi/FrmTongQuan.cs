using Microsoft.Reporting.WinForms;
using QuanLyCuaHangDoChoiBUS;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCuaHangDoChoi
{
    public partial class FrmTongQuan : Form
    {
        public FrmTongQuan()
        {
            InitializeComponent();
        }

        private void FrmTongQuan_Load(object sender, EventArgs e)
        {
	    HDBanBUS bus = new HDBanBUS();
            HDBanDTO dto = bus.DemMaHDBan();
            txtDemHDB.Text = dto.MaHDBan;
            //Load SO HD Nhap
            HDNhapBUS bus1 = new HDNhapBUS();
            HDNhapDTO dto1 = bus1.DemMaHDNhap();
            txtDemHDN.Text = dto1.MaHDNhap;
            //Load TongSP Da Ban
            SanPhamBUS bus2 = new SanPhamBUS();
            SP_CTHDBDTO dto2 = bus2.TongSoSPBan();
            txtTongSPBan.Text = dto2.SLSP.ToString();
            //Load TongSP Da Nhap
            SanPhamBUS bus3 = new SanPhamBUS();
            SP_CTHDN_LSP_HDN dto3 = bus3.TongSoSPNhap();
            txtTongSPDaNhap.Text = dto3.TongSL.ToString();
            //Load HD huy
            HDBanBUS bus4 = new HDBanBUS();
            HDBanDTO dto4 = bus4.DemSoHDHuy();
            txtTongSPDaNhap.Text = dto4.MaHDBan.ToString();
            //loadTongDoanhThu
            HDBanBUS bus5 = new HDBanBUS();
            HDBanDTO dto5 = bus5.TongDoanhThuTrongNgay();
            txtTongDT.Text = dto5.TongTien.ToString("#.##");

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           // DoThiSPBanChayNhat();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void txtTongDT_TextChanged(object sender, EventArgs e)
        {

        }
       // public void DoThiSPBanChayNhat()
        //{
        //    SanPhamBUS bus = new SanPhamBUS();
        //    List<SP_CTHDBDTO> spb = bus.SPBanChayNhat();
        //    reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLiCuaHangDoChoi.rptSPBanChayNhat.rdlc";

        //    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsSPBanChayNhat", spb));

        //    reportViewer1.RefreshReport();
        //}
    }
}
