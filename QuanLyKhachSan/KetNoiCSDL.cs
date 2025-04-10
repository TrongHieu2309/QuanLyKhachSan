using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public class KetNoiCSDL
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataSet ds;

        public KetNoiCSDL()
        {
            string str = "Data Source=ADMINH2;Initial Catalog=db_QuanLyKhachSan;Integrated Security=True;Encrypt=False";
            conn = new SqlConnection(str);
        }

        private void OpenConnection()
        {
            if (ConnectionState.Closed == conn.State)
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void CloseConnection()
        {
            if (ConnectionState.Open == conn.State)
            {
                try
                {
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        public DataTable Execute(string query)
        {
            DataTable dt = new DataTable();
            OpenConnection();

            try
            {
                adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public int ExecuteNonQuery(string query)
        {
            int rowsAffected = 0;
            OpenConnection();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi query: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return rowsAffected;
        }

        public object ExecuteScalar(string query)
        {
            object result = null;
            OpenConnection();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                result = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            int rowsAffected = 0;
            OpenConnection();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return rowsAffected;
        }

        public DataTable GetLogin(string query, string user, string pass)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Username", user);
                    cmd.Parameters.AddWithValue("@Pass", pass);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Thông báo");
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public DataTable Execute(string query, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            OpenConnection();

            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = query;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public int GetRegister(string query, string user, string pass)
        {
            return ExecuteNonQuery(query,
                new SqlParameter("@User", user),
                new SqlParameter("@Pass", pass));
        }
    }
}
