using QuanLyCuaHangDoChoiDAO;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiBUS
{
    public class ChiTietDDHBUS
    {
        public List<ChiTietDDHDTO> LOADCTDHH(string ma)
        {
            ChiTietDDHDAO DAO = new ChiTietDDHDAO();
            return DAO.LOADCTHDDH(ma);
        }
        public bool ThemCTDDH(ChiTietDDHDTO DTO)
        {
            ChiTietDDHDAO DAO = new ChiTietDDHDAO();
            return DAO.ThemCTDDH(DTO);
        }
        public string LayMaCTDDNTiepTheo()
        {

            ChiTietDDHDAO Dao = new ChiTietDDHDAO();
            string MADDH = Dao.MaCTCTDDHLonNhat();
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
    }
}
