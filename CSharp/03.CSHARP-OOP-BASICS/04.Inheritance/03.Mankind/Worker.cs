using System;
using System.Collections.Generic;
using System.Text;


public class Worker : Human
{
    private const decimal MIN_SALARY = 10.0m;
    private const decimal MIN_WORKING_HOURS = 1.0m;
    private const decimal MAX_WORKING_HOURS = 12.0m;
    private decimal weekSalary;
    private decimal workingHoursPerDay;
    private decimal salaryPerHour => SalaryPerHour();

    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= MIN_SALARY)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public decimal WorkingHoursPerDay
    {
        get { return workingHoursPerDay; }
        set
        {
            if (value < MIN_WORKING_HOURS || value > MAX_WORKING_HOURS)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workingHoursPerDay = value;
        }
    }

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHoursPerDay)
        :base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkingHoursPerDay = workingHoursPerDay;
    }

    private decimal SalaryPerHour()
    {
        decimal salaryPerHour = this.WeekSalary / 5 / this.WorkingHoursPerDay;

        return salaryPerHour;
    }

    public override string ToString()
    {
        StringBuilder outputBuild = new StringBuilder();
        outputBuild.AppendLine(base.ToString());
        outputBuild.AppendLine($"Week Salary: {this.WeekSalary:f2}");
        outputBuild.AppendLine($"Hours per day: {this.WorkingHoursPerDay:f2}");
        outputBuild.AppendLine($"Salary per hour: {this.salaryPerHour:f2}");
        string result = outputBuild.ToString().TrimEnd();

        return result;
    }
}

