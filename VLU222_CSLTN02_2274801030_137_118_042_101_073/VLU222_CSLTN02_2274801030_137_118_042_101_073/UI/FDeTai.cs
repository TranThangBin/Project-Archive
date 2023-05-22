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
    public partial class FDeTai : Form
    {
        private bool toMenu = true;
        private bool toTGDT = false;
        public FDeTai()
        {
            InitializeComponent();
        }

        private void FDeTai_Load(object sender, EventArgs e)
        {
            //render Database data in this event
        }

        private void FDeTai_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (toMenu && MessageBox.Show("Xác nhận!", "Bạn muốn quay về trang chủ?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                Forms.MainMenu.Show();
            else if (toTGDT && MessageBox.Show("Xác nhận!", "Bạn muốn tham gia đề tài?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Forms.ThamGiaDT = new FThamGiaDT();
                Forms.ThamGiaDT.Show();
            }
            else
            {
                e.Cancel = true;
                toMenu = true;
                toTGDT = false;
            }
        }

        private DeTai GetDeTai()
        {
            string maDT = txt_maDetai.Text;
            string tenDT = txt_tenDetai.Text;
            decimal kinhPhi = decimal.Parse(txt_kinhPhi.Text);
            DateTime ngayBD = dtP_ngayBatDau.Value;
            DateTime ngayKT = dtP_ngayKetThuc.Value;
            string maGVHD = txt_maGiangVien.Text;
            string maSVCNDT = txt_maSinhVien.Text;
            // Place holder for Database pulling
            SinhVien sinhViens = new SinhVien("2274801030123", "Nguyễn Văn", "A", "Nam", "003", new Khoa());
            GiangVien giangViens = new GiangVien("2274801030138", "Trần Văn", "B", "Nam", "12/12", "003", new Khoa());
            //----------------------------------
            return new DeTai(maDT, tenDT, kinhPhi, ngayBD, ngayKT, maGVHD, maSVCNDT, sinhViens, giangViens);
        }

        private void btn_themDeTai_Click(object sender, EventArgs e)
        {
            lsB_danhSachDeTai.Items.Add(GetDeTai());
            txt_maDetai.Focus();
        }

        private void btn_suaDeTai_Click(object sender, EventArgs e)
        {
            int selectedIndex = lsB_danhSachDeTai.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn 1 mục tiêu để chỉnh sửa!");
                return;
            }
            lsB_danhSachDeTai.Items.RemoveAt(selectedIndex);
            lsB_danhSachDeTai.Items.Insert(selectedIndex, GetDeTai());
            txt_maDetai.Focus();
            //done this
        }

        private void btn_xoaDeTai_Click(object sender, EventArgs e)
        {
            DeTai selectedThamGiaDeTai = lsB_danhSachDeTai.SelectedItem as DeTai;
            lsB_danhSachDeTai.Items.Remove(selectedThamGiaDeTai);
            txt_maDeTaiTGDT.Focus();
        }

        private void btn_troVeDeTai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_truyCapTGDT_Click(object sender, EventArgs e)
        {
            toMenu = false;
            toTGDT = true;
            Close();
        }
    }
}
