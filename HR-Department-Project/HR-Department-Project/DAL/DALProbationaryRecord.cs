using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.DAL
{
    class DALProbationaryRecord
    {
        ConnectDatabase commonClass;

        public DALProbationaryRecord()
        {
            commonClass = new ConnectDatabase();
        }
        public DataTable DalLoadGrid()
        {
            string sqlLoad = "SELECT * FROM probationary_records, personal_informations WHERE probationary_records.personal_information_id = personal_informations.id";
            return commonClass.LoadData(sqlLoad);
        }
        public DataTable DAL_load_probationary_payrolls()
        {
            string sqlLoad = "SELECT * FROM probationary_payrolls ";
            return commonClass.LoadData(sqlLoad);
        }
        public DataTable DalComboDepartmentId()
        {
            string sqlLoadCombo = "select * from departments";
            return commonClass.LoadData(sqlLoadCombo);
        }
        public DataTable DalComboProbationPayrollsId()
        {
            string sqlLoadCombo = "select * from probationary_payrolls";
            return commonClass.LoadData(sqlLoadCombo);
        }
        public DataTable DalCombopersonalInformationsId()
        {
            string sqlLoadCombo = "select * from personal_informations";
            return commonClass.LoadData(sqlLoadCombo);
        }
      
    
        public void DALcreate1(int id, int num_day_of_work, int num_day_off, int salary, string note)
        {
            string sqlCreate = $"insert into probationary_payrolls values ({id},N'" + num_day_of_work + "',N'" + num_day_off + "',N'" + salary + "',N'" + note + "')";

            commonClass.Nonquery(sqlCreate);
        }
        public void DALcreate2(int id, int insurances_id, string probationary_position, DateTime probationary_date, DateTime expiry_date, string note, int department_id, int probationary_payroll_id, int personal_information_id)
        {
            DateTime date_of_issue = DateTime.Now;
            DataTable dt = commonClass.LoadData($"SELECT * FROM personal_informations WHERE personal_informations.id = {personal_information_id}");

            string sql1 = $"insert into probationary_records values ({id}, N'{probationary_position}', '{probationary_date}', '{expiry_date}', '{note}', {department_id}, {probationary_payroll_id}, {personal_information_id})";
            string sql2 = $@"insert into insurances values ({insurances_id}, '{date_of_issue}', '{date_of_issue}', '{note}', '{date_of_issue}', {personal_information_id})";

            commonClass.Nonquery(sql1);
            commonClass.Nonquery(sql2);
        }

       
        public void DALUpdate(string probationary_position, DateTime probationary_date, DateTime expiry_date, string note, int department_id, int probationary_payroll_id, int personal_information_id, int id)
        {
            string sqlSua = $"UPDATE probationary_records SET probationary_position = '{probationary_position}' , probationary_date = '{probationary_date}', expiry_date = '{ expiry_date}', note='{note}', department_id ='{department_id}'  , probationary_payroll_id ='{probationary_payroll_id}', personal_information_id ='{personal_information_id}' WHERE id ='{id}'";

            commonClass.Nonquery(sqlSua);
        }
        public void DALDelete(int id)
        {
            string sqldelete = $"delete from probationary_records where id= {id}" + $"delete from probationary_payrolls where id= {id}";

            commonClass.Nonquery(sqldelete);

        }

        public int DAL_comfirm_id_probationary_records()
        {

            try
            {
                string sql = $@"SELECT MAX(id) FROM probationary_records";
                return (int)commonClass.Scalar(sql);

            }
            catch (Exception error)
            {
                //throw error;
                return 1;
            }

        }

    }
}
