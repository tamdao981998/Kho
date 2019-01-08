using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class HDBanDTO
    {
        private string maHDBan;

        public string MaHDBan
        {
            get { return maHDBan; }
            set { maHDBan = value; }
        }
        private DateTime ngayLapHD;
        
        public DateTime NgayLapHD
        {
            get { return ngayLapHD; }
            set { ngayLapHD = value; }
        }

        private decimal tongTien;

        public decimal TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        private string maKH;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        private string nVLapHD;

        public string NVLapHD
        {
            get { return nVLapHD; }
            set { nVLapHD = value; }
        }
        private int tinhTrang;

        public int TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
        decimal tienKhachTra;

        public decimal TienKhachTra
        {
            get { return tienKhachTra; }
            set { tienKhachTra = value; }
        }
        decimal tienDu;

        public decimal TienDu
        {
            get { return tienDu; }
            set { tienDu = value; }
        }

     public HDBanDTO()
        {
         //datetime
            NgayLapHD = DateTime.MinValue;
         //string
            MaKH = "";
            MaHDBan = "";
            NVLapHD = "";
        }
    }
}
