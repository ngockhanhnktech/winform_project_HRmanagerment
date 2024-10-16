using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.BLL
{
    class BLL_user
    {

        DAL.DAL_user DAL_USER;
        GUI.frm_admin_page APP;

        public BLL_user(GUI.frm_admin_page app)
        {
            DAL_USER = new DAL.DAL_user();
            APP = app;
        }

        public BLL_user()
        {
            
        }

        public DataTable bll_user_loadData()
        {
           return DAL_USER.DAL_loadData();

        }

    }
}
