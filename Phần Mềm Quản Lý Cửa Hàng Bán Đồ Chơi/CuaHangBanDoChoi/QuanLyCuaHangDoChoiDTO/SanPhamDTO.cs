using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class SanPhamDTO
    {
        private string maSP;

        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }


        private string tenSP;

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }


        private string doTuoi;

        public string DoTuoi
        {
            get { return doTuoi; }
            set { doTuoi = value; }
        }

        private string moTa;

        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }
        private decimal gia;

        public decimal Gia
        {
            get { return gia; }
            set { gia = value; }
        }


        private int soLuongTonKho;

        public int SoLuongTonKho
        {
            get { return soLuongTonKho; }
            set { soLuongTonKho = value; }
        }

        private string hinhAnh;

        public string HinhAnh
        {
            get { return hinhAnh; }
            set { hinhAnh = value; }
        }




        private string maLoaiSP;

        public string MaLoaiSP
        {
            get { return maLoaiSP; }
            set { maLoaiSP = value; }
        }
        private string maNSX;

        public string MaNSX
        {
            get { return maNSX; }
            set { maNSX = value; }
        }

        private int tinhTrang;

        public int TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
    }
}
