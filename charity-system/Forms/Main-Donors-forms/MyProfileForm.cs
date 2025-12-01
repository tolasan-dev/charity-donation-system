using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace charity_system.Forms.Main_Donors_forms
{
    public partial class MyProfileForm : Form
    {
        public MyProfileForm()
        {
            InitializeComponent();
        }

        private void MyProfileForm_Load(object sender, EventArgs e)
        {

        }

        private void Donor_Main(object sender, EventArgs e)
        {
            DonorMainForm dn = new DonorMainForm();
            dn.Show();
            Dispose();
        }

        private void Donation_now(object sender, EventArgs e)
        {


            DonateNowForm donation_now = new DonateNowForm();
            donation_now.Show();
            Dispose();

        }

        private void My_donation_Click(object sender, EventArgs e)
        {   
            MyDonationsForm md = new MyDonationsForm();
            md.Show();
            Dispose();


        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Dispose();
        }
    }
}
