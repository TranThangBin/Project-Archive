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
        private int phuCap;
        private string ketQua;
        private SinhVien sinhViens;

        public ThamGiaDeTai()
        {
            maDT = "00000000000";
            maSV = "00000000";
            phuCap = 0;
            ketQua = "";
            sinhViens = new SinhVien();
        }

        public ThamGiaDeTai(string maDT, string maSV, int phuCap, string ketQua, SinhVien sinhViens)
        {
            this.maDT = maDT;
            this.maSV = maSV;
            this.phuCap = phuCap;
            this.ketQua = ketQua;
            this.sinhViens = sinhViens;
        }

        public string MaDT { get => maDT; set => maDT = value; }
        public string MaSV { get => maSV; set => maSV = value; }
        public int PhuCap { get => phuCap; set => phuCap = value; }
        public string KetQua { get => ketQua; set => ketQua = value; }
        public SinhVien SinhViens { get => sinhViens; set => sinhViens = value; }
        public override string ToString()
        {
            return $"{maDT}--{sinhViens.HoLot} {sinhViens.TenSV}--{ketQua}";
        }
    }
}
