using System;
using System.IO;

namespace IconSharp
{
    public class IcoImageEntry : ImageEntry
    {
        protected internal IcoImageEntry()
        {

        }
        protected internal IcoImageEntry(byte[] bytes)
        {
            SetBytes(bytes);
        }

        public ushort ColorPlanes { get; set; }
        public ushort BitsPerPixel { get; set; }

        public override void SetBytes(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            using (var reader = new BinaryReader(ms))
            {
                Width = reader.ReadByte();
                Height = reader.ReadByte();
                NumberOfColors = reader.ReadByte();
                reader.ReadByte();
                ColorPlanes = reader.ReadUInt16();
                BitsPerPixel = reader.ReadUInt16();
                ByteSize = reader.ReadUInt32();
                Offset = reader.ReadUInt32();
            }
        }
        public override byte[] GetBytes()
        {
            using (var ms = new MemoryStream(16))
            using (var binaryWriter = new BinaryWriter(ms))
            {
                binaryWriter.Write(Width);
                binaryWriter.Write(Height);
                binaryWriter.Write(NumberOfColors);
                binaryWriter.Write(Reserved);
                binaryWriter.Write(ColorPlanes);
                binaryWriter.Write(BitsPerPixel);
                binaryWriter.Write(ByteSize);
                binaryWriter.Write(Offset);
                return ms.GetBuffer();
            }
        }
    }
}
