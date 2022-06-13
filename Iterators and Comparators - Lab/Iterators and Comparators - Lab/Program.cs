using System;

namespace IteratorsAndComparators
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PrintNames("name1", "name2");
            PrintNames("nameBG", "nameE","a","b","cc");
            PrintNames();
            PrintNames("w", "e", "l");
        }

        static void PrintNames(params string[] names)
        {
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
