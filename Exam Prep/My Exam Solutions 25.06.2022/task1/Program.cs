using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exam1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstInts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); //white
            int[] secondInts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); //grey

            Queue<int> queueGrey = new Queue<int>(secondInts);
            Stack<int> stackWhite = new Stack<int>(firstInts);

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"Sink", 0},
                {"Oven", 0 },
                {"Countertop", 0 },
                {"Wall", 0 },
                {"Floor",0 }
            };

            while (queueGrey.Count > 0 && stackWhite.Count > 0)
            {
                int currGrey = queueGrey.Peek();
                int currWhite = stackWhite.Peek();

                if (currGrey == currWhite)
                {
                    int currSum = currGrey + currWhite;

                    if (currSum == 40)
                    {
                        dict["Sink"]++;
                        queueGrey.Dequeue();
                        stackWhite.Pop();
                    }
                    else if(currSum == 50)
                    {
                        dict["Oven"]++;
                        queueGrey.Dequeue();
                        stackWhite.Pop();
                    }
                    else if(currSum == 60)
                    {
                        dict["Countertop"]++;
                        queueGrey.Dequeue();
                        stackWhite.Pop();
                    }
                    else if(currSum == 70)
                    {
                        dict["Wall"]++;
                        queueGrey.Dequeue();
                        stackWhite.Pop();
                    }
                    else
                    {
                        dict["Floor"]++;
                        queueGrey.Dequeue();
                        stackWhite.Pop();
                    }
                }

                if (currWhite != currGrey)
                {
                    int valueToPushWhite = stackWhite.Pop() / 2;
                    stackWhite.Push(valueToPushWhite);
                    int valueToEnqueueGrey = queueGrey.Dequeue();
                    queueGrey.Enqueue(valueToEnqueueGrey);
                }

            }

            if (stackWhite.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", stackWhite)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (queueGrey.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", queueGrey)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var kvp in dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if(kvp.Value != 0)
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }




        }
    }
}
