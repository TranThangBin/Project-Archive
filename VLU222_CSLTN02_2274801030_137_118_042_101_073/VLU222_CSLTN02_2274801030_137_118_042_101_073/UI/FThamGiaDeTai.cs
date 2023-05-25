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
        private List<TextBox> txtTGDTs;
        public FThamGiaDT()
        {
            InitializeComponent();
            txtTGDTs = new List<TextBox>()
            {
                txt_maDeTaiTGDT,
                txt_maSinhVienTGDT,
                txt_phuCapTGDT,
                txt_ketQuaTGDT
            };
        }

        private void FThamGiaDT_Load(object sender, EventArgs e)
        {
            //render Database data in this event
        }

        private void FThamGiaDT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn quay về trang chủ?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                Forms.MainMenu.Show();
            else
                e.Cancel = true;
        }

        private ThamGiaDeTai GetThamGiaDeTai()
        {
            if (txt_maDeTaiTGDT.Text == "")
                throw new Exception("Vui lòng không để trống mã đề tài!");
            if (txt_maSinhVienTGDT.Text == "")
                throw new Exception("Vui lòng không để trống mã sinh viên!");
            if (txt_phuCapTGDT.Text == "")
                throw new Exception("Vui lòng không để trống tiền phụ cấp!");
            if (txt_ketQuaTGDT.Text == "")
                throw new Exception("Vui lòng không để trống kết quả!");
            string maDT = txt_maDeTaiTGDT.Text;
            string maSV = txt_maSinhVienTGDT.Text;
            long phuCap = long.Parse(txt_phuCapTGDT.Text);
            string ketQua = txt_ketQuaTGDT.Text;
            return new ThamGiaDeTai(maDT, maSV, phuCap, ketQua);
        }


        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumberInputHandler(false, false, sender as TextBox, e);
        }

        private void txtSpacesHandled_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtPrematureSpacesHandler(sender as TextBox, e);
        }

        private void btn_themTGDT_Click(object sender, EventArgs e)
        {
            try
            {
                ThamGiaDeTai thamGiaDeTai = GetThamGiaDeTai();
                lsB_danhSach.Items.Add(thamGiaDeTai);
                Forms.TxtClearInput(txtTGDTs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaTGDT_Click(object sender, EventArgs e)
        {
            int danhSachSelectedIndex = lsB_danhSach.SelectedIndex;
            if (!Forms.LsbHasItemSelected(danhSachSelectedIndex, "Vui lòng chọn 1 mục tiêu để chỉnh sửa!")) return;
            try
            {
                ThamGiaDeTai thamGiaDeTai = GetThamGiaDeTai();
                Forms.LsbUpdateItem(lsB_danhSach, danhSachSelectedIndex, thamGiaDeTai);
                Forms.TxtClearInput(txtTGDTs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaTGDT_Click(object sender, EventArgs e)
        {
            ThamGiaDeTai selectedThamGiaDeTai = lsB_danhSach.SelectedItem as ThamGiaDeTai;
            lsB_danhSach.Items.Remove(selectedThamGiaDeTai);
            Forms.TxtClearInput(txtTGDTs);
        }

        private void btn_troveTGDT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lsB_danhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsB_danhSach.SelectedIndex == -1)
            {
                Forms.TxtClearInput(txtTGDTs);
                return;
            }
            ThamGiaDeTai selectedThamGiaDeTai = lsB_danhSach.SelectedItem as ThamGiaDeTai;
            txt_maDeTaiTGDT.Text = selectedThamGiaDeTai.MaDT;
            txt_maSinhVienTGDT.Text = selectedThamGiaDeTai.MaSV;
            txt_phuCapTGDT.Text = selectedThamGiaDeTai.PhuCap + "";
            txt_ketQuaTGDT.Text = selectedThamGiaDeTai.KetQua;
        }

        private void lsB_danhSach_MouseDown(object sender, MouseEventArgs e)
        {
            Forms.LsbRightClickDeselected(sender as ListBox, e);
        }
    }
}
