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
        private static FDeTai deTai;
        private static FThamGiaDT thamGiaDT;
        private static FGiangVien giangVien;
        private static FSinhVien sinhVien;
        private static FKhoa khoa;
        private static FThanhVien thanhVien;

        public static QLDETAINCKHSINHVIEN MainMenu { get => mainMenu; set => mainMenu = value; }
        public static FDeTai DeTai { get => deTai; set => deTai = value; }
        public static FThamGiaDT ThamGiaDT { get => thamGiaDT; set => thamGiaDT = value; }
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

        public static void CleanInput(ArrayList inpObjs)
        {
            for (int i = 0; i < inpObjs.Count; i++)
            {
                if (inpObjs[i] is TextBox)
                {
                    TextBox textBox = inpObjs[i] as TextBox;
                    textBox.Clear();
                    if (i == 0) textBox.Focus();
                }
                if (inpObjs[i] is ComboBox)
                {
                    ComboBox comboBox = inpObjs[i] as ComboBox;
                    comboBox.Text = "";
                }
                if (inpObjs[i] is DateTimePicker)
                {
                    DateTimePicker dateTimePicker = inpObjs[i] as DateTimePicker;
                    dateTimePicker.Value = DateTime.Today;
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
