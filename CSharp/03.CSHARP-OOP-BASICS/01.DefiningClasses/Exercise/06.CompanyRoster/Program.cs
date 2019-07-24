using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int countOfPeople = int.Parse(Console.ReadLine());
        Dictionary<string, List<decimal>> departmentSalary = new Dictionary<string, List<decimal>>();
        Dictionary<string, List<Employee>> departmentEmployeeList = new Dictionary<string, List<Employee>>();


        for (int i = 0; i < countOfPeople; i++)
        {
            string[] inputData = Console.ReadLine().Split();
            Employee currnetEmployee = new Employee();


                currnetEmployee.Name = inputData[0];
                currnetEmployee.Selary = decimal.Parse(inputData[1]);
                currnetEmployee.Position = inputData[2];
                currnetEmployee.Department = inputData[3];
                currnetEmployee.Email = "n/a";
                currnetEmployee.Age = -1;
     
            if (inputData.Length == 6)
            {
                currnetEmployee.Email = inputData[4];
                currnetEmployee.Age = int.Parse(inputData[5]);
            }
            else if(inputData.Length == 5)
            {
                int age;
                bool isAge = int.TryParse(inputData[4], out age);
                if (isAge)
                {
                    currnetEmployee.Age = age;
                }
                else
                {
                    currnetEmployee.Email = inputData[4];
                }
                
            }


            if (!departmentSalary.ContainsKey(currnetEmployee.Department))
            {
                departmentSalary.Add(currnetEmployee.Department, new List<decimal>());
                departmentEmployeeList.Add(currnetEmployee.Department, new List<Employee>());
            }

            departmentSalary[currnetEmployee.Department].Add(currnetEmployee.Selary);
            departmentEmployeeList[currnetEmployee.Department].Add(currnetEmployee);
        }

        string highestAverageSalayDepartment = departmentSalary.OrderByDescending(x => x.Value.Average()).First().Key;
        decimal highestAverageSelary = departmentSalary[highestAverageSalayDepartment].Average();

        foreach (var department in departmentSalary.Where(x => x.Value.Average() == highestAverageSelary))
        {
            Console.WriteLine($"Highest Average Salary: {department.Key}");
            foreach (var dep in departmentEmployeeList.Where(x => x.Key==department.Key))
            {
                foreach (var employee in dep.Value.OrderByDescending(x => x.Selary))
                {
                    Console.WriteLine($"{employee.Name} {employee.Selary:f2} {employee.Email} {employee.Age}");
                }   
            }   
        }
    }
}

