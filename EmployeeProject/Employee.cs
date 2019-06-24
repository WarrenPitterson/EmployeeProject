using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject
{
    public class Employee
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public DateTime StartDate { get; set; }
        public string HomeTown { get; set; }
        public string Department { get; set; }

        public Employee(string firstName, string lastName, DateTime dob, DateTime startDate, string homeTown, string department)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Dob = dob;
            this.StartDate = startDate;
            this.HomeTown = homeTown;
            this.Department = department;
        }


        public void DisplayAll()
        {
            Console.WriteLine($" First Name: { FirstName}\n Last Name: { LastName}\n Dob: { Dob}\n Start Date: { StartDate}\n HomeTown: { HomeTown}\n Department: {Department}\n");
        }

    }
}
