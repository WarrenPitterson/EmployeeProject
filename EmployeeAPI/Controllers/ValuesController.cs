﻿using EmployeeAPI.Models;
using EmployeeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace EmployeeAPI.Controllers
{
    public class EmployeesController : ApiController
    {

        [HttpGet()]
        [Route("api/employees")]
        public IHttpActionResult GetEmployees()
        {
            var employees = EmployeeRepository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet()]
        [Route("api/employees/{id}")]
        public IHttpActionResult GetOneEmployee(int id)
        {
            var employeeToReturn = EmployeeRepository.GetAllEmployees().FirstOrDefault(e => e.EmployeeId == id);
            if (employeeToReturn == null)
            {
                return NotFound();
            }
            return Ok(employeeToReturn);
        }

        // POST api/values
        [HttpPost()]
        [Route("api/employees/")]
        public IHttpActionResult AddNewEmployee([FromBody]Employee employee)
        {
            EmployeeRepository.GetAllEmployees().Add(employee);

            if (!ModelState.IsValid)
                return BadRequest("Invalid Entry");

            return Ok(employee);

        }

        // PUT api/values/5
        [HttpPut()]
        [Route("api/employees/{id}")]
        public IHttpActionResult EditEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Entry");

            var employeeToEdit = EmployeeRepository.GetAllEmployees().FirstOrDefault(e => e.EmployeeId == id);

            if (employeeToEdit != null)
            {
                employeeToEdit.FirstName = employee.FirstName;
                employeeToEdit.LastName = employee.LastName;
            }

            else
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // DELETE api/values/5
        [HttpDelete()]
        [Route("api/employees/{id}")]
        public IHttpActionResult DeleteOneEmployee(int id)
        {
            var employeeToDelete = EmployeeRepository.GetAllEmployees().FirstOrDefault(e => e.EmployeeId == id);

            if (employeeToDelete == null)
            {
                return NotFound();
            }

            EmployeeRepository.employees.Remove(employeeToDelete);

            return Ok(employeeToDelete);
        }

        [HttpGet()]
        [Route("api/employees/Anniversaries")]
        public IHttpActionResult EmployeeMonthlyAnniversary(Employee employee)
        {
            var AnniversaryQuery = EmployeeRepository.GetAllEmployees().FindAll(e => e.Anniversary == true);  

            return Ok(AnniversaryQuery);
        }
}

}