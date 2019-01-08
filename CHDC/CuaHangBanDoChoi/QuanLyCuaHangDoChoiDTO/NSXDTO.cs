using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class NSXDTO
    {
        private string maNSX;

        public string MaNSX
        {
            get { return maNSX; }
            set { maNSX = value; }
        }
        private string tenNSX;

        public string TenNSX
        {
            get { return tenNSX; }
            set { tenNSX = value; }
        }
        private string diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        private int sDT;

        public int SDT
        {
            get { return sDT; }
            set { sDT = value; }
        }
        private int tinhTrang;

        public int TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
    }
}
