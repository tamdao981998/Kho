using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDAO
{
    public class ChiTietDDHDAO
    {
        public List<ChiTietDDHDTO> LOADCTHDDH(string ma)
        {
            List<ChiTietDDHDTO> ls = new List<ChiTietDDHDTO>();
            string truyvan = "SELECT * FROM CHI_TIET_DON_DH WHERE MADONDH= '" + ma + "' ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                ChiTietDDHDTO dto = new ChiTietDDHDTO();
                dto.MaDDH = sr["MaDonDH"].ToString();
                dto.MaSP = sr["MaSP"].ToString();
                dto.SoLuong1 = int.Parse(sr["SoLuong"].ToString());
                dto.DonGia = decimal.Parse(sr["DonGia"].ToString());
                if (dto.MaDDH == ma)
                {
                    ls.Add(dto);
                }

            }
            sr.Close();
            con.Close();
            return ls;
        }

        public bool ThemCTDDH(ChiTietDDHDTO DTO)
        {
            string INSERT = "INSERT INTO CHI_TIET_DON_DH VALUES(@MaDDH,@MaSP,@SoLuong,@DonGia)";
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@MaDDH", DTO.MaDDH);
            p[1] = new SqlParameter("@MaSP", DTO.MaSP);
            p[2] = new SqlParameter("@SoLuong", DTO.SoLuong1);
            p[3] = new SqlParameter("@DonGia", DTO.DonGia);

            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(INSERT, p, con);
            con.Close();
            return kq > 0;
        }
        public string MaCTCTDDHLonNhat()
        {
            string strResult = null;
            string strTruyVan = "SELECT MAX(MADDH) FROM CHI_TIET_DON_DH";
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
    }
}
