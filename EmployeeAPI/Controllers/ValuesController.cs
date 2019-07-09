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
    public class EmployeesController : ApiController
    {

        [HttpGet()]
        // GET api/values/
        public IHttpActionResult GetEmployees()
        {
            //return Ok();
            var employees = EmployeeRepository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet()]
        public IHttpActionResult GetOneEmployer(int id)
        {
            var employeeToReturn = EmployeeRepository.GetAllEmployees().FirstOrDefault(e => e.EmployeeID == id);
            //if (employeeToReturn == null)
            //{
            //    return NotFound();
            //}
            return Ok(employeeToReturn);
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
