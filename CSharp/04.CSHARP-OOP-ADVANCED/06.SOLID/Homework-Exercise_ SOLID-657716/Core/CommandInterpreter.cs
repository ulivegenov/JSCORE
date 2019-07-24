namespace Solid.Core
{
    using Solid.Appenders.Contracts;
    using Solid.Appenders.Factory;
    using Solid.Appenders.Factory.Contracts;
    using Solid.Core.Contracts;
    using Solid.Layouts.Contracts;
    using Solid.Layouts.Factory;
    using Solid.Layouts.Factory.Contracts;
    using Solid.Loggers.Enums;

    using System;
    using System.Collections.Generic;
 
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;
        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }
        public void AddAppender(string[] args)
        {
            string appenderType = args[0];
            string layoutType = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;
            if(args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout);
            appender.ReportLevel = reportLevel;
            this.appenders.Add(appender);
        }

        public void AddMessage(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0]);
            string dateTime = args[1];
            string message = args[2];
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
