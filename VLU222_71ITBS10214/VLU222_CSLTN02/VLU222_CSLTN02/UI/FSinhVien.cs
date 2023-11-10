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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.UI
{
    public partial class FSinhVien : Form
    {
        private ArrayList inpSinhViens;
        private ArrayList inpDeTais;
        private ArrayList inpTGDTs;
        public FSinhVien()
        {
            InitializeComponent();
            inpSinhViens = new ArrayList()
            {
                txt_maSinhVien,
                txt_hoLotSV,
                txt_tenSinhVien,
                cmb_gioiTinhSV,
                cmB_maKhoaSV
            };
            inpDeTais = new ArrayList()
            {
                txt_maDetai,
                txt_tenDetai,
                txt_kinhPhiDT,
                dtP_ngayBatDauDT,
                dtP_ngayKetThucDT,
                cmB_maGiangVienDT
            };
            inpTGDTs = new ArrayList()
            {
                txt_phuCapTGDT,
                txt_ketQuaTGDT
            };
        }

        private void FSinhVien_Load(object sender, EventArgs e)
        {
            //render Database data in this event
            Database.RenderSinhVien(lsb_danhSachSinhVien, cmB_maKhoaSV, cmB_maGiangVienDT);
        }

        private void FSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn quay về trang chủ?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                Forms.MainMenu.Show();
            else e.Cancel = true;
        }

        private SinhVien GetSelectedSinhVien()
        {
            return lsb_danhSachSinhVien.SelectedItem as SinhVien;
        }

        private int GetSinhVienSelectedIndex()
        {
            return lsb_danhSachSinhVien.SelectedIndex;
        }

        private DeTai GetSelectedDeTai()
        {
            return lsb_danhSachDeTai.SelectedItem as DeTai;
        }

        private int GetDeTaiSelectedIndex()
        {
            return lsb_danhSachDeTai.SelectedIndex;
        }

        private void txtStringNumId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringNumIdHandler(e);
        }

        private void txtNumOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumOnlyHandler(sender as TextBox, e);
        }

        private void txtStringOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringOnlyHandler(sender as TextBox, e);
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

        private void lsbDeselected_MouseDown(object sender, MouseEventArgs e)
        {
            Forms.LsbRightClickDeselected(sender as ListBox, e);
        }

        private void btn_themSV_Click(object sender, EventArgs e)
        {
            try
            {
                //Insert data into SINHVIEN table
                SinhVien sinhVien = Forms.GetSinhVien(inpSinhViens);
                int rowAffected = Database.InsertSinhVien(sinhVien);
                if (rowAffected == 0 && MessageBox.Show("Thêm Sinh viên thất bại!") == DialogResult.OK)
                    return;
                MessageBox.Show("Thêm Sinh viên thành công!");
                lsb_danhSachSinhVien.Items.Add(sinhVien);
                Forms.CleanInput(inpSinhViens);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Mã sinh viên bị trùng với 1 trong các " +
                                    "sinh viên đã có trong cơ sở dữ liệu!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaSV_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(lsb_danhSachSinhVien, "Vui lòng chọn 1 sinh viên để chỉnh sửa!")) return;
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            try
            {
                //Update data for SINHVIEN table
                SinhVien newSinhVien = Forms.GetSinhVien(inpSinhViens);
                int rowAffected = Database.UpdateSinhVien(selectedSinhVien, newSinhVien);
                if (rowAffected == 0 && MessageBox.Show("Sửa Sinh viên thất bại!") == DialogResult.OK)
                    return;
                MessageBox.Show("Sửa Sinh viên thành công!");
                newSinhVien.Detais = selectedSinhVien.Detais;
                Forms.LsbUpdateItem(lsb_danhSachSinhVien, GetSinhVienSelectedIndex(), newSinhVien);
                Forms.CleanInput(inpSinhViens);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaSV_Click(object sender, EventArgs e)
        {
            //Delete data from SINHVIEN table
            if (GetSinhVienSelectedIndex() == -1 &&
                MessageBox.Show("Bạn cần phải chọn 1 sinh viên để xóa!") == DialogResult.OK)
                return;
            SinhVien sinhVien = GetSelectedSinhVien();
            int rowAffected = Database.DeleteSinhVien(sinhVien);
            if (rowAffected == 0 && MessageBox.Show("Xóa Sinh viên thất bại!") == DialogResult.OK)
                return;
            MessageBox.Show("Xóa Sinh viên thành công!");
            lsb_danhSachSinhVien.Items.Remove(sinhVien);
            Forms.CleanInput(inpSinhViens);
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
                Forms.CleanInput(inpSinhViens);
                Forms.CleanInput(inpDeTais);
                Forms.CleanInput(inpTGDTs);
                txt_maSinhVien.Enabled =
                cmB_maKhoaSV.Enabled =
                btn_themSV.Enabled =
                txt_maDetai.Enabled =
                cmB_maGiangVienDT.Enabled =
                btn_themDeTai.Enabled =
                btn_themTGDT.Enabled = true;
                return;
            }
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            txt_maSinhVien.Text = selectedSinhVien.MaSV;
            txt_hoLotSV.Text = selectedSinhVien.HoLot;
            txt_tenSinhVien.Text = selectedSinhVien.TenSV;
            cmb_gioiTinhSV.Text = selectedSinhVien.GioiTinh;
            cmB_maKhoaSV.Text = selectedSinhVien.MaKhoa;
            foreach (DeTai deTai in selectedSinhVien.Detais)
                lsb_danhSachDeTai.Items.Add(deTai);
            txt_maSinhVien.Enabled =
            cmB_maKhoaSV.Enabled =
            btn_themSV.Enabled = false;
        }

        private void txt_maSinhVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumIdHandler(e);
        }

        private void txt_tenSinhVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtOneWordOnlyHandler(e);
        }

        private void btn_themDeTai_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(lsb_danhSachSinhVien, "Bạn cần phải chọn 1 sinh viên để thêm đề tài!")) return;
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            try
            {
                //Insert data into DETAI table
                DeTai deTai = Forms.GetDeTai(inpDeTais, null, selectedSinhVien);
                int rowAffected = Database.InsertDeTai(deTai);
                if (rowAffected == 0 && MessageBox.Show("Thêm Đề tài thất bại!") == DialogResult.OK)
                    return;
                MessageBox.Show("Thêm Đề tài thành công!");
                selectedSinhVien.Detais.Add(deTai);
                lsb_danhSachDeTai.Items.Add(deTai);
                Forms.CleanInput(inpDeTais);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("Mã đề tài bị trùng với 1 trong các " +
                                    "mã đề tài đã có trong cơ sở dữ liệu!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaDeTai_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(lsb_danhSachDeTai, "Vui lòng chọn 1 đề tài để chỉnh sửa!")) return;
            //Update data for DETAI table
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            DeTai selectedDeTai = GetSelectedDeTai();
            try
            {
                int deTaiSelectedIndex = GetDeTaiSelectedIndex();
                DeTai newDeTai = Forms.GetDeTai(inpDeTais, null, selectedSinhVien);
                int rowAffected = Database.UpdateDeTai(selectedDeTai, newDeTai);
                if (rowAffected == 0 && MessageBox.Show("Sửa Đề tài thất bại!") == DialogResult.OK)
                    return;
                MessageBox.Show("Sửa Đề tài thành công!");
                newDeTai.ThamGiaDeTai = selectedDeTai.ThamGiaDeTai;
                selectedSinhVien.Detais.RemoveAt(deTaiSelectedIndex);
                selectedSinhVien.Detais.Insert(deTaiSelectedIndex, newDeTai);
                Forms.LsbUpdateItem(lsb_danhSachDeTai, deTaiSelectedIndex, newDeTai);
                Forms.CleanInput(inpDeTais);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaDeTai_Click(object sender, EventArgs e)
        {
            //Delete data from DETAI table
            if (GetDeTaiSelectedIndex() == -1 &&
                MessageBox.Show("Bạn cần phải chọn 1 đề tài để xóa!") == DialogResult.OK)
                return;
            int deTaiSelectedIndex = GetDeTaiSelectedIndex();
            SinhVien selectedSinhVien = GetSelectedSinhVien();
            int rowAffected = Database.DeleteDeTai(selectedSinhVien.Detais[deTaiSelectedIndex]);
            if (rowAffected == 0 && MessageBox.Show("Xóa Đề tài thất bại!") == DialogResult.OK)
                return;
            MessageBox.Show("Xóa Đề tài thành công!");
            selectedSinhVien.Detais.RemoveAt(deTaiSelectedIndex);
            lsb_danhSachDeTai.Items.RemoveAt(deTaiSelectedIndex);
            Forms.CleanInput(inpDeTais);
        }

        private void lsb_danhSachDeTai_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsv_danhSachTGDT.Items.Clear();
            if (GetDeTaiSelectedIndex() == -1)
            {
                Forms.CleanInput(inpDeTais);
                Forms.CleanInput(inpTGDTs);
                txt_maDetai.Enabled =
                cmB_maGiangVienDT.Enabled =
                btn_themDeTai.Enabled =
                btn_themTGDT.Enabled = true;
                return;
            }
            DeTai selectedDeTai = GetSelectedDeTai();
            txt_maDetai.Text = selectedDeTai.MaDT;
            txt_tenDetai.Text = selectedDeTai.TenDT;
            txt_kinhPhiDT.Text = selectedDeTai.KinhPhi + "";
            dtP_ngayBatDauDT.Value = selectedDeTai.NgayBD;
            dtP_ngayKetThucDT.Value = selectedDeTai.NgayKT;
            cmB_maGiangVienDT.Text = selectedDeTai.MaGVHD;
            ThamGiaDeTai thamGiaDeTai = selectedDeTai.ThamGiaDeTai;
            if (thamGiaDeTai != null)
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
                btn_themTGDT.Enabled = false;
            }
            txt_maDetai.Enabled =
            cmB_maGiangVienDT.Enabled =
            btn_themDeTai.Enabled = false;
        }

        private void txt_tenDetai_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringNumHandler(sender as TextBox, e);
        }

        private void btn_themTGDT_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(lsb_danhSachDeTai, "Bạn cần phải chọn 1 đề tài để tham gia!")) return;
            DeTai selectedDeTai = GetSelectedDeTai();
            //Insert data into TGDT table
            try
            {
                ThamGiaDeTai thamGiaDeTai = Forms.GetThamGiaDeTai(inpTGDTs, selectedDeTai);
                int rowAffected = Database.InsertThamGiaDeTai(thamGiaDeTai);
                if (rowAffected == 0 && MessageBox.Show("Thêm Tham gia đề tài thất bại!") == DialogResult.OK)
                    return;
                MessageBox.Show("Thêm Tham gia đề tài thành công!");
                selectedDeTai.ThamGiaDeTai = thamGiaDeTai;
                string[] lsviObj = new string[]
                {
                    thamGiaDeTai.MaDT,
                    thamGiaDeTai.MaSV,
                    thamGiaDeTai.PhuCap+"",
                    thamGiaDeTai.KetQua
                };
                ListViewItem lsvItem = new ListViewItem(lsviObj);
                lsv_danhSachTGDT.Items.Add(lsvItem);
                btn_themTGDT.Enabled = false;
                Forms.CleanInput(inpTGDTs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaTGDT_Click(object sender, EventArgs e)
        {
            if (lsv_danhSachTGDT.SelectedItems.Count == 0 &&
                MessageBox.Show("Vui lòng chọn 1 tham gia đề tài để chỉnh sửa!") == DialogResult.OK)
                return;
            //Update data for TGDT table
            ListViewItem TGDTSelectedItem = lsv_danhSachTGDT.SelectedItems[0];
            int TGDTSelectedIndex = TGDTSelectedItem.Index;
            DeTai selectedDeTai = GetSelectedDeTai();
            try
            {
                ThamGiaDeTai newTGDT = Forms.GetThamGiaDeTai(inpTGDTs, selectedDeTai);
                selectedDeTai.ThamGiaDeTai = newTGDT;
                int rowAffected = Database.UpdateThamGiaDeTai(selectedDeTai.ThamGiaDeTai, newTGDT);
                if (rowAffected == 0 && MessageBox.Show("Sửa Tham gia đề tài thất bại!") == DialogResult.OK)
                    return;
                MessageBox.Show("Sửa Tham gia đề tài thành công!");
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
            if (lsv_danhSachTGDT.SelectedItems.Count == 0 &&
                MessageBox.Show("Bạn cần phải chọn 1 tham gia đề tài để xóa!") == DialogResult.OK)
                return;
            DeTai selectedDeTai = GetSelectedDeTai();
            int rowAffected = Database.DeleteThamGiaDeTai(selectedDeTai.ThamGiaDeTai);
            if (rowAffected == 0 && MessageBox.Show("Xóa Tham gia đề tài thất bại") == DialogResult.OK)
                return;
            MessageBox.Show("Xóa Tham gia đề tài thành công!");
            selectedDeTai.ThamGiaDeTai = null;
            lsv_danhSachTGDT.Items.RemoveAt(0);
            btn_themTGDT.Enabled = true;
            Forms.CleanInput(inpTGDTs);
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
