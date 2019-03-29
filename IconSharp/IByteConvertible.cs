using System;
namespace IconSharp
{
    public interface IByteConvertible
    {
        void SetBytes(byte[] bytes);
        byte[] GetBytes();
    }
}
