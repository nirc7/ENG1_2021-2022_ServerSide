using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentsController : ApiController
    {
        public IEnumerable<Student> Get() 
        {
            return StudentsDBMock.students.ToArray();
        }

        public Student Get(int id)
        {
            return StudentsDBMock.students.FirstOrDefault(stu=> stu.ID == id);
        }

        public int Post([FromBody] Student value) 
        {
            int max = StudentsDBMock.students.Max(stu=> stu.ID);
            value.ID = max + 1;
            StudentsDBMock.students.Add(value);
            return value.ID;
        }

        public string Put(int id, [FromBody] Student value) 
        {
            Student studetn2update = StudentsDBMock.students.FirstOrDefault(stu=> stu.ID== id);
            studetn2update.Name = value.Name;
            studetn2update.Grade = value.Grade;
            return "done:)";
        }

        public IHttpActionResult Delete(int id)
        {
            Student student2Delete = StudentsDBMock.students.SingleOrDefault(stu=> stu.ID==id);
            StudentsDBMock.students.Remove(student2Delete);
            var jRes = new { Result="deleted successfully!"};
            var res = Json(jRes);
            return res;
        }

    }
}
