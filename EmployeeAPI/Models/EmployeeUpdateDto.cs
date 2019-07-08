using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeAPI.Models
{
    public class EmployeeUpdateDto
    {
        [Required(ErrorMessage = "You should have a valid name")]
        [MaxLength(20)]
        public string Lastname { get; set; }

    }
}