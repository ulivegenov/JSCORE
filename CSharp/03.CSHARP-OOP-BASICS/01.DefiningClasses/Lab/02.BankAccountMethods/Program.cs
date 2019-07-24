using System;


class Program
{
    static void Main(string[] args)
    {
        BankAccount bankAccount = new BankAccount();

        bankAccount.Id = 1;
        bankAccount.Deposit(15);
        bankAccount.Withdraw(10);

        Console.WriteLine(bankAccount);
    }
}
