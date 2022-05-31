using System;
using System.Linq;
using System.Collections.Generic;

namespace _8._List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            List<int> deviders = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 1; i <= N; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> validationFunc = number =>
            {
                foreach (var num in deviders)
                {
                    if (number % num != 0)
                    {
                        return false;
                    }
                }
                return true;
            };

            numbers.Where(x => validationFunc(x)).ToList().ForEach(x => Console.Write(x + " "));
        }
    }
}
