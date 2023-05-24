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
        private List<TextBox> txtDeTais;
        private List<TextBox> txtTGDTs;
        public FDeTai()
        {
            InitializeComponent();
            txtDeTais = new List<TextBox>()
            {
                txt_maDetai,
                txt_tenDetai,
                txt_kinhPhi,
                txt_maGiangVien,
                txt_maSinhVien
            };
            txtTGDTs = new List<TextBox>()
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

        private DeTai GetDeTai()
        {
            string maDT = txt_maDetai.Text;
            string tenDT = txt_tenDetai.Text;
            long kinhPhi = long.Parse(txt_kinhPhi.Text);
            DateTime ngayBD = dtP_ngayBatDau.Value;
            DateTime ngayKT = dtP_ngayKetThuc.Value;
            string maGVHD = txt_maGiangVien.Text;
            string maSVCNDT = txt_maSinhVien.Text;
            return new DeTai(maDT, tenDT, kinhPhi, ngayBD, ngayKT, maGVHD, maSVCNDT);
        }
        private ThamGiaDeTai GetThamGiaDeTai(DeTai deTai)
        {
            string maDT = deTai.MaDT;
            string maSV = deTai.MaSVCNDT;
            long phuCap = long.Parse(txt_phuCapTGDT.Text);
            string ketQua = txt_ketQuaTGDT.Text;
            return new ThamGiaDeTai(maDT, maSV, phuCap, ketQua);
        }

        private void UpdateDeTai(int index, DeTai deTai)
        {
            lsB_danhSachDeTai.Items.RemoveAt(index);
            lsB_danhSachDeTai.Items.Insert(index, deTai);
            lsB_danhSachDeTai.SelectedIndex = index;
        }

        private void txtDeTaisFullClear()
        {
            Forms.ClearInput(txtDeTais);
            dtP_ngayBatDau.Value = DateTime.Today;
            dtP_ngayKetThuc.Value = DateTime.Today;
        }

        private void btn_themDeTai_Click(object sender, EventArgs e)
        {
            lsB_danhSachDeTai.Items.Add(GetDeTai());
            txtDeTaisFullClear();
        }

        private void btn_suaDeTai_Click(object sender, EventArgs e)
        {
            int DeTaiSelectedIndex = lsB_danhSachDeTai.SelectedIndex;
            if (DeTaiSelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn 1 đề tài để chỉnh sửa!");
                return;
            }
            DeTai selectedDeTai = lsB_danhSachDeTai.SelectedItem as DeTai;
            DeTai newDeTai = GetDeTai();
            newDeTai.ThamGiaDeTais = selectedDeTai.ThamGiaDeTais;
            UpdateDeTai(DeTaiSelectedIndex, newDeTai);
            txtDeTaisFullClear();
        }

        private void btn_xoaDeTai_Click(object sender, EventArgs e)
        {
            DeTai selectedThamGiaDeTai = lsB_danhSachDeTai.SelectedItem as DeTai;
            lsB_danhSachDeTai.Items.Remove(selectedThamGiaDeTai);
            txtDeTaisFullClear();
        }

        private void btn_troVeDeTai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lsB_danhSachDeTai_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsv_danhSachTGDT.Items.Clear();
            if (lsB_danhSachDeTai.SelectedIndex == -1) return;
            DeTai selectedDeTai = lsB_danhSachDeTai.SelectedItem as DeTai;
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
        }

        private void lsB_danhSachDeTai_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) lsB_danhSachDeTai.SelectedIndex = -1;
        }

        private void txt_kinhPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.NumberInputHandler(false, sender as TextBox, e);
        }

        private void txt_maGiangVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.NumberInputHandler(false, sender as TextBox, e);
        }

        private void txt_maSinhVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.NumberInputHandler(false, sender as TextBox, e);
        }

        private void btn_themTGDT_Click(object sender, EventArgs e)
        {
            int DeTaiSelectedIndex = lsB_danhSachDeTai.SelectedIndex;
            if (DeTaiSelectedIndex == -1)
            {
                MessageBox.Show("Bạn cần phải chọn 1 đề tài để tham gia!");
                return;
            }
            DeTai selectedDeTai = lsB_danhSachDeTai.SelectedItem as DeTai;
            ThamGiaDeTai thamGiaDeTai = GetThamGiaDeTai(selectedDeTai);
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
            UpdateDeTai(DeTaiSelectedIndex, selectedDeTai);
            Forms.ClearInput(txtTGDTs);
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
            DeTai selectedDeTai = lsB_danhSachDeTai.SelectedItem as DeTai;
            ThamGiaDeTai newThamGiaDeTai = GetThamGiaDeTai(selectedDeTai);
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
            Forms.ClearInput(txtTGDTs);
        }

        private void btn_xoaTGDT_Click(object sender, EventArgs e)
        {
            ListViewItem TGDTSelectedItem = lsv_danhSachTGDT.SelectedItems[0];
            int TGDTSelectedIndex = TGDTSelectedItem.Index;
            lsv_danhSachTGDT.Items.Remove(TGDTSelectedItem);
            int DeTaiSelectedIndex = lsB_danhSachDeTai.SelectedIndex;
            DeTai selectedDeTai = lsB_danhSachDeTai.SelectedItem as DeTai;
            selectedDeTai.ThamGiaDeTais.RemoveAt(TGDTSelectedIndex);
            UpdateDeTai(DeTaiSelectedIndex, selectedDeTai);
            Forms.ClearInput(txtTGDTs);
        }

        private void btn_truyCapTGDT_Click(object sender, EventArgs e)
        {
            toMenu = false;
            toTGDT = true;
            Close();
        }

        private void lsv_danhSachTGDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsv_danhSachTGDT.SelectedItems.Count == 0) return;
            ListViewItem TGDTSelectedItem = lsv_danhSachTGDT.SelectedItems[0];
            txt_phuCapTGDT.Text = TGDTSelectedItem.SubItems[2].Text;
            txt_ketQuaTGDT.Text = TGDTSelectedItem.SubItems[3].Text;
        }

        private void txt_maSinhVienTGDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.NumberInputHandler(false, sender as TextBox, e);
        }

        private void txt_phuCapTGDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.NumberInputHandler(false, sender as TextBox, e);
        }
    }
}
