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
    public partial class frmNhap : Form
    {
        public frmNhap()
        {
            InitializeComponent();
            txtCTPN.ForeColor = Color.LightGray;
            txtCTPN.Text = "Nhập Mã CTPN";
            this.txtCTPN.Leave += new System.EventHandler(this.textBox1_Leave);
            this.txtCTPN.Enter += new System.EventHandler(this.textBox1_Enter);
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtCTPN.Text == "")
            {
                txtCTPN.Text = "Nhập Mã CTPN";
                txtCTPN.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtCTPN.Text == "Nhập Mã CTPN")
            {
                txtCTPN.Text = "";
                txtCTPN.ForeColor = Color.Black;
            }
        }
        SqlConnection conn = null;
        string Strconn = @"Data Source=HUYNGUYEN\SQLEXPRESS;Initial Catalog=_QLBH;Integrated Security=True";
        private string StrConn;
        private void frmNhap_Load(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT dbo.ChiTietPhieuNhap.MaCTPN,dbo.ChiTietPhieuNhap.MaHH,dbo.ChiTietPhieuNhap.Counts,dbo.ChiTietPhieuNhap.Gianhap,dbo.ChiTietPhieuNhap.GhiChu,dbo.ChiTietPhieuNhap.MaNV,dbo.ChiTietPhieuNhap.Giaxuat,dbo.PhieuNhap.NgayNhap
                                    FROM dbo.ChiTietPhieuNhap,dbo.PhieuNhap
                                    WHERE ChiTietPhieuNhap.MaPN=PhieuNhap.MaPN";
            command.Connection = conn;
            lvnhap.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvi.SubItems.Add(reader[5].ToString());
                lvi.SubItems.Add(reader[7].ToString());
                lvi.SubItems.Add(reader[6].ToString());
                lvi.SubItems.Add(reader[0].ToString());
                lvnhap.Items.Add(lvi);
            }
            reader.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            command.CommandText = "EXEC dbo.Nhap @mahh,@SL,@gianhap,@giaxuat,@ghichu,@manv,@ngaynhap";
            command.Parameters.Add("@mahh",SqlDbType.NVarChar).Value=txtmahh.Text;
            command.Parameters.Add("@SL", SqlDbType.Int).Value = txtsl.Text;
            command.Parameters.Add("@gianhap", SqlDbType.Float).Value = txtgianhap.Text;
            command.Parameters.Add("@giaxuat", SqlDbType.Float).Value = txtgiaban.Text;
            command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = txtghichu.Text;
            command.Parameters.Add("@manv", SqlDbType.NVarChar).Value = txtmanv.Text;
            command.Parameters.Add("@ngaynhap", SqlDbType.Date).Value = datenhap.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Nhập thành công");
            }
            else
            {
                MessageBox.Show("Nhập thất bại");
            }
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT dbo.ChiTietPhieuNhap.MaCTPN,dbo.ChiTietPhieuNhap.MaHH,dbo.ChiTietPhieuNhap.Counts,dbo.ChiTietPhieuNhap.Gianhap,dbo.ChiTietPhieuNhap.GhiChu,dbo.ChiTietPhieuNhap.MaNV,dbo.ChiTietPhieuNhap.Giaxuat,dbo.PhieuNhap.NgayNhap
                                    FROM dbo.ChiTietPhieuNhap,dbo.PhieuNhap
                                    WHERE ChiTietPhieuNhap.MaPN=PhieuNhap.MaPN";
            command.Connection = conn;
            lvnhap.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvi.SubItems.Add(reader[5].ToString());
                lvi.SubItems.Add(reader[7].ToString());
                lvi.SubItems.Add(reader[6].ToString());
                lvi.SubItems.Add(reader[0].ToString());
                lvnhap.Items.Add(lvi);
            }
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "EXEC dbo.Xoanhap @maCTPN";
            command.Parameters.Add("@maCTPN", SqlDbType.Int).Value = txtCTPN.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT dbo.ChiTietPhieuNhap.MaCTPN,dbo.ChiTietPhieuNhap.MaHH,dbo.ChiTietPhieuNhap.Counts,dbo.ChiTietPhieuNhap.Gianhap,dbo.ChiTietPhieuNhap.GhiChu,dbo.ChiTietPhieuNhap.MaNV,dbo.ChiTietPhieuNhap.Giaxuat,dbo.PhieuNhap.NgayNhap
                                    FROM dbo.ChiTietPhieuNhap,dbo.PhieuNhap
                                    WHERE ChiTietPhieuNhap.MaPN=PhieuNhap.MaPN";
            command.Connection = conn;
            lvnhap.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvi.SubItems.Add(reader[5].ToString());
                lvi.SubItems.Add(reader[7].ToString());
                lvi.SubItems.Add(reader[6].ToString());
                lvi.SubItems.Add(reader[0].ToString());
                lvnhap.Items.Add(lvi);
            }
            reader.Close();
        }

        private void lvnhap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvnhap.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvnhap.SelectedItems[0];
            txtmahh.Text = lvi.SubItems[0].Text;
            txtsl.Text = lvi.SubItems[1].Text;
            txtgianhap.Text = lvi.SubItems[2].Text;
            txtghichu.Text = lvi.SubItems[3].Text;
            txtgiaban.Text = lvi.SubItems[6].Text;
            txtmanv.Text = lvi.SubItems[4].Text;
            datenhap.Text=lvi.SubItems[5].Text;
            txtCTPN.Text = lvi.SubItems[7].Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(StrConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            string sql = "EXEC dbo.updatenhap @mahh,@SL,@gianhap,@giaban,@manv,@ngaynhap,@ghichu,@maCTPN";
            command.CommandText = sql;
            command.Connection = conn;
            command.Parameters.Add("@mahh", SqlDbType.NVarChar).Value = txtmahh.Text;
            command.Parameters.Add("@SL", SqlDbType.Int).Value = txtsl.Text;
            command.Parameters.Add("@gianhap", SqlDbType.Float).Value = txtgianhap.Text;
            command.Parameters.Add("@giaban", SqlDbType.Float).Value = txtgiaban.Text;
            command.Parameters.Add("@manv", SqlDbType.NVarChar).Value = txtmanv.Text;
            command.Parameters.Add("@ngaynhap", SqlDbType.Date).Value = datenhap.Text;
            command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = txtghichu.Text;
            command.Parameters.Add("@maCTPN", SqlDbType.Int).Value = txtCTPN.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT dbo.ChiTietPhieuNhap.MaCTPN,dbo.ChiTietPhieuNhap.MaHH,dbo.ChiTietPhieuNhap.Counts,dbo.ChiTietPhieuNhap.Gianhap,dbo.ChiTietPhieuNhap.GhiChu,dbo.ChiTietPhieuNhap.MaNV,dbo.ChiTietPhieuNhap.Giaxuat,dbo.PhieuNhap.NgayNhap
                                    FROM dbo.ChiTietPhieuNhap,dbo.PhieuNhap
                                    WHERE ChiTietPhieuNhap.MaPN=PhieuNhap.MaPN";
            command.Connection = conn;
            lvnhap.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvi.SubItems.Add(reader[5].ToString());
                lvi.SubItems.Add(reader[7].ToString());
                lvi.SubItems.Add(reader[6].ToString());
                lvi.SubItems.Add(reader[0].ToString());
                lvnhap.Items.Add(lvi);
            }
            reader.Close();
        }

        private void txtCTPN_TextChanged(object sender, EventArgs e)
        {
            
        }
        
    }
}
