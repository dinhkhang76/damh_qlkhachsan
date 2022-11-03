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
    public partial class frmDichVu : Form
    {
        string makhachhang = "";
        string tenkhachhang = "";
        string madichvu = "";
        DateTime ngay = DateTime.Today;
        float dongia;
        int hang_chon = -1;
        int mt;
        KetNoi kn = new KetNoi();
        public frmDichVu()
        {
            InitializeComponent();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            LoadDichVu();
            cbbLoaiDichVu.SelectedIndex = 0;
        }

        public void LoadDichVu()
        {
            string sqlDV = "SELECT LoaiDichVu FROM DichVu GROUP BY LoaiDichVu";
            DataTable dtDV = kn.getData(sqlDV);
            cbbLoaiDichVu.DataSource = dtDV;
            cbbLoaiDichVu.DisplayMember = "LoaiDichVu";
        }

        public void loadMaKhachHang()
        {
            string sqlDV = "SELECT TenDichVu, Ngay, SoLuong, SDDV.DonGia From DichVu DV, SuDungDichVu SDDV WHERE DV.MaDichVu=SDDV.MaDichVu AND MaKhachHang=" + int.Parse(makhachhang) + "";
            DataTable dtDV = kn.getData(sqlDV);
            dgvThongTinSuDungDichVu.DataSource = dtDV;
            lbKhachHang.Text = tenkhachhang;
        }

        private void txtMaThue_MouseClick(object sender, MouseEventArgs e)
        {
            txtMaPhong.Text = "";
        }

        private void txtMaPhong_MouseClick(object sender, MouseEventArgs e)
        {
            txtMaThue.Text = "";
        }

        private void cbbLoaiDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            String sqlDichVu = "SELECT * FROM DichVu WHERE LoaiDichVu=N'" + cbbLoaiDichVu.Text + "'";
            DataTable dtDichVu = kn.getData(sqlDichVu);
            dgvLoaiDichVu.DataSource = dtDichVu;

        }

        private void dgvLoaiDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                hang_chon = e.RowIndex;
                if (hang_chon < dgvLoaiDichVu.Rows.Count)
                {
                    madichvu = dgvLoaiDichVu.Rows[hang_chon].Cells["MaDichVu"].Value.ToString();
                    dongia = float.Parse(dgvLoaiDichVu.Rows[hang_chon].Cells["DonGia1"].Value.ToString());
                }
            }
            catch
            {
            }
            hang_chon = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlThem = "";
                if (makhachhang == "")
                {
                    throw new Exception("Chưa Chọn Khách Hàng!");
                }
                else
                {
                    sqlThem = "INSERT INTO SuDungDichVu(MaKhachHang,MaDichVu,Ngay,SoLuong,DonGia) VALUES(N'" + makhachhang + "',N'" + madichvu + "',N'" + ngay.ToString("yyyy/MM/dd") + "'," + int.Parse(nudSoLuong.Text) + "," + (float.Parse(nudSoLuong.Text) * dongia) + ")";                    
                }
                kn.setData(sqlThem);
                loadMaKhachHang();
                nudSoLuong.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlKhachHang = "";
                if (txtMaPhong.Text == "")
                {
                    if (!int.TryParse(txtMaThue.Text, out mt) || txtMaThue.Text == "")
                    {
                        throw new Exception("Không Tìm Thấy Khách Hàng!");
                    }
                    else
                    {
                        int mathue = int.Parse(txtMaThue.Text);
                        sqlKhachHang = "SELECT TP.MaKhachHang, KH.TenKhachHang FROM KhachHang KH, ThuePhong TP WHERE KH.MaKhachHang=TP.MaKhachHang AND MaThue=" + mathue + "";
                    }
                }
                if (txtMaThue.Text == "")
                {
                    if (txtMaPhong.Text == "")
                    {
                        throw new Exception("Không Tìm Thấy Khách Hàng!");
                    }
                    else
                    {
                        sqlKhachHang = "SELECT TP.MaKhachHang, KH.TenKhachHang FROM KhachHang KH, ThuePhong TP WHERE KH.MaKhachHang=TP.MaKhachHang AND MaPhong=N'" + txtMaPhong.Text + "'";
                    }
                }
                DataTable dtKhachHang = kn.getData(sqlKhachHang);
                if (dtKhachHang.Rows.Count > 0)
                {
                    foreach (DataRow row in dtKhachHang.Rows)
                    {
                        makhachhang = row["MaKhachHang"].ToString();
                        tenkhachhang = row["TenKhachHang"].ToString();
                    }
                    loadMaKhachHang();
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
