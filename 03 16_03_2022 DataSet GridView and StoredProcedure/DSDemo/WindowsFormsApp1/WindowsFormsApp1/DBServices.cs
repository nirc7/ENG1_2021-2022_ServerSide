using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    static class DBServices
    {
        static DataSet ds = new DataSet();
        static DataTable dt;
        static SqlDataAdapter adptr;

        public static DataTable GetALLUsers()
        {
            string conStr = @"Data Source=LAB-C00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            adptr = new SqlDataAdapter("SELECT * FROM TBUsers", con);
            ds.Clear();
            adptr.Fill(ds, "Users");
            dt = ds.Tables["Users"];
            return dt;
        }
    }
}
