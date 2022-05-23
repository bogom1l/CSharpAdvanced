using System;
using System.Collections.Generic;
using System.Linq;


namespace _3._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            numbers = numbers.OrderByDescending(x => x).ToList();

            for (int i = 0; i < 3; i++)
            {
                if (i < numbers.Count)
                {
                    Console.Write(numbers[i] + " ");
                }
            }

            //.v2
            /*
            var nums = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(el => el).ToList().Take(3);

            Console.WriteLine(string.Join(" ", nums));
            */
        }
    }
}
