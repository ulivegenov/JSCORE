
namespace Solid.Logger.Appenders
{
    using System;
    using System.IO;
    using Contracts;
    using Solid.Logger.Layouts.Contracts;
    using Solid.Logger.Loggers;
    using Solid.Logger.Loggers.Contracts;
    using Solid.Logger.Loggers.Enums;

    class FileAppender : Appender
    {
        private const string Path = "../../../log.txt";

        private ILayout layout;

        private readonly ILogFile logFile;

        public FileAppender(ILayout layout) 
            : base(layout)
        {
            this.logFile = new LogFile();
        }

        public FileAppender(ILayout layout, ILogFile logFile) 
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel errorLevel, string message)
        {
            if (errorLevel >= this.ReportLevel)
            {
                this.messageCount++;
                string contents = string.Format(this.Layout.Format, dateTime, errorLevel, message) + "\n";
                this.logFile.Write(contents);
                File.AppendAllText(Path, contents);
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.messageCount}," +
                $" File size: {this.logFile.Size}";

        }
    }
}
