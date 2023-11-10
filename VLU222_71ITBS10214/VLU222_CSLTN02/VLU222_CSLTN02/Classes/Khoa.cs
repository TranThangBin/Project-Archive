using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes
{
    internal class Khoa
    {
        private string maKhoa;
        private string tenKhoa;
        private int namThanhLap;
        private List<GiangVien> giangViens = new List<GiangVien>();
        private List<SinhVien> sinhViens = new List<SinhVien>();

        public Khoa()
        {
            maKhoa = "";
            tenKhoa = "unknown";
            namThanhLap = 0;
        }

        public Khoa(string maKhoa, string tenKhoa, int namThanhLap)
        {
            this.maKhoa = maKhoa;
            this.tenKhoa = tenKhoa;
            this.namThanhLap = namThanhLap;
        }

        public override string ToString()
        {
            return $"{maKhoa}/{tenKhoa}/{namThanhLap}";
        }

        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
        public string TenKhoa { get => tenKhoa; set => tenKhoa = value; }
        public int NamThanhLap { get => namThanhLap; set => namThanhLap = value; }
        public List<GiangVien> GiangViens { get => giangViens; set => giangViens = value; }
        public List<SinhVien> SinhViens { get => sinhViens; set => sinhViens = value; }
    }
}
