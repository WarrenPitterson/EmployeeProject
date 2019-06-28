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
        public int Age
        {
            get
            {
                int Age = DateTime.Now.Year - Dob.Year;

                if ((Dob.Month > DateTime.Now.Month) || (Dob.Month == DateTime.Now.Month && Dob.Day > DateTime.Now.Day))
                    Age--;
                return Age;
            }
        }
        public DateTime StartDate { get; set; }
        public bool Anniversary
        {
            get
            {
                
                bool Anniversary = false;

                if (StartDate.DayOfYear <= DateTime.Now.DayOfYear + 28 && StartDate.DayOfYear >= DateTime.Now.DayOfYear)
                {
                    Anniversary = true;
                }

                return Anniversary;

            }
        }
        public int AnniversaryTimer
        {
            get
            {
                var AnniversaryTimer = StartDate.DayOfYear - DateTime.Now.DayOfYear;
                    return AnniversaryTimer;
            }
        }

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
