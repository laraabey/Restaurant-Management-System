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
using System.Xml.Linq;

namespace Restaurant_Management_System
{
    public partial class formCust : Form
    {
        private string cs = @"Data Source=MANJULA; Initial Catalog=Restaurant_Management_System; Integrated Security=True";

        public formCust()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) || string.IsNullOrWhiteSpace(txtemail.Text) || string.IsNullOrWhiteSpace(txtmob.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "INSERT INTO tblCustomer (Name, Email, MobileNumber) VALUES (@Name, @Email, @MobileNumber)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                cmd.Parameters.AddWithValue("@MobileNumber", txtmob.Text);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            ClearFields();
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns.Add("Email", "Email");
                dataGridView1.Columns.Add("MobileNumber", "Mobile Number");
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT Name, Email, MobileNumber FROM tblCustomer"; // Select specific columns
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Name"], reader["Email"], reader["MobileNumber"]);
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("Please search for a customer to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "UPDATE tblCustomer SET Name = @Name, MobileNumber = @MobileNumber WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@MobileNumber", txtmob.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            ClearFields();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtemail.Text))
            {
                MessageBox.Show("Please search for a customer to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "DELETE FROM tblCustomer WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string customerEmail = txtCID.Text;

            if (string.IsNullOrWhiteSpace(customerEmail))
            {
                MessageBox.Show("Please enter a valid Customer Email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT * FROM tblCustomer WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", customerEmail);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtname.Text = reader["Name"].ToString();
                    txtemail.Text = reader["Email"].ToString();
                    txtmob.Text = reader["MobileNumber"].ToString();
                }
                else
                {
                    MessageBox.Show("Customer not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ClearFields()
        {
            txtname.Clear();
            txtemail.Clear();
            txtmob.Clear();
            txtCID.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtemail.Clear();
            txtmob.Clear();
            txtCID.Clear();
        }
    }
}
