using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5_QLKhachSan
{
    public partial class frmQuanLyKhachSan : Form
    {
        public frmQuanLyKhachSan()
        {
            InitializeComponent();
        }

        private void quảnLýPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPHONG frm = new frmPHONG();
            frm.Show();
        }

        private void quảnLýĐồDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoDungTheoPhong frm = new frmDoDungTheoPhong();
            frm.Show();
        }

        private void quảnLýKháchThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachThue frm = new frmKhachThue();
            frm.Show();
        }
    }
}
