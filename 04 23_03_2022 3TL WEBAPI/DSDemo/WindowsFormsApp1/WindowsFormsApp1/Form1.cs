using BALProject;
using DALProject;
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
        DataSet ds = new DataSet();
        DataTable dt;
        SqlDataAdapter adptr;

        public Form1()
        {
            InitializeComponent();
        }



        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();

            dr["ID"] = 7;
            dr["Name"] = txtName.Text;
            dr["Family"] = txtFamily.Text;

            dt.Rows.Add(dr);
        }

        private void btnUpdateFromDS2Sql_Click(object sender, EventArgs e)
        {
            new SqlCommandBuilder(adptr);
            adptr.Update(dt);
        }

        private void btnGetUsersFromSql_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BALServices.GetALLUsers(7);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<User> users = BALServices.DeleteUser(int.Parse(txtId.Text));
            dataGridView1.DataSource = users;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState != DataRowState.Deleted && row["Id"].ToString() == txtId.Text)
                {
                    row["Name"] = txtName.Text;
                    row["Family"] = txtFamily.Text;
                }
            }
        }

        private void btnFamilySP_Click(object sender, EventArgs e)
        {
            string conStr = @"Data Source=LAB-C00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True";
            SqlConnection myCon = new SqlConnection(conStr);

            SqlCommand MySPCommand = new SqlCommand("SearchUser", myCon);
            MySPCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parID = new SqlParameter("@MyID", SqlDbType.Int);
            parID.Direction = ParameterDirection.Input;
            parID.Value = int.Parse(txtId.Text);

            SqlParameter parFName = new SqlParameter("@FamilyName", SqlDbType.NVarChar, 20);
            parFName.Direction = ParameterDirection.Output;

            SqlParameter parErr = new SqlParameter();
            parErr.Direction = ParameterDirection.ReturnValue;

            MySPCommand.Parameters.Add(parID);
            MySPCommand.Parameters.Add(parFName);
            MySPCommand.Parameters.Add(parErr);

            myCon.Open();
            MySPCommand.ExecuteNonQuery();
            myCon.Close();

            if (parErr.Value.ToString() == "0")
            {
                MessageBox.Show(parFName.Value.ToString());
            }
        }

        private void btnTableFromSP_Click(object sender, EventArgs e)
        {
            string conStr = @"Data Source=LAB-C00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True";
            SqlConnection myCon = new SqlConnection(conStr);

            SqlCommand MySPCommand = new SqlCommand("SearchUserTable", myCon);
            MySPCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parID = new SqlParameter("@MyID", SqlDbType.Int);
            parID.Direction = ParameterDirection.Input;
            parID.Value = int.Parse(txtId.Text);

            MySPCommand.Parameters.Add(parID);

            SqlDataAdapter adptr = new SqlDataAdapter(MySPCommand);
            ds.Clear();
            adptr.Fill(ds, "Users");
            dt = ds.Tables["Users"];
            dataGridView1.DataSource = dt;
        }
    }
}
