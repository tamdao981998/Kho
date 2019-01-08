using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiDAO
{
    public class DonDatHangDAO
    {
        public List<DonDatHangDTO> Laydsdondathang()
        {
            List<DonDatHangDTO> ls = new List<DonDatHangDTO>();
            string truyvan = "SELECT * FROM DON_DAT_HANG";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while(sr.Read())
            {
                DonDatHangDTO dto = new DonDatHangDTO();
                dto.MaDonDH = sr["MaDonDH"].ToString();
                dto.NgayDat = DateTime.Parse(sr["NgayDat"].ToString());
                dto.NgayGiao = DateTime.Parse(sr["NgayGiao"].ToString());
                dto.DiaChiGiao = sr["DiaChiGiao"].ToString();
                dto.SoDienThoai = int.Parse(sr["SoDienThoai"].ToString());
                dto.TongTien = decimal.Parse(sr["TongTien"].ToString());
                dto.KhachHangDat = sr["KhachHangDat"].ToString();
                dto.NVLap = sr["NVLap"].ToString();
                dto.TinhTrang =int.Parse(sr["TinhTrang"].ToString());
                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }


        public bool SuaDDH(DonDatHangDTO DTO)
        {
            string UPDATE = "UPDATE DON_DAT_HANG SET NGAYDAT=@NgayDat,NGAYGIAO=@NgayGiao,DIACHIGIAO=@DiaChiGiao,SODIENTHOAI=@SDT,TONGTIEN=@TongTien,KHACHHANGDAT=@MaKH,NVLAP=@NVLap,TINHTRANG=@TinhTrang WHERE MADONDH=@MaDonDH";
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@MaDonDH", DTO.MaDonDH);
            p[1] = new SqlParameter("@NgayDat", DTO.NgayDat);
            p[2] = new SqlParameter("@NgayGiao", DTO.NgayGiao);
            p[3] = new SqlParameter("@DiaChiGiao", DTO.DiaChiGiao);
            p[4] = new SqlParameter("@SDT", DTO.SoDienThoai);
            p[5] = new SqlParameter("@TongTien", DTO.TongTien);
            p[6] = new SqlParameter("@MaKH", DTO.KhachHangDat);
            p[7] = new SqlParameter("@NVLap", DTO.NVLap);
            p[8] = new SqlParameter("@TinhTrang", DTO.TinhTrang);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(UPDATE, p, con);
            con.Close();
            return kq > 0;

        }


        public bool XoaDDH(DonDatHangDTO DTO)
        {
            string DELETE = "UPDATE DON_DAT_HANG SET TINHTRANG=0 WHERE  MADONDH = @MaDonDH";
            SqlParameter[] p = new SqlParameter[1];

            p[0] = new SqlParameter("@MaDonDH", DTO.MaDonDH);
            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(DELETE, p, con);
            con.Close();
            return kq > 0;
        }

        public string MaDDHLonNhat()
        {
            string strResult = null;
            string strTruyVan = "SELECT MAX(MADONDH) FROM DON_DAT_HANG";
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

        public bool ThemDDH(DonDatHangDTO DTO)
        {
            string INSERT = "INSERT INTO DON_DAT_HANG VALUES(@MADONNDH,@NgayDAT,@NgayGiao,@DiaChi,@SDT,@TongTien,@MaKH,@NVLapHD,@TinhTrang)";
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@MADONNDH", DTO.MaDonDH);
            p[1] = new SqlParameter("@NgayDAT", DTO.NgayDat);
            p[2] = new SqlParameter("@NgayGiao", DTO.NgayGiao);
            p[3] = new SqlParameter("@DiaChi", DTO.DiaChiGiao);
            p[4] = new SqlParameter("@SDT", DTO.SoDienThoai);
            p[5] = new SqlParameter("@TongTien",DTO.TongTien );
            p[6] = new SqlParameter("@MaKH", DTO.KhachHangDat);
            p[7] = new SqlParameter("@NVLapHD", DTO.NVLap);
            p[8] = new SqlParameter("@TinhTrang", 1);

            SqlConnection con = DataProvider.TaoKetNoi();
            int kq = DataProvider.ThucThiCauLenh(INSERT, p, con);
            con.Close();
            return kq > 0;
        }
        public List<DonDatHangDTO> TimKiem(string ten)
        {
            List<DonDatHangDTO> ls = new List<DonDatHangDTO>();
            string truyvan = "SELECT * FROM DON_DAT_HANG WHERE MADONDH LIKE N'%"+ten+"%'";
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlDataReader sr = DataProvider.TruyVanDuLieu(truyvan, con);
            while (sr.Read())
            {
                DonDatHangDTO dto = new DonDatHangDTO();
                dto.MaDonDH = sr["MaDonDH"].ToString();
                dto.NgayDat = DateTime.Parse(sr["NgayDat"].ToString());
                dto.NgayGiao = DateTime.Parse(sr["NgayGiao"].ToString());
                dto.DiaChiGiao = sr["DiaChiGiao"].ToString();
                dto.SoDienThoai = int.Parse(sr["SoDienThoai"].ToString());
                dto.TongTien = decimal.Parse(sr["TongTien"].ToString());
                dto.KhachHangDat = sr["KhachHangDat"].ToString();
                dto.NVLap = sr["NVLap"].ToString();
                dto.TinhTrang = int.Parse(sr["TinhTrang"].ToString());
                ls.Add(dto);
            }
            con.Close();
            sr.Close();
            return ls;
        }
        }
    }
