using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDAO
{
    public class KhachHangDAO
    {
        public List<KhachHangDTO> LAYDSKH()
        {
            List<KhachHangDTO> LS = new List<KhachHangDTO>();
            string truyvan = "SELECT * FROM KHACH_HANG  WHERE TINHTRANG=1";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                KhachHangDTO dto = new KhachHangDTO();
                dto.MaKH = sr["MaKH"].ToString();
                dto.TenKH = sr["HoTenKH"].ToString();
                dto.DiaChi = sr["DiaChi"].ToString();
                dto.Email = sr["Email"].ToString();
                dto.SDT = int.Parse(sr["SoDienThoai"].ToString());
                dto.CMND = sr["CMND"].ToString();
                dto.NgayMuaHang = DateTime.Parse(sr["NgayMuaHang"].ToString());
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                LS.Add(dto);

            }
            sr.Close();
            con.Close();
            return LS;
        }
        public List<KhachHangDTO> LAYDSKHxoa()
        {
            List<KhachHangDTO> LS = new List<KhachHangDTO>();
            string truyvan = "SELECT * FROM KHACH_HANG  WHERE TINHTRANG=0";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                KhachHangDTO dto = new KhachHangDTO();
                dto.MaKH = sr["MaKH"].ToString();
                dto.TenKH = sr["HoTenKH"].ToString();
                dto.DiaChi = sr["DiaChi"].ToString();
                dto.Email = sr["Email"].ToString();
                dto.SDT = int.Parse(sr["SoDienThoai"].ToString());
                dto.CMND = sr["CMND"].ToString();
                dto.NgayMuaHang = DateTime.Parse(sr["NgayMuaHang"].ToString());
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                LS.Add(dto);

            }
            sr.Close();
            con.Close();
            return LS;
        }
        public string MaKHLonNhat()
        {
            string strResult = null;
            string strTruyVan = "SELECT MAX(MaKH) FROM KHACH_HANG";
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

        public bool ThemKH(KhachHangDTO DTO)
        {
            string INSERT = "INSERT INTO KHACH_HANG VALUES(@MaKH,@TenKH,@DiaChi,@Email,@SDT,@CMND,@NGAYMUAHANG,@TINHTRANG)";
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@MaKH", DTO.MaKH);
            p[1] = new SqlParameter("@TenKH", DTO.TenKH);
            p[2] = new SqlParameter("@DiaChi", DTO.DiaChi);
            p[3] = new SqlParameter("@Email", DTO.Email);
            p[4] = new SqlParameter("@SDT", DTO.SDT);
            p[5] = new SqlParameter("@CMND", DTO.CMND);
            p[6] = new SqlParameter("@NGAYMUAHANG", DTO.NgayMuaHang);
            p[7] = new SqlParameter("@TINHTRANG", DTO.TinhTrang);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(INSERT, p, con);
            con.Close();
            return kq > 0;
        }
        public bool SuaTTKH(KhachHangDTO DTO)
        {
            string UPDATE = "UPDATE KHACH_HANG SET HOTENKH=@TenKH,DIACHI=@DiaChi,EMAIL=@Email,SoDienThoai=@SDT,CMND=@CMND,NGAYMUAHANG=@NGAYMUAHANG,TinhTrang=@TINHTRANG WHERE MAKH=@MaKH" ;
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@MaKH", DTO.MaKH);
            p[1] = new SqlParameter("@TenKH", DTO.TenKH);
            p[2] = new SqlParameter("@DiaChi", DTO.DiaChi);
            p[3] = new SqlParameter("@Email", DTO.Email);
            p[4] = new SqlParameter("@SDT", DTO.SDT);
            p[5] = new SqlParameter("@CMND", DTO.CMND);
            p[6] = new SqlParameter("@NGAYMUAHANG", DTO.NgayMuaHang);
            p[7] = new SqlParameter("@TINHTRANG", DTO.TinhTrang);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(UPDATE, p, con);
            con.Close();
            return kq > 0;
        }
        public bool XoaKH(KhachHangDTO DTO)
        {
            string DELETE = "UPDATE KHACH_HANG SET TINHTRANG=0 WHERE  MAKH = @MaKH";
            SqlParameter[] p = new SqlParameter[1];
            
            p[0] = new SqlParameter("@MaKH", DTO.MaKH);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(DELETE, p, con);
            con.Close();
            return kq > 0;
        }

        public List<KhachHangDTO> TimKiemTheoTen(string ma)
        {
            List<KhachHangDTO> LS = new List<KhachHangDTO>();
            string truyvan = "SELECT * FROM KHACH_HANG WHERE HOTENKH LIKE N'%" + ma + "%' OR MAKH LIKE N'%" + ma + "%'";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                KhachHangDTO dto = new KhachHangDTO();
                dto.MaKH = sr["MaKH"].ToString();
                dto.TenKH = sr["HoTenKH"].ToString();
                dto.DiaChi = sr["DiaChi"].ToString();
                dto.Email = sr["Email"].ToString();
                dto.SDT = int.Parse(sr["SoDienThoai"].ToString());
                dto.CMND = sr["CMND"].ToString();
                dto.NgayMuaHang = DateTime.Parse(sr["NgayMuaHang"].ToString());
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                LS.Add(dto);

            }
            sr.Close();
            con.Close();
            return LS;
        }
    }
}
