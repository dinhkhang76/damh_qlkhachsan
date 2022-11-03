using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class frmHoaDon : Form
    {
        string manhanvien = "";
        string tennhanvien = "";
        string diachi = "";
        string sodienthoai = "";
        string chucvu = "";
        //----------------------
        string maphong = "";
        string tenkhachhang = "";
        DateTime ngaylap = DateTime.Today;
        string makhachhang = "";
        string maphieuthue = "";
        string ngayvao="";
        string ngayra="";
        int songayo = 0;
        float dongia = 0;
        float datcoc = 0;
        float tongtien = 0;
        float tiendichvu = 0;
        float tienphong = 0;
        KetNoi kn = new KetNoi();
        public frmHoaDon(NhanVien user)
        {
            InitializeComponent();
            this.manhanvien = user.MaNhanVien;
            this.tennhanvien = user.TenNhanVien;
            this.diachi = user.DiaChi;
            this.sodienthoai = user.SoDienThoai;
            this.chucvu = user.ChucVu;
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            txtMaKhachHang.ReadOnly = true;
            txtMaPhieuThue.ReadOnly = true;
            txtMaPhong.ReadOnly = true;
            txtSoNgayO.ReadOnly = true;
            txtTienDichVu.ReadOnly = true;
            txtTienPhong.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtNhanVienLap.Text = tennhanvien;
            dtpNgayLap.Value = DateTime.Today;
            dgvDichVuDaSuDung.ToString();
        }

        public void loadDichVu()
        {
            String sqlDichVu = "SELECT TenDichVu, SoLuong, Ngay, SDDV.DonGia FROM SuDungDichVu SDDV, KhachHang KH, DichVu DV WHERE CMND=N'" + txtCMND.Text + "' AND SDDV.MaDichVu=DV.MaDichVu AND KH.MaKhachHang=SDDV.MaKhachHang";
            DataTable dtDichVu = kn.getData(sqlDichVu);
            dgvDichVuDaSuDung.DataSource = dtDichVu;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string cmnd = txtCMND.Text.Trim();
                string sqlKH = "SELECT TP.MaKhachHang, TenKhachHang,MaThue, LP.DonGia, DatCoc, CONVERT(CHAR(16), NgayVao, 101) as NgayVao, CONVERT(CHAR(16), NgayRa, 101) as NgayRa, TP.MaPhong FROM ThuePhong TP, KhachHang KH, Phong P, LoaiPhong LP WHERE P.MaLoai=LP.MaLoai AND P.MaPhong=TP.MaPhong AND TP.MaKhachHang=KH.MaKhachHang AND CMND=N'" + cmnd+"' AND TinhTrang=N'Full'";
                DataTable dtKH = kn.getData(sqlKH);
                // NHƯ CÂU NÀY THÌ CHẠY BẰNG CÁCH NÀY NÈ, GETDATA(SQLSQL) ĐỔ VÀO DATATABLE ẤY
                if (dtKH.Rows.Count > 0)
                {
                    foreach (DataRow row in dtKH.Rows)
                    {
                        makhachhang = row["MaKhachHang"].ToString();
                        tenkhachhang = row["TenKhachHang"].ToString();
                        maphieuthue = row["MaThue"].ToString();
                        maphong = row["MaPhong"].ToString();
                        datcoc = float.Parse(row["DatCoc"].ToString());
                        dongia = float.Parse(row["DonGia"].ToString());
                        //DateTime ngayvaodt = Convert.ToDateTime(row["NgayVao"].ToString());
                        //DateTime ngayradt = Convert.ToDateTime(row["NgayRa"].ToString());
                        //DateTime ngayvaodt = DateTime.Parse(row["NgayVao"].ToString(""));
                        //DateTime ngayradt = DateTime.Parse(row["NgayRa"].ToString());
                        //TimeSpan Time = ngayradt - ngayvaodt;
                        string sql = "SELECT DATEDIFF ( DAY , '"+row["NgayVao"].ToString()+"' , '"+ row["NgayRa"].ToString() + "' ) as s";
                        DataTable dtSongayo = kn.getData(sql);
                        //songayo = Time.Days;
                        songayo = int.Parse(dtSongayo.Rows[0][0].ToString());
                        ngayvao = row["NgayVao"].ToString();
                        ngayra = row["NgayRa"].ToString();
                    }
                    string sqlSDDV = "SELECT *  FROM SuDungDichVu WHERE MaKhachHang=" + makhachhang + "";
                    DataTable dtSDDV = kn.getData(sqlSDDV);
                    if (dtSDDV.Rows.Count > 0)
                    {
                        string sqlDV = "SELECT SUM(dongia) AS TienDichVu FROM SuDungDichVu WHERE MaKhachHang=" + makhachhang + "";
                        DataTable dtDV = kn.getData(sqlDV);
                        foreach (DataRow row in dtDV.Rows)
                        {
                            tiendichvu = float.Parse(row["TienDichVu"].ToString());
                        }
                    }
                    txtMaKhachHang.Text = makhachhang;
                    txtMaPhieuThue.Text = maphieuthue;
                    txtMaPhong.Text = maphong;
                    txtSoNgayO.Text = songayo.ToString();
                    txtTienDichVu.Text = tiendichvu.ToString();
                    tienphong = float.Parse((songayo * dongia).ToString());
                    tongtien = float.Parse((tiendichvu + tienphong - datcoc).ToString());
                    txtTongTien.Text = tongtien.ToString();
                    txtTienPhong.Text = tienphong.ToString();
                    txtDatCoc.Text = datcoc.ToString();
                    loadDichVu();
                }
                else
                {
                    throw new Exception("Không Tìm Thấy Khách Hàng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }   
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"C:\Users\VTP\Desktop\HoaDon.txt");
            string txtHoaDon = "";
            txtHoaDon += "\t\t\tHÓA ĐƠN"+"\n\n";
            txtHoaDon += "Mã phiếu thuê: " + maphieuthue + "\n\n";
            txtHoaDon += "Mã khách hàng: " + makhachhang + " \t|\tMã phòng " + maphong + "\n\n";
            txtHoaDon += "Họ tên khách hàng: " + tenkhachhang + "\n\n";
            txtHoaDon += "Tiền phòng: " + tienphong + " \tSố ngày ở: " + songayo + "\n\n";
            txtHoaDon += "Dịch vụ đã sử dụng:\n\n";
            if (dgvDichVuDaSuDung.Rows.Count > 0)
            {
                for (int i = 0; i < dgvDichVuDaSuDung.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvDichVuDaSuDung.Columns.Count; j++)
                    {
                        txtHoaDon += "|" + dgvDichVuDaSuDung.Rows[i].Cells[j].Value.ToString() + "\t";
                    }
                    txtHoaDon += "|\n\n----------------------------------------------------\n\n";
                }
            }
            else
            {
                txtHoaDon += "\t\tKhông sử dụng dịch vụ!";
            }
            txtHoaDon += "Tiền dịch vụ: " + tiendichvu + "\n\n";
            txtHoaDon += "Đặt cọc: " + datcoc + "\n\n";
            txtHoaDon += "Thành tiền: " + tongtien + "\n\n";
            txtHoaDon += "\t Khách Hàng\t\t\t Nhân Viên\n\n\n\n";
            txtHoaDon +=  "\t"+tenkhachhang +"\t\t\t"+ txtNhanVienLap.Text + "\n\n\n\n";
            txtHoaDon += "\t\t\t\t\t\t\tNgày lập: " + ngaylap.ToString("dd/MM/yyyy") ;
            writer.Write(txtHoaDon);
            writer.Close();
            MessageBox.Show("Xuất hóa đơn thành công");

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlTT = "INSERT INTO ThanhToan(MaPhong, MaKhachHang, TenKhachHang, NgayVao, NgayRa, DatCoc, Thu, ThanhTien, NgayLap, NguoiLap) VALUES(N'" + maphong + "'," + makhachhang + ",N'" + tenkhachhang + "',N'" + ngayvao + "',N'" + ngayra + "'," + datcoc + "," + tongtien + "," + (datcoc + tongtien) + ",N'" + ngaylap.ToString("MM/dd/yyyy") + "',N'" + txtNhanVienLap.Text + "')";
                kn.setData(sqlTT);
                string sqlTP = "DELETE FROM ThuePhong WHERE MaThue=N'" + maphieuthue + "'";
                kn.setData(sqlTP);
                string sqlDV = "DELETE FROM SuDungDichVu WHERE MaKhachHang=N'" + makhachhang + "'";
                kn.setData(sqlDV);
                string sqlP = "UPDATE Phong SET TinhTrang=N'Trống' WHERE MaPhong=N'" + txtMaPhong.Text + "'";
                kn.setData(sqlP);
                throw new Exception("Đã thanh toán!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtCMND.Text = "";
            txtMaKhachHang.Text = "";
            txtMaPhieuThue.Text = "";
            txtMaPhong.Text = "";
            txtSoNgayO.Text = "";
            txtTienDichVu.Text = "";
            txtTienPhong.Text = "";
            txtTongTien.Text = "";
            txtNhanVienLap.Text = "";
            txtDatCoc.Text = "";
            dgvDichVuDaSuDung.DataSource = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

       
    }
}
