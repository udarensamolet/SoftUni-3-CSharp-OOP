using Logger.Enums;

namespace Logger.Contracts
{
    public interface IMessage
    {
        string DateTime { get; }
        ReportLevel ReportLevel { get; }
        string MessageText { get; }
    }
}
