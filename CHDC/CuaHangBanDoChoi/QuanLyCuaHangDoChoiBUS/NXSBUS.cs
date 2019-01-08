using QuanLyCuaHangDoChoiDAO;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiBUS
{
    public class NXSBUS
    {
        public List<NSXDTO> LoadDSNXSxoa()
        {
            NXSDAO dao = new NXSDAO();
            return dao.LoadDSNXSxoa();
        }
        public List<NSXDTO> LayDSNSX()
        {
            NXSDAO dao = new NXSDAO();
            return dao.LoadDSNXS();
        }

        public List<NSXDTO> LoadDSNSX()
        {
            NXSDAO dao = new NXSDAO();
            return dao.LoadDSNXS();
        }

        public bool ThemNSX(NSXDTO dto)
        {
            NXSDAO DAO = new NXSDAO();
            return DAO.ThemNSX(dto);
        }
        public string LayNSXTiepTheo()
        {
            string strKQ;
            NXSDAO suaDao = new NXSDAO();
            string MaxMaNXS = suaDao.MaNXSLonNhat();
            if (string.IsNullOrEmpty(MaxMaNXS))
            {
                return "NSX001";
            }
            else
            {
                int ChuyenSo = int.Parse(MaxMaNXS.Replace("NSX", ""));
                return "NSX" + (ChuyenSo + 1).ToString("000");
            }
        }
     
        public bool SuaNSX(NSXDTO DTO)
        {
            NXSDAO dao = new NXSDAO();
            return dao.SuaTTNSX(DTO);

        }
        public bool XoaNSX(NSXDTO DTO)
        {
            NXSDAO dao = new NXSDAO();
            return dao.XoanNSX(DTO);
        }

        public List<NSXDTO> TimKiem(string ten)
        {
            NXSDAO dao = new NXSDAO();
            return dao.TimKiem(ten);
        }

}
}
