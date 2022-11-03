using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class LoaiPhong
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string GhiChu { get; set; }
        public int SoNguoiChuan { get; set; }
        public int SoNguoiToiDa { get; set; }
        public float DonGia { get; set; }
        public LoaiPhong() { }
        public LoaiPhong(string maloai, string tenloai, string ghichu, int songuoichuan, int songuoitoida, float dongia)
        {
            this.MaLoai = maloai;
            this.TenLoai = tenloai;
            this.GhiChu = ghichu;
            this.SoNguoiChuan = songuoichuan;
            this.SoNguoiToiDa = songuoitoida;
            this.DonGia = dongia;
        }    
    }
}
