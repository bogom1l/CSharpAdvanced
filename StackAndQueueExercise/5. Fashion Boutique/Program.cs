using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //nz
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(numbers);

            int currentRackCapacity = rackCapacity;
            int rackCount = 1;

            while (clothes.Any())
            {
                int currentClothes = clothes.Pop();

                if (currentClothes > currentRackCapacity)
                {
                    rackCount++;
                    currentRackCapacity = rackCapacity;
                }   

                currentRackCapacity -= currentClothes;
            }
            Console.WriteLine(rackCount);


        }
    }
}
