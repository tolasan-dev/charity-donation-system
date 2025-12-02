using charity_system.Forms.Main_Donors_forms;
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
using charity_system.config;
using Microsoft.Data.SqlClient;

namespace charity_system.Forms
{


    public partial class DonorMainForm : Form
    {

        public DonorMainForm()
        {
            InitializeComponent();
            this.Load += DonorForm_Load;
        }

        private void DonorForm_Load(object sender, EventArgs e)
        {

            if (CurrentUser.DonorID == null)
                return;

            int donorId = CurrentUser.DonorID.Value;  // Get the logged-in donor's ID

            LoadTotalDonation(donorId);
            LoadDonationCount(donorId);
            LoadLastDonationDate(donorId);
            LoadRecentCampaigns();

        }

        private void guna2ShadowPanel4_Paint(object sender, PaintEventArgs e)
        {
            //LoadTotalDonation();
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

        }

        private void guna2CirclePictureBox1_Click_1(object sender, EventArgs e)
        {


        }

        //private void panel1_Paint(object sender, PaintEventArgs e)
        //{
        //    //Border.borderradius(panel1, 30);
        //}

        private void DonorForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void Donation_now(object sender, EventArgs e)
        {
            this.Hide();  // hide parent first

            DonateNowForm donateNowForm = new DonateNowForm();
            donateNowForm.ShowDialog();  // open child as modal


        }

        private void btnExit_Click(object sender, EventArgs e)
        {


            LoginForm login = new LoginForm();
            login.Show();
            Dispose();

        }

        private void Profile_btn(object sender, EventArgs e)
        {
            this.Hide();  // hide parent first
            MyProfileForm myProfileForm = new MyProfileForm();
            myProfileForm.ShowDialog();
        }

        private void MyDonation(object sender, EventArgs e)
        {
            this.Hide();
            MyDonationsForm myDonationsForm = new MyDonationsForm();
            myDonationsForm.ShowDialog();

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void LoadTotalDonation(int donorId)
        {
            string sql = @"SELECT ISNULL(SUM(Amount),0)
                   FROM Donation
                   WHERE DonorID = @donor AND Status = 'Completed'";

            try
            {
                using var conn = new SqlConnection(DBConnection.ConnectionString);
                using var cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@donor", donorId);

                conn.Open();
                decimal total = Convert.ToDecimal(cmd.ExecuteScalar());

                lbTotalDonation.Text = total.ToString("C");  // $1,250.00
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading total donation: " + ex.Message);
            }
        }

        private void LoadDonationCount(int donorId)
        {
            string sql = @"SELECT COUNT(*)
                   FROM Donation
                   WHERE DonorID = @donor";

            try
            {
                using var conn = new SqlConnection(DBConnection.ConnectionString);
                using var cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@donor", donorId);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                lblNumberOfDonations.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading donation count: " + ex.Message);
            }
        }

        private void LoadLastDonationDate(int donorId)
        {
            string sql = @"SELECT TOP 1 DonationDate
                   FROM Donation
                   WHERE DonorID = @donor
                   ORDER BY DonationDate DESC";

            try
            {
                using var conn = new SqlConnection(DBConnection.ConnectionString);
                using var cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@donor", donorId);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    lblLastDonationDate.Text = Convert.ToDateTime(result).ToString("MM/dd/yyyy");
                else
                    lblLastDonationDate.Text = "--/--/----";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading last donation date: " + ex.Message);
            }
        }


        private void LoadRecentCampaigns()
        {
            string sql = @"
        SELECT TOP 3 
            Title, 
            CreatedDate
        FROM Campaign
        WHERE Status = 'Active'
        ORDER BY CampaignID DESC";

            try
            {
                DataTable dt = new DataTable();

                using var conn = new SqlConnection(DBConnection.ConnectionString);
                using var cmd = new SqlCommand(sql, conn);
                using var da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                dgvRecentCampaigns.DataSource = dt;
                dgvRecentCampaigns.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading campaigns: " + ex.Message);
            }
        }

        private void btnCLear(object sender, EventArgs e)
        {
            dgvRecentCampaigns.DataSource = null;
            dgvRecentCampaigns.Rows.Clear();
            dgvRecentCampaigns.Refresh();

        }
    }
}

