using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.DAL
{
    class DAL_employee_payroll
    {

        ConnectDatabase2 ketnoi;


        public DAL_employee_payroll()
        {
            ketnoi = new ConnectDatabase2();
        }


        public DataTable DAL_load_employee_payroll()
        {
            string sql = $@"SELECT ((ep.num_day_of_work + (ep.num_over_time / 24.0) * 100) - ep.num_day_off) * ep.basic_salary 
                    + ep.salary_other_allowance + ep.salary_position_allowance as total_salary,
                    ep.*, si.*, pi.* FROM employee_payrolls as ep JOIN staff_informations as si ON ep.id = si.employee_payroll_id
                    JOIN personal_informations as pi ON si.personal_information_id = pi.id";


            return ketnoi.loadData(sql);
        }

       


        public void DAL_create_employee_payroll() {

            string sql = $@"insert into employee_payrolls values ()";

            ketnoi.changeDB(sql);
        }

        public void DAL_edit_employee_payroll(int id, decimal basic_salary, decimal new_basic_salary, decimal salary_position_allowance, decimal salary, decimal salary_other_allowance, string new_position_allowance, string penalty, int num_day_of_work, int num_day_off, int num_over_time, DateTime correction_salary_date)
        {
            string sql = $@"UPDATE employee_payrolls SET basic_salary={basic_salary}, new_basic_salary={new_basic_salary}, salary_position_allowance={salary_position_allowance}, salary={salary}, salary_other_allowance={salary_other_allowance}, new_position_allowance=N'{new_position_allowance}', penalty=N'{penalty}', num_day_of_work={num_day_of_work}, num_day_off={num_day_off}, num_over_time={num_over_time}, correction_salary_date='{correction_salary_date}'  WHERE employee_payrolls.id = {id}";

            ketnoi.changeDB(sql);
        }


        public void DAL_delete_employee_payroll(int id)
        {

            string sql = $@"DELETE FROM employee_payrolls WHERE id = {id}";

            ketnoi.changeDB(sql);
        }

        public int DAL_comfirm_employee_payroll_id()
        {
            try
            {
                string sql = $@"SELECT MAX(id) FROM employee_payrolls";

                return (int)ketnoi.countRecord(sql);
            }
            catch
            {
                return 1;
            }

        }

    }
}
