using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, List<string>>>(); //Dictionary<string, Dictionary<string, List<string>>> dict

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string continent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (!dict.ContainsKey(continent))
                {
                    dict[continent] = new Dictionary<string, List<string>>();
                }

                if (!dict[continent].ContainsKey(country))
                {
                    dict[continent][country] = new List<string>();
                }

                dict[continent][country].Add(city);
            }

            foreach (var kvp in dict)
            {
                string currContinent = kvp.Key;
                Console.WriteLine($"{currContinent}:");

                foreach (var kvp2 in kvp.Value)
                {
                    string currCountry = kvp2.Key;
                    List<string> currCities = kvp2.Value;
                    Console.Write($"  {currCountry} -> ");
                    Console.Write($"{string.Join(", ", currCities)}");
                    Console.WriteLine();
                }
            }

        }
    }
}
