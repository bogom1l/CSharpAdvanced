using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            Stack<int> stackHats = new Stack<int>(input1);
            Queue<int> queueScarfs = new Queue<int>(input2);

            List<int> sets = new List<int>();

            while (stackHats.Count > 0 && queueScarfs.Count > 0)
            {
                int currHat = stackHats.Peek();
                int currScarf = queueScarfs.Peek();

                if (currHat > currScarf)
                {
                    int currSet = currHat + currScarf;
                    sets.Add(currSet);
                    stackHats.Pop();
                    queueScarfs.Dequeue();
                }
                else if (currHat < currScarf)
                {
                    stackHats.Pop();
                }
                else if (currHat == currScarf)
                {
                    queueScarfs.Dequeue();
                    int valueToPush = stackHats.Pop() + 1;
                    stackHats.Push(valueToPush);
                }

            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine($"{string.Join(" ",sets)}");



        }
    }
}
