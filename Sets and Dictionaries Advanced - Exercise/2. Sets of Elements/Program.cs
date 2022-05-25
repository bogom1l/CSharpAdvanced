using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            HashSet<int> set3 = new HashSet<int>();

            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = tokens[0];
            int m = tokens[1];

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                set1.Add(num);
            }

            for (int i = 0; i < m; i++)
            {
                int num = int.Parse(Console.ReadLine());
                set2.Add(num);
            }

            foreach (var item in set1)
            {
                if (set2.Contains(item))
                {
                    set3.Add(item);
                }
            }

            foreach (var item in set3)
            {
                Console.Write(item + " ");
            }
        }
    }
}
