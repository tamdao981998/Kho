using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class TK_HDNhap_NSXDTO
    {
        string hoTenNV;

        public string HoTenNV
        {
            get { return hoTenNV; }
            set { hoTenNV = value; }
        }
        string hoTenNSX;

        public string HoTenNSX
        {
            get { return hoTenNSX; }
            set { hoTenNSX = value; }
        }

       
        string maHDNhap;

        public string MaHDNhap
        {
            get { return maHDNhap; }
            set { maHDNhap = value; }
        }


        DateTime ngayNhapHang;

        public DateTime NgayNhapHang
        {
            get { return ngayNhapHang; }
            set { ngayNhapHang = value; }
        }

        
        double tongTien;

        public double TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        string maNSX;

        public string MaNSX
        {
            get { return maNSX; }
            set { maNSX = value; }
        }

       
        string nVLap;

        public string NVLap
        {
            get { return nVLap; }
            set { nVLap = value; }
        }

        int tinhTrang;

        public int TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
    }
}
