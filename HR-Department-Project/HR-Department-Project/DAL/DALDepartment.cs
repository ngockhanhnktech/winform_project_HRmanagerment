using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.DAL
{
    class DALDepartment
    {
        ConnectDatabase commonClass;
        public DALDepartment()
        {
            commonClass = new ConnectDatabase();
        }
        public DataTable DalLoadGrid()
        {
            string sqlLoad = "SELECT * FROM departments ";
            
            return commonClass.LoadData(sqlLoad);
        }
        public void DALcreate(int id, string Department_name, DateTime Date_of_establishment, string note)
        {

            string sqlCreate = $"insert into departments values ({id}, N'{Department_name}','{Date_of_establishment}', '{note}')";

            commonClass.Nonquery(sqlCreate);
        }
      
        public void DALDelete(int id)
        {
            string sqldelete = "delete from departments where id='" + id + "'";

            commonClass.Nonquery(sqldelete);

        }

        public void DALUpdate( string Department_name, DateTime Date_of_establishment, string note, int Id)
        {
            string sqlUpdate = $"UPDATE departments SET department_name = N'{Department_name}', date_of_establishment = '{Date_of_establishment}', note = '{note}' WHERE departments.id = {Id} ";

            commonClass.Nonquery(sqlUpdate);
        }


        public int DAL_comfirm_createPerson()
        {
            try
            {
                string sql = $@"SELECT MAX(id) FROM departments";
                return (int)commonClass.Scalar(sql);
            }
            catch
            {
                return 1;
            }

        }


    }
}
