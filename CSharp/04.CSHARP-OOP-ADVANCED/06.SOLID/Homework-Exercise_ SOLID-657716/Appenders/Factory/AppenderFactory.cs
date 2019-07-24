namespace Solid.Appenders.Factory
{
    using Solid.Appenders.Contracts;
    using Solid.Appenders.Factory.Contracts;
    using Solid.Layouts.Contracts;
    using Solid.Loggers;

    using System;
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeLowerCase = type.ToLower();
            switch (typeLowerCase)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
