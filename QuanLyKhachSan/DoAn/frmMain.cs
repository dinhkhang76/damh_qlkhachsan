using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class frmMain : Form
    {
        string manhanvien = "";
        string tennhanvien = "";
        string diachi = "";
        string sodienthoai = "";
        string chucvu = "";
        public frmMain(NhanVien user)
        {
            InitializeComponent();
            this.manhanvien = user.MaNhanVien;
            this.tennhanvien = user.TenNhanVien;
            this.diachi = user.DiaChi;
            this.sodienthoai = user.SoDienThoai;
            this.chucvu = user.ChucVu;
        }

        private void DangNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmDangNhap();
            this.Visible = true;
            frm.ShowDialog();       
        }

        private void DangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.manhanvien = "";
                this.tennhanvien = "";
                this.diachi = "";
                this.sodienthoai = "";
                this.chucvu = "";
                MessageBox.Show("Đăng xuất thành công!");
                frmDangNhap frm = new frmDangNhap();
                this.Visible = false;
                frm.ShowDialog(); 
            }
        }

        private void DoiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(manhanvien);
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DangXuatToolStripMenuItem.Enabled = false;
            DoiMatKhauToolStripMenuItem.Enabled = false;
            QuanLyDichVuToolStripMenuItem.Enabled = false;
            QuanLyHoaDonToolStripMenuItem.Enabled = false;
            QuanLyLoaiPhongToolStripMenuItem.Enabled = false;
            QuanLyKhachHangToolStripMenuItem.Enabled = false;
            QuanLyNhanVienToolStripMenuItem.Enabled = false;
            QuanLyHoaDonToolStripMenuItem.Enabled = false;
            QuanLyPhongToolStripMenuItem.Enabled = false;
            doanhThuToolStripMenuItem.Enabled = false;
            btnDangKyPhong.Enabled = false;
            btnThuePhong.Enabled = false;
            btnDichVu.Enabled = false;
            btnThanhToan.Enabled = false;
            btnDangNhap.Enabled = true;
            //btnDangXuat.Enabled = false;
            
            if (chucvu == "Lễ tân")
            {
                DangNhapToolStripMenuItem.Enabled = false;
                DangXuatToolStripMenuItem.Enabled = true;
                DoiMatKhauToolStripMenuItem.Enabled = true;
                QuanLyDichVuToolStripMenuItem.Enabled = false;
                QuanLyHoaDonToolStripMenuItem.Enabled = false;
                QuanLyLoaiPhongToolStripMenuItem.Enabled = false;
                QuanLyKhachHangToolStripMenuItem.Enabled = false;
                QuanLyNhanVienToolStripMenuItem.Enabled = false;
                QuanLyHoaDonToolStripMenuItem.Enabled = false;
                QuanLyPhongToolStripMenuItem.Enabled = false;
                doanhThuToolStripMenuItem.Enabled = false;
                btnDangKyPhong.Enabled = true;
                btnThuePhong.Enabled = true;
                btnDichVu.Enabled = true;
                btnThanhToan.Enabled = true;
                btnDangNhap.Enabled = false;
                //btnDangXuat.Enabled = true;
            }
            if(chucvu=="Quản lý dịch vụ")
            {
                DangNhapToolStripMenuItem.Enabled = false;
                DangXuatToolStripMenuItem.Enabled = true;
                DoiMatKhauToolStripMenuItem.Enabled = true;
                QuanLyDichVuToolStripMenuItem.Enabled = true;
                QuanLyHoaDonToolStripMenuItem.Enabled = false;
                QuanLyLoaiPhongToolStripMenuItem.Enabled = false;
                QuanLyKhachHangToolStripMenuItem.Enabled = false;
                QuanLyNhanVienToolStripMenuItem.Enabled = false;
                QuanLyHoaDonToolStripMenuItem.Enabled = false;
                QuanLyPhongToolStripMenuItem.Enabled = false;
                doanhThuToolStripMenuItem.Enabled = false;
                btnDangKyPhong.Enabled = false;
                btnThuePhong.Enabled = false;
                btnDichVu.Enabled = false;
                btnThanhToan.Enabled = false;
                btnDangNhap.Enabled = false;
                //btnDangXuat.Enabled = true;
            }
            if (chucvu == "Quản lý khách hàng")
            {
                DangNhapToolStripMenuItem.Enabled = false;
                DangXuatToolStripMenuItem.Enabled = true;
                DoiMatKhauToolStripMenuItem.Enabled = true;
                QuanLyDichVuToolStripMenuItem.Enabled = false;
                QuanLyHoaDonToolStripMenuItem.Enabled = false;
                QuanLyLoaiPhongToolStripMenuItem.Enabled = false;
                QuanLyKhachHangToolStripMenuItem.Enabled = true;
                QuanLyNhanVienToolStripMenuItem.Enabled = false;
                QuanLyHoaDonToolStripMenuItem.Enabled = false;
                QuanLyPhongToolStripMenuItem.Enabled = false;
                doanhThuToolStripMenuItem.Enabled = false;
                btnDangKyPhong.Enabled = false;
                btnThuePhong.Enabled = false;
                btnDichVu.Enabled = false;
                btnThanhToan.Enabled = false;
                btnDangNhap.Enabled = false;
                //btnDangXuat.Enabled = true;
            }
            if (chucvu == "Quản lý nhân viên")
            {
                DangNhapToolStripMenuItem.Enabled = false;
                DangXuatToolStripMenuItem.Enabled = true;
                DoiMatKhauToolStripMenuItem.Enabled = true;
                QuanLyDichVuToolStripMenuItem.Enabled = false;
                QuanLyHoaDonToolStripMenuItem.Enabled = false;
                QuanLyLoaiPhongToolStripMenuItem.Enabled = false;
                QuanLyKhachHangToolStripMenuItem.Enabled = false;
                QuanLyNhanVienToolStripMenuItem.Enabled = true;
                QuanLyHoaDonToolStripMenuItem.Enabled = false;
                QuanLyPhongToolStripMenuItem.Enabled = false;
                doanhThuToolStripMenuItem.Enabled = false;
                btnDangKyPhong.Enabled = false;
                btnThuePhong.Enabled = false;
                btnDichVu.Enabled = false;
                btnThanhToan.Enabled = false;
                btnDangNhap.Enabled = false;
                //btnDangXuat.Enabled = true;
            }
            if (chucvu == "Quản lý phòng")
            {
                DangNhapToolStripMenuItem.Enabled = false;
                DangXuatToolStripMenuItem.Enabled = true;
                DoiMatKhauToolStripMenuItem.Enabled = true;
                QuanLyDichVuToolStripMenuItem.Enabled = false;
                QuanLyHoaDonToolStripMenuItem.Enabled = false;
                QuanLyLoaiPhongToolStripMenuItem.Enabled = true;
                QuanLyKhachHangToolStripMenuItem.Enabled = false;
                QuanLyNhanVienToolStripMenuItem.Enabled = false;
                QuanLyHoaDonToolStripMenuItem.Enabled = false;
                QuanLyPhongToolStripMenuItem.Enabled = true;
                doanhThuToolStripMenuItem.Enabled = false;
                btnDangKyPhong.Enabled = false;
                btnThuePhong.Enabled = false;
                btnDichVu.Enabled = false;
                btnThanhToan.Enabled = false;
                btnDangNhap.Enabled = false;
                //btnDangXuat.Enabled = true;
            }
            if (chucvu == "Kế toán")
            {
                DangNhapToolStripMenuItem.Enabled = false;
                DangXuatToolStripMenuItem.Enabled = true;
                DoiMatKhauToolStripMenuItem.Enabled = true;
                QuanLyDichVuToolStripMenuItem.Enabled = false;
                QuanLyHoaDonToolStripMenuItem.Enabled = false;
                QuanLyLoaiPhongToolStripMenuItem.Enabled = false;
                QuanLyKhachHangToolStripMenuItem.Enabled = false;
                QuanLyNhanVienToolStripMenuItem.Enabled = false;
                QuanLyHoaDonToolStripMenuItem.Enabled = true;
                QuanLyPhongToolStripMenuItem.Enabled = false;
                doanhThuToolStripMenuItem.Enabled = true;
                btnDangKyPhong.Enabled = false;
                btnThuePhong.Enabled = false;
                btnDichVu.Enabled = false;
                btnThanhToan.Enabled = true;
                btnDangNhap.Enabled = false;
                //btnDangXuat.Enabled = true;
            }
            if (chucvu == "Admin")
            {
                DangXuatToolStripMenuItem.Enabled = true;
                DoiMatKhauToolStripMenuItem.Enabled = true;
                QuanLyDichVuToolStripMenuItem.Enabled = true;
                QuanLyHoaDonToolStripMenuItem.Enabled = true;
                QuanLyLoaiPhongToolStripMenuItem.Enabled = true;
                QuanLyKhachHangToolStripMenuItem.Enabled = true;
                QuanLyNhanVienToolStripMenuItem.Enabled = true;
                QuanLyHoaDonToolStripMenuItem.Enabled = true;
                QuanLyPhongToolStripMenuItem.Enabled = true;
                doanhThuToolStripMenuItem.Enabled = true;
                btnDangKyPhong.Enabled = true;
                btnThuePhong.Enabled = true;
                btnDichVu.Enabled = true;
                btnThanhToan.Enabled = true;
                btnDangNhap.Enabled = false;
                //btnDangXuat.Enabled = true;
            }
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            frmDichVu frm = new frmDichVu();
            frm.ShowDialog();
        }

        private void btnThuePhong_Click(object sender, EventArgs e)
        {
            frmThuePhong frm = new frmThuePhong();
            frm.ShowDialog();
        }

        private void btnDangKyPhong_Click(object sender, EventArgs e)
        {
            frmDangKyPhong frm = new frmDangKyPhong();
            frm.ShowDialog();
        }

        private void QuanLyKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyKhachHang frm = new frmQuanLyKhachHang();
            frm.ShowDialog();
        }

        private void QuanLyNhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien frm = new frmQuanLyNhanVien();
            frm.ShowDialog();
        }

        private void QuanLyPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyPhong frm = new frmQuanLyPhong();
            frm.ShowDialog();
        }

        private void QuanLyLoaiPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyLoaiPhong frm = new frmQuanLyLoaiPhong();
            frm.ShowDialog();
        }

        private void QuanLyDichVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyDichVu frm = new frmQuanLyDichVu();
            frm.ShowDialog();
        }

        private void QuanLyHoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyHoaDon frm = new frmQuanLyHoaDon();
            frm.ShowDialog();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoanhThu frm = new frmDoanhThu();
            frm.ShowDialog();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            NhanVien user = new NhanVien();
            user.MaNhanVien = manhanvien;
            user.TenNhanVien = tennhanvien;
            user.DiaChi = diachi;
            user.SoDienThoai = sodienthoai;
            user.ChucVu = chucvu;
            frmHoaDon frm = new frmHoaDon(user);
            frm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Form frm = new frmDangNhap();
            this.Visible = false;
            frm.ShowDialog();
        }

        private void TroGiupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTroGiup frm = new frmTroGiup();
            frm.ShowDialog();
        }

        //private void btnDangXuat_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //    if (result == DialogResult.Yes)
        //    {
        //        this.manhanvien = "";
        //        this.tennhanvien = "";
        //        this.diachi = "";
        //        this.sodienthoai = "";
        //        this.chucvu = "";
        //        MessageBox.Show("Đăng xuất thành công!");
        //        frmDangNhap frm = new frmDangNhap();
        //        this.Visible = false;
        //        frm.ShowDialog();
        //    }
        //}


    }
}
