using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class KhachHangDTO
    {
        private string maKH;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        private string tenKH;

        public string TenKH
        {
            get { return tenKH; }
            set { tenKH = value; }
        }

        private string diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private int sDT;

        public int SDT
        {
            get { return sDT; }
            set { sDT = value; }
        }
        private string cMND;

        public string CMND
        {
            get { return cMND; }
            set { cMND = value; }
        }
        private DateTime ngayMuaHang;

        public DateTime NgayMuaHang
        {
            get { return ngayMuaHang; }
            set { ngayMuaHang = value; }
        }
        private int tinhTrang;

        public int TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }

    }
}
