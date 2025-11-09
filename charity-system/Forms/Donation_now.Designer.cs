namespace charity_system.Forms
{
    partial class Donation_now
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            listView1 = new ListView();
            listView2 = new ListView();
            listView3 = new ListView();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.Location = new Point(54, 41);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(190, 39);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "Donation Now";
            // 
            // guna2ComboBox1
            // 
            guna2ComboBox1.BackColor = Color.Transparent;
            guna2ComboBox1.CustomizableEdges = customizableEdges3;
            guna2ComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            guna2ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            guna2ComboBox1.FocusedColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2ComboBox1.Font = new Font("Segoe UI", 10F);
            guna2ComboBox1.ForeColor = Color.FromArgb(68, 88, 112);
            guna2ComboBox1.ItemHeight = 30;
            guna2ComboBox1.Location = new Point(54, 116);
            guna2ComboBox1.Name = "guna2ComboBox1";
            guna2ComboBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2ComboBox1.Size = new Size(588, 36);
            guna2ComboBox1.TabIndex = 2;
            // 
            // listView1
            // 
            listView1.Location = new Point(54, 182);
            listView1.Name = "listView1";
            listView1.Size = new Size(588, 89);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // listView2
            // 
            listView2.Location = new Point(52, 301);
            listView2.Name = "listView2";
            listView2.Size = new Size(588, 89);
            listView2.TabIndex = 4;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView3
            // 
            listView3.Location = new Point(54, 418);
            listView3.Name = "listView3";
            listView3.Size = new Size(588, 89);
            listView3.TabIndex = 5;
            listView3.UseCompatibleStateImageBehavior = false;
            // 
            // Donation_now
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 691);
            Controls.Add(listView3);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(guna2ComboBox1);
            Controls.Add(guna2HtmlLabel1);
            Name = "Donation_now";
            Text = "Donation_now";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private ListView listView1;
        private ListView listView2;
        private ListView listView3;
    }
}