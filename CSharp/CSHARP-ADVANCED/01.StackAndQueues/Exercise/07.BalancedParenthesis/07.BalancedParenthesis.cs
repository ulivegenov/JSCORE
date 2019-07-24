using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string parentheses = Console.ReadLine();
            Stack<char> openedParentheses = new Stack<char>();
            char[] openingCases = new char[] { '{', '[', '(' };

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (openingCases.Contains(parentheses[i]))
                {
                    openedParentheses.Push(parentheses[i]);
                }
                else
                {
                    if (openedParentheses.Count() == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    switch (parentheses[i])
                    {
                        case '}':
                            if (openedParentheses.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ']':
                            if (openedParentheses.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ')':
                            if (openedParentheses.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
