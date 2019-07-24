using Solid.Appenders;
using Solid.Appenders.Contracts;
using Solid.Core.Factory.Contracts;
using Solid.Layouts.Contracts;
using Solid.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Core.Factory
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppander CreateAppender(string type, ILayout layOut)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layOut);

                case "fileappender":
                    return new FileAppender(layOut, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");

            }
        }
    }
}
