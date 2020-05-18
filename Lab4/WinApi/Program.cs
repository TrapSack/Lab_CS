using System;

namespace WinApi
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Player player = new Player();
            Console.WriteLine("Esc - stop");
            Console.WriteLine("Space - (un)pause");
            Console.WriteLine("ArrowsLR - rewind");
            Console.WriteLine("ArrowsUD - volume");
            while (true)
            {
                Console.WriteLine("Enter the full path to sound:");
                string path = Console.ReadLine();
                if (!player.Play(path))
                {
                    Console.WriteLine("Wrong path!");
                    continue;
                }
                ConsoleKey sym;
                do
                {
                    sym = Console.ReadKey(true).Key;
                    switch (sym)
                    {
                        case ConsoleKey.Spacebar:
                            player.Pause();
                            break;
                        case ConsoleKey.LeftArrow:
                            player.SetTiming(player.GetTiming() - 5 * 1000);
                            break;
                        case ConsoleKey.RightArrow:
                            player.SetTiming(player.GetTiming() + 5 * 1000);
                            break;
                        case ConsoleKey.UpArrow:
                            player.Volume += 5;
                            break;
                        case ConsoleKey.DownArrow:
                            player.Volume -= 5;
                            break;
                        case ConsoleKey.Escape:
                            player.Stop();
                            break;
                    }
                } 
                while (sym != ConsoleKey.Escape);
            }
        }
    }
}
