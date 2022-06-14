using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOfStrings = Console.ReadLine().Split();
            int[] arrayOfInts = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> calories = new Stack<int>(arrayOfInts);
            Queue<int> meals = new Queue<int>();

            foreach (string element in arrayOfStrings)
            {
                if (element == "salad")
                {
                    meals.Enqueue(350);
                }
                else if(element == "soup")
                {
                    meals.Enqueue(490);
                }
                else if(element == "pasta")
                {
                    meals.Enqueue(680);
                }
                else if(element == "steak")
                {
                    meals.Enqueue(790);
                }
            }

            int originalNumberOfMeals = meals.Count();


            int storedCalories = 0;
            int diff = calories.Peek();

            while (meals.Count > 0 && calories.Count > 0)
            {
                diff -= meals.Peek();

                if (storedCalories != 0)
                {
                    int calorieisValue = calories.Pop() - storedCalories;
                    calories.Push(calorieisValue);
                    storedCalories = 0;
                }

                if (diff > 0)
                {
                    meals.Dequeue();
                }
                else if(diff == 0)
                {
                    calories.Pop();
                    meals.Dequeue();
                }
                else if(diff < 0)
                {
                    storedCalories = Math.Abs(diff);
                    meals.Dequeue();
                    calories.Pop();
                    diff = calories.Peek();
                }
                
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {originalNumberOfMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {originalNumberOfMeals - meals.Count()} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }



        }
    }
}
