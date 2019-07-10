using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject
{
    public class EmployeeRepository
    {
        public static string databasePath = ConfigurationManager.AppSettings["CsvDatabasePath"];
        public static List<Employee> employees = new List<Employee>();

        public static void ManualAdd(List<Employee> employees)
        {
            try
            {
                string databasePath = ConfigurationManager.AppSettings["CsvDatabasePath"];
                {
                    using (var writer = new StreamWriter(databasePath, true))
                    {
                        Console.WriteLine("Employee ID");
                        var EmployeeId = Int32.Parse(Console.ReadLine());

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

                        Employee newEmployee = new Employee(EmployeeId, firstName, lastName, parsedDob, parsedStartDate, homeTown, department);

                        string result = $"{EmployeeId},{firstName},{lastName},{parsedDob.ToShortDateString()}, {parsedStartDate.ToShortDateString()},{homeTown},{department}";

                        employees.Add(newEmployee);
                        writer.WriteLine(result);
                        writer.Close();
                        Program.StartMenu(employees);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to add employee");
                Console.WriteLine(e.Message);
            }
        }

        public static void AddEmployeeViaCSV(List<Employee> employees)
        {
            try
            {
                var databasePath = ConfigurationManager.AppSettings["CsvDatabasePath"];

                using (var reader = new StreamReader(databasePath, true))

                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        string EmployeeId = values[0];
                        int.TryParse(EmployeeId, out int parsedEmployeeID);
                        string firstName = values[1];
                        string lastName = values[2];
                        string dob = values[3];
                        DateTime.TryParse(dob, out DateTime parsedDob);
                        string StartDate = values[4];
                        DateTime.TryParse(StartDate, out DateTime parsedStartDate);
                        string hometown = values[5];
                        string department = values[6];

                        Employee newEmployee = new Employee(parsedEmployeeID, firstName, lastName, parsedDob, parsedStartDate, hometown, department);

                        employees.Add(newEmployee);
                    }
                    Console.WriteLine("Employees added from CSV\n");
                }
                Program.StartMenu(employees);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Loading List");
                Console.WriteLine(e.Message);
            }
        }

        public static void RemoveEmployee(List<Employee> employees)
        {
            var databasePath = ConfigurationManager.AppSettings["CsvDatabasePath"];
            StringBuilder sb = new StringBuilder();

            Console.WriteLine("Please enter the employee number you wish to remove");
            var employeeRemoved = int.Parse(Console.ReadLine());


            foreach (var e in employees.ToList().Where(e => e.EmployeeId == employeeRemoved))
            {
                Console.WriteLine($"{e.FirstName} has been removed");
                employees.Remove(e);
            }

            foreach (var e in employees)
            {
                string result = $"{e.EmployeeId},{e.FirstName},{e.LastName},{e.Dob}, {e.StartDate},{e.HomeTown},{e.Department}";
                sb.AppendLine(result);
            }

            string contents = sb.ToString();
            File.WriteAllText(databasePath, contents);
            Program.StartMenu(employees);
        }

        public static void EditEmployee(List<Employee> employees)
        {
            var databasePath = ConfigurationManager.AppSettings["CsvDatabasePath"];
            StringBuilder sb = new StringBuilder();

            Console.WriteLine("Select the employee  number you wish to edit");
            var employeeEdited = int.Parse(Console.ReadLine());

            Console.WriteLine($"What would you like to change The Last Name to? ");
            var newLastName = Console.ReadLine();

            var emp = employees.Where(e => e.EmployeeId == employeeEdited).SingleOrDefault();
            if (emp != null)
            {
                emp.LastName = newLastName;
            }

            foreach (var e in employees)
            {
                string newresult = $"{e.EmployeeId},{e.FirstName},{e.LastName},{e.Dob}, {e.StartDate},{e.HomeTown},{e.Department}";
                sb.AppendLine(newresult);
            }

            string contents = sb.ToString();
            File.WriteAllText(databasePath, contents);
            Program.StartMenu(employees);
        }

        public static List<Employee> GetAllEmployees()
        {
            try
            {
                var databasePath = ConfigurationManager.AppSettings["CsvDatabasePath"];

                using (var reader = new StreamReader(databasePath, true))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        string EmployeeId = values[0];
                        Int32.TryParse(EmployeeId, out int parsedEmployeeID);
                        string firstName = values[1];
                        string lastName = values[2];
                        string dob = values[3];
                        DateTime.TryParse(dob, out DateTime parsedDob);
                        string StartDate = values[4];
                        DateTime.TryParse(StartDate, out DateTime parsedStartDate);
                        string hometown = values[5];
                        string department = values[6];

                        Employee newEmployee = new Employee(parsedEmployeeID, firstName, lastName, parsedDob, parsedStartDate, hometown, department);
                        employees.Add(newEmployee);
                    }
                    Console.WriteLine("Employees added from CSV\n");
                    return employees;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;

            }
        }
    }
}


