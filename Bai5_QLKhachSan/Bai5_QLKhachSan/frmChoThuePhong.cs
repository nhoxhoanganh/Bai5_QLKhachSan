using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using KetNoiDB;
using BangKhachSan;
namespace Bai5_QLKhachSan
{
    public partial class frmChoThuePhong : Form
    {
        string MaHD = "";
        BUS_KhachThuePhong kh = new BUS_KhachThuePhong();
        BUS_ThuePhong ThuePhong = new BUS_ThuePhong();
        public frmChoThuePhong()
        {
            InitializeComponent();
        }

        public void HienThiListKhach()
        {
            dgvKhachThuePhong.DataSource = kh.HienThiKhach_2TC();
        }
        private void btnThemKhachMoi_Click(object sender, EventArgs e)
        {
            frmKhachThue frm = new frmKhachThue();
            frm.Show();
            HienThiListKhach();
        }

        private void frmChoThuePhong_Load(object sender, EventArgs e)
        {
            HienThiListKhach();
        }

        private void dgvKhachThuePhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaKH.Text = dgvKhachThuePhong.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch
            {

            }
        }

        private void dgvPhongTrong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaPhong.Text = dgvPhongTrong.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch
            {

            }
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaDV.Text = dgvDichVu.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnChonPhong_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ThuePhong.ThemHoaDon(txtMaKH.Text, "Admin", DateTime.Now);
                if (dt.Rows.Count < 1)
                    MessageBox.Show("Thêm Hóa Đơn Thất Bại.");
                MaHD = dt.Rows[0]["MaHD"].ToString();
                DataTable dt2 = new DataTable();
                dt2 = ThuePhong.ThemCTHoaDon(MaHD, txtMaPhong.Text, "DV00000001");
                if (dt2.Rows.Count < 1)
                    MessageBox.Show("Thêm Chi Tiết Hóa Đơn Thất Bại.");
                ThuePhong.UpdateTrangThaiPhong_Thue(txtMaPhong.Text);
            }
            catch { }
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            ThuePhong.ThemDV(MaHD, txtMaPhong.Text, txtMaDV.Text);
        }
    }
}
