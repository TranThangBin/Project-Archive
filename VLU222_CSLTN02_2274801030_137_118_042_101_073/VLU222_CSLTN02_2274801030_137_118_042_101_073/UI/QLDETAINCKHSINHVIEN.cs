using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes;
using VLU222_CSLTN02_2274801030_137_118_042_101_073.UI;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073
{
    public partial class QLDETAINCKHSINHVIEN : Form
    {
        // connectionString của Trần Quang Thắng
        private const string connectionString = "Data Source=DESKTOP-VOPAJLN;Initial Catalog=QLNCKH_SV;Integrated Security=True";
        // connectionString của Châu Gia Hào
        //private const string connectionString = "Data Source=PeachSwe3t\\HAOCHAU;Initial Catalog=QLNCKH_SV;Integrated Security=True";
        // connectionString của ....
        //private const string connectionString = "Your connectionString";

        public QLDETAINCKHSINHVIEN()
        {
            InitializeComponent();
            Forms.MainMenu = this;
            Forms.ThamGiaDT = new FThamGiaDT();
            Forms.DeTai = new FDeTai();
            Forms.GiangVien = new FGiangVien();
            Forms.SinhVien = new FSinhVien();
            Forms.Khoa = new FKhoa();
        }

        private void QLDETAINCKHSINHVIEN_Load(object sender, EventArgs e)
        {
            Database.Connect(connectionString);
        }

        private void QLDETAINCKHSINHVIEN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Database.Disconnect();
            Application.Exit();
        }

        private void btn_TGDT_Click(object sender, EventArgs e)
        {
            Hide();
            Forms.ThamGiaDT.Show();
        }

        private void btn_DSDT_Click(object sender, EventArgs e)
        {
            Hide();
            Forms.DeTai.Show();
        }

        private void btn_GVHD_Click(object sender, EventArgs e)
        {
            Hide();
            Forms.GiangVien.Show();
        }

        private void btn_SVCN_Click(object sender, EventArgs e)
        {
            Hide();
            Forms.SinhVien.Show();
        }

        private void btn_DSCK_Click(object sender, EventArgs e)
        {
            Hide();
            Forms.Khoa.Show();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận!", "Bạn muốn thoát Form?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                Close();
        }
    }
}
