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
    public partial class frmQuanLyKhachHang : Form
    {
        string ma = "";
        int hang_chon = -1;
        KetNoi kn = new KetNoi();
        public frmQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            loadKhachHang();
            dgvDanhSachKhachHang.ReadOnly = true;
        }

        public void loadKhachHang()
        {
            String sqlKhachHang = "SELECT * FROM KhachHang";
            DataTable dtKhachHang = kn.getData(sqlKhachHang);
            dgvDanhSachKhachHang.DataSource = dtKhachHang;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoCMND.Text.Trim() != "")
                {
                    string cmnd = txtSoCMND.Text;
                    string sql = "SELECT * FROM KhachHang WHERE CMND=N'" + cmnd + "'";
                    DataTable dtKhachHang = kn.getData(sql);
                    dgvDanhSachKhachHang.DataSource = dtKhachHang;
                    if (dtKhachHang.Rows.Count == 0)
                    {
                        throw new Exception("Không Tìm Thấy!");
                    }
                    else
                    {
                        foreach (DataRow row in dtKhachHang.Rows)
                        {
                            txtHoTen.Text = row["TenKhachHang"].ToString();
                            txtDiaChi.Text = row["DiaChi"].ToString();
                            txtSoDienThoai.Text = row["SoDienThoai"].ToString();
                        }
                    }                   
                }
                else
                {
                    throw new Exception("Chưa nhập số CMND");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtSoCMND.Text = "";
            loadKhachHang();
        }

        private void dgvDanhSachKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                hang_chon = e.RowIndex;
                if (hang_chon < dgvDanhSachKhachHang.Rows.Count)
                {
                    txtSoCMND.Text = dgvDanhSachKhachHang.Rows[hang_chon].Cells["CMND"].Value.ToString();
                    txtHoTen.Text = dgvDanhSachKhachHang.Rows[hang_chon].Cells["TenKhachHang"].Value.ToString();
                    txtDiaChi.Text = dgvDanhSachKhachHang.Rows[hang_chon].Cells["DiaChi"].Value.ToString();
                    txtSoDienThoai.Text = dgvDanhSachKhachHang.Rows[hang_chon].Cells["SoDienThoai"].Value.ToString();
                    ma = dgvDanhSachKhachHang.Rows[hang_chon].Cells["MaKhachHang"].Value.ToString();
                }         
            }
            catch
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (ma == "")
                {
                    throw new Exception("Vui lòng chọn khách hàng!");
                }
                else
                {
                    if (txtSoCMND.Text == "")
                    {
                        throw new Exception("Số CMND không được để trống!");
                    }
                    else
                    {
                        if (txtHoTen.Text == "")
                        {
                            throw new Exception("Họ Tên không được để trống!");
                        }
                        else
                        {
                            if (txtDiaChi.Text == "")
                            {
                                throw new Exception("Địa Chỉ không được để trống!");
                            }
                            else
                            {
                                if (txtSoDienThoai.Text == "")
                                {
                                    throw new Exception("Số Điện Thoại không được để trống!");
                                }
                                else
                                {
                                    DialogResult result = MessageBox.Show("Bạn có chắc chắn sửa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    if (result == DialogResult.Yes)
                                    {
                                        int makh = int.Parse(ma);
                                        string sql = "UPDATE KhachHang SET TenKhachHang=N'" + txtHoTen.Text + "',CMND=N'" + txtSoCMND.Text + "',DiaChi=N'" + txtDiaChi.Text + "',SoDienThoai=N'" + txtSoDienThoai.Text + "' WHERE MaKhachHang='" + makh + "'";
                                        kn.setData(sql);
                                        loadKhachHang();
                                        ma = "";
                                        txtSoDienThoai.Text = "";
                                        txtSoCMND.Text = "";
                                        txtHoTen.Text = "";
                                        txtDiaChi.Text = "";
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
                    int makh = int.Parse(ma);
                    string sql1 = "DELETE FROM KhachHang WHERE MaKhachHang='" + makh + "'";
                    string sql2 = "DELETE FROM ThuePhong WHERE MaKhachHang='" + makh + "'";
                    string sql3 = "DELETE FROM SuDungDichVu WHERE MaKhachHang='" + makh + "'";
                    kn.setData(sql3);
                    kn.setData(sql2);
                    kn.setData(sql1);      
                    loadKhachHang();
                    ma = "";
                    txtSoDienThoai.Text = "";
                    txtSoCMND.Text = "";
                    txtHoTen.Text = "";
                    txtDiaChi.Text = "";
                    throw new Exception("Xóa thành công!");
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
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
    }
}
