using Logger.Contracts;
using System.Text;

namespace Logger.Models
{
    public class LogFile : ILogFile
    {
        private StringBuilder _sb;

        public LogFile()
        {
            _sb = new StringBuilder();
        }

        public void Write(string message)
        {
            _sb.Append(message);
            File.AppendAllText("log.txt", message + Environment.NewLine);

        }

        public int Size => _sb.ToString()
            .Where(c => c >= 'a' && c <= 'z' ||
                        c >= 'A' && c <= 'Z')
            .Sum(c => c);
    }
}
