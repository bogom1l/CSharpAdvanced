using System;
using System.Collections.Generic;
using System.Linq;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                list.Add(input);
            }

            Box<string> box = new Box<string>(list);

            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray(); ;
            int index1 = tokens[0];
            int index2 = tokens[1];

            box.Swap(list, index1, index2);
            Console.WriteLine(box);
        }
    }
}
