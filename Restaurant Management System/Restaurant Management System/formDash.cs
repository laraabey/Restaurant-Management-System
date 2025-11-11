using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System
{
    public partial class formDash : Form
    {
        public formDash()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void LoadData()
        {
            string cs = @"Data Source=MANJULA; Initial Catalog=Restaurant_Management_System; Integrated Security=True"; ;
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            string sql = "SELECT * FROM tblProd";
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader reader = com.ExecuteReader();

            int index = 0;
            while (reader.Read())
            {
                // Assuming two product panels
                //if (index == 0)
                {
                    Image img = null;

                    if (!reader.IsDBNull(reader.GetOrdinal("image")))
                    {
                        var imgData = (byte[])reader["image"]; // Assuming the "image" column contains a byte array
                        using (MemoryStream ms = new MemoryStream(imgData))
                        {
                            img = Image.FromStream(ms);
                        }
                    }

                    UserControl_ProductItem item = new UserControl_ProductItem(reader["Name"].ToString(), "Rs." + reader["Price"].ToString(), img);
                    // Calculate the position for each item
                    int column = index % 2; // 0 for the first column, 1 for the second column
                    int row = index / 2;    // Controls the vertical position

                    // Set the position: alternate between the two columns and new rows
                    item.Location = new Point(50 + (column * 350), 50 + (row * 150));
                    item.Name = "name_" + index;
                    this.Controls.Add(item);
                }

                index++;
            }


        }

        private void formDash_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
