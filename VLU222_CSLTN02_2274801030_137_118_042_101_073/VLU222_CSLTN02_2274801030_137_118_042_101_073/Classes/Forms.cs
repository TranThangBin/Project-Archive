using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLU222_CSLTN02_2274801030_137_118_042_101_073.UI;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes
{
    internal static class Forms
    {
        private static QLDETAINCKHSINHVIEN mainMenu;
        public static QLDETAINCKHSINHVIEN MainMenu { get => mainMenu; set => mainMenu = value; }

        private static FDeTai deTai;
        public static FDeTai DeTai { get => deTai; set => deTai = value; }

        private static FThamGiaDT thamGiaDT;
        public static FThamGiaDT ThamGiaDT { get => thamGiaDT; set => thamGiaDT = value; }

        private static FGiangVien giangVien;
        public static FGiangVien GiangVien { get => giangVien; set => giangVien = value; }

        private static FSinhVien sinhVien;
        public static FSinhVien SinhVien { get => sinhVien; set => sinhVien = value; }

        private static FKhoa khoa;
        public static FKhoa Khoa { get => khoa; set => khoa = value; }
    }
}
