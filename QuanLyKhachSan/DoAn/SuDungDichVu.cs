using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class SuDungDichVu
    {
        public int MaSuDung { get; set; }
        public int MaKhachHang { get; set; }
        public string MaDichVu { get; set; }
        public string NgaySuDung { get; set; }
        public float DonGia { get; set; }
        public SuDungDichVu() { }
        public SuDungDichVu(int masudung, int makhachhang, string madichvu, string ngaysudung, float dongia)
        {
            this.MaSuDung = masudung;
            this.MaKhachHang = makhachhang;
            this.MaDichVu = madichvu;
            this.NgaySuDung = ngaysudung;
            this.DonGia = dongia;
        } 
    }
}
