using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _1.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstInts = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] seconInts = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> queueEffect = new Queue<int>(firstInts);
            Stack<int> stackCasing = new Stack<int>(seconInts);

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"Datura Bombs", 0},
                {"Cherry Bombs", 0},
                {"Smoke Decoy Bombs", 0}
            };

            while (queueEffect.Count > 0 && stackCasing.Count > 0)
            {
                int currSum = queueEffect.Peek() + stackCasing.Peek();

                if (currSum == 40)
                {
                    dict["Datura Bombs"]++;
                    queueEffect.Dequeue();
                    stackCasing.Pop();
                }
                else if(currSum == 60)
                {
                    dict["Cherry Bombs"]++;
                    queueEffect.Dequeue();
                    stackCasing.Pop();
                }
                else if(currSum == 120)
                {
                    dict["Smoke Decoy Bombs"]++;
                    queueEffect.Dequeue();
                    stackCasing.Pop();
                }
                else
                {
                    int casingValueToPush = stackCasing.Pop() - 5;
                    stackCasing.Push(casingValueToPush);
                }

                if (isFilled(dict))
                {
                    break;
                }
            }

            if (isFilled(dict))
            {
                Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine($"You don't have enough materials to fill the bomb pouch.");
            }

            if (queueEffect.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", queueEffect)}");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: empty");
            }
            if (stackCasing.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", stackCasing)}");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: empty");
            }

            foreach (var kvp in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }

        static bool isFilled(Dictionary<string,int> dict)
        {
            List<int> list = dict.Values.ToList();

            if (list.TrueForAll(x => x >= 3))
            {
                return true;
            }
            return false;
        }

    }
}
