using Logger.Contracts;
using Logger.Enums;

namespace Logger.Models
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout simpleLayout, ILogFile logFile = null)
        {
            Layout = simpleLayout;
        }
        public ILayout Layout { get; private set; }
        public ReportLevel ReportLevel { get; private set; }

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
