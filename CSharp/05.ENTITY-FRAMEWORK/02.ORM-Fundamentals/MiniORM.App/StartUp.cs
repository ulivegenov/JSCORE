using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System;
using System.Linq;

namespace MiniORM.App
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniDbContext(Configuration.CONNECTION_STRING);

            context.Employees.Add(new Employee
            {
                FirstName = "Minka",
                LastName = "Gesheva",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();

            employee.MiddleName = "Modified";

            context.SaveChanges();
        }
    }
}
