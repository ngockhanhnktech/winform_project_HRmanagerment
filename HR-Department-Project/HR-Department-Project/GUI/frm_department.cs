using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department_Project.GUI
{
    public partial class frm_department : Form
    {
        BLL.BLLDepartment bll_cn;
        private ConnectDatabase commonClass;
        public frm_department()
        {
            InitializeComponent();
            commonClass = new ConnectDatabase();
            bll_cn = new BLL.BLLDepartment(this);
        }
        private void frm_department_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            bll_cn.BllLoadGrid();
        }
        private void btn_create_Click(object sender, EventArgs e)
        {
           
            try
            {

                bll_cn.BllCreate();
                loadData();

            }
            catch (Exception)
            {
             
                bll_cn.BBLCreate2();


            }
            loadData();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_department_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_date_of_establishment.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_note.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
           
        }

        string checkDelete;
        private void btn_update_Click(object sender, EventArgs e)
        {
        

            checkDelete = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            bll_cn.BllUpdate(int.Parse(checkDelete));

            loadData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("You may want to delete", "Delete data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    checkDelete = dataGridView1.CurrentRow.Cells["id"].Value.ToString();               
                    bll_cn.BllDelete(int.Parse(checkDelete));
                    loadData();
                }
            }
            catch
            {
                MessageBox.Show("You need to delete employee information before deleting personal information");
            }

            loadData();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txt_date_of_establishment.Text = "";
            txt_department_name.Text = "";
            txt_note.Text = "";
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
