using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDAO
{
   public class TaiKhoanDAO
    {
       public List<TaiKhoanDTO> LayDSTaiKhoan()
       {
           List<TaiKhoanDTO> result = new List<TaiKhoanDTO>();
           string truyvan = "SELECT * FROM TAI_KHOAN Where TinhTrang =1";
           SqlConnection con = DataProvider.TaoKetNoi();
           SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
           while (sr.Read())
           {
               TaiKhoanDTO tk = new TaiKhoanDTO();
               tk.MaNV = sr["MaNV"].ToString();
               tk.MatKhau = sr["MatKhau"].ToString();
               tk.HoTen = sr["HoTenNV"].ToString();
               tk.DiaChi = sr["DiaChi"].ToString();
               tk.CMND = sr["CMND"].ToString();
               tk.Email = sr["Email"].ToString();
               tk.MaLoaiTaiKhoan = sr["MaLoaiTK"].ToString();
               tk.Sdt =int.Parse( sr["SoDienThoai"].ToString());
               tk.AnhDaiDien = sr["AnhDaiDien"].ToString();
               tk.TenDangNhap = sr["TenDangNhap"].ToString();
               tk.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
               result.Add(tk);
           }
           sr.Close();
           con.Close();
           return result;
       }
       public List<TaiKhoanDTO> LayDSTaiKhoanxoa()
       {
           List<TaiKhoanDTO> result = new List<TaiKhoanDTO>();
           string truyvan = "SELECT * FROM TAI_KHOAN Where TinhTrang =0";
           SqlConnection con = DataProvider.TaoKetNoi();
           SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
           while (sr.Read())
           {
               TaiKhoanDTO tk = new TaiKhoanDTO();
               tk.MaNV = sr["MaNV"].ToString();
               tk.MatKhau = sr["MatKhau"].ToString();
               tk.HoTen = sr["HoTenNV"].ToString();
               tk.DiaChi = sr["DiaChi"].ToString();
               tk.CMND = sr["CMND"].ToString();
               tk.Email = sr["Email"].ToString();
               tk.MaLoaiTaiKhoan = sr["MaLoaiTK"].ToString();
               tk.Sdt = int.Parse(sr["SoDienThoai"].ToString());
               tk.AnhDaiDien = sr["AnhDaiDien"].ToString();
               tk.TenDangNhap = sr["TenDangNhap"].ToString();
               tk.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
               result.Add(tk);
           }
           sr.Close();
           con.Close();
           return result;
       }
       

      
       public string MaNVLonNhat()
       {
           string strResult = null;
           string strTruyVan = "SELECT MAX(MANV) FROM TAI_KHOAN";
           SqlConnection con = DataProvider.TaoKetNoi();
           SqlDataReader sdr = DataProvider.TruyVanDuLieu(strTruyVan, con);
           if (sdr.Read())
           {
               strResult = sdr[0].ToString();
           }
           sdr.Close();
           con.Close();
           return strResult;

       }

       public bool ThemTK(TaiKhoanDTO DTO)
       {
           string INSERT = "INSERT INTO TAI_KHOAN VALUES(@MaNV,@MatKhau,@HoTen,@DiaChi,@Email,@Sdt,@CMND,@AnhDaiDien,@MaLoaiTaiKhoan,@TinhTrang,@TenDangNhap)";
           SqlParameter[] p = new SqlParameter[11];
           p[0] = new SqlParameter("@MaNV", DTO.MaNV);
           p[1] = new SqlParameter("@MatKhau", DTO.MatKhau);
           p[2] = new SqlParameter("@HoTen", DTO.HoTen);
           p[3] = new SqlParameter("@DiaChi", DTO.DiaChi);
           p[4] = new SqlParameter("@Email", DTO.Email);
           p[5] = new SqlParameter("@Sdt", DTO.Sdt);
           p[6] = new SqlParameter("@CMND", DTO.CMND);
           p[7] = new SqlParameter("@AnhDaiDien", DTO.AnhDaiDien);
           p[8] = new SqlParameter("@MaLoaiTaiKhoan", DTO.MaLoaiTaiKhoan);
           p[9] = new SqlParameter("@TinhTrang", DTO.TinhTrang);
           p[10] = new SqlParameter("@TenDangNhap", DTO.TenDangNhap);
           SqlConnection con = DataProvider.TaoKetNoi();
           int kq = DataProvider.ThucThiCauLenh(INSERT, p, con);
           con.Close();
           return kq > 0;
       }
       public bool SuaTTTK(TaiKhoanDTO DTO)
       {
           string UPDATE = "UPDATE TAI_KHOAN SET MATKHAU=@MatKhau,HOTENNV=@HoTen,DIACHI=@DiaChi,EMAIL=@Email,SoDienThoai=@Sdt,CMND=@CMND,ANHDAIDIEN=@AnhDaiDien,MALOAITK=@MaLoaiTaiKhoan,TINHTRANG=@TinhTrang,TENDANGNHAP=@TenDangNhap WHERE MANV=@MaNV";
           SqlParameter[] p = new SqlParameter[11];
           p[0] = new SqlParameter("@MaNV", DTO.MaNV);
           p[1] = new SqlParameter("@MatKhau", DTO.MatKhau);
           p[2] = new SqlParameter("@HoTen", DTO.HoTen);
           p[3] = new SqlParameter("@DiaChi", DTO.DiaChi);
           p[4] = new SqlParameter("@Email", DTO.Email);
           p[5] = new SqlParameter("@Sdt", DTO.Sdt);
           p[6] = new SqlParameter("@CMND", DTO.CMND);
           p[7] = new SqlParameter("@AnhDaiDien", DTO.AnhDaiDien);
           p[8] = new SqlParameter("@MaLoaiTaiKhoan", DTO.MaLoaiTaiKhoan);
           p[9] = new SqlParameter("@TinhTrang", DTO.TinhTrang);
           p[10] = new SqlParameter("@TenDangNhap", DTO.TenDangNhap);
           SqlConnection con = DataProvider.TaoKetNoi();
           int kq = DataProvider.ThucThiCauLenh(UPDATE, p, con);
           con.Close();
           return kq > 0;
       }
       public bool XoaTK(TaiKhoanDTO DTO)
       {
           string DELETE = "UPDATE TAI_KHOAN SET TINHTRANG=0 WHERE  MANV = @MaNV";
           SqlParameter[] p = new SqlParameter[1];

           p[0] = new SqlParameter("@MANV", DTO.MaNV);
           SqlConnection con = DataProvider.TaoKetNoi();
           int kq = DataProvider.ThucThiCauLenh(DELETE, p, con);
           con.Close();
           return kq > 0;
       }
       public bool KTTT(string tontai)
       {
           string struyvan = "SELECT COUNT(MANV) FROM TAI_KHOAN WHERE MANV=@tontai AND TINHTRANG =0";
           SqlParameter[] p = new SqlParameter[1];
           p[0] = new SqlParameter("@tontai", tontai);
           SqlConnection con = DataProvider.TaoKetNoi();
           int kq = DataProvider.ThucThiCauLenh(struyvan, p, con);
           con.Close();
           return kq >0;
       }
       public TaiKhoanDTO LaythongTinTK(string tdn)
       {
           TaiKhoanDTO tk = null;
           string truyvan = "SELECT * FROM TAI_KHOAN WHERE TenDangNhap ='" + tdn + "' ";
           SqlParameter[] p = new SqlParameter[1];
           p[0] = new SqlParameter("@manv", tdn);
           SqlConnection con = DataProvider.TaoKetNoi();
           SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, p, con);
           while (sr.Read())
           {
               tk = new TaiKhoanDTO();
               tk.MaNV = sr["MaNV"].ToString();
               tk.HoTen = sr["HoTenNV"].ToString();
               tk.MaLoaiTaiKhoan = sr["MaLoaiTK"].ToString();
               tk.AnhDaiDien = sr["AnhDaiDien"].ToString();
               tk.TenDangNhap = sr["TenDangNhap"].ToString();
           }
           sr.Close();
           con.Close();
           return tk;
       }

       public TaiKhoanDTO LayTenDangNhap()
       {

           TaiKhoanDTO tk = null;
           string truyvan = "SELECT * FROM TAI_KHOAN";
           SqlConnection con = DataProvider.TaoKetNoi();
           SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);

           if (sr.Read())
           {
               TaiKhoanDTO kqc = new TaiKhoanDTO();
               kqc.MaNV = sr["MaNV"].ToString();
               kqc.HoTen = sr["HoTenNV"].ToString();
               kqc.MatKhau = sr["MatKhau"].ToString();
               kqc.MaLoaiTaiKhoan = sr["MaLoaiTK"].ToString();
               kqc.Sdt = int.Parse(sr["SoDienThoai"].ToString());
               kqc.DiaChi = sr["DiaCHi"].ToString();
               kqc.Email = sr["Email"].ToString();
               kqc.CMND = sr["CMND"].ToString();
               kqc.AnhDaiDien = sr["AnhDaiDien"].ToString();
               kqc.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
               kqc.TenDangNhap = sr["TenDangNhap"].ToString();
           }
           sr.Close();
           con.Close();
           return tk;

       }
       public bool KiemTraDangNhap(string tk, string mk)
       {
           bool kq = false;
           string truyvan = "SELECT * FROM TAI_KHOAN WHERE TenDangNhap=@tk AND MatKhau=@mk AND TINHTRANG =1";
           SqlParameter[] p = new SqlParameter[2];
           p[0] = new SqlParameter("@tk", tk);
           p[1] = new SqlParameter("@mk", mk);
           SqlConnection con = DataProvider.TaoKetNoi();
           SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, p, con);

           if (sr.Read())
           {
               TaiKhoanDTO kqc = new TaiKhoanDTO();
               kqc.MaNV = sr["MaNV"].ToString();
               kqc.HoTen = sr["HoTenNV"].ToString();
               kqc.MatKhau = sr["MatKhau"].ToString();
               kqc.MaLoaiTaiKhoan = sr["MaLoaiTK"].ToString();
               kqc.Sdt = int.Parse(sr["SoDienThoai"].ToString());
               kqc.DiaChi = sr["DiaCHi"].ToString();
               kqc.Email = sr["Email"].ToString();
               kqc.CMND = sr["CMND"].ToString();
               kqc.AnhDaiDien = sr["AnhDaiDien"].ToString();
               kqc.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
               kqc.TenDangNhap = sr["TenDangNhap"].ToString();

               if (kqc.MatKhau == mk)
               {
                   kq = true;

               }
           }
           sr.Close();
           con.Close();
           return kq;

       }
       public bool UpdateMatKhau(TaiKhoanDTO dto)
       {

           string truyvan = "UPDATE [dbo].[TAI_KHOAN]SET MatKhau=@mk ";
           SqlParameter[] p = new SqlParameter[1];
          
           p[0] = new SqlParameter("@mk", dto.MatKhau);
           SqlConnection con = DataProvider.TaoKetNoi();
           int kq = DataProvider.ThucThiCauLenh(truyvan, p, con);
           return kq > 0;
       }


       public List<TaiKhoanDTO> TimKiemTheoTen(string tennv)
       {
           List<TaiKhoanDTO> result = new List<TaiKhoanDTO>();
           string truyvan = "SELECT * FROM TAI_KHOAN WHERE HOTENNV LIKE N'%"+tennv+"%'";
           SqlConnection con = DataProvider.TaoKetNoi();
           SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
           while (sr.Read())
           {
               TaiKhoanDTO tk = new TaiKhoanDTO();
               tk.MaNV = sr["MaNV"].ToString();
               tk.MatKhau = sr["MatKhau"].ToString();
               tk.HoTen = sr["HoTenNV"].ToString();
               tk.DiaChi = sr["DiaChi"].ToString();
               tk.CMND = sr["CMND"].ToString();
               tk.Email = sr["Email"].ToString();
               tk.MaLoaiTaiKhoan = sr["MaLoaiTK"].ToString();
               tk.Sdt = int.Parse(sr["SoDienThoai"].ToString());
               tk.AnhDaiDien = sr["AnhDaiDien"].ToString();
               tk.TenDangNhap = sr["TenDangNhap"].ToString();
               tk.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
               result.Add(tk);          
           }
           sr.Close();
           con.Close();
           return result;
       }

       public List<TaiKhoanDTO> TimKiemTheoMa(string ma)
       {
           List<TaiKhoanDTO> result = new List<TaiKhoanDTO>();
           string truyvan = "SELECT * FROM TAI_KHOAN WHERE HOTENNV LIKE N'%" + ma + "%' OR MANV LIKE N'%" + ma + "%'";
           SqlConnection con = DataProvider.TaoKetNoi();
           SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
           while (sr.Read())
           {
               TaiKhoanDTO tk = new TaiKhoanDTO();
               tk.MaNV = sr["MaNV"].ToString();
               tk.MatKhau = sr["MatKhau"].ToString();
               tk.HoTen = sr["HoTenNV"].ToString();
               tk.DiaChi = sr["DiaChi"].ToString();
               tk.CMND = sr["CMND"].ToString();
               tk.Email = sr["Email"].ToString();
               tk.MaLoaiTaiKhoan = sr["MaLoaiTK"].ToString();
               tk.Sdt = int.Parse(sr["SoDienThoai"].ToString());
               tk.AnhDaiDien = sr["AnhDaiDien"].ToString();
               tk.TenDangNhap = sr["TenDangNhap"].ToString();
               tk.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
               result.Add(tk);
           }
           sr.Close();
           con.Close();
           return result;
       }
       public TaiKhoanDTO LayDSTKTheoMaNV(string maNV)
       {
           TaiKhoanDTO tk = null;
           string truyvan = "SELECT * FROM TAI_KHOAN Where MaNV ='" + maNV + "' ";
           SqlParameter[] p = new SqlParameter[1];
           p[0] = new SqlParameter("@maNV", maNV);
           SqlConnection con = DataProvider.TaoKetNoi();
           SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, p, con);
           while (sr.Read())
           {
               tk = new TaiKhoanDTO();
               tk.MaNV = sr["MaNV"].ToString();
               tk.HoTen = sr["HoTenNV"].ToString();
           }
           sr.Close();
           con.Close();
           return tk;
       }


    }
}
