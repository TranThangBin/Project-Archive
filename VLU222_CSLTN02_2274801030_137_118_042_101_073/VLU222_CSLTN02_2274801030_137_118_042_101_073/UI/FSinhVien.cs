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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.UI
{
    public partial class FSinhVien : Form
    {
        private bool toMenu = true;
        private bool toDeTai = false;
        private bool toTGDT = false;
        private List<TextBox> txtSinhViens;
        private List<TextBox> txtDeTais;
        private List<TextBox> txtTGDTs;
        public FSinhVien()
        {
            InitializeComponent();
            txtSinhViens = new List<TextBox>()
            {
                txt_maSinhVien,
                txt_hoLotSV,
                txt_tenSinhVien,
                txt_maKhoaSV
            };
            txtDeTais = new List<TextBox>()
            {
                txt_maDetai,
                txt_tenDetai,
                txt_kinhPhiDT,
                txt_maGiangVienDT
            };
            txtTGDTs = new List<TextBox>()
            {
                txt_phuCapTGDT,
                txt_ketQuaTGDT
            };
        }

        private void FSinhVien_Load(object sender, EventArgs e)
        {
            //render Database data in this event
        }

        private void FSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (toMenu && MessageBox.Show("Bạn muốn quay về trang chủ?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                Forms.MainMenu.Show();
            else if (toDeTai && MessageBox.Show("Bạn muốn truy cập Form đề tài?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Forms.DeTai = new FDeTai();
                Forms.DeTai.Show();
            }
            else if (toTGDT && MessageBox.Show("Bạn muốn tham gia đề tài?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Forms.ThamGiaDT = new FThamGiaDT();
                Forms.ThamGiaDT.Show();
            }
            else
            {
                e.Cancel = true;
                toMenu = true;
                toDeTai = false;
                toTGDT = false;
            }
        }

        private SinhVien GetSinhVien()
        {
            string maSV = txt_maSinhVien.Text;
            string hoLot = txt_hoLotSV.Text;
            string tenSV = txt_tenSinhVien.Text;
            string gioiTinh = cmb_gioiTinhSV.Text;
            string maKhoa = txt_maKhoaSV.Text;
            return new SinhVien(maSV, hoLot, tenSV, gioiTinh, maKhoa);
        }

        private SinhVien GetSelectedSinhVien()
        {
            return lsb_danhSachSinhVien.SelectedItem as SinhVien;
        }

        private int GetSinhVienSelectedIndex()
        {
            return lsb_danhSachSinhVien.SelectedIndex;
        }

        private DeTai GetDeTai(SinhVien sinhVien)
        {
            string maDT = txt_maDetai.Text;
            string tenDT = txt_tenDetai.Text;
            long kinhPhi = long.Parse(txt_kinhPhiDT.Text);
            DateTime ngayBD = dtP_ngayBatDauDT.Value;
            DateTime ngayKT = dtP_ngayKetThucDT.Value;
            string maGV = txt_maGiangVienDT.Text;
            string maSV = sinhVien.MaSV;
            return new DeTai(maDT, tenDT, kinhPhi, ngayBD, ngayKT, maGV, maSV);
        }

        private DeTai GetSelectedDeTai()
        {
            return lsb_danhSachDeTai.SelectedItem as DeTai;
        }

        private int GetDeTaiSelectedIndex()
        {
            return lsb_danhSachDeTai.SelectedIndex;
        }

        private ThamGiaDeTai GetThamGiaDeTai(SinhVien sinhVien, DeTai deTai)
        {
            string maDT = deTai.MaDT;
            string maSV = sinhVien.MaSV;
            long phuCap = long.Parse(txt_phuCapTGDT.Text);
            string ketQua = txt_ketQuaTGDT.Text;
            return new ThamGiaDeTai(maDT, maSV, phuCap, ketQua);
        }

        private void txtSinhViensFullClear()
        {
            Forms.TxtClearInput(txtSinhViens);
            cmb_gioiTinhSV.Text = "";
        }

        private void txtDeTaisFullClear()
        {
            Forms.TxtClearInput(txtDeTais);
            dtP_ngayBatDauDT.Value = DateTime.Today;
            dtP_ngayKetThucDT.Value = DateTime.Today;
        }

        private void btn_themSV_Click(object sender, EventArgs e)
        {
            lsb_danhSachSinhVien.Items.Add(GetSinhVien());
            txtSinhViensFullClear();
        }

        private void btn_suaSV_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(GetSinhVienSelectedIndex(), "Vui lòng chọn 1 sinh viên để chỉnh sửa!")) return;
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            SinhVien newSinhVien = GetSinhVien();
            newSinhVien.Detais = selectedSinhVien.Detais;
            newSinhVien.ThamGiaDeTais = selectedSinhVien.ThamGiaDeTais;
            txtSinhViensFullClear();
        }

        private void btn_xoaSV_Click(object sender, EventArgs e)
        {
            lsb_danhSachSinhVien.Items.Remove(GetSelectedSinhVien());
            txtSinhViensFullClear();
        }

        private void btn_troVeSV_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lsb_danhSachSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsb_danhSachDeTai.Items.Clear();
            lsv_danhSachTGDT.Items.Clear();
            if (GetSinhVienSelectedIndex() == -1)
            {
                txtSinhViensFullClear();
                return;
            }
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            txt_maSinhVien.Text = selectedSinhVien.MaSV;
            txt_hoLotSV.Text = selectedSinhVien.HoLot;
            txt_tenSinhVien.Text = selectedSinhVien.TenSV;
            cmb_gioiTinhSV.Text = selectedSinhVien.GioiTinh;
            txt_maKhoaSV.Text = selectedSinhVien.MaKhoa;
            foreach (DeTai deTai in selectedSinhVien.Detais)
                lsb_danhSachDeTai.Items.Add(deTai);
        }

        private void lsb_danhSachSinhVien_MouseDown(object sender, MouseEventArgs e)
        {
            Forms.LsbRightClickDeselected(sender as ListBox, e);
        }

        private void txt_maSinhVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumberInputHandler(false, sender as TextBox, e);
        }

        private void cmb_gioiTinhSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_themDeTai_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(GetSinhVienSelectedIndex(), "Bạn cần phải chọn 1 sinh viên để thêm đề tài!")) return;
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            DeTai deTai = GetDeTai(selectedSinhVien);
            selectedSinhVien.Detais.Add(deTai);
            lsb_danhSachDeTai.Items.Add(deTai);
            txtDeTaisFullClear();
        }

        private void btn_suaDeTai_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(GetDeTaiSelectedIndex(), "Vui lòng chọn 1 đề tài để chỉnh sửa!")) return;
            int deTaiSelectedIndex = GetDeTaiSelectedIndex();
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            DeTai newDeTai = GetDeTai(selectedSinhVien);
            selectedSinhVien.Detais.RemoveAt(deTaiSelectedIndex);
            selectedSinhVien.Detais.Insert(deTaiSelectedIndex, newDeTai);
            lsb_danhSachDeTai.Items.RemoveAt(deTaiSelectedIndex);
            lsb_danhSachDeTai.Items.Insert(deTaiSelectedIndex, newDeTai);
            txtDeTaisFullClear();
        }

        private void btn_xoaDeTai_Click(object sender, EventArgs e)
        {
            int deTaiSelectedIndex = GetDeTaiSelectedIndex();
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            selectedSinhVien.Detais.RemoveAt(deTaiSelectedIndex);
            lsb_danhSachDeTai.Items.RemoveAt(deTaiSelectedIndex);
            txtDeTaisFullClear();
        }

        private void btn_truycapDeTai_Click(object sender, EventArgs e)
        {
            toMenu = false;
            toDeTai = true;
            Close();
        }

        private void lsb_danhSachDeTai_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsv_danhSachTGDT.Items.Clear();
            if (GetDeTaiSelectedIndex() == -1)
            {
                txtDeTaisFullClear();
                return;
            }
            DeTai selectedDeTai = GetSelectedDeTai();
            txt_maDetai.Text = selectedDeTai.MaDT;
            txt_tenDetai.Text = selectedDeTai.TenDT;
            txt_kinhPhiDT.Text = selectedDeTai.KinhPhi + "";
            dtP_ngayBatDauDT.Value = selectedDeTai.NgayBD;
            dtP_ngayKetThucDT.Value = selectedDeTai.NgayKT;
            txt_maGiangVienDT.Text = selectedDeTai.MaGVHD;
            foreach (ThamGiaDeTai thamGiaDeTai in selectedDeTai.ThamGiaDeTais)
            {
                string[] lsviObj = new string[]
                {
                    thamGiaDeTai.MaDT,
                    thamGiaDeTai.MaSV,
                    thamGiaDeTai.PhuCap+"",
                    thamGiaDeTai.KetQua
                };
                ListViewItem lsvItem = new ListViewItem(lsviObj);
                lsv_danhSachTGDT.Items.Add(lsvItem);
            }
        }

        private void lsb_danhSachDeTai_MouseDown(object sender, MouseEventArgs e)
        {
            Forms.LsbRightClickDeselected(sender as ListBox, e);
        }

        private void txt_kinhPhiDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumberInputHandler(false, sender as TextBox, e);
        }

        private void txt_maGiangVienDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumberInputHandler(false, sender as TextBox, e);
        }

        private void btn_themTGDT_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(GetDeTaiSelectedIndex(), "Bạn cần phải chọn 1 đề tài để tham gia!")) return;
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            DeTai selectedDeTai = GetSelectedDeTai();
            ThamGiaDeTai thamGiaDeTai = GetThamGiaDeTai(selectedSinhVien, selectedDeTai);
            selectedDeTai.ThamGiaDeTais.Add(thamGiaDeTai);
            string[] lsviObj = new string[]
            {
                thamGiaDeTai.MaDT,
                thamGiaDeTai.MaSV,
                thamGiaDeTai.PhuCap+"",
                thamGiaDeTai.KetQua
            };
            ListViewItem lsvItem = new ListViewItem(lsviObj);
            lsv_danhSachTGDT.Items.Add(lsvItem);
            Forms.TxtClearInput(txtTGDTs);
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
            ThamGiaDeTai newTGDT = GetThamGiaDeTai(GetSelectedSinhVien(), selectedDeTai);
            selectedDeTai.ThamGiaDeTais.RemoveAt(TGDTSelectedIndex);
            selectedDeTai.ThamGiaDeTais.Insert(TGDTSelectedIndex, newTGDT);
            string[] newLsviObj = new string[]
            {
                newTGDT.MaDT,
                newTGDT.MaSV,
                newTGDT.PhuCap+"",
                newTGDT.KetQua
            };
            ListViewItem newLsvItem = new ListViewItem(newLsviObj);
            lsv_danhSachTGDT.Items.RemoveAt(TGDTSelectedIndex);
            lsv_danhSachTGDT.Items.Insert(TGDTSelectedIndex, newLsvItem);
            Forms.TxtClearInput(txtTGDTs);
        }

        private void btn_xoaTGDT_Click(object sender, EventArgs e)
        {
            ListViewItem TGDTSelectedItem = lsv_danhSachTGDT.SelectedItems[0];
            int TGDTSelectedIndex = TGDTSelectedItem.Index;
            lsv_danhSachTGDT.Items.RemoveAt(TGDTSelectedIndex);
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

        private void txt_phuCapTGDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumberInputHandler(false, sender as TextBox, e);
        }
    }
}
