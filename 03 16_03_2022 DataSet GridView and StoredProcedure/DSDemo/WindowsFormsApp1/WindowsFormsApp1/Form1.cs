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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adptr;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conStr = @"Data Source=LAB-B00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            adptr = new SqlDataAdapter("SELECT * FROM TBUsers",con);
            ds = new DataSet();
            adptr.Fill(ds, "Users");
            dt = ds.Tables["Users"];
            dataGridView1.DataSource = dt;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();

            dr["ID"] = 7;
            dr["Name"] = txtName.Text;
            dr["Family"] = txtFamily.Text;

            dt.Rows.Add(dr);
        }
    }
}
