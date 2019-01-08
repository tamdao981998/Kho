using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDAO
{
    public class SanPhamDAO
    {
        public List<SanPhamDTO> LayDSSanPham()
        {
            List<SanPhamDTO> lsdto = new List<SanPhamDTO>();
            string truyvan = "SELECT * FROM SAN_PHAM WHERE SOLUONGTONKHO >0 AND TINHTRANG=1 ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                SanPhamDTO dto = new SanPhamDTO();
                dto.MaSP = sr["MaSP"].ToString();
                dto.TenSP = sr["TenSP"].ToString();
                dto.DoTuoi = sr["DoTuoi"].ToString();
                dto.MoTa = sr["MoTa"].ToString();
                dto.Gia = decimal.Parse(sr["Gia"].ToString());
                dto.SoLuongTonKho = int.Parse(sr["SoLuongTonKho"].ToString());
                dto.HinhAnh = sr["HinhAnh"].ToString();
                dto.MaLoaiSP = sr["MaLoaiSP"].ToString();
                dto.MaNSX = sr["MaNSX"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                lsdto.Add(dto);
            }
            sr.Close();
            con.Close();
            return lsdto;
        }

        public List<SanPhamDTO> LayDSSanPhamxoa()
        {
            List<SanPhamDTO> lsdto = new List<SanPhamDTO>();
            string truyvan = "SELECT * FROM SAN_PHAM WHERE SoLuongTonKho = 0 OR TINHTRANG=0";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                SanPhamDTO dto = new SanPhamDTO();
                dto.MaSP = sr["MaSP"].ToString();
                dto.TenSP = sr["TenSP"].ToString();
                dto.DoTuoi = sr["DoTuoi"].ToString();
                dto.MoTa = sr["MoTa"].ToString();
                dto.Gia = decimal.Parse(sr["Gia"].ToString());
                dto.SoLuongTonKho = int.Parse(sr["SoLuongTonKho"].ToString());
                dto.HinhAnh = sr["HinhAnh"].ToString();
                dto.MaLoaiSP = sr["MaLoaiSP"].ToString();
                dto.MaNSX = sr["MaNSX"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                lsdto.Add(dto);
            }
            sr.Close();
            con.Close();
            return lsdto;
        }
        public List<SanPhamDTO> LayDSSanPhamTheoTen(string tenSP)
        {
            List<SanPhamDTO> lsdto = new List<SanPhamDTO>();
            string truyvan = "SELECT * FROM SAN_PHAM WHERE TenSP like N'%" + tenSP +"%' ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                SanPhamDTO dto = new SanPhamDTO();
                dto.MaSP = sr["MaSP"].ToString();
                dto.TenSP = sr["TenSP"].ToString();
                dto.DoTuoi = sr["DoTuoi"].ToString();
                dto.MoTa = sr["MoTa"].ToString();
                dto.Gia = decimal.Parse(sr["Gia"].ToString());
                dto.SoLuongTonKho = int.Parse(sr["SoLuongTonKho"].ToString());
                dto.HinhAnh = sr["HinhAnh"].ToString();
                dto.MaLoaiSP = sr["MaLoaiSP"].ToString();
                dto.MaNSX = sr["MaNSX"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                lsdto.Add(dto);
            }
            sr.Close();
            con.Close();
            return lsdto;
        }
        public List<SanPhamDTO> LayDSSanPhamTheoNSX(string mansx)
        {
            List<SanPhamDTO> lsdto = new List<SanPhamDTO>();
            string truyvan = "SELECT * FROM SAN_PHAM WHERE MaNSX like N'%" + mansx + "%' ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                SanPhamDTO dto = new SanPhamDTO();
                dto.MaSP = sr["MaSP"].ToString();
                dto.TenSP = sr["TenSP"].ToString();
                dto.DoTuoi = sr["DoTuoi"].ToString();
                dto.MoTa = sr["MoTa"].ToString();
                dto.Gia = decimal.Parse(sr["Gia"].ToString());
                dto.SoLuongTonKho = int.Parse(sr["SoLuongTonKho"].ToString());
                dto.HinhAnh = sr["HinhAnh"].ToString();
                dto.MaLoaiSP = sr["MaLoaiSP"].ToString();
                dto.MaNSX = sr["MaNSX"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                lsdto.Add(dto);
            }
            sr.Close();
            con.Close();
            return lsdto;
        }
        public string MaSPLonNhat()
        {
            string strResult = null;
            string strTruyVan = "SELECT MAX(MASP) FROM SAN_PHAM";
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

        public bool ThemSP(SanPhamDTO dto)
        {
            string insert = "INSERT INTO SAN_PHAM  VALUES(@MaSP,@TenSP,@DoTuoi,@MoTa,@Gia,@SoLuongTonKho,@HinhAnh,@MaLoaiSP,@MaNSX,@TinhTrang)";
            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@MaSP", dto.MaSP);
            p[1] = new SqlParameter("@TenSP", dto.TenSP);
            p[2] = new SqlParameter("@DoTuoi", dto.DoTuoi);
            p[3] = new SqlParameter("@MoTa", dto.MoTa);
            p[4] = new SqlParameter("@Gia", dto.Gia);
            p[5] = new SqlParameter("@SoLuongTonKho", dto.SoLuongTonKho);
            p[6] = new SqlParameter("@HinhAnh", dto.HinhAnh);
            p[7] = new SqlParameter("@MaLoaiSP", dto.MaLoaiSP);
            p[8] = new SqlParameter("@MaNSX", dto.MaNSX);
            p[9] = new SqlParameter("@TinhTrang", dto.TinhTrang);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(insert, p, con);
            con.Close();
            return kq > 0;
        }

        public bool SuaSoLuong(string sl,string ma)
        {
            string UPDATE = "UPDATE SAN_PHAM SET SOLUONGTONKHO -= @sl WHERE MASP=@ma";
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@sl", sl);
            p[1] = new SqlParameter("@ma", ma);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(UPDATE, p, con);
            con.Close();
            return kq > 0;
        }
        public bool SuaNhapSoLuong(string sl, string ma)
        {
            string UPDATE = "UPDATE SAN_PHAM SET SOLUONGTONKHO += @sl WHERE MASP=@ma";
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@sl", sl);
            p[1] = new SqlParameter("@ma", ma);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(UPDATE, p, con);
            con.Close();
            return kq > 0;
        }
        public bool SuaTTSP(SanPhamDTO dto)
        {
            string UPDATE = "UPDATE SAN_PHAM SET TENSP=@TenSP,DOTUOI=@DoTuoi,MOTA=@MoTa,GIA=@Gia,SOLUONGTONKHO=@SoLuongTonKho,HINHANH=@HinhAnh,MALOAISP=@MaLoaiSP,MANSX=@MaNSX,TINHTRANG=@TinhTrang WHERE MASP=@MaSP";
            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@MaSP", dto.MaSP);
            p[1] = new SqlParameter("@TenSP", dto.TenSP);
            p[2] = new SqlParameter("@DoTuoi", dto.DoTuoi);
            p[3] = new SqlParameter("@MoTa", dto.MoTa);
            p[4] = new SqlParameter("@Gia", dto.Gia);
            p[5] = new SqlParameter("@SoLuongTonKho", dto.SoLuongTonKho);
            p[6] = new SqlParameter("@HinhAnh", dto.HinhAnh);
            p[7] = new SqlParameter("@MaLoaiSP", dto.MaLoaiSP);
            p[8] = new SqlParameter("@MaNSX", dto.MaNSX);
            p[9] = new SqlParameter("@TinhTrang", dto.TinhTrang);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(UPDATE, p, con);
            con.Close();
            return kq > 0;
        }
        public bool XoaSP(SanPhamDTO DTO)
        {
            string DELETE = "UPDATE SAN_PHAM SET TINHTRANG=0 WHERE  MASP = @MaSP";
            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@MaSP", DTO.MaSP);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(DELETE, p, con);
            con.Close();
            return kq > 0;
        }


        public List<SanPhamDTO> TimKiemTheoMa(string ma)
        {
            List<SanPhamDTO> lsdto = new List<SanPhamDTO>();
            string truyvan = "SELECT * FROM SAN_PHAM SAN_PHAM WHERE TENSP LIKE N'%" + ma + "%' OR MASP LIKE N'%" + ma + "%'";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                SanPhamDTO dto = new SanPhamDTO();
                dto.MaSP = sr["MaSP"].ToString();
                dto.TenSP = sr["TenSP"].ToString();
                dto.DoTuoi = sr["DoTuoi"].ToString();
                dto.MoTa = sr["MoTa"].ToString();
                dto.Gia = decimal.Parse(sr["Gia"].ToString());
                dto.SoLuongTonKho = int.Parse(sr["SoLuongTonKho"].ToString());
                dto.HinhAnh = sr["HinhAnh"].ToString();
                dto.MaLoaiSP = sr["MaLoaiSP"].ToString();
                dto.MaNSX = sr["MaNSX"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                lsdto.Add(dto);
            }
            sr.Close();
            con.Close();
            return lsdto;
        }

        public List<SanPhamDTO> TKTHEOGIA(string giatu,string giaden)
        {
            List<SanPhamDTO> lsdto = new List<SanPhamDTO>();
            string truyvan = "SELECT * FROM SAN_PHAM SAN_PHAM WHERE GIA >= "+giatu+" AND GIA <= "+giaden+"";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                SanPhamDTO dto = new SanPhamDTO();
                dto.MaSP = sr["MaSP"].ToString();
                dto.TenSP = sr["TenSP"].ToString();
                dto.DoTuoi = sr["DoTuoi"].ToString();
                dto.MoTa = sr["MoTa"].ToString();
                dto.Gia = decimal.Parse(sr["Gia"].ToString());
                dto.SoLuongTonKho = int.Parse(sr["SoLuongTonKho"].ToString());
                dto.HinhAnh = sr["HinhAnh"].ToString();
                dto.MaLoaiSP = sr["MaLoaiSP"].ToString();
                dto.MaNSX = sr["MaNSX"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                lsdto.Add(dto);
            }
            sr.Close();
            con.Close();
            return lsdto;
        }

        public List<SanPhamDTO> TKTHEOGIAten(string ma,string giatu, string giaden)
        {
            List<SanPhamDTO> lsdto = new List<SanPhamDTO>();
            string truyvan = "SELECT * FROM SAN_PHAM SAN_PHAM WHERE TENSP LIKE N'%"+ma+"%' AND GIA >= " + giatu + " AND GIA <= " + giaden + "";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                SanPhamDTO dto = new SanPhamDTO();
                dto.MaSP = sr["MaSP"].ToString();
                dto.TenSP = sr["TenSP"].ToString();
                dto.DoTuoi = sr["DoTuoi"].ToString();
                dto.MoTa = sr["MoTa"].ToString();
                dto.Gia = decimal.Parse(sr["Gia"].ToString());
                dto.SoLuongTonKho = int.Parse(sr["SoLuongTonKho"].ToString());
                dto.HinhAnh = sr["HinhAnh"].ToString();
                dto.MaLoaiSP = sr["MaLoaiSP"].ToString();
                dto.MaNSX = sr["MaNSX"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                lsdto.Add(dto);
            }
            sr.Close();
            con.Close();
            return lsdto;
        }
        public List<SanPhamDTO> LayDSSanPhamTheoLoai(string maLoai)
        {
            List<SanPhamDTO> lsdto = new List<SanPhamDTO>();
            string truyvan = "SELECT * FROM SAN_PHAM WHERE MaLoaiSP = '" + maLoai + "' ";
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@maLoai", maLoai);
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                SanPhamDTO dto = new SanPhamDTO();
                dto.MaSP = sr["MaSP"].ToString();
                dto.TenSP = sr["TenSP"].ToString();
                dto.DoTuoi = sr["DoTuoi"].ToString();
                dto.MoTa = sr["MoTa"].ToString();
                dto.Gia = decimal.Parse(sr["Gia"].ToString());
                dto.SoLuongTonKho = int.Parse(sr["SoLuongTonKho"].ToString());
                dto.HinhAnh = sr["HinhAnh"].ToString();
                dto.MaLoaiSP = sr["MaLoaiSP"].ToString();
                dto.MaNSX = sr["MaNSX"].ToString();
                if(maLoai == dto.MaLoaiSP)
                lsdto.Add(dto);
            }
            sr.Close();
            con.Close();
            return lsdto;
        }
        public List<SP_CTHDBDTO> LayDSSPDaBan(DateTime TimeTu, DateTime TimeDen)
        {
            List<SP_CTHDBDTO> spb = new List<SP_CTHDBDTO>();
            string truyvan = "Select * from dbo.HienThiDSSanPhamDaBan Where NgayLapHD between '" + TimeTu + "' AND '" + TimeDen + "' ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                SP_CTHDBDTO dto = new SP_CTHDBDTO();
                dto.MaSP = sr["MaSP"].ToString();
                dto.TenSP = sr["TenSP"].ToString();
                dto.Gia = decimal.Parse(sr["DonGia"].ToString());
                dto.SLSP = int.Parse(sr["SLSP"].ToString());
                dto.TenLoaiSP = sr["TenLoaiSP"].ToString();
                dto.TongTien = decimal.Parse(sr["TongTien"].ToString());
                dto.NgayLapHD = DateTime.Parse(sr["NgayLapHD"].ToString());
                spb.Add(dto);
            }
            sr.Close();
            con.Close();
            return spb;
        }
        public List<SP_CTHDBDTO> LayDSSPDaNhap(DateTime TimeTu, DateTime TimeDen)
        {
            List<SP_CTHDBDTO> spb = new List<SP_CTHDBDTO>();
            string truyvan = "EXEC Proc_HienThiSanPhamNhapTheoNgay '" + TimeTu + "','" + TimeDen + "'";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                SP_CTHDBDTO dto = new SP_CTHDBDTO();
                dto.MaSP = sr["MaSP"].ToString();
                dto.TenSP = sr["TenSP"].ToString();
                dto.Gia = decimal.Parse(sr["DonGia"].ToString());
                dto.SLSP = int.Parse(sr["SLSP"].ToString());
                dto.TenLoaiSP = sr["TenLoaiSP"].ToString();
                dto.TongTien = decimal.Parse(sr["TongTien"].ToString());
                dto.NgayLapHD = DateTime.Parse(sr["NgayLapHD"].ToString());
                spb.Add(dto);
            }
            sr.Close();
            con.Close();
            return spb;
        }
        public List<SP_CTHDBDTO> SPBanChayNhat(DateTime TimeTu, DateTime TimeDen)
        {
            List<SP_CTHDBDTO> spb = new List<SP_CTHDBDTO>();
            string truyvan = "EXEC Proc_SPBanChayNhat '" + TimeTu + "','" + TimeDen + "'";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                SP_CTHDBDTO dto = new SP_CTHDBDTO();
                //dto.MaSP = sr["MaSP"].ToString();
                dto.TenSP = sr["TenSP"].ToString();
                //dto.Gia = double.Parse(sr["DonGia"].ToString());
                dto.SLSP = int.Parse(sr["SLSP"].ToString());
                //dto.TenLoaiSP = sr["TenLoaiSP"].ToString();
                dto.TongTien = decimal.Parse(sr["TongTien"].ToString());
                //dto.NgayLapHD = DateTime.Parse(sr["NgayLapHD"].ToString());
                spb.Add(dto);
            }
            sr.Close();
            con.Close();
            return spb;
        }
	public SP_CTHDBDTO TongSPDaBan()
        {
            SP_CTHDBDTO dto = null;
            string truyvan = "EXEC dbo.Proc_DemSoSPDaBan ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                dto = new SP_CTHDBDTO();
               
                    dto.SLSP = int.Parse(sr["SOSP"].ToString());
                
            }
            sr.Close();
            con.Close();
            return dto;  
        }

        public SP_CTHDN_LSP_HDN TongSPNhap()
        {

            SP_CTHDN_LSP_HDN dto = null;
            string truyvan = "EXEC dbo.Proc_DemSoSPDaNhap ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                dto = new SP_CTHDN_LSP_HDN();

                dto.TongSL = int.Parse(sr["SOSP"].ToString());

            }
            sr.Close();
            con.Close();
            return dto;  
        }
    }
}
