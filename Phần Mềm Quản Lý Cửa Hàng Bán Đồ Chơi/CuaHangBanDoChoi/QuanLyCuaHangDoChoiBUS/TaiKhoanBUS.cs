using QuanLyCuaHangDoChoiDAO;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiBUS
{
   public  class TaiKhoanBUS
    {
       public List<TaiKhoanDTO> LayDSTaiKhoanxoa()
       {
           TaiKhoanDAO dao = new TaiKhoanDAO();
           return dao.LayDSTaiKhoanxoa();
       }
       public TaiKhoanDTO LayTenDangNhap()
       {
           TaiKhoanDAO dao = new TaiKhoanDAO();
           return dao.LayTenDangNhap();
       }
       public List<TaiKhoanDTO> LayDSTaiKhoan()
       {
           TaiKhoanDAO tk = new TaiKhoanDAO();
           return tk.LayDSTaiKhoan();
       }
      
       public TaiKhoanDTO LayThongTinTK(string tdn)
       {
           TaiKhoanDAO tk = new TaiKhoanDAO();
           return tk.LaythongTinTK(tdn);
       }
       public bool UpdateMatKhau(TaiKhoanDTO dto)
       {
           TaiKhoanDAO tk = new TaiKhoanDAO();
           return tk.UpdateMatKhau(dto);
       }
       public bool KiemTraDangNhap(string tk, string mk)
       {
           TaiKhoanDAO ktDN = new TaiKhoanDAO();
           return ktDN.KiemTraDangNhap(tk, mk);
       }
       public string LayManNVTiepTheo()
       {
           // string strKQ;
           TaiKhoanDAO suaDao = new TaiKhoanDAO();
           string MaxMaNV = suaDao.MaNVLonNhat();
           if (string.IsNullOrEmpty(MaxMaNV))
           {
               return "TK001";
           }
           else
           {
               int ChuyenSo = int.Parse(MaxMaNV.Replace("TK", ""));
               return "TK" + (ChuyenSo + 1).ToString("000");
           }
       }
       public bool ThemTK(TaiKhoanDTO DTO)
       {
           TaiKhoanDAO dao = new TaiKhoanDAO();
           return dao.ThemTK(DTO);
       }
       public bool SuaTTTK(TaiKhoanDTO DTO)
       {
           TaiKhoanDAO dao = new TaiKhoanDAO();
           return dao.SuaTTTK(DTO);

       }
       public bool XoaTK(TaiKhoanDTO DTO)
       {
           TaiKhoanDAO dao = new TaiKhoanDAO();
           return dao.XoaTK(DTO);
       }
       public bool KTTT(string tontai)
       {
           TaiKhoanDAO dao = new TaiKhoanDAO();
           return dao.KTTT(tontai);
       }
        public List<TaiKhoanDTO> TimKiemTheoTen(string tennv)
       {
           TaiKhoanDAO dao = new TaiKhoanDAO();
           return dao.TimKiemTheoTen(tennv);
       }
        public List<TaiKhoanDTO> TimKiemTheoMa(string ma)
        {
            TaiKhoanDAO dao = new TaiKhoanDAO();
            return dao.TimKiemTheoMa(ma);
        }
        public TaiKhoanDTO LayDSTKTheoMaNV(string maNV)
        {
            TaiKhoanDAO dao = new TaiKhoanDAO();
            return dao.LayDSTKTheoMaNV(maNV);
        }
    }
}
