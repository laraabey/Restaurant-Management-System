using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtuser.Text) || string.IsNullOrEmpty(txtpw.Text))
            {
                MessageBox.Show("Please fill in all the details", "Missing Details",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Connection string
            string cs = "Data Source=MANJULA; Initial Catalog=Restaurant_Management_System; Integrated Security=True";
            // Create and open connection
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            // Define the SQL query to check login credentials
            string sql = "SELECT * FROM loginUsers WHERE Username = @user AND Password = @pw";
            SqlCommand com = new SqlCommand(sql, con);

            // Pass parameters to the SQL query
            com.Parameters.AddWithValue("@user", txtuser.Text);
            com.Parameters.AddWithValue("@pw", txtpw.Text);

            // Execute the query
            SqlDataReader dr = com.ExecuteReader();

            // Check if any record matches
            if (dr.Read())
            {
                // If login is successful, show the dashboard
                formDashboard dashboard = new formDashboard();
                dashboard.Show();
                this.Hide();
            }

            else
            {
                // If no matching record, show error message
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Close the connection and cleanup
            con.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtpw.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void reg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }
    }
}

    