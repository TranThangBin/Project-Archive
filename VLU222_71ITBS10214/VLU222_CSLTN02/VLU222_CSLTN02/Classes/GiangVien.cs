using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes
{
    internal class GiangVien
    {
        private string maGV;
        private string hoLot;
        private string tenGV;
        private string gioiTinh;
        private string trinhDo;
        private string maKhoa;
        private List<DeTai> detais = new List<DeTai>();

        public GiangVien()
        {
            maGV = "00000000";
            hoLot = "unknown";
            tenGV = "unknown";
            gioiTinh = "";
            trinhDo = "";
            maKhoa = "";
        }

        public GiangVien(string maGV, string hoLot, string tenGV, string gioiTinh, string trinhDo, string maKhoa)
        {
            this.maGV = maGV;
            this.hoLot = hoLot;
            this.tenGV = tenGV;
            this.gioiTinh = gioiTinh;
            this.trinhDo = trinhDo;
            this.maKhoa = maKhoa;
        }

        public override string ToString()
        {
            return $"{maGV}/{maKhoa} {trinhDo}: {hoLot} {tenGV}";
        }

        public string MaGV { get => maGV; set => maGV = value; }
        public string HoLot { get => hoLot; set => hoLot = value; }
        public string TenGV { get => tenGV; set => tenGV = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string TrinhDo { get => trinhDo; set => trinhDo = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
        public List<DeTai> Detais { get => detais; set => detais = value; }
    }
}
