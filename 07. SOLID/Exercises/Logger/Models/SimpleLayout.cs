using Logger.Contracts;

namespace Logger.Models
{
    public class SimpleLayout : ILayout
    { 
        public SimpleLayout() 
        {
        }

        public string FormatMessage(IMessage message)
        {
            return $"{message.DateTime} - {message.ReportLevel} - {message.MessageText}";
        }
    }
}
