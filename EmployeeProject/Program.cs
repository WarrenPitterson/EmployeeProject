using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.ComponentModel;


namespace EmployeeProject
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Employee Program");
            List<Employee> employees = new List<Employee>();
            StartMenu(employees);
        }



        public static void StartMenu(List<Employee> employees)
        {
            Console.WriteLine("Please select an Option");
            Console.WriteLine("1 - Add an Employee Manually");
            Console.WriteLine("2 - Add Employee via CSV");
            Console.WriteLine("3 - List all Employees");
            Console.WriteLine("4 - Quit Program");

            var userInput = Convert.ToInt32(Console.ReadLine());

            if (userInput == 1)
            {
                ManualAdd(employees);
            }

            if (userInput == 2)
            {
                AddEmployeeViaCSV(employees);
            }

            if (userInput == 3)
            {
                ShowAllEmployees(employees);
            }

            if (userInput == 4)
            {
                Environment.Exit(0);
            }
        }


        public static void ManualAdd(List<Employee> employees)
        {
            {
                Console.WriteLine("Please enter first name");
                var firstName = Console.ReadLine();

                Console.WriteLine("Please enter last name");
                var lastName = Console.ReadLine();

                Console.WriteLine("Please enter date of birth (DD/MM/YYYY)");
                var dob = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Please enter the employee start date (DD/MM/YYYY)");
                var startDate = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Please enter the employee hometown");
                var homeTown = Console.ReadLine();

                Console.WriteLine("Please enter the employee department");
                var department = Console.ReadLine();

                Employee newEmployee = new Employee(firstName, lastName, dob, startDate, homeTown, department);

                employees.Add(newEmployee);
                StartMenu(employees);
            }
        }

        public static void AddEmployeeViaCSV(List<Employee> employees)
        {
            string databasePath = ConfigurationManager.AppSettings["CsvDatabasePath"];

            using (var reader = new StreamReader(databasePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    string firstName = values[0];
                    string lastName = values[1];
                    string dob = values[2];
                    DateTime parsedDob = Convert.ToDateTime(dob);
                    string StartDate = values[3];
                    DateTime parsedStartDate = DateTime.Parse(StartDate);
                    string hometown = values[4];
                    string department = values[5];


                    Employee newEmployee = new Employee(firstName, lastName, parsedDob, parsedStartDate.Date, hometown, department);

                    employees.Add(newEmployee);
                }

                Console.WriteLine("Employees added from CSV");
            }
            StartMenu(employees);
        }
        
        public static void ShowAllEmployees(List<Employee> employees)
        {
            for (var i = 0; i < employees.Count; i++)
            {
                employees[i].DisplayAll();
            }

            StartMenu(employees);
        }

        public static void RemoveEmployee(List<Employee> employees)
        {
            Console.WriteLine("Please enter then name of the employee you wish to remove");

            //employees.Remove(oldEmployee);
            StartMenu(employees);
        }
    }

}

