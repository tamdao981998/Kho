using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class ChiTietDDHDTO
    {
        private string maDDH;

        public string MaDDH
        {
            get { return maDDH; }
            set { maDDH = value; }
        }
        private string maSP;

        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }

        private int SoLuong;

        public int SoLuong1
        {
            get { return SoLuong; }
            set { SoLuong = value; }
        }
        private decimal donGia;

        public decimal DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        private decimal thnhTien;

        public decimal ThnhTien
        {
            get { return donGia * SoLuong; }
            
        }
    }
}
