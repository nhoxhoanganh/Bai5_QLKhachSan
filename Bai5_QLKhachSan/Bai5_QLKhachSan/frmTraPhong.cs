using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BangKhachSan;

namespace Bai5_QLKhachSan
{
    public partial class frmTraPhong : Form
    {
        public frmTraPhong()
        {
            InitializeComponent();
        }

        CTHD cthd = new CTHD();
        HoaDon hd = new HoaDon();
        BUS_Phong phong = new BUS_Phong();
        private void frmTraPhong_Load(object sender, EventArgs e)
        {
            cboMaHD.DataSource = hd.HienDH();
            cboMaHD.DisplayMember = "MaHD";
            cboMaHD.ValueMember = "MaHD";
            cboMaHD.SelectedValue = "MaHD";
            cboTenPhong.DataSource = phong.HienThiPhong();
            cboTenPhong.DisplayMember = "TenPhong";
            cboTenPhong.ValueMember = "MaPhong";
            cboTenPhong.SelectedValue = "MaPhong";
            
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (cboMaHD.Text != "" && cboTenPhong.Text != "")
            {
                string dieukien = " and MaHD='" + cboMaHD.Text + "' and MaPhong='" + cboTenPhong.SelectedValue.ToString() + "'";
                dataGridView1.DataSource = cthd.HienCTDH(dieukien);
            }
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
