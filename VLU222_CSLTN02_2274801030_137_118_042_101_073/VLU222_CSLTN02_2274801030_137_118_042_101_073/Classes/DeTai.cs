using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes
{
    internal class DeTai
    {
        private string maDT;
        private string tenDT;
        private decimal kinhPhi;
        private DateTime ngayBD;
        private DateTime ngayKT;
        private string maGVHD;
        private string maSVCNDT;
        private List<ThamGiaDeTai> thamGiaDeTais = new List<ThamGiaDeTai>();
        private SinhVien sinhViens;
        private GiangVien giangViens;

        public DeTai()
        {
            maDT = "00000000000";
            tenDT = "";
            kinhPhi = 0;
            ngayBD = DateTime.Today;
            ngayKT = DateTime.Today;
            maGVHD = "";
            maSVCNDT = "";
            sinhViens = new SinhVien();
            giangViens = new GiangVien();
        }

        public DeTai(string maDT, string tenDT, decimal kinhPhi, DateTime ngayBD, DateTime ngayKT, string maGVHD, string maSVCNDT, SinhVien sinhViens, GiangVien giangViens)
        {
            this.maDT = maDT;
            this.tenDT = tenDT;
            this.kinhPhi = kinhPhi;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
            this.maGVHD = maGVHD;
            this.maSVCNDT = maSVCNDT;
            this.sinhViens = sinhViens;
            this.giangViens = giangViens;
        }

        public string MaDT { get => maDT; set => maDT = value; }
        public string TenDT { get => tenDT; set => tenDT = value; }
        public decimal KinhPhi { get => kinhPhi; set => kinhPhi = value; }
        public DateTime NgayBD { get => ngayBD; set => ngayBD = value; }
        public DateTime NgayKT { get => ngayKT; set => ngayKT = value; }
        public string MaGVHD { get => maGVHD; set => maGVHD = value; }
        public string MaSVCNDT { get => maSVCNDT; set => maSVCNDT = value; }
        public List<ThamGiaDeTai> ThamGiaDeTais { get => thamGiaDeTais; set => thamGiaDeTais = value; }
        public SinhVien SinhViens { get => sinhViens; set => sinhViens = value; }
        public GiangVien GiangViens { get => giangViens; set => giangViens = value; }
        public override string ToString()
        {
            return $"{maDT}: {tenDT}";
        }
    }
}
