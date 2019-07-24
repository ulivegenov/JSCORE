using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Smartphone : ICall, IBrowse
{
    public string Calling(string phoneNumber)
    {
        if (!phoneNumber.Any(char.IsDigit))
        {
            return "Invalid number!";
        }
        else
        {
            return $"Calling... {phoneNumber}";
        } 
    }

    public string Browsing(string site)
    {
        if (site.Any(char.IsDigit))
        {
            return "Invalid URL!";
        }
        else if (site == string.Empty)
        {
            return "Browsing: !";
        }
        else
        {
            return $"Browsing: {site}!";
        }  
    }
}

