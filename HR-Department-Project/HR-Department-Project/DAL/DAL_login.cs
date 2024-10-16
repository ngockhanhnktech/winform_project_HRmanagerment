using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.DAL
{
    class DAL_login
    {

        //DATA LAYER

        ConnectDatabase2 ketnoi;

        public DAL_login()
        {
            ketnoi = new ConnectDatabase2();
        }

        public int dal_login_user(string username, string password)
        {
            string sql = $@"SELECT COUNT(*) FROM users WHERE username = '{username}' AND password = '{password}'";

            return (int)ketnoi.countRecord(sql);
        }

        public int dal_login_admin(string username, string password)
        {
            string sql = $@"SELECT COUNT(*) FROM admins WHERE username = '{username}' AND password = '{password}'";

            return (int)ketnoi.countRecord(sql);
        }


    }
}
