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
    public partial class FGiangVien : Form
    {
        public FGiangVien()
        {
            InitializeComponent();
        }

        private void btn_troVeGV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận!", "Bạn muốn quay về trang chủ?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Hide();
                Forms.MainMenu.Show();
            }
        }

        private void btn_truyCapDT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận!", "Bạn muốn truy cập Form đề tài?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Hide();
                Forms.DeTai.Show();
            }
        }

        private void FGiangVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            Database.Disconnect();
            Application.Exit();
        }
    }
}
