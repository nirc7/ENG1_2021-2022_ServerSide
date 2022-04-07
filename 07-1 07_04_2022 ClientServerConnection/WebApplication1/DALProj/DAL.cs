using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProj
{
    static public class DAL
    {
        static string conStr = @"Data Source=LAB-M00\SQLLAB;Initial Catalog=DBStudents;Integrated Security=True";
        static SqlConnection con;

        static DAL()
        {
            con = new SqlConnection(conStr);
        }

        static public Student LoginStudent(PartlyStudentDetailsLogin value)
        {
            try
            {
                SqlDataReader reader = ExcQ(
                        $" SELECT * FROM TBStudents " +
                        $" WHERE Email='{value.Email}' and  Password='{value.Password}'");

                if (reader.Read())
                {
                    Student s2return = new Student()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Email = value.Email,
                        Password = value.Password
                    };
                    return s2return;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        private static SqlDataReader ExcQ(string command)
        {
            con.Open();
            SqlCommand comm = new SqlCommand(command, con);
            SqlDataReader reader = comm.ExecuteReader();
            return reader;
        }
    }

    public class Student : PartlyStudentDetailsLogin
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class PartlyStudentDetailsLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
