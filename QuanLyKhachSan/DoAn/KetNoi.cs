using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    class KetNoi
    {
        SqlConnection conn = null;
        public KetNoi()
        {
            string strConnect = @"Data Source=DINHKHANG\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";
            conn = new SqlConnection(strConnect);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public DataTable getData(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter apt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            apt.Fill(dt);
            return dt;
        }
        public void setData(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
