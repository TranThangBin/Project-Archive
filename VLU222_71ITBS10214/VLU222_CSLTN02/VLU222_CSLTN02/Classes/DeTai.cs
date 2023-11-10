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
        private long kinhPhi;
        private DateTime ngayBD;
        private DateTime ngayKT;
        private string maGVHD;
        private string maSVCNDT;
        private ThamGiaDeTai thamGiaDeTai;

        public DeTai()
        {
            maDT = "00000000000";
            tenDT = "Đề tài chưa có tên";
            kinhPhi = 0;
            ngayBD = DateTime.Today;
            ngayKT = DateTime.Today;
            maGVHD = "";
            maSVCNDT = "";
            thamGiaDeTai = null;
        }

        public DeTai(string maDT, string tenDT, long kinhPhi, DateTime ngayBD, DateTime ngayKT, string maGVHD, string maSVCNDT)
        {
            this.maDT = maDT;
            this.tenDT = tenDT;
            this.kinhPhi = kinhPhi;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
            this.maGVHD = maGVHD;
            this.maSVCNDT = maSVCNDT;
            this.thamGiaDeTai = null;
        }

        public override string ToString()
        {
            return $"{maDT}: {tenDT}";
        }

        public string MaDT { get => maDT; set => maDT = value; }
        public string TenDT { get => tenDT; set => tenDT = value; }
        public long KinhPhi { get => kinhPhi; set => kinhPhi = value; }
        public DateTime NgayBD { get => ngayBD; set => ngayBD = value; }
        public DateTime NgayKT { get => ngayKT; set => ngayKT = value; }
        public string MaGVHD { get => maGVHD; set => maGVHD = value; }
        public string MaSVCNDT { get => maSVCNDT; set => maSVCNDT = value; }
        public ThamGiaDeTai ThamGiaDeTai { get => thamGiaDeTai; set => thamGiaDeTai = value; }
    }
}
