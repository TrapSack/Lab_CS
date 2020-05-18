using System;

namespace Lab7
{
    class Program
    {
        static void Main()
        {
            {
                var rnd = new Random();
                Fraction[] sort = new Fraction[13];
                Console.Write("Массив: ");
                for (int i = 0; i < 13; i++)
                {
                    try
                    {
                        sort[i] = new Fraction(rnd.Next(-42, 42), rnd.Next(-42, 42));
                    }
                    catch
                    {
                        sort[i] = new Fraction(rnd.Next(-42, 42));
                    }
                    Console.Write($"{sort[i]} ");
                }
                Console.WriteLine();
                Array.Sort(sort);
                Console.Write("Отсортированный массив: ");
                for (int i = 0; i < 13; i++)
                {
                    Console.Write($"{sort[i]} ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            {
                Fraction a = new Fraction(3, 4);
                Fraction b = new Fraction(35, -42);
                Console.WriteLine($"3/4 = {a.Numerator}/{b.Denominator}");
                Console.WriteLine($"35/-42 = {b}");
                Console.WriteLine($"{a} + {b} = {a + b}");
                Console.WriteLine($"{a} - {b} = {a - b}");
                Console.WriteLine($"{a} * {b} = {a * b}");
                Console.WriteLine($"{a} / {b} = {a / b}");
                Console.WriteLine();
            }

            {
                decimal t = 420.13M;
                Fraction x = t;
                Console.WriteLine($"{t} == {x.ToString()}");
                Console.WriteLine($"{t} == {x.ToString("float")}");
                Console.WriteLine($"{t} == {x.ToString("binary")}");
                Console.WriteLine($"{t} ~= {x.ToString("integer")}");
                Console.WriteLine();

                t = -13.42M;
                x = t;
                Console.WriteLine($"{t} == {x.ToString()}");
                Console.WriteLine($"{t} == {x.ToString("float")}");
                Console.WriteLine($"{t} == {x.ToString("binary")}");
                Console.WriteLine($"{t} ~= {x.ToString("integer")}");
                Console.WriteLine();

                t = 42M;
                x = t;
                Console.WriteLine($"{t} == {x.ToString()}");
                Console.WriteLine($"{t} == {x.ToString("float")}");
                Console.WriteLine($"{t} == {x.ToString("binary")}");
                Console.WriteLine($"{t} ~= {x.ToString("integer")}");
                Console.WriteLine();

                t = -13.5M;
                x = t;
                Console.WriteLine($"{t} == {x.ToString()}");
                Console.WriteLine($"{t} == {x.ToString("float")}");
                Console.WriteLine($"{t} == {x.ToString("binary")}");
                Console.WriteLine($"{t} ~= {x.ToString("integer")}");
                Console.WriteLine();
            }

            {
                Console.WriteLine($"-420/-7 = {Fraction.Parse("-420/-7")}");
                Console.WriteLine($"42 = {Fraction.Parse("42")}");
                Console.WriteLine($"13.42 = {Fraction.Parse("13.42")}");
                Console.WriteLine($"13,42 = {Fraction.Parse("13,42")}");
                Console.WriteLine();
            }

            {
                Fraction x = Fraction.Parse("1 / 7");
                Console.WriteLine($"x == {x} == {(int)x} == {(double)x} == {(decimal)x}");
                x++;
                Console.WriteLine($"x++ == {x} == {(int)x} == {(double)x} == {(decimal)x}");
            }
        }
    }
}
