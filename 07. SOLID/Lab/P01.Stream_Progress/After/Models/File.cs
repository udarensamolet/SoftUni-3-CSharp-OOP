using P01.Stream_Progress.After.Contracts;

namespace P01.Stream_Progress.After.Models
{
    public class File : IStreamable
    {
        private string name;
        public File(string name, int length, int bytesSent)
        {
            this.name = name;
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length { get; private set; }

        public int BytesSent { get; private set; }
    }
}
