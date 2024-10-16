using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.DAL
{
    class DALProbationary_payrolls
    {
        ConnectDatabase commonClass;

        public DALProbationary_payrolls()
        {
            commonClass = new ConnectDatabase();
        }
        public DataTable DalLoadGrid()
        {
            string SqlLoad = "SELECT pr.*, rd.probationary_position, rd.expiry_date,inf.identification_num,inf.fullname,dpm.department_name, (pr.num_day_of_work - pr.num_day_off) * pr.salary as total_salary FROM probationary_payrolls pr left JOIN probationary_records rd   ON pr.id = rd.probationary_payroll_id  left JOIN personal_informations inf   ON rd.personal_information_id = inf.id   left JOIN departments dpm   ON rd.department_id = dpm.id; ";
           
            return commonClass.LoadData(SqlLoad);
        }
        public void DALUpdate(int num_day_of_work, int  num_day_off, float salary, string note, int id)
        {
            string sqlSua = $"UPDATE probationary_payrolls SET num_day_of_work = {num_day_of_work} , num_day_off = {num_day_off}, salary = {salary} , note='{note}' WHERE id = {id}";

            commonClass.Nonquery(sqlSua);
        }
        public void DALDelete(int id)
        {

            string sqldelete = $"delete from probationary_records where id= {id}" + $"delete from probationary_payrolls where id={id}";

            commonClass.Nonquery(sqldelete);

        }

    }
}
