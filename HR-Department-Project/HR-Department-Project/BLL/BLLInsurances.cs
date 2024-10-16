using HR_Department_Project.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.BLL
{
    class BLLInsurances
    {

        DAL.DALInsurances DAL_Insurances;
        frm_insuraces APP;
        int ID;
        string id;

        public BLLInsurances()
        {

        }

        public BLLInsurances(frm_insuraces app)
        {
            DAL_Insurances = new DAL.DALInsurances();
            APP = app;
        }



        public void BLL_Insurances_loadData()
        {

            APP.dataGridView1.DataSource = DAL_Insurances.DAL_load_insurances();

        }

        public void BLL_loadData_personal_id()
        {

            APP.cb_personal_id.DataSource = DAL_Insurances.DAL_load_personal_infomation_id();
            APP.cb_personal_id.DisplayMember = "identification_num";
            APP.cb_personal_id.ValueMember = "id";

        }


        public void BLL_create_Insurances()
        {

            int comfirm = DAL_Insurances.DAL_comfirm_insurances_id();
            DataTable dt = DAL_Insurances.DAL_load_insurances();
            DateTime txt_date_of_issue = DateTime.Parse(APP.txt_date_of_issue.Text);

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


            DAL_Insurances.DAL_create_insurances(ID, txt_date_of_issue, APP.txt_place_of_issue.Text, APP.cb_personal_id.SelectedValue.ToString());

        }

        public void BLL_edit_Insurances()
        {
            id = APP.dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            DateTime date_of_issue = DateTime.Parse(APP.txt_date_of_issue.Text);

            DAL_Insurances.DAL_edit_insurances(int.Parse(id), date_of_issue, APP.txt_place_of_issue.Text, APP.cb_personal_id.SelectedValue.ToString());
        }


        public void BLL_delete_Insurances()
        {
            id = APP.dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            DAL_Insurances.DAL_delete_insurances(int.Parse(id));

        }





    }



}
