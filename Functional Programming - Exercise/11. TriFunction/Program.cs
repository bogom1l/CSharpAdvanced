using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> people = Console.ReadLine().Split().ToList();

            string name = people.First(name => name.Select(symbol => (int)symbol).Sum() >= n);
            Console.WriteLine(name);
        }
    }
}
