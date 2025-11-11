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
    public partial class formStaff : Form
    {
        string cs = "Data Source=MANJULA; Initial Catalog=Restaurant_Management_System; Integrated Security=True";
        public formStaff()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void formStaff_Load(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "DELETE FROM tblStaff WHERE StaffID = @StaffID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StaffID", txtSID.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clear();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSID.Text))
            {
                MessageBox.Show("Enter Staff ID!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    // Query to search for a record by StaffID
                    string query = "SELECT * FROM tblStaff WHERE StaffID = @StaffID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StaffID", txtSID.Text);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Populate fields with data from the database
                                txtname.Text = reader["Name"].ToString();
                                txtid.Text = reader["StaffID"].ToString();
                                cmbtype.Text = reader["Type"].ToString();
                                txtnum.Text = reader["MobileNumber"].ToString();
                                txtnic.Text = reader["NIC"].ToString();
                                txtaddr.Text = reader["Address"].ToString();
                            }
                            // MessageBox.Show("Staff record found", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record found with the provided StaffID.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) || string.IsNullOrWhiteSpace(txtaddr.Text) || string.IsNullOrWhiteSpace(txtid.Text) || string.IsNullOrWhiteSpace(txtnic.Text) || string.IsNullOrWhiteSpace(txtnum.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string query = "INSERT INTO tblStaff (StaffID, Name, Type, MobileNumber, NIC, Address) VALUES (@StaffID, @Name, @Type, @MobileNumber, @NIC, @Address)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StaffID", txtid.Text);
                    cmd.Parameters.AddWithValue("@Name", txtname.Text);
                    cmd.Parameters.AddWithValue("@Type", cmbtype.Text);
                    cmd.Parameters.AddWithValue("@MobileNumber", txtnum.Text);
                    cmd.Parameters.AddWithValue("@NIC", txtnic.Text);
                    cmd.Parameters.AddWithValue("@Address", txtaddr.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff added successfully.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "UPDATE tblStaff SET Name = @Name, Type = @Type, MobileNumber = @MobileNumber, NIC = @NIC, Address = @Address WHERE StaffID = @StaffID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StaffID", txtid.Text);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Type", cmbtype.Text);
                cmd.Parameters.AddWithValue("@MobileNumber", txtnum.Text);
                cmd.Parameters.AddWithValue("@NIC", txtnic.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddr.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff updated successfully.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
        }

        private void clear()
            {
            // Clear the input fields
                txtSID.Text = "";
                txtid.Text = "";
                txtname.Text = "";
                cmbtype.Text = "";
                txtnum.Text = "";
                txtnic.Text = "";
                txtaddr.Text = "";
            }

        private void btnload_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn= new SqlConnection(cs))
            {
                conn.Open();

                string query = "SELECT * FROM tblStaff";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet(); 
                dap.Fill(ds);

                this.dataGridView1.DataSource = ds.Tables[0];

                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                // Clear the input fields
                txtSID.Text = "";
                txtid.Text = "";
                txtname.Text = "";
                cmbtype.Text = "";
                txtnum.Text = "";
                txtnic.Text = "";
                txtaddr.Text = "";
            
        }
    }
}
