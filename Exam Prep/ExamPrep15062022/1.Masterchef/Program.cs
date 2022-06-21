using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _1.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queueIngredient = new Queue<int>(firstInput);
            Stack<int> stackFreshness = new Stack<int>(secInput);

            Dictionary<string, int> readyFood = new Dictionary<string, int>()
            {
                {"Dipping sauce",0},
                {"Green salad", 0},
                {"Chocolate cake", 0},
                {"Lobster", 0}
            };

            while (queueIngredient.Count > 0 && stackFreshness.Count > 0)
            {
                if (queueIngredient.Peek() == 0) 
                {
                    queueIngredient.Dequeue();
                    continue;
                }

                int currSum = queueIngredient.Peek() * stackFreshness.Peek();

                if (currSum == 150)  
                {
                    readyFood["Dipping sauce"]++;
                    queueIngredient.Dequeue();
                    stackFreshness.Pop();
                }
                else if (currSum == 250)  
                {
                    readyFood["Green salad"]++;
                    queueIngredient.Dequeue();
                    stackFreshness.Pop();
                }
                else if (currSum == 300)  
                {
                    readyFood["Chocolate cake"]++;
                    queueIngredient.Dequeue();
                    stackFreshness.Pop();
                }
                else if (currSum == 400)  
                {
                    readyFood["Lobster"]++;
                    queueIngredient.Dequeue();
                    stackFreshness.Pop();
                }
                else
                {
                    stackFreshness.Pop();
                    int valToEnqueue = queueIngredient.Dequeue() + 5;
                    queueIngredient.Enqueue(valToEnqueue);
                }
            }

            if (readyFood.Any(kvp => kvp.Value == 0))
            {
                Console.WriteLine($"You were voted off. Better luck next year.");
            }
            else
            {
                Console.WriteLine($"Applause! The judges are fascinated by your dishes!");
            }

            if(queueIngredient.Sum() != 0)
                Console.WriteLine($"Ingredients left: {queueIngredient.Sum()}");

            foreach (var kvp in readyFood.OrderBy(x => x.Key))
            {
                if(kvp.Value != 0)
                    Console.WriteLine($"# {kvp.Key} --> {kvp.Value}");
            }

        }
    }
}
