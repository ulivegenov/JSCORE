using System;
using System.Collections.Generic;

namespace _03.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, BankAccount> bankAccounts = new Dictionary<int, BankAccount>();
            BankAccount bankAccount = new BankAccount();
            string input;
            
            while ((input = Console.ReadLine()) != "End")
            {
                string[] splitInput = input.Split();
                string command = splitInput[0];

                switch (command)
                {
                    case "Create":
                        if (bankAccounts.ContainsKey(int.Parse(splitInput[1])))
                        {
                            Console.WriteLine("Account already exists");
                        }
                        else
                        {
                            bankAccount.Id = int.Parse(splitInput[2]);
                            bankAccounts.Add(int.Parse(splitInput[1]), new BankAccount(bankAccount.Id, bankAccount.Balance));
                        }
                        break;
                    case "Deposit":
                        bankAccounts[]
                        break;
                }

            }
        }
    }
}
