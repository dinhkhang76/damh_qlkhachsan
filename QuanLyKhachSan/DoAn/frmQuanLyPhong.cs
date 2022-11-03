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
    public partial class frmQuanLyPhong : Form
    {
        int hang_chon = -1;
        KetNoi kn = new KetNoi();
        public frmQuanLyPhong()
        {
            InitializeComponent();
        }

        private void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            loadQuanLyPhong();
            loadLoaiPhong();
            cbbTinhTrang.SelectedIndex = 0;
            dgvQuanLyPhong.ReadOnly = true;
        }

        public void loadQuanLyPhong()
        {
            String sqlPhong = "SELECT MaPhong,TenPhong,TenLoai,TinhTrang FROM LoaiPhong LP, Phong P WHERE P.MaLoai=LP.MaLoai";
            DataTable dtPhong = kn.getData(sqlPhong);
            dgvQuanLyPhong.DataSource = dtPhong; 
        }

        public void loadLoaiPhong()
        {
            String sqlKhoa = "SELECT * FROM LoaiPhong";
            DataTable dlkhoa = kn.getData(sqlKhoa);
            cbbLoaiPhong.DataSource = dlkhoa;
            cbbLoaiPhong.DisplayMember = "TenLoai";
            cbbLoaiPhong.ValueMember = "MaLoai";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaPhong.Text == ""||txtTenPhong.Text == "")
                {
                    throw new Exception("Mã Phòng Không được để trống");
                }
                else
                {
                    string maloai = cbbLoaiPhong.SelectedValue.ToString();
                    string sql = "INSERT INTO Phong(MaPhong,TenPhong,MaLoai,TinhTrang) VALUES(N'" + txtMaPhong.Text + "',N'" + txtTenPhong.Text + "',N'" + maloai + "',N'" + cbbTinhTrang.Text + "')";
                    kn.setData(sql);
                    txtTenPhong.Text = "";
                    txtMaPhong.Text = "";
                    cbbTinhTrang.SelectedIndex = 0;
                    cbbLoaiPhong.SelectedIndex = 0;
                    loadQuanLyPhong();
                    throw new Exception("Thêm thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
            }
        }

        private void dgvQuanLyPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                hang_chon = e.RowIndex;
                if (hang_chon < dgvQuanLyPhong.Rows.Count)
                {
                    txtMaPhong.Text = dgvQuanLyPhong.Rows[hang_chon].Cells["MaPhong"].Value.ToString();
                    txtTenPhong.Text = dgvQuanLyPhong.Rows[hang_chon].Cells["TenPhong"].Value.ToString();
                    string loaiphong = dgvQuanLyPhong.Rows[hang_chon].Cells["TenLoai"].Value.ToString();
                    string sql = "SELECT * FROM LoaiPhong WHERE TenLoai=N'" + loaiphong + "'";
                    DataTable dsLoaiPhong = kn.getData(sql);
                    cbbLoaiPhong.SelectedValue = dsLoaiPhong.Rows[0]["MaLoai"].ToString();
                    cbbTinhTrang.Text = dgvQuanLyPhong.Rows[hang_chon].Cells["MaPhong"].Value.ToString();
                    txtMaPhong.Enabled = false;
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
                DialogResult result = MessageBox.Show("Bạn có chắc chắn sửa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string maloai = cbbLoaiPhong.SelectedValue.ToString();
                    string sql = "UPDATE Phong Set TenPhong=N'" + txtTenPhong.Text + "',MaLoai=N'" + maloai + "',TinhTrang=N'" + cbbTinhTrang.Text + "' WHERE MaPhong=N'" + txtMaPhong.Text + "'";
                    kn.setData(sql);
                    txtTenPhong.Text = "";
                    txtMaPhong.Text = "";
                    cbbTinhTrang.SelectedIndex = 0;
                    cbbLoaiPhong.SelectedIndex = 0;
                    loadQuanLyPhong();
                    txtMaPhong.Enabled = true;
                    MessageBox.Show("Sửa thành công!");
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
                    string maphong = txtMaPhong.Text;
                    string sql = "DELETE FROM Phong WHERE MaPhong=N'" + maphong + "'";
                    kn.setData(sql);
                    txtTenPhong.Text = "";
                    txtMaPhong.Text = "";
                    cbbTinhTrang.SelectedIndex = 0;
                    cbbLoaiPhong.SelectedIndex = 0;
                    loadQuanLyPhong();
                    txtMaPhong.Enabled = true;
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaPhong.Text == "")
                {
                    throw new Exception("Mã Phòng trống!");
                }
                else
                {
                    String sqlPhong = "SELECT MaPhong,TenPhong,TenLoai,TinhTrang FROM LoaiPhong LP, Phong P WHERE P.MaLoai=LP.MaLoai AND MaPhong=N'"+txtMaPhong.Text+"'";
                    DataTable dtPhong = kn.getData(sqlPhong);
                    dgvQuanLyPhong.DataSource = dtPhong; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
            }
        }

    }
}
