using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department_Project.BLL
{
    class BLL_register
    {

        //BUSSINESS LAYER

        int ID;
        DAL.DAL_register DAL_RG;
        GUI.frm_login APP;

        public BLL_register(GUI.frm_login app)
        {
            DAL_RG = new DAL.DAL_register();
            APP = app;
        }

        public BLL_register()
        {
           
        }

        public void bll_register()
        {
            DateTime current_date = DateTime.Now;
            DataTable dt = DAL_RG.DAL_load_user_data();
            bool check_username = false;

            if (!string.IsNullOrEmpty(APP.txt_username_r.Text) &&
                !string.IsNullOrEmpty(APP.Txt_password_r.Text))
            {
                int checkUsernameAdmin = DAL_RG.DAL_CheckUsername_Admin(APP.txt_username_r.Text);
                if (checkUsernameAdmin < 1)
                {
                    int comfirm = DAL_RG.DAL_comfirm_register();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            string username = row["username"].ToString();
                            object id = row["id"];

                            ID = comfirm <= (int)id ? comfirm + 1 : ID;

                            if (string.Equals(username, APP.txt_username_r.Text,
                                StringComparison.OrdinalIgnoreCase))
                            {
                                check_username = true;

                                break;
                            }
                        }
                    }

                    if (check_username)
                    {
                        MessageBox.Show("Trùng tên đăng nhập");
                    }
                    else
                    {
                        DAL_RG.dal_user_register(ID, APP.txt_username_r.Text, APP.txt_password_r.Text);

                    }

                }
                else
                {
                    MessageBox.Show("Bạn đã nhập tên đăng nhập trùng với người chơi khác vui lòng nhập tên đăng nhập khác!");
                }


            }
            else
            {
                MessageBox.Show("Vui lòng nhập vào");
            }



        }

    }
}
