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
            if (txt_maGiangVien.Text == "")
                throw new Exception("Vui lòng không để trống mã giảng viên!");
            if (txt_hoLot.Text == "")
                throw new Exception("Vui lòng không để trống họ lót!");
            if (txt_tenGiangVien.Text == "")
                throw new Exception("Vui lòng không để trống tên giảng viên!");
            if (txt_trinhDo.Text == "")
                throw new Exception("Vui lòng không để trống trình độ!");
            if (cmB_gioiTinh.Text == "")
                throw new Exception("Vui lòng không để trống giới tính!");
            if (txt_maKhoa.Text == "")
                throw new Exception("Vui lòng không để trống mã khoa!");
            if (txt_maGiangVien.TextLength < txt_maGiangVien.MaxLength)
                throw new Exception("Mã giảng viên chưa thỏa yêu cầu!");
            if (txt_maKhoa.TextLength < txt_maKhoa.MaxLength)
                throw new Exception("Mã khoa chưa thỏa yêu cầu!");
            string maGV = txt_maGiangVien.Text;
            string hoLot = txt_hoLot.Text.TrimEnd();
            string tenGV = txt_tenGiangVien.Text;
            string trinhDo = txt_trinhDo.Text.TrimEnd();
            string gioiTinh = cmB_gioiTinh.Text;
            string maKhoa = txt_maKhoa.Text;
            return new GiangVien(maGV, hoLot, tenGV, gioiTinh, trinhDo, maKhoa);
        }

        private GiangVien GetSelectedGiangVien()
        {
            return lsB_danhSachGiangVien.SelectedItem as GiangVien;
        }

        private int GetGiangVienSelectedIndex()
        {
            return lsB_danhSachGiangVien.SelectedIndex;
        }

        private DeTai GetDeTai(GiangVien giangVien)
        {
            if (txt_maDetai.Text == "")
                throw new Exception("Vui lòng không để trống mã đề tài!");
            if (txt_tenDeTai.Text == "")
                throw new Exception("Vui lòng không để trống tên đề tài!");
            if (txt_kinhPhi.Text == "")
                throw new Exception("Vui lòng không để trống kinh phí!");
            if (txt_maSinhVien.Text == "")
                throw new Exception("Vui lòng không để trống mã sinh viên!");
            if (txt_maDetai.TextLength < txt_maDetai.MaxLength)
                throw new Exception("Mã đề tài chưa thỏa yêu cầu!");
            string maDT = txt_maDetai.Text;
            string tenDT = txt_tenDeTai.Text.TrimEnd();
            long kinhPhi = long.Parse(txt_kinhPhi.Text);
            DateTime ngayBD = dtP_ngayBatDau.Value;
            DateTime ngayKT = dtP_ngayKetThuc.Value;
            if (ngayBD > ngayKT)
                throw new Exception("Ngày bắt đầu không được trễ hơn ngày kết thúc!");
            string maGVHD = giangVien.MaGV;
            string maSVCNDT = txt_maSinhVien.Text;
            return new DeTai(maDT, tenDT, kinhPhi, ngayBD, ngayKT, maGVHD, maSVCNDT);
        }

        private void txtGiangViensFullClear()
        {
            Forms.TxtClearInput(txtGiangViens);
            cmB_gioiTinh.Text = "";
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

        private void txtStringNumId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringNumIdHandler(e);
        }

        private void txtIStringOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtStringOnlyHandler(sender as TextBox, e);
        }

        private void btn_themGV_Click(object sender, EventArgs e)
        {
            try
            {
                GiangVien giangVien = GetGiangVien();
                lsB_danhSachGiangVien.Items.Add(giangVien);
                txtGiangViensFullClear();
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
                GiangVien newGiangVien = GetGiangVien();
                newGiangVien.Detais = selectedGiangVien.Detais;
                Forms.LsbUpdateItem(lsB_danhSachGiangVien, GetGiangVienSelectedIndex(), newGiangVien);
                txtGiangViensFullClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaGV_Click(object sender, EventArgs e)
        {
            GiangVien giangVien = GetSelectedGiangVien();
            lsB_danhSachGiangVien.Items.Remove(giangVien);
            txtGiangViensFullClear();
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
                txtGiangViensFullClear();
                txtDeTaisFullClear();
                txt_maGiangVien.Enabled = true;
                btn_themGV.Enabled = true;
                return;
            }
            GiangVien selectedGiangVien = GetSelectedGiangVien();
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
                txt_maGiangVien.Enabled = false;
                btn_themGV.Enabled = false;
            }
        }

        private void lsB_danhSachGiangVien_MouseDown(object sender, MouseEventArgs e)
        {
            Forms.LsbRightClickDeselected(sender as ListBox, e);
        }

        private void txt_tenGiangVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            Forms.TxtOneWordOnlyHandler(e);
        }

        private void cmB_gioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmB_gioiTinh_Enter(object sender, EventArgs e)
        {
            cmB_gioiTinh.DroppedDown = true;
        }

        private void btn_themDT_Click(object sender, EventArgs e)
        {
            if (!Forms.LsbHasItemSelected(lsB_danhSachGiangVien, "Bạn cần phải chọn 1 giảng viên để thêm đề tài!")) return;
            GiangVien selectedGiangVien = GetSelectedGiangVien();
            try
            {
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
                txtDeTaisFullClear();
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
            ListViewItem deTaiSelectedItem = lsV_giangVienGuongdanVeDT.SelectedItems[0];
            int deTaiSelectedIndex = deTaiSelectedItem.Index;
            GiangVien selectedGiangVien = GetSelectedGiangVien();
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoaDT_Click(object sender, EventArgs e)
        {
            ListViewItem deTaiSelectedItem = lsV_giangVienGuongdanVeDT.SelectedItems[0];
            int deTaiSelectedIndex = deTaiSelectedItem.Index;
            lsV_giangVienGuongdanVeDT.Items.RemoveAt(deTaiSelectedIndex);
            GiangVien selectedGiangVien = GetSelectedGiangVien();
            selectedGiangVien.Detais.RemoveAt(deTaiSelectedIndex);
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
            if (lsV_giangVienGuongdanVeDT.SelectedItems.Count == 0)
            {
                txtDeTaisFullClear();
                return;
            }
            ListViewItem deTaiSelectedItem = lsV_giangVienGuongdanVeDT.SelectedItems[0];
            txt_maDetai.Text = deTaiSelectedItem.SubItems[0].Text;
            txt_tenDeTai.Text = deTaiSelectedItem.SubItems[1].Text;
            txt_kinhPhi.Text = deTaiSelectedItem.SubItems[2].Text;
            dtP_ngayBatDau.Text = deTaiSelectedItem.SubItems[3].Text;
            dtP_ngayKetThuc.Text = deTaiSelectedItem.SubItems[4].Text;
            txt_maSinhVien.Text = deTaiSelectedItem.SubItems[5].Text;
        }
    }
}
