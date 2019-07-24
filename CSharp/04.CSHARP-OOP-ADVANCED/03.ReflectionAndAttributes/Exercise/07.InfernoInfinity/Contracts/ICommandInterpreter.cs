using System;
using System.Collections.Generic;
using System.Text;

namespace _07InfernoInfinity.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpredCommand(string data);
    }
}
