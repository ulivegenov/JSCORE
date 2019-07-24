
namespace Solid.Appenders
{
    using Solid.Appenders.Contracts;
    using Solid.Layouts.Contracts;
    using Solid.Loggers.Contracts;
    using Solid.Loggers.Enums;
    using System;
    using System.IO;

    public class FileAppender : Appender, IAppander
    {

        private readonly ILogFile logFile;
        private const string path = "SearchForThisFile.txt";

        public ReportLevel reportLevel { get; set; }
        public int MessagesCount { get; private set; }


        public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.reportLevel)
            {
                this.MessagesCount++;
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
                this.logFile.Write(content);
                File.AppendAllText(path, content);
            }
        }
        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}>,  + Report level: {reportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesCount}, File size: {this.logFile.Size}";
        }
    }
}
