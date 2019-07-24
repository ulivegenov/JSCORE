using LoggerApp.Enums;
using LoggerApp.Models.Contracts;
using System;

namespace LoggerApp.Models.Factories
{
    public class AppenderFactory
    {
        const string DefaultFileName = "logFile{0}.txt";

        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 0;
        }

        public IAppender CreateApender(string appenderType, string stringReportLevel, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ReportLevel level = this.ParseReportLevel(stringReportLevel);
            IAppender appender = null;

            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, level);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaultFileName, this.fileNumber));
                    appender = new FileAppender(layout, level, logFile);
                    break;
                default:
                    throw new ArgumentException("Invalid Appender Type!");
            }

            return appender;
        }

        private ReportLevel ParseReportLevel(string stringReportLevel)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ReportLevel), stringReportLevel);
                return (ReportLevel)levelObj;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid Level Type!", e);
            }
        }
    }
}
