using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.BLL
{
    class BLL_maternities
    {

        DAL.DAL_maternities DAL_MATERNITIES;
        GUI.frm_maternities APP;
        int ID;
        string id;

        public BLL_maternities()
        {

        }

        public BLL_maternities(GUI.frm_maternities app)
        {
            DAL_MATERNITIES = new DAL.DAL_maternities();
            APP = app;
        }



        public void BLL_maternities_loadData()
        {

            APP.dataGridView1.DataSource = DAL_MATERNITIES.DAL_load_maternities();

        }

        public void BLL_loadData_personal_id()
        {

            APP.cb_personal_id.DataSource = DAL_MATERNITIES.DAL_load_personal_infomation_id();
            APP.cb_personal_id.DisplayMember = "identification_num";
            APP.cb_personal_id.ValueMember = "id";

        }


        public void BLL_create_maternities()
        {

            int comfirm = DAL_MATERNITIES.DAL_comfirm_maternities_id();
            DataTable dt = DAL_MATERNITIES.DAL_load_maternities();
            DateTime day_maternity_leave = DateTime.Parse(APP.txt_day_maternity_leave.Text);

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


            DAL_MATERNITIES.DAL_create_maternities(ID, day_maternity_leave, APP.txt_salary_company_allowance.Text, APP.cb_personal_id.SelectedValue.ToString());

        }

        public void BLL_edit_maternities()
        {
            id = APP.dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            DateTime day_maternity_leave = DateTime.Parse(APP.txt_day_maternity_leave.Text);

            DAL_MATERNITIES.DAL_edit_maternities(int.Parse(id), day_maternity_leave, APP.txt_salary_company_allowance.Text, APP.cb_personal_id.SelectedValue.ToString());
        }


        public void BLL_delete_maternities()
        {
            id = APP.dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            DAL_MATERNITIES.DAL_delete_maternities(int.Parse(id));

        }

    }
}
