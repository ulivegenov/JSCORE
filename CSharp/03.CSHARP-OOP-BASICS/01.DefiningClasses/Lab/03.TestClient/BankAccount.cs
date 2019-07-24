using System;
using System.Collections.Generic;
using System.Text;


class BankAccount
{
    int id;
    decimal balance;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            this.Balance -= amount;
        }
    }

}

