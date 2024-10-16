using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.DAL
{
    class DAL_user
    {
        ConnectDatabase2 ketnoi;
        public DAL_user()
        {
            ketnoi = new ConnectDatabase2();
        }

        public DataTable DAL_loadData()
        {

            return ketnoi.loadData("SELECT * FROM users");
        }


    }
}
