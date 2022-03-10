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

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            ExcNQ(
                " INSERT INTO TBUsers(Name, Family) " +
               $" VALUES('{txtName.Text}', '{txtFamily.Text}')");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ExcNQ($@"   DELETE From TBUsers 
                        WHERE Id={txtId.Text} ");
        }

        private void ExcNQ(string command)
        {
            SqlConnection con = null;
            try
            {
                string conStr = @"Data Source=LAB-M00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True";
                con = new SqlConnection(conStr);

                SqlCommand comm = new SqlCommand(command, con);

                con.Open();
                int res = comm.ExecuteNonQuery();


                MessageBox.Show(res == 1 ? ":)" : ":(");
                RefreshLabelTable();
            }
            catch (Exception ex)
            {
                int.Parse("avi");
            }
            finally
            {
                con.Close();
            }
            Console.WriteLine("END");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ExcNQ(
                $" UPDATE TBUsers " +
                $" SET Name='{txtName.Text}' , Family='{txtFamily.Text}'" +
                $" WHERE Id={txtId.Text}");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            RefreshLabelTable();
        }

        private void RefreshLabelTable()
        {
            string conStr = @"Data Source=LAB-M00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand comm = new SqlCommand("SELECT * FROM TBUsers Order By Name Desc", con);
            lblTable.Text = "";

            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                lblTable.Text += reader["ID"].ToString() + ", " + (string)reader["Name"] + ", " + reader[2] + "\n";
            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshLabelTable();
        }
    }
}
