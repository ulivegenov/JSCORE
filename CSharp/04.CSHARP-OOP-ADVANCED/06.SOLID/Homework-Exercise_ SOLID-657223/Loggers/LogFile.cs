﻿using Solid.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solid.Loggers
{
    public class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string messgae)
        {
            this.Size += messgae.Where(char.IsLetter).Sum(x => x);
        }
    }
}
