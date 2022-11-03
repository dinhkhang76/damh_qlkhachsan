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
    public partial class frmDoiMatKhau : Form
    {
        KetNoi kn = new KetNoi();
        string manhanvien;
        public frmDoiMatKhau(string ma)
        {
            InitializeComponent();
            this.manhanvien = ma;
        }
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            string sqllattennhanvien = "SELECT TenNhanVien FROM NhanVien WHERE MaNhanVien=N'" + manhanvien + "'";
            DataTable dtTen = kn.getData(sqllattennhanvien);
            foreach (DataRow row in dtTen.Rows)
            {
                labelAccount.Text = row["TenNhanVien"].ToString();
            }
            txtMatKhauHienTai.PasswordChar = '*';
            txtMatKhauMoi.PasswordChar = '*';
            txtLapLaiMatKhau.PasswordChar = '*';
        }
        private void cbHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThiMatKhau.Checked)
            {
                txtMatKhauHienTai.PasswordChar = '\0';
                txtMatKhauMoi.PasswordChar = '\0';
                txtLapLaiMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhauHienTai.PasswordChar = '*';
                txtMatKhauMoi.PasswordChar = '*';
                txtLapLaiMatKhau.PasswordChar = '*';
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                string sqllaymatkhau = "SELECT MatKhau FROM NhanVien NV, Account A WHERE NV.MaNhanVien=N'" +manhanvien+ "' AND A.MaNhanVien=NV.MaNhanVien";
                DataTable dtUser = kn.getData(sqllaymatkhau);
                Account acc = new Account();
                foreach (DataRow row in dtUser.Rows)
                {
                    acc.MatKhau = row["MatKhau"].ToString();
                }
                if (txtMatKhauHienTai.Text == acc.MatKhau)
                {
                    if (txtMatKhauMoi.Text == "")
                    {
                        throw new Exception("Mật Khẩu Mới Không Được Bỏ Trống");
                    }
                    if (txtMatKhauMoi.Text.Length - 1 < 5)
                    {
                        throw new Exception("Mật Khẩu Mới Không An Toàn");
                    }
                    if (txtMatKhauMoi.Text == txtLapLaiMatKhau.Text)
                    {
                        DialogResult result = MessageBox.Show("Bạn có muốn đổi mật khẩu không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            MessageBox.Show("Đổi Mật Khẩu Thành Công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Visible = false;
                            string sqldoimatkhau = "UPDATE Account SET MatKhau=N'" + txtLapLaiMatKhau.Text + "' WHERE MaNhanVien=N'" + manhanvien + "'";
                            kn.setData(sqldoimatkhau);
                        }  
                    }
                    else 
                    {
                        throw new Exception("Lặp Lại Mật Khẩu Không Đúng");
                    }
                }
                else
                {
                    MessageBox.Show("Mật Khẩu Hiện Tại Không Đúng", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
