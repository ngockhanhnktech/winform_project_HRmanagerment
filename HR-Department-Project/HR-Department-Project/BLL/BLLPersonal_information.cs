using HR_Department_Project.GUI;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace HR_Department_Project.BLL
{


    class BLLPersonal_information
    {
        DAL.DALPersonal_information dal_cn;
        frm_personal_information cn;
        frm_user_page cn_user_page;
        int ID;

        public BLLPersonal_information(frm_personal_information FNS)
        {
            dal_cn = new DAL.DALPersonal_information();
            cn = FNS;
        }

        public BLLPersonal_information(frm_user_page FNS_USER_PAGE)
        {
            dal_cn = new DAL.DALPersonal_information();
            cn_user_page = FNS_USER_PAGE;
        }
        public void BllLoadGrid()
        {
            cn.dataGridView1.DataSource = dal_cn.DalLoadGrid();
        }
        public void BllLoadCombo()
        {

            cn.combox_user_id.DataSource = dal_cn.DalComboUserId();
            cn.combox_user_id.DisplayMember = "username";
            cn.combox_user_id.ValueMember = "id";
        }
        public void BllCreate()
        {
            int gender;
            if (cn.txt_gender.Text == "Nam")
            {
                gender = 1;
            }
            else
            {
                gender = 0;
            }

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

            dal_cn.DALcreate(ID, cn.txt_identification_number.Text, cn.txt_full_name.Text, gender, cn.txt_birthplace.Text, cn.datetime_birthday.Value, cn.txt_image.Text, cn.txt_address.Text, cn.txt_phonenumber.Text, cn.txt_ethnicity.Text, cn.txt_religion.Text, cn.txt_nationality.Text, cn.txt_education.Text, cn.txt_notes.Text, cn.combox_user_id.SelectedValue.ToString());
        }
        
        public void BllUpdate(int id)
        {
            int gender;
            DateTime birthday = cn.datetime_birthday.Value;

            if (cn.txt_gender.Text == "Nam")
            {
                gender = 1;
            }
            else
            {
                gender = 0;
            }
            dal_cn.DALUpdate(cn.txt_identification_number.Text, cn.txt_full_name.Text, 
            gender, cn.txt_birthplace.Text,birthday, cn.txt_image.Text, cn.txt_address.Text,
            cn.txt_phonenumber.Text, cn.txt_ethnicity.Text, cn.txt_religion.Text,
            cn.txt_nationality.Text, cn.txt_education.Text,cn.txt_notes.Text, 
            cn.combox_user_id.SelectedValue.ToString(), id);
        }

        public void bll_update_user_img(int id, string image_file_name)
        {
            DialogResult res = MessageBox.Show("Bạn chắc chắn muốn đổi ảnh đại diện chứ ?", "Xác nhận", MessageBoxButtons.OKCancel);

            switch (res)
            {
                case DialogResult.OK:

                    try
                    {
                        cn_user_page.img_user.Image.Save(Application.StartupPath + $@"\\Resources\\{image_file_name}");
                        dal_cn.DAL_Update_imgUser(id, image_file_name);

                    }
                    catch
                    {
                        return;
                    }

                    break;
              
               
            }



        }

        public void BllDelete(int id)
        {
            dal_cn.DALDelete(id);
        }
    }
}
