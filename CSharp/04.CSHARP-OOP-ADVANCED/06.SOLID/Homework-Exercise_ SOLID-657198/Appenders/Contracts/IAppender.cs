using Solid.Logger.Loggers.Enums;

namespace Solid.Logger.Appenders.Contracts
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, ReportLevel errorLevel, string message);

        int messageCount { get; }
    }
}