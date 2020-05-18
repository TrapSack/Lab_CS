using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Reverse_Polish_Notation
{
    class Program
    {
		const string dll = "Maths.dll";
		
		[DllImport(dll, EntryPoint = "plus", CallingConvention = CallingConvention.StdCall)]
        public static extern double plus(double a, double b);

        [DllImport(dll, EntryPoint = "minus", CallingConvention = CallingConvention.Cdecl)]
        public static extern double minus(double a, double b);

        [DllImport(dll, EntryPoint = "multi", CallingConvention = CallingConvention.Winapi)]
        public static extern double multi(double a, double b);

        [DllImport(dll, EntryPoint = "divide", CallingConvention = CallingConvention.Cdecl)]
        public static extern double divide(double a, double b);


		const string opers = "(+-*/)";
		static string ExpressionToRpn(string exp)
		{
			StringBuilder input = new StringBuilder();
			input.Append('(');
			input.Append(exp);
			input.Append(')');
			for (int i = 0; i < opers.Length; i++)
			{
				input.Replace(opers[i].ToString(), " " + opers[i] + " ");
			}
			input.Replace("  ", " ");
			input.Replace(".", ",");
			string[] tmp = input.ToString().Split();
			List<string> rpn = new List<string>();
			Stack<string> st = new Stack<string>();
			for (int i = 1; i < tmp.Length - 1; i++)
			{
				if (opers.Contains(tmp[i]))
				{
					switch (tmp[i])
					{
						case "(":
							st.Push("(");
							break;
						case ")":
							while (st.Peek() != "(")
							{ 
								rpn.Add(st.Pop());
							}
							st.Pop();
							break;
						default:
							static int OperPrior(char x)
							{
								switch (x)
								{
									case '(':
										return 0;
									case '+':
									case '-':
										return 1;
									case '/':
									case '*':
										return 2;
									default:
										throw new Exception("Wrong operator");
								}
							}
							while (OperPrior(tmp[i][0]) <= OperPrior(st.Peek()[0]))
							{
								rpn.Add(st.Pop());
							}
							st.Push(tmp[i]);
							break;
					}
				} 
				else
				{
					rpn.Add(tmp[i]);
				}
			}
			if (st.Count > 0)
			{
				throw new Exception("Wrong expression");
			}
			StringBuilder output = new StringBuilder();
			for (int i = 0; i < rpn.Count; i++)
			{
				if (i > 0)
				{
					output.Append(' ');
				}
				output.Append(rpn[i]);
			}
			return output.ToString();
		}
		static double RpnToNumber(string rpn)
		{
			string[] tmp = rpn.Split();
			Stack<double> st = new Stack<double>();
			for (int i = 0; i < tmp.Length; i++)
			{
				if (opers.Contains(tmp[i]))
				{
					double t2 = st.Pop();
					double t1 = st.Pop();
					switch (tmp[i])
					{
						case "+":
							st.Push(plus(t1, t2));
							break;
						case "-":
							st.Push(minus(t1, t2));
							break;
						case "*":
							st.Push(multi(t1, t2));
							break;
						case "/":
							st.Push(divide(t1, t2));
							break;
						default:
							throw new Exception("Wrong operator");
					}
				} 
				else
				{
					st.Push(Double.Parse(tmp[i]));
				}
			}
			if (st.Count != 1)
			{
				throw new Exception("Wrong expression");
			}
			return st.Pop();
		}

        static void Main(string[] args)
        {
			try
			{
				_ = plus(0, 0);
			}
			catch
			{
				Console.WriteLine("Не удалось загрузить DLL");
			}
			while (true)
			{
				try
				{
					Console.WriteLine();
					Console.WriteLine("Введите числовое выражение:");
					string s = ExpressionToRpn(Console.ReadLine());
					Console.WriteLine("RPN: " + s);
					double ans = RpnToNumber(s);
					if (!Double.IsFinite(ans))
					{
						throw new Exception("Undefined answer");
					}
					Console.WriteLine(ans);
				}
				catch
				{
					Console.WriteLine("Неверное выражение");
				}
			}
		}
    }
}
