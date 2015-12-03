using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BangKhachSan;
using KetNoiDB;
namespace Bai5_QLKhachSan
{
    public partial class frmDoDungTheoPhong : Form
    {
        string ma;
        public frmDoDungTheoPhong()
        {
            InitializeComponent();
        }
        public frmDoDungTheoPhong(string _ma)
        {
            ma = _ma;
            InitializeComponent(); 
        }

        BUS_DoDung dodung = new BUS_DoDung();
        BUS_DoDungTrongPhong dd = new BUS_DoDungTrongPhong();
        int chon = 0;

        private void frmDoDungTheoPhong_Load(object sender, EventArgs e)
        {
            //if (ma != null) HienThi("where MaPhong = '" + ma + "'");
            //else HienThi("");

            dgvDodung.DataSource = dd.ShowDoDung_Ma(ma);
            dgvDD.DataSource = dodung.HienThiDoDung2();
            cbTinhTrang.SelectedIndex = 0;
            KhoaDieuKhien();

        }
        public void HienThi(string DieuKien) 
        {
            txtMaPhong.Text = ma;
            dgvDodung.DataSource = dodung.HienThiDoDung(DieuKien);
        }

        private void dgvDodung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhong.Text = ma;
            txtMaDoDung.Text = dgvDodung.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTen.Text = dgvDodung.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvDodung.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDonVi.Text = dgvDodung.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbTinhTrang.Text = dgvDodung.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        void KhoaDieuKhien()
        {
            txtTen.Enabled = txtSoLuong.Enabled = txtDonVi.Enabled = cbTinhTrang.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }

        void MoDieuKhien()
        {
            txtTen.Enabled = txtSoLuong.Enabled = txtDonVi.Enabled = cbTinhTrang.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }

        void SetNull()
        {
            txtTen.Text = txtSoLuong.Text = txtDonVi.Text = txtMaDoDung.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //MoDieuKhien();
            cbTinhTrang.Enabled = true;
            btnThemDD.Enabled = true;
            SetNull();
            chon = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            SetNull();
            chon = 2;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmDoDungTheoPhong_Load(sender, e);
            SetNull();
            btnThemDD.Enabled = false;
        }

        private void btnThemDD_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvDodung.Rows.Count; i++)
            {
                if (dgvDodung.Rows[i].Cells[0].Value == dgvDD.Rows[dgvDD.SelectedRows[0].Index].Cells[0].Value)
                {
                    MessageBox.Show("Sản phẩm đã được chọn !!!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (dgvDD.SelectedRows.Count > 0)
            {
                dgvDodung.Rows.AddRange();
                dgvDodung.Rows[dgvDodung.RowCount - 2].Cells[0].Value = dgvDD.Rows[dgvDD.SelectedRows[0].Index].Cells[0].Value;
                dgvDodung.Rows[dgvDodung.RowCount - 2].Cells[1].Value = dgvDD.Rows[dgvDD.SelectedRows[0].Index].Cells[1].Value;
                if (int.Parse(nbr1.Value.ToString()) <= int.Parse(dgvDD.Rows[dgvDD.SelectedRows[0].Index].Cells[2].Value.ToString()))
                    dgvDodung.Rows[dgvDodung.RowCount - 2].Cells[2].Value = nbr1.Value;
                else
                    MessageBox.Show("nhập lại số lượng!", "");
                dgvDodung.Rows[dgvDodung.RowCount - 2].Cells[3].Value = dgvDD.Rows[dgvDD.SelectedRows[0].Index].Cells[3].Value;
                dgvDodung.Rows[dgvDodung.RowCount - 2].Cells[5].Value = dgvDD.Rows[dgvDD.SelectedRows[0].Index].Cells[4].Value;
                dgvDodung.Rows[dgvDodung.RowCount - 2].Cells[4].Value = cbTinhTrang.Text;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //if(dgvDodung.)
        }
    }
}
