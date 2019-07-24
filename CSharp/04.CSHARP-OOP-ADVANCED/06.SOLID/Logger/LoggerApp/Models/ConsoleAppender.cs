using LoggerApp.Enums;
using LoggerApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerApp.Models
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevel level)
        {
            this.Layout = layout;
            this.Level = level;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }

        public ReportLevel Level { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formatedError = this.Layout.FormateError(error);
            Console.WriteLine(formatedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string appenderType = GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string reportLevel = this.Level.ToString();
            string messagesAppended = this.MessagesAppended.ToString();
            string result = $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {reportLevel}, Messages appended: {messagesAppended}";
            return result;
        }
    }
}
