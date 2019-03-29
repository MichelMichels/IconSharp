using System;
using System.IO;

namespace IconSharp
{
    public class CurImageEntry : ImageEntry
    {
        public CurImageEntry(byte[] bytes)
        {
            SetBytes(bytes);
        }

        public byte LeftCenterOffset { get; set; }
        public byte TopCenterOffset { get; set; }

        public override void SetBytes(byte[] bytes)
        {
            using(var ms = new MemoryStream(bytes))
            using(var reader = new BinaryReader(ms))
            {
                Width = reader.ReadByte();
                Height = reader.ReadByte();
                NumberOfColors = reader.ReadByte();
                LeftCenterOffset = reader.ReadByte();
                TopCenterOffset = reader.ReadByte();
                ByteSize = reader.ReadInt32();
                Offset = reader.ReadInt32();
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
                binaryWriter.Write(LeftCenterOffset);
                binaryWriter.Write(TopCenterOffset);
                binaryWriter.Write(ByteSize);
                binaryWriter.Write(Offset);
                return ms.GetBuffer();
            }
        }
    }
}
