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
            if (txt_maDetai.Text == "")
                throw new Exception("Vui lòng không để trống mã đề tài!");
            if (txt_maDetai.TextLength < txt_maDetai.MaxLength)
                throw new Exception("Mã đề tài chưa thỏa yêu cầu!");
            if (txt_tenDetai.Text == "")
                throw new Exception("Vui lòng không để trống tên đề tài!");
            if (txt_kinhPhi.Text == "")
                throw new Exception();
            if (txt_maGiangVien.Text == "")
                throw new Exception("Vui lòng không để trống mã giảng viên!");
            if (txt_maSinhVien.Text == "")
                throw new Exception("Vui lòng không để trống mã sinh viên!");
            if (txt_maGiangVien.TextLength < txt_maGiangVien.MaxLength)
                throw new Exception("Mã giảng viên chưa thỏa yêu cầu!");
            if (txt_maSinhVien.TextLength < txt_maSinhVien.MaxLength)
                throw new Exception("Mã sinh viên chưa thỏa yêu cầu!"); ;
            string maDT = txt_maDetai.Text;
            string tenDT = txt_tenDetai.Text.TrimEnd();
            long kinhPhi = long.Parse(txt_kinhPhi.Text);
            DateTime ngayBD = dtP_ngayBatDau.Value;
            DateTime ngayKT = dtP_ngayKetThuc.Value;
            if (ngayBD > ngayKT)
                throw new Exception("Ngày bắt đầu không được trễ hơn ngày kết thúc!");
            string maGVHD = txt_maGiangVien.Text;
            string maSVCNDT = txt_maSinhVien.Text;
            return new DeTai(maDT, tenDT, kinhPhi, ngayBD, ngayKT, maGVHD, maSVCNDT);
        }

        private DeTai GetSelectedDeTai()
        {
            return lsB_danhSachDeTai.SelectedItem as DeTai;
        }

        private int GetDeTaiSelectedIndex()
        {
            return lsB_danhSachDeTai.SelectedIndex;
        }

        private ThamGiaDeTai GetThamGiaDeTai(DeTai deTai)
        {
            if (txt_phuCapTGDT.Text == "")
                throw new Exception("Vui lòng không để trống tiền phụ cấp!");
            if (txt_ketQuaTGDT.Text == "")
                throw new Exception("Vui lòng không để trống kết quả!");
            string maDT = deTai.MaDT;
            string maSV = deTai.MaSVCNDT;
            long phuCap = long.Parse(txt_phuCapTGDT.Text);
            if (phuCap > deTai.KinhPhi)
                throw new Exception("Phụ cấp vượt quá giới hạn kinh phí!");
            string ketQua = txt_ketQuaTGDT.Text.TrimEnd();
            return new ThamGiaDeTai(maDT, maSV, phuCap, ketQua);
        }

        private void txtDeTaisFullClear()
        {
            Forms.TxtClearInput(txtDeTais);
            dtP_ngayBatDau.Value = DateTime.Today;
            dtP_ngayKetThuc.Value = DateTime.Today;
        }

        private void txtNumId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumIdHandler(sender as TextBox, e);
        }

        private void txtIStringOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringOnlyHandler(sender as TextBox, e);
        }

        private void btn_themDeTai_Click(object sender, EventArgs e)
        {
            try
            {
                DeTai deTai = GetDeTai();
                lsB_danhSachDeTai.Items.Add(deTai);
                txtDeTaisFullClear();
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
                DeTai newDeTai = GetDeTai();
                newDeTai.ThamGiaDeTais = selectedDeTai.ThamGiaDeTais;
                Forms.LsbUpdateItem(lsB_danhSachDeTai, GetDeTaiSelectedIndex(), newDeTai);
                txtDeTaisFullClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaDeTai_Click(object sender, EventArgs e)
        {
            DeTai deTai = GetSelectedDeTai();
            lsB_danhSachDeTai.Items.Remove(deTai);
            txtDeTaisFullClear();
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
                txtDeTaisFullClear();
                Forms.TxtClearInput(txtTGDTs);
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
                Forms.TxtClearInput(txtTGDTs);
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
                Forms.TxtClearInput(txtTGDTs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaTGDT_Click(object sender, EventArgs e)
        {
            ListViewItem TGDTSelectedItem = lsv_danhSachTGDT.SelectedItems[0];
            int TGDTSelectedIndex = TGDTSelectedItem.Index;
            lsv_danhSachTGDT.Items.Remove(TGDTSelectedItem);
            DeTai selectedDeTai = GetSelectedDeTai();
            selectedDeTai.ThamGiaDeTais.RemoveAt(TGDTSelectedIndex);
            Forms.TxtClearInput(txtTGDTs);
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
                Forms.TxtClearInput(txtTGDTs);
                return;
            }
            ListViewItem TGDTSelectedItem = lsv_danhSachTGDT.SelectedItems[0];
            txt_phuCapTGDT.Text = TGDTSelectedItem.SubItems[2].Text;
            txt_ketQuaTGDT.Text = TGDTSelectedItem.SubItems[3].Text;
        }
    }
}
