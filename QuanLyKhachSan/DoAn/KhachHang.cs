using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class KhachHang
    {
        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public KhachHang() { }
        public KhachHang(int makhachhang, string tenkhachhang, string cmnd, string diachi, string sodienthoai)
        {
            this.MaKhachHang = makhachhang;
            this.TenKhachHang = tenkhachhang;
            this.CMND = cmnd;
            this.DiaChi = diachi;
            this.SoDienThoai = sodienthoai;
        }    
    }
}
