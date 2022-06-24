using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1._Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstInts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); //liquids
            int[] secondInts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); //ingredients

            Queue<int> queueLiquids = new Queue<int>(firstInts);
            Stack<int> stackIngredients = new Stack<int>(secondInts);

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"Bread", 0},
                {"Cake", 0},
                {"Pastry", 0},
                {"Fruit Pie", 0}
            };

            while (queueLiquids.Count > 0 && stackIngredients.Count > 0)
            {
                int currSum = queueLiquids.Peek() + stackIngredients.Peek();

                if (currSum == 25)
                {
                    dict["Bread"]++;
                    queueLiquids.Dequeue();
                    stackIngredients.Pop();
                }
                else if(currSum == 50)
                {
                    dict["Cake"]++;
                    queueLiquids.Dequeue();
                    stackIngredients.Pop();
                }
                else if(currSum == 75)
                {
                    dict["Pastry"]++;
                    queueLiquids.Dequeue();
                    stackIngredients.Pop();
                }
                else if(currSum == 100)
                {
                    dict["Fruit Pie"]++;
                    queueLiquids.Dequeue();
                    stackIngredients.Pop();
                }
                else
                {
                    queueLiquids.Dequeue();
                    int valueToPush = stackIngredients.Pop() + 3;
                    stackIngredients.Push(valueToPush);
                }

            }

            bool isAllCooked = true;

            foreach (var kvp in dict)
            {
                if (kvp.Value == 0)
                {
                    isAllCooked = false;
                }
            }

            if (isAllCooked)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (queueLiquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ",queueLiquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (stackIngredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", stackIngredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var kvp in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }


        }
    }
}
