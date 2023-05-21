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
    public partial class FThamGiaDT : Form
    {
        public FThamGiaDT()
        {
            InitializeComponent();
        }

        private ThamGiaDeTai GetThamGiaDeTai()
        {
            string maDT = txt_maDeTaiTGDT.Text;
            string maSV = txt_maSinhVienTGDT.Text;
            int phuCap = int.Parse(txt_phuCapTGDT.Text);
            string ketQua = txt_ketQuaTGDT.Text;
            // Place holder for Database pulling
            SinhVien sinhViens = new SinhVien("2274801030137", "Trần Quang", "Thắng", "Nam", "003", new Khoa());
            //----------------------------------
            return new ThamGiaDeTai(maDT, maSV, phuCap, ketQua, sinhViens);
        }

        private void btn_themTGDT_Click(object sender, EventArgs e)
        {
            lsB_danhSach.Items.Add(GetThamGiaDeTai());
            txt_maDeTaiTGDT.Focus();
        }

        private void btn_suaTGDT_Click(object sender, EventArgs e)
        {
            int selectedIndex = lsB_danhSach.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn 1 mục tiêu để chỉnh sửa!");
                return;
            }
            lsB_danhSach.Items.RemoveAt(selectedIndex);
            lsB_danhSach.Items.Insert(selectedIndex, GetThamGiaDeTai());
            txt_maDeTaiTGDT.Focus();
        }

        private void btn_xoaTGDT_Click(object sender, EventArgs e)
        {
            ThamGiaDeTai selectedThamGiaDeTai = lsB_danhSach.SelectedItem as ThamGiaDeTai;
            lsB_danhSach.Items.Remove(selectedThamGiaDeTai);
            txt_maDeTaiTGDT.Focus();
        }

        private void lsB_danhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsB_danhSach.SelectedIndex == -1) return;
            ThamGiaDeTai selectedThamGiaDeTai = lsB_danhSach.SelectedItem as ThamGiaDeTai;
            txt_maDeTaiTGDT.Text = selectedThamGiaDeTai.MaDT;
            txt_maSinhVienTGDT.Text = selectedThamGiaDeTai.MaSV;
            txt_phuCapTGDT.Text = selectedThamGiaDeTai.PhuCap + "";
            txt_ketQuaTGDT.Text = selectedThamGiaDeTai.KetQua;
        }

        private void btn_troveTGDT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận!", "Bạn muốn quay về trang chủ?", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Hide();
                Forms.MainMenu.Show();
            }
        }

        private void IntegerInputHandler(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == (char)Keys.Back) return;
            e.Handled = true;
        }

        private void FThamGiaDT_FormClosing(object sender, FormClosingEventArgs e)
        {
            Database.Disconnect();
            Application.Exit();
        }
    }
}
