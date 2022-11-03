using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class ThanhToan
    {
        public int MaThue { get; set; }
        public int MaThanhToan { get; set; }
        public float ThanhTien { get; set; }
        public string HinhThucThanhToan { get; set; }
        public string GhiChu { get; set; }
        public string NgayThanhToan { get; set; }
        public ThanhToan() { }
        public ThanhToan(int mathue, int mathnhtoan, float thanhtien, string hinhthucthanhtoan, string ghichu, string ngaythanhtoan)
        {
            this.MaThue = mathue;
            this.MaThanhToan = mathnhtoan;
            this.ThanhTien = thanhtien;
            this.HinhThucThanhToan = hinhthucthanhtoan;
            this.GhiChu = ghichu;
            this.NgayThanhToan = ngaythanhtoan;
        } 
    }
}
