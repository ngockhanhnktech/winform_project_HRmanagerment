using HR_Department_Project.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department_Project.BLL
{
    class BLLDepartment
    {
        DAL.DALDepartment dal_cn;
        frm_department cn;
        int ID;

        public BLLDepartment(frm_department FNS)
        {
            dal_cn = new DAL.DALDepartment();
            cn = FNS;
        }
        public void BllLoadGrid()
        {
            cn.dataGridView1.DataSource = dal_cn.DalLoadGrid();
        }
        public void BllCreate()
        {
            int comfirm = dal_cn.DAL_comfirm_createPerson();

            DataTable dt = dal_cn.DalLoadGrid();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    object id = row["id"];
                    ID = comfirm <= (int)id ? comfirm + 1 : ID;
                }
            }

            if (ID == 0)
            {
                ID = 1;
            }
            //MessageBox.Show(ID.ToString());
            dal_cn.DALcreate(ID,cn.txt_department_name.Text,cn.txt_date_of_establishment.Value ,cn.txt_note.Text);
        }
        public void BBLCreate2()
        {
            dal_cn.DALcreate(1, cn.txt_department_name.Text, cn.txt_date_of_establishment.Value, cn.txt_note.Text);
        }

        public void BllUpdate(int id)
        {
            
            dal_cn.DALUpdate(cn.txt_department_name.Text, cn.txt_date_of_establishment.Value, cn.txt_note.Text,id);
        }
        public void BllDelete(int id)
        {
            dal_cn.DALDelete(id);

        }

    }
}
