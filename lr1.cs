using System;

namespace ConsoleApp1
{
    
    class Program
    {
        static void solve(int a, int b, int c)
        {
            double x1, x2;
            if ((a == 0) && (b == 0) && (c == 0))
            {
                Console.WriteLine("Корнем будет любое число\n");

            }
            else if (a == 0)
            {
                if (c > 0)
                {
                    Console.WriteLine("Корней нет");
                }
                else if (c < 0)
                {
                    x1 = Math.Sqrt(-c / b);
                    Console.WriteLine($"Корни уравнения - +- {x1}");
                }
                else if (c == 0)
                {
                    Console.WriteLine(0); 
                }



            }


            else
            {
                int t;
                t = b*b - 4 * a * c;


                if (t < 0)
                {
                    Console.WriteLine("Выражение не имеет корней\n");
                }
                else if (t == 0)
                {
                    x1 = x2 = -b / (2 * a);
                    if (x1 > 0) Console.WriteLine($"Корни уравнения - +-{Math.Sqrt(x1)}");
                    else if (x1 == 0)
                    {
                        Console.WriteLine($"Корень уравнения - {Math.Abs(Math.Sqrt(x1))}");

                    }
                    else
                    {
                        Console.WriteLine("Корней нет\n");
                    }
                }
                else
                {

                    x1 = (-b - Math.Sqrt(t)) / (2 * a);
                    x2 = (-b + Math.Sqrt(t)) / (2 * a);
                    if (x1 == 0)
                    {
                        Console.WriteLine($"Корни уравнения -  {Math.Sqrt(x1)} +- {Math.Sqrt(x2)}");
                    }

                    else if (x1 >= 0 && x2 >= 0)
                    {
                        Console.WriteLine($"Корни уравнения: - +- {Math.Sqrt(x1)} +- {Math.Sqrt(x2)}"); 
                    }
                    else if (x1 >= 0 && x2 <= 0)
                    {
                        Console.WriteLine($"Корни уравнения - +- {Math.Sqrt(x1)}"); 

                    }

                    else if (x1 < 0 && x2 < 0)
                    {
                        Console.WriteLine("Корней нет ");
                    }
                    else
                    {
                        Console.WriteLine($"Корни уравнения - +- {Math.Sqrt(x2)}");
                    }

                }
            }
        }

        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            solve(a, b, c);
        }
    }
}