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
    public partial class frmThuePhong : Form
    {
        int mathue = -1;
        int hang_chon = -1;
        KetNoi kn = new KetNoi();
        public frmThuePhong()
        {
            InitializeComponent();
        }

        private void cb1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1.Checked == true)
            {
                btnTimKiem.Enabled = true;
                txtSoCMND.Text = "";
                txtDatCoc.Text = "";
                txtDiaChi.Text = "";
                txtHoTen.Text = "";
                txtSoDienThoai.Text = "";
                txtMaPhong.Text = "";
                txtHoTen.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtMaPhong.ReadOnly = true;
                txtSoDienThoai.ReadOnly = true;
                dgvDanhSachKhachHang.Enabled = false;
                dtpNgayRa.Value = DateTime.Today;
                dtpNgayVao.Value = DateTime.Today;
                btnSua.Enabled = false;
                mathue = -1;
            }
            if (cb1.Checked == false)
            {
                btnTimKiem.Enabled = false;
                txtDatCoc.Text = "";
                txtDiaChi.Text = "";
                txtHoTen.Text = "";
                txtSoDienThoai.Text = "";
                txtMaPhong.Text = "";
                txtSoCMND.Text = "";
                txtHoTen.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtDatCoc.ReadOnly = false;
                txtMaPhong.ReadOnly = false;
                txtSoDienThoai.ReadOnly = false;
                dgvDanhSachKhachHang.Enabled = true;
                dtpNgayRa.Value = DateTime.Today;
                dtpNgayVao.Value = DateTime.Today;
                btnSua.Enabled = false;
                mathue = -1;
            }
        }


        private void frmThuePhong_Load(object sender, EventArgs e)
        {
            btnTimKiem.Enabled = false;
            btnSua.Enabled = false;
            loadThuePhong();
            loadPhong();
        }

        public void loadThuePhong()
        {
            String sql = "SELECT MaThue,TenKhachHang,P.MaPhong,NgayVao,NgayRa,DatCoc,TinhTrang FROM ThuePhong TP, Phong P, KhachHang KH, LoaiPhong LP WHERE P.MaLoai=LP.MaLoai AND P.MaPhong=TP.MaPhong AND TP.MaKhachHang=KH.MaKhachHang";
            DataTable dt = kn.getData(sql);
            dgvDanhSachKhachHang.DataSource = dt; 
        }

        public void loadPhong()
        {
            String sql = "SELECT P.MaPhong, TenPhong, TenLoai, TinhTrang, DonGia FROM  Phong P, LoaiPhong LP WHERE P.MaLoai=LP.MaLoai";
            DataTable dt = kn.getData(sql);
            dgvDanhSachPhong.DataSource = dt;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlCMND = "";
                if (cb1.Checked == true)
                {
                    sqlCMND = "SELECT TenKhachHang,DiaChi,SoDienThoai FROM KhachHang KH, Phong P, ThuePhong TP  Where TP.MaKhachHang=KH.MaKhachHang AND P.MaPhong=TP.MaPhong AND CMND=N'" + txtSoCMND.Text + "' AND TinhTrang=N'Đặt trước'";
                }
                else
                {
                    sqlCMND = "SELECT TenKhachHang,DiaChi,SoDienThoai FROM KhachHang KH, Phong P, ThuePhong TP  Where TP.MaKhachHang=KH.MaKhachHang AND P.MaPhong=TP.MaPhong AND CMND=N'" + txtSoCMND.Text + "' AND TinhTrang=N'Full'";
                }
                DataTable dtCMND = kn.getData(sqlCMND);
                if (dtCMND.Rows.Count > 0)
                {
                    foreach (DataRow row in dtCMND.Rows)
                    {
                        txtDiaChi.Text = row["DiaChi"].ToString();
                        txtHoTen.Text = row["TenKhachHang"].ToString();
                        txtSoDienThoai.Text = row["SoDienThoai"].ToString();  
                    }
                    string sqlNgay = "SELECT NgayVao, NgayRa, MaPhong FROM ThuePhong P, KhachHang KH Where CMND=N'" + txtSoCMND.Text + "' AND P.MaKhachHang=KH.MaKhachHang";
                    DataTable dtNgay = kn.getData(sqlNgay);
                    foreach (DataRow row in dtNgay.Rows)
                    {
                        dtpNgayRa.Text = row["NgayRa"].ToString();
                        dtpNgayVao.Text = row["NgayVao"].ToString();
                        txtMaPhong.Text = row["MaPhong"].ToString();
                    }
                }
                else
                {
                    throw new Exception("Không tìm thấy!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
            }
            
        }

        private void dgvDanhSachKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string maphong;
                hang_chon = e.RowIndex;
                if (hang_chon < dgvDanhSachKhachHang.Rows.Count)
                {
                    mathue = int.Parse(dgvDanhSachKhachHang.Rows[hang_chon].Cells["MaThue"].Value.ToString());
                    maphong = dgvDanhSachKhachHang.Rows[hang_chon].Cells["MaPhong"].Value.ToString();
                    txtMaPhong.Text = dgvDanhSachKhachHang.Rows[hang_chon].Cells["MaPhong"].Value.ToString();
                    string sql = "SELECT TenKhachHang,DiaChi,SoDienThoai,CMND FROM KhachHang KH, ThuePhong TP  WHERE TP.MaPhong=N'" + maphong + "' AND KH.MaKhachHang=TP.MaKhachHang";
                    DataTable dt = kn.getData(sql);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            txtDiaChi.Text = row["DiaChi"].ToString();
                            txtHoTen.Text = row["TenKhachHang"].ToString();
                            txtSoDienThoai.Text = row["SoDienThoai"].ToString();
                            txtSoCMND.Text = row["CMND"].ToString();
                        }
                        string sqlNgay = "SELECT NgayVao, NgayRa, DatCoc FROM ThuePhong Where MaPhong=N'" + maphong + "'";
                        DataTable dtNgay = kn.getData(sqlNgay);
                        foreach (DataRow row in dtNgay.Rows)
                        {
                            dtpNgayRa.Text = row["NgayRa"].ToString();
                            dtpNgayVao.Text = row["NgayVao"].ToString();
                            txtDatCoc.Text = row["DatCoc"].ToString();
                        }
                        btnSua.Enabled = true;
                        btnThue.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("ERROR!");
                    }
                }
            }
            catch
            {
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDatCoc.Text = "0";
            txtDiaChi.Text = "";
            txtHoTen.Text = "";
            txtSoDienThoai.Text = "";
            txtMaPhong.Text = "";
            txtSoCMND.Text = "";
            dtpNgayRa.Value = DateTime.Today;
            dtpNgayVao.Value = DateTime.Today;
            mathue = -1;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThue_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb1.Checked == false)
                {
                    string makhachhang = "";
                    string sqlKH = "INSERT INTO KhachHang(TenKhachHang,CMND,DiaChi,SoDienThoai) VALUES(N'" + txtHoTen.Text + "',N'" + txtSoCMND.Text + "',N'" + txtDiaChi.Text + "',N'" + txtSoDienThoai.Text + "')";
                    kn.setData(sqlKH);
                    string sql = "SELECT * FROM KhachHang WHERE CMND=N'" + txtSoCMND.Text + "'";
                    DataTable dt = kn.getData(sql);
                    foreach (DataRow row in dt.Rows)
                    {
                        makhachhang = row["MaKhachHang"].ToString();
                    }
                    string sqlTP = "INSERT INTO ThuePhong(MaKhachHang,MaPhong,NgayVao,NgayRa,DatCoc) VALUES(N'" + makhachhang + "',N'" + txtMaPhong.Text + "',N'" + dtpNgayVao.Text + "',N'" + dtpNgayRa.Text + "','" + float.Parse(txtDatCoc.Text) + "')";
                    kn.setData(sqlTP);
                    string sqlPhong = "UPDATE Phong SET TinhTrang=N'Full' WHERE MaPhong=N'" + txtMaPhong.Text + "'";
                    kn.setData(sqlPhong);
                    loadThuePhong();
                    loadPhong();
                    txtDatCoc.Text = "0";
                    txtDiaChi.Text = "";
                    txtHoTen.Text = "";
                    txtSoDienThoai.Text = "";
                    txtMaPhong.Text = "";
                    txtSoCMND.Text = "";
                    dtpNgayRa.Value = DateTime.Today;
                    dtpNgayVao.Value = DateTime.Today;
                    mathue = -1;
                    throw new Exception("Thuê thành công!");
                }
                if (cb1.Checked == true)
                {
                    string sqlDK = "UPDATE Phong SET TinhTrang=N'Full' WHERE MaPhong=N'" + txtMaPhong.Text + "'";
                    kn.setData(sqlDK);
                    loadThuePhong();
                    loadPhong();
                    txtDatCoc.Text = "0";
                    txtDiaChi.Text = "";
                    txtHoTen.Text = "";
                    txtSoDienThoai.Text = "";
                    txtMaPhong.Text = "";
                    txtSoCMND.Text = "";
                    dtpNgayRa.Value = DateTime.Today;
                    dtpNgayVao.Value = DateTime.Today;
                    mathue = -1;
                    throw new Exception("Thuê thành công!");
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn sửa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string sqlPhong = "UPDATE ThuePhong SET MaPhong=N'" + txtMaPhong.Text + "',NgayVao=N'" + dtpNgayVao.Text + "',NgayRa=N'" + dtpNgayRa.Text + "',DatCoc=N'" + float.Parse(txtDatCoc.Text) + "' WHERE MaThue=N'" + mathue + "'";
                    kn.setData(sqlPhong);
                    loadThuePhong();
                    string makhachhang = "";
                    string sql = "SELECT * FROM ThuePhong WHERE MaPhong=N'" + txtMaPhong.Text + "'";
                    DataTable dt = kn.getData(sql);
                    foreach (DataRow row in dt.Rows)
                    {
                        makhachhang = row["MaKhachHang"].ToString();
                    }
                    string sqlKH = "UPDATE KhachHang SET TenKhachHang=N'" + txtHoTen.Text + "',CMND=N'" + txtSoCMND.Text + "',DiaChi=N'" + txtDiaChi.Text + "',SoDienThoai=N'" + txtSoDienThoai.Text + "' WHERE MaKhachHang=N'" + makhachhang + "'";
                    kn.setData(sqlKH);
                    btnThue.Enabled = true;
                    throw new Exception("Sửa thành công!");
                    
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
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
                MessageBox.Show(ex.Message, "Thông Báo");
            }
        }

        private void dgvDanhSachPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                hang_chon = e.RowIndex;
                if (hang_chon < dgvDanhSachPhong.Rows.Count)
                {
                    txtMaPhong.Text = dgvDanhSachPhong.Rows[hang_chon].Cells["MaPhong1"].Value.ToString();
                    
                }
            }
            catch
            {
            }
        }

      
    }
}
