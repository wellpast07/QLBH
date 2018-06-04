using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        string connection = @"Data Source=HUYNGUYEN\SQLEXPRESS;Initial Catalog=_QLBH;Integrated Security=True";

        internal static DataProvider Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private DataProvider() { }
        public DataTable ExcuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection con = new SqlConnection(connection))
            {         
              con.Open();

              SqlCommand command = new SqlCommand(query, con);

                if (parameter != null)
                 {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                  }

             SqlDataAdapter adapter = new SqlDataAdapter(command);

             adapter.Fill(data);

             con.Close();
            }
           
            return data;
        }

        public int ExcuteNonQuery(string query,object[] parameter = null)
        {
            int data = 0;
            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                SqlCommand command = new SqlCommand(query,con);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();

                con.Close();
            }
            return data;
        }

        public object ExcuteScalar(string query,object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                SqlCommand command = new SqlCommand(query,con);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                con.Close();
            }

            return data;
        }
    }
}
