using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Action action = new Action();
            action.AddOperation("mod", (x, y) => x % y);
            action.RemoveOperation("addition");
            action.GetNameOperations(Display);
            double result = action.DoOperation("mod", 6.4724, 6.46426);
            Display(result.ToString());
            action.RemoveOperation("mod");
            action.RemoveOperation("subtraction");
            action.RemoveOperation("multipcation");
            action.RemoveOperation("Division");
            action.GetNameOperations();

        }

        public static void Display(string name)
        {
            Console.WriteLine(name);
        }
    }
}
