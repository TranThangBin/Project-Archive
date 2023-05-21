using System;
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

        public static QLDETAINCKHSINHVIEN MainMenu { get => mainMenu; set => mainMenu = value; }
        public static FDeTai DeTai { get => deTai; set => deTai = value; }
        public static FThamGiaDT ThamGiaDT { get => thamGiaDT; set => thamGiaDT = value; }
        public static FGiangVien GiangVien { get => giangVien; set => giangVien = value; }
        public static FSinhVien SinhVien { get => sinhVien; set => sinhVien = value; }
        public static FKhoa Khoa { get => khoa; set => khoa = value; }
    }
}
