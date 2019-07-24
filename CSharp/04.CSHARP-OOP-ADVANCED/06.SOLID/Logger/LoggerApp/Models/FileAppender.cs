using LoggerApp.Enums;
using LoggerApp.Models.Contracts;

namespace LoggerApp.Models
{
    public class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ReportLevel level, ILogFile logFile)
        {
            this.Layout = layout;
            this.Level = level;
            this.logFile = logFile;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }

        public ReportLevel Level { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormateError(error);
            this.logFile.WriteToFile(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string appenderType = GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string reportLevel = this.Level.ToString();
            string messagesAppended = this.MessagesAppended.ToString();
            string result = $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {reportLevel}, Messages appended: {messagesAppended}, File Size: {this.logFile.Size}";
            return result;
        }
    }
}