using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDAO
{
    public class HDBanDAO
    {
     
        public List<HDBanDTO> LAYDSHDBanxoa()
        {
            List<HDBanDTO> ls = new List<HDBanDTO>();
            string struyvan = "SELECT * FROM HOA_DON_BAN Where TinhTrang=0 ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                HDBanDTO dto = new HDBanDTO();
                dto.MaHDBan = sr["MaHDBan"].ToString();
                dto.NgayLapHD = DateTime.Parse(sr["NgayLapHD"].ToString());
                dto.TongTien = decimal.Parse(sr["TongTien"].ToString());
                dto.MaKH = sr["MaKH"].ToString();
                dto.NVLapHD = sr["NVLapHD"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                dto.TienKhachTra = decimal.Parse(sr["TienKhachTra"].ToString());
                dto.TienDu = decimal.Parse(sr["TienDu"].ToString());

                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }
        public List<HDBanDTO> LAYDSHDBan()
        {
            List<HDBanDTO> ls = new List<HDBanDTO>();
            string struyvan = "SELECT * FROM HOA_DON_BAN Where TinhTrang=1 ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while(sr.Read())
            {
                HDBanDTO dto = new HDBanDTO();
                dto.MaHDBan = sr["MaHDBan"].ToString();
                dto.NgayLapHD = DateTime.Parse(sr["NgayLapHD"].ToString());
                dto.TongTien = decimal.Parse(sr["TongTien"].ToString());
                dto.MaKH = sr["MaKH"].ToString();
                dto.NVLapHD = sr["NVLapHD"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                dto.TienKhachTra = decimal.Parse(sr["TienKhachTra"].ToString());
                dto.TienDu = decimal.Parse(sr["TienDu"].ToString());
               
                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }
        public List<TK_KH_HDBDTOcs> LAYDSHDBanTheoMaHD(string mahd)
        {
            List<TK_KH_HDBDTOcs> ls = new List<TK_KH_HDBDTOcs>();
            string struyvan = "Select tk.HoTenNV,kh.HoTenKH,hdb.* From TAI_KHOAN tk,KHACH_HANG kh , HOA_DON_BAN hdb WHERE kh.MaKH=hdb.MaKH AND tk.MaNV = hdb.NVLapHD AND MaHDBan='" + mahd + "' ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                TK_KH_HDBDTOcs dto = new TK_KH_HDBDTOcs();
                dto.MaHDBan = sr["MaHDBan"].ToString();
                dto.NgayLapHD = DateTime.Parse(sr["NgayLapHD"].ToString());
                dto.TongTien = double.Parse(sr["TongTien"].ToString());
                dto.HoTenNV = sr["HoTenNV"].ToString();
                dto.HoTenKH = sr["HoTenKH"].ToString();
                dto.TienKhachTra = decimal.Parse(sr["TienKhachTra"].ToString());
                dto.TienDu = decimal.Parse(sr["TienDu"].ToString());

                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }
        public bool SuaHDB(HDBanDTO DTO)
        {
            string UPDATE = "UPDATE HOA_DON_BAN SET NGAYLAPHD=@NgayLapHD,TONGTIEN=@TongTien,MAKH=@MaKH,NVLAPHD=@NVLapHD,TINHTRANG=@TinhTrang WHERE MAHDBAN=@MaHDBan";
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@MaHDBan", DTO.MaHDBan);
            p[1] = new SqlParameter("@NgayLapHD", DTO.NgayLapHD);
            p[2] = new SqlParameter("@TongTien", DTO.TongTien);
            p[3] = new SqlParameter("@MaKH", DTO.MaKH);
            p[4] = new SqlParameter("@NVLapHD", DTO.NVLapHD);
            p[5] = new SqlParameter("@TinhTrang", DTO.TinhTrang);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(UPDATE, p, con);
            con.Close();
            return kq > 0;

        }


        public bool XoaHDB(HDBanDTO DTO)
        {
            string DELETE = "UPDATE HOA_DON_BAN SET TINHTRANG=0 WHERE  MAHDBAN = @MaHDBan";
            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@MaHDBan", DTO.MaHDBan);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(DELETE, p, con);
            con.Close();
            return kq > 0;
        }

        public bool ThemHDB(HDBanDTO DTO)
        {
            string INSERT = "INSERT INTO HOA_DON_BAN VALUES(@MaHDBan,@NgayLapHD,@TongTien,@MaKH,@NVLapHD,@TinhTrang,@TienKhachTra,@TienDu)";
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@MaHDBan", DTO.MaHDBan);
            p[1] = new SqlParameter("@NgayLapHD", DTO.NgayLapHD);
            p[2] = new SqlParameter("@TongTien", DTO.TongTien);
            p[3] = new SqlParameter("@MaKH", DTO.MaKH);
            p[4] = new SqlParameter("@NVLapHD", DTO.NVLapHD);
            p[5] = new SqlParameter("@TinhTrang", 1);
            p[6] = new SqlParameter("@TienKhachTra", DTO.TienKhachTra);
            p[7] = new SqlParameter("@TienDu", DTO.TienDu);
          
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(INSERT, p, con);
            con.Close();
            return kq > 0;
        }
        public string MaHDBLonNhat()
        {
            string strResult = null;
            string strTruyVan = "SELECT MAX(MAHDBAN) FROM HOA_DON_BAN";
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


        public List<HDBanDTO> TimKiem(string ma)
        {
            List<HDBanDTO> ls = new List<HDBanDTO>();
            string struyvan = "SELECT * FROM HOA_DON_BAN WHERE MAHDBAN LIKE N'%"+ma+"%'";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                HDBanDTO dto = new HDBanDTO();
                dto.MaHDBan = sr["MaHDBan"].ToString();
                dto.NgayLapHD = DateTime.Parse(sr["NgayLapHD"].ToString());
                dto.TongTien = decimal.Parse(sr["TongTien"].ToString());
                dto.MaKH = sr["MaKH"].ToString();
                dto.NVLapHD = sr["NVLapHD"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());

                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }
        public List<TK_KH_HDBDTOcs> LAYDSHDBanTheoNgay(DateTime TimeTu, DateTime TimeDen)
        {
            List<TK_KH_HDBDTOcs> ls = new List<TK_KH_HDBDTOcs>();
            string struyvan = "Select * From HienThiDSHoaDonBan Where TinhTrang = 1 AND NgayLapHD Between '" + TimeTu + "' AND  '" + TimeDen + "'";
            //SqlParameter[] p = new SqlParameter[2];
            //p[1] = new SqlParameter("@TimeTu",TimeTu);
            //p[1] = new SqlParameter("@TimeTu", TimeDen);
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                TK_KH_HDBDTOcs dto = new TK_KH_HDBDTOcs();
                dto.MaHDBan = sr["MaHDBan"].ToString();
                dto.HoTenKH = sr["HoTenKH"].ToString();
                dto.HoTenNV = sr["HoTenNV"].ToString();
                dto.NgayLapHD = DateTime.Parse(sr["NgayLapHD"].ToString());
                dto.TongTien = double.Parse(sr["TongTien"].ToString());
                dto.MaKH = sr["MaKH"].ToString();
                dto.NVLapHD = sr["NVLapHD"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }
        //Lay DS Hoa don huy
        public List<TK_KH_HDBDTOcs> LayDSHoaDonBanHuy(DateTime TimeTu, DateTime TimeDen)
        {
            List<TK_KH_HDBDTOcs> ls = new List<TK_KH_HDBDTOcs>();
            string struyvan = "Select * From dbo.HienThiDSHoaDonBan Where TinhTrang =0 AND NgayLapHD Between '" + TimeTu + "' AND  '" + TimeDen + "'";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                TK_KH_HDBDTOcs dto = new TK_KH_HDBDTOcs();
                dto.MaHDBan = sr["MaHDBan"].ToString();
                dto.HoTenKH = sr["HoTenKH"].ToString();
                dto.HoTenNV = sr["HoTenNV"].ToString();
                dto.NgayLapHD = DateTime.Parse(sr["NgayLapHD"].ToString());
                dto.TongTien = double.Parse(sr["TongTien"].ToString());
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }

        public List<TK_HDB_CTHDBDTO> LayTongDoanhThuTheoNhanVien(string manv, DateTime TimeTu, DateTime TimeDen)
        {
            List<TK_HDB_CTHDBDTO> ls = new List<TK_HDB_CTHDBDTO>();
            string struyvan = "Select * from dbo.HienThiTongDoanhThuTheoNV Where NVLapHD ='" + manv + "' AND NgayLap Between '" + TimeTu + "' AND  '" + TimeDen + "'";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                TK_HDB_CTHDBDTO dto = new TK_HDB_CTHDBDTO();
                dto.MaNV = sr["NVLapHD"].ToString();
                dto.HoTenNV = sr["HoTenNV"].ToString();
                //dto.NgayLapHD = DateTime.Parse(sr["NgayLap"].ToString());
                dto.TongDoanhThu = double.Parse(sr["TongDoanhThu"].ToString());
                dto.TongSL = int.Parse(sr["SLSP"].ToString());
                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }
        public List<HDBanDTO> LayTongDoanhThuTheoThang(DateTime ThangTu, DateTime ThangDen)
        {
            List<HDBanDTO> ls = new List<HDBanDTO>();
            string struyvan = "EXEC Proc_HienThiTongDoanhThuTheoThang '" + ThangTu + "'  , '" + ThangDen + "'";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                HDBanDTO dto = new HDBanDTO();
                dto.NgayLapHD = DateTime.Parse(sr["NgayLapHD"].ToString());
                dto.TongTien = decimal.Parse(sr["TongDoanhThu"].ToString());
                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }
   public HDBanDTO DemMaHDBan()
        {
            HDBanDTO dto = null;
            string struyvan = "Exec dbo.Proc_DemSoHDBan ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                dto = new HDBanDTO();
                dto.MaHDBan = sr["SOHD"].ToString();
            }
            con.Close();
            sr.Close();
            return dto;
        }



        public HDBanDTO DemSoHDHuy()
        {
            HDBanDTO dto = null;
            string struyvan = "EXEC dbo.Proc_DemSoHDHuy ";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                dto = new HDBanDTO();
                dto.MaHDBan = sr["SOHD"].ToString();
            }
            con.Close();
            sr.Close();
            return dto;
        }

        public HDBanDTO TongDoanhThuTrongNgay()
        {
            HDBanDTO dto = null;
            string struyvan = "EXEC dbo.Proc_TongDoanhThuTrongNgay";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(struyvan, con);
            while (sr.Read())
            {
                dto = new HDBanDTO();
                dto.TongTien = decimal.Parse(sr["TongDT"].ToString());
            }
            con.Close();
            sr.Close();
            return dto;
        }
    }
}
