using System;
using System.Collections;
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

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.UI
{
    public partial class FThamGiaDT : Form
    {
        private ArrayList inpTGDTs;
        public FThamGiaDT()
        {
            InitializeComponent();
            inpTGDTs = new ArrayList()
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
            Database.RenderThamGiaDeTai(lsB_danhSach);
        }

        private void FThamGiaDT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn quay về trang chủ?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                Forms.MainMenu.Show();
            else
                e.Cancel = true;
        }

        private void txtNumId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumIdHandler(sender as TextBox, e);
        }

        private void btn_themTGDT_Click(object sender, EventArgs e)
        {
            try
            {
                //Insert data into TGDT table
                ThamGiaDeTai thamGiaDeTai = Forms.GetThamGiaDeTai(inpTGDTs);
                lsB_danhSach.Items.Add(thamGiaDeTai);
                Forms.CleanInput(inpTGDTs);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Mã đề tài hoặc mã sinh viên " +
                                    "bạn vừa nhập bị trùng với 1 trong " +
                                    "các dữ liệu trước đó!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaTGDT_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(lsB_danhSach, "Vui lòng chọn 1 mục tiêu để chỉnh sửa!")) return;
            try
            {
                //Update data for TGDT table
                ThamGiaDeTai thamGiaDeTai = Forms.GetThamGiaDeTai(inpTGDTs);
                Forms.LsbUpdateItem(lsB_danhSach, lsB_danhSach.SelectedIndex, thamGiaDeTai);
                Forms.CleanInput(inpTGDTs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaTGDT_Click(object sender, EventArgs e)
        {
            //Delete data from TGDT table
            ThamGiaDeTai selectedThamGiaDeTai = lsB_danhSach.SelectedItem as ThamGiaDeTai;
            lsB_danhSach.Items.Remove(selectedThamGiaDeTai);
            Forms.CleanInput(inpTGDTs);
        }

        private void btn_troveTGDT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lsB_danhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsB_danhSach.SelectedIndex == -1)
            {
                Forms.CleanInput(inpTGDTs);
                txt_maDeTaiTGDT.Enabled = true;
                txt_maSinhVienTGDT.Enabled = true;
                btn_themTGDT.Enabled = true;
                return;
            }
            ThamGiaDeTai selectedThamGiaDeTai = lsB_danhSach.SelectedItem as ThamGiaDeTai;
            txt_maDeTaiTGDT.Text = selectedThamGiaDeTai.MaDT;
            txt_maSinhVienTGDT.Text = selectedThamGiaDeTai.MaSV;
            txt_phuCapTGDT.Text = selectedThamGiaDeTai.PhuCap + "";
            txt_ketQuaTGDT.Text = selectedThamGiaDeTai.KetQua;
            txt_maDeTaiTGDT.Enabled = false;
            txt_maSinhVienTGDT.Enabled = false;
            btn_themTGDT.Enabled = false;
        }

        private void lsB_danhSach_MouseDown(object sender, MouseEventArgs e)
        {
            Forms.LsbRightClickDeselected(sender as ListBox, e);
        }

        private void txt_maDeTaiTGDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringNumIdHandler(e);
        }

        private void txt_ketQuaTGDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringOnlyHandler(sender as TextBox, e);
        }
    }
}
