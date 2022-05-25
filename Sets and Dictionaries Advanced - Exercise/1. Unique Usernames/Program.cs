using System;
using System.Collections.Generic;

namespace _1._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                set.Add(input);
            }

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }

        }
    }
}
