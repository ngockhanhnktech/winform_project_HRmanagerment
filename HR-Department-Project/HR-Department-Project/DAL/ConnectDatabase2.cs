using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department_Project.DAL
{
    class ConnectDatabase2
    {
        static string dbName = "HRD_DB";
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=HRD_DB;Integrated Security=True";
        //string connectionString = $@"server=DESKTOP-9ER0ESK\SQLEXPRESS;database={dbName};User ID=sa;Password=tuongyeuthao1";
        SqlConnection connection;
        public ConnectDatabase2()
        {
            connection = new SqlConnection(connectionString);
        }

        public DataTable loadData(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

            }
            catch (Exception error)
            {
                MessageBox.Show("Vui lòng nhập đúng cú pháp!");
                throw error;
            }
            return dt;
        }


        public void changeDB(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res >= 1) MessageBox.Show("successfully");
                else MessageBox.Show("Vui lòng nhập vào mã!");
            }
            catch (Exception error)
            {
                throw error;
                MessageBox.Show($"{error}");
            }

            connection.Close();
        }

        public object countRecord(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            int count = (int)cmd.ExecuteScalar();
            connection.Close();

            return count;
        }


    }
}
