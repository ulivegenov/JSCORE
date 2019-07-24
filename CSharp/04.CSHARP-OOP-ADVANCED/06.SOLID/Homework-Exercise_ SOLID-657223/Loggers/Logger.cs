

namespace Solid.Loggers
{
    using System;
    using Solid.Appenders.Contracts;
    using Solid.Loggers.Contracts;
    using Solid.Loggers.Enums;

    public class Logger : ILogger
    {
        private readonly IAppander consoleAppender;
        private readonly IAppander fileAppender;
        public Logger(IAppander consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }
        public Logger(IAppander consoleAppender, IAppander fileAppender) : this(consoleAppender)
        {
            this.fileAppender = fileAppender;
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            this.AppendMessage(dateTime ,ReportLevel.Fatal, fatalMessage);

        }

        internal void Warning(string dateTime, string warningMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.Warning, warningMessage);
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.Critical, criticalMessage);

        }

        public void Error(string dateTime, string errorMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.Error, errorMessage);

        }

        public void Info(string dateTime, string infoMessage)
        {
            this.AppendMessage(dateTime, ReportLevel.Info, infoMessage);

        }

        private void AppendMessage(string dateTime, ReportLevel reportLevel, string message)
        {
            this.consoleAppender?.Append(dateTime, reportLevel, message);
            this.fileAppender?.Append(dateTime, reportLevel , message);
        }
    }
}
