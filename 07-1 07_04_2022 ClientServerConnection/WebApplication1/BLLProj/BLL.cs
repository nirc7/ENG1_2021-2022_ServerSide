using DALProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLProj
{
    static public class BLL
    {
        static public Student GetStudent4Login(PartlyStudentDetailsLogin value)
        {
            return DAL.LoginStudent(value);
        }
    }


   
}
