using QuanLyCuaHangDoChoiDAO;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiBUS
{
    public class KhachHangBUS
    {
        public List<KhachHangDTO> LAYDSKHxoa()
        {
            KhachHangDAO DAO = new KhachHangDAO();
            return DAO.LAYDSKHxoa();
        }
        public List<KhachHangDTO> LAYDSKH()
        {
            KhachHangDAO DAO = new KhachHangDAO();
            return DAO.LAYDSKH();
        }
        public string LayMaKHTiepTheo()
        {
            string strKQ;
            KhachHangDAO suaDao = new KhachHangDAO();
            string MaxMaNXS = suaDao.MaKHLonNhat();
            if (string.IsNullOrEmpty(MaxMaNXS))
            {
                return "KH001";
            }
            else
            {
                int ChuyenSo = int.Parse(MaxMaNXS.Replace("KH", ""));
                return "KH" + (ChuyenSo + 1).ToString("000");
            }
        }
        public bool ThemKH(KhachHangDTO DTO)
        {
            KhachHangDAO dao = new KhachHangDAO();
            return dao.ThemKH(DTO);
        }
        public bool SuaTTKH(KhachHangDTO DTO)
        {
            KhachHangDAO dao = new KhachHangDAO();
            return dao.SuaTTKH(DTO);

        }
        public bool XoaTTKH(KhachHangDTO DTO)
        {
            KhachHangDAO dao = new KhachHangDAO();
            return dao.XoaKH(DTO);
        }

        public List<KhachHangDTO> TimKiemTheoTen(string ma)
        {
            KhachHangDAO dao = new KhachHangDAO();
            return dao.TimKiemTheoTen(ma);
        }
    }
}
