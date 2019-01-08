using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class HDNhapDTO
    {
        private string maHDNhap;

        public string MaHDNhap
        {
            get { return maHDNhap; }
            set { maHDNhap = value; }
        }
        private DateTime ngayNhapHang;

        public DateTime NgayNhapHang
        {
            get { return ngayNhapHang; }
            set { ngayNhapHang = value; }
        }

        private decimal tongTien;

        public decimal TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }

        private string nVLap;

        public string NVLap
        {
            get { return nVLap; }
            set { nVLap = value; }
        }

        private string nSX;

        public string NSX
        {
            get { return nSX; }
            set { nSX = value; }
        }
        private int tinhTrang;

        public int TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
    }
}
