using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class DichVu
    {
        public string MaDichVu { get; set; }
        public string LoaiDichVu { get; set; }
        public string TenDichVu { get; set; }
        public float DonGia { get; set; }
        public DichVu() { }
        public DichVu(string madichvu, string loaidichvu, string tendichvu, float dongia)
        {
            this.MaDichVu = madichvu;
            this.TenDichVu = tendichvu;
            this.LoaiDichVu = loaidichvu;
            this.DonGia = dongia;
        }       
    }
}
