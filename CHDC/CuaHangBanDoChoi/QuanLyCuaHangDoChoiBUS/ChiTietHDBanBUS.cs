using QuanLyCuaHangDoChoiDAO;
using QuanLyCuaHangDoChoiDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDoChoiBUS
{
    public class ChiTietHDBanBUS
    {
         public List<ChiTietHDBanDTO> LOADCTHDB(string ma)
        {
            ChiTietHDBanDAO dao = new ChiTietHDBanDAO();
            return dao.LOADCTHDB(ma);
        }
         public bool ThemCTHDB(ChiTietHDBanDTO DTO)
         {
             ChiTietHDBanDAO dao = new ChiTietHDBanDAO();
             return dao.ThemCTHDB(DTO);
         }
         public string LayMaCTHDBTiepTheo()
         {
             string strKQ;
             ChiTietHDBanDAO Dao = new ChiTietHDBanDAO();
             string MAHDB = Dao.MaCTHDBLonNhat();
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
        public List<SP_CTHDBDTO> LOADCTHDXUAT(string ma)
         {
             ChiTietHDBanDAO dao = new ChiTietHDBanDAO();
             return dao.LOADCTHDXUAT(ma);
         }
 
    }
}
