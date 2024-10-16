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
    public partial class frm_probationary_payrolls : Form
    {
        BLL.BLLProbationary_payrolls bll_cn;
        private ConnectDatabase commonClass;
        private string check;

        public frm_probationary_payrolls()
        {
            InitializeComponent();
            commonClass = new ConnectDatabase();
            bll_cn = new BLL.BLLProbationary_payrolls(this);

        }

        private void frm_probationary_payrolls_Load(object sender, EventArgs e)
        {
            bll_cn.BllLoadGrid();
        }
      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_numberdayofwork.Text = dataGridView1.CurrentRow.Cells["num_day_of_work"].Value.ToString();
            txt_numberdayoff.Text = dataGridView1.CurrentRow.Cells["num_day_off"].Value.ToString();
            txt_salary.Text = dataGridView1.CurrentRow.Cells["salary"].Value.ToString();
            txt_department.Text= dataGridView1.CurrentRow.Cells["department_name"].Value.ToString();
            txt_fullname.Text = dataGridView1.CurrentRow.Cells["fullname"].Value.ToString();
            txt_identificationnumber.Text = dataGridView1.CurrentRow.Cells["identification_num"].Value.ToString();
            txt_probationaryposition.Text = dataGridView1.CurrentRow.Cells["probationary_position"].Value.ToString();
            txt_expirydays.Text = dataGridView1.CurrentRow.Cells["expiry_date"].Value.ToString();
            
        }


        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                check = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                bll_cn.BllUpdate(int.Parse(check));
            }
            catch (Exception err)
            {
                MessageBox.Show("Fail!");
                throw err;
            }

            bll_cn.BllLoadGrid();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("You may want to delete", "Delete data", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    check = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                    bll_cn.BllDelete(int.Parse(check));
                    bll_cn.BllLoadGrid();
                }

            }
            catch(Exception err)
            {
                MessageBox.Show("You need to delete employee information before deleting personal information");
                throw err;
            }

            bll_cn.BllLoadGrid();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            bll_cn.BllLoadGrid();

        }
    }
}
