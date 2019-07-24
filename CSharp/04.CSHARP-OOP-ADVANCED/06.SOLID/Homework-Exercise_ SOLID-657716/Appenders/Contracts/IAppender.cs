namespace Solid.Appenders.Contracts
{
    using Loggers.Enums;
    public interface IAppender
    {
        void Append(string datetime, ReportLevel reportLevel, string message);
        ReportLevel ReportLevel { get; set; }
        int MessagesCount { get; }
    }
}
