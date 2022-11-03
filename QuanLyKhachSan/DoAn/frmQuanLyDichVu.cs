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
    public partial class frmQuanLyDichVu : Form
    {
        int hang_chon = -1;
        float dg;
        KetNoi kn = new KetNoi();
        public frmQuanLyDichVu()
        {
            InitializeComponent();
        }
        public void loadDichVu()
        {
            String sqlDichVu = "SELECT * FROM DichVu";
            DataTable dtDichVu = kn.getData(sqlDichVu);
            dgvDichVu.DataSource = dtDichVu;
        }

        private void frmQuanLyDichVu_Load(object sender, EventArgs e)
        {
            loadDichVu();
            dgvDichVu.ReadOnly = true;
            cbbLoaiDichVu.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaDichVu.Text == ""||cbbLoaiDichVu.Text == ""||txtTenDichVu.Text == ""||txtDonGia.Text == "")
                {
                    throw new Exception("Không được để trống!");
                }
                else
                {
                    if (!float.TryParse(txtDonGia.Text, out dg))
                    {
                        throw new Exception("Đơn giá phải là số!");
                    }
                    else
                    {
                        string madichvu = txtMaDichVu.Text.Trim();
                        string loaidichvu = cbbLoaiDichVu.Text.Trim();
                        string tendichvu = txtTenDichVu.Text.Trim();
                        float dongia = float.Parse(txtDonGia.Text.Trim());
                        string sql = "INSERT INTO DichVu(MaDichVu,LoaiDichVu,TenDichVu,DonGia) VALUES(N'" + madichvu + "',N'" + loaidichvu + "',N'" + tendichvu + "','" + dongia + "')";
                        kn.setData(sql);
                        loadDichVu();
                        txtMaDichVu.Text = "";
                        txtTenDichVu.Text = "";
                        txtDonGia.Text = "";
                        cbbLoaiDichVu.SelectedIndex = 0;
                        hang_chon = -1;
                        throw new Exception("Thêm thành công!");

                    }                
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
            }
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                hang_chon = e.RowIndex;
                if (hang_chon < dgvDichVu.Rows.Count)
                {
                    txtMaDichVu.Text = dgvDichVu.Rows[hang_chon].Cells["MaDichVu"].Value.ToString();
                    cbbLoaiDichVu.Text = dgvDichVu.Rows[hang_chon].Cells["LoaiDichVu"].Value.ToString();
                    txtTenDichVu.Text = dgvDichVu.Rows[hang_chon].Cells["TenDichVu"].Value.ToString();
                    txtDonGia.Text = dgvDichVu.Rows[hang_chon].Cells["DonGia"].Value.ToString();
                    txtMaDichVu.ReadOnly = true;
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
                if (txtMaDichVu.Text == "" || cbbLoaiDichVu.Text == "" || txtTenDichVu.Text == "" || txtDonGia.Text == "")
                {
                    throw new Exception("Không được để trống!");
                }
                else
                {
                    if (!float.TryParse(txtDonGia.Text, out dg))
                    {
                        throw new Exception("Đơn giá phải là số!");
                    }
                    else
                    {
                        string madichvu = txtMaDichVu.Text.Trim();
                        string loaidichvu = cbbLoaiDichVu.Text.Trim();
                        string tendichvu = txtTenDichVu.Text.Trim();
                        float dongia = float.Parse(txtDonGia.Text.Trim());
                        string sql = "UPDATE DichVu SET LoaiDichVu=N'" + loaidichvu + "', TenDichVu=N'" + tendichvu + "', DonGia='" + dongia + "' WHERE MaDichVu=N'" + madichvu + "'";
                        kn.setData(sql);
                        loadDichVu();
                        txtMaDichVu.ReadOnly = false;
                        txtMaDichVu.Text = "";
                        txtTenDichVu.Text = "";
                        txtDonGia.Text = "";
                        cbbLoaiDichVu.SelectedIndex = 0;
                        hang_chon = -1;
                        throw new Exception("Sửa thành công!");
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
            DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string madichvu = txtMaDichVu.Text.Trim();
                string sql = "DELETE FROM DichVu WHERE MaDichVu=N'" + madichvu + "'";
                kn.setData(sql);
                loadDichVu();
                txtMaDichVu.ReadOnly = false;
                txtMaDichVu.Text = "";
                txtTenDichVu.Text = "";
                txtDonGia.Text = "";
                cbbLoaiDichVu.SelectedIndex = 0;
                hang_chon = -1;
                MessageBox.Show("Xóa thành công!");
            }
        }

        private void btnXuatDSDV_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"C:\Users\VTP\Desktop\DanhSachDichVu.txt");
            string txtDSDV = "";
            writer.Write("--------------------------Danh Sách Dịch Vụ---------------------\n\n");
            writer.Write("|Mã DV  |Loại Dịch Vụ    |Tên Dịch Vụ             |  Đơn giá  |\n\n");
            for (int i = 0; i < dgvDichVu.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvDichVu.Columns.Count; j++)
                {
                    txtDSDV += dgvDichVu.Rows[i].Cells[j].Value.ToString() + "\t";
                }
                txtDSDV += "\n\n";
            }
            writer.Write(txtDSDV);
            writer.Close();
            MessageBox.Show("Xuất danh sách dịch vụ thành công");
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
