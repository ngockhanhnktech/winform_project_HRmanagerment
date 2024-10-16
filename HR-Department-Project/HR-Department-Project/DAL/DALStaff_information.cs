using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HR_Department_Project.DAL
{
    class DALStaff_information 
    {
        ConnectDatabase commonClass;
       

        public DALStaff_information()
        {
            commonClass = new ConnectDatabase();
        }
        public DataTable DalLoadGrid()
        {
            string SqlLoad = "SELECT departments.department_name,personal_informations.identification_num, personal_informations.fullname ,staff_informations.* from ((staff_informations left JOIN  departments ON staff_informations.department_id =departments.id) left JOIN personal_informations ON staff_informations.personal_information_id=personal_informations.id) left JOIN employee_payrolls ON staff_informations.employee_payroll_id=employee_payrolls.id;";

            return commonClass.LoadData(SqlLoad);
        }
        public DataTable DalComboDepartmentId()
        {
            string sqlLoadCombo = "select * from departments";

            return commonClass.LoadData(sqlLoadCombo);
        }
       
        public DataTable DalCombopersonalInformationsId()
        {
            string sqlLoadCombo = "select * from personal_informations";

            return commonClass.LoadData(sqlLoadCombo);
        }
        public void DALcreate(int id, int insurances_id,int marriage_status,  string position, string contracttype, DateTime dayofwork, DateTime signing_date, DateTime expiry_date, int department_id,int personal_information_id, int employee_payroll_id)
        {
            DataTable dt = commonClass.LoadData($"SELECT * FROM personal_informations WHERE personal_informations.id = {personal_information_id}");
            string place_of_issue = dt.Rows[0]["address"].ToString();
            string sql = $"insert into insurances values ({id}, Convert(DateTime,'" + signing_date + "' ,103), Convert(DateTime,'" + signing_date + "' ,103),N''," +
              " Convert(DateTime,'" + signing_date + "' ,103),'" + employee_payroll_id + "')";

            string sql2 = $"INSERT INTO staff_informations values ({id},'{marriage_status}',N'{position}',N'{contracttype}','{dayofwork}','{signing_date}', '{expiry_date}', {department_id}, {personal_information_id}, {employee_payroll_id})";

           commonClass.Nonquery(sql);
           commonClass.Nonquery(sql2);

        }
        public void DALcreate2(int id, decimal basic_salary, decimal new_basic_salary, decimal salary_position_allowance,
            decimal salary, decimal salary_other_allowance, string new_position_allowance, string penalty,
            int num_day_of_work, int num_day_off, int num_over_time, DateTime correction_salary_date)
        {

            string sqlCreate = $"insert into employee_payrolls values ({id}, {basic_salary}, {new_basic_salary}, {salary_position_allowance}, {salary}, {salary_other_allowance}, N'{new_position_allowance}', N'{penalty}', {num_day_of_work}, {num_day_off}, {num_over_time}, '{correction_salary_date}')";

            commonClass.Nonquery(sqlCreate);

        }
        public void DALUpdate(int marriage_status, string position, string contracttype, DateTime dayofwork, DateTime signing_date, DateTime expiry_date, int department_id, int persional_infor, int employee_payroll, int id)
        {
       
            string sqlSua = $"UPDATE staff_informations SET marriage_status = {marriage_status}, position=N'{position}', contracttype=N'{contracttype}', dayofwork='{dayofwork}', signing_date='{signing_date}', expiry_date='{expiry_date}', department_id={department_id}, personal_information_id={persional_infor}, employee_payroll_id= {employee_payroll} WHERE id = {id}";

            commonClass.Nonquery(sqlSua);
        }
        public void DALDelete(int id)
        {
            string sqldelete = $"delete from staff_informations where id= {id} " + $"delete from employee_payrolls where id= {id}";
             
            commonClass.Nonquery(sqldelete);


        }
        public int DAL_comfirm_id_staff_information()
        {
            try
            {
                string sql = $@"SELECT MAX(id) FROM staff_informations";
                return (int)commonClass.Scalar(sql);
            }
            catch
            {
                return 1;
            }
            
        }
        public DataTable DalTim()
        {
            string nhap = Interaction.InputBox("mời bạn nhập vào ô bên dưới để tìm ");
            string sqlTim = "SELECT staff_informations.*,departments.department_name,personal_informations.identification_num, personal_informations.fullname from ((staff_informations left JOIN  departments ON staff_informations.department_id =departments.id) left JOIN personal_informations ON staff_informations.personal_information_id=personal_informations.id) left JOIN employee_payrolls ON staff_informations.employee_payroll_id=employee_payrolls.id where identification_num like '%" + nhap + "%'";

            return commonClass.LoadData(sqlTim);
        }
        public int DalDem()
        {
            string sqlDem = "select count(*) from staff_informations";
            int ketqua = (int)commonClass.Scalar(sqlDem);

            return ketqua;
        }

    }
}
