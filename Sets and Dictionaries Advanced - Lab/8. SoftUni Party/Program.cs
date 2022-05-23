using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set1 = new HashSet<string>();
            HashSet<string> set2 = new HashSet<string>();

            while (true)
            {
                string guest = Console.ReadLine();

                if (guest == "PARTY")
                {
                    break;
                }
                
                set1.Add(guest);
            }

            while (true)
            {
                string guest = Console.ReadLine();

                if (guest == "END")
                {
                    break;
                }

                set2.Add(guest);
            }

            int cnt = 0;

            foreach (var item in set1)
            {
                if (!set2.Contains(item))
                {
                    cnt++;
                }
            }

            Console.WriteLine(cnt);

            foreach (string item in set1)
            {
                if (!set2.Contains(item))
                {
                    char firstLetter = item[0];
                    if (Char.IsDigit(firstLetter))
                    {
                        Console.WriteLine(item);
                    } 
                }
            }

            foreach (string item in set1)
            {
                if (!set2.Contains(item))
                {
                    char firstLetter = item[0];
                    if (!Char.IsDigit(firstLetter))
                    {
                        Console.WriteLine(item);
                    }
                }
            }


        }
    }
}
