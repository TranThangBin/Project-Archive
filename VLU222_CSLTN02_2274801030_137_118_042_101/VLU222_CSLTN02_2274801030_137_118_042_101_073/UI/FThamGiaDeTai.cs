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
                cmB_maDeTaiTGDT,
                cmB_maSinhVienTGDT,
                txt_phuCapTGDT,
                txt_ketQuaTGDT
            };
        }

        private void FThamGiaDT_Load(object sender, EventArgs e)
        {
            //render Database data in this event
            Database.RenderThamGiaDeTai(lsB_danhSach, cmB_maDeTaiTGDT, cmB_maSinhVienTGDT);
        }

        private void FThamGiaDT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn quay về trang chủ?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                Forms.MainMenu.Show();
            else
                e.Cancel = true;
        }

        private void cmB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmB_Enter(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            cmb.DroppedDown = true;
        }

        private void btn_themTGDT_Click(object sender, EventArgs e)
        {
            try
            {
                //Insert data into TGDT table
                ThamGiaDeTai thamGiaDeTai = Forms.GetThamGiaDeTai(inpTGDTs);
                int rowAffected = Database.InsertThamGiaDeTai(thamGiaDeTai);
                if (rowAffected != 0)
                {
                    MessageBox.Show("Tham gia đề tài thành công!");
                    lsB_danhSach.Items.Add(thamGiaDeTai);
                    lsB_danhSach.Sorted = true;
                    Forms.CleanInput(inpTGDTs);
                }
                else MessageBox.Show("Tham gia đề tài thất bại!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Vui lòng kiểm tra lại dữ liệu gửi của " +
                                    "bạn vì có sự trùng lặp xảy ra!");
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
                int rowAffected = Database.UpdateThamGiaDeTai(
                    lsB_danhSach.SelectedItem as ThamGiaDeTai, thamGiaDeTai
                );
                if (rowAffected != 0)
                {
                    MessageBox.Show("Sửa tham gia đề tài thành công!");
                    Forms.LsbUpdateItem(lsB_danhSach, lsB_danhSach.SelectedIndex, thamGiaDeTai);
                    Forms.CleanInput(inpTGDTs);
                }
                else MessageBox.Show("Sửa tham gia đề tài thất bại!");
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
            int rowAffected = Database.DeleteThamGiaDeTai(selectedThamGiaDeTai);
            if (rowAffected != 0)
            {
                MessageBox.Show("Xóa tham gia đề tài thành công!");
                lsB_danhSach.Items.Remove(selectedThamGiaDeTai);
                Forms.CleanInput(inpTGDTs);
            }
            else MessageBox.Show("Xóa tham gia đề tài thất bại!");

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
                cmB_maDeTaiTGDT.Enabled = true;
                cmB_maSinhVienTGDT.Enabled = true;
                btn_themTGDT.Enabled = true;
                return;
            }
            ThamGiaDeTai selectedThamGiaDeTai = lsB_danhSach.SelectedItem as ThamGiaDeTai;
            cmB_maDeTaiTGDT.Text = selectedThamGiaDeTai.MaDT;
            cmB_maSinhVienTGDT.Text = selectedThamGiaDeTai.MaSV;
            txt_phuCapTGDT.Text = selectedThamGiaDeTai.PhuCap + "";
            txt_ketQuaTGDT.Text = selectedThamGiaDeTai.KetQua;
            cmB_maDeTaiTGDT.Enabled = false;
            cmB_maSinhVienTGDT.Enabled = false;
            btn_themTGDT.Enabled = false;
        }

        private void lsB_danhSach_MouseDown(object sender, MouseEventArgs e)
        {
            Forms.LsbRightClickDeselected(sender as ListBox, e);
        }

        private void txt_phuCapTGDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumOnlyHandler(sender as TextBox, e);
        }

        private void txt_ketQuaTGDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringOnlyHandler(sender as TextBox, e);
        }
    }
}
