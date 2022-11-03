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
    public partial class frmDoanhThu : Form
    {
        KetNoi kn = new KetNoi();
        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            loadDoanhThu();
        }

        private void loadDoanhThu()
        {
            string sql = "SELECT NgayLap, SUM(DatCoc) AS TienDaCoc, SUM(Thu) AS TienThu, SUM(ThanhTien) AS DoanhThu FROM ThanhToan GROUP BY NgayLap";
            DataTable dt = kn.getData(sql);
            dgvDoanhThu.DataSource = dt;
            dgvDoanhThu.Columns[0].DefaultCellStyle.Format = "yyyy/MM/dd";

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"C:\Users\VTP\Desktop\DoanhThu.txt");
            string txtDSHoaDon = "";
            writer.Write("|-------------------------------------------------------------------------------|\n\n");
            for (int i = 0; i < dgvDoanhThu.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvDoanhThu.Columns.Count; j++)
                {
                    txtDSHoaDon += "| " + dgvDoanhThu.Rows[i].Cells[j].Value.ToString() + "\t";
                }
            }
            txtDSHoaDon += "|\n\n|------------------------------------------------------------------------|\n\n";
            writer.Write(txtDSHoaDon);
            writer.Close();
            MessageBox.Show("Xuất doanh thu thành công");
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
