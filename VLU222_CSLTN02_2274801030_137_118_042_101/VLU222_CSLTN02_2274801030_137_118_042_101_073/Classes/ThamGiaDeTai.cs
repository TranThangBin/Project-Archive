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
        private long phuCap;
        private string ketQua;

        public ThamGiaDeTai()
        {
            maDT = "00000000000";
            maSV = "00000000";
            phuCap = 0;
            ketQua = "";
        }

        public ThamGiaDeTai(string maDT, string maSV, long phuCap, string ketQua)
        {
            this.maDT = maDT;
            this.maSV = maSV;
            this.phuCap = phuCap;
            this.ketQua = ketQua;
        }

        public override string ToString()
        {
            return $"Mã đề tài: {maDT}/Mã sinh viên:{maSV}/Phụ cấp: {phuCap}/Kết quả: {ketQua}";
        }

        public string MaDT { get => maDT; set => maDT = value; }
        public string MaSV { get => maSV; set => maSV = value; }
        public long PhuCap { get => phuCap; set => phuCap = value; }
        public string KetQua { get => ketQua; set => ketQua = value; }
    }
}
