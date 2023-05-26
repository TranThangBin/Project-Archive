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
    public partial class FKhoa : Form
    {
        private bool toMenu = true;
        private bool toGiangVien = false;
        private bool toSinhVien = false;
        private List<TextBox> txtKhoas;
        private List<TextBox> txtGiangViens;
        private List<TextBox> txtSinhViens;
        public FKhoa()
        {
            InitializeComponent();
            txtKhoas = new List<TextBox>()
            {
                txt_maKhoa,
                txt_tenKhoa,
                txt_namThanhLap
            };
            txtGiangViens = new List<TextBox>()
            {
                txt_maGiangVien,
                txt_hoLotGV,
                txt_tenGiangVien,
                txt_trinhDoGV
            };
            txtSinhViens = new List<TextBox>()
            {
                txt_maSinhVien,
                txt_hoLotSV,
                txt_tenSinhVien
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

        private Khoa GetKhoa()
        {
            if (txt_maKhoa.Text == "")
                throw new Exception("Vui lòng không để trống mã khoa!");
            if (txt_tenKhoa.Text == "")
                throw new Exception("Vui lòng không để trống tên khoa!");
            if (txt_namThanhLap.Text == "")
                throw new Exception("Vui lòng không để trống năm thành lập!");
            string maKhoa = txt_maKhoa.Text;
            string tenKhoa = txt_tenKhoa.Text;
            int namThanhLap = int.Parse(txt_namThanhLap.Text);
            if (namThanhLap > DateTime.Today.Year)
                throw new Exception("Năm thành lập của khoa không hợp lệ!");
            return new Khoa(maKhoa, tenKhoa, namThanhLap);
        }

        private Khoa GetSelectedKhoa()
        {
            return lsB_danhSachKhoa.SelectedItem as Khoa;
        }

        private int GetKhoaSelectedIndex()
        {
            return lsB_danhSachKhoa.SelectedIndex;
        }

        private GiangVien GetGiangVien(Khoa khoa)
        {
            if (txt_maGiangVien.Text == "")
                throw new Exception("Vui lòng không để trống mã giảng viên!");
            if (txt_hoLotGV.Text == "")
                throw new Exception("Vui lòng không để trống họ lót giảng viên!");
            if (txt_tenGiangVien.Text == "")
                throw new Exception("Vui lòng không để trống tên giảng viên!");
            if (txt_trinhDoGV.Text == "")
                throw new Exception("Vui lòng không để trống trình độ giảng viên!");
            if (cmB_gioiTinhGV.Text == "")
                throw new Exception("Vui lòng không để trống mã khoa giới tính giảng viên!");
            string maGV = txt_maGiangVien.Text;
            string hoLot = txt_hoLotGV.Text;
            string tenGV = txt_tenGiangVien.Text;
            string trinhDo = txt_trinhDoGV.Text;
            string gioiTinh = cmB_gioiTinhGV.Text;
            string maKhoa = khoa.MaKhoa;
            return new GiangVien(maGV, hoLot, tenGV, gioiTinh, trinhDo, maKhoa);
        }

        private SinhVien GetSinhVien(Khoa khoa)
        {
            if (txt_maSinhVien.Text == "")
                throw new Exception("Vui lòng không để trống mã sinh viên!");
            if (txt_hoLotSV.Text == "")
                throw new Exception("Vui lòng không để trống họ lót sinh viên!");
            if (txt_tenSinhVien.Text == "")
                throw new Exception("Vui lòng không để trống tên sinh viên!");
            if (cmb_gioiTinhSV.Text == "")
                throw new Exception("Vui lòng không để trống mã khoa giới tính sinh viên!");
            string maSV = txt_maSinhVien.Text;
            string hoLot = txt_hoLotSV.Text;
            string tenSV = txt_tenSinhVien.Text;
            string gioiTinh = cmb_gioiTinhSV.Text;
            string maKhoa = khoa.MaKhoa;
            return new SinhVien(maSV, hoLot, tenSV, gioiTinh, maKhoa);
        }

        private void txtGiangViensFullClear()
        {
            Forms.TxtClearInput(txtGiangViens);
            cmB_gioiTinhGV.Text = "";
        }

        private void txtSinhViensFullClear()
        {
            Forms.TxtClearInput(txtSinhViens);
            cmb_gioiTinhSV.Text = "";
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtNumberInputHandler(false, false, sender as TextBox, e);
        }

        private void txtInputConstraint_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtInputConstraint(sender as TextBox, e);
        }

        private void cmB_KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_themKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                Khoa khoa = GetKhoa();
                lsB_danhSachKhoa.Items.Add(khoa);
                Forms.TxtClearInput(txtKhoas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaKhoa_Click(object sender, EventArgs e)
        {
            int khoaSelectedIndex = GetKhoaSelectedIndex();
            if (!Forms.LsbHasItemSelected(khoaSelectedIndex, "Vui lòng chọn 1 khoa để chỉnh sửa!")) return;
            Khoa selectedKhoa = GetSelectedKhoa();
            try
            {
                Khoa newKhoa = GetKhoa();
                newKhoa.SinhViens = selectedKhoa.SinhViens;
                newKhoa.GiangViens = selectedKhoa.GiangViens;
                Forms.LsbUpdateItem(lsB_danhSachKhoa, khoaSelectedIndex, newKhoa);
                Forms.TxtClearInput(txtKhoas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaKhoa_Click(object sender, EventArgs e)
        {
            lsB_danhSachKhoa.Items.Remove(GetSelectedKhoa());
            Forms.TxtClearInput(txtKhoas);
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
                Forms.TxtClearInput(txtKhoas);
                txtGiangViensFullClear();
                txtSinhViensFullClear();
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

        private void btn_themGV_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(GetKhoaSelectedIndex(), "Bạn cần phải chọn 1 khoa để thêm giảng viên!")) return;
            Khoa selectedKhoa = GetSelectedKhoa();
            try
            {
                GiangVien giangVien = GetGiangVien(selectedKhoa);
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
                txtGiangViensFullClear();
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
            ListViewItem giangVienSelectedItem = lsV_danhSachGV.SelectedItems[0];
            int giangVienSelectedIndex = giangVienSelectedItem.Index;
            Khoa selectedKhoa = GetSelectedKhoa();
            try
            {
                GiangVien newGiangVien = GetGiangVien(selectedKhoa);
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
                txtGiangViensFullClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaGV_Click(object sender, EventArgs e)
        {
            ListViewItem giangVienSelectedItem = lsV_danhSachGV.SelectedItems[0];
            int giangVienSelectedIndex = giangVienSelectedItem.Index;
            lsV_danhSachGV.Items.RemoveAt(giangVienSelectedIndex);
            Khoa selectedKhoa = GetSelectedKhoa();
            selectedKhoa.GiangViens.RemoveAt(giangVienSelectedIndex);
            txtGiangViensFullClear();
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
                txtGiangViensFullClear();
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
            if (!Forms.LsbHasItemSelected(GetKhoaSelectedIndex(), "Bạn cần phải chọn 1 khoa để thêm sinh viên!")) return;
            Khoa selectedKhoa = GetSelectedKhoa();
            try
            {
                SinhVien sinhVien = GetSinhVien(selectedKhoa);
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
                txtSinhViensFullClear();
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
            ListViewItem sinhVienSelectedItem = lsV_danhSachSV.SelectedItems[0];
            int sinhVienSelectedIndex = sinhVienSelectedItem.Index;
            Khoa selectedKhoa = GetSelectedKhoa();
            try
            {
                SinhVien newSinhVien = GetSinhVien(selectedKhoa);
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
                txtSinhViensFullClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaSV_Click(object sender, EventArgs e)
        {
            ListViewItem sinhVienSelectedItem = lsV_danhSachSV.SelectedItems[0];
            int sinhVienSelectedIndex = sinhVienSelectedItem.Index;
            lsV_danhSachSV.Items.RemoveAt(sinhVienSelectedIndex);
            Khoa selectedKhoa = GetSelectedKhoa();
            selectedKhoa.SinhViens.RemoveAt(sinhVienSelectedIndex);
            txtSinhViensFullClear();
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
                txtSinhViensFullClear();
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
