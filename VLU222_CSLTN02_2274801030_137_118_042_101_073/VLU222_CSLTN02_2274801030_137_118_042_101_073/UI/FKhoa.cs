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
        private bool toMenu = true;
        private bool toGiangVien = false;
        private bool toSinhVien = false;
        public FKhoa()
        {
            InitializeComponent();
        }

        private void FKhoa_Load(object sender, EventArgs e)
        {
            //render Database data in this event
        }

        private void FKhoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (toMenu && MessageBox.Show("Xác nhận!", "Bạn muốn quay về trang chủ?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                Forms.MainMenu.Show();
            else if (toGiangVien && MessageBox.Show("Xác nhận!", "Bạn muốn truy cập Form giảng viên?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Forms.GiangVien = new FGiangVien();
                Forms.GiangVien.Show();
            }
            else if (toSinhVien && MessageBox.Show("Xác nhận!", "Bạn muốn truy cập Form sinh viên?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Forms.SinhVien = new FSinhVien();
                Forms.SinhVien.Show();
            }
            else
            {
                e.Cancel = true;
                toMenu = true;
                toGiangVien = false;
                toSinhVien = false;
            }
        }

        private void btn_troVeKhoa_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_truyCapGV_Click(object sender, EventArgs e)
        {
            toMenu = false;
            toGiangVien = true;
            Close();
        }

        private void btn_truyCapSV_Click(object sender, EventArgs e)
        {
            toMenu = false;
            toSinhVien = true;
            Close();
        }
    }
}
