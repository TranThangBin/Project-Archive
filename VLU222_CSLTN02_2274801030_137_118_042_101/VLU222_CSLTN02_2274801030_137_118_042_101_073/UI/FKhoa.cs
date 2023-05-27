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
    public partial class FKhoa : Form
    {
        private bool toMenu = true;
        private bool toGiangVien = false;
        private bool toSinhVien = false;
        private ArrayList inpKhoas;
        private ArrayList inpGiangViens;
        private ArrayList inpSinhViens;
        public FKhoa()
        {
            InitializeComponent();
            inpKhoas = new ArrayList()
            {
                txt_maKhoa,
                txt_tenKhoa,
                txt_namThanhLap
            };
            inpGiangViens = new ArrayList()
            {
                txt_maGiangVien,
                txt_hoLotGV,
                txt_tenGiangVien,
                txt_trinhDoGV,
                cmB_gioiTinhGV
            };
            inpSinhViens = new ArrayList()
            {
                txt_maSinhVien,
                txt_hoLotSV,
                txt_tenSinhVien,
                cmb_gioiTinhSV
            };
        }

        private void FKhoa_Load(object sender, EventArgs e)
        {
            //render Database data in this event
        }

        private void FKhoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (toMenu && MessageBox.Show("Bạn muốn quay về trang chủ?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                Forms.MainMenu.Show();
            else if (toGiangVien && MessageBox.Show("Bạn muốn truy cập Form giảng viên?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Forms.GiangVien = new FGiangVien();
                Forms.GiangVien.Show();
            }
            else if (toSinhVien && MessageBox.Show("Bạn muốn truy cập Form sinh viên?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Forms.SinhVien = new FSinhVien();
                Forms.SinhVien.Show();
            }
            else
            {
                e.Cancel = true;
                toMenu = true;
                toGiangVien = false;
                toSinhVien = false;
            }
        }

        private Khoa GetSelectedKhoa()
        {
            return lsB_danhSachKhoa.SelectedItem as Khoa;
        }

        private int GetKhoaSelectedIndex()
        {
            return lsB_danhSachKhoa.SelectedIndex;
        }

        private void txtNumId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumIdHandler(sender as TextBox, e);
        }

        private void txtStringOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringOnlyHandler(sender as TextBox, e);
        }

        private void txtOneWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtOneWordOnlyHandler(e);
        }

        private void cmB_KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmB_Enter(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            cmb.DroppedDown = true;
        }

        private void btn_themKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                //Insert data into KHOA table
                Khoa khoa = Forms.GetKhoa(inpKhoas);
                lsB_danhSachKhoa.Items.Add(khoa);
                Forms.CleanInput(inpKhoas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaKhoa_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(lsB_danhSachKhoa, "Vui lòng chọn 1 khoa để chỉnh sửa!")) return;
            Khoa selectedKhoa = GetSelectedKhoa();
            try
            {
                //Update data for KHOA table
                Khoa newKhoa = Forms.GetKhoa(inpKhoas);
                newKhoa.SinhViens = selectedKhoa.SinhViens;
                newKhoa.GiangViens = selectedKhoa.GiangViens;
                Forms.LsbUpdateItem(lsB_danhSachKhoa, GetKhoaSelectedIndex(), newKhoa);
                Forms.CleanInput(inpKhoas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaKhoa_Click(object sender, EventArgs e)
        {
            //Delete data from KHOA table
            lsB_danhSachKhoa.Items.Remove(GetSelectedKhoa());
            Forms.CleanInput(inpKhoas);
        }

        private void btn_troVeKhoa_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lsB_danhSachKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsV_danhSachGV.Items.Clear();
            lsV_danhSachSV.Items.Clear();
            if (GetKhoaSelectedIndex() == -1)
            {
                Forms.CleanInput(inpKhoas);
                Forms.CleanInput(inpGiangViens);
                Forms.CleanInput(inpSinhViens);
                txt_maKhoa.Enabled = true;
                btn_themKhoa.Enabled = true;
                return;
            }
            Khoa selectedKhoa = GetSelectedKhoa();
            txt_maKhoa.Text = selectedKhoa.MaKhoa;
            txt_tenKhoa.Text = selectedKhoa.TenKhoa;
            txt_namThanhLap.Text = selectedKhoa.NamThanhLap + "";
            foreach (GiangVien giangVien in selectedKhoa.GiangViens)
            {
                string[] lsviObj = new string[]
                {
                    giangVien.MaGV,
                    giangVien.HoLot,
                    giangVien.TenGV,
                    giangVien.TrinhDo,
                    giangVien.GioiTinh,
                    giangVien.MaKhoa
                };
                ListViewItem lsvItem = new ListViewItem(lsviObj);
                lsV_danhSachGV.Items.Add(lsvItem);
            }
            foreach (SinhVien sinhVien in selectedKhoa.SinhViens)
            {
                string[] lsviObj = new string[]
                {
                    sinhVien.MaSV,
                    sinhVien.HoLot,
                    sinhVien.TenSV,
                    sinhVien.GioiTinh,
                    sinhVien.MaKhoa
                };
                ListViewItem lsvItem = new ListViewItem(lsviObj);
                lsV_danhSachSV.Items.Add(lsvItem);
            }
            txt_maKhoa.Enabled = false;
            btn_themKhoa.Enabled = false;
        }

        private void lsB_danhSachKhoa_MouseDown(object sender, MouseEventArgs e)
        {
            Forms.LsbRightClickDeselected(sender as ListBox, e);
        }

        private void txt_maKhoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringNumIdHandler(e);
        }

        private void btn_themGV_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(lsB_danhSachKhoa, "Bạn cần phải chọn 1 khoa để thêm giảng viên!")) return;
            Khoa selectedKhoa = GetSelectedKhoa();
            try
            {
                //Insert data into GIANGVIEN table
                GiangVien giangVien = Forms.GetGiangVien(inpGiangViens, selectedKhoa);
                selectedKhoa.GiangViens.Add(giangVien);
                string[] lsviObj = new string[]
                {
                    giangVien.MaGV,
                    giangVien.HoLot,
                    giangVien.TenGV,
                    giangVien.GioiTinh,
                    giangVien.TrinhDo,
                    giangVien.MaKhoa
                };
                ListViewItem lsvItem = new ListViewItem(lsviObj);
                lsV_danhSachGV.Items.Add(lsvItem);
                Forms.CleanInput(inpGiangViens);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaGV_Click(object sender, EventArgs e)
        {
            if (lsV_danhSachGV.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 giảng viên để chỉnh sửa!");
                return;
            }
            //Update data for GIANGVIEN table
            ListViewItem giangVienSelectedItem = lsV_danhSachGV.SelectedItems[0];
            int giangVienSelectedIndex = giangVienSelectedItem.Index;
            Khoa selectedKhoa = GetSelectedKhoa();
            try
            {
                GiangVien newGiangVien = Forms.GetGiangVien(inpGiangViens, selectedKhoa);
                selectedKhoa.GiangViens.RemoveAt(giangVienSelectedIndex);
                selectedKhoa.GiangViens.Insert(giangVienSelectedIndex, newGiangVien);
                string[] newLsviObj = new string[]
                {
                    newGiangVien.MaGV,
                    newGiangVien.HoLot,
                    newGiangVien.TenGV,
                    newGiangVien.GioiTinh,
                    newGiangVien.TrinhDo,
                    newGiangVien.MaKhoa
                };
                ListViewItem newLsvItem = new ListViewItem(newLsviObj);
                lsV_danhSachGV.Items.RemoveAt(giangVienSelectedIndex);
                lsV_danhSachGV.Items.Insert(giangVienSelectedIndex, newLsvItem);
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
            ListViewItem giangVienSelectedItem = lsV_danhSachGV.SelectedItems[0];
            int giangVienSelectedIndex = giangVienSelectedItem.Index;
            lsV_danhSachGV.Items.RemoveAt(giangVienSelectedIndex);
            Khoa selectedKhoa = GetSelectedKhoa();
            selectedKhoa.GiangViens.RemoveAt(giangVienSelectedIndex);
            Forms.CleanInput(inpGiangViens);
        }

        private void btn_truyCapGV_Click(object sender, EventArgs e)
        {
            toMenu = false;
            toGiangVien = true;
            Close();
        }

        private void lsV_danhSachGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsV_danhSachGV.SelectedItems.Count == 0)
            {
                Forms.CleanInput(inpGiangViens);
                return;
            }
            ListViewItem giangVienSelectedItem = lsV_danhSachGV.SelectedItems[0];
            txt_maGiangVien.Text = giangVienSelectedItem.SubItems[0].Text;
            txt_hoLotGV.Text = giangVienSelectedItem.SubItems[1].Text;
            txt_tenGiangVien.Text = giangVienSelectedItem.SubItems[2].Text;
            txt_trinhDoGV.Text = giangVienSelectedItem.SubItems[3].Text;
            cmB_gioiTinhGV.Text = giangVienSelectedItem.SubItems[4].Text;
        }

        private void btn_themSV_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(lsB_danhSachKhoa, "Bạn cần phải chọn 1 khoa để thêm sinh viên!")) return;
            Khoa selectedKhoa = GetSelectedKhoa();
            try
            {
                //Insert data into SINHVIEN table
                SinhVien sinhVien = Forms.GetSinhVien(inpSinhViens, selectedKhoa);
                selectedKhoa.SinhViens.Add(sinhVien);
                string[] lsviObj = new string[]
                {
                sinhVien.MaSV,
                sinhVien.HoLot,
                sinhVien.TenSV,
                sinhVien.GioiTinh,
                sinhVien.MaKhoa
                };
                ListViewItem lsvItem = new ListViewItem(lsviObj);
                lsV_danhSachSV.Items.Add(lsvItem);
                Forms.CleanInput(inpSinhViens);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaSV_Click(object sender, EventArgs e)
        {
            if (lsV_danhSachSV.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 sinh viên để chỉnh sửa!");
                return;
            }
            //Update data for SINHVIEN table
            ListViewItem sinhVienSelectedItem = lsV_danhSachSV.SelectedItems[0];
            int sinhVienSelectedIndex = sinhVienSelectedItem.Index;
            Khoa selectedKhoa = GetSelectedKhoa();
            try
            {
                SinhVien newSinhVien = Forms.GetSinhVien(inpSinhViens, selectedKhoa);
                selectedKhoa.SinhViens.RemoveAt(sinhVienSelectedIndex);
                selectedKhoa.SinhViens.Insert(sinhVienSelectedIndex, newSinhVien);
                string[] newLsviObj = new string[]
                {
                    newSinhVien.MaSV,
                    newSinhVien.HoLot,
                    newSinhVien.TenSV,
                    newSinhVien.GioiTinh,
                    newSinhVien.MaKhoa
                };
                ListViewItem newLsvItem = new ListViewItem(newLsviObj);
                lsV_danhSachGV.Items.RemoveAt(sinhVienSelectedIndex);
                lsV_danhSachGV.Items.Insert(sinhVienSelectedIndex, newLsvItem);
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
            ListViewItem sinhVienSelectedItem = lsV_danhSachSV.SelectedItems[0];
            int sinhVienSelectedIndex = sinhVienSelectedItem.Index;
            lsV_danhSachSV.Items.RemoveAt(sinhVienSelectedIndex);
            Khoa selectedKhoa = GetSelectedKhoa();
            selectedKhoa.SinhViens.RemoveAt(sinhVienSelectedIndex);
            Forms.CleanInput(inpSinhViens);
        }

        private void btn_truyCapSV_Click(object sender, EventArgs e)
        {
            toMenu = false;
            toSinhVien = true;
            Close();
        }

        private void lsV_danhSachSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsV_danhSachSV.SelectedItems.Count == 0)
            {
                Forms.CleanInput(inpSinhViens);
                return;
            }
            ListViewItem sinhVienSelectedItem = lsV_danhSachSV.SelectedItems[0];
            txt_maSinhVien.Text = sinhVienSelectedItem.SubItems[0].Text;
            txt_hoLotSV.Text = sinhVienSelectedItem.SubItems[1].Text;
            txt_tenSinhVien.Text = sinhVienSelectedItem.SubItems[2].Text;
            cmb_gioiTinhSV.Text = sinhVienSelectedItem.SubItems[3].Text;
        }
    }
}
