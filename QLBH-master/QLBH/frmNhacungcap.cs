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
    public partial class frmNhacungcap : Form
    {
        public frmNhacungcap()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        string Strconn = @"Data Source=HUYNGUYEN\SQLEXPRESS;Initial Catalog=_QLBH;Integrated Security=True";
        private string StrConn;
        private void button1_Click(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"INSERT INTO dbo.NhaCC
                                  ( TenNCC, DiaChi, SDT, Email )
                          VALUES  ( @tennhacc,
                                    @diachi,
                                    @sdt,
                                    @email
                                    )";
            command.Parameters.Add("@tennhacc", SqlDbType.NVarChar).Value = txtten.Text;
            command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = txtdiachi.Text;
            command.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = txtsdt.Text;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = txtemail.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            txtmancc.Clear(); txtten.Clear(); txtsdt.Clear(); txtemail.Clear(); txtdiachi.Clear();
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * from dbo.NhaCC";
            command.Connection = conn;
            lvnhacc.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvnhacc.Items.Add(lvi);
            }
            reader.Close();
        }
        private void frmNhacungcap_Load(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * from dbo.NhaCC";
            command.Connection = conn;
            lvnhacc.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvnhacc.Items.Add(lvi);
            }
            reader.Close();
        }

        private void lvnhacc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvnhacc.SelectedItems.Count == 0) return;
            ListViewItem lvi = lvnhacc.SelectedItems[0];
            txtmancc.Text = lvi.SubItems[0].Text;
            txtten.Text = lvi.SubItems[1].Text;
            txtdiachi.Text = lvi.SubItems[2].Text;
            txtsdt.Text = lvi.SubItems[3].Text;
            txtemail.Text = lvi.SubItems[4].Text;
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
            command.CommandText = @"DELETE dbo.NhaCC WHERE MaNCC=@manhacc";
            command.Parameters.Add("@manhacc", SqlDbType.Int).Value = txtmancc.Text;
            int ret = command.ExecuteNonQuery();
            if (ret > 0)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            txtmancc.Clear(); txtten.Clear(); txtsdt.Clear(); txtemail.Clear(); txtdiachi.Clear();
            if (conn == null)
                conn = new SqlConnection(Strconn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = @"SELECT * from dbo.NhaCC";
            command.Connection = conn;
            lvnhacc.Items.Clear();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem(reader[0].ToString());
                lvi.SubItems.Add(reader[1].ToString());
                lvi.SubItems.Add(reader[2].ToString());
                lvi.SubItems.Add(reader[3].ToString());
                lvi.SubItems.Add(reader[4].ToString());
                lvnhacc.Items.Add(lvi);
            }
            reader.Close();
        }
    }
}
