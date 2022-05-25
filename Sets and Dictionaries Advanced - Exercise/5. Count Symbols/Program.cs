using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            foreach (char c in text)
            {
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, 1);
                }
                else
                {
                    dict[c]++;
                }  
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value + " time/s");
            }

        }
    }
}
