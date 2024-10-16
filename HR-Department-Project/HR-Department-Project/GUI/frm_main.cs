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
    public partial class frm_main : Form
    {
        string username = BLL.BLL_login.SESSION.username;
        private static Form currentFormChild;
        public static int permission;
        frm_login LOGIN;
        DAL.ConnectDatabase2 ketnoi = new DAL.ConnectDatabase2();

        public frm_main()
        {
            ketnoi = new DAL.ConnectDatabase2();
            InitializeComponent();
            LOGIN = new frm_login();
        }

        private void frm_main_Load(object sender, EventArgs e)
        {

            OpenChildForm(new frm_user_page());

            switch (frm_user_page.session_role)
            {

                case 7:
                case 9:
                case 2023:

                    personalInformationMenu.Visible = true;
                    staffInformationMenu.Visible = true;
                    departmentMenu.Visible = true;
                    probationaryRecordmenu.Visible = true;
                    probationary_payroll_menu.Visible = true;
                    employee_payroll_menu.Visible = true;
                    insurances_menu.Visible = true;
                    maternities_menu.Visible = true;
                    employee_quit_menu.Visible = true;
                    admin_menu.Visible = true;

                break;

                default:
                    personalInformationMenu.Visible = false;
                    staffInformationMenu.Visible = false;
                    departmentMenu.Visible = false;
                    probationaryRecordmenu.Visible = false;
                    probationary_payroll_menu.Visible = false;
                    employee_payroll_menu.Visible = false;
                    insurances_menu.Visible = false;
                    maternities_menu.Visible = false;
                    employee_quit_menu.Visible = false;
                    admin_menu.Visible = false;
                break;
            }


        }

        public void OpenChildForm(Form childFrom)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childFrom;
            childFrom.TopLevel = false;
            childFrom.FormBorderStyle = FormBorderStyle.None;
            childFrom.Dock = DockStyle.Fill;
            panel_mid.Controls.Add(childFrom);
            panel_mid.Tag = childFrom;
            childFrom.BringToFront();
            childFrom.Show();

        }
      
        private void btn_acccount_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_user_page());

        }


        private void departmentMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_department());

        }

        private void personalInformationMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_personal_information());
        }

        private void staffInformationMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_staff_informations());

        }

        private void probationaryRecord_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_probationary_record());

        }

        private void probationary_payroll_menu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_probationary_payrolls());

        }

        private void admin_menu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_admin_page());

        }

        private void logout_Click(object sender, EventArgs e)
        {
            frm_user_page.session_role = 0;
            this.Hide();
            frm_login form_login = new frm_login();
            form_login.Show();
        }

        private void employee_quit_menu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_employee_quits());

        }

        private void insurances_menu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_insuraces());
        }

        private void employee_payroll_menu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_employee_payroll());

        }

        private void maternities_menu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_maternities());
        }

        private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
