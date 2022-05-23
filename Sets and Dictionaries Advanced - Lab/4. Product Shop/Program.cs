using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary
            var dict = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] tokens = input.Split(", ");
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!dict.ContainsKey(shop))
                {
                    dict.Add(shop, new Dictionary<string,double>());
                }
                //dict[shop][product] = price;    
                dict[shop].Add(product, price);

                input = Console.ReadLine();
            }

            //var orderedDict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            //var orderedDict = dict.OrderBy(x => x.Key);

            foreach (var kvp in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}->");

                foreach (var (product, price) in kvp.Value)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }


        }
    }
}
