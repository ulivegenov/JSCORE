namespace Solid.Logger.Appenders
{
    using System;

    using Contracts;
    using Layouts.Contracts;
    using Solid.Logger.Loggers.Enums;

    public class ConsoleAppender : Appender
    {
        private readonly ILayout layout;

        public ConsoleAppender(ILayout layout) :
            base(layout)
        {
            this.layout = layout;
        }

        public override void Append(string dateTime, ReportLevel errorLevel, string message)
        {
            if (errorLevel >= this.ReportLevel)
            {
                this.messageCount++;
                Console.WriteLine(string.Format(this.layout.Format, dateTime, errorLevel, message));
            }   
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.messageCount}";

        }
    }
}
