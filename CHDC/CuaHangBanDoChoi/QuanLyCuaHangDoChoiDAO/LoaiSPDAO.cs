using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDAO
{
    public class LoaiSPDAO
    {
        public List<LoaiSPDTO> layDSLoaiSP()
        {
            List<LoaiSPDTO> dto = new List<LoaiSPDTO>();
            string truyvan = "SELECT* FROM LOAI_SAN_PHAM WHERE TINHTRANG=1";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                LoaiSPDTO ls = new LoaiSPDTO();
                ls.MaLoaiSP = sr["MaLoaiSP"].ToString();
                ls.TenLoaiSP = sr["TenLoaiSP"].ToString();
                ls.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                dto.Add(ls);
            }
            sr.Close();
            con.Close();
            return dto;

        }

        public string MaLoaiSPLonNhat()
        {
            string strResult = null;
            string strTruyVan = "SELECT MAX(MALOAISP) FROM LOAI_SAN_PHAM";
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

        public bool ThemLOAISP(LoaiSPDTO dto)
        {
            string insert = "INSERT INTO LOAI_SAN_PHAM  VALUES(@MaLoaiSP,@TenLoaiSP,@TinhTrang)";
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@MaLoaiSP", dto.MaLoaiSP);
            p[1] = new SqlParameter("@TenLoaiSP", dto.TenLoaiSP);
            p[2] = new SqlParameter("@TinhTrang", dto.TinhTrang);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(insert, p, con);
            con.Close();
            return kq > 0;
        }


        public bool SuaLoaiSP(LoaiSPDTO dto)
        {
            string UPDATE = "UPDATE LOAI_SAN_PHAM SET TENLOAISP=@TenLoaiSP,TINHTRANG=@TinhTrang WHERE MALOAISP=@MaLoaiSP";
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@MaLoaiSP", dto.MaLoaiSP);
            p[1] = new SqlParameter("@TenLoaiSP", dto.TenLoaiSP);
            p[2] = new SqlParameter("@TinhTrang", dto.TinhTrang);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(UPDATE, p, con);
            con.Close();
            return kq > 0;
        }
        public bool XoaLoaiSP(LoaiSPDTO DTO)
        {
            string DELETE = "UPDATE LOAI_SAN_PHAM SET TINHTRANG=0 WHERE  MALOAISP = @MaLoaiSP";
            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@MaLoaiSP", DTO.MaLoaiSP);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(DELETE, p, con);
            con.Close();
            return kq > 0;
        }
        public LoaiSPDTO LayLoaiSanPham(string maLoai)
        {
            LoaiSPDTO lsp = null;
            string truyvan = "SELECT * FROM LOAI_SAN_PHAM WHERE MaLoaiSP =@maLoai";
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@maLoai", maLoai);
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, p, con);
            while (sr.Read())
            {
                lsp = new LoaiSPDTO();
                lsp.MaLoaiSP = sr["MaLoaiSP"].ToString();
                lsp.TenLoaiSP = sr["TenLoaiSP"].ToString();
                lsp.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
            }
            sr.Close();
            con.Close();
            return lsp;
        }
    }
}
