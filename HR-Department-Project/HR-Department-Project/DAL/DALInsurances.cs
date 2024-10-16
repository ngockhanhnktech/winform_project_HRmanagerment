using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.DAL
{
    class DALInsurances
    {
        ConnectDatabase2 ketnoi;


        public DALInsurances()
        {
            ketnoi = new ConnectDatabase2();
        }


        public DataTable DAL_load_insurances()
        {

            string sql = $@"SELECT * FROM insurances, personal_informations WHERE insurances.personal_information_id = personal_informations.id";

            return ketnoi.loadData(sql);
        }

        public DataTable DAL_load_personal_infomation_id()
        {

            string sql = $@"SELECT * FROM  personal_informations";

            return ketnoi.loadData(sql);
        }


        public void DAL_create_insurances(int id, DateTime date_of_issue, string place_of_issue, string personal_information_id)
        {
            string sql = $@"insert into insurances values ({id}, '{date_of_issue}', N'{place_of_issue}', {personal_information_id})";

            ketnoi.changeDB(sql);
        }

        public void DAL_edit_insurances(int id, DateTime date_of_issue, string place_of_issue, string personal_information_id)
        {
            string sql = $@"UPDATE insurances SET date_of_issue = '{date_of_issue}', place_of_issue = N'{place_of_issue}', personal_information_id = {personal_information_id} WHERE id = {id}";

            ketnoi.changeDB(sql);
        }


        public void DAL_delete_insurances(int id)
        {

            string sql = $@"DELETE FROM insurances WHERE id = {id}";
            ketnoi.changeDB(sql);
        }

        public int DAL_comfirm_insurances_id()
        {
            try
            {
                string sql = $@"SELECT MAX(id) FROM insurances";
                return (int)ketnoi.countRecord(sql);
            }
            catch
            {
                return 1;
            }

        }

    }
}
