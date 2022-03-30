using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/RWstudents")]
    public class RWStudentsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GiveMeAllStudents()
        {
            try
            {
                //throw new ArithmeticException("go to school!");
                return Ok(StudentsDBMock.students);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
                //return BadRequest("in Get All Function " + ex.Message);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Student student2return = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
                if (student2return != null)
                {
                    return Ok(student2return);
                }
                return Content(HttpStatusCode.NotFound, $"student with id={id} was not found in Get!");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("{isAvi:bool}")]
        public IHttpActionResult Get(bool isAvi)
        {
            try
            {
                Student student2return = StudentsDBMock.students.FirstOrDefault(
                    stu => isAvi ? stu.Name == "avi" : stu.Name != "avi");
                if (student2return != null)
                {
                    return Ok(student2return);
                }
                return Content(HttpStatusCode.NotFound, $"student with id={isAvi} was not found in Get!");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
        [Route("{id}/grade")]
        [Route("~/g/{id}")]
        public IHttpActionResult GetGrade4StudentId(int id)
        {
            try
            {
                Student student2return = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
                if (student2return != null)
                {
                    return Ok(student2return.Grade);
                }
                return Content(HttpStatusCode.NotFound, $"student with id={id} was not found in Get!");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        public IHttpActionResult Post([FromBody] Student value)
        {
            try
            {
                int max = StudentsDBMock.students.Max(stu => stu.ID);
                value.ID = max + 1;
                StudentsDBMock.students.Add(value);
                return Created(new Uri(Request.RequestUri.AbsoluteUri + value.ID), value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put(int id, [FromBody] Student value)
        {
            try
            {
                Student student2Update = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
                if (student2Update == null)
                {
                    return Content(HttpStatusCode.NotFound, $"student with id={id} was not found 4 update!");
                }
                student2Update.Name = value.Name;
                student2Update.Grade = value.Grade;
                return Ok(student2Update);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Student student2Delete = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
                if (student2Delete != null)
                {
                    StudentsDBMock.students.Remove(student2Delete);
                    return Content(HttpStatusCode.OK, id);
                }
                return Content(HttpStatusCode.NotFound, $"student with id={id} was not found 4 delete!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
