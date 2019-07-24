

namespace Solid.Core
{
    using Solid.Appenders.Contracts;
    using Solid.Core.Contracts;
    using Solid.Core.Factory;
    using Solid.Core.Factory.Contracts;
    using Solid.Layouts.Contracts;
    using Solid.Layouts.Factory;
    using Solid.Layouts.Factory.Contracts;
    using Solid.Loggers.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Command : ICommand
    {
        private ICollection<IAppander> appenders;
        private IAppenderFactory factory;
        private ILayOutFactory layoutFactory;
        public Command()
        {
            this.appenders = new List<IAppander>();
            this.factory = new AppenderFactory();
            this.layoutFactory = new LayOutFactory();
        }
        public void AddAppender(string[] args)
        {
            string appenderType = args[0];
            string layoutType = args[1];
            ReportLevel reportLevel = ReportLevel.Info;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2],true);
            }
            ILayout layout = this.layoutFactory.CreateLayOut(layoutType);
            IAppander appender = this.factory.CreateAppender(appenderType, layout);
            appender.reportLevel = reportLevel;

            this.appenders.Add(appender);

        }

        public void AddMessage(string[] args)
        {
            ReportLevel report = Enum.Parse<ReportLevel>(args[0],true);
            string dateTime = args[1];
            string message = args[2];

            foreach (var appender in appenders)
            {
                appender.Append(dateTime, report, message);
            }
        }

        public void Print()
        {
            Console.WriteLine("Logger info");

            foreach (var appenders in appenders)
            {
                Console.WriteLine(appenders);
            }
        }
    }
}
