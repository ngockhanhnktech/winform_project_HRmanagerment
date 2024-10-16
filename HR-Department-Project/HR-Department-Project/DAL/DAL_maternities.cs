using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.DAL
{
    class DAL_maternities
    {

        ConnectDatabase2 ketnoi;


        public DAL_maternities()
        {
            ketnoi = new ConnectDatabase2();
        }


        public DataTable DAL_load_maternities()
        {

            string sql = $@"SELECT * FROM maternities, personal_informations WHERE maternities.personal_information_id = personal_informations.id";

            return ketnoi.loadData(sql);
        }

        public DataTable DAL_load_personal_infomation_id()
        {

            string sql = $@"SELECT * FROM personal_informations";

            return ketnoi.loadData(sql);
        }


        public void DAL_create_maternities(int id, DateTime day_maternity_leave, string salary_company_allowance, string personal_information_id)
        {
            string sql = $@"insert into maternities values ({id}, '{day_maternity_leave}', {salary_company_allowance}, {personal_information_id})";

            ketnoi.changeDB(sql);
        }


        public void DAL_edit_maternities(int id, DateTime day_maternity_leave, string salary_company_allowance, string personal_information_id)
        {
            string sql = $@"UPDATE maternities SET day_maternity_leave = '{day_maternity_leave}', salary_company_allowance = {salary_company_allowance}, personal_information_id = {personal_information_id} WHERE id = {id}";

            ketnoi.changeDB(sql);
        }


        public void DAL_delete_maternities(int id)
        {

            string sql = $@"DELETE FROM maternities WHERE id = {id}";

            ketnoi.changeDB(sql);
        }

        public int DAL_comfirm_maternities_id()
        {
            try
            {
                string sql = $@"SELECT MAX(id) FROM maternities";

                return (int)ketnoi.countRecord(sql);
            }
            catch
            {
                return 1;
            }

        }

    }
}
