using Logger.Contracts;

namespace Logger.Models
{
    public class XmlLayout : ILayout
    {
        public XmlLayout()
        {
        }

        public string FormatMessage(IMessage message)
        {
            return "<log>" + Environment.NewLine +
                        $"\t<date>{message.DateTime}</date></log>" + Environment.NewLine +
                        $"\t<level>{message.ReportLevel}</level></log>" + Environment.NewLine +
                        $"\t<message>{message.MessageText}</message></log>" + Environment.NewLine +
                   "</log>";
        }
    }
}
