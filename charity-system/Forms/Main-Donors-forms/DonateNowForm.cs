using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using charity_system.config;
using charity_system.Forms.Main_Donors_forms;


namespace charity_system.Forms
{
    public partial class DonateNowForm : Form



    {
        public DonateNowForm()
        {
            InitializeComponent();

            this.BackColor = Color.White;           // Already good
                                                    // Change to any color you want:
            this.BackColor = Color.FromArgb(240, 248, 255);  // Light blue (AliceBlue)
                                                             // or
            this.BackColor = Color.SkyBlue;
            // or
            this.BackColor = ColorTranslator.FromHtml("#F0F8FF");  // HTML color

            this.Load += Donation_now_Load;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Donation_now_Load(object sender, EventArgs e)
        {
            //LoadDonorInfo();
            //LoadCampaigns();
            //LoadPaymentMethods();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void LoadDonorInfo(object sender, PaintEventArgs e)
        {

            if (CurrentUser.DonorID == null)
                return;

            string sql = "SELECT FullName, Email, DonorType FROM Donor WHERE DonorID = @id";

            try
            {
                using var conn = new SqlConnection(DBConnection.ConnectionString);
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", CurrentUser.DonorID);

                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblDonorName.Text = reader["FullName"].ToString();
                    lblDonorEmail.Text = reader["Email"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading donor info: " + ex.Message);
            }
        }


        private void LoadCampaignSummaryFromDB()
        {
            if (cmbCampaign.SelectedValue == null)
                return;

            string sql = @"
        SELECT c.Title, c.Description, org.Name AS OrgName
        FROM Campaign c
        JOIN Organization org ON c.OrganizationID = org.OrganizationID
        WHERE c.CampaignID = @id";

            try
            {
                using var conn = new SqlConnection(DBConnection.ConnectionString);
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", cmbCampaign.SelectedValue);

                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblSummaryCampaign.Text = reader["Title"].ToString();
                    //lblSummaryOrgName.Text = reader["OrgName"].ToString();
                    //lblSummaryCampaignDesc.Text = reader["Description"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading campaign details: " + ex.Message);
            }
        }

        private void btndonation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for your donation!");
        }

        private void DonorMain_btn(object sender, EventArgs e)
        {
            DonorMainForm mn = new DonorMainForm();
            mn.Show();
            Dispose();
        }

        private void Donation_btn(object sender, EventArgs e)
        {
            DonateNowForm donateNowForm = new DonateNowForm();
            donateNowForm.Show();
            Dispose();
        }

        private void My_Donation_btn(object sender, EventArgs e)
        {
            MyDonationsForm md = new MyDonationsForm();
            md.Show();
            Dispose();
        }

        private void My_Profile_btn(object sender, EventArgs e)
        {
            MyProfileForm myProfileForm = new MyProfileForm();
            myProfileForm.Show();
            Dispose();
        }
    }
}
