using System;
using System.Linq;
using System.Collections.Generic;

namespace _7._Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> myList = Console.ReadLine().Split().ToList();

            Predicate<string> isLessOrEqual = name => name.Length <= n;

            foreach (var name in myList.Where(x => isLessOrEqual(x)))
            {
                Console.WriteLine(name);
            }

        }
    }
}
