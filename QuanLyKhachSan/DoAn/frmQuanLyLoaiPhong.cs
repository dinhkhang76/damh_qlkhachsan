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
    public partial class frmQuanLyLoaiPhong : Form
    {
        int hang_chon = -1;
        float dg;
        KetNoi kn = new KetNoi();
        public frmQuanLyLoaiPhong()
        {
            InitializeComponent();
        }

        private void frmQuanLyLoaiPhong_Load(object sender, EventArgs e)
        {
            loadLoaiPhong();
            dgvQuanLyLoaiPhong.ReadOnly = true;
        }

        public void loadLoaiPhong()
        {
            String sqlLoaiPhong = "SELECT * FROM LoaiPhong";
            DataTable dtLoaiPhong = kn.getData(sqlLoaiPhong);
            dgvQuanLyLoaiPhong.DataSource = dtLoaiPhong;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaLoai.Text == "")
                {
                    throw new Exception("Mã Loại không được trống!");
                }
                else
                {
                    if (txtTenLoai.Text == "")
                    {
                        throw new Exception("Tên Loại không được trống!");
                    }
                    else
                    {
                        if (txtDonGia.Text == "")
                        {
                            throw new Exception("Đơn Giá không được trống!");
                        }
                        else
                        {
                            if (!float.TryParse(txtDonGia.Text, out dg))
                            {
                                throw new Exception("Đơn Giá không phải là số");
                            }
                            else
                            {
                                string maloai = txtMaLoai.Text;
                                string tenloai = txtTenLoai.Text;
                                float dongia = float.Parse(txtDonGia.Text);
                                int songuoichuan = int.Parse(nudSoNguoiChuan.Value.ToString());
                                int songuoitoida = int.Parse(nudSoNguoiToiDa.Value.ToString());
                                string ghichu = txtGhiChu.Text;
                                string sql = "INSERT INTO LoaiPhong(MaLoai,TenLoai,SoNguoiChuan,SoNguoiToiDa,DonGia,GhiChu) VALUES(N'" + maloai + "',N'" + tenloai + "','" + songuoichuan + "','" + songuoitoida + "','" + dongia + "',N'" + ghichu + "')";
                                kn.setData(sql);
                                loadLoaiPhong();
                                txtDonGia.Text = "";
                                txtMaLoai.Text = "";
                                txtTenLoai.Text = "";
                                nudSoNguoiChuan.Value = 1;
                                nudSoNguoiToiDa.Value = 1;
                                txtGhiChu.Text = "";
                                throw new Exception("Thêm thành công!");
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

        private void dgvQuanLyLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {  
                hang_chon = e.RowIndex;
                if (hang_chon < dgvQuanLyLoaiPhong.Rows.Count)
                {
                    txtMaLoai.Text = dgvQuanLyLoaiPhong.Rows[hang_chon].Cells["MaLoai"].Value.ToString();
                    txtTenLoai.Text = dgvQuanLyLoaiPhong.Rows[hang_chon].Cells["TenLoai"].Value.ToString();
                    txtDonGia.Text = dgvQuanLyLoaiPhong.Rows[hang_chon].Cells["DonGia"].Value.ToString();
                    nudSoNguoiChuan.Value = int.Parse(dgvQuanLyLoaiPhong.Rows[hang_chon].Cells["SoNguoiChuan"].Value.ToString());
                    nudSoNguoiToiDa.Value = int.Parse(dgvQuanLyLoaiPhong.Rows[hang_chon].Cells["SoNguoiToiDa"].Value.ToString());
                    txtGhiChu.Text = dgvQuanLyLoaiPhong.Rows[hang_chon].Cells["GhiChu"].Value.ToString();
                    txtMaLoai.ReadOnly = true;
                    btnThem.Enabled = false;
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
                if (txtTenLoai.Text == "")
                {
                    throw new Exception("Tên Loại không được trống!");
                }
                else
                {
                    if (txtDonGia.Text == "")
                    {
                        throw new Exception("Đơn Giá không được trống!");
                    }
                    else
                    {
                        if (!float.TryParse(txtDonGia.Text, out dg))
                        {
                            throw new Exception("Đơn Giá không phải là số");
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Bạn có chắc chắn sửa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                string maloai = txtMaLoai.Text;
                                string tenloai = txtTenLoai.Text;
                                float dongia = float.Parse(txtDonGia.Text);
                                int songuoichuan = int.Parse(nudSoNguoiChuan.Value.ToString());
                                int songuoitoida = int.Parse(nudSoNguoiToiDa.Value.ToString());
                                string ghichu = txtGhiChu.Text;
                                string sql = "UPDATE LoaiPhong SET TenLoai=N'" + tenloai + "',SoNguoiChuan='" + songuoichuan + "',SoNguoiToiDa='" + songuoitoida + "',DonGia='" + dongia + "',GhiChu=N'" + ghichu + "' WHERE MaLoai='" + maloai + "'";
                                kn.setData(sql);
                                loadLoaiPhong();
                                txtDonGia.Text = "";
                                txtMaLoai.Text = "";
                                txtTenLoai.Text = "";
                                nudSoNguoiChuan.Value = 1;
                                nudSoNguoiToiDa.Value = 1;
                                txtGhiChu.Text = "";
                                hang_chon = -1;
                                txtMaLoai.ReadOnly = false;
                                btnThem.Enabled = true;
                                MessageBox.Show("Sửa thành công!");
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
                    string maloai = txtMaLoai.Text;
                    string sql = "DELETE FROM LoaiPhong WHERE MaLoai='" + maloai + "'";
                    kn.setData(sql);
                    loadLoaiPhong();
                    txtDonGia.Text = "";
                    txtMaLoai.Text = "";
                    txtTenLoai.Text = "";
                    nudSoNguoiChuan.Value = 1;
                    nudSoNguoiToiDa.Value = 1;
                    txtGhiChu.Text = "";
                    hang_chon = -1;
                    txtMaLoai.ReadOnly = false;
                    btnThem.Enabled = true; 
                    MessageBox.Show("Xóa thành công!");
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
