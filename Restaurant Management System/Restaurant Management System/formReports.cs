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
    public partial class formReports : Form
    {
        string cs = "Data Source=MANJULA\\MSSQLSERVER01; Initial Catalog=Restaurant_Management_System; Integrated Security=True";

        public formReports()
        {
            InitializeComponent();
        }

        private void btnstaff_Click(object sender, EventArgs e)
        {
            AddControls(new formStaffReport());
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            AddControls(new formProdReport());
        }

        private void AddControls(Form f)
        {
            panel1.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void formReports_Load(object sender, EventArgs e)
        {

        }
    }
}
