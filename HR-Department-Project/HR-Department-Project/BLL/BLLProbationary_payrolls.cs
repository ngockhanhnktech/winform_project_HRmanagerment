using HR_Department_Project.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Department_Project.BLL
{
    class BLLProbationary_payrolls
    {
        DAL.DALProbationary_payrolls dal_cn;
        frm_probationary_payrolls cn;

        public BLLProbationary_payrolls(frm_probationary_payrolls FNS)
        {
            dal_cn = new DAL.DALProbationary_payrolls();
            cn = FNS;
        }
        public void BllLoadGrid()
        {
            cn.dataGridView1.DataSource = dal_cn.DalLoadGrid();
        }
        public void BllUpdate(int id)
        {
            int num_day_of_work = int.Parse(cn.txt_numberdayofwork.Text);
            int num_day_off = int.Parse(cn.txt_numberdayoff.Text);
            float salary = float.Parse(cn.txt_salary.Text);

            dal_cn.DALUpdate(num_day_of_work,num_day_off,salary,cn.txt_note.Text, id);
        }
        public void BllDelete(int id)
        {
            dal_cn.DALDelete(id);

        }
    }
}
