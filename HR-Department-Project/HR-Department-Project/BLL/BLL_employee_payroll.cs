using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department_Project.BLL
{
    class BLL_employee_payroll
    {

        DAL.DAL_employee_payroll DAL_EMP_PAYROLL;
        GUI.frm_employee_payroll APP;
        int ID;
        string id;

        public BLL_employee_payroll()
        {

        }

        public BLL_employee_payroll(GUI.frm_employee_payroll app)
        {
            DAL_EMP_PAYROLL = new DAL.DAL_employee_payroll();
            APP = app;
           
        }

        public void BLL_employee_payroll_loadData()
        {

            APP.dataGridView1.DataSource = DAL_EMP_PAYROLL.DAL_load_employee_payroll();

        }

 
        public void BLL_edit_employee_payroll()
        {
            id = APP.dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            //MessageBox.Show(id);

            DAL_EMP_PAYROLL.DAL_edit_employee_payroll(int.Parse(id),
            Decimal.Parse(APP.txt_salary_basic.Text), Decimal.Parse(APP.txt_new_basic_salary.Text),
            Decimal.Parse(APP.txt_salary_position_allowance.Text), Decimal.Parse(APP.txt_salary.Text),
            Decimal.Parse(APP.txt_salary_other_allowance.Text), APP.txt_new_position_allowance.Text,
            APP.txt_Penalty.Text, int.Parse(APP.txt_num_day_of_work.Text), int.Parse(APP.txt_num_day_off.Text),
            int.Parse(APP.txt_num_over_time.Text), DateTime.Parse(APP.txt_correction_salary_date.Text));

        }


        public void BLL_delete_employee_payroll()
        {
            id = APP.dataGridView1.CurrentRow.Cells["id"].Value.ToString();

            DAL_EMP_PAYROLL.DAL_delete_employee_payroll(int.Parse(id));
        }


    }
}
