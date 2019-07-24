using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> departmentsRegister = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> doctorsRegister = new Dictionary<string, List<string>>();

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "Output")
            {
                string[] inputData = inputLine
                                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string department = inputData[0];
                string doctor = inputData[1] + " " + inputData[2];
                string patient = inputData[3];

                if (!departmentsRegister.ContainsKey(department))
                {
                    departmentsRegister.Add(department, new List<string>());
                }

                departmentsRegister[department].Add(patient);


                if (!doctorsRegister.ContainsKey(doctor))
                {
                    doctorsRegister.Add(doctor, new List<string>());
                }

                doctorsRegister[doctor].Add(patient);

            }

            string outputCommand;

            while ((outputCommand = Console.ReadLine()) != "End")
            {
                string[] splitData = outputCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (splitData.Length == 1)
                {
                    foreach (var patient in departmentsRegister[outputCommand])
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    int room = 0;

                    if (int.TryParse(splitData[1], out room))
                    {
                        string department = splitData[0];
                        
                        foreach (var patient in departmentsRegister[department].Skip(3 * (room - 1)).Take(3).OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    else
                    {
                        foreach (var patient in doctorsRegister[outputCommand].OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
            }
        }
    }
}
