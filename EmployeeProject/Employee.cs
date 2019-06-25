using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public DateTime StartDate { get; set; }
        public string HomeTown { get; set; }
        public string Department { get; set; }

        public Employee(string employeeID, string firstName, string lastName, DateTime dob, DateTime startDate, string homeTown, string department)
        {
            this.EmployeeID = employeeID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Dob = dob;
            this.StartDate = startDate;
            this.HomeTown = homeTown;
            this.Department = department;
        }


        public void DisplayAll()
        {
            Console.WriteLine($" EmployeeId: {EmployeeID}\n First Name: { FirstName}\n Last Name: { LastName}\n Dob: { Dob.ToShortDateString()}\n Start Date: { StartDate.ToShortDateString()}\n HomeTown: { HomeTown}\n Department: {Department}\n");
        }

    }
}
