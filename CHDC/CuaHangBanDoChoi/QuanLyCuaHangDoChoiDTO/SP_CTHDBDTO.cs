using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class SP_CTHDBDTO
    {
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
        decimal gia;

        public decimal Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        int sLSP;

        public int SLSP
        {
            get { return sLSP; }
            set { sLSP = value; }
        }
        decimal tongTien;

        public decimal TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        string tenLoaiSP;

        public string TenLoaiSP
        {
            get { return tenLoaiSP; }
            set { tenLoaiSP = value; }
        }
        DateTime ngayLapHD;

        public DateTime NgayLapHD
        {
            get { return ngayLapHD; }
            set { ngayLapHD = value; }
        }
        private string maHDBan;

        public string MaHDBan
        {
            get { return maHDBan; }
            set { maHDBan = value; }
        }
    }
}
