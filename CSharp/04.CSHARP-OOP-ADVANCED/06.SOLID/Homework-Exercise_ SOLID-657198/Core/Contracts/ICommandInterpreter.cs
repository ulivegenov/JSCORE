using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Logger.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] args);

        void AddMessage(string[] args);

        void PrintInfo();
    }
}
