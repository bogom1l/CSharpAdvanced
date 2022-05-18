using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();    
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();

                int command = int.Parse(tokens[0]);
                
                if (command == 1)
                {
                    int x = int.Parse(tokens[1]);
                    stack.Push(x);
                }
                else if (command == 2)
                {
                    if (stack.Count > 0)
                        stack.Pop();
                }
                else if (command == 3)
                {
                    if(stack.Count > 0)
                        Console.WriteLine(stack.Max());
                }
                else if (command == 4)
                {
                    if (stack.Count > 0)
                        Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine($"{string.Join(", ", stack)}");


        }
    }
}
