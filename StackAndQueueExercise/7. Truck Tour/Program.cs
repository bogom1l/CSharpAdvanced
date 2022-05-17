using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Truck_Tour
{
    class Pump
    {
        public Pump(int n, int a, int d)
        {
            this.Number = n;
            this.Amount = a;
            this.Distance = d;
        }
        public int Number{ get; set; }
        public int Amount { get; set; }
        public int Distance { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            int N = int.Parse(Console.ReadLine());

            Queue<Pump> queue = new Queue<Pump>();


            for (int i = 0; i <= N-1; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int currAmount = tokens[0];
                int currDistance = tokens[1];
                Pump currPump = new Pump(i, currAmount, currDistance);

                queue.Enqueue(currPump);
            }

            int totalDistance = queue.Sum(pump => pump.Distance);
            int truckDistance = 0; //izminato razstoqnie


            while (true)
            {
                int truckFuel = 0; //subranoto gorivo

                foreach (Pump currPump in queue)
                {
                    truckFuel += currPump.Amount;
                    


                }
            }



        }
    }
}
