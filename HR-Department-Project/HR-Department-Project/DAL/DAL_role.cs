using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department_Project.DAL
{
    class DAL_role
    {



        ConnectDatabase2 ketnoi;
        public DAL_role()
        {
            ketnoi = new ConnectDatabase2();
        }


        public void DAL_create_role(int id, string name)
        {

            string sql = $@"insert into roles values ({id},N'{name}')";

            ketnoi.changeDB(sql);
        }

        public void DAL_create_role_user(int id, string admin_id,int user_id, int role_id)
        {
            
            string sql = $@"insert into role_users values ({id}, {admin_id}, {user_id}, {role_id})";

            ketnoi.changeDB(sql);
        }

        public void DAL_edit_role_user(int id,string admin_id, int user_id, int role_id)
        {
            string sql = $@"UPDATE role_users SET role_users.admin_id = {admin_id}, role_users.role_id = {role_id} WHERE role_users.id = {id}";

            ketnoi.changeDB(sql);
        }

        public void DAL_edit_role(int id, string name)
        {
            string sql = $@"UPDATE roles SET roles.name = N'{name}' WHERE roles.id = {id}";

            ketnoi.changeDB(sql);
        }

        public void DAL_delete_role(int id)
        {

            string sql = $@"DELETE FROM roles WHERE roles.id = {id}";

            ketnoi.changeDB(sql);

        }


        public DataTable DAL_load_role_data()
        {
            string sql = $@"SELECT * FROM roles";

            return ketnoi.loadData(sql);
        }
        public DataTable DAL_load_role_user_data()
        {
            string sql = $@"SELECT * FROM  role_users, roles, users WHERE role_users.user_id = users.id and role_users.role_id = roles.id";

            return ketnoi.loadData(sql);
        }


        public int DAL_comfirm_role()
        {
            string sql = $@"SELECT MAX(id) FROM roles";

            return (int)ketnoi.countRecord(sql);
        }

        public int DAL_comfirm_role_user()
        {
            string sql = $@"SELECT MAX(id) FROM role_users";

            return (int)ketnoi.countRecord(sql);
        }


    }
}
