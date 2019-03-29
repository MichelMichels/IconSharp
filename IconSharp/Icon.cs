using System;
using System.IO;
using System.Collections.Generic;

namespace IconSharp
{
    public class Icon
    {
        private const int HEADER_BYTE_SIZE = 6;

        public Icon()
        {
            Header = new Header();
            ImageEntries = new List<ImageEntry>();
        }
        public Icon(string filePath)
        {
            if(File.Exists(filePath))
            {
                LoadFile(filePath);
            }
            else
            {
                throw new FileNotFoundException("Icon file not found", filePath);
            }
        }

        private void LoadFile(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var headerBuffer = new byte[HEADER_BYTE_SIZE];
                fs.Read(headerBuffer, 0, headerBuffer.Length);
                Header = new Header(headerBuffer);
            }
        }

        public Header Header { get; set; }
        public IList<ImageEntry> ImageEntries { get; set; }
    }
}
