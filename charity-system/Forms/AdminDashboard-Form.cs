using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace charity_system.Forms
{
    public partial class AdminDashboard_Form : Form

    {
        //private bool sidebarExpanded = true;
        public AdminDashboard_Form()
        {
            InitializeComponent();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMenuToggle(object sender, EventArgs e)
        {
            // TODO: Implement sidebar toggle functionality
        }

        private void AdminDashboard_Form_Click(object sender, EventArgs e)
        {


        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            //AdminDashboard_Form.ActiveForm.Close(); 

             DonorForm donorForm = new DonorForm();
             donorForm.Show();
        }

        private void AdminDashboard_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
