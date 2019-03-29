using System;
using IconSharp;

namespace IconSharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var icon = new Icon();
            Console.WriteLine($"Image type       : {icon.Header.ImageType.ToString()}");
            Console.WriteLine($"Number of images : {icon.Header.NumberOfImages}");

            Console.ReadKey();
        }
    }
}
