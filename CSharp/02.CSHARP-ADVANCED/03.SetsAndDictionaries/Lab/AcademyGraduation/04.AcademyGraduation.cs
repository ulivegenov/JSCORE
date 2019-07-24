using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AcademyGraduation
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<double>> studentsEvaluations = new SortedDictionary<string, List<double>>();
            int numberOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; i++)
            {
                string inputName = Console.ReadLine();
                double[] inputEvaluations = Console.ReadLine()
                                            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(double.Parse)
                                            .ToArray();

                if (!studentsEvaluations.ContainsKey(inputName))
                {
                    studentsEvaluations.Add(inputName, new List<double>());
                }

                for (int j = 0; j < inputEvaluations.Length; j++)
                {
                    studentsEvaluations[inputName].Add(inputEvaluations[j]);
                }   
            }

            foreach (KeyValuePair<string, List<double>> student in studentsEvaluations)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }
        }
    }
}
