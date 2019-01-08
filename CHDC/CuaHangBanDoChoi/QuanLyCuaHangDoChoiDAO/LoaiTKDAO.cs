using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDAO
{
    public class LoaiTKDAO
    {
        public List<LoaiTKDTO> LoadDSLoaiTK()
        {
            List<LoaiTKDTO> NXS = new List<LoaiTKDTO>();
            string truyvan = "SELECT *  FROM LOAI_TAI_KHOAN WHERE TINHTRANG=1 ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                LoaiTKDTO NX = new LoaiTKDTO();
                NX.MaLoaiTK = sr["MaLoaiTK"].ToString();
                NX.TenLoaiTK = sr["TenLoaiTK"].ToString();
                NX.TinhTrang =int.Parse(sr["TinhTrang"].ToString());
                NXS.Add(NX);
            }
            sr.Close();
            con.Close();
            return NXS;

        }
        public string MaLoaiTKLonNhat()
        {
            string strResult = null;
            string strTruyVan = "SELECT MAX(MaLoaiTK) FROM LOAI_TAI_KHOAN";
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

        public bool ThemLoaiTK(LoaiTKDTO DTO)
        {
            string INSERT = "INSERT INTO LOAI_TAI_KHOAN VALUES(@MaLoaiTK,@TenLoaiTK,@TinhTrang)";
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@MaLoaiTK", DTO.MaLoaiTK);
            p[1] = new SqlParameter("@TenLoaiTK", DTO.TenLoaiTK);
            p[2] = new SqlParameter("@TinhTrang", DTO.TinhTrang);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(INSERT, p, con);
            con.Close();
            return kq > 0;
        }
        public bool SuaLoaiTK(LoaiTKDTO DTO)
        {
            string UPDATE = "UPDATE LOAI_TAI_KHOAN SET TENLOAITK=@TenLoaiTK,TINHTRANG=@TINHTRANG WHERE MALOAITK=@MaLoaiTK";
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@MaLoaiTK", DTO.MaLoaiTK);
            p[1] = new SqlParameter("@TenLoaiTK", DTO.TenLoaiTK);
            p[2] = new SqlParameter("@TinhTrang", DTO.TinhTrang);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(UPDATE, p, con);
            con.Close();
            return kq > 0;
        }
        public bool XoaLoaiTK(LoaiTKDTO DTO)
        {
            string DELETE = "UPDATE LOAI_TAI_KHOAN SET TINHTRANG=0 WHERE  MALOAITK = @MaLoaiTK";
            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@MaLoaiTK", DTO.MaLoaiTK);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(DELETE, p, con);
            con.Close();
            return kq > 0;
        }
    }
}
