using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLBH
{
    public partial class frmXuat : Form
    {
        public frmXuat()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn = null;
        string Strconn = @"Data Source=HUYNGUYEN\SQLEXPRESS;Initial Catalog=_QLBH;Integrated Security=True";
        private string StrConn;
        private void frmXuat_Load(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT dbo.ChiTietPhieuXuat.MaCTPX,dbo.ChiTietPhieuXuat.MaHH,dbo.ChiTietPhieuXuat.MaKH,dbo.ChiTietPhieuXuat.Counts,dbo.ChiTietPhieuXuat.GhiChu,dbo.PhieuXuat.NgayXuat 
		                            FROM dbo.ChiTietPhieuXuat,dbo.PhieuXuat 
		                            WHERE dbo.ChiTietPhieuXuat.MaPX=dbo.PhieuXuat.MaPX";
            command.Connection = conn;
            lvxuat.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvi.SubItems.Add(reader[0].ToString());
                lvxuat.Items.Add(lvi);
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"EXEC dbo.Xuat @mahh,
                                    @SL ,
                                    @ghichu ,
                                    @makh,
                                    @ngayxuat";
            command.Parameters.Add("@mahh", SqlDbType.NVarChar).Value = txtmahh.Text;
            command.Parameters.Add("@SL", SqlDbType.Int).Value = txtsl.Text;
            command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = txtghichu.Text;
            command.Parameters.Add("@makh", SqlDbType.Int).Value = txtmakh.Text;
            command.Parameters.Add("@ngayxuat", SqlDbType.Date).Value = dtngayxuat.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
    }
}
