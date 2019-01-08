using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class ChiTietHDBanDTO
    {
        private string maHDBan;

        public string MaHDBan
        {
            get { return maHDBan; }
            set { maHDBan = value; }
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
        string tenSP;

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }
    }
}
