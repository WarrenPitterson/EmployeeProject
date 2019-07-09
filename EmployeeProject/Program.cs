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
        public static string databasePath = ConfigurationManager.AppSettings["CsvDatabasePath"];
        public static List<Employee> employees = new List<Employee>();
        public static EmployeeRepository EmployeeRepo = new EmployeeRepository();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Employee Program");
            StartMenu(employees);
        }

        public static void StartMenu(List<Employee> employees)
        {
            Console.WriteLine("\nPlease select an Option");
            Console.WriteLine("1 - Add an Employee Manually");
            Console.WriteLine("2 - Add Employee via CSV");
            Console.WriteLine("3 - List all Employees");
            Console.WriteLine("4 - Remove Employee");
            Console.WriteLine("5 - Show employees who have anniversaries in the next 30 days");
            Console.WriteLine("6 - Average Age By Departments");
            Console.WriteLine("7 - Number of employees from each town");
            Console.WriteLine("8 - Age of employees by Department");
            Console.WriteLine("9 - Edit Employees ");
            Console.WriteLine("0 - Quit Program\n");

            var userInput = (Console.ReadLine().Trim());
            Int32.TryParse(userInput, out int userInputResult);

            switch (userInputResult)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    EmployeeRepository.ManualAdd(employees);
                    break;
                case 2:
                    employees = EmployeeRepository.GetAllEmployees();
                    break;
                case 3:
                    ShowAllEmployees(employees);

                    break;
                case 4:
                    EmployeeRepository.RemoveEmployee(employees);
                    break;
                case 5:
                    EmployeeMonthlyAnniversary(employees);
                    break;
                case 6:
                    AverageAgeByDepartments(employees);
                    break;
                case 7:
                    NumberOfEmployeesByTown(employees);
                    break;
                case 8:
                    ShowAgeByDepartments(employees);
                    break;
                case 9:
                    EmployeeRepository.EditEmployee(employees);
                    break;
                default:
                    Console.WriteLine("Please select a number between 1-9 or 0 to exit\n");
                    break;
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

        public static void ShowAgeByDepartments(List<Employee> employees)
        {
            foreach (var employeeGroup in employees.GroupBy(e => e.Department))
            {
                Console.WriteLine($"{employeeGroup.Key}");
                foreach (var e in employeeGroup)
                {
                    Console.WriteLine($"\t\t{e.FirstName} - {e.Age}");
                }
                Console.WriteLine("\n");
            }
        }

        static void EmployeeMonthlyAnniversary(List<Employee> employees)
        {
            var AnniversaryQuery = from e in employees
                                   select e;
            foreach (var e in employees)
            {
                if (e.Anniversary == true)
                {
                    Console.WriteLine($"{e.FirstName} has a work anniversary in the next month in {e.AnniversaryTimer} Days");
                }
            }
        }

        static void AverageAgeByDepartments(List<Employee> employees)
        {
            foreach (var d in employees.GroupBy(e => e.Department))
            {
                Console.WriteLine($"{d.Key}");
                var totalAge = 0;
                var people = 0;

                foreach (var e in d)
                {
                    Console.WriteLine($"\t\t{e.FirstName} - {e.Age}");
                    totalAge += e.Age;
                    people++;
                }

                Console.WriteLine($"\t\tTotal age combined: {totalAge}");
                Console.WriteLine($"\t\tStaff in Department: {people}");
                Console.WriteLine($"\t\tAverage age of Staff in Department: {totalAge / people}");
                Console.WriteLine("\n");
            }
        }

        static void NumberOfEmployeesByTown(List<Employee> employees)
        {
            foreach (var h in employees.GroupBy(e => e.HomeTown))
            {
                var Count = 0;
                Console.WriteLine($"{h.Key}");

                foreach (var e in h)
                {
                    Count++;
                    Console.WriteLine($"\t{e.FirstName} {e.LastName} ");
                }
                Console.WriteLine($"Total: {Count}\n");
            };
        }
    }
}