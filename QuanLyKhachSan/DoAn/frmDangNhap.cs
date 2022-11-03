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
    public partial class frmDangNhap : Form
    {
        KetNoi kn = new KetNoi();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT * FROM NhanVien NV, Account A WHERE A.TaiKhoan=N'" + txtAccount.Text + "' AND A.MaNhanVien=NV.MaNhanVien";
                DataTable dtUser = kn.getData(sql);
                NhanVien user = new NhanVien();
                Account acc = new Account();
                foreach (DataRow row in dtUser.Rows)
                {
                    user.MaNhanVien = row["MaNhanVien"].ToString();
                    user.TenNhanVien = row["TenNhanVien"].ToString();
                    user.DiaChi = row["DiaChi"].ToString();
                    user.SoDienThoai = row["SoDienThoai"].ToString();
                    user.ChucVu = row["ChucVu"].ToString();
                    acc.TaiKhoan = row["TaiKhoan"].ToString();
                    acc.MatKhau = row["MatKhau"].ToString();
                }
                if (txtPassword.Text == acc.MatKhau)
                {
                    
                    DialogResult result = MessageBox.Show("Đăng Nhập Thành Công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (result == DialogResult.OK)
                    {                      
                        frmMain frm = new frmMain(user);
                        this.Visible = false;
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);                 
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void cbHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThiMatKhau.Checked)
            {
                txtAccount.PasswordChar = '\0';
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtAccount.PasswordChar = '\0';
                txtPassword.PasswordChar = '*';
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            NhanVien user = new NhanVien();
            user.MaNhanVien = "";
            user.TenNhanVien = "";
            user.DiaChi = "";
            user.SoDienThoai = "";
            user.ChucVu = "";
            frmMain frm = new frmMain(user);
            this.Visible = false;
            frm.ShowDialog();
        }
    }
}
