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

    public override string ToString()
    {
        return $"Account {id}, balance {balance}";
    }
}

