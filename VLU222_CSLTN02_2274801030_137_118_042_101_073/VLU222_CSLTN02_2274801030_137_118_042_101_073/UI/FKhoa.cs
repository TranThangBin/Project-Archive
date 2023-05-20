using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.UI
{
    public partial class FKhoa : Form
    {
        public FKhoa()
        {
            InitializeComponent();
        }

        private void btn_troVeKhoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận!", "Bạn muốn truy cập Form khoa?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Hide();
                Forms.Khoa.Show();
            }
        }

        private void btn_truyCapGV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận!", "Bạn muốn truy cập Form giảng viên?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Hide();
                Forms.GiangVien.Show();
            }
        }

        private void btn_truyCapSV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận!", "Bạn muốn truy cập Form sinh viên?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Hide();
                Forms.SinhVien.Show();
            }
        }

        private void FKhoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Database.Disconnect();
            Application.Exit();
        }
    }
}
