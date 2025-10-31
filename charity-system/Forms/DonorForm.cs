using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace charity_system.Forms
{


    public partial class DonorForm : Form
    { 
      
        public DonorForm()
        {
            InitializeComponent();
        }

        private void DonorForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for your donation!", "Donation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            // Create and open the login form modally
            LoginForm loginForm = new LoginForm();

            // Show the form and wait until it closes
            DialogResult result = loginForm.ShowDialog();

            // Check what the user did on the login form
            if (result == DialogResult.OK)
            {
                // Example: Login successful, proceed to main form or next action
                MessageBox.Show("Login successful!");
            }
            else
            {
                // Example: User canceled or closed the form
                MessageBox.Show("Login canceled.");
            }
        }
    }
   }

