using Logger.Enums;

namespace Logger.Contracts
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; }
        ILayout Layout { get; }
        void Append(IMessage message);
    }
}
