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
    public partial class frm_maternities : Form
    {
        string id;
        DAL.ConnectDatabase2 ketnoi;
        BLL.BLL_maternities bll_cn;
        bool c = false;

        public frm_maternities()
        {
            InitializeComponent();
            bll_cn = new BLL.BLL_maternities(this);
            ketnoi = new DAL.ConnectDatabase2();
        }

       

        private void frm_maternities_Load(object sender, EventArgs e)
        {
            bll_cn.BLL_maternities_loadData();
            bll_cn.BLL_loadData_personal_id();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                c = true;

                txt_day_maternity_leave.Text = dataGridView1.CurrentRow.Cells["day_maternity_leave"].Value.ToString();
                txt_salary_company_allowance.Text = dataGridView1.CurrentRow.Cells["salary_company_allowance"].Value.ToString();
                cb_personal_id.Text = dataGridView1.Rows[e.RowIndex].Cells["personal_information_id"].Value.ToString();

                c = false;
            }
            catch
            {
                return;
            }
        }


        private void btn_create_Click(object sender, EventArgs e)
        {
            bll_cn.BLL_create_maternities();
            bll_cn.BLL_maternities_loadData();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            bll_cn.BLL_edit_maternities();
            bll_cn.BLL_maternities_loadData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            bll_cn.BLL_delete_maternities();
            bll_cn.BLL_maternities_loadData();
        }

        private void btn_refesh_Click(object sender, EventArgs e)
        {
            bll_cn.BLL_maternities_loadData();
        }

       
    }
}
