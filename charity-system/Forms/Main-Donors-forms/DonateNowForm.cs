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

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Donation_now_Load(object sender, EventArgs e)
        {

        }
    }
}
