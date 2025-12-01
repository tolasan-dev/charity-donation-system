using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using charity_system.config;
using Microsoft.Data.SqlClient;

namespace charity_system.Forms.Main_Donors_forms
{
    public partial class MyDonationsForm : Form
    {
        public MyDonationsForm()
        {
            InitializeComponent();
            this.Load += MyDonationsForm_Load;
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close()
            LoginForm lg = new LoginForm();
            lg.Show();
            Dispose();

        }

        private void Donor_Main(object sender, EventArgs e)
        {

            DonorMainForm dn = new DonorMainForm();
            dn.Show();
            Dispose();
        }

        private void Donation_now(object sender, EventArgs e)
        {
            DonateNowForm dn = new DonateNowForm();
            dn.Show();
            Dispose();

        }

        private void Profile_Click(object sender, EventArgs e)
        {
            MyProfileForm mp = new MyProfileForm();
            mp.Show();
            Dispose(true);

        }

        private void MyDonationsForm_Load(object sender, EventArgs e)
        {
            if (CurrentUser.DonorID == null)
            {
                MessageBox.Show("Donor not logged in.");
                return;
            }

            int donorID = CurrentUser.DonorID.Value;

            string sql = @"
        SELECT 
            d.DonationID,
            d.DonationDate,
            c.Title AS Campaign,
            pm.MethodName AS PaymentMethod,
            d.Amount,
            d.Status,
            ISNULL(r.ReceiptNumber, 'N/A') AS Receipt
        FROM Donation d
        JOIN Campaign c ON d.CampaignID = c.CampaignID
        JOIN PaymentMethod pm ON d.PaymentMethodID = pm.PaymentMethodID
        LEFT JOIN DonationReceipt r ON d.DonationID = r.DonationID
        WHERE d.DonorID = @donorID
        ORDER BY d.DonationDate DESC;
    ";

            try
            {
                DataTable dt = new DataTable();

                using var conn = new SqlConnection(DBConnection.ConnectionString);
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@donorID", donorID);

                conn.Open();
                dt.Load(cmd.ExecuteReader());

                dgvDonations.DataSource = dt;


                // Format table
                dgvDonations.Columns["Amount"].DefaultCellStyle.Format = "C";
                dgvDonations.Columns["DonationDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvDonations.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading donations: " + ex.Message);
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            dgvDonations.DataSource = null;
            dgvDonations.Rows.Clear();
            dgvDonations.Refresh();
        }
    }
}
