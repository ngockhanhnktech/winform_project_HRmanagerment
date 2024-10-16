using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department_Project.GUI
{
    public partial class frm_personal_information : Form
    {
        BLL.BLLPersonal_information bll_cn;
        private ConnectDatabase commonClass;
        int a = 0;
        bool exit = false;
        int gender;
        string checkDelete;

        public frm_personal_information()
        {
            InitializeComponent();
            commonClass = new ConnectDatabase();
            bll_cn = new BLL.BLLPersonal_information(this);

        }



        private void frm_personal_information_Load(object sender, EventArgs e)
        {
            loadData();
            LoadUserId();
            DataTable dt = commonClass.LoadData($@"SELECT * FROM personal_informations");
            try
            {
                string[] gender_array = { "Nam", "Nữ" };
                txt_identification_number.Text = dt.Rows[0]["identification_num"].ToString();
                txt_full_name.Text = dt.Rows[0]["fullname"].ToString();
                txt_birthplace.Text = dt.Rows[0]["Birthplace"].ToString();
                datetime_birthday.Text = dt.Rows[0]["Birthday"].ToString();
                txt_image.Text = dt.Rows[0]["image"].ToString();
                txt_address.Text = dt.Rows[0]["address"].ToString();
                txt_phonenumber.Text = dt.Rows[0]["phone_num"].ToString();
                txt_ethnicity.Text = dt.Rows[0]["ethnicity"].ToString();
                txt_religion.Text = dt.Rows[0]["religion"].ToString();
                txt_nationality.Text = dt.Rows[0]["nationality"].ToString();
                txt_education.Text = dt.Rows[0]["education"].ToString();
                txt_notes.Text = dt.Rows[0]["note"].ToString();

                for (int i =0; i<gender_array.Length; i++)
                {
                    txt_gender.Text = gender_array[i];

                }
                LoadUserId();


                pictureBox1.ImageLocation = Application.StartupPath + $@"\\Resources\\{txt_image.Text}";
            }
            catch
            {
                pictureBox1.ImageLocation = Application.StartupPath + $@"\\Resources\\user1.png";

            }


        }
        public void loadData()
        {
            bll_cn.BllLoadGrid();
        }
         
        private void btn_create_Click(object sender, EventArgs e)
        {
            int user_id = (int) combox_user_id.SelectedValue;
            if (txt_gender.Text == "Nam")
            {
                gender = 1;
            }
            else
            {
                gender = 0;
            }
            
                bll_cn.BllCreate();

           

          
            loadData();

        }
        public void LoadUserId()
        {
            bll_cn.BllLoadCombo();
        }

      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                a = 1;
                txt_identification_number.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_full_name.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_gender.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_birthplace.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                datetime_birthday.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txt_image.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txt_address.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txt_phonenumber.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txt_ethnicity.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                txt_religion.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                txt_nationality.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                txt_education.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                txt_notes.Text = dataGridView1.Rows[e.RowIndex].Cells["note"].Value.ToString();
                combox_user_id.Text = dataGridView1.Rows[e.RowIndex].Cells["user_id"].Value.ToString();
                pictureBox1.ImageLocation = Application.StartupPath + $@"\\Resources\\{txt_image.Text}";

                a = 0;

            }
            catch
            {
                return;
            }


            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Hãy chọn ảnh";
            ofd.Filter = "Tất cả đuôi ảnh|*.*|JPG|*.jpg|PNG|*.png|JPEG|*.jpeg|GIF|*.gif";

            switch (ofd.ShowDialog())
            {
                case DialogResult.OK:
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    string fileName = Path.GetFileName(ofd.FileName);
                    txt_image.Text = fileName;
                    pictureBox1.Image.Save(Application.StartupPath + $@"\\Resources\\{txt_image.Text}");

                    break;
            }
        }
        private void _btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                checkDelete = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                File.Delete(Application.StartupPath + $@"\\Resources\\{txt_image.Text}");
                bll_cn.BllDelete(int.Parse(checkDelete));
                loadData();
            }catch(Exception error)
            {
                checkDelete = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                bll_cn.BllDelete(int.Parse(checkDelete));
                loadData();
            }

            
        }

        private void combox_user_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (a == 0)
            {

                string slqLoad = "select * from personal_informations where user_id='" + combox_user_id.SelectedValue.ToString() + "'";
                dataGridView1.DataSource = commonClass.LoadData(slqLoad);

            }
        }

     

        private void btn_update_Click(object sender, EventArgs e)
        {
            checkDelete = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            bll_cn.BllUpdate(int.Parse(checkDelete));
            loadData();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
