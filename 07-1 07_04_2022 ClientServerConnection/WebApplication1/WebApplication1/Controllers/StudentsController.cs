using BLLProj;
using DALProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class StudentsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Login([FromBody] PartlyStudentDetailsLogin value)
        {
            try
            {
                Student stuednt4Login = BLL.GetStudent4Login(value);
                if (stuednt4Login != null)
                {
                    return Ok(stuednt4Login);
                }
                return Content(HttpStatusCode.NotFound, $"studfent with email={value.Email} was not found in Login!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

  
}
