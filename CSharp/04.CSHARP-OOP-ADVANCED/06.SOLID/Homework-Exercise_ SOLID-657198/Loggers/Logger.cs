namespace Solid.Logger.Loggers
{
    using System;

    using Contracts;
    using Appenders.Contracts;
    using Solid.Logger.Loggers.Enums;

    class Logger : ILogger
    {
        private readonly IAppender appender;
        private readonly IAppender fileAppender;


        public Logger(IAppender appender)
        {
            this.appender = appender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender) 
            : this(consoleAppender)
        {
            this.appender = consoleAppender;
            this.fileAppender = fileAppender;
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.FATAL, fatalMessage);
        }

        internal void Warning(string dateTime, string warningMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.WARNING, warningMessage);
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.CRITICAL, criticalMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.ERROR, errorMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.INFO, infoMessage);
        }

        private void AppendMessage(string dateTime, ReportLevel reportLevel, string message)
        {
            this.appender?.Append(dateTime, reportLevel, message);
            this.fileAppender?.Append(dateTime, reportLevel, message);
        }
    }
}
