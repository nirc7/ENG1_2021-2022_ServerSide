using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSayHello_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            name = "Hello " + name;
            lblResult.Text = name;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            lblResult.Text = comboBox1.SelectedIndex + ", " + comboBox1.SelectedItem;
        }

        private void btn2_MouseEnter(object sender, EventArgs e)
        {
            btn2.BackColor = Color.Green;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lblResult.Text = comboBox1.SelectedIndex + ", " + comboBox1.SelectedItem;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            lblResult.Text = monthCalendar1.SelectionStart.ToShortDateString() + ", " + 
                DateTime.Now.ToLongTimeString();

            DateTime dt = new DateTime(2020,7,7);
        }
    }
}
