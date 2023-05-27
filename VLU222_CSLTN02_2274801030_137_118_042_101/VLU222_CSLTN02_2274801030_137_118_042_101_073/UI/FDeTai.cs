using System;
using System.Collections;
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
        private ArrayList inpDeTais;
        private ArrayList inpTGDTs;
        public FDeTai()
        {
            InitializeComponent();
            inpDeTais = new ArrayList()
            {
                txt_maDetai,
                txt_tenDetai,
                txt_kinhPhi,
                dtP_ngayBatDau,
                dtP_ngayKetThuc,
                txt_maGiangVien,
                txt_maSinhVien
            };
            inpTGDTs = new ArrayList()
            {
                txt_phuCapTGDT,
                txt_ketQuaTGDT
            };
        }

        private void FDeTai_Load(object sender, EventArgs e)
        {
            //render Database data in this event
        }

        private void FDeTai_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (toMenu && MessageBox.Show("Bạn muốn quay về trang chủ?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                Forms.MainMenu.Show();
            else if (toTGDT && MessageBox.Show("Bạn muốn tham gia đề tài?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
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

        private DeTai GetSelectedDeTai()
        {
            return lsB_danhSachDeTai.SelectedItem as DeTai;
        }

        private int GetDeTaiSelectedIndex()
        {
            return lsB_danhSachDeTai.SelectedIndex;
        }

        private void txtNumId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumIdHandler(sender as TextBox, e);
        }

        private void txtStringOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringOnlyHandler(sender as TextBox, e);
        }

        private void btn_themDeTai_Click(object sender, EventArgs e)
        {
            try
            {
                //Insert data into DETAI table
                DeTai deTai = Forms.GetDeTai(inpDeTais);
                lsB_danhSachDeTai.Items.Add(deTai);
                Forms.CleanInput(inpDeTais);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaDeTai_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(lsB_danhSachDeTai, "Vui lòng chọn 1 đề tài để chỉnh sửa!")) return;
            DeTai selectedDeTai = GetSelectedDeTai();
            try
            {
                //Update data for DETAI table
                DeTai newDeTai = Forms.GetDeTai(inpDeTais);
                newDeTai.ThamGiaDeTais = selectedDeTai.ThamGiaDeTais;
                Forms.LsbUpdateItem(lsB_danhSachDeTai, GetDeTaiSelectedIndex(), newDeTai);
                Forms.CleanInput(inpDeTais);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaDeTai_Click(object sender, EventArgs e)
        {
            //Delete data for DeTai table
            DeTai deTai = GetSelectedDeTai();
            lsB_danhSachDeTai.Items.Remove(deTai);
            Forms.CleanInput(inpDeTais);
        }

        private void btn_troVeDeTai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lsB_danhSachDeTai_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsv_danhSachTGDT.Items.Clear();
            if (GetDeTaiSelectedIndex() == -1)
            {
                Forms.CleanInput(inpDeTais);
                Forms.CleanInput(inpTGDTs);
                txt_maDetai.Enabled = true;
                txt_maSinhVien.Enabled = true;
                btn_themDeTai.Enabled = true;
                return;
            }
            DeTai selectedDeTai = GetSelectedDeTai();
            txt_maDetai.Text = selectedDeTai.MaDT;
            txt_tenDetai.Text = selectedDeTai.TenDT;
            txt_kinhPhi.Text = selectedDeTai.KinhPhi + "";
            dtP_ngayBatDau.Value = selectedDeTai.NgayBD;
            dtP_ngayKetThuc.Value = selectedDeTai.NgayKT;
            txt_maGiangVien.Text = selectedDeTai.MaGVHD;
            txt_maSinhVien.Text = selectedDeTai.MaSVCNDT;
            foreach (ThamGiaDeTai thamGiaDeTai in selectedDeTai.ThamGiaDeTais)
            {
                string[] lsviObj = new string[]
                {
                    thamGiaDeTai.MaDT,
                    thamGiaDeTai.MaSV,
                    thamGiaDeTai.PhuCap + "",
                    thamGiaDeTai.KetQua
                };
                ListViewItem lsvItem = new ListViewItem(lsviObj);
                lsv_danhSachTGDT.Items.Add(lsvItem);
            }
            txt_maDetai.Enabled = false;
            txt_maSinhVien.Enabled = false;
            btn_themDeTai.Enabled = false;
        }

        private void lsB_danhSachDeTai_MouseDown(object sender, MouseEventArgs e)
        {
            Forms.LsbRightClickDeselected(sender as ListBox, e);
        }

        private void txt_maDetai_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringNumIdHandler(e);
        }

        private void btn_themTGDT_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(lsB_danhSachDeTai, "Bạn cần phải chọn 1 đề tài để tham gia!")) return;
            DeTai selectedDeTai = GetSelectedDeTai();
            try
            {
                //Insert data into TGDT table
                ThamGiaDeTai thamGiaDeTai = Forms.GetThamGiaDeTai(inpTGDTs, selectedDeTai);
                string[] lsviObj = new string[]
                {
                    thamGiaDeTai.MaDT,
                    thamGiaDeTai.MaSV,
                    thamGiaDeTai.PhuCap + "",
                    thamGiaDeTai.KetQua
                };
                ListViewItem lsvItem = new ListViewItem(lsviObj);
                lsv_danhSachTGDT.Items.Add(lsvItem);
                selectedDeTai.ThamGiaDeTais.Add(thamGiaDeTai);
                Forms.CleanInput(inpTGDTs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaTGDT_Click(object sender, EventArgs e)
        {
            if (lsv_danhSachTGDT.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 tham gia đề tài để chỉnh sửa!");
                return;
            }
            ListViewItem TGDTSelectedItem = lsv_danhSachTGDT.SelectedItems[0];
            int TGDTSelectedIndex = TGDTSelectedItem.Index;
            DeTai selectedDeTai = GetSelectedDeTai();
            try
            {
                //Update data for TGDT table
                ThamGiaDeTai newThamGiaDeTai = Forms.GetThamGiaDeTai(inpTGDTs, selectedDeTai);
                selectedDeTai.ThamGiaDeTais.RemoveAt(TGDTSelectedIndex);
                selectedDeTai.ThamGiaDeTais.Insert(TGDTSelectedIndex, newThamGiaDeTai);
                string[] newLsviObj = new string[]
                {
                    newThamGiaDeTai.MaDT,
                    newThamGiaDeTai.MaSV,
                    newThamGiaDeTai.PhuCap + "",
                    newThamGiaDeTai.KetQua
                };
                ListViewItem newLsvItem = new ListViewItem(newLsviObj);
                lsv_danhSachTGDT.Items.RemoveAt(TGDTSelectedIndex);
                lsv_danhSachTGDT.Items.Insert(TGDTSelectedIndex, newLsvItem);
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
            ListViewItem TGDTSelectedItem = lsv_danhSachTGDT.SelectedItems[0];
            int TGDTSelectedIndex = TGDTSelectedItem.Index;
            lsv_danhSachTGDT.Items.Remove(TGDTSelectedItem);
            DeTai selectedDeTai = GetSelectedDeTai();
            selectedDeTai.ThamGiaDeTais.RemoveAt(TGDTSelectedIndex);
            Forms.CleanInput(inpTGDTs);
        }

        private void btn_truyCapTGDT_Click(object sender, EventArgs e)
        {
            toMenu = false;
            toTGDT = true;
            Close();
        }

        private void lsv_danhSachTGDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsv_danhSachTGDT.SelectedItems.Count == 0)
            {
                Forms.CleanInput(inpTGDTs);
                return;
            }
            ListViewItem TGDTSelectedItem = lsv_danhSachTGDT.SelectedItems[0];
            txt_phuCapTGDT.Text = TGDTSelectedItem.SubItems[2].Text;
            txt_ketQuaTGDT.Text = TGDTSelectedItem.SubItems[3].Text;
        }
    }
}
