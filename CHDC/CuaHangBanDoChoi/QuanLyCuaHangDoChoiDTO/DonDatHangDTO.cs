using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class DonDatHangDTO
    {
        private string maDonDH;

        public string MaDonDH
        {
            get { return maDonDH; }
            set { maDonDH = value; }
        }

        private DateTime ngayDat;

        public DateTime NgayDat
        {
            get { return ngayDat; }
            set { ngayDat = value; }
        }
        private DateTime ngayGiao;

        public DateTime NgayGiao
        {
            get { return ngayGiao; }
            set { ngayGiao = value; }
        }

        private string diaChiGiao;

        public string DiaChiGiao
        {
            get { return diaChiGiao; }
            set { diaChiGiao = value; }
        }

        private int soDienThoai;

        public int SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

        private decimal tongTien;

        public decimal TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        private string khachHangDat;

        public string KhachHangDat
        {
            get { return khachHangDat; }
            set { khachHangDat = value; }
        }

        private string nVLap;

        public string NVLap
        {
            get { return nVLap; }
            set { nVLap = value; }
        }

        private int tinhTrang;

        public int TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
        

    }
}
