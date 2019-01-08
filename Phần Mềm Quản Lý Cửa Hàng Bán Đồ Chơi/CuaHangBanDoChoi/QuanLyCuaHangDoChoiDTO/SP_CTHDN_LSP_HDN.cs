using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class SP_CTHDN_LSP_HDN
    {
        string maHDN;

        public string MaHDN
        {
            get { return maHDN; }
            set { maHDN = value; }
        }
        string maSP;

        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        string tenSP;

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }
        string tenLoaiSP;

        public string TenLoaiSP
        {
            get { return tenLoaiSP; }
            set { tenLoaiSP = value; }
        }
        double donGia;

        public double DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        int tongSL;

        public int TongSL
        {
            get { return tongSL; }
            set { tongSL = value; }
        }
        double thanhTien;

        public double ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }
        DateTime ngayNhapHang;

        public DateTime NgayNhapHang
        {
            get { return ngayNhapHang; }
            set { ngayNhapHang = value; }
        }
    }
}
