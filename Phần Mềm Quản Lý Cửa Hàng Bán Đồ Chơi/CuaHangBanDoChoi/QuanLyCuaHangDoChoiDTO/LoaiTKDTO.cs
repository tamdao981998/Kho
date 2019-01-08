using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDTO
{
    public class LoaiTKDTO
    {
        private string maLoaiTK;

        public string MaLoaiTK
        {
            get { return maLoaiTK; }
            set { maLoaiTK = value; }
        }
        private string tenLoaiTK;

        public string TenLoaiTK
        {
            get { return tenLoaiTK; }
            set { tenLoaiTK = value; }
        }
        private int tinhTrang;

        public int TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
    }
}
