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

            if (CurrentUser.DonorID != null)
            {
                LoadDonorName(CurrentUser.DonorID.Value);
            }
            else if (CurrentUser.DonorID == null)
            {
                MessageBox.Show("Please log in to access donation features.", "Not Logged In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Donation_now_Load(object sender, EventArgs e)
        {

            LoadCampaigns();
            LoadPaymentMethods();
            UpdateDonationSummary();


        }


        // fetch donor name profile 
        private void LoadDonorName(int donorId)
        {
            string sql = "SELECT FullName FROM Donor WHERE DonorID = @id";

            using var conn = new SqlConnection(DBConnection.ConnectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", donorId);

            conn.Open();
            var result = cmd.ExecuteScalar();

            if (result != null)
                lbdonorProfile.Text = result.ToString();
            else
                lbdonorProfile.Text = "Unknown Donor";
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();

        }


        private void LoadPaymentMethods()
        {
            string sql = "SELECT PaymentMethodID, MethodName FROM PaymentMethod";

            try
            {
                using var conn = new SqlConnection(DBConnection.ConnectionString);
                using var cmd = new SqlCommand(sql, conn);

                conn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                cmbPaymentMethod.DataSource = dt;
                cmbPaymentMethod.DisplayMember = "MethodName";
                cmbPaymentMethod.ValueMember = "PaymentMethodID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payment methods: " + ex.Message);
            }
        }





        private void btndonation_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            int donorId = CurrentUser.DonorID.Value;
            int campaignId = (int)cmbCampaign.SelectedValue;
            int paymentMethodId = (int)cmbPaymentMethod.SelectedValue;
            decimal amount = Convert.ToDecimal(txtAmount.Text);

            try
            {
                int donationId = InsertDonation(donorId, campaignId, amount, paymentMethodId);
                string receipt = InsertReceipt(donationId);

                MessageBox.Show(
                    $"Donation Successful!\nReceipt: {receipt}",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                //txtAmount.Clear();
                UpdateDonationSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting donation: " + ex.Message);
            }
        }




        private void UpdateDonationSummary()
        {
            // Campaign
            if (cmbCampaign.SelectedItem != null)
                lblSummaryCampaign.Text = cmbCampaign.Text;
            else
                lblSummaryCampaign.Text = "-";

            // Payment Method
            if (cmbPaymentMethod.SelectedItem != null)
                lblSummaryPaymentMethod.Text = cmbPaymentMethod.Text;
            else
                lblSummaryPaymentMethod.Text = "-";

            // Amount + Total
            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                lblSummaryAmount.Text = amount.ToString("C");  // Format as $120.00
                lblSummaryTotal.Text = amount.ToString("C");   // Total = Amount
            }
            else
            {
                lblSummaryAmount.Text = "$0.00";
                lblSummaryTotal.Text = "$0.00";
            }
        }



        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            UpdateDonationSummary();
        }

        private void cmbCampaign_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDonationSummary();
        }

        private void cmbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDonationSummary();
        }




        private bool ValidateForm()
        {
            if (cmbCampaign.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a campaign.");
                return false;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Invalid donation amount.");
                return false;
            }

            if (cmbPaymentMethod.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a payment method.");
                return false;
            }

            return true;
        }



        private int InsertDonation(int donorId, int campaignId, decimal amount, int paymentMethodId)
        {
            string sql = @"
        INSERT INTO Donation 
            (DonorID, CampaignID, Amount, PaymentMethodID, DonationDate, Status)
        OUTPUT INSERTED.DonationID
        VALUES 
            (@donor, @campaign, @amount, @payment, GETDATE(), 'Completed')";

            using var conn = new SqlConnection(DBConnection.ConnectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@donor", donorId);
            cmd.Parameters.AddWithValue("@campaign", campaignId);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@payment", paymentMethodId);

            conn.Open();
            return (int)cmd.ExecuteScalar();
        }



        // Insert donation into the database


        private string InsertReceipt(int donationId)
        {
            string receipt = "RCPT-" + DateTime.Now.ToString("yyyyMMddHHmmss");

            string sql = @"INSERT INTO DonationReceipt (DonationID, ReceiptNumber)
                           VALUES (@id, @receipt)";

            using var conn = new SqlConnection(DBConnection.ConnectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", donationId);
            cmd.Parameters.AddWithValue("@receipt", receipt);

            conn.Open();
            cmd.ExecuteNonQuery();

            return receipt;
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


        private void LoadCampaigns()
        {
            string sql = "SELECT CampaignID, Title FROM Campaign WHERE Status = 'Active'";

            try
            {
                using var conn = new SqlConnection(DBConnection.ConnectionString);
                using var cmd = new SqlCommand(sql, conn);

                conn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                cmbCampaign.DataSource = dt;
                cmbCampaign.DisplayMember = "Title";
                cmbCampaign.ValueMember = "CampaignID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading campaigns: " + ex.Message);
            }
        }

        private void cmbCampaign_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateDonationSummary();
        }

        private void txtAmount_TextChanged_1(object sender, EventArgs e)
        {
            UpdateDonationSummary();
        }

        private void cmbPaymentMethod_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateDonationSummary();
        }
    }
}
