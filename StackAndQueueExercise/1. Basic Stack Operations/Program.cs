using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int N = tokens[0];
            int S = tokens[1];
            int X = tokens[2];

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < N; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < S; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(X))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }

        }
    }
}
