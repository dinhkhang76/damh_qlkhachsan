using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class Phong
    {
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string MaLoai { get; set; }
        public string TinhTrang { get; set; }
        public float GiaThue { get; set; }
        public Phong() { }
        public Phong(string maphong, string tenphong, string maloai, string tinhtrang, float giathue)
        {
            this.MaPhong = maphong;
            this.TenPhong = tenphong;
            this.MaLoai = maloai;
            this.TinhTrang = tinhtrang;
            this.GiaThue = giathue;
        } 
    }
}
