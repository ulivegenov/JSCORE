using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Student : Human
{
    private const int FACULTY_NUMBER_MIN_LEGHT = 5;
    private const int FACULTY_NUMBER_MAX_LEGHT = 10;
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if ((value.Length < FACULTY_NUMBER_MIN_LEGHT || value.Length > FACULTY_NUMBER_MAX_LEGHT) || (value.Any(p => !(char.IsLetterOrDigit(p)))))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName ,string facultyNumber)
        :base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
        StringBuilder outputBuild = new StringBuilder();
        outputBuild.AppendLine(base.ToString());
        outputBuild.Append($"Faculty number: {this.FacultyNumber}");
        string result = outputBuild.ToString().TrimEnd();

        return result;
    }
}

