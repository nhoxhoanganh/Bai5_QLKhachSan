﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using KetNoiDB;

namespace BangKhachSan
{
    public class BUS_ThuePhong
    {
        public DataTable ThemHoaDon(string MaKH, string NguoiLap, DateTime TGMuon)
        {
            DataTable dt = new DataTable();
            string str = string.Format("ThemHD");
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@MaKH", MaKH);
            cmd.Parameters.AddWithValue("@NguoiLap", NguoiLap);
            cmd.Parameters.AddWithValue("@TGMuon", TGMuon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
        public DataTable ThemCTHoaDon(string MaHD, string MaPhong, string MaDV)
        {
            DataTable dt = new DataTable();
            string str = string.Format("ThemCTHD");
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@MaHD", MaHD);
            cmd.Parameters.AddWithValue("@MaPhong", MaPhong);
            cmd.Parameters.AddWithValue("@MaDV", MaDV);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void UpdateTrangThaiPhong_Thue(string MaPhong)
        {
            string str = string.Format(@"Update tblPhong set TrangThai = Using where MaPhong = '" + MaPhong + "'");
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void ThemDV(string MaHD, string MaPhong, string MaDV)
        {
            try
            {
                string str = string.Format(@"Insert into tblCTHD '" + MaHD + "'" + "','" + MaPhong + "', '" + MaDV + "'");
                SqlConnection con = new SqlConnection(KetNoi.connect());
                con.Open();
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch { }
        }
    }
}
