using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //nz
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var ch in input)
            {
                if (stack.Count > 0)
                {
                    char stackLastSymbol = stack.Peek();

                    if (ch == ')' && stackLastSymbol == '('
                        || ch == '}' && stackLastSymbol == '{'
                        || ch == ']' && stackLastSymbol == '[')
                    {
                        stack.Pop();
                        continue;
                    }
                }
                stack.Push(ch);

            }

            Console.WriteLine(stack.Count > 0 ? "NO" : "YES");

        }
    }
}
