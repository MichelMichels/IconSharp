using System;
using System.IO;
using IconSharp.Enums;

namespace IconSharp
{
    public class Header : IByteConvertible
    {
        private Header()
        {
            ImageType = ImageType.ICO;
            NumberOfImages = 1;
        }
        private Header(byte[] bytes)
        {
            SetBytes(bytes);
        }

        public static Header CreateNew() => new Header();
        public static Header FromBytes(byte[] bytes) => new Header(bytes);

        public ushort Reserved => 0;
        public ImageType ImageType { get; set; }
        public ushort NumberOfImages { get; set; }

        public byte[] GetBytes()
        {
            using(var ms = new MemoryStream(6))
            using(var writer = new BinaryWriter(ms))
            {
                writer.Write(Reserved);
                writer.Write((ushort)ImageType);
                writer.Write(NumberOfImages);
                return ms.GetBuffer();
            }
        }
        public void SetBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            using (var reader = new BinaryReader(ms))
            {
                reader.ReadUInt16();
                ImageType = (ImageType)reader.ReadUInt16();
                NumberOfImages = reader.ReadUInt16();
            }
        }
    }
}
