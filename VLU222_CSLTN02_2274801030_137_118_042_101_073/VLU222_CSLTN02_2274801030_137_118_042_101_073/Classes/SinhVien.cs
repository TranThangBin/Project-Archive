using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes
{
    internal class SinhVien
    {
        private string maSV;
        private string hoLot;
        private string tenSV;
        private string gioiTinh;
        private string maKhoa;
        private Khoa khoas;
        private List<DeTai> detais = new List<DeTai>();
        private List<ThamGiaDeTai> thamGiaDeTais = new List<ThamGiaDeTai>();

        public SinhVien()
        {
            maSV = "00000000";
            hoLot = "";
            tenSV = "";
            gioiTinh = "";
            maKhoa = "";
        }

        public SinhVien(string maSV, string hoLot, string tenSV, string gioiTinh, string maKhoa)
        {
            this.maSV = maSV;
            this.hoLot = hoLot;
            this.tenSV = tenSV;
            this.gioiTinh = gioiTinh;
            this.maKhoa = maKhoa;
        }

        public override string ToString()
        {
            return $"{maSV}/{maKhoa} {hoLot} {tenSV}";
        }

        public string MaSV { get => maSV; set => maSV = value; }
        public string HoLot { get => hoLot; set => hoLot = value; }
        public string TenSV { get => tenSV; set => tenSV = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
        public Khoa Khoas { get => khoas; set => khoas = value; }
        public List<DeTai> Detais { get => detais; set => detais = value; }
        public List<ThamGiaDeTai> ThamGiaDeTais { get => thamGiaDeTais; set => thamGiaDeTais = value; }
    }
}
