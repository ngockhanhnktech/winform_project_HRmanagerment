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
    public partial class frm_insuraces : Form
    {
        string id;
        DAL.ConnectDatabase2 ketnoi;
        BLL.BLLInsurances bll_cn;
        bool c = false;

        public frm_insuraces()
        {
            InitializeComponent();
            bll_cn = new BLL.BLLInsurances(this);
            ketnoi = new DAL.ConnectDatabase2();
        }

        private void frm_insuraces_Load(object sender, EventArgs e)
        {
            bll_cn.BLL_Insurances_loadData();
            bll_cn.BLL_loadData_personal_id();

        }
    

   

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                c = true;

                txt_date_of_issue.Text = dataGridView1.CurrentRow.Cells["date_of_issue"].Value.ToString();
                txt_place_of_issue.Text = dataGridView1.CurrentRow.Cells["place_of_issue"].Value.ToString();
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
            bll_cn.BLL_create_Insurances();
            bll_cn.BLL_Insurances_loadData();

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            bll_cn.BLL_edit_Insurances();
            bll_cn.BLL_Insurances_loadData();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            bll_cn.BLL_delete_Insurances();
            bll_cn.BLL_Insurances_loadData();

        }

        private void btn_refesh_Click(object sender, EventArgs e)
        {
            bll_cn.BLL_Insurances_loadData();

        }
    }
}
