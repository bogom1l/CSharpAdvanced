using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();

            string text = Console.ReadLine();

            foreach (char symbol in text)
            {
                stack.Push(symbol);
            }
            
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }  
        }
    }
}
