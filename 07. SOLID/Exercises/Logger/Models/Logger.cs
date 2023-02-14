using Logger.Contracts;
using Logger.Enums;

namespace Logger.Models
{
    public class Loger : ILogger
    {
        private IEnumerable<IAppender> appenders;

        public Loger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Critical(string dateTime, string messageText)
        {
            Log(dateTime, messageText, ReportLevel.Critical);
        }

        public void Error(string dateTime, string messageText)
        {
            Log(dateTime, messageText, ReportLevel.Error);
        }

        public void Fatal(string dateTime, string messageText)
        {
            Log(dateTime, messageText, ReportLevel.Fatal);
        }

        public void Info(string dateTime, string messageText)
        {
            Log(dateTime, messageText, ReportLevel.Info);
        }

        public void Warn(string dateTime, string messageText)
        {
            Log(dateTime, messageText, ReportLevel.Warning);
        }

        private void Log(string dateTime, string messageText, ReportLevel reportLevel)
        {
            IMessage message  = new Message(dateTime, reportLevel, messageText);
            foreach (var appender in appenders)
            {
                appender.Append(message);
            }
        }
    }
}
