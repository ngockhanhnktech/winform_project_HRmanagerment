using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department_Project.BLL
{
    class BLL_employee_quit
    {

        DAL.DAL_employee_quit DAL_EMP_QUIT;
        GUI.frm_employee_quits APP;
        int ID;
        string id;

        public BLL_employee_quit()
        {

        }

        public BLL_employee_quit(GUI.frm_employee_quits app)
        {
            DAL_EMP_QUIT = new DAL.DAL_employee_quit();
            APP = app;
        }

        

        public void BLL_employee_quit_loadData()
        {

            APP.dataGridView1.DataSource =  DAL_EMP_QUIT.DAL_load_employee_quit();

        }

        public void BLL_loadData_personal_id()
        {

            APP.cb_staff_id.DataSource = DAL_EMP_QUIT.DAL_load_personal_infomation_id();
            APP.cb_staff_id.DisplayMember = "identification_num";
            APP.cb_staff_id.ValueMember = "id";

        }


        public void BLL_create_employee_quit()
        {

            int comfirm = DAL_EMP_QUIT.DAL_comfirm_employee_quit_id();
            DataTable dt = DAL_EMP_QUIT.DAL_load_employee_quit();
            DateTime day_off_work = DateTime.Parse(APP.txt_day_of_work.Text);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    object id = row["id"];

                    ID = comfirm <= (int)id ? comfirm + 1 : ID;

                }
            }

            if (ID == 0)
            {
                ID = 1;
            }


            DAL_EMP_QUIT.DAL_create_employee_quit(ID, day_off_work, APP.txt_reason.Text, APP.cb_staff_id.SelectedValue.ToString());

        }

        public void BLL_edit_employee_quit()
        {
            id = APP.dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            DateTime day_off_work = DateTime.Parse(APP.txt_day_of_work.Text);

            string staffId = APP.cb_staff_id.SelectedValue != null ? APP.cb_staff_id.SelectedValue.ToString() : string.Empty;

            DAL_EMP_QUIT.DAL_edit_employee_quit(int.Parse(id), day_off_work, APP.txt_reason.Text, staffId);
        }


        public void BLL_delete_employee_quit()
        {
            id = APP.dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            DAL_EMP_QUIT.DAL_delete_employee_quit(int.Parse(id));

        }



    }
}
