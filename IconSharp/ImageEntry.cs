using IconSharp.Enums;
using IconSharp.Exceptions;
using System;
namespace IconSharp
{
    public abstract class ImageEntry : IByteConvertible
    {
        public byte Width { get; set; }
        public byte Height { get; set; }
        public byte NumberOfColors { get; set; }
        public byte Reserved => 0;
        public uint ByteSize { get; set; }
        public uint Offset { get; set; }

        public abstract byte[] GetBytes();
        public abstract void SetBytes(byte[] bytes);

        public static ImageEntry CreateNew(ImageType imageType)
        {
            switch(imageType)
            {
                case ImageType.CUR:
                    return new CurImageEntry();
                case ImageType.ICO:
                    return new IcoImageEntry();
                default:
                    throw new UnknownImageTypeException(imageType.ToString());
            }
        }
        public static CurImageEntry CreateNewCursor() => new CurImageEntry();
        public static CurImageEntry FromBytesCursor(byte[] bytes) => new CurImageEntry(bytes);
        public static IcoImageEntry CreateNewIcon() => new IcoImageEntry();
        public static IcoImageEntry FromBytesIcon(byte[] bytes) => new IcoImageEntry(bytes);
    }
}
