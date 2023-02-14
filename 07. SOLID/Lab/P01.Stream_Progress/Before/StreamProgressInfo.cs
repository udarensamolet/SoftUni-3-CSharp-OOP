using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress.Before
{
    public class StreamProgressInfo
    {
        private File file;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(File file)
        {
            this.file = file;
        }

        public int CalculateCurrentPercent()
        {
            return file.BytesSent * 100 / file.Length;
        }
    }
}
