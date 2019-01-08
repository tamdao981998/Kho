using QuanLyCuaHangDoChoiDAO;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiBUS
{
    public class HDNhapBUS
    {
        public List<HDNhapDTO> LAYDSHDNhapxoa()
        {
            HDNhapDAO DAO = new HDNhapDAO();
            return DAO.LAYDSHDNhapxoa();
        }
        public string LayMaHDNTiepTheo()
        {

            HDNhapDAO Dao = new HDNhapDAO();
            string MAHDN = Dao.MaHDNLonNhat();
            if (string.IsNullOrEmpty(MAHDN))
            {
                return "HDN001";
            }
            else
            {
                int ChuyenSo = int.Parse(MAHDN.Replace("HDN", ""));
                return "HDN" + (ChuyenSo + 1).ToString("000");
            }
        }
        public bool ThemHDN(HDNhapDTO DTO)
        {
            HDNhapDAO DAO = new HDNhapDAO();
            return DAO.ThemHDN(DTO);
        }
        public List<HDNhapDTO> LAYDSHDNhap()
        {
            HDNhapDAO DAO = new HDNhapDAO();
            return DAO.LAYDSHDNhap();
        }
        public bool SUAHDN(HDNhapDTO DTO)
        {
            HDNhapDAO DAO = new HDNhapDAO();
            return DAO.SuaHDN(DTO);
        }
        public bool XoaHDN(HDNhapDTO DTO)
        {
            HDNhapDAO dao = new HDNhapDAO();
            return dao.XoaHDN(DTO);
        }
        public List<HDNhapDTO> TimKiem(string ma)
        {
            HDNhapDAO DAO = new HDNhapDAO();
            return DAO.TimKiem(ma);
        }
        public List<TK_HDNhap_NSXDTO> LAYDSHDNhapTheoNgay(DateTime TimeTu, DateTime TimeDen)
        {
            HDNhapDAO dao = new HDNhapDAO();
            return dao.LAYDSHDNhapTheoNgay(TimeTu, TimeDen);
        }
        public List<TK_HDNhap_NSXDTO> LayDanHSachHDNHuy(DateTime TimeTu, DateTime TimeDen)
        {
            HDNhapDAO dao = new HDNhapDAO();
            return dao.LayDanhSachHDNHuy(TimeTu, TimeDen);
        }

        public List<TK_HDNhap_NSXDTO> LAYDSHDNhapTheoMaHD(string mahd)
        {
            HDNhapDAO dao = new HDNhapDAO();
            return dao.LAYDSHDNhapTheoMaHD(mahd);
        }
 	public HDNhapDTO DemMaHDNhap()
        {
            HDNhapDAO dao = new HDNhapDAO();
            return dao.DemMaHDN();
        }
    }
}
