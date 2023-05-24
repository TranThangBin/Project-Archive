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
    public partial class FGiangVien : Form
    {
        private bool toMenu = true;
        private bool toDeTai = false;
        private List<TextBox> txtGiangViens;
        private List<TextBox> txtDeTais;
        public FGiangVien()
        {
            InitializeComponent();
            txtGiangViens = new List<TextBox>()
            {
                txt_maGiangVien,
                txt_hoLot,
                txt_tenGiangVien,
                txt_trinhDo,
                txt_maKhoa
            };
            txtDeTais = new List<TextBox>()
            {
                txt_maDetai,
                txt_tenDeTai,
                txt_kinhPhi,
                txt_maSinhVien
            };
        }

        private void FGiangVien_Load(object sender, EventArgs e)
        {
            //render Database data in this event
        }

        private void FGiangVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (toMenu && MessageBox.Show("Bạn muốn quay về trang chủ?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                Forms.MainMenu.Show();
            else if (toDeTai && MessageBox.Show("Bạn muốn truy cập Form đề tài?", "Xác nhận!", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Forms.DeTai = new FDeTai();
                Forms.DeTai.Show();
            }
            else
            {
                e.Cancel = true;
                toMenu = true;
                toDeTai = false;
            }
        }

        private GiangVien GetGiangVien()
        {
            string maGiangVien = txt_maGiangVien.Text;
            string hoLot = txt_hoLot.Text;
            string tenGV = txt_tenGiangVien.Text;
            string trinhDo = txt_trinhDo.Text;
            string gioiTinh = cmB_gioiTinh.Text;
            string maKhoa = txt_maKhoa.Text;
            return new GiangVien(maGiangVien, hoLot, tenGV, gioiTinh, trinhDo, maKhoa);
        }

        private DeTai GetDeTai(GiangVien giangVien)
        {
            string maDT = txt_maDetai.Text;
            string tenDT = txt_tenDeTai.Text;
            long kinhPhi = long.Parse(txt_kinhPhi.Text);
            DateTime ngayBD = dtP_ngayBatDau.Value;
            DateTime ngayKT = dtP_ngayKetThuc.Value;
            string maGVHD = giangVien.MaGV;
            string maSVCNDT = txt_maSinhVien.Text;
            return new DeTai(maDT, tenDT, kinhPhi, ngayBD, ngayKT, maGVHD, maSVCNDT);
        }

        private void UpdateGiangVien(int index, GiangVien giangVien)
        {
            lsB_danhSachGiangVien.Items.RemoveAt(index);
            lsB_danhSachGiangVien.Items.Insert(index, giangVien);
            lsB_danhSachGiangVien.SelectedIndex = index;
        }

        private void txtGiangViensFullClear()
        {
            Forms.ClearInput(txtGiangViens);
            cmB_gioiTinh.Text = "";
        }

        private void txtDeTaisFullClear()
        {
            Forms.ClearInput(txtDeTais);
            dtP_ngayBatDau.Value = DateTime.Today;
            dtP_ngayKetThuc.Value = DateTime.Today;
        }

        private void btn_themGV_Click(object sender, EventArgs e)
        {
            lsB_danhSachGiangVien.Items.Add(GetGiangVien());
            txtGiangViensFullClear();
        }

        private void btn_suaGV_Click(object sender, EventArgs e)
        {
            int GiangVienSelectedIndex = lsB_danhSachGiangVien.SelectedIndex;
            if (GiangVienSelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn 1 giảng viên để chỉnh sửa!");
                return;
            }
            GiangVien selectedGiangVien = lsB_danhSachGiangVien.SelectedItem as GiangVien;
            GiangVien newGiangVien = GetGiangVien();
            newGiangVien.Detais = selectedGiangVien.Detais;
            UpdateGiangVien(GiangVienSelectedIndex, newGiangVien);
            txtGiangViensFullClear();
        }

        private void btn_xoaGV_Click(object sender, EventArgs e)
        {
            GiangVien selectedGiangVien = lsB_danhSachGiangVien.SelectedItem as GiangVien;
            lsB_danhSachGiangVien.Items.Remove(selectedGiangVien);
            txtGiangViensFullClear();
        }

        private void btn_troVeGV_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lsB_danhSachGiangVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsV_giangVienGuongdanVeDT.Items.Clear();
            if (lsB_danhSachGiangVien.SelectedIndex == -1) return;
            GiangVien selectedGiangVien = lsB_danhSachGiangVien.SelectedItem as GiangVien;
            txt_maGiangVien.Text = selectedGiangVien.MaGV;
            txt_hoLot.Text = selectedGiangVien.HoLot;
            txt_tenGiangVien.Text = selectedGiangVien.TenGV;
            txt_trinhDo.Text = selectedGiangVien.TrinhDo;
            cmB_gioiTinh.Text = selectedGiangVien.GioiTinh;
            txt_maKhoa.Text = selectedGiangVien.MaKhoa;
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
        }

        private void txt_maGiangVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.NumberInputHandler(false, sender as TextBox, e);
        }

        private void txt_maKhoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.NumberInputHandler(false, sender as TextBox, e);
        }

        private void cmB_gioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_themDT_Click(object sender, EventArgs e)
        {
            int GiangVienSelectedIndex = lsB_danhSachGiangVien.SelectedIndex;
            if (GiangVienSelectedIndex == -1)
            {
                MessageBox.Show("Bạn cần phải chọn 1 giảng viên để thêm đề tài!");
                return;
            }
            GiangVien selectedGiangVien = lsB_danhSachGiangVien.SelectedItem as GiangVien;
            DeTai deTai = GetDeTai(selectedGiangVien);
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
            UpdateGiangVien(GiangVienSelectedIndex, selectedGiangVien);
            txtDeTaisFullClear();
        }

        private void btn_suaDT_Click(object sender, EventArgs e)
        {
            if (lsV_giangVienGuongdanVeDT.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 tham gia đề tài để chỉnh sửa!");
                return;
            }
            ListViewItem deTaiSelectedItem = lsV_giangVienGuongdanVeDT.SelectedItems[0];
            int deTaiSelectedIndex = deTaiSelectedItem.Index;
            GiangVien selectedGiangVien = lsB_danhSachGiangVien.SelectedItem as GiangVien;
            DeTai newDeTai = GetDeTai(selectedGiangVien);
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
            txtDeTaisFullClear();
        }

        private void btn_xoaDT_Click(object sender, EventArgs e)
        {
            ListViewItem deTaiSelectedItem = lsV_giangVienGuongdanVeDT.SelectedItems[0];
            int deTaiSelectedIndex = deTaiSelectedItem.Index;
            lsV_giangVienGuongdanVeDT.Items.RemoveAt(deTaiSelectedIndex);
            int GiangVienSelectedIndex = lsB_danhSachGiangVien.SelectedIndex;
            GiangVien selectedGiangVien = lsB_danhSachGiangVien.SelectedItem as GiangVien;
            selectedGiangVien.Detais.RemoveAt(deTaiSelectedIndex);
            UpdateGiangVien(GiangVienSelectedIndex, selectedGiangVien);
            txtDeTaisFullClear();
        }

        private void btn_truyCapDT_Click(object sender, EventArgs e)
        {
            toMenu = false;
            toDeTai = true;
            Close();
        }

        private void lsV_giangVienGuongdanVeDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsV_giangVienGuongdanVeDT.SelectedItems.Count == 0) return;
            ListViewItem deTaiSelectedItem = lsV_giangVienGuongdanVeDT.SelectedItems[0];
            txt_maDetai.Text = deTaiSelectedItem.SubItems[0].Text;
            txt_tenDeTai.Text = deTaiSelectedItem.SubItems[1].Text;
            txt_kinhPhi.Text = deTaiSelectedItem.SubItems[2].Text;
            dtP_ngayBatDau.Text = deTaiSelectedItem.SubItems[3].Text;
            dtP_ngayKetThuc.Text = deTaiSelectedItem.SubItems[4].Text;
            txt_maSinhVien.Text = deTaiSelectedItem.SubItems[5].Text;
        }

        private void lsB_danhSachGiangVien_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) lsB_danhSachGiangVien.SelectedIndex = -1;
        }
    }
}
