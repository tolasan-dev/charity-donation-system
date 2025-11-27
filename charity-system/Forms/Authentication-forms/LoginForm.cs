using charity_system.Forms;
using Microsoft.Data.SqlClient;
using charity_system.config;


namespace charity_system
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Show a test message
            MessageBox.Show("Login Button Test - Starting Login...");

            // If empty inputs - quick test
            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            string query = @"SELECT UserID, RoleID, DonorID 
                     FROM [User]
                     WHERE UserName = @uname AND PasswordHash = @pass";

            using (SqlConnection conn = new SqlConnection("your_connection_string_here"))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@uname", username);
                cmd.Parameters.AddWithValue("@pass", password);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        int userID = dr.GetInt32(0);
                        int roleID = dr.GetInt32(1);
                        int? donorID = dr.IsDBNull(2) ? (int?)null : dr.GetInt32(2);

                        MessageBox.Show($"Login Success!\nUserID: {userID}\nRoleID: {roleID}");

                        // Save to Global User
                        CurrentUser.UserID = userID;
                        CurrentUser.RoleID = roleID;
                        CurrentUser.DonorID = donorID;

                        // Navigate based on role
                        if (roleID == 1)
                        {
                            MessageBox.Show("Redirecting to Admin Dashboard...");
                            new AdminDashboard_Form().Show();
                        }
                        else if (roleID == 2)
                        {
                            MessageBox.Show("Redirecting to Donor Dashboard...");
                            new DonorForm().Show();
                        }

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("❌ Invalid username or password");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
            }
        }

    }
}