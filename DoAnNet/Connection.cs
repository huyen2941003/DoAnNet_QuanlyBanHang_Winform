using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DoAnNet
{
    internal class Connection
    {
        private String constr = @"Data Source=DESKTOP-QMPTM77\SQLEXPRESS;Initial Catalog=SQL_DoanNet;Integrated Security=True";
        private static Connection instance;

        public static Connection Instance
        {
            get { if (instance == null) instance = new Connection(); return Connection.instance; }
            private set { Connection.instance = value; }
        }

        public DataTable ExecuteOuery(string query, object[] parameters = null)
        {
            try
            {
                DataTable data = new DataTable();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    if (parameters != null)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            command.Parameters.AddWithValue($"@param{i}", parameters[i]);
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            try
            {
                DataTable data = new DataTable();
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    if (parameters != null)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            command.Parameters.AddWithValue($"@param{i}", parameters[i]);
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ExecuteNonOuery(string query, object[] parameters = null)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    if (parameters != null)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            command.Parameters.AddWithValue($"@param{i}", parameters[i]);
                        }
                    }
                    data = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameters = null)
        {
            try
            {
                object data = null;
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    if (parameters != null)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            command.Parameters.AddWithValue($"@param{i}", parameters[i]);
                        }
                    }
                    data = command.ExecuteScalar();
                    conn.Close();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
