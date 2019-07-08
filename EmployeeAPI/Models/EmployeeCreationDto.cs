using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeAPI.Models
{
    public class EmployeeCreationDto
    {
        [Required (ErrorMessage = "You should have a valid name")]
        [MaxLength(20)]
        public string Firstname { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [MaxLength(10)]
        public DateTime Dob { get; set; }

        [MaxLength(10)]
        public DateTime StartDate { get; set; }

        [MaxLength(30)]
        public string Hometown { get; set; }

        [MaxLength(20)]
        public string Department { get; set; }

    }
}