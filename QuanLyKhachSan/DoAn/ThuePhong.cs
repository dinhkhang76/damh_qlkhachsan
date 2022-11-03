using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class ThuePhong
    {
        public int MaThue { get; set; }
        public int MaKhachHang { get; set; }
        public string MaPhong { get; set; }
        public string NgayVao { get; set; }
        public string NgayRa { get; set; }
        public float DatCoc { get; set; }
        public ThuePhong() { }
        public ThuePhong(int mathue, int makhachhang, string maphong, string ngayvao, string ngayra, float datcoc)
        {
            this.MaThue = mathue;
            this.MaKhachHang = makhachhang;
            this.MaPhong = maphong;
            this.NgayVao = ngayvao;
            this.NgayRa = ngayra;
            this.DatCoc = datcoc;
        } 
    }
}
