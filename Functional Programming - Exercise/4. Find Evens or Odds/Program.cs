using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int min = numbers[0];
            int max = numbers[1];

            List<int> myList = new List<int>();

            for (int i = min; i <= max; i++)
            {
                myList.Add(i);
            }
            //Console.WriteLine(String.Join(" ", myList));

            string evenOrOdd = Console.ReadLine();

            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;

            if (evenOrOdd == "even")
            {
                int[] allEven = myList.Where(x => isEven(x)).ToArray();
                Console.WriteLine(String.Join(" ", allEven));
            }
            else if (evenOrOdd == "odd")
            {
                int[] allOdd = myList.Where(x => isOdd(x)).ToArray();
                Console.WriteLine(String.Join(" ", allOdd));
            }

        }

    }
}
