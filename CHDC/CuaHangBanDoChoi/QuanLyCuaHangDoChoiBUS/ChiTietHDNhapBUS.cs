using QuanLyCuaHangDoChoiDAO;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiBUS
{
    public class ChiTietHDNhapBUS
    {
        public List<ChiTietHDNhapDTO> LOADCTHDN(string ma)
        {
            ChiTietHDNhapDAO dao = new ChiTietHDNhapDAO();
            return dao.LOADCTHDB(ma);
        }
        public bool ThemCTHDN(ChiTietHDNhapDTO DTO)
        {
            ChiTietHDNhapDAO dao = new ChiTietHDNhapDAO();
            return dao.ThemCTHDN(DTO);
        }


        public List<SP_CTHDN_LSP_HDN> LOADCTHDXUAT(string mahdn)
        {
            ChiTietHDNhapDAO dao = new ChiTietHDNhapDAO();
            return dao.LOADCTHDXUAT(mahdn);
        }
    }
}
