using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class Account
    {
        public string MaNhanVien { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public Account() { }
        public Account(string manhanvien, string taikhoan, string matkhau)
        {
            this.MaNhanVien = manhanvien;
            this.TaiKhoan = taikhoan;
            this.MatKhau = matkhau;
        } 
    }
}
