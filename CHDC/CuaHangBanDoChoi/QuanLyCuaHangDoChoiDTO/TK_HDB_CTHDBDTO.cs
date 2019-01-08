using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class TK_HDB_CTHDBDTO
    {
        string maNV;

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        string hoTenNV;

        public string HoTenNV
        {
            get { return hoTenNV; }
            set { hoTenNV = value; }
        }
        int tongSL;

        public int TongSL
        {
            get { return tongSL; }
            set { tongSL = value; }
        }
        double tongDoanhThu;

        public double TongDoanhThu
        {
            get { return tongDoanhThu; }
            set { tongDoanhThu = value; }
        }
    }
}
