using System;
using System.Collections.Generic;
using System.Text;


public class Tomcat:Cat
{
    public override string Type { get => "Tomcat"; }
    public override string Gender { get => "Male"; }

    public Tomcat(string name, int age, string gender) : base(name, age, gender)
    {

    }
}

