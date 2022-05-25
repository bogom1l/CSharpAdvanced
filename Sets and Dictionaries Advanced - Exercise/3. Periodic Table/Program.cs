using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> set = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();

                foreach (var elem in tokens)
                {
                    set.Add(elem);
                }
            }

            foreach (var elem in set)
            {
                Console.Write(elem + " ");
            }
        }
    }
}
