using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AverageGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            Student[] students = new Student[countOfStudents];

            for (int i = 0; i < countOfStudents; i++)
            {
                students[i] = InputStudent(Console.ReadLine());
            }

            foreach (var student in students.Where(x => x.AverageGrade >= 5.00)
                                            .OrderBy(x => x.Name)
                                            .ThenByDescending(x => x.AverageGrade))
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade:f2}");
            }
        }

        static Student InputStudent(string input)
        {
            string[] studentParameters = input.Split(' ');
            List<double> grades = new List<double>();
            foreach (string studentParameter in studentParameters.Skip(1))
            {
                grades.Add(double.Parse(studentParameter));
            }

            return new Student { Name = studentParameters[0], Grades = grades };
        }
        class Student
        {
            public string Name { get; set; }
            public List<double> Grades { get; set; }
            public double AverageGrade { get { return Grades.Sum() / Grades.Count; } }
        }
    }
}
