using System;
using System.Text;

namespace TextAdventure;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Rooms.Initialize();
        Game.Start();
    }
}