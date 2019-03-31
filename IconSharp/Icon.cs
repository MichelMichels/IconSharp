using System;
using System.IO;
using System.Collections.Generic;
using IconSharp.Helpers;
using IconSharp.Enums;

namespace IconSharp
{
    public class Icon
    {
        private Icon()
        {
            Header = Header.CreateNew();
            ImageEntries = new List<ImageEntry>();
            ImageDataByEntry = new Dictionary<ImageEntry, ImageData>();
        }
        private Icon(string filePath)
        {
            ImageEntries = new List<ImageEntry>();
            ImageDataByEntry = new Dictionary<ImageEntry, ImageData>();

            if (File.Exists(filePath))
            {
                LoadFile(filePath);
            }
            else
            {
                throw new FileNotFoundException("Icon file not found", filePath);
            }
        }
        
        public static Icon CreateNew() => new Icon();
        public static Icon FromFile(string filePath) => new Icon(filePath);      
        
        public Header Header { get; set; }
        public IList<ImageEntry> ImageEntries { get; set; }
        public Dictionary<ImageEntry, ImageData> ImageDataByEntry { get; set; }

        /// <summary>
        /// Loads the icon into the Icon data structure.
        /// </summary>
        /// <param name="filePath">Path to the icon or cursor file.</param>
        private void LoadFile(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open))
            {
                var headerBytes = ReadBytes(fs, Constants.HeaderByteSize);
                Header = Header.FromBytes(headerBytes);
         
                for (int i = 0; i < Header.NumberOfImages; i++)
                {
                    var imageEntryBytes = ReadBytes(fs, Constants.ImageEntryByteSize);
                    ImageEntry entry = Header.ImageType == ImageType.ICO ? (ImageEntry)ImageEntry.FromBytesIcon(imageEntryBytes) : ImageEntry.FromBytesCursor(imageEntryBytes);

                    ImageEntries.Add(entry);
                }

                foreach(var entry in ImageEntries)
                {
                    fs.Seek(entry.Offset, SeekOrigin.Begin);

                    var data = ImageData.FromBytes(ReadBytes(fs, (int)entry.ByteSize));
                    ImageDataByEntry.Add(entry, data);
                }
            }
        }
        private byte[] ReadBytes(FileStream fs, int byteSize)
        {
            var headerBuffer = new byte[byteSize];
            fs.Read(headerBuffer, 0, headerBuffer.Length);
            return headerBuffer;
        }
    }
}
