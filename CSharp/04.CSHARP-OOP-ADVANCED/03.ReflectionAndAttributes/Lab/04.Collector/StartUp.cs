using System;


public class StartUp
{
    static void Main(string[] args)
    {
        Spy spy = new Spy();
        string result = spy.ColectGettersAndSetters("Hacker");
        Console.WriteLine(result);
    }
}

