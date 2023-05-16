using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes
{
    internal class ThamGiaDeTai
    {
        private string maDT;
        private string maSV;
        private decimal phuCap;
        private string ketQua;
        private SinhVien sinhViens;

        public ThamGiaDeTai()
        {
            maDT = "00000000000";
            maSV = "00000000";
            phuCap = 0;
            ketQua = "";
        }

        public ThamGiaDeTai(string maDT, string maSV, decimal phuCap, string ketQua)
        {
            this.maDT = maDT;
            this.maSV = maSV;
            this.phuCap = phuCap;
            this.ketQua = ketQua;
        }

        public string MaDT { get => maDT; set => maDT = value; }
        public string MaSV { get => maSV; set => maSV = value; }
        public decimal PhuCap { get => phuCap; set => phuCap = value; }
        public string KetQua { get => ketQua; set => ketQua = value; }
        public SinhVien SinhViens { get => sinhViens; set => sinhViens = value; }
    }
}
