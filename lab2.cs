using System;
using System.Text;

namespace Lab2
{
    class Program
    {
        static bool isAnswer(char ch)
        {
            string eng = "ABCDEFGHLJKLMNOPQRSTUVWXYZ";

            bool isAnswer = true;
            for (int j = 0; j < eng.Length; j++)
            {
                if (ch == eng[j]) isAnswer = false;
            }

            return isAnswer;
        }
        static void Main()
        {

            Console.WriteLine("Enter the Text: ");
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsUpper(text[i]))
                {

                    if (isAnswer(text[i])) Console.Write(text[i]);
                }
            }

            Console.ReadLine();
        }
    }