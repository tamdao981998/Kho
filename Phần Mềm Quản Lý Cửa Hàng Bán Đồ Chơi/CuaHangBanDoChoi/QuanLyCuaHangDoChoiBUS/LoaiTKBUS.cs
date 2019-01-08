using QuanLyCuaHangDoChoiDAO;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiBUS
{
    public class LoaiTKBUS
    {
        public List<LoaiTKDTO> LoadDSLoaiTK()
        {
            LoaiTKDAO dao = new LoaiTKDAO();
            return dao.LoadDSLoaiTK();
        }
        public string LayMaLoaiTKTiepTheo()
        {
            string strKQ;
            LoaiTKDAO suaDao = new LoaiTKDAO();
            string MaLoaiTK = suaDao.MaLoaiTKLonNhat();
            if (string.IsNullOrEmpty(MaLoaiTK))
            {
                return "TK001";
            }
            else
            {
                int ChuyenSo = int.Parse(MaLoaiTK.Replace("LTK", ""));
                return "TK" + (ChuyenSo + 1).ToString("000");
            }
        }
        public bool ThemLoaiTK(LoaiTKDTO DTO)
        {
            LoaiTKDAO dao = new LoaiTKDAO();
            return dao.ThemLoaiTK(DTO);
        }
        public bool SuaTTTK(LoaiTKDTO DTO)
        {
            LoaiTKDAO dao = new LoaiTKDAO();
            return dao.SuaLoaiTK(DTO);

        }
        public bool XoaTTTK(LoaiTKDTO DTO)
        {
            LoaiTKDAO dao = new LoaiTKDAO();
            return dao.XoaLoaiTK(DTO);
        }
    }
}
