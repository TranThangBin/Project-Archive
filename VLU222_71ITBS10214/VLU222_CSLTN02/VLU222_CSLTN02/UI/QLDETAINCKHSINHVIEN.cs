﻿using System;
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
        //private const string connectionString = "Data Source=LAPTOP-N17PMH73\\SQLEXPRESS02;Initial Catalog=QLNCKH_SV;Integrated Security=True";
        //connectionString của Hoàng Phúc
        //private const string connectionString = "Data Source=DESKTOP-BF0SUD8;Initial Catalog=QLNCKH_SV;Integrated Security=True";
        private bool connectionFailed = true;
        public QLDETAINCKHSINHVIEN()
        {
            InitializeComponent();
        }

        private void QLDETAINCKHSINHVIEN_Load(object sender, EventArgs e)
        {
            try
            {
                Database.Connect();
                connectionFailed = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                Database.Disconnect();
                Forms.TruyCapCSDL.Show();
                Close();
            }
        }

        private void QLDETAINCKHSINHVIEN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connectionFailed || MessageBox.Show("Bạn muốn thoát khỏi cơ sở dữ liệu?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Forms.TruyCapCSDL.Show();
                Database.Disconnect();
            }
            else e.Cancel = true;
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
