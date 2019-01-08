using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDAO
{
    public  class NXSDAO
    {

        public List<NSXDTO> LoadDSNXSxoa()
        {
            List<NSXDTO> NXS = new List<NSXDTO>();
            string truyvan = "SELECT *  FROM NHA_SAN_XUAT  Where TinhTrang=0 ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                NSXDTO NX = new NSXDTO();
                NX.MaNSX = sr["MaNSX"].ToString();
                NX.TenNSX = sr["TenNSX"].ToString();
                NX.DiaChi = sr["DiaChi"].ToString();
                NX.SDT = int.Parse(sr["SoDienThoai"].ToString());
                NX.TinhTrang = int.Parse(sr["TinhTrang"].ToString());

                NXS.Add(NX);
            }
            sr.Close();
            con.Close();
            return NXS;

        }
        public List<NSXDTO> LoadDSNXS()
        {
            List<NSXDTO> NXS = new List<NSXDTO>();
            string truyvan = "SELECT *  FROM NHA_SAN_XUAT  Where TinhTrang=1 ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                NSXDTO NX = new NSXDTO();
                NX.MaNSX = sr["MaNSX"].ToString();
                NX.TenNSX = sr["TenNSX"].ToString();
                NX.DiaChi = sr["DiaChi"].ToString();
                NX.SDT = int.Parse(sr["SoDienThoai"].ToString());
                NX.TinhTrang =int.Parse( sr["TinhTrang"].ToString());
                
                NXS.Add(NX);
            }
            sr.Close();
            con.Close();
            return NXS;

        }

        public bool ThemNSX(NSXDTO dto)
        {
            string insert = "INSERT INTO NHA_SAN_XUAT ([MANSX],[TENNSX],[DIACHI],[SODIENTHOAI],[TINHTRANG]) VALUES(@MaNSX,@TenNSX,@DiaChi,@SDT,@TinhTrang)";
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@MaNSX", dto.MaNSX);
            p[1] = new SqlParameter("@TenNSX", dto.TenNSX);
            p[2] = new SqlParameter("@DiaChi", dto.DiaChi);
            p[3] = new SqlParameter("@SDT", dto.SDT);
            p[4] = new SqlParameter("@TinhTrang", dto.TinhTrang);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(insert, p, con);
            con.Close();
            return kq > 0;
        }
        public string MaNXSLonNhat()
        {
            string strResult = null;
            string strTruyVan = "SELECT MAX(MaNSX) FROM NHA_SAN_XUAT";
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
        public bool SuaTTNSX(NSXDTO DTO)
        {
            string UPDATE = "UPDATE NHA_SAN_XUAT SET TENNSX=@TenNSX,DIACHI=@DiaChi,SODIENTHOAI=@SDT,TINHTRANG=@TinhTrang WHERE MANSX=@MaNSX";
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@TenNSX", DTO.TenNSX);
            p[1] = new SqlParameter("@DiaChi", DTO.DiaChi);
            p[2] = new SqlParameter("@TinhTrang", DTO.TinhTrang);
            p[3] = new SqlParameter("@MaNSX", DTO.MaNSX);
            p[4] = new SqlParameter("@SDT", DTO.SDT);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(UPDATE, p, con);
            con.Close();
            return kq > 0;
        }
        public bool XoanNSX(NSXDTO DTO)
        {
            string DELETE = "UPDATE NHA_SAN_XUAT SET TINHTRANG=0 WHERE  MANSX = @MaNSX";
            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@MaNSX", DTO.MaNSX);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(DELETE, p, con);
            con.Close();
            return kq > 0;
        }

        public List<NSXDTO> TimKiem(string ten)
        {
            List<NSXDTO> NXS = new List<NSXDTO>();
            string truyvan = "SELECT *  FROM NHA_SAN_XUAT WHERE TENNSX LIKE N'%" + ten + "%' OR MANSX LIKE N'%" + ten + "%' ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                NSXDTO NX = new NSXDTO();
                NX.MaNSX = sr["MaNSX"].ToString();
                NX.TenNSX = sr["TenNSX"].ToString();
                NX.DiaChi = sr["DiaChi"].ToString();
                NX.SDT = int.Parse(sr["SoDienThoai"].ToString());
                NX.TinhTrang = int.Parse(sr["TinhTrang"].ToString());

                NXS.Add(NX);
            }
            sr.Close();
            con.Close();
            return NXS;

        }

          
    }
}
