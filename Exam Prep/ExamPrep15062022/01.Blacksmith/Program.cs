using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queueSteel = new Queue<int>(firstInput);
            Stack<int> carbonStack = new Stack<int>(secondInput);

            SortedDictionary<string, int> swords = new SortedDictionary<string, int>()
            {
                {"Gladius", 0 },
                {"Shamshir", 0 },
                {"Katana", 0 },
                {"Sabre", 0 },
                {"Broadsword", 0 }
            };

            int totalSwords = 0;

            while (queueSteel.Count > 0 && carbonStack.Count > 0)
            {
                int currSum = queueSteel.Peek() + carbonStack.Peek();

                if (currSum == 70)
                {
                    swords["Gladius"]++;
                    totalSwords++;
                    queueSteel.Dequeue();
                    carbonStack.Pop();
                }
                else if (currSum == 80)
                {
                    swords["Shamshir"]++;
                    totalSwords++;
                    queueSteel.Dequeue();
                    carbonStack.Pop();
                }
                else if (currSum == 90)
                {
                    swords["Katana"]++;
                    totalSwords++;
                    queueSteel.Dequeue();
                    carbonStack.Pop();
                }
                else if (currSum == 110)
                {
                    swords["Sabre"]++;
                    totalSwords++;
                    queueSteel.Dequeue();
                    carbonStack.Pop();
                }
                else if (currSum == 150)
                {
                    swords["Broadsword"]++;
                    totalSwords++;
                    queueSteel.Dequeue();
                    carbonStack.Pop();
                }
                else
                {
                    queueSteel.Dequeue();

                    int currCarbonToPush = carbonStack.Peek() + 5;
                    carbonStack.Pop();
                    carbonStack.Push(currCarbonToPush);
                }
            }

            if (totalSwords > 0)
            {
                Console.WriteLine($"You have forged {totalSwords} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }

            if (queueSteel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", queueSteel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbonStack.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbonStack)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach(var kvp in swords)
            {
                var key = kvp.Key;
                var val = kvp.Value;

                if (val > 0)
                {
                    Console.WriteLine($"{key}: {val}");
                }   
            }
        }
    }
}
