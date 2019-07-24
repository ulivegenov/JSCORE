using _08CreateCustomClassAttribute;
using System;

namespace _08.CreateCustomClassAttribute
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Type classType = typeof(Weapon);
            var attributes = classType.GetCustomAttributes(false);

            foreach (var attr in attributes)
            {
                var classAttr = attr as CastomAttributeAttribute;

                if (classAttr != null)
                {
                    string command;

                    while ((command = Console.ReadLine()) != "END")
                    {
                        switch (command)
                        {
                            case "Author":
                                Console.WriteLine($"Author: {classAttr.Author}");
                                break;
                            case "Revision":
                                Console.WriteLine($"Revision: {classAttr.Revision}");
                                break;
                            case "Description":
                                Console.WriteLine($"Class description: {classAttr.Description}");
                                break;
                            case "Reviewers":
                                Console.WriteLine($"Reviewers: {string.Join(", ", classAttr.Reviewers)}");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
