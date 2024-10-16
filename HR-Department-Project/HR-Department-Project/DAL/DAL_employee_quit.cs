using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.DAL
{
    class DAL_employee_quit
    {


        ConnectDatabase2 ketnoi;


        public DAL_employee_quit()
        {
            ketnoi = new ConnectDatabase2();
        }


        public DataTable DAL_load_employee_quit()
        {

            string sql = $@"SELECT * FROM employee_quits, personal_informations WHERE employee_quits.personal_information_id = personal_informations.id";

            return ketnoi.loadData(sql);
        }

        public DataTable DAL_load_personal_infomation_id()
        {

            string sql = $@"SELECT * FROM  personal_informations";

            return ketnoi.loadData(sql);
        }


        public void DAL_create_employee_quit(int id, DateTime dayoffwork, string reason, string personal_information_id)
        {
            string sql = $@"insert into employee_quits values ({id}, '{dayoffwork}', '{reason}', {personal_information_id})";

            ketnoi.changeDB(sql);
        }




        public void DAL_edit_employee_quit(int id, DateTime dayoffwork, string reason, string personal_information_id)
        {
            string sql = $@"UPDATE employee_quits SET day_off_work = '{dayoffwork}', reason = '{reason}', personal_information_id = {personal_information_id} WHERE id = {id}";

            ketnoi.changeDB(sql);
        }


        public void DAL_delete_employee_quit(int id)
        {

            string sql = $@"DELETE FROM employee_quits WHERE id = {id}";
            ketnoi.changeDB(sql);
        }

        public int DAL_comfirm_employee_quit_id()
        {
            try
            {
                string sql = $@"SELECT MAX(id) FROM employee_quits";
                return (int)ketnoi.countRecord(sql);
            }
            catch
            {
                return 1;
            }
            
        }



    }
}
