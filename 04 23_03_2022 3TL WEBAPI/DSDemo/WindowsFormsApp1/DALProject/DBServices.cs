using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public static class DALDBServices
    {
        static DataSet ds = new DataSet();
        static DataTable dt;
        static SqlDataAdapter adptr;

        public static List<User> DeleteUser(int userid) {

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].RowState != DataRowState.Deleted && (int)dt.Rows[i]["Id"] == userid)
                {
                    dt.Rows[i].Delete();
                    i--;
                }
            }

            List<User> users = new List<User>();

            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    users.Add(new User()
                    {
                        ID = (int)row["ID"],
                        Name = (string)row["Name"],
                        Family = (string)row["Family"]
                    });
                }
            }

            return users;

            //foreach (DataRow row in dt.Rows)
            //{
            //    if (row["Id"].ToString() == txtId.Text)
            //    {
            //        row.Delete();
            //    }
            //}
        }

        public static List<User> GetALLUsers()
        {
            string conStr = @"Data Source=LAB-C00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            adptr = new SqlDataAdapter("SELECT * FROM TBUsers", con);
            ds.Clear();
            adptr.Fill(ds, "Users");
            dt = ds.Tables["Users"];

            List<User> users = new List<User>();

            foreach (DataRow row in dt.Rows)
            {
                users.Add(new User()
                {
                    ID = (int)row["ID"],
                    Name = (string)row["Name"],
                    Family = (string)row["Family"]
                });
            }

            return users;
        }
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
