using System;
using System.Collections.Generic;
using System.Linq;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<double> elements = new List<double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double element = double.Parse(Console.ReadLine());
                elements.Add(element);
            }

            string valueToCompare = Console.ReadLine();

            Box<double> box = new Box<double>(elements);

            int ans = box.CountOfGreaterElements(elements, double.Parse(valueToCompare));
            Console.WriteLine(ans);
        }
    }
}
