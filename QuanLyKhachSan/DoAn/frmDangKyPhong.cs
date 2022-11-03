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
    public partial class frmDangKyPhong : Form
    {
        KetNoi kn = new KetNoi();
        public frmDangKyPhong()
        {
            InitializeComponent();
            dtpNgayNhanPhong.Value = DateTime.Today;
        }

      

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sqlDangKy = "select P.MaPhong, TenPhong, TenLoai, TinhTrang, NgayVao, NgayRa from ThuePhong TP,Phong P, LoaiPhong LP Where P.MaLoai=LP.MaLoai And P.MaPhong = TP.MaPhong ";
            DataTable dtDangKy = kn.getData(sqlDangKy);
            dgvTimKiemPhongThue.DataSource = dtDangKy;
            String sqlDangKyThue = "SELECT MaPhong, TenPhong, TenLoai, TinhTrang,DonGia FROM Phong P, LoaiPhong LP WHERE P.MaLoai=LP.MaLoai  AND TinhTrang=N'Trống' ";
            DataTable dtDangKyThue = kn.getData(sqlDangKyThue);
            dgvTimKiemPhong.DataSource = dtDangKyThue;

        }

        private void dgvTimKiemPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaPhong.Text = dgvTimKiemPhong.Rows[e.RowIndex].Cells["MaPhong"].Value.ToString();
            }
            catch
            {
            }
        }

        private void dgvTimKiemPhongThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaPhong.Text = dgvTimKiemPhongThue.Rows[e.RowIndex].Cells["MaPhong1"].Value.ToString();
            }
            catch
            {
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDiaChi.Text == "" || txtHoVaTen.Text == "" || txtMaPhong.Text == "" || txtSoCMND.Text == "" || txtSoDienThoai.Text == "")
                {
                    throw new Exception("Chưa điền đầy đủ thông tin!");
                }
                else
                {
                    string makhachhang = "";
                    string sqlKhachHang = "INSERT INTO KhachHang(TenKhachHang, CMND, DiaChi, SoDienThoai)  VALUES(N'" + txtHoVaTen.Text + "',N'" + txtSoCMND.Text + "',N'" + txtDiaChi.Text + "',N'" + txtSoDienThoai.Text + "')";
                    string sqlPhong = "UPDATE Phong SET TinhTrang=N'Đặt trước' WHERE MaPhong=N'" + txtMaPhong.Text + "'";
                    kn.setData(sqlKhachHang);
                    kn.setData(sqlPhong);
                    string sql = "SELECT * FROM KhachHang WHERE CMND=N'" + txtSoCMND.Text + "'";
                    DataTable dtPhong = kn.getData(sql);
                    foreach (DataRow row in dtPhong.Rows)
                    {
                        makhachhang = row["MaKhachHang"].ToString();
                    }
                    string sqlThuePhong = "INSERT INTO ThuePhong(MaKhachHang,MaPhong,NgayVao,NgayRa,DatCoc) VALUES(N'" + makhachhang + "',N'" + txtMaPhong.Text + "' ,N'" + dtpNgayVao.Text + "',N'" + dtpNgayRa.Text + "',0)";
                    kn.setData(sqlThuePhong);
                    txtDiaChi.Text = "";
                    txtHoVaTen.Text = "";
                    txtMaPhong.Text = "";
                    txtSoCMND.Text = "";
                    txtSoDienThoai.Text = "";
                    throw new Exception("Đặt phòng thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                txtDiaChi.Text = "";
                txtHoVaTen.Text = "";
                txtMaPhong.Text = "";
                txtSoCMND.Text = "";
                txtSoDienThoai.Text = "";
                dtpNgayNhanPhong.Value = DateTime.Today;
                dtpNgayRa.Value = DateTime.Today;
                dtpNgayVao.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT TinhTrang FROM Phong WHERE MaPhong=N'" + txtKiemTraTinhTrang.Text + "'";
                DataTable dt = kn.getData(sql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        throw new Exception("Tình Trạng: " + row["TinhTrang"].ToString());
                    }
                }
                else
                {
                    throw new Exception("Không tìm thấy phòng!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

    
    }
}
