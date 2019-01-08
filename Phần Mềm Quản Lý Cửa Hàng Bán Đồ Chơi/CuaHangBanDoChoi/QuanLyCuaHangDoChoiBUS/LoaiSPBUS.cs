using QuanLyCuaHangDoChoiDAO;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiBUS
{
    public class LoaiSPBUS
    {

        public List<LoaiSPDTO> layDSLoaiSP()
        {
            LoaiSPDAO DAO = new LoaiSPDAO();
            return DAO.layDSLoaiSP();
        }
        public string LayMaLoaiSPTiepTheo()
        {
            // string strKQ;
            LoaiSPDAO suaDao = new LoaiSPDAO();
            string MaxMaLoaiSP = suaDao.MaLoaiSPLonNhat();
            if (string.IsNullOrEmpty(MaxMaLoaiSP))
            {
                return "LSP001";
            }
            else
            {
                int ChuyenSo = int.Parse(MaxMaLoaiSP.Replace("LSP", ""));
                return "LSP" + (ChuyenSo + 1).ToString("000");
            }
        }
        public bool ThemLoaiSP(LoaiSPDTO dto)
        {
            LoaiSPDAO dao = new LoaiSPDAO();
            return dao.ThemLOAISP(dto);
        }
        public bool SuaLoaiSP(LoaiSPDTO DTO)
        {
            LoaiSPDAO dao = new LoaiSPDAO();
            return dao.SuaLoaiSP(DTO);

        }
        public bool XoaLoaiSP(LoaiSPDTO DTO)
        {
            LoaiSPDAO dao = new LoaiSPDAO();
            return dao.XoaLoaiSP(DTO);
        }
        public LoaiSPDTO LayLoaiSanPham(string maLoai)
        {
            LoaiSPDAO dao = new LoaiSPDAO();
            return dao.LayLoaiSanPham(maLoai);
        }
    }
}
