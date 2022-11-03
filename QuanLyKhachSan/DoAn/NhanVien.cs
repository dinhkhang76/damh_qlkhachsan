using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }
        public NhanVien() { }
        public NhanVien(string manhanvien, string tennhanvien, string gioitinh, string diachi, string sodienthoai, string chucvu)
        {
            this.MaNhanVien = manhanvien;
            this.TenNhanVien = tennhanvien;
            this.GioiTinh = gioitinh;
            this.DiaChi = diachi;
            this.SoDienThoai = sodienthoai;
            this.ChucVu = chucvu;
        } 
    }
}
