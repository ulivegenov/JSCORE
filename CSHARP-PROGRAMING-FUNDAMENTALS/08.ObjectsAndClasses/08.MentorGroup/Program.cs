using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace _08.MentorGroup
{
    class Student
    {
        public List<string> Comments { get; set; }
        public List<DateTime> DatesAttended { get; set; }
    }
    class MentorGroup
    {
        static void Main()
        {
            SortedDictionary<string, Student> studentsData = new SortedDictionary<string, Student>();

            string firstInput = Console.ReadLine();

            while (firstInput != "end of dates")
            {
                List<DateTime> datesAttended = new List<DateTime>();

                string[] tokens = firstInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string userName = tokens[0];

                Student student = new Student();

                if (tokens.Length > 1)
                {
                    string[] dates = tokens[1].Split(',');

                    for (int i = 0; i < dates.Length; i++)
                    {
                        DateTime currentDate = DateTime.ParseExact(dates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        datesAttended.Add(currentDate);
                    }


                }

                if (!studentsData.ContainsKey(userName))
                {
                    studentsData.Add(userName, student);
                    student.DatesAttended = datesAttended;
                    student.Comments = new List<string>();
                }
                else
                {
                    studentsData[userName].DatesAttended.AddRange(datesAttended);
                }

                firstInput = Console.ReadLine();
            }

            string secondInput = Console.ReadLine();

            while (secondInput != "end of comments")
            {
                List<string> comments = new List<string>();

                string[] tokens = secondInput.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                string userName = tokens[0];
                string comment = tokens[1];

                comments.Add(comment);

                if (studentsData.ContainsKey(userName))
                {
                    if (studentsData[userName].Comments.Count > 0)
                    {
                        studentsData[userName].Comments.AddRange(comments);
                    }
                    else
                    {
                        studentsData[userName].Comments = comments;
                    }
                }

                secondInput = Console.ReadLine();
            }

            foreach (KeyValuePair<string, Student> students in studentsData)
            {
                string userName = students.Key;
                Student student = students.Value;

                List<DateTime> datesAttended = student.DatesAttended;
                List<string> comments = student.Comments;

                Console.WriteLine(userName);
                Console.WriteLine("Comments:");

                foreach (string comment in comments)
                {
                    Console.WriteLine($"- {comment}");
                }

                Console.WriteLine("Dates attended:");

                foreach (DateTime date in datesAttended.OrderBy(d => d))
                {
                    Console.WriteLine($"-- {date.ToString("dd/MM/yyyy")}");
                }
            }
        }
    }
}