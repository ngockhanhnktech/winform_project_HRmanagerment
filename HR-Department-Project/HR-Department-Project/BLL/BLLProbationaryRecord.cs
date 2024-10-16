using HR_Department_Project.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department_Project.BLL
{
    class BLLProbationaryRecord
    {
        DAL.DALProbationaryRecord dal_cn;
        DAL.DAL_role dal_cn_role;
        DAL.DALInsurances dal_insurances;
        frm_probationary_record cn;
        private int ID;
        int ID2;
        public BLLProbationaryRecord(frm_probationary_record FNS)
        {
            dal_cn = new DAL.DALProbationaryRecord();
            dal_cn_role = new DAL.DAL_role();
            dal_insurances = new DAL.DALInsurances();
            cn = FNS;
        }
        public void BllLoadGrid()
        {
            cn.dataGridView1.DataSource = dal_cn.DalLoadGrid();
        }

        public void BLL_Load_cb_pos()
        {
            cn.cb_pos.DataSource = dal_cn_role.DAL_load_role_data();
            cn.cb_pos.DisplayMember = "name";
        }


        public void BllLoadDepartment()
        {
            cn.combo_department.DataSource = dal_cn.DalComboDepartmentId();
            cn.combo_department.DisplayMember = "department_name";
            cn.combo_department.ValueMember = "id";
        }

        public void BllLoadPersonalInformation()
        {
            cn.combox_identification_number.DataSource = dal_cn.DalCombopersonalInformationsId();
            cn.combox_identification_number.DisplayMember = "identification_num";
            cn.combox_identification_number.ValueMember = "id";
        }

        public static int CalculateWorkingDays(DateTime startDate, DateTime endDate)
        {
            int workingDays = 0;
            DateTime currentDate = startDate;

            while (currentDate <= endDate)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }

                currentDate = currentDate.AddDays(1);
            }

            return workingDays;
        }

       
        public void BllCreate()
        {
            int comfirm = dal_cn.DAL_comfirm_id_probationary_records();
            int comfirm_insurances = dal_insurances.DAL_comfirm_insurances_id();

            DataTable dt = dal_cn.DAL_load_probationary_payrolls();
            DataTable dt2 = dal_insurances.DAL_load_insurances();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    object id = row["id"];
                    ID = comfirm <= (int)id ? comfirm + 1 : ID;
                }
            }

            if (ID==0)
            {
                ID = 1;
            }

            if (dt2 != null && dt2.Rows.Count > 0)
            {
                foreach (DataRow row in dt2.Rows)
                {
                    object id = row["id"];
                    ID2 = comfirm_insurances <= (int)id ? comfirm_insurances + 1 : ID;
                }
            }

            if (ID2 == 0)
            {
                ID2 = 1;
            }


            MessageBox.Show(ID.ToString());

            int department = int.Parse(cn.combo_department.SelectedValue.ToString());
            int persional_infor = int.Parse(cn.combox_identification_number.SelectedValue.ToString());

            DateTime startDate = cn.txt_probationary_date.Value;
            DateTime endDate = cn.txt_exprity_date.Value;

            int days = CalculateWorkingDays(startDate, endDate);

            dal_cn.DALcreate1(ID, days, 0, 0, "ghichu");
            dal_cn.DALcreate2(ID, ID2, cn.cb_pos.Text, cn.txt_probationary_date.Value, cn.txt_exprity_date.Value, cn.txt_note.Text, department, ID, persional_infor);

        }
        public void BllUpdate(int id)
        {
            int department = int.Parse(cn.combo_department.SelectedValue.ToString());
            int persional_infor = int.Parse(cn.combox_identification_number.SelectedValue.ToString());

            dal_cn.DALUpdate(cn.cb_pos.Text, cn.txt_probationary_date.Value, cn.txt_exprity_date.Value, cn.txt_note.Text, department, id, persional_infor,id);
        }
        public void BllDelete(int id)
        {
            dal_cn.DALDelete(id);

        }
    }
}
