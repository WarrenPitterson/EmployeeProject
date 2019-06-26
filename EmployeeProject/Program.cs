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
            Console.WriteLine("\nPlease select an Option");
            Console.WriteLine("1 - Add an Employee Manually");
            Console.WriteLine("2 - Add Employee via CSV");
            Console.WriteLine("3 - List all Employees");
            Console.WriteLine("4 - Remove Employee");
            Console.WriteLine("0 - Quit Program\n");


            var userInput = (Console.ReadLine().Trim());
            Int32.TryParse(userInput, out int userInputResult);


            switch (userInputResult)
            {
                case 0:
                    Environment.Exit(0);
                    break;

                case 1:
                    ManualAdd(employees);
                    break;

                case 2:
                    AddEmployeeViaCSV(employees);
                    break;

                case 3:
                    ShowAllEmployees(employees);
                    break;

                    case 4:
                    RemoveEmployee(employees);
                    break;

                default:
                    Console.WriteLine("Please select either 1, 2, 3 or 0 to exit\n");
                    break;
            }
            StartMenu(employees);
        }


        public static void ManualAdd(List<Employee> employees)
        {
            try
            {
                string databasePath = ConfigurationManager.AppSettings["CsvDatabasePath"];

                {
                    using (var writer = new StreamWriter(databasePath, true))
                    {
                        Console.WriteLine("Employee ID");
                        var EmployeeID = (Console.ReadLine());

                        Console.WriteLine("Please enter first name");
                        var firstName = Console.ReadLine();

                        Console.WriteLine("Please enter last name");
                        var lastName = Console.ReadLine();

                        Console.WriteLine("Please enter date of birth (DD/MM/YYYY)");
                        var dob = Console.ReadLine();
                        DateTime.TryParse(dob, out DateTime parsedDob);

                        Console.WriteLine("Please enter the employee start date (DD/MM/YYYY)");
                        var startDate = Console.ReadLine();
                        DateTime.TryParse(startDate, out DateTime parsedStartDate);

                        Console.WriteLine("Please enter the employee hometown");
                        var homeTown = Console.ReadLine();

                        Console.WriteLine("Please enter the employee department");
                        var department = Console.ReadLine();

                        Employee newEmployee = new Employee(EmployeeID, firstName, lastName, parsedDob, parsedStartDate, homeTown, department);

                        string result = $"{EmployeeID},{firstName},{lastName},{parsedDob},{parsedStartDate},{homeTown},{department}";

                        employees.Add(newEmployee);
                        writer.WriteLine(result);
                        writer.Close();
                        StartMenu(employees);
                    }            
                }
            }
            catch (Exception e)
            {
                Console.WriteLine( "Unable to add employee");
                Console.WriteLine( e.Message);
            }
        }


        public static void AddEmployeeViaCSV(List<Employee> employees)
        {
            try
            {
                string databasePath = ConfigurationManager.AppSettings["CsvDatabasePath"];

                using (var reader = new StreamReader(databasePath))

                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        string employeeID = values[0];
                        string firstName = values[1];
                        string lastName = values[2];
                        string dob = values[3];
                        DateTime.TryParse(dob, out DateTime parsedDob);
                        string StartDate = values[4];
                        DateTime.TryParse(StartDate, out DateTime parsedStartDate);
                        string hometown = values[5];
                        string department = values[6];

                        Employee newEmployee = new Employee(employeeID, firstName, lastName, parsedDob, parsedStartDate, hometown, department);

                        employees.Add(newEmployee);
                    }
                    reader.Close();
                    Console.WriteLine("Employees added from CSV\n");
                }
                StartMenu(employees);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read file");
                Console.WriteLine(e.Message);

            }
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
            Console.WriteLine("Please enter the employee number you wish to remove");
            var employeeRemoved = Console.ReadLine();

            var removalQuery = from e in employees
                               where e.EmployeeID == employeeRemoved
                               select e;

            foreach (var e in removalQuery)
            {
                Console.WriteLine($"{e.FirstName} has been removed");
                employees.Remove(e);
            }

           StartMenu(employees);

        }

        public static void AppendEmployee(List<Employee> employees)
        {

        }
    }

}



//var EmployeeLINQ = from e in employees
//                   select e.FirstName;

//var EmployeeLINQ2 = employees.Select(e => new { e.FirstName, e.LastName });


//            foreach (var e in EmployeeLINQ2)
//            {
//                Console.WriteLine(e);
//            }