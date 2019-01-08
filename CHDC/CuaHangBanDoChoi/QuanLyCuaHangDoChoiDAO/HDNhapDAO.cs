using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDAO
{
    public class HDNhapDAO
    {
        protected  void abc()
        {

        }
        public List<HDNhapDTO> LAYDSHDNhapxoa()
        {
            List<HDNhapDTO> ls = new List<HDNhapDTO>();
            string struyvan = "SELECT * FROM HOA_DON_NHAP where TinhTrang=0 ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                HDNhapDTO dto = new HDNhapDTO();
                dto.MaHDNhap = sr["MaHDNhap"].ToString();
                dto.NgayNhapHang = DateTime.Parse(sr["NgayNhapHang"].ToString());
                dto.TongTien = decimal.Parse(sr["TongTien"].ToString());
                dto.NVLap = sr["NVLap"].ToString();
                dto.NSX = sr["MaNSX"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }
        public List<HDNhapDTO> LAYDSHDNhap()
        {
            List<HDNhapDTO> ls = new List<HDNhapDTO>();
            string struyvan = "SELECT * FROM HOA_DON_NHAP where TinhTrang=1 ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                HDNhapDTO dto = new HDNhapDTO();
                dto.MaHDNhap = sr["MaHDNhap"].ToString();
                dto.NgayNhapHang = DateTime.Parse(sr["NgayNhapHang"].ToString());
                dto.TongTien = decimal.Parse(sr["TongTien"].ToString());
                dto.NVLap = sr["NVLap"].ToString();
                dto.NSX = sr["MaNSX"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }
        public bool ThemHDN(HDNhapDTO DTO)
        {
            string INSERT = "INSERT INTO HOA_DON_NHAP VALUES(@MAHDNHAP,@NgayLapHD,@TongTien,@NVLapHD,@NSX,@TinhTrang)";
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@MAHDNHAP", DTO.MaHDNhap);
            p[1] = new SqlParameter("@NgayLapHD", DTO.NgayNhapHang);
            p[2] = new SqlParameter("@TongTien", DTO.TongTien);
            p[3] = new SqlParameter("@NVLapHD", DTO.NVLap);
            p[4] = new SqlParameter("@NSX", DTO.NSX);
            
            p[5] = new SqlParameter("@TinhTrang", 1);

            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(INSERT, p, con);
            con.Close();
            return kq > 0;
        }
        public string MaHDNLonNhat()
        {
            string strResult = null;
            string strTruyVan = "SELECT MAX(MAHDNHAP) FROM HOA_DON_NHAP";
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
        public bool SuaHDN(HDNhapDTO DTO)
        {
            string UPDATE = "UPDATE HOA_DON_NHAP SET NGAYNHAPHANG=@NgayNhapHang,TONGTIEN=@TongTien,MANSX=@MaNSX,NVLAP=@NVLap,TINHTRANG=@TinhTrang WHERE MAHDNHAP=@MaHDNhap";
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@MaHDNhap", DTO.MaHDNhap);
            p[1] = new SqlParameter("@NgayNhapHang", DTO.NgayNhapHang);
            p[2] = new SqlParameter("@TongTien", DTO.TongTien);
            p[3] = new SqlParameter("@MaNSX", DTO.NSX);
            p[4] = new SqlParameter("@NVLap", DTO.NVLap);
            p[5] = new SqlParameter("@TinhTrang", DTO.TinhTrang);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(UPDATE, p, con);
            con.Close();
            return kq > 0;

        }


        public bool XoaHDN(HDNhapDTO DTO)
        {
            string DELETE = "UPDATE HOA_DON_NHAP SET TINHTRANG=0 WHERE  MAHDNHAP = @MaHDNhap";
            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@MaHDNhap", DTO.MaHDNhap);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(DELETE, p, con);
            con.Close();
            return kq > 0;
        }

        public List<HDNhapDTO> TimKiem(string ma)
        {
            List<HDNhapDTO> ls = new List<HDNhapDTO>();
            string struyvan = "SELECT * FROM HOA_DON_NHAP WHERE MAHDNHAP LIKE N'%"+ma+"%'";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                HDNhapDTO dto = new HDNhapDTO();
                dto.MaHDNhap = sr["MaHDNhap"].ToString();
                dto.NgayNhapHang = DateTime.Parse(sr["NgayNhapHang"].ToString());
                dto.TongTien = decimal.Parse(sr["TongTien"].ToString());
                dto.NVLap = sr["NVLap"].ToString();
                dto.NSX = sr["MaNSX"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }
        public List<TK_HDNhap_NSXDTO> LAYDSHDNhapTheoNgay(DateTime TimeTu, DateTime TimeDen)
        {
            List<TK_HDNhap_NSXDTO> ls = new List<TK_HDNhap_NSXDTO>();
            string struyvan = "Select * From dbo.HienThiDSHoaDonNhap Where TinhTrang = 1 AND NgayNhapHang Between '" + TimeTu + "' AND  '" + TimeDen + "' ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                TK_HDNhap_NSXDTO dto = new TK_HDNhap_NSXDTO();
                dto.MaHDNhap = sr["MaHDNhap"].ToString();
                dto.HoTenNSX = sr["TenNSX"].ToString();
                dto.HoTenNV = sr["HoTenNV"].ToString();
                dto.NgayNhapHang = DateTime.Parse(sr["NgayNhapHang"].ToString());
                dto.TongTien = double.Parse(sr["TongTien"].ToString());
                dto.NVLap = sr["NVLap"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }
        public List<TK_HDNhap_NSXDTO> LayDanhSachHDNHuy(DateTime TimeTu, DateTime TimeDen)
        {
            List<TK_HDNhap_NSXDTO> ls = new List<TK_HDNhap_NSXDTO>();
            string struyvan = "Select * From dbo.HienThiDSHoaDonNhap Where TinhTrang =0 AND NgayNhapHang Between '" + TimeTu + "' AND  '" + TimeDen + "' ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                TK_HDNhap_NSXDTO dto = new TK_HDNhap_NSXDTO();
                dto.MaHDNhap = sr["MaHDNhap"].ToString();
                dto.HoTenNSX = sr["TenNSX"].ToString();
                dto.HoTenNV = sr["HoTenNV"].ToString();
                dto.NgayNhapHang = DateTime.Parse(sr["NgayNhapHang"].ToString());
                dto.TongTien = double.Parse(sr["TongTien"].ToString());
                dto.NVLap = sr["NVLap"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }

        public List<TK_HDNhap_NSXDTO> LAYDSHDNhapTheoMaHD(string mahd)
        {
            List<TK_HDNhap_NSXDTO> ls = new List<TK_HDNhap_NSXDTO>();
            string struyvan = "Select * From dbo.HienThiDSHoaDonNhap WHERE  MaHDNhap = '" + mahd + "' ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                TK_HDNhap_NSXDTO dto = new TK_HDNhap_NSXDTO();
                dto.MaHDNhap = sr["MaHDNhap"].ToString();
                dto.NgayNhapHang = DateTime.Parse(sr["NgayNhapHang"].ToString());
                dto.TongTien = double.Parse(sr["TongTien"].ToString());
                dto.NVLap = sr["NVLap"].ToString();
                dto.HoTenNSX = sr["TenNSX"].ToString();
                dto.HoTenNV = sr["HoTenNV"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;

        }
	public HDNhapDTO DemMaHDN()
        {
            HDNhapDTO dto = null;
            string struyvan = "EXEC dbo.Proc_DemSoHDNhap ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                dto = new HDNhapDTO();
                dto.MaHDNhap = sr["SOHD"].ToString();
            }
            con.Close();
            sr.Close();
            return dto;
        }
    }
}
