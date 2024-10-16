using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department_Project.DAL
{
    class DALPersonal_information
    {
        ConnectDatabase commonClass;
        public DALPersonal_information()
        {
            commonClass = new ConnectDatabase();
        }
        public DataTable DalLoadGrid()
        {
            string sqlLoad = "SELECT * FROM personal_informations";

            return commonClass.LoadData(sqlLoad);
        }
        public DataTable DalComboUserId()
        {
            string sqlLoadCombo = "select * from users";

            return commonClass.LoadData(sqlLoadCombo);
        }

        public int DAL_comfirm_createPerson()
        {
            try
            {
                string sql = $@"SELECT MAX(id) FROM personal_informations";

                return (int)commonClass.Scalar(sql);
            }
            catch
            {
                return 1;
            }

            
        }

        public void DALcreate(int id, string identification, string fullname, int gender, string birthplace, DateTime birthday, string image, string address, string phone_number, string ethnicity, string religion, string nationality, string education, string note, string id_user)
        {


            string sql = $"insert into personal_informations values({id}, N'{identification}',N'{fullname}',{gender}," +
            $"N'{birthplace}','{birthday}',N'{image}',N'{address}', N'{phone_number}', N'{ethnicity}', N'{religion}'," +
            $"N'{nationality}', N'{education}', '{note}', {id_user})";

            commonClass.Nonquery(sql);
        }

        public void DALDelete(int id)
        {
            string sqldelete = "delete from personal_informations where id='" + id + "'";

            commonClass.Nonquery(sqldelete);
          
        }

        public void DALUpdate(string Identification, string Fullname, int Gender, string Birthplace, DateTime birthday, string Image, string Address, string PhoneNumber, string Ethnicity, string Religion, string Nationality, string Education, string Note, string UserId, int Id)
        {
            string sqlSua = $"UPDATE personal_informations SET identification_num = N'{Identification}', fullname = '{Fullname}', gender = '{Gender}', Birthplace = '{Birthplace}', birthday = '{birthday}', image = '{Image}', Address = '{Address}', phone_num = '{PhoneNumber}', ethnicity = '{Ethnicity}', religion = '{Religion}', nationality = '{Nationality}', education = '{Education}', note = '{Note}', user_id = '{UserId}' WHERE id = '{Id}'";

            commonClass.Nonquery(sqlSua);
        }


        public void DAL_Update_imgUser(int id, string image)
        {
            string sqlSua = $"UPDATE personal_informations SET personal_informations.image = '{image}' WHERE personal_informations.id = {id}";

            commonClass.Nonquery(sqlSua);
        }
    }
}
