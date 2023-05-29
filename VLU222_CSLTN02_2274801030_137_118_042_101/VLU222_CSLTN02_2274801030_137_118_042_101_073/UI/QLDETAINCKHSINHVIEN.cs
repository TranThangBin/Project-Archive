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
        //private const string connectionString = "Data Source=DESKTOP-VOPAJLN;Initial Catalog=QLNCKH_SV;Integrated Security=True";
        // connectionString của Châu Gia Hào
        //private const string connectionString = "Data Source=PeachSwe3t\\HAOCHAU;Initial Catalog=QLNCKH_SV;Integrated Security=True";
        // connectionString của Bảo Nguyên
        private const string connectionString = "Data Source=LAPTOP-N17PMH73\\SQLEXPRESS02;Initial Catalog=QLNCKH_SV;Integrated Security=True";

        public QLDETAINCKHSINHVIEN()
        {
            InitializeComponent();
            Forms.MainMenu = this;
        }

        private void QLDETAINCKHSINHVIEN_Load(object sender, EventArgs e)
        {
            //WHAT IS THIS?
            //CHECKOUT DATABASE CLASS
            Database.Connect(connectionString);
        }

        private void QLDETAINCKHSINHVIEN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát Form?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                Database.Disconnect();
            else e.Cancel = true;
        }

        private void btn_TGDT_Click(object sender, EventArgs e)
        {
            Hide();
            Forms.ThamGiaDT = new FThamGiaDT();
            Forms.ThamGiaDT.Show();
        }

        private void btn_DSDT_Click(object sender, EventArgs e)
        {
            Hide();
            Forms.DeTai = new FDeTai();
            Forms.DeTai.Show();
        }

        private void btn_GVHD_Click(object sender, EventArgs e)
        {
            Hide();
            Forms.GiangVien = new FGiangVien();
            Forms.GiangVien.Show();
        }

        private void btn_SVCN_Click(object sender, EventArgs e)
        {
            Hide();
            Forms.SinhVien = new FSinhVien();
            Forms.SinhVien.Show();
        }

        private void btn_DSCK_Click(object sender, EventArgs e)
        {
            Hide();
            Forms.Khoa = new FKhoa();
            Forms.Khoa.Show();
        }

        private void btn_thanhVien_Click(object sender, EventArgs e)
        {
            Hide();
            Forms.ThanhVien = new FThanhVien();
            Forms.ThanhVien.Show();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
