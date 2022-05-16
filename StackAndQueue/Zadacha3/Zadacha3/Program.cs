using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadacha3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Matching Brackets

            var stack = new Stack<int>();

            string expression = Console.ReadLine();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (c == '(')
                {
                    stack.Push(i);
                }
                else if(c == ')')
                {
                    int startIndex = stack.Pop();
                    int endIndex = i;
                    string subExpression = expression.Substring(startIndex, endIndex - startIndex + 1);
                    Console.WriteLine(subExpression);
                }
            }





        }
    }
}
