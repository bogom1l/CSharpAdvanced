using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mealsCalories = new Dictionary<string, int>
        {
            {"salad", 350},
            {"soup", 490},
            {"pasta", 680},
            {"steak", 790}
        };

            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int startMealsCount = meals.Count;

            while ((meals.Count > 0) && (calories.Count > 0))
            {
                int currentCallories = calories.Pop();

                int currentMealCallories = mealsCalories[meals.Peek()];

                if (currentCallories - currentMealCallories >= 0)
                {
                    currentCallories -= currentMealCallories;
                    meals.Dequeue();
                    calories.Push(currentCallories);
                }
                else if (currentCallories < currentMealCallories && calories.Count > 0)
                {
                    currentCallories -= currentMealCallories; //negative nubmer
                    currentCallories += calories.Pop(); //1910 , meal = 790

                    if (currentCallories > currentMealCallories)
                    {
                        calories.Push(currentCallories);
                        meals.Dequeue();
                    }
                }
                else if (currentCallories < currentMealCallories && calories.Count == 0)
                {
                    meals.Dequeue();
                }
            }

            StringBuilder sb = new StringBuilder();

            if (calories.Count > 0)
            {
                sb.AppendLine($"John had {startMealsCount} meals.");
                sb.AppendLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                sb.AppendLine($"John ate enough, he had {startMealsCount - meals.Count} meals.");
                sb.AppendLine($"Meals left: {string.Join(", ", meals)}.");

            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
