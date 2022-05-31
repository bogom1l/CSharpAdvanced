using System;
using System.Linq;

namespace _1._Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = (string s) => Console.WriteLine(s);

            string[] words = Console.ReadLine().Split();

            foreach (var word in words)
            {
                print(word);
            }

        }
    }
}
