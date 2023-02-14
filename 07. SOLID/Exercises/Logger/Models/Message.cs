using Logger.Contracts;
using Logger.Enums;

namespace Logger.Models
{
    public class Message : IMessage
    {
        public Message(string dateTime, ReportLevel reportLevel, string messageText)
        {
            DateTime = dateTime;
            ReportLevel = reportLevel;
            MessageText = messageText;
        }

        public string DateTime { get; private set;  }

        public ReportLevel ReportLevel { get; private set; }

        public string MessageText { get; private set; }
    }
}
