using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System
{
    public partial class formDashboard : Form
    {
        public formDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Hide the current form (formDashboard)
                this.Hide();

                // Show the login form
                formLogin loginForm = new formLogin();
                loginForm.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           AddControls(new formStaff());
        }

        private void AddControls(Form f)
        {
            panel3.Controls.Clear();
            f.Dock= DockStyle.Fill; 
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.Show();
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void btndash_Click(object sender, EventArgs e)
        {
            AddControls(new formDash());
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            AddControls(new formProd());
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            AddControls(new formReports());
        }

        private void btncus_Click(object sender, EventArgs e)
        {
            AddControls(new formCust());
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
