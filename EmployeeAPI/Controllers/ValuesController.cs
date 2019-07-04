using EmployeeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace EmployeeAPI.Controllers
{
    [System.Web.Http.Route("api/employees")]
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet()]
        public ActionResult GetEmployees()
        {
            return Ok(EmployeeRepository.AddEmployeeViaCSV);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
