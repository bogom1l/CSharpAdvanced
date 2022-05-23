using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_and_Dictionaries_Advanced___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Demo

            List<int> array = new List<int>() { 1, 2, 3, 53, 23, 11, 4, 30 };

            List<int> array2 = new List<int>();

            foreach (var item in array)
            {
                array2.Add(item);
            }

            array2.OrderBy(x => x);
            Console.WriteLine(string.Join(" ", array2));
            //

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            var sortedFruits = dictionary.OrderBy(pair => pair.Value).ThenBy(pair => pair.Key).ToDictionary(pair => pair.Key, pair => pair.Value);


        }
    }
}
