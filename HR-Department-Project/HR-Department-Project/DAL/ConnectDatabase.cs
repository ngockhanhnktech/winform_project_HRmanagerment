using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department_Project
{
    class ConnectDatabase
    {


        SqlConnection connection;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=HRD_DB;Integrated Security=True";
        public ConnectDatabase()
        {
            connection = new SqlConnection(connectionString);
        }

        public DataTable LoadData(string sql)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đúng cú pháp!");
            }
            return dt;
        }


        public void Nonquery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();

            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res >= 1) MessageBox.Show("successfully");
                else MessageBox.Show("Vui lòng nhập vào mã!");

            }
            catch(Exception error)
            {
                //MessageBox.Show("Faild !" + error);
                throw error;
            }

            connection.Close();
        }
        public void Nonquery2(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();


            try
            {
                int res = cmd.ExecuteNonQuery();


            }
            catch
            {
                //MessageBox.Show("Faild !");
            }

            connection.Close();
        }

        public object Scalar(string sql)
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
