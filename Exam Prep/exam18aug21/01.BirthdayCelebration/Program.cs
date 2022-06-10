using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NE RAZBIRAM USLOVIETO ????? DVUSMISLENO E MNOGOSMISLENO E NE NZAM KAKVO E QDOSVAM SE


            int[] input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> guestsCapacities = new Stack<int>(input1);
            Queue<int> preparedPlates = new Queue<int>(input2);

            int wastedFood = 0;

            while (true)
            {
                if (guestsCapacities.Count > 0 || preparedPlates.Count > 0)
                {
                    break;
                }

                int currPlate = preparedPlates.Peek();
                int currGuestCapacity = guestsCapacities.Peek();

                if (currPlate >= currGuestCapacity)
                {
                    int currWastedFood = currPlate - currGuestCapacity;
                    wastedFood += currWastedFood;

                    guestsCapacities.Pop();
                    preparedPlates.Dequeue();
                }




            }
            
            
            
            
            
        }
    }
}
