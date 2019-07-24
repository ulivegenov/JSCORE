
namespace Solid.Appenders
{
    using Contracts;
    using Solid.Layouts.Contracts;
    using Solid.Loggers.Enums;
    using System;

    public class ConsoleAppender : Appender, IAppander
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
           
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.reportLevel)
            {
                this.MessagesCount++;
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
            }
        }
        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}>,  + Report level: {reportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesCount}";
        }

    }
}
