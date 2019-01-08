using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyCuaHangDoChoiDAO
{
    public class DataProvider
    {

        static string strKetNoi = @"Data Source=DESKTOP-F9M940K\SQLEXPRESS;Initial Catalog=CuaHangDoChoi;Integrated Security=True";

        
        public static SqlConnection TaoKetNoi()
        {
            SqlConnection con = new SqlConnection(strKetNoi);
            con.Open();
            return con;
        }
        public static SqlDataReader TruyVanDuLieu(string strTruyVan, SqlConnection con)
        {
            SqlCommand comm = new SqlCommand(strTruyVan, con);
            return comm.ExecuteReader();
        }

        public static SqlDataReader TruyVanDuLieu(string strTruyVan, SqlParameter[] param, SqlConnection con)
        {
            SqlCommand com = new SqlCommand(strTruyVan, con);
            com.Parameters.AddRange(param);
            return com.ExecuteReader(); 
        }
        public static int ThucThiCauLenh(string strCauLenh, SqlConnection conn)
        {
            SqlCommand com = new SqlCommand(strCauLenh, conn);
            int ketqua = com.ExecuteNonQuery();
            return ketqua;
        }
        public static int ThucThiCauLenh(string strCauLenh, SqlParameter[] parma, SqlConnection conn)
        {
            SqlCommand com = new SqlCommand(strCauLenh, conn);
            com.Parameters.AddRange(parma);
            int ketqua = com.ExecuteNonQuery();
            return ketqua;
        }

        }
}








