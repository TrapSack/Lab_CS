using System;
using System.Text;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(" ");
                Console.WriteLine(" 1 - С помощью класса DateTime вывести на консоль названия месяцев на французском языке. По желанию обобщить на случай, когда язык задается с клавиатуры. \n");
                Console.WriteLine(" 2 - Рассчитать максимальную степень двойки, на которую делится произведение подряд идущих чисел от a до b (числа целые 64-битные без знака). \n");
                Console.WriteLine(" 3 - Дана строка, содержащая число с десятичной точкой. Преобразовать эту строку в число действительного типа (не пользуясь стандартным Parse/TryParse). \n");
                Console.WriteLine(" Esc - выход \n ");

                bool wrongKey;
                do
                {
                    wrongKey = false;
                    var sym = Console.ReadKey(true);
                    switch (sym.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            MonthsNamesTask();
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            MaxDegreeOfTwoTask();
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            StringToFloatTask();
                            break;

                        case ConsoleKey.Escape:
                            Console.Clear();
                            Console.WriteLine("\n   Хорошего дня! ");
                            return;
                        default:
                            wrongKey = true;
                            break;
                    }
                } while (wrongKey);

                Console.WriteLine("\n Нажмите любую клавишу для продолжения ");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        static void MonthsNamesTask()
        {
            Console.Clear();
            string str;
            while (true)
            {
                Console.WriteLine("Введите: / язык на английском / язык в формате TwoLetterISO / символ ? для просмотра списка языков /");
                str = Console.ReadLine().Trim();
                if (str == "?")
                {
                    Console.WriteLine(MonthsNames.LanguageList());
                    continue;
                }
                string ans;
                try
                {
                    ans = MonthsNames.GetMonths(MonthsNames.LanguageToCulture(str));
                }
                catch (Exception)
                {
                    Console.WriteLine("Неверный ввод!");
                    continue;
                }
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine(ans);
                Console.OutputEncoding = Encoding.Default;
                break;
            }
        }
        static void MaxDegreeOfTwoTask()
        {
            Console.Clear();
            ulong a, b;
            while (true)
            {
                Console.WriteLine("Введите числа a и b через пробел:");
                try
                {
                    string str = Console.ReadLine().Trim();
                    while (str[str.IndexOf(' ')] == str[str.IndexOf(' ') + 1])
                    {
                        str = str.Remove(str.IndexOf(' '), 1);
                    }
                    if (str.Split(' ').Length != 2)
                    {
                        throw new Exception("Чисел не два\n");
                    }
                    a = Convert.ToUInt64(str.Split(' ')[0]);
                    b = Convert.ToUInt64(str.Split(' ')[1]);
                    Console.WriteLine("2^{0} | П{1}..{2} ", MaxDegreeOfTwo.Solve(a, b), a, b);
                    //Console.WriteLine("2^{0} | П{1}..{2} ", MaxDegreeOfTwo.SlowSolve(a, b), a, b);
                    //Console.WriteLine("2^{0} | П{1}..{2} ", MaxDegreeOfTwo.BigIntSolve(a, b), a, b);
                }
                catch (Exception)
                {
                    Console.WriteLine("Неправильно введены числа\n");
                    continue;
                }
                break;
            }
        }
        static void StringToFloatTask()
        {
            Console.Clear();
            Console.WriteLine("\nВведите строку с вещественным числом: ");
            string str = Console.ReadLine();
            double ans;
            try
            {
                ans = StringToFloat.ConvertStringToFloat(str);
            }
            catch (Exception)
            {
                Console.WriteLine("Неверный ввод");
                return;
            }
            Console.WriteLine("{0}", ans);
        }
    }
}
