using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isCapitalFirstletter =
                (string x) => x.Length > 0 && Char.IsUpper(x[0]);

            string[] words = Console.ReadLine().Split(" ").Where(x => isCapitalFirstletter(x)).ToArray();

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
