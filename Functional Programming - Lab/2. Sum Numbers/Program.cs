using System;
using System.Linq;

namespace _2._Sum_Numbers
{
    internal class Program
    {
        static int Parse(string str) => int.Parse(str);
        
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(Parse).ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}
