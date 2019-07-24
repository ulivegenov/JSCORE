using System;
using System.Collections.Generic;
using System.Text;


public class Mission : IMission
{
    private string codeName;
    private string state;

    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public string CodeName
    {
        get { return codeName; }
        set { codeName = value; }
    }

    public string State
    {
        get { return state; }
        set { state = value; }
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State}";
    }
}

