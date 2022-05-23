using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split(", ");
                string command = tokens[0];
                string carName = tokens[1];

                if (command == "IN")
                {
                    set.Add(carName);
                }
                else if(command == "OUT")
                {
                    set.Remove(carName);
                }

                input = Console.ReadLine();
            }

            if (set.Count > 0)
            {
                foreach (var item in set)
                {
                    Console.WriteLine($"{item}");
                }
            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }

        }
    }
}
