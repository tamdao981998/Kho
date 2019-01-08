using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class ChiTietHDNhapDTO
    {
        private string maHDNhap;

        public string MaHDNhap
        {
            get { return maHDNhap; }
            set { maHDNhap = value; }
        }
        string tenSP;

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }
        private string maSP;

        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }



        private decimal donGia;

        public decimal DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }

        private decimal thanhTien;

        public decimal ThanhTien
        {
            get { return DonGia * SoLuong; }
          
        }

    }
}
