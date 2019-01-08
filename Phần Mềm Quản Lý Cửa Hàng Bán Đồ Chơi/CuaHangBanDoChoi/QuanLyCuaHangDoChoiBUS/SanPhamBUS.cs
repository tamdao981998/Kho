using QuanLyCuaHangDoChoiDAO;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiBUS
{
    public  class SanPhamBUS
    {

        public List<SanPhamDTO> LayDSSanPhamxoa()
        {
            SanPhamDAO DAO = new SanPhamDAO();
            return DAO.LayDSSanPhamxoa();
        }
        

        public List<SanPhamDTO> LayDSSanPham()
        {
            SanPhamDAO DAO = new SanPhamDAO();
            return DAO.LayDSSanPham();
        }
        public List<SanPhamDTO> LayDSSanPhamTheoTen(string tenSP)
        {
            SanPhamDAO DAO = new SanPhamDAO();
            return DAO.LayDSSanPhamTheoTen(tenSP);
        }
        public string LayMaSPTiepTheo()
        {
            // string strKQ;
            SanPhamDAO suaDao = new SanPhamDAO();
            string MaxMaSP = suaDao.MaSPLonNhat();
            if (string.IsNullOrEmpty(MaxMaSP))
            {
                return "SP001";
            }
            else
            {
                int ChuyenSo = int.Parse(MaxMaSP.Replace("SP", ""));
                return "SP" + (ChuyenSo + 1).ToString("000");
            }
        }
        public bool ThemSP(SanPhamDTO dto)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.ThemSP(dto);
        }
        public bool SuaTTSP(SanPhamDTO DTO)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.SuaTTSP(DTO);

        }
        public bool SuaNhapSoLuong(string sl, string ma)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.SuaNhapSoLuong(sl,ma);
        }
        public bool SuaSoLuong(string sl, string ma)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.SuaSoLuong(sl,ma);
        }
        public bool XoaSP(SanPhamDTO DTO)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.XoaSP(DTO);
        }
        public List<SanPhamDTO> LayDSSanPhamTheoNSX(string mansx)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.LayDSSanPhamTheoNSX(mansx);
        }
        public List<SanPhamDTO> TimKiemTheoMa(string ma)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.TimKiemTheoMa(ma);
        }
        public List<SanPhamDTO> TKTHEOGIA(string giatu, string giaden)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.TKTHEOGIA(giatu,giaden);
        }
        public List<SanPhamDTO> TKTHEOGIAten(string ma, string giatu, string giaden)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.TKTHEOGIAten(ma, giatu, giaden);
        }

        public List<SanPhamDTO> LayDSSanPhamTheoLoai(string maLoai)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.LayDSSanPhamTheoLoai(maLoai);
        }
        public List<SP_CTHDBDTO> LayDSSPBan(DateTime TimeTu, DateTime TimeDen)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.LayDSSPDaBan(TimeTu, TimeDen);
        }
        public List<SP_CTHDBDTO> LayDSSPDaNhap(DateTime TimeTu, DateTime TimeDen)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.LayDSSPDaNhap(TimeTu, TimeDen);
        }
        public List<SP_CTHDBDTO> SPBanChayNhat(DateTime TimeTu, DateTime TimeDen)
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.SPBanChayNhat(TimeTu, TimeDen);
        }
	public SP_CTHDBDTO TongSoSPBan()
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.TongSPDaBan();
        }

        public SP_CTHDN_LSP_HDN TongSoSPNhap()
        {
            SanPhamDAO dao = new SanPhamDAO();
            return dao.TongSPNhap();
        }
    }
}
