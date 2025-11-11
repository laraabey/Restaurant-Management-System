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
using System.IO;
using System.Drawing.Imaging;

namespace Restaurant_Management_System
{
    public partial class formProd : Form
    {
        string cs = "Data Source=MANJULA; Initial Catalog=Restaurant_Management_System; Integrated Security=True";

        public formProd()
        {
            InitializeComponent();
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {

            SqlConnection con = new SqlConnection(cs);
            con.Open();

            string sql = "SELECT ProdID, Name, Price, Descrip FROM tblProd";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dap.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }
        private void btnupload_Click(object sender, EventArgs e)
        {
            {
                // Create and configure the OpenFileDialog
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Select an Image";

                // Show the dialog and check if the user selected a file
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Display the selected file path (optional)
                    txtImagePath.Text = ofd.FileName;
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPID.Text))
            {
                MessageBox.Show("Enter Product ID!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string query = "SELECT ProdID, Name, Price, Descrip FROM tblProd WHERE ProdID = @ProdID";
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Use the text from the search input field
                    cmd.Parameters.AddWithValue("@ProdID", txtPID.Text);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Display the data in the respective fields
                        txtProdID.Text = reader["ProdID"].ToString();
                        txtname.Text = reader["Name"].ToString();
                        txtprice.Text = reader["Price"].ToString();
                        txtdescrip.Text = reader["Descrip"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Product not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    con.Close();
                }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (string.IsNullOrWhiteSpace(txtProdID.Text) || string.IsNullOrWhiteSpace(txtname.Text) ||
                    string.IsNullOrWhiteSpace(txtprice.Text) || string.IsNullOrWhiteSpace(txtdescrip.Text))
                {
                    MessageBox.Show("All fields are mandatory!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {
                    string query = "INSERT INTO tblProd (ProdID, Name, Price, Descrip, Image) VALUES (@ProdID, @Name, @Price, @Descrip, @Image)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@ProdID", txtProdID.Text);
                    cmd.Parameters.AddWithValue("@Name", txtname.Text);
                    cmd.Parameters.AddWithValue("@Price", txtprice.Text);
                    cmd.Parameters.AddWithValue("@Descrip", txtdescrip.Text);

                    // Add Image
                    if (!string.IsNullOrEmpty(txtImagePath.Text))
                    {
                        byte[] imageData = File.ReadAllBytes(txtImagePath.Text);
                        cmd.Parameters.AddWithValue("@Image", imageData);
                    }
                    else
                    {
                        MessageBox.Show("Add an image.", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product added successfully!");
                    clear();
                }
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "UPDATE tblProd SET Name = @Name, Price = @Price, Descrip = @Descrip, Image = @Image WHERE ProdID = @ProdID";
                SqlCommand cmd = new SqlCommand(query, con);

                // Add parameters with explicit types
                cmd.Parameters.AddWithValue("@ProdID", txtProdID.Text);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Price", txtprice.Text);
                cmd.Parameters.AddWithValue("@Descrip", txtdescrip.Text);

                // Handle the image parameter explicitly
                if (!string.IsNullOrEmpty(txtImagePath.Text))
                {
                    byte[] imageData = File.ReadAllBytes(txtImagePath.Text);
                    SqlParameter imageParameter = new SqlParameter("@Image", SqlDbType.VarBinary);
                    imageParameter.Value = imageData;
                    cmd.Parameters.Add(imageParameter);
                }
                else
                {
                    SqlParameter imageParameter = new SqlParameter("@Image", SqlDbType.VarBinary);
                    imageParameter.Value = DBNull.Value;
                    cmd.Parameters.Add(imageParameter);
                }

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Product updated successfully!");
                clear();
            }
        }

        private void clear()
        {
            // Clear the input fields
            txtname.Text = "";
            txtPID.Text = "";
            txtdescrip.Text = "";
            txtImagePath.Text = "";
            txtProdID.Text = "";
            txtprice.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtPID.Text = "";
            txtdescrip.Text = "";
            txtImagePath.Text = "";
            txtProdID.Text = "";
            txtprice.Text = "";
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            // Validate if Product ID is provided
            if (string.IsNullOrWhiteSpace(txtProdID.Text))
            {
                MessageBox.Show("Please enter a Product ID to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string productId = txtProdID.Text;

            // Database connection string
            string cs = @"Data Source=MANJULA; Initial Catalog=Restaurant_Management_System; Integrated Security=True";

            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();
                    // SQL query to delete the product by Product ID
                    string query = "DELETE FROM tblProd WHERE ProdID = @ProdID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ProdID", productId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the dashboard
                        RefreshDashboard();

                        // Clear input fields
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Product not found. Please check the Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void RefreshDashboard()
        {
            // Clear existing controls
            foreach (Control control in this.Controls.OfType<UserControl_ProductItem>().ToList())
            {
                this.Controls.Remove(control);
            }

            // Reload data
            LoadData();
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtprice.Text, "^[0-9]*$"))
            {
                txtprice.Text = string.Empty;
            }
        }

        private void txtPID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
