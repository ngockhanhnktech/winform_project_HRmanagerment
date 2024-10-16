using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.DAL
{
    class DAL_register
    {

        ConnectDatabase2 ketnoi;

        public DAL_register()
        {
            ketnoi = new ConnectDatabase2();
        }

        public void dal_user_register(int id, string username, string password)
        {
            string sql = $@"insert into users values ({id},'{username}','{password}')";

            ketnoi.changeDB(sql);
        }

        public DataTable DAL_load_user_data()
        {

            string sql = $@"SELECT * FROM users";

            return ketnoi.loadData(sql);
        }

        public int DAL_comfirm_register()
        {
            try
            {
                string sql = $@"SELECT MAX(id) FROM users";

                return (int)ketnoi.countRecord(sql);
            }
            catch
            {
                return 1;
            }
           
        }

        public int DAL_CheckUsername_Admin(string username)
        {
            string sql = $@"SELECT COUNT(*) FROM admins WHERE username = '{username}'";

            return (int)ketnoi.countRecord(sql);
        }

    }
}
