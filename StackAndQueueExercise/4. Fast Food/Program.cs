using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();  

            Queue<int> queue = new Queue<int>(numbers);

            Console.WriteLine(numbers.Max());

            while (queue.Count > 0)
            {
                int currFood = queue.Peek();

                if (quantity >= currFood)
                {
                    quantity -= currFood;
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
