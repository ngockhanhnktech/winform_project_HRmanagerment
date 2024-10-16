namespace HR_Department_Project.GUI
{
    partial class frm_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel_top = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logout = new System.Windows.Forms.ToolStripMenuItem();
            this.admin_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_acccount = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.personalInformationMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.staffInformationMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.probationaryRecordmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.employee_payroll_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.probationary_payroll_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.employee_quit_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.insurances_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.maternities_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_left = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_mid = new System.Windows.Forms.Panel();
            this.gr_main = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_top.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel_mid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel_top.Controls.Add(this.pictureBox1);
            this.panel_top.Controls.Add(this.menuStrip1);
            this.panel_top.Location = new System.Drawing.Point(67, 1);
            this.panel_top.Margin = new System.Windows.Forms.Padding(4);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(1524, 113);
            this.panel_top.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngToolStripMenuItem,
            this.quảnLýToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1524, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logout,
            this.admin_menu});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.chứcNăngToolStripMenuItem.Text = "Chức Năng";
            // 
            // logout
            // 
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(284, 26);
            this.logout.Text = "Đăng xuất";
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // admin_menu
            // 
            this.admin_menu.Name = "admin_menu";
            this.admin_menu.Size = new System.Drawing.Size(284, 26);
            this.admin_menu.Text = "Quản lý vai trò, quyền, chức vụ";
            this.admin_menu.Click += new System.EventHandler(this.admin_menu_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_acccount,
            this.departmentMenu,
            this.personalInformationMenu,
            this.staffInformationMenu,
            this.probationaryRecordmenu,
            this.employee_payroll_menu,
            this.probationary_payroll_menu,
            this.employee_quit_menu,
            this.insurances_menu,
            this.maternities_menu});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.quảnLýToolStripMenuItem.Text = "Quản Lý";
            // 
            // btn_acccount
            // 
            this.btn_acccount.Name = "btn_acccount";
            this.btn_acccount.Size = new System.Drawing.Size(286, 26);
            this.btn_acccount.Text = "Tài khoản";
            this.btn_acccount.Click += new System.EventHandler(this.btn_acccount_Click);
            // 
            // departmentMenu
            // 
            this.departmentMenu.Name = "departmentMenu";
            this.departmentMenu.Size = new System.Drawing.Size(286, 26);
            this.departmentMenu.Text = "Bộ Phận";
            this.departmentMenu.Click += new System.EventHandler(this.departmentMenu_Click);
            // 
            // personalInformationMenu
            // 
            this.personalInformationMenu.Name = "personalInformationMenu";
            this.personalInformationMenu.Size = new System.Drawing.Size(286, 26);
            this.personalInformationMenu.Text = "Thông tin cá nhân";
            this.personalInformationMenu.Click += new System.EventHandler(this.personalInformationMenu_Click);
            // 
            // staffInformationMenu
            // 
            this.staffInformationMenu.Name = "staffInformationMenu";
            this.staffInformationMenu.Size = new System.Drawing.Size(286, 26);
            this.staffInformationMenu.Text = "Thông tin nhân viên chính thức";
            this.staffInformationMenu.Click += new System.EventHandler(this.staffInformationMenu_Click);
            // 
            // probationaryRecordmenu
            // 
            this.probationaryRecordmenu.Name = "probationaryRecordmenu";
            this.probationaryRecordmenu.Size = new System.Drawing.Size(286, 26);
            this.probationaryRecordmenu.Text = "Hồ sơ nhân viên tạm thời";
            this.probationaryRecordmenu.Click += new System.EventHandler(this.probationaryRecord_Click);
            // 
            // employee_payroll_menu
            // 
            this.employee_payroll_menu.Name = "employee_payroll_menu";
            this.employee_payroll_menu.Size = new System.Drawing.Size(286, 26);
            this.employee_payroll_menu.Text = "Lương nhân viên chính thức";
            this.employee_payroll_menu.Click += new System.EventHandler(this.employee_payroll_menu_Click);
            // 
            // probationary_payroll_menu
            // 
            this.probationary_payroll_menu.Name = "probationary_payroll_menu";
            this.probationary_payroll_menu.Size = new System.Drawing.Size(286, 26);
            this.probationary_payroll_menu.Text = "Lương nhân viên tạm thời";
            this.probationary_payroll_menu.Click += new System.EventHandler(this.probationary_payroll_menu_Click);
            // 
            // employee_quit_menu
            // 
            this.employee_quit_menu.Name = "employee_quit_menu";
            this.employee_quit_menu.Size = new System.Drawing.Size(286, 26);
            this.employee_quit_menu.Text = "Nhân viên nghỉ việc";
            this.employee_quit_menu.Click += new System.EventHandler(this.employee_quit_menu_Click);
            // 
            // insurances_menu
            // 
            this.insurances_menu.Name = "insurances_menu";
            this.insurances_menu.Size = new System.Drawing.Size(286, 26);
            this.insurances_menu.Text = "Bảo Hiểm";
            this.insurances_menu.Click += new System.EventHandler(this.insurances_menu_Click);
            // 
            // maternities_menu
            // 
            this.maternities_menu.Name = "maternities_menu";
            this.maternities_menu.Size = new System.Drawing.Size(286, 26);
            this.maternities_menu.Text = "Thai sản";
            this.maternities_menu.Click += new System.EventHandler(this.maternities_menu_Click);
            // 
            // panel_left
            // 
            this.panel_left.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel_left.Location = new System.Drawing.Point(-5, 1);
            this.panel_left.Margin = new System.Windows.Forms.Padding(4);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(64, 830);
            this.panel_left.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 28);
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // panel_mid
            // 
            this.panel_mid.Controls.Add(this.gr_main);
            this.panel_mid.Location = new System.Drawing.Point(67, 122);
            this.panel_mid.Margin = new System.Windows.Forms.Padding(4);
            this.panel_mid.Name = "panel_mid";
            this.panel_mid.Size = new System.Drawing.Size(1524, 709);
            this.panel_mid.TabIndex = 2;
            // 
            // gr_main
            // 
            this.gr_main.Location = new System.Drawing.Point(4, 4);
            this.gr_main.Margin = new System.Windows.Forms.Padding(4);
            this.gr_main.Name = "gr_main";
            this.gr_main.Size = new System.Drawing.Size(1260, 548);
            this.gr_main.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HR_Department_Project.Properties.Resources.nhansu;
            this.pictureBox1.Location = new System.Drawing.Point(4, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1595, 829);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.panel_mid);
            this.Controls.Add(this.panel_left);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_main";
            this.Text = "frm_main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_main_FormClosing);
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel_mid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.Panel panel_mid;
        private System.Windows.Forms.ToolStripMenuItem btn_acccount;
        private System.Windows.Forms.ToolStripMenuItem staffInformationMenu;
        private System.Windows.Forms.ToolStripMenuItem departmentMenu;
        private System.Windows.Forms.ToolStripMenuItem personalInformationMenu;
        private System.Windows.Forms.Panel gr_main;
        private System.Windows.Forms.ToolStripMenuItem probationaryRecordmenu;
        private System.Windows.Forms.ToolStripMenuItem logout;
        private System.Windows.Forms.ToolStripMenuItem probationary_payroll_menu;
        private System.Windows.Forms.ToolStripMenuItem admin_menu;
        private System.Windows.Forms.ToolStripMenuItem employee_quit_menu;
        private System.Windows.Forms.ToolStripMenuItem insurances_menu;
        private System.Windows.Forms.ToolStripMenuItem employee_payroll_menu;
        private System.Windows.Forms.ToolStripMenuItem maternities_menu;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}