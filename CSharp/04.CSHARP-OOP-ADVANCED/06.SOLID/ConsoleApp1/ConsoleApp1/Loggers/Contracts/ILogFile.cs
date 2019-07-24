using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Loggers.Contracts
{
    public interface ILogFile
    {
        void Write(string messgae);
        int Size { get; }
    }
}
