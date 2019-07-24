using LoggerApp.Models;
using LoggerApp.Models.Contracts;
using LoggerApp.Models.Factories;
using System;
using System.Collections.Generic;

namespace LoggerApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory = new ErrorFactory();
            Engine engine = new Engine(logger, errorFactory);
            engine.Run();   
        }

        static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            int appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                string appenderType = inputArgs[0];
                string layoutType = inputArgs[1];
                string stringReportLevel = "INFO";

                if (inputArgs.Length == 3)
                {
                    stringReportLevel = inputArgs[2];
                }

                IAppender appender = appenderFactory.CreateApender(appenderType, stringReportLevel, layoutType);
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders);
            return logger;
        }
    }
}
