using System;
using System.Collections.Generic;
using System.Linq;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> elements = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string element = Console.ReadLine();
                elements.Add(element);
            }

            string valueToCompare = Console.ReadLine();

            Box<string> box = new Box<string>(elements);

            int ans = box.CountOfGreaterElements(elements, valueToCompare);
            Console.WriteLine(ans);
        }
    }
}
