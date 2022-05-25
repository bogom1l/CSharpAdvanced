using System;
using System.Collections.Generic;
using System.Linq;


namespace _4._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<int> set = new HashSet<int>();
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                set.Add(num);
                list.Add(num);
            }

            foreach (var item in set)
            {
                if (list.Contains(item))
                    list.Remove(item);
            }

            if(list.Count > 0)
                Console.WriteLine(list[0]);

        }
    }
}
