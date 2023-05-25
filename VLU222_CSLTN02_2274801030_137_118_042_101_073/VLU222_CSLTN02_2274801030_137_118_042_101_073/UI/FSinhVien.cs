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
            if (txt_maSinhVien.Text == "")
                throw new Exception("Vui lòng không để trống mã sinh viên!");
            if (txt_hoLotSV.Text == "")
                throw new Exception("Vui lòng không để trống họ lót!");
            if (txt_tenSinhVien.Text == "")
                throw new Exception("Vui lòng không để trống tên sinh viên!");
            if (cmb_gioiTinhSV.Text == "")
                throw new Exception("Vui lòng không để trống giới tính!");
            if (txt_maKhoaSV.Text == "")
                throw new Exception("Vui lòng không để trống mã khoa!");
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
            if (txt_maDetai.Text == "")
                throw new Exception("Vui lòng không để trống mã đề tài!");
            if (txt_tenDetai.Text == "")
                throw new Exception("Vui lòng không để trống tên đề tài!");
            if (txt_kinhPhiDT.Text == "")
                throw new Exception("Vui lòng không để trống kinh phí!");
            if (txt_maGiangVienDT.Text == "")
                throw new Exception("Vui lòng không để trống mã giảng viên!");
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
            if (txt_phuCapTGDT.Text == "")
                throw new Exception("Vui lòng không để trống tiền phụ cấp!");
            if (txt_ketQuaTGDT.Text == "")
                throw new Exception("Vui lòng không để trống kết quả!");
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

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumberInputHandler(false, false, sender as TextBox, e);
        }

        private void txtSpacesHandled_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtPrematureSpacesHandler(sender as TextBox, e);
        }

        private void lsbDeselected_MouseDown(object sender, MouseEventArgs e)
        {
            Forms.LsbRightClickDeselected(sender as ListBox, e);
        }

        private void btn_themSV_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien sinhVien = GetSinhVien();
                lsb_danhSachSinhVien.Items.Add(sinhVien);
                txtSinhViensFullClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaSV_Click(object sender, EventArgs e)
        {
            int sinhVienSelectedIndex = GetSinhVienSelectedIndex();
            if (!Forms.LsbHasItemSelected(sinhVienSelectedIndex, "Vui lòng chọn 1 sinh viên để chỉnh sửa!")) return;
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            try
            {
                SinhVien newSinhVien = GetSinhVien();
                newSinhVien.Detais = selectedSinhVien.Detais;
                Forms.LsbUpdateItem(lsb_danhSachSinhVien, sinhVienSelectedIndex, newSinhVien);
                txtSinhViensFullClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void cmb_gioiTinhSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_themDeTai_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(GetSinhVienSelectedIndex(), "Bạn cần phải chọn 1 sinh viên để thêm đề tài!")) return;
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            try
            {
                DeTai deTai = GetDeTai(selectedSinhVien);
                selectedSinhVien.Detais.Add(deTai);
                lsb_danhSachDeTai.Items.Add(deTai);
                txtDeTaisFullClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaDeTai_Click(object sender, EventArgs e)
        {
            int deTaiSelectedIndex = GetDeTaiSelectedIndex();
            if (!Forms.LsbHasItemSelected(deTaiSelectedIndex, "Vui lòng chọn 1 đề tài để chỉnh sửa!")) return;
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            try
            {
                DeTai newDeTai = GetDeTai(selectedSinhVien);
                selectedSinhVien.Detais.RemoveAt(deTaiSelectedIndex);
                selectedSinhVien.Detais.Insert(deTaiSelectedIndex, newDeTai);
                Forms.LsbUpdateItem(lsb_danhSachDeTai, deTaiSelectedIndex, newDeTai);
                txtDeTaisFullClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void btn_themTGDT_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(GetDeTaiSelectedIndex(), "Bạn cần phải chọn 1 đề tài để tham gia!")) return;
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            DeTai selectedDeTai = GetSelectedDeTai();
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    }
}
