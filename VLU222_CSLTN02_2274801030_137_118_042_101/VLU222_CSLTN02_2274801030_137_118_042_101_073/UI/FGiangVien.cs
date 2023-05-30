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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.UI
{
    public partial class FGiangVien : Form
    {
        private ArrayList inpGiangViens;
        private ArrayList inpDeTais;
        public FGiangVien()
        {
            InitializeComponent();
            inpGiangViens = new ArrayList()
            {
                txt_maGiangVien,
                txt_hoLot,
                txt_tenGiangVien,
                txt_trinhDo,
                cmB_gioiTinh,
                cmB_maKhoa
            };
            inpDeTais = new ArrayList()
            {
                txt_maDetai,
                txt_tenDeTai,
                txt_kinhPhi,
                dtP_ngayBatDau,
                dtP_ngayKetThuc,
                cmB_maSinhVien
            };
        }

        private void FGiangVien_Load(object sender, EventArgs e)
        {
            //render Database data in this event
        }

        private void FGiangVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn quay về trang chủ?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                Forms.MainMenu.Show();
            else e.Cancel = true;
        }

        private GiangVien GetSelectedGiangVien()
        {
            return lsB_danhSachGiangVien.SelectedItem as GiangVien;
        }

        private int GetGiangVienSelectedIndex()
        {
            return lsB_danhSachGiangVien.SelectedIndex;
        }

        private void txtNumId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumIdHandler(e);
        }

        private void txtStringNumId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringNumIdHandler(e);
        }

        private void txtStringOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringOnlyHandler(sender as TextBox, e);
        }

        private void btn_themGV_Click(object sender, EventArgs e)
        {
            try
            {
                //Insert data into GIANGVIEN table
                GiangVien giangVien = Forms.GetGiangVien(inpGiangViens);
                lsB_danhSachGiangVien.Items.Add(giangVien);
                Forms.CleanInput(inpGiangViens);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaGV_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(lsB_danhSachGiangVien, "Vui lòng chọn 1 giảng viên để chỉnh sửa!")) return;
            GiangVien selectedGiangVien = GetSelectedGiangVien();
            try
            {
                //Update data for GIANGVIEN table
                GiangVien newGiangVien = Forms.GetGiangVien(inpGiangViens);
                newGiangVien.Detais = selectedGiangVien.Detais;
                Forms.LsbUpdateItem(lsB_danhSachGiangVien, GetGiangVienSelectedIndex(), newGiangVien);
                Forms.CleanInput(inpGiangViens);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaGV_Click(object sender, EventArgs e)
        {
            //Delete data from GIANGVIEN table
            GiangVien giangVien = GetSelectedGiangVien();
            lsB_danhSachGiangVien.Items.Remove(giangVien);
            Forms.CleanInput(inpGiangViens);
        }

        private void btn_troVeGV_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lsB_danhSachGiangVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsV_giangVienGuongdanVeDT.Items.Clear();
            if (GetGiangVienSelectedIndex() == -1)
            {
                Forms.CleanInput(inpGiangViens);
                Forms.CleanInput(inpDeTais);
                txt_maGiangVien.Enabled =
                cmB_maKhoa.Enabled =
                btn_themGV.Enabled = true;
                return;
            }
            GiangVien selectedGiangVien = GetSelectedGiangVien();
            txt_maGiangVien.Text = selectedGiangVien.MaGV;
            txt_hoLot.Text = selectedGiangVien.HoLot;
            txt_tenGiangVien.Text = selectedGiangVien.TenGV;
            txt_trinhDo.Text = selectedGiangVien.TrinhDo;
            cmB_gioiTinh.Text = selectedGiangVien.GioiTinh;
            cmB_maKhoa.Text = selectedGiangVien.MaKhoa;
            foreach (DeTai deTai in selectedGiangVien.Detais)
            {
                string[] lsviObj = new string[]
                {
                    deTai.MaDT,
                    deTai.TenDT,
                    deTai.KinhPhi + "",
                    deTai.NgayBD + "",
                    deTai.NgayKT + "",
                    deTai.MaGVHD,
                    deTai.MaSVCNDT
                };
                ListViewItem lsvItem = new ListViewItem(lsviObj);
                lsV_giangVienGuongdanVeDT.Items.Add(lsvItem);
            }
            txt_maGiangVien.Enabled =
            cmB_maKhoa.Enabled =
            btn_themGV.Enabled = false;
        }

        private void lsB_danhSachGiangVien_MouseDown(object sender, MouseEventArgs e)
        {
            Forms.LsbRightClickDeselected(sender as ListBox, e);
        }

        private void txt_tenGiangVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtOneWordOnlyHandler(e);
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

        private void btn_themDT_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(lsB_danhSachGiangVien, "Bạn cần phải chọn 1 giảng viên để thêm đề tài!")) return;
            GiangVien selectedGiangVien = GetSelectedGiangVien();
            try
            {
                //Insert data into DETAI table
                DeTai deTai = Forms.GetDeTai(inpDeTais, selectedGiangVien);
                string[] lsviObj = new string[]
                {
                    deTai.MaDT,
                    deTai.TenDT,
                    deTai.KinhPhi + "",
                    deTai.NgayBD + "",
                    deTai.NgayKT + "",
                    deTai.MaGVHD,
                    deTai.MaSVCNDT
                };
                ListViewItem lsvItem = new ListViewItem(lsviObj);
                lsV_giangVienGuongdanVeDT.Items.Add(lsvItem);
                selectedGiangVien.Detais.Add(deTai);
                Forms.CleanInput(inpDeTais);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaDT_Click(object sender, EventArgs e)
        {
            if (lsV_giangVienGuongdanVeDT.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 tham gia đề tài để chỉnh sửa!");
                return;
            }
            //Update data for DETAI table
            ListViewItem deTaiSelectedItem = lsV_giangVienGuongdanVeDT.SelectedItems[0];
            int deTaiSelectedIndex = deTaiSelectedItem.Index;
            GiangVien selectedGiangVien = GetSelectedGiangVien();
            try
            {
                DeTai newDeTai = Forms.GetDeTai(inpDeTais, selectedGiangVien);
                selectedGiangVien.Detais.RemoveAt(deTaiSelectedIndex);
                selectedGiangVien.Detais.Insert(deTaiSelectedIndex, newDeTai);
                string[] newLsviObj = new string[]
                {
                    newDeTai.MaDT,
                    newDeTai.TenDT,
                    newDeTai.KinhPhi + "",
                    newDeTai.NgayBD + "",
                    newDeTai.NgayKT + "",
                    newDeTai.MaGVHD,
                    newDeTai.MaSVCNDT
                };
                ListViewItem newLsvItem = new ListViewItem(newLsviObj);
                lsV_giangVienGuongdanVeDT.Items.RemoveAt(deTaiSelectedIndex);
                lsV_giangVienGuongdanVeDT.Items.Insert(deTaiSelectedIndex, newLsvItem);
                Forms.CleanInput(inpDeTais);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaDT_Click(object sender, EventArgs e)
        {
            //Delete data from DETAI table
            ListViewItem deTaiSelectedItem = lsV_giangVienGuongdanVeDT.SelectedItems[0];
            int deTaiSelectedIndex = deTaiSelectedItem.Index;
            lsV_giangVienGuongdanVeDT.Items.RemoveAt(deTaiSelectedIndex);
            GiangVien selectedGiangVien = GetSelectedGiangVien();
            selectedGiangVien.Detais.RemoveAt(deTaiSelectedIndex);
            Forms.CleanInput(inpDeTais);
        }

        private void lsV_giangVienGuongdanVeDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsV_giangVienGuongdanVeDT.SelectedItems.Count == 0)
            {
                Forms.CleanInput(inpDeTais);
                txt_maDetai.Enabled =
                cmB_maSinhVien.Enabled =
                btn_themDT.Enabled = true;
                return;
            }
            ListViewItem deTaiSelectedItem = lsV_giangVienGuongdanVeDT.SelectedItems[0];
            txt_maDetai.Text = deTaiSelectedItem.SubItems[0].Text;
            txt_tenDeTai.Text = deTaiSelectedItem.SubItems[1].Text;
            txt_kinhPhi.Text = deTaiSelectedItem.SubItems[2].Text;
            dtP_ngayBatDau.Text = deTaiSelectedItem.SubItems[3].Text;
            dtP_ngayKetThuc.Text = deTaiSelectedItem.SubItems[4].Text;
            cmB_maSinhVien.Text = deTaiSelectedItem.SubItems[5].Text;
            txt_maDetai.Enabled =
            cmB_maSinhVien.Enabled =
            btn_themDT.Enabled = false;
        }

        private void txt_tenDeTai_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringNumHandler(sender as TextBox, e);
        }
    }
}
