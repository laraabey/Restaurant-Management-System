using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Restaurant_Management_System
{
    public partial class UserControl_ProductItem : UserControl
    {
        public UserControl_ProductItem(string name, string price, Image img)
        {
            InitializeComponent();

            textBox_name1.Text = name;
            textBox_price1.Text = price;
            if (img != null)
            {
                pictureBox1.Image = img;
            }
        }
    }
}
