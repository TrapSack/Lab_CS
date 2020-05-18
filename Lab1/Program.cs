using System;

namespace Lab1
{
    class Program
    {
        static void PlayGemPuzzle()
        {
            GemPuzzle game = new GemPuzzle();
            Console.WriteLine("Введите размер поля (от 3 до 9)");
            int n;
            try
            {
                n = Convert.ToInt32(Console.ReadLine());
                game.CreateField(n);
                game.Shuffle();
            }
            catch (Exception)
            {
                Console.WriteLine("Неправильный ввод размера поля");
                return;
            }
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write(game.Redraw());
            while (!game.Victory())
            {
                var sym = Console.ReadKey(true);
                switch (sym.Key)
                {
                    case ConsoleKey.UpArrow:
                        game.MakeMove(GemPuzzle.Move.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        game.MakeMove(GemPuzzle.Move.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        game.MakeMove(GemPuzzle.Move.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        game.MakeMove(GemPuzzle.Move.Right);
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
                Console.SetCursorPosition(0, 0);
                Console.Write(game.Redraw());
            }
            Console.CursorVisible = true;
            Console.WriteLine("Хорошо сыграно! \n");
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo sym;
            do
            {
                Console.Clear();
                PlayGemPuzzle();
                Console.WriteLine("Хотите сыграть ещё? Esc/Enter");
                sym = Console.ReadKey(true);
                while ((sym.Key != ConsoleKey.Enter) && (sym.Key != ConsoleKey.Escape))
                {
                    sym = Console.ReadKey(true);
                }
            } 
            while (sym.Key != ConsoleKey.Escape);
            Console.Clear();
            Console.WriteLine("\n Хорошего дня!");
        }
    }
}
