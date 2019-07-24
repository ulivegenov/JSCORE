using Solid.Logger.Appenders.Contracts;
using Solid.Logger.Appenders.Factory.Contracts;
using Solid.Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Logger.Appenders.Factory
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeToLower = type.ToLower();

            switch (typeToLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout);
                default:
                    throw new ArgumentException("Invalid appender type");
            }
        }
    }
}
