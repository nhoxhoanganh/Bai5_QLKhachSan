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
    public partial class frmDoDung : Form
    {
        public frmDoDung()
        {
            InitializeComponent();
        }

        BUS_DoDung dd = new BUS_DoDung();
        TimKiem tk = new TimKiem();
        int chon = 0;

        void KhoaDieuKhien()
        {
            txtTen.Enabled = txtSL.Enabled = txtGia.Enabled = txtDVT.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }

        void MoDieuKhien()
        {
            txtTen.Enabled = txtSL.Enabled = txtGia.Enabled = txtDVT.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }

        void SetNull()
        {
            txtMa.Text = txtTen.Text = txtSL.Text = txtGia.Text = txtDVT.Text = "";
            txtTKMa.Text = txtTKTen.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            SetNull();
            chon = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            SetNull();
            chon = 2;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa Đồ dùng này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                dd.XoaDoDung(txtMa.Text);
                MessageBox.Show("Xóa thành công!");
                frmDoDung_Load(sender, e);
                SetNull();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chon == 1)
            {
                if (txtTen.Text == "" || txtSL.Text == "" || txtGia.Text == "" || txtDVT.Text == "")
                    MessageBox.Show("Mời nhập đầy đủ thông tin!");
                else
                    if (DialogResult.Yes == MessageBox.Show("Bạn có muốn Thêm Đồ dùng này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        dd.ThemDoDung(txtTen.Text, int.Parse(txtSL.Text), txtDVT.Text, float.Parse(txtGia.Text));
                        MessageBox.Show("Thêm thành công!");
                        SetNull();
                        frmDoDung_Load(sender, e);
                    }
            }
            else if (chon == 2)
            {
                if (txtTen.Text == "" || txtSL.Text == "" || txtGia.Text == "" || txtDVT.Text == "")
                    MessageBox.Show("Mời nhập đầy đủ thông tin!");
                else
                    if (DialogResult.Yes == MessageBox.Show("Bạn có muốn Sửa Đồ dùng này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        dd.SuaDoDung(txtMa.Text, txtTen.Text, int.Parse(txtSL.Text), txtDVT.Text, float.Parse(txtGia.Text));
                        MessageBox.Show("Sửa thành công!");
                        SetNull();
                        frmDoDung_Load(sender, e);
                    }
            }
        }

        private void frmDoDung_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = dd.HienThiDoDung2();
            dgvDD.DataSource = dt;
            KhoaDieuKhien();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            chon = 0;
            SetNull();
            frmDoDung_Load(sender, e);
        }

        private void txtTKMa_TextChanged(object sender, EventArgs e)
        {
            dgvDD.DataSource = tk.TKDD_Ma(txtTKMa.Text);
        }

        private void txtTKTen_TextChanged(object sender, EventArgs e)
        {
            dgvDD.DataSource = tk.TKDD_Ten(txtTKTen.Text);
        }

        private void dgvDD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMa.Text = dgvDD.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTen.Text = dgvDD.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSL.Text = dgvDD.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDVT.Text = dgvDD.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtGia.Text = dgvDD.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch { }
        }

    }
}
