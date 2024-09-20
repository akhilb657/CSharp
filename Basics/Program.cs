using System;
using Basics.Models;

namespace Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Computer myComputer = new Computer() {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 999.99m,
                VideoCard = "RTX 2060"
            };

            myComputer.HasWifi = false;

            Console.WriteLine(myComputer.Motherboard);
            Console.WriteLine(myComputer.HasLTE);
            Console.WriteLine(myComputer.HasWifi);
            Console.WriteLine(myComputer.ReleaseDate);
            Console.WriteLine(myComputer.VideoCard);
            Console.WriteLine(myComputer.Price);
        }
    }
}