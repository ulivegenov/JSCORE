

namespace SoftUni
{
    using System;
    using SoftUni.Data;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using SoftUni.Models;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var result = RemoveTown(context);
                Console.WriteLine(result);
            }
        }

        //03. Employees Full Information 
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context.Employees
                                   .Select(e => new
                                   {
                                       e.FirstName,
                                       e.LastName,
                                       e.MiddleName,
                                       e.JobTitle,
                                       e.Salary,
                                       e.EmployeeId
                                   })
                                   .OrderBy(e => e.EmployeeId)
                                   .ToList();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return result.ToString().TrimEnd();
        }

        //04. Employees with Salary Over 50 000 
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context.Employees
                                   .Select(e => new
                                   {
                                       e.FirstName,
                                       e.Salary
                                   })
                                   .Where(e => e.Salary > 50000)
                                   .OrderBy(e => e.FirstName)
                                   .ToList();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return result.ToString().TrimEnd();
        }

        //05. Employees from Research and Development 
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context.Employees
                                   .Select(e => new
                                   {
                                       e.FirstName,
                                       e.LastName,
                                       DepartmentName = e.Department.Name,
                                       e.Salary
                                   })
                                   .Where(e => e.DepartmentName == "Research and Development")
                                   .OrderBy(e => e.Salary)
                                   .ThenByDescending(e => e.FirstName)
                                   .ToList();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }

            return result.ToString().Trim();
        }

        //06. Adding a New Address and Updating Employee 
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            //Define new adrress
            var newAdress = new Address();
            newAdress.AddressText = "Vitoshka 15";
            newAdress.TownId = 4;

            // Select employee 'Nakov'
            var nakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            nakov.Address = newAdress;

            //Save update
            context.SaveChanges();

            var employeeAdressText = context.Employees.Select(e => new
                                                       {
                                                           e.AddressId,
                                                           AdressText = e.Address.AddressText
                                                       })
                                                       .OrderByDescending(e => e.AddressId)
                                                       .Take(10);

            foreach (var e in employeeAdressText)
            {
                result.AppendLine(e.AdressText);
            }

            return result.ToString().Trim();
        }


        //07. Employees and Projects 
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context.Employees.Where(e => e.EmployeesProjects
                                                            .Any(ep => ep.Project.StartDate.Year >= 2001 &&
                                                                 ep.Project.StartDate.Year <= 2003))
                                             .Select(e => new
                                             {
                                                 e.FirstName,
                                                 e.LastName,
                                                 ManagerFullName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                                                 Projects = e.EmployeesProjects.Select(p => new
                                                 {
                                                     ProjectName = p.Project.Name,
                                                     StartDate = p.Project.StartDate,
                                                     EndDate = p.Project.EndDate
                                                 })
                                             })
                                             .Take(10)
                                             .ToList();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFullName}");

                foreach (var p in e.Projects)
                {
                    string startDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt");
                    string endDate = p.EndDate.HasValue ? p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")
                                                        : "not finished";

                    result.AppendLine($"--{p.ProjectName} - {startDate} - {endDate}");
                }
            }

            return result.ToString().Trim();
        }


        //08. Addresses by Town 
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var addresses = context.Addresses.Select(a => new
                                              {
                                                  a.AddressText,
                                                  Town = a.Town.Name,
                                                  EmployeesCount = a.Employees.Count
                                              })
                                             .OrderByDescending(a => a.EmployeesCount)
                                             .ThenBy(a => a.Town)
                                             .ThenBy(a => a.AddressText)
                                             .Take(10)
                                             .ToList();

            foreach (var a in addresses)
            {
                result.AppendLine($"{a.AddressText}, {a.Town} - {a.EmployeesCount} employees");
            }

            return result.ToString().Trim();
        }

        //09. Employee 147 
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employee147 = context.Employees.Select(e => new
                                               {
                                                   e.FirstName,
                                                   e.LastName,
                                                   e.JobTitle,
                                                   e.EmployeeId,
                                                   Projects = e.EmployeesProjects.Select(p => new
                                                   {
                                                       ProjectName = p.Project.Name
                                                   })
                                                   .OrderBy(p => p.ProjectName)
                                                   .ToList()
                                               })
                                               .FirstOrDefault(e => e.EmployeeId == 147);

            result.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
            foreach (var p in employee147.Projects)
            {
                result.AppendLine(p.ProjectName);
            }

            return result.ToString().Trim();
        }


        //10. Departments with More Than 5 Employees 
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var departments = context.Departments.Where(d => d.Employees.Count > 5)
                                                 .Select(d => new
                                                 {
                                                     d.Name,
                                                     ManagerFullName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                                                     Employees = d.Employees.Select(e => new
                                                     {
                                                         e.FirstName,
                                                         e.LastName,
                                                         e.JobTitle
                                                     })
                                                     .OrderBy(e => e.FirstName)
                                                     .ThenBy(e => e.LastName)
                                                 })
                                                 .OrderBy(d => d.Employees.Count())
                                                 .ThenBy(d => d.Name)
                                                 .ToList();

            foreach (var d in departments)
            {
                result.AppendLine($"{d.Name} - {d.ManagerFullName}");

                foreach (var e in d.Employees)
                {
                    result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return result.ToString().Trim();
        }


        //11. Find Latest 10 Projects 
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var projects = context.Projects.Select(p => new
                                            {
                                                p.Name,
                                                p.Description,
                                                p.StartDate
                                            })
                                           .OrderByDescending(p => p.StartDate)
                                           .Take(10)
                                           .ToList();

            foreach (var p in projects.OrderBy(p => p.Name))
            {
                result.AppendLine(p.Name);
                result.AppendLine(p.Description);
                result.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return result.ToString().Trim();
        }


        //12. Increase Salaries 
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            string[] departmentNames = { "Engineering",
                                         "Tool Design",
                                         "Marketing",
                                         "Information Services" };

            var employees = context.Employees.Where(e => departmentNames.Contains(e.Department.Name))
                                             .OrderBy(e => e.FirstName)
                                             .ThenBy(e => e.LastName)
                                             .ToList();

            foreach (var e in employees)
            {
                e.Salary = e.Salary * 1.12m;

                result.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");     
            }
                                             

            return result.ToString().Trim();
        }


        //13. Find Employees by First Name Starting With Sa 
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var employees = context.Employees.Where(e => e.FirstName.StartsWith("Sa"))
                                             .Select(e => new
                                             {
                                                 e.FirstName,
                                                 e.LastName,
                                                 e.JobTitle,
                                                 e.Salary
                                             })
                                             .OrderBy(e => e.FirstName)
                                             .ThenBy(e => e.LastName)
                                             .ToList();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return result.ToString().Trim();
        }


        //14. Delete Project by Id 
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            // Select project to delete
            var projectToDelete = context.Projects.FirstOrDefault(p => p.ProjectId == 2);

            // Select related EmployeesProjects
            var employeesProjects = context.EmployeesProjects.Where(ep => ep.ProjectId == 2)
                                                             .ToList();
            // Delete related EmployeesProjects
            context.EmployeesProjects.RemoveRange(employeesProjects);

            // Delete project
            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context.Projects.Select(p => p.Name)
                                           .Take(10)
                                           .ToList();

            foreach (var p in projects)
            {
                result.AppendLine(p);
            }

            return result.ToString().Trim();
        }


        //15. Remove Town 
        public static string RemoveTown(SoftUniContext context)
        {
            //Select Seattle
            var seattle = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            //Select addresses in Seattle
            var addresses = context.Addresses.Where(a => a.TownId == seattle.TownId)
                                              .ToList();

            // Select employees in Seattle
            var employees = context.Employees.Where(e => addresses.Contains(e.Address))
                                             .ToList();

            // Set addressID of Seattle's employees to null
            foreach (var e in employees)
            {
                e.AddressId = null;
            }

            //Delete addresses in Seattle
            context.Addresses.RemoveRange(addresses);

            //Delete Seattle
            context.Towns.Remove(seattle);

            context.SaveChanges();

            return $"{addresses.Count} addresses in Seattle were deleted";
        }
    }
}
