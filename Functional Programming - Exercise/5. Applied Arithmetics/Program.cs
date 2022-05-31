using System;
using System.Linq;
using System.Collections.Generic;

namespace _5._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = numbers.Select(x => x += 1).ToList();
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(x => x = x * 2).ToList();
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(x => x -= 1).ToList();
                }
                else if (command == "print")
                {
                    print(numbers);
                }

                command = Console.ReadLine();
            }

        }
    }
}
