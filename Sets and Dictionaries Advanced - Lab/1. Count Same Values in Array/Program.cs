using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> dictionary = new Dictionary<double, int>();

            foreach (double num in numbers)
            {
                if (dictionary.ContainsKey(num))
                {
                    dictionary[num]++;
                }
                else
                {
                    dictionary.Add(num, 1);
                }
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }

        }
    }
}
