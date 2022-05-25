using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(" -> ");
                    string currColor = tokens[0];
                string[] tokens2 = tokens[1].Split(",");

                foreach (var currClothe in tokens2)
                {

                    if (!dict.ContainsKey(currColor))
                    {
                        dict[currColor] = new Dictionary<string, int>();
                    }

                    if (!dict[currColor].ContainsKey(currClothe))
                    {
                        dict[currColor].Add(currClothe, 1);
                    }
                    else
                    {
                        dict[currColor][currClothe]++;
                    }
                }            
            }

            string[] tokens3 = Console.ReadLine().Split();
            string clotheToSearchFor = tokens3[1];
            string colorToSearchFor = tokens3[0];

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var v in item.Value)
                {
                    if (v.Key == clotheToSearchFor && item.Key == colorToSearchFor)
                    {
                        Console.WriteLine($"* {v.Key} - {v.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {v.Key} - {v.Value}");
                    }
                }
            }

        }
    }
}
