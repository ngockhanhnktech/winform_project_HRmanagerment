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
    class BLLStaff_information
    {
        DAL.DALStaff_information dal_cn;
        DAL.DAL_role dal_cn_role;
        DAL.DALInsurances dal_insurances;
        frm_staff_informations cn;
        int ID, ID2;


        public BLLStaff_information(frm_staff_informations FNS)
        {
            dal_cn = new DAL.DALStaff_information();
            dal_cn_role = new DAL.DAL_role();
            dal_insurances = new DAL.DALInsurances();
            cn = FNS;
        }

      
        public void BllLoadGrid()
        {
            cn.dataGridView1.DataSource = dal_cn.DalLoadGrid();
        }

        public void BLL_Load_cb_pos()
        {
            cn.cb_pos.DataSource = dal_cn_role.DAL_load_role_data();
            cn.cb_pos.DisplayMember = "name";
        }


        public void BllLoadDepartment()
        {
            cn.combox_departmet.DataSource = dal_cn.DalComboDepartmentId();
            cn.combox_departmet.DisplayMember = "department_name";
            cn.combox_departmet.ValueMember = "id";
        }

        public void BllLoadPersonalInformation()
        {
            cn.combo_personal_information.DataSource = dal_cn.DalCombopersonalInformationsId();
            cn.combo_personal_information.DisplayMember = "identification_num";
            cn.combo_personal_information.ValueMember = "id";
        }

        public static int CalculateWorkingDays(DateTime startDate, DateTime endDate)
        {
            int workingDays = 0;
            DateTime currentDate = startDate;

            while (currentDate <= endDate)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }

                currentDate = currentDate.AddDays(1);
            }

            return workingDays;
        }

        public void BllCreate()
        {
            int comfirm = dal_cn.DAL_comfirm_id_staff_information();
            int comfirm_insurances = dal_insurances.DAL_comfirm_insurances_id();

            DataTable dt = dal_cn.DalLoadGrid();
            DataTable dt2 = dal_insurances.DAL_load_insurances();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    object id = row["id"];
                    ID = comfirm <= (int)id ? comfirm + 1 : ID;
                }
            }

            if (ID==0)
            {
                ID = 1;
            }

            if (dt2 != null && dt2.Rows.Count > 0)
            {
                foreach (DataRow row in dt2.Rows)
                {
                    object id = row["id"];
                    ID2 = comfirm_insurances <= (int)id ? comfirm_insurances + 1 : ID;
                }
            }

            if (ID2 == 0)
            {
                ID2 = 1;
            }


            MessageBox.Show($"Nhân viên số {ID} được tạo");

            int department = int.Parse(cn.combox_departmet.SelectedValue.ToString());
            int persional_infor = int.Parse(cn.combo_personal_information.SelectedValue.ToString());

            DateTime daywork = cn.txt_day_of_work.Value;
            DateTime daysign = cn.txt_singing_date.Value;
            DateTime expiryday = cn.txt_expiry_date.Value;
            //MessageBox.Show(daysign + "----" + expiryday);

            int days = CalculateWorkingDays(daywork, expiryday);
            int Status;
            if (cn.txt_marriage.Text == "ĐÃ KẾT HÔN")
            {
                Status = 1;
            }
            else
            {
                Status = 0;
            }
            int department_id = int.Parse(cn.combox_departmet.SelectedValue.ToString());
            int personal_infor_id = int.Parse(cn.combo_personal_information.SelectedValue.ToString());

            dal_cn.DALcreate2(ID, 0, 0, 0, 0, 0, "", "", days, 0, 0, daysign);
            dal_cn.DALcreate(ID, ID2, Status, cn.cb_pos.Text, cn.txt_contract_type.Text, daywork, daysign, expiryday, department_id, personal_infor_id, ID);

        }
        public void BllUpdate(int id)
        {
            int department = int.Parse(cn.combox_departmet.SelectedValue.ToString());
            int persional_infor = int.Parse(cn.combo_personal_information.SelectedValue.ToString());
            int department_id = int.Parse(cn.combox_departmet.SelectedValue.ToString());
            int personal_infor_id = int.Parse(cn.combo_personal_information.SelectedValue.ToString());

            DateTime daywork = cn.txt_day_of_work.Value;
            DateTime daysign = cn.txt_singing_date.Value;
            DateTime expiryday = cn.txt_expiry_date.Value;
            int days = CalculateWorkingDays(daywork, expiryday);

            int Status;

            if (cn.txt_marriage.Text == "ĐÃ KẾT HÔN")
            {
                Status = 1;
            }
            else
            {
                Status = 0;
            }
            

            dal_cn.DALUpdate(Status, cn.cb_pos.Text, cn.txt_contract_type.Text, daywork, daysign, expiryday, department_id, personal_infor_id, id, id);
        }
        public void BllDelete(int id)
        {
            dal_cn.DALDelete(id);

        }
        public void BllTim()
        {
            cn.dataGridView1.DataSource = dal_cn.DalTim();
            
        }
        public void BllDem()
        {
            cn.txt_so_luong.Text = dal_cn.DalDem().ToString();
        }

    }
}
