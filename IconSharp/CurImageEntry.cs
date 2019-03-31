using System;
using System.IO;

namespace IconSharp
{
    public class CurImageEntry : ImageEntry
    {
        protected internal CurImageEntry() : base()
        {

        }
        protected internal CurImageEntry(byte[] bytes)
        {
            SetBytes(bytes);
        }

        public ushort LeftCenterOffset { get; set; }
        public ushort TopCenterOffset { get; set; }

        public override void SetBytes(byte[] bytes)
        {
            using(var ms = new MemoryStream(bytes))
            using(var reader = new BinaryReader(ms))
            {
                Width = reader.ReadByte();
                Height = reader.ReadByte();
                NumberOfColors = reader.ReadByte();
                reader.ReadByte();
                LeftCenterOffset = reader.ReadUInt16();
                TopCenterOffset = reader.ReadUInt16();
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
                binaryWriter.Write(LeftCenterOffset);
                binaryWriter.Write(TopCenterOffset);
                binaryWriter.Write(ByteSize);
                binaryWriter.Write(Offset);
                return ms.GetBuffer();
            }
        }
    }
}
