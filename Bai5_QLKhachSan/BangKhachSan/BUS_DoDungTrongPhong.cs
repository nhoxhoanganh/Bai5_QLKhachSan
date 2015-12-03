using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetNoiDB;
using System.Data;
using System.Data.SqlClient;

namespace BangKhachSan
{
    public class BUS_DoDungTrongPhong
    {
        public DataTable ShowDoDung_Ma(string MaPhong)
        {
            string sql = string.Format(@"SELECT     dbo.DoDung.MaDD, dbo.DoDung.TenDD, dbo.tblDoDungTrongPhong.SoLuong, dbo.tblDoDungTrongPhong.DonViTinh, dbo.tblDoDungTrongPhong.TinhTrang, dbo.DoDung.GiaMua
                                        FROM         dbo.tblDoDungTrongPhong INNER JOIN
                                                              dbo.DoDung ON dbo.tblDoDungTrongPhong.MaDoDung = dbo.DoDung.MaDD INNER JOIN
                                                              dbo.tblPhong ON dbo.tblDoDungTrongPhong.MaPhong = dbo.tblPhong.MaPhong
                                        WHERE     (dbo.tblPhong.MaPhong = @MaPhong)");
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Parameters.AddWithValue("@MaPhong", MaPhong);
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void UpdateDoDung_Phong(string MaDoDung, string MaPhong, int SoLuong, string DVTinh, string TinhTrang)
        {
            string str = string.Format(@"update tblDoDungTrongPhong
                                        set SoLuong = " + SoLuong + ", DonViTinh = N'" + DVTinh + "', TinhTrang = N'" + TinhTrang + "'where MaDoDung = '" + MaDoDung + "' and MaPhong = '" + MaPhong + "'");
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
        }
        public void ThemDoDung_Phong(string MaDD, string MaPhong, int SoLuong, string DVTinh, string TinhTrang)
        {
            string str = string.Format(@"Insert into tblDoDungTrongPhong (MaDoDung, SoLuong, DonViTinh, TinhTrang, MaPhong) values (@MaDD, @SoLuong, @DVTinh, @TinhTrang, @MaPhong)");
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@MaDD", MaDD);
            cmd.Parameters.Add("@MaPhong", MaPhong);
            cmd.Parameters.Add("@SoLuong", SoLuong);
            cmd.Parameters.Add("@DVTinh", DVTinh);
            cmd.Parameters.Add("@TinhTrang", TinhTrang);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
         
        }
    }
}
