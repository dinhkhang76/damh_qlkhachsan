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
    public partial class frmQuanLyNhanVien : Form
    {
        int hang_chon = -1;
        KetNoi kn = new KetNoi();
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            cbbChucVu.SelectedIndex = 0;
            dgvNhanVien.ReadOnly = true;
        }

        void LoadNhanVien()
        {
            String sqlNhanVien = "SELECT NV.MaNhanVien,TenNhanVien,NgaySinh,GioiTinh,DiaChi,SoDienThoai,ChucVu,TaiKhoan,MatKhau FROM NhanVien NV, Account A WHERE NV.MaNhanVien=A.MaNhanVien";
            DataTable dtNhanVien = kn.getData(sqlNhanVien);
            dgvNhanVien.DataSource = dtNhanVien;   
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNhanVien.Text == "")
                {
                    throw new Exception("Mã Nhân Viên trống!");
                }
                else
                {
                    if (txtHoVaTen.Text == "")
                    {
                        throw new Exception("Họ Và Tên trống!");
                    }
                    else
                    {
                        if (txtDiaChi.Text == "")
                        {
                            throw new Exception("Địa Chỉ trống!");
                        }
                        else
                        {
                            if (txtSoDienThoai.Text == "")
                            {
                                throw new Exception("Số Điện Thoại trống!");
                            }
                            else
                            {
                                if (txtTaiKhoan.Text == "")
                                {
                                    throw new Exception("Tài Khoản trống!");
                                }
                                else
                                {
                                    if (txtMatKhau.Text == "")
                                    {
                                        throw new Exception("Mật Khẩu trống!");
                                    }
                                    else
                                    {
                                        string gioitinh = "";
                                        if (rdbtnNam.Checked == true)
                                        {
                                            gioitinh = "Nam";
                                        }
                                        if (rdbtnNu.Checked == true)
                                        {
                                            gioitinh = "Nu";
                                        }
                                        string sql1 = "INSERT INTO NhanVien(MaNhanVien, TenNhanVien, GioiTinh, NgaySinh, DiaChi, SoDienThoai, ChucVu) VALUES(N'" + txtMaNhanVien.Text + "',N'" + txtHoVaTen.Text + "', N'" + gioitinh + "', N'" + dtpNgaySinh.Text + "',N'" + txtDiaChi.Text + "',N'" + txtSoDienThoai.Text + "',N'" + cbbChucVu.Text + "')";
                                        string sql2 = "INSERT INTO Account(MaNhanVien,TaiKhoan,MatKhau) VALUES(N'" + txtMaNhanVien.Text + "',N'" + txtTaiKhoan.Text + "',N'" + txtMatKhau.Text + "')";
                                        kn.setData(sql1);
                                        kn.setData(sql2);
                                        txtDiaChi.Text = "";
                                        txtHoVaTen.Text = "";
                                        txtMaNhanVien.Text = "";
                                        txtMaNV.Text = "";
                                        txtMatKhau.Text = "";
                                        txtSoDienThoai.Text = "";
                                        txtTaiKhoan.Text = "";
                                        cbbChucVu.SelectedIndex = 0;
                                        LoadNhanVien();
                                        throw new Exception("Thêm thành công!");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                hang_chon = e.RowIndex;
                if (hang_chon < dgvNhanVien.Rows.Count)
                {
                    txtMaNhanVien.Text = dgvNhanVien.Rows[hang_chon].Cells["MaNhanVien"].Value.ToString();
                    txtDiaChi.Text = dgvNhanVien.Rows[hang_chon].Cells["DiaChi"].Value.ToString();
                    txtHoVaTen.Text = dgvNhanVien.Rows[hang_chon].Cells["TenNhanVien"].Value.ToString();
                    txtMatKhau.Text = dgvNhanVien.Rows[hang_chon].Cells["MatKhau"].Value.ToString();
                    txtSoDienThoai.Text = dgvNhanVien.Rows[hang_chon].Cells["SoDienThoai"].Value.ToString();
                    txtTaiKhoan.Text = dgvNhanVien.Rows[hang_chon].Cells["TaiKhoan"].Value.ToString();
                    cbbChucVu.Text = dgvNhanVien.Rows[hang_chon].Cells["ChucVu"].Value.ToString();
                    dtpNgaySinh.Text = dgvNhanVien.Rows[hang_chon].Cells["NgaySinh"].Value.ToString();
                    if (dgvNhanVien.Rows[hang_chon].Cells["GioiTinh"].Value.ToString() == "Nam")
                    {
                        rdbtnNam.Checked = true;
                    }
                    if (dgvNhanVien.Rows[hang_chon].Cells["GioiTinh"].Value.ToString() == "Nữ")
                    {
                        rdbtnNu.Checked = true;
                    }
                    txtMaNhanVien.ReadOnly = true;
                }
            }
            catch
            {
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = "";
            txtHoVaTen.Text = "";
            txtMaNhanVien.Text = "";
            txtMatKhau.Text = "";
            txtSoDienThoai.Text = "";
            txtTaiKhoan.Text = "";
            cbbChucVu.SelectedIndex = 0;
            rdbtnNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Today;
            LoadNhanVien();
            txtMaNhanVien.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHoVaTen.Text == "")
                {
                    throw new Exception("Họ Và Tên trống!");
                }
                else
                {
                    if (txtDiaChi.Text == "")
                    {
                        throw new Exception("Địa Chỉ trống!");
                    }
                    else
                    {
                        if (txtSoDienThoai.Text == "")
                        {
                            throw new Exception("Số Điện Thoại trống!");
                        }
                        else
                        {
                            if (txtTaiKhoan.Text == "")
                            {
                                throw new Exception("Tài Khoản trống!");
                            }
                            else
                            {
                                if (txtMatKhau.Text == "")
                                {
                                    throw new Exception("Mật Khẩu trống!");
                                }
                                else
                                {
                                    string gioitinh = "";
                                    if (rdbtnNam.Checked == true)
                                    {
                                        gioitinh = "Nam";
                                    }
                                    if (rdbtnNu.Checked == true)
                                    {
                                        gioitinh = "Nu";
                                    }
                                    DialogResult result = MessageBox.Show("Bạn có chắc chắn sửa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (result == DialogResult.Yes)
                                    {
                                        string sql1 = "UPDATE NhanVien SET TenNhanVien=N'" + txtHoVaTen.Text + "',GioiTinh=N'" + gioitinh + "',NgaySinh=N'" + dtpNgaySinh.Text + "',DiaChi=N'" + txtDiaChi.Text + "',SoDienThoai=N'" + txtSoDienThoai.Text + "',ChucVu=N'" + cbbChucVu.Text + "' WHERE MaNhanVien=N'" + txtMaNhanVien.Text + "'";
                                        string sql2 = "UPDATE Account SET TaiKhoan=N'" + txtTaiKhoan.Text + "',MatKhau=N'" + txtMatKhau.Text + "' WHERE MaNhanVien=N'" + txtMaNhanVien.Text + "'";
                                        kn.setData(sql1);
                                        kn.setData(sql2);
                                        txtDiaChi.Text = "";
                                        txtHoVaTen.Text = "";
                                        txtMaNhanVien.Text = "";
                                        txtMaNV.Text = "";
                                        txtMatKhau.Text = "";
                                        txtSoDienThoai.Text = "";
                                        txtTaiKhoan.Text = "";
                                        cbbChucVu.SelectedIndex = 0;
                                        LoadNhanVien();
                                        txtMaNhanVien.ReadOnly = false;
                                        dtpNgaySinh.Value = DateTime.Today;
                                        MessageBox.Show("Sửa thành công!");
                                    }   
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string sql1 = "DELETE FROM NhanVien WHERE MaNhanVien=N'" + txtMaNhanVien.Text + "'";
                    string sql2 = "DELETE FROM Account WHERE MaNhanVien=N'" + txtMaNhanVien.Text + "'";
                    kn.setData(sql2);
                    kn.setData(sql1);
                    txtDiaChi.Text = "";
                    txtHoVaTen.Text = "";
                    txtMaNhanVien.Text = "";
                    txtMaNV.Text = "";
                    txtMatKhau.Text = "";
                    txtSoDienThoai.Text = "";
                    txtTaiKhoan.Text = "";
                    cbbChucVu.SelectedIndex = 0;
                    LoadNhanVien();
                    txtMaNhanVien.ReadOnly = false;
                    dtpNgaySinh.Value = DateTime.Today;
                    MessageBox.Show("Xóa thành công!");
                }   
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
            }
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sqlNhanVien = "SELECT NV.MaNhanVien,TenNhanVien,NgaySinh,GioiTinh,DiaChi,SoDienThoai,ChucVu,TaiKhoan,MatKhau FROM NhanVien NV, Account A WHERE NV.MaNhanVien=A.MaNhanVien AND NV.MaNhanVien=N'" + txtMaNV.Text + "'";
            DataTable dtNhanVien = kn.getData(sqlNhanVien);
            dgvNhanVien.DataSource = dtNhanVien;   
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
