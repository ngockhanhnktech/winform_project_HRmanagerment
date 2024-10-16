using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department_Project.BLL
{
    class BLL_role
    {

        //BUSSINESS LAYER

        int ID;
        DAL.DAL_role DAL_ROLE;
        GUI.frm_admin_page APP;
        DAL.ConnectDatabase2 ketnoi;

        public BLL_role(GUI.frm_admin_page app)
        {
            DAL_ROLE = new DAL.DAL_role();
            ketnoi = new DAL.ConnectDatabase2();
            APP = app;
        }

        public BLL_role()
        {

        }

        public DataTable bll_loadData_role()
        {
            return DAL_ROLE.DAL_load_role_data();
        }

        public DataTable bll_loadData_role_user()
        {
            return DAL_ROLE.DAL_load_role_user_data();
        }


        public void bll_edit_role(int id, string name)
        {
            DAL_ROLE.DAL_edit_role(id, name);
        }

        public void bll_edit_role_user(int id,string admin_id, int user_id, int role_id)
        {
            DAL_ROLE.DAL_edit_role_user(id, admin_id, user_id, role_id);
        }


        public void bll_delete_role(int id)
        {
            DAL_ROLE.DAL_delete_role(id);
        }

        public void bll_create_role_user()
        {

            DataTable dt = DAL_ROLE.DAL_load_role_user_data();
            int role_id = (int)((DataRowView)APP.cb_role_id_p.SelectedItem)["id"];
            int user_id = (int)((DataRowView)APP.cb_user_id.SelectedItem)["id"];
            string admin_id = "NULL";
            bool check_user = false;
            int comfirm = DAL_ROLE.DAL_comfirm_role_user();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    object id = row["id"];
                    object roleID = row["role_id"];
                    object userID = row["user_id"];
      
                    ID = comfirm <= (int)id ? comfirm + 1 : ID;

                    if (string.Equals(userID.ToString(),user_id.ToString(),
                        StringComparison.OrdinalIgnoreCase))
                    {
                        check_user = true;

                        break;
                    }

                   
                }
            }
            if (check_user)
            {
                MessageBox.Show("Người dùng này đã được trao quyền!!!");
            }
            else
            {
                DAL_ROLE.DAL_create_role_user(ID, admin_id, user_id, role_id);

            }
            
        }

        public void bll_create_role()
        {

            DataTable dt = DAL_ROLE.DAL_load_role_data();
            bool check_name = false;

            if (!string.IsNullOrEmpty(APP.txt_role.Text))
            {
                int comfirm = DAL_ROLE.DAL_comfirm_role();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            string name = row["name"].ToString();
                            object id = row["id"];

                            ID = comfirm <= (int)id ? comfirm + 1 : ID;

                            if (string.Equals(name, APP.txt_role.Text,
                                StringComparison.OrdinalIgnoreCase))
                            {
                                check_name = true;

                                break;
                            }
                        }
                    }

                    if (check_name)
                    {
                        MessageBox.Show("Trùng tên vai trò");
                    }
                    else
                    {
                        DAL_ROLE.DAL_create_role(ID, APP.txt_role.Text);

                    }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập vào");
            }




        }


    }
}
