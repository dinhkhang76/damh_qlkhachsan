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
    public partial class frmQuanLyHoaDon : Form
    {
        KetNoi kn = new KetNoi();
        public frmQuanLyHoaDon()
        {
            InitializeComponent();
        }

        private void frmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            loadHoaDon();
        }

        public void loadHoaDon()
        {
            String sqlHD = "SELECT * FROM ThanhToan";
            DataTable dtHD = kn.getData(sqlHD);
            dgvQuanLyHoaDon.DataSource = dtHD;
            dgvQuanLyHoaDon.Columns[4].DefaultCellStyle.Format = "yyyy/MM/dd";
            dgvQuanLyHoaDon.Columns[5].DefaultCellStyle.Format = "yyyy/MM/dd";
            dgvQuanLyHoaDon.Columns[9].DefaultCellStyle.Format = "yyyy/MM/dd";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbTimKiem.Checked == true)
                {
                    if (txtMaKH.Text == "")
                    {
                        throw new Exception("Mã KH trống!");
                    }
                    else
                    {
                        string sql1 = "SELECT * FROM ThanhToan WHERE MaKhachHang='" + txtMaKH.Text + "'";
                        DataTable dt1 = kn.getData(sql1);
                        dgvQuanLyHoaDon.DataSource = dt1;
                    }
                }
                else
                {
                    string sql2 = "SELECT * FROM ThanhToan WHERE NgayLap<=N'" + dtpDen.Text + "' AND NgayLap>=N'" + dtpTu.Text + "'";
                    DataTable dt2 = kn.getData(sql2);
                    dgvQuanLyHoaDon.DataSource = dt2;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo");
            }   
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"C:\Users\VTP\Desktop\DanhSachHoaDon.txt");
            string txtDSHoaDon = "";
            writer.Write("|----------------------------------------------------------------------DANH SÁCH HÓA ĐƠN------------------------------------------------------------------------------------------------|\n\n");
            writer.Write("| MaTT  |MaPhong| MaKH  | TenKhachHang  | NgayVao\t\t| NgayRa\t\t| DatCoc\t| Thu\t        |ThanhTien\t| NgayLap\t\t| NguoiLap\t        |\n\n");
            writer.Write("|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|\n\n");
            for (int i = 0; i < dgvQuanLyHoaDon.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvQuanLyHoaDon.Columns.Count; j++)
                {
                    txtDSHoaDon += "| " + dgvQuanLyHoaDon.Rows[i].Cells[j].Value.ToString() + "\t";
                }
            }
            txtDSHoaDon += "|\n\n|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|\n\n";       
            writer.Write(txtDSHoaDon);
            writer.Close();
            MessageBox.Show("Xuất danh sách hóa đơn thành công");
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
