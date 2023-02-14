using Logger.Contracts;
using Logger.Enums;

namespace Logger.Models
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout simpleLayout) 
        {
            Layout = simpleLayout;   
        }
        public ILayout Layout { get; private set; }
        public ReportLevel ReportLevel { get; protected internal set; }

        public void Append(IMessage message)
        {
            if (message.ReportLevel < ReportLevel)
            {
                return;
            }

            Console.WriteLine(Layout.FormatMessage(message));
        }
    }
}
