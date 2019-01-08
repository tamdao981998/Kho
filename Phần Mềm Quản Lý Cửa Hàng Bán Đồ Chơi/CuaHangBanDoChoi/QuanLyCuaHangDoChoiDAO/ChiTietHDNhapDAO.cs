using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDAO
{
    public class ChiTietHDNhapDAO
    {
        public List<ChiTietHDNhapDTO> LOADCTHDB(string ma)
        {
            List<ChiTietHDNhapDTO> ls = new List<ChiTietHDNhapDTO>();
            string truyvan = "Select sp.TenSP, cthdb.* From SAN_PHAM sp,CHI_TIET_HDNHAP cthdb Where sp.MaSP=cthdb.MaSP AND MaHDNhap= '" + ma + "' ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                ChiTietHDNhapDTO dto = new ChiTietHDNhapDTO();
                dto.MaHDNhap = sr["MaHDNhap"].ToString();
                dto.MaSP = sr["MaSP"].ToString();
                dto.SoLuong = int.Parse(sr["SoLuong"].ToString());
                dto.DonGia = decimal.Parse(sr["DonGia"].ToString());
                dto.TenSP = sr["TenSP"].ToString(); 
                if (dto.MaHDNhap == ma)
                {
                    ls.Add(dto);
                }

            }
            sr.Close();
            con.Close();
            return ls;
        }
        public bool ThemCTHDN(ChiTietHDNhapDTO DTO)
        {
            string INSERT = "INSERT INTO CHI_TIET_HDNHAP VALUES(@MaHDNHAP,@MaSP,@SoLuong,@DonGia)";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@MaHDNHAP", DTO.MaHDNhap);
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


        public List<SP_CTHDN_LSP_HDN> LOADCTHDXUAT(string mahdn)
        {
            List<SP_CTHDN_LSP_HDN> ls = new List<SP_CTHDN_LSP_HDN>();
            string truyvan = " select sp.TenSP , lsp.TenLoaiSP,ct.* From SAN_PHAM sp , CHI_TIET_HDNHAP ct , LOAI_SAN_PHAM lsp WHERE sp.MaSP = ct.MaSP AND sp.MaLoaiSP = lsp.MaLoaiSP And MaHDNhap= '" + mahdn + "' ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                SP_CTHDN_LSP_HDN dto = new SP_CTHDN_LSP_HDN();
                dto.MaHDN = sr["MaHDNhap"].ToString();
                dto.TenLoaiSP = sr["TenLoaiSP"].ToString();
                dto.TongSL = int.Parse(sr["SoLuong"].ToString());
                dto.DonGia = double.Parse(sr["DonGia"].ToString());
                dto.TenSP = sr["TenSP"].ToString();
                if (dto.MaHDN == mahdn)
                {
                    ls.Add(dto);
                }

            }
            sr.Close();
            con.Close();
            return ls;
        }
    }
}
