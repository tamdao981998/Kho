using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDAO
{
    public class ChiTietHDBanDAO
    {
        public List<ChiTietHDBanDTO> LOADCTHDB(string ma)
        {
            List<ChiTietHDBanDTO> ls = new List<ChiTietHDBanDTO>();
            string truyvan = "Select sp.TenSP, cthdb.* From SAN_PHAM sp,CHI_TIET_HDBAN cthdb Where sp.MaSP=cthdb.MaSP AND MaHDBan= '" + ma + "' ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan ,con);
            while(sr.Read())
            {
                ChiTietHDBanDTO dto = new ChiTietHDBanDTO();
                dto.MaHDBan = sr["MaHDBan"].ToString();
                dto.MaSP = sr["MaSP"].ToString();
                dto.SoLuong =int.Parse( sr["SoLuong"].ToString());
                dto.DonGia = decimal.Parse(sr["DonGia"].ToString());
                dto.TenSP = sr["TenSP"].ToString();


                if (dto.MaHDBan == ma)
                {
                    ls.Add(dto);
                }
            }
            sr.Close();
            con.Close();
            return ls;
        }
        public List<SP_CTHDBDTO> LOADCTHDXUAT(string ma)
        {
            List<SP_CTHDBDTO> ls = new List<SP_CTHDBDTO>();
            string truyvan = "Select sp.TenSP,cthdb.* From SAN_PHAM sp ,CHI_TIET_HDBAN cthdb Where sp.MaSP = cthdb.MaSP And MaHDBan='" + ma + "'";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                SP_CTHDBDTO dto = new SP_CTHDBDTO();
                dto.TenSP = sr["TenSP"].ToString();
                dto.SLSP = int.Parse(sr["SoLuong"].ToString());
                dto.Gia = decimal.Parse(sr["DonGia"].ToString());
                //dto.TongTien = decimal.Parse(sr["ThanhTien"].ToString());
                ls.Add(dto);
                
            }
            sr.Close();
            con.Close();
            return ls;
        }
        public bool ThemCTHDB(ChiTietHDBanDTO DTO)
        {
            string INSERT = "INSERT INTO CHI_TIET_HDBAN VALUES(@MaHDBan,@MaSP,@SoLuong,@DonGia)";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@MaHDBan", DTO.MaHDBan);
            p[1] = new SqlParameter("@MaSP", DTO.MaSP);
            p[2] = new SqlParameter("@SoLuong", DTO.SoLuong);
            p[3] = new SqlParameter("@DonGia", DTO.DonGia); 
            int kq = DataProvider.ThucThiCauLenh(INSERT, p, con);
            con.Close();
            return kq > 0;
        }
        public string MaCTHDBLonNhat()
        {
            string strResult = null;
            string strTruyVan = "SELECT MAX(MAHDBAN) FROM CHI_TIET_HDBAN";
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
