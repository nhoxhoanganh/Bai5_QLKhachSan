using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using KetNoiDB;

namespace BangKhachSan
{
    public class BUS_DoDung
    {
        public DataTable HienThiDoDung(string DieuKien)
        {
            string sql = "SELECT * FROM DoDung " + DieuKien;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            return dt;
        }
        public DataTable HienThiDoDung2()
        {
            string sql = "SELECT * FROM DoDung";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            return dt;
        }

        public void ThemDoDung(string TenDD, int SoLuong, string DonViTinh, float GiaMua)
        {
            string sql = "Them_DD";
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TenDD", TenDD);
            cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
            cmd.Parameters.AddWithValue("@DonViTinh", DonViTinh);
            cmd.Parameters.AddWithValue("@GiaMua", GiaMua);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void SuaDoDung(string MaDD, string TenDD, int SoLuong, string DonViTinh, float GiaMua)
        {
            string sql = "Sua_DD";
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TenDD", TenDD);
            cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
            cmd.Parameters.AddWithValue("@DonViTinh", DonViTinh);
            cmd.Parameters.AddWithValue("@GiaMua", GiaMua);
            cmd.Parameters.AddWithValue("@MaDD", MaDD);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void XoaDoDung(string MaDD)
        {
            string sql = "Xoa_DD";
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDD", MaDD);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        //public DataTable HienThiDoDung(string DieuKien)
        //{
        //    string sql = "SELECT * FROM DoDung " + DieuKien;
        //    DataTable dt = new DataTable();
        //    SqlConnection con = new SqlConnection(KetNoi.connect());
        //    SqlDataAdapter da = new SqlDataAdapter(sql, con);
        //    da.Fill(dt);
        //    return dt;
        //}
    }
}
