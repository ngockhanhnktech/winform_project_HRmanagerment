using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department_Project.BLL
{
    class BLL_login
    {
        DAL.DAL_login DAL_LG;
        GUI.frm_login APP;
        int close = 0;
        private static BLL_login session;
        public static string _username;
        public static string _password;
        public string username { get; set; }

        private BLL_login()
        {

        }

        public static BLL_login SESSION
        {
            get
            {
                if (session == null)
                {
                    session = new BLL_login();
                }
                return session;
            }
        }

        public BLL_login(GUI.frm_login login)
        {
            DAL_LG = new DAL.DAL_login();
            APP = login;
        }


        public void bll_login()
        {

            if (!string.IsNullOrEmpty(APP.txt_username.Text) &&
                  !string.IsNullOrEmpty(APP.txt_password.Text))
            {
                int res_admin = DAL_LG.dal_login_admin(APP.txt_username.Text, APP.txt_password.Text);
                if (res_admin >= 1)
                {
                    SESSION.username = APP.txt_username.Text;
                    GUI.frm_user_page.session_role = 2023;
                    close = 0;
                    APP.Hide();
                    GUI.frm_main form_main = new GUI.frm_main();
                    form_main.Show();
                }
                else
                {
      
                    int res = DAL_LG.dal_login_user(APP.txt_username.Text, APP.txt_password.Text);
                    if (res >= 1)
                    {
                        SESSION.username = APP.txt_username.Text;
                        close = 0;
                        APP.Hide();
                        GUI.frm_main form_main = new GUI.frm_main();
                        form_main.Show();

                    }
                    else
                    {
                        close++;
                        MessageBox.Show($@"Bạn đã nhập sai tên đăng nhập hoặc mật khẩu lần {close} !");
                    }
                }

                if (close > 3)
                {
                    MessageBox.Show($@"Bạn đã nhập sai quá {close - 1} lần chương trình phải thoát");
                    Application.Exit();
                }

            }
            else
            {
                MessageBox.Show("Vui lòng nhập vào");
            }


        }



    }
}
