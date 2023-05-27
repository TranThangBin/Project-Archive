using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLU222_CSLTN02_2274801030_137_118_042_101_073.UI;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes
{
    internal static class Forms
    {
        private static QLDETAINCKHSINHVIEN mainMenu;
        private static FThamGiaDT thamGiaDT;
        private static FDeTai deTai;
        private static FGiangVien giangVien;
        private static FSinhVien sinhVien;
        private static FKhoa khoa;
        private static FThanhVien thanhVien;

        public static QLDETAINCKHSINHVIEN MainMenu { get => mainMenu; set => mainMenu = value; }
        public static FThamGiaDT ThamGiaDT { get => thamGiaDT; set => thamGiaDT = value; }
        public static FDeTai DeTai { get => deTai; set => deTai = value; }
        public static FGiangVien GiangVien { get => giangVien; set => giangVien = value; }
        public static FSinhVien SinhVien { get => sinhVien; set => sinhVien = value; }
        public static FKhoa Khoa { get => khoa; set => khoa = value; }
        public static FThanhVien ThanhVien { get => thanhVien; set => thanhVien = value; }

        private static bool IsSpecialChar(char ch)
        {
            if (char.IsLetter(ch))
                return false;
            else if (char.IsDigit(ch))
                return false;
            else if (ch == ' ')
                return false;
            else if (ch == (char)Keys.Back)
                return false;
            else if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                return false;
            return true;
        }

        public static ThamGiaDeTai GetThamGiaDeTai(ArrayList inps, DeTai deTai = null)
        {
            int lastIndex = inps.Count - 1;
            TextBox txtMaDT;
            TextBox txtMaSV;
            TextBox txtPhuCap = inps[lastIndex - 1] as TextBox;
            TextBox txtKetQua = inps[lastIndex] as TextBox;
            string maDT;
            string maSV;
            if (deTai == null)
            {
                txtMaDT = inps[lastIndex - 3] as TextBox;
                txtMaSV = inps[lastIndex - 2] as TextBox;
                if (txtMaDT.Text == "")
                    throw new Exception("Vui lòng không để trống mã đề tài!");
                if (txtMaDT.TextLength < txtMaDT.MaxLength)
                    throw new Exception($"Mã đề tài chưa thỏa yêu cầu! ({txtMaDT.MaxLength} ký tự)");
                if (txtMaSV.Text == "")
                    throw new Exception("Vui lòng không để trống mã sinh viên!");
                if (txtMaSV.TextLength < txtMaSV.MaxLength)
                    throw new Exception($"Mã sinh viên chưa thỏa yêu cầu! ({txtMaSV.MaxLength} ký tự)");
                maDT = txtMaDT.Text;
                maSV = txtMaSV.Text;
            }
            else
            {
                maDT = deTai.MaDT;
                maSV = deTai.MaSVCNDT;
            }
            if (txtPhuCap.Text == "")
                throw new Exception("Vui lòng không để trống tiền phụ cấp!");
            if (txtKetQua.Text == "")
                throw new Exception("Vui lòng không để trống kết quả!");
            long phuCap = long.Parse(txtPhuCap.Text);
            string ketQua = txtKetQua.Text.TrimEnd();
            return new ThamGiaDeTai(maDT, maSV, phuCap, ketQua);
        }

        public static DeTai GetDeTai(ArrayList inps, GiangVien giangVien = null, SinhVien sinhVien = null)
        {
            int lastIndex = inps.Count - 1;
            TextBox txtMaDT = inps[0] as TextBox;
            TextBox txtTenDT = inps[1] as TextBox;
            TextBox txtKinhPhi = inps[2] as TextBox;
            DateTimePicker dtPNgayBD = inps[3] as DateTimePicker;
            DateTimePicker dtPNgayKT = inps[4] as DateTimePicker;
            TextBox txtMaGV;
            TextBox txtMaSV;
            string maGVHD;
            string maSVCNDT;
            if (txtMaDT.Text == "")
                throw new Exception("Vui lòng không để trống mã đề tài!");
            if (txtMaDT.TextLength < txtMaDT.MaxLength)
                throw new Exception($"Mã đề tài chưa thỏa yêu cầu! ({txtMaDT.MaxLength} ký tự)");
            if (txtTenDT.Text == "")
                throw new Exception("Vui lòng không để trống tên đề tài!");
            if (txtKinhPhi.Text == "")
                throw new Exception("Vui lòng không để trống kinh phí!");
            if (giangVien == null && sinhVien == null)
            {
                txtMaGV = inps[lastIndex - 1] as TextBox;
                txtMaSV = inps[lastIndex] as TextBox;
                if (txtMaGV.Text == "")
                    throw new Exception("Vui lòng không để trống mã giảng viên!");
                if (txtMaGV.TextLength < txtMaGV.MaxLength)
                    throw new Exception($"Mã giảng viên chưa thỏa yêu cầu! ({txtMaGV.MaxLength} ký tự)");
                if (txtMaSV.Text == "")
                    throw new Exception("Vui lòng không để trống mã sinh viên!");
                if (txtMaSV.TextLength < txtMaSV.MaxLength)
                    throw new Exception($"Mã sinh viên chưa thỏa yêu cầu! ({txtMaSV.MaxLength} ký tự)");
                maGVHD = txtMaGV.Text;
                maSVCNDT = txtMaSV.Text;
            }
            else
            {
                if (giangVien == null)
                {
                    txtMaGV = inps[lastIndex] as TextBox;
                    if (txtMaGV.Text == "")
                        throw new Exception("Vui lòng không để trống mã giảng viên!");
                    if (txtMaGV.TextLength < txtMaGV.MaxLength)
                        throw new Exception($"Mã giảng viên chưa thỏa yêu cầu! ({txtMaGV.MaxLength} ký tự)");
                    maGVHD = txtMaGV.Text;
                }
                else maGVHD = giangVien.MaGV;
                if (sinhVien == null)
                {
                    txtMaSV = inps[lastIndex] as TextBox;
                    if (txtMaSV.Text == "")
                        throw new Exception("Vui lòng không để trống mã sinh viên!");
                    if (txtMaSV.TextLength < txtMaSV.MaxLength)
                        throw new Exception($"Mã sinh viên chưa thỏa yêu cầu! ({txtMaSV.MaxLength} ký tự)");
                    maSVCNDT = txtMaSV.Text;
                }
                else maSVCNDT = sinhVien.MaSV;
            }
            string maDT = txtMaDT.Text;
            string tenDT = txtTenDT.Text.TrimEnd();
            long kinhPhi = long.Parse(txtKinhPhi.Text);
            DateTime ngayBD = dtPNgayBD.Value;
            DateTime ngayKT = dtPNgayKT.Value;
            if (ngayBD >= ngayKT)
                throw new Exception("Ngày bắt đầu không được trùng hoặc trễ hơn ngày kết thúc!");
            return new DeTai(maDT, tenDT, kinhPhi, ngayBD, ngayKT, maGVHD, maSVCNDT);
        }

        public static GiangVien GetGiangVien(ArrayList inps, Khoa khoa = null)
        {
            int lastIndex = inps.Count - 1;
            TextBox txtMaGV = inps[0] as TextBox;
            TextBox txtHoLot = inps[1] as TextBox;
            TextBox txtTenGV = inps[2] as TextBox;
            TextBox txtTrinhDo = inps[3] as TextBox;
            ComboBox cmBGioiTinh = inps[4] as ComboBox;
            TextBox txtMaKhoa;
            string maKhoa;
            if (txtMaGV.Text == "")
                throw new Exception("Vui lòng không để trống mã giảng viên!");
            if (txtHoLot.Text == "")
                throw new Exception("Vui lòng không để trống họ lót! giảng viên");
            if (txtTenGV.Text == "")
                throw new Exception("Vui lòng không để trống tên giảng viên!");
            if (txtTrinhDo.Text == "")
                throw new Exception("Vui lòng không để trống trình độ viên!");
            if (cmBGioiTinh.Text == "")
                throw new Exception("Vui lòng không để trống giới tính giảng viên!");
            if (txtMaGV.TextLength < txtMaGV.MaxLength)
                throw new Exception($"Mã giảng viên chưa thỏa yêu cầu! ({txtMaGV.MaxLength} ký tự)");
            if (khoa == null)
            {
                txtMaKhoa = inps[lastIndex] as TextBox;
                if (txtMaKhoa.Text == "")
                    throw new Exception("Vui lòng không để trống mã khoa!");
                if (txtMaKhoa.TextLength < txtMaKhoa.MaxLength)
                    throw new Exception($"Mã khoa chưa thỏa yêu cầu! ({txtMaKhoa.MaxLength} ký tự)");
                maKhoa = txtMaKhoa.Text;
            }
            else maKhoa = khoa.MaKhoa;
            string maGV = txtMaGV.Text;
            string hoLot = txtHoLot.Text.TrimEnd();
            string tenGV = txtTenGV.Text;
            string trinhDo = txtTrinhDo.Text.TrimEnd();
            string gioiTinh = cmBGioiTinh.Text;
            return new GiangVien(maGV, hoLot, tenGV, gioiTinh, trinhDo, maKhoa);
        }

        public static SinhVien GetSinhVien(ArrayList inps, Khoa khoa = null)
        {
            int lastIndex = inps.Count - 1;
            TextBox txtMaSV = inps[0] as TextBox;
            TextBox txtHoLot = inps[1] as TextBox;
            TextBox txtTenSV = inps[2] as TextBox;
            ComboBox cmBGioiTinh = inps[3] as ComboBox;
            TextBox txtMaKhoa;
            string maKhoa;
            if (txtMaSV.Text == "")
                throw new Exception("Vui lòng không để trống mã sinh viên!");
            if (txtHoLot.Text == "")
                throw new Exception("Vui lòng không để trống họ lót sinh viên!");
            if (txtTenSV.Text == "")
                throw new Exception("Vui lòng không để trống tên sinh viên!");
            if (cmBGioiTinh.Text == "")
                throw new Exception("Vui lòng không để trống giới tính sinh viên!");
            if (txtMaSV.TextLength < txtMaSV.MaxLength)
                throw new Exception($"Mã sinh viên chưa thỏa yêu cầu! ({txtMaSV.MaxLength} ký tự)");
            if (khoa == null)
            {
                txtMaKhoa = inps[lastIndex] as TextBox;
                if (txtMaKhoa.Text == "")
                    throw new Exception("Vui lòng không để trống mã khoa!");
                if (txtMaKhoa.TextLength < txtMaKhoa.MaxLength)
                    throw new Exception($"Mã khoa chưa thỏa yêu cầu! ({txtMaKhoa.MaxLength} ký tự)");
                maKhoa = txtMaKhoa.Text;
            }
            else maKhoa = khoa.MaKhoa;
            string maSV = txtMaSV.Text;
            string hoLot = txtHoLot.Text.TrimEnd();
            string tenSV = txtTenSV.Text;
            string gioiTinh = cmBGioiTinh.Text;
            return new SinhVien(maSV, hoLot, tenSV, gioiTinh, maKhoa);
        }

        public static Khoa GetKhoa(ArrayList inps)
        {
            TextBox txtMaKhoa = inps[0] as TextBox;
            TextBox txtTenKhoa = inps[1] as TextBox;
            TextBox txtNamThanhLap = inps[2] as TextBox;
            if (txtMaKhoa.Text == "")
                throw new Exception("Vui lòng không để trống mã khoa!");
            if (txtTenKhoa.Text == "")
                throw new Exception("Vui lòng không để trống tên khoa!");
            if (txtNamThanhLap.Text == "")
                throw new Exception("Vui lòng không để trống năm thành lập!");
            if (txtMaKhoa.TextLength < txtMaKhoa.MaxLength)
                throw new Exception($"Mã khoa chưa thỏa yêu cầu! ({txtMaKhoa.MaxLength} ký tự)");
            string maKhoa = txtMaKhoa.Text;
            string tenKhoa = txtTenKhoa.Text.TrimEnd();
            int namThanhLap = int.Parse(txtNamThanhLap.Text);
            if (namThanhLap > DateTime.Today.Year)
                throw new Exception("Năm thành lập của khoa không hợp lệ!");
            return new Khoa(maKhoa, tenKhoa, namThanhLap);
        }

        public static void CleanInput(ArrayList inpObjs)
        {
            bool hasFocus = false;
            for (int i = 0; i < inpObjs.Count; i++)
            {
                if (inpObjs[i] is TextBox)
                {
                    TextBox textBox = inpObjs[i] as TextBox;
                    textBox.Clear();
                    if (hasFocus) continue;
                    textBox.Focus();
                    hasFocus = true;
                }
                if (inpObjs[i] is ComboBox)
                {
                    ComboBox comboBox = inpObjs[i] as ComboBox;
                    comboBox.Text = "";
                    if (hasFocus) continue;
                    comboBox.Focus();
                    hasFocus = true;
                }
                if (inpObjs[i] is DateTimePicker)
                {
                    DateTimePicker dateTimePicker = inpObjs[i] as DateTimePicker;
                    dateTimePicker.Value = DateTime.Today;
                    if (hasFocus) continue;
                    dateTimePicker.Focus();
                    hasFocus = true;
                }
            }
        }

        public static void TxtNumIdHandler(TextBox textBox, KeyPressEventArgs e, bool allowNegative = false, bool isDecimal = false)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control) return;
            if (char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == (char)Keys.Back) return;
            if (allowNegative)
                if (e.KeyChar == '-' && textBox.TextLength == 0) return;
            if (isDecimal)
                if (e.KeyChar == '.' && textBox.TextLength > 0 && !textBox.Text.Contains(".")) return;
            e.Handled = true;
        }

        public static void TxtStringNumIdHandler(KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (e.KeyChar == ' ')
                e.Handled = true;
            else if (IsSpecialChar(e.KeyChar)) e.Handled = true;
        }

        public static void TxtStringOnlyHandler(TextBox textBox, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                if (textBox.Text.EndsWith(" ") || textBox.TextLength == 0)
                    e.Handled = true;
            }
            else if (IsSpecialChar(e.KeyChar)) e.Handled = true;
            else if (char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        public static void TxtOneWordOnlyHandler(KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                e.Handled = true;
            else if (IsSpecialChar(e.KeyChar)) e.Handled = true;
            else if (char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        public static void LsbRightClickDeselected(ListBox listBox, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) listBox.SelectedIndex = -1;
        }

        public static bool LsbHasItemSelected(ListBox listBox, string message)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show(message);
                return false;
            }
            return true;
        }

        public static void LsbUpdateItem(ListBox listBox, int index, object item)
        {
            listBox.Items.RemoveAt(index);
            listBox.Items.Insert(index, item);
            listBox.SelectedIndex = index;
        }
    }
}
