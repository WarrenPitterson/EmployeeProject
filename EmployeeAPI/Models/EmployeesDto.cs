using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeAPI.Models
{
    public class EmployeesDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public DateTime StartDate { get; set; }
        public string Hometown { get; set; }
        public string  Department { get; set; }
    }
}