using System;
using System.IO;
using IconSharp;

namespace IconSharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDir = Environment.CurrentDirectory;
            var iconPath = @"Resources\icontest.ico";
            var file = Path.Combine(currentDir, iconPath);

            var icon = Icon.FromFile(file);
            Console.WriteLine($"Image type       : {icon.Header.ImageType.ToString()}");
            Console.WriteLine($"Number of images : {icon.Header.NumberOfImages}");

            foreach(var kvp in icon.ImageDataByEntry)
            {
                var entry = kvp.Key;
                var data = kvp.Value;

                Console.WriteLine($"");
                Console.WriteLine($"Image dimensions (w x h):   {entry.Width} x {entry.Height}");
                Console.WriteLine($"Number of colors:           {entry.NumberOfColors}");
                Console.WriteLine($"Offset:                     {entry.Offset} bytes");
                Console.WriteLine($"Byte size:                  {entry.ByteSize} bytes");

                if(entry is IcoImageEntry icoEntry)
                {
                    Console.WriteLine($"Color planes:               {icoEntry.ColorPlanes}");
                    Console.WriteLine($"Bits per pixel:             {icoEntry.BitsPerPixel}");
                }

                if(entry is CurImageEntry curEntry)
                {
                    Console.WriteLine($"Left center offset:         {curEntry.LeftCenterOffset}");
                    Console.WriteLine($"Top center offset:          {curEntry.TopCenterOffset}");
                }

                Console.WriteLine($"Image data: {data.GetBytes().Length}");
            }

            Console.ReadKey();
        }
    }
}
