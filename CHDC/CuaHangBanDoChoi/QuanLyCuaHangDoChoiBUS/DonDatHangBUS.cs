using QuanLyCuaHangDoChoiDAO;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiBUS
{
    public class DonDatHangBUS
    {
        public List<DonDatHangDTO> Laydsdondathang()
        {
            DonDatHangDAO DAO = new DonDatHangDAO();
            return DAO.Laydsdondathang();
        }

        public bool SUADDH(DonDatHangDTO DTO)
        {
            DonDatHangDAO DAO = new DonDatHangDAO();
            return DAO.SuaDDH(DTO);
        }
        public bool XoaDDH(DonDatHangDTO DTO)
        {
            DonDatHangDAO dao = new DonDatHangDAO();
            return dao.XoaDDH(DTO);
        }
        public string MaDDHLonNhat()
        {
            
            DonDatHangDAO Dao = new DonDatHangDAO();
            string MADDH = Dao.MaDDHLonNhat();
            if (string.IsNullOrEmpty(MADDH))
            {
                return "DDH001";
            }
            else
            {
                int ChuyenSo = int.Parse(MADDH.Replace("DDH", ""));
                return "DDH" + (ChuyenSo + 1).ToString("000");
            }
        }
        public bool ThemDDH(DonDatHangDTO DTO)
        {
            DonDatHangDAO Dao = new DonDatHangDAO();
            return Dao.ThemDDH(DTO);
        }
        public List<DonDatHangDTO> TimKiem(string ten)
        {
            DonDatHangDAO DAO = new DonDatHangDAO();
            return DAO.TimKiem(ten);
        }
    }
}
