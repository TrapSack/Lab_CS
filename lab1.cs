using System;

namespace Labs
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Enter the a, b and c...");

            double a, b, c;
            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            c = Convert.ToDouble(Console.ReadLine());

            double d = b * b - (4 * a * c);
            if (d < 0)
            {
                Console.WriteLine("There is no answers!");
                return;
            }

            double x1 = (-b - Math.Sqrt(d)) / (2 * a);
            double x2 = (-b + Math.Sqrt(d)) / (2 * a);


            int count = 1;
            if (x1 >= 0)
            {
                Console.WriteLine("x{0} = {1}", count, Math.Sqrt(x1));
                count++;
                Console.WriteLine("x{0} = {1}", count, -Math.Sqrt(x1));
                count++;

                if (x1 == x2)
                {
                    Console.ReadLine();
                    return;
                }

            }
            if (x2 >= 0)
            {
                Console.WriteLine("x{0} = {1}", count, Math.Sqrt(x2));
                count++;
                Console.WriteLine("x{0} = {1}", count, -Math.Sqrt(x2));
                count++;
            }


            Console.ReadLine();
        }
    }
}