using System;
namespace IconSharp
{
    public abstract class ImageEntry : IByteConvertible
    {
        public byte Width { get; set; }
        public byte Height { get; set; }
        public byte NumberOfColors { get; set; }
        public byte Reserved => 0;
        public int ByteSize { get; set; }
        public int Offset { get; set; }

        public abstract byte[] GetBytes();
        public abstract void SetBytes(byte[] bytes);
    }
}
