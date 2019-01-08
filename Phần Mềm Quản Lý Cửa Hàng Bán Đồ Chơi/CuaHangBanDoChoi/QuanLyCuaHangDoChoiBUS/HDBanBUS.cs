using QuanLyCuaHangDoChoiDAO;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiBUS
{
    public class HDBanBUS
    {

        public List<HDBanDTO> LAYDSHDBanxoa()
        {
            HDBanDAO dao = new HDBanDAO();
            return dao.LAYDSHDBanxoa();
            
        }
        public List<HDBanDTO> LAYHDBan()
        {
            HDBanDAO dao = new HDBanDAO();
            return dao.LAYDSHDBan();
        }
        public bool SUAHDB(HDBanDTO DTO)
        {
            HDBanDAO DAO = new HDBanDAO();
            return DAO.SuaHDB(DTO);
        }
        public bool XoaHDB(HDBanDTO DTO)
        {
            HDBanDAO dao = new HDBanDAO();
            return dao.XoaHDB(DTO);
        }
        public bool ThemHDB(HDBanDTO DTO)
        {
            HDBanDAO dao = new HDBanDAO();
            return dao.ThemHDB(DTO);
        }
        public string LayMaHDBTiepTheo()
        {
           
            HDBanDAO Dao = new HDBanDAO();
            string MAHDB = Dao.MaHDBLonNhat();
            if (string.IsNullOrEmpty(MAHDB))
            {
                return "HDB001";
            }
            else
            {
                int ChuyenSo = int.Parse(MAHDB.Replace("HDB", ""));
                return "HDB" + (ChuyenSo + 1).ToString("000");
            }
        }
        public List<HDBanDTO> TimKiem(string ma)
        {
            HDBanDAO dao = new HDBanDAO();
            return dao.TimKiem(ma);
        }
        public List<TK_KH_HDBDTOcs> LAYHDBanTheoNgay(DateTime TimeTu, DateTime TimeDen)
        {
            HDBanDAO dao = new HDBanDAO();
            return dao.LAYDSHDBanTheoNgay(TimeTu, TimeDen);
        }
        public List<TK_HDB_CTHDBDTO> LayTongDoanhThuTheoNhanVien(string manv, DateTime TimeTu, DateTime TimeDen)
        {
            HDBanDAO dao = new HDBanDAO();
            return dao.LayTongDoanhThuTheoNhanVien(manv, TimeTu, TimeDen);
        }
        public List<TK_KH_HDBDTOcs> LayDSHoaDonBanHuy(DateTime TimeTu, DateTime TimeDen)
        {
            HDBanDAO dao = new HDBanDAO();
            return dao.LayDSHoaDonBanHuy(TimeTu, TimeDen);
        }
        public List<TK_KH_HDBDTOcs> LAYDSHDBanTheoMaHD(string mahd)
        {
            HDBanDAO dao = new HDBanDAO();
            return dao.LAYDSHDBanTheoMaHD(mahd);
        }
        public List<HDBanDTO> LayTongDoanhThuTheoThang(DateTime ThangTu, DateTime ThangDen)
        {
            HDBanDAO dao = new HDBanDAO();
            return dao.LayTongDoanhThuTheoThang(ThangTu,ThangDen);
        }
    
        public HDBanDTO DemMaHDBan()
        {
            HDBanDAO dao = new HDBanDAO();
            return dao.DemMaHDBan();
        }



        public HDBanDTO DemSoHDHuy()
        {
            HDBanDAO dao = new HDBanDAO();
            return dao.DemSoHDHuy();
        }

        public HDBanDTO TongDoanhThuTrongNgay()
        {
            HDBanDAO dao = new HDBanDAO();
            return dao.TongDoanhThuTrongNgay();
        }
    }
}
