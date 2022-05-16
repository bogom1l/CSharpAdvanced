using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            string command = Console.ReadLine().ToLower();

            while (command != "End")
            {
                string[] tokens = command.Split();  
                string cmd = tokens[0];

                if (cmd == "add")
                {
                    int firstNum = int.Parse(tokens[1]);
                    int secondNum = int.Parse(tokens[2]);

                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if(cmd == "remove")
                {
                    int count = int.Parse(tokens[1]);   
                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
