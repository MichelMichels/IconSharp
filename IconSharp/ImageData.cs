using System;
using System.Collections.Generic;
using System.Text;

namespace IconSharp
{
    public class ImageData : IByteConvertible
    {
        private byte[] bytes;

        private ImageData()
        {

        }
        private ImageData(byte[] bytes)
        {
            SetBytes(bytes);
        }

        public static ImageData CreateNew() => new ImageData();
        public static ImageData FromBytes(byte[] bytes) => new ImageData(bytes);

        public byte[] GetBytes()
        {
            return bytes;
        }

        public void SetBytes(byte[] bytes)
        {
            this.bytes = bytes;
        }
    }
}
