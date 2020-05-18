using System;
using System.Text;
using System.Collections.Generic;

namespace lab6
{
    interface IComparer
    {
        int Compare(object o1, object o2);
    }

    enum Direction
    {
        stop,
        top,
        right,
        down,
        left
    }
    interface IMovable
    {
        int Speed { get; set; }

        Point Position { get; set; }

        void Move()
        {
            Console.WriteLine("Move is'nt orerrided");
        }
    }

    interface IDrawable
    {
        int Width { get; set; }
        int Height { get; set; }

        void Draw()
        {
            Console.WriteLine("Draw is'nt orerrided");
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Stringify()
        {
            StringBuilder posSb = new StringBuilder();
            posSb.Append("X: ");
            posSb.Append(this.X);
            posSb.Append("; Y: ");
            posSb.Append(this.Y);
            posSb.Append(";");

            return posSb.ToString();
        }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    abstract class Entity : IMovable
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }

        public Point Position { get; set; }
        public Direction Dir { get; set; }

        public void Move()
        {
            switch (this.Dir)
            {
                case Direction.stop:
                    Console.WriteLine("Staying here..");
                    break;
                case Direction.top:
                    Console.WriteLine("{0} steps to top side", this.Speed);
                    this.Position = new Point(this.Position.X, this.Position.Y - 1);
                    break;
                case Direction.right:
                    Console.WriteLine("{0} steps to right side", this.Speed);
                    this.Position = new Point(this.Position.X + 1, this.Position.Y);
                    break;
                case Direction.down:
                    Console.WriteLine("{0} steps to down side", this.Speed);
                    this.Position = new Point(this.Position.X, this.Position.Y + 1);
                    break;
                case Direction.left:
                    Console.WriteLine("{0} steps to left side", this.Speed);
                    this.Position = new Point(this.Position.X - 1, this.Position.Y);
                    break;
            }
            Console.WriteLine("My Position is: {0}", this.Position.Stringify());
        }


        public Entity(Point startPosition, int width, int height, int speed)
        {
            this.Width = width;
            this.Height = height;
            this.Speed = speed;
            this.Position = startPosition;
            this.Dir = Direction.stop;
        }
    }

    class Player : Entity
    {
        public string Name { get; set; }

        public Player(Point startPosition, int width, int height, int speed, string name) : base(startPosition, width, height, speed)
        {
            this.Name = name;
        }
    }


    
    class PlayerComparer : IComparer<Player>
    {
        public int Compare(Player p1, Player p2)
        {
            if (p1.Name.Length > p2.Name.Length)
                return 1;
            else if (p1.Name.Length < p2.Name.Length)
                return -1;
            else
                return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(new Point(0, 0), 40, 80, 1, "Edward");
            Player player2 = new Player(new Point(0, 0), 40, 80, 1, "Tomas");
            player1.Dir = Direction.top;
            for (int i = 0; i < 3; i++) player1.Move();
            player1.Dir = Direction.right;
            for (int i = 0; i < 3; i++) player1.Move();
            
            PlayerComparer comparer = new PlayerComparer();
            Console.WriteLine(comparer.Compare(player1, player2));
        }
    }
}